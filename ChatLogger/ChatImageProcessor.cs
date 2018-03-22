namespace ChatLogger
{
    public class ChatImageProcessor
    {
        const byte MaximumCharactersPerLine = 59;
        const byte LinesPerChat = 6;
        const byte CharacterWidth = 6;
        const byte CharacterHeight = 11;

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

        public string ConvertChatImageToText(System.Drawing.Bitmap bitmap)
        {
            var buffer = new char[LinesPerChat * MaximumCharactersPerLine];

            for (int l = 0; l < LinesPerChat; l++)
            {
                for (int c = 0; c < MaximumCharactersPerLine; c++)
                {
                    byte x = (byte)(c * CharacterWidth);
                    byte y = (byte)(l * CharacterHeight);
                    buffer[l * c + c] = GetChatImageCharacter(bitmap, x, y);
                }
            }

            return new string(buffer);
        }

        public char GetChatImageCharacter(System.Drawing.Bitmap bitmap, int x, int y)
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

            return GetCharacterByColorMap(colorMap, System.Drawing.Color.FromArgb(255, 255, 255, 0));
        }

        public char GetCharacterByColorMap(System.Drawing.Color[][] colorMap, System.Drawing.Color fontColor)
        {
            if (Characters.S.Match(colorMap, fontColor))
            { return 'S'; }

            return ' ';
        }
    }
}