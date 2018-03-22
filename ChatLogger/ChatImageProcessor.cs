namespace ChatLogger
{
    using System.Linq;

    public class ChatImageProcessor
    {
        const byte MaximumCharactersPerLine = 59;
        const byte LinesPerChat = 6;
        const byte CharacterWidth = 6;
        const byte CharacterHeight = 11;

        private System.Collections.Generic.List<Characters.CharacterBase> characterSet = new System.Collections.Generic.List<Characters.CharacterBase>();

        public ChatImageProcessor()
        {
            characterSet.Add(new Characters.HigherS());
            characterSet.Add(new Characters.LowerE());
        }

        public void ScreenCaptureTest()
        {
            var bitmapOld = new System.Drawing.Bitmap(374, 66);
            var graphicsOld = System.Drawing.Graphics.FromImage(bitmapOld);
            var bitmapNew = new System.Drawing.Bitmap(374, 66);
            var graphicsNew = System.Drawing.Graphics.FromImage(bitmapNew);

            while (true)
            {
                graphicsNew.CopyFromScreen(80, 30, 0, 0, new System.Drawing.Size(bitmapNew.Width, bitmapNew.Height), System.Drawing.CopyPixelOperation.SourceCopy);

                if (CompareImages(bitmapOld, bitmapNew))
                {
                    System.Threading.Thread.Sleep(10000);
                    continue;
                }

                graphicsOld.DrawImage(bitmapNew, 0, 0);

            }
        }

        private static bool CompareImages(System.Drawing.Bitmap image1, System.Drawing.Bitmap image2)
        {
            for (int x = 0; x < image1.Width; x++)
            {
                for (int y = 0; y < image1.Height; y++)
                {
                    if (image1.GetPixel(x, y) != image2.GetPixel(x, y))
                    { return false; }
                }
            }

            return true;
        }


        /// <summary>
        /// Converts the chat image to text.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <returns></returns>
        public string ConvertChatImageToText(System.Drawing.Bitmap bitmap)
        {
            var buffer = new char[LinesPerChat * MaximumCharactersPerLine];

            for (int l = 0; l < LinesPerChat; l++)
            {
                var fontColor = GetFontColor(bitmap, System.Drawing.Color.FromArgb(255, 10, 10, 10), (l * CharacterHeight + CharacterHeight / 2));

                for (int c = 0; c < MaximumCharactersPerLine; c++)
                {
                    byte x = (byte)(c * CharacterWidth);
                    byte y = (byte)(l * CharacterHeight);
                    buffer[l * c + c] = GetChatImageCharacter(bitmap, fontColor, x, y);
                }
            }

            return new string(buffer);
        }


        /// <summary>
        /// Gets the color of the font.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="backgroundColor">Color of the background.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Font color not found</exception>
        public System.Drawing.Color GetFontColor(System.Drawing.Bitmap bitmap, System.Drawing.Color backgroundColor, int y)
        {
            for (int x = 0; x < bitmap.Width; x++)
            {
                var pixelColor = bitmap.GetPixel(x, y);

                if (!pixelColor.Equals(backgroundColor)) { return pixelColor; }
            }

            throw new System.Exception("Font color not found");
        }


        /// <summary>
        /// Gets the chat image character.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="fontColor">Color of the font.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public char GetChatImageCharacter(System.Drawing.Bitmap bitmap, System.Drawing.Color fontColor, int x, int y)
        {
            var colorMap = new System.Drawing.Color[CharacterHeight][];

            for (int h = 0; h < CharacterHeight; h++)
            {
                colorMap[h] = new System.Drawing.Color[CharacterWidth];

                for (int w = 0; w < CharacterWidth; w++)
                {
                    colorMap[h][w] = bitmap.GetPixel(x + w, y + h);
                }
            }

            return GetCharacterByColorMap(colorMap, fontColor);
        }


        /// <summary>
        /// Gets the character by color map.
        /// </summary>
        /// <param name="colorMap">The color map.</param>
        /// <param name="fontColor">Color of the font.</param>
        /// <returns></returns>
        public char GetCharacterByColorMap(System.Drawing.Color[][] colorMap, System.Drawing.Color fontColor)
        {
            var character = characterSet.AsParallel().FirstOrDefault(c => c.Match(colorMap, fontColor));

            if (character == null) { throw new System.NotImplementedException("Character not implemented"); }

            return character.Character;
        }
    }
}