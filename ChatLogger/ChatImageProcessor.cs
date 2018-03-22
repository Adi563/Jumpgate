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
            characterSet.Add(new Characters.HigherA());
            characterSet.Add(new Characters.HigherB());
            characterSet.Add(new Characters.HigherC());
            characterSet.Add(new Characters.HigherD());
            characterSet.Add(new Characters.HigherE());
            characterSet.Add(new Characters.HigherF());
            characterSet.Add(new Characters.HigherG());
            characterSet.Add(new Characters.HigherH());
            characterSet.Add(new Characters.HigherI());
            characterSet.Add(new Characters.HigherJ());
            characterSet.Add(new Characters.HigherK());
            characterSet.Add(new Characters.HigherL());
            characterSet.Add(new Characters.HigherM());
            characterSet.Add(new Characters.HigherN());
            characterSet.Add(new Characters.HigherO());
            characterSet.Add(new Characters.HigherP());
            characterSet.Add(new Characters.HigherQ());
            characterSet.Add(new Characters.HigherR());
            characterSet.Add(new Characters.HigherS());
            characterSet.Add(new Characters.HigherT());
            characterSet.Add(new Characters.HigherU());
            characterSet.Add(new Characters.HigherV());
            characterSet.Add(new Characters.HigherW());
            characterSet.Add(new Characters.HigherX());
            characterSet.Add(new Characters.HigherY());
            characterSet.Add(new Characters.HigherZ());
            characterSet.Add(new Characters.LowerA());
            characterSet.Add(new Characters.LowerB());
            characterSet.Add(new Characters.LowerC());
            characterSet.Add(new Characters.LowerD());
            characterSet.Add(new Characters.LowerE());
            characterSet.Add(new Characters.LowerF());
            characterSet.Add(new Characters.LowerG());
            characterSet.Add(new Characters.LowerH());
            characterSet.Add(new Characters.LowerI());
            characterSet.Add(new Characters.LowerJ());
            characterSet.Add(new Characters.LowerK());
            characterSet.Add(new Characters.LowerL());
            characterSet.Add(new Characters.LowerM());
            characterSet.Add(new Characters.LowerN());
            characterSet.Add(new Characters.LowerO());
            characterSet.Add(new Characters.LowerP());
            characterSet.Add(new Characters.LowerR());
            characterSet.Add(new Characters.LowerS());
            characterSet.Add(new Characters.LowerT());
            characterSet.Add(new Characters.LowerU());
            characterSet.Add(new Characters.LowerV());
            characterSet.Add(new Characters.LowerW());
            characterSet.Add(new Characters.LowerY());
            characterSet.Add(new Characters.NumberZero());
            characterSet.Add(new Characters.NumberOne());
            characterSet.Add(new Characters.NumberThree());
            characterSet.Add(new Characters.NumberFour());
            characterSet.Add(new Characters.NumberFive());
            characterSet.Add(new Characters.NumberSix());
            characterSet.Add(new Characters.SpecialSpace());
            characterSet.Add(new Characters.SpecialAt());
            characterSet.Add(new Characters.SpecialColon());
            characterSet.Add(new Characters.SpecialDot());
            characterSet.Add(new Characters.SpecialBracketOpen());
            characterSet.Add(new Characters.SpecialBracketClosed());
            characterSet.Add(new Characters.SpecialSlash());
            characterSet.Add(new Characters.SpecialExclamation());
            characterSet.Add(new Characters.SpecialHyphen());
            characterSet.Add(new Characters.SpecialApostrophe());
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
            var buffer = new char[LinesPerChat * MaximumCharactersPerLine + LinesPerChat * 2];

            var backgroundColor = bitmap.GetPixel(0, 0);

            for (int l = 0; l < LinesPerChat; l++)
            {
                var fontColor = GetFontColor(bitmap, backgroundColor, (l * CharacterHeight + CharacterHeight / 2));

                for (int c = 0; c < MaximumCharactersPerLine; c++)
                {
                    int x = c * CharacterWidth;
                    int y = l * CharacterHeight;
                    buffer[l * MaximumCharactersPerLine + c + l * 2] = GetChatImageCharacter(bitmap, fontColor, x, y);
                }

                buffer[(l+1) * MaximumCharactersPerLine + l * 2] = '\r';
                buffer[(l+1) * MaximumCharactersPerLine + l * 2 + 1] = '\n';
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