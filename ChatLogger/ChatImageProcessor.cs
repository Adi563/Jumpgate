namespace ChatLogger
{
    public class ChatImageProcessor
    {
        const byte MaximumCharactersPerLine = 59;
        const byte LinesPerChat = 6;
        const byte CharacterWidth = 5;
        const byte CharacterHeight = 9;

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
                    byte x = (byte)(c * CharacterWidth + 1);
                    byte y = (byte)(l * CharacterHeight + 1);
                    buffer[l * c + c] = GetChatImageCharacter(bitmap, x, y);
                }
            }
            
            return null;
        }

        public char GetChatImageCharacter(System.Drawing.Bitmap bitmap, int x, int y)
        {
            var pixel00 = bitmap.GetPixel(x + 0, y + 0);
            var pixel10 = bitmap.GetPixel(x + 1, y + 0);
            var pixel20 = bitmap.GetPixel(x + 2, y + 0);
            var pixel30 = bitmap.GetPixel(x + 3, y + 0);
            var pixel40 = bitmap.GetPixel(x + 4, y + 0);

            return ' ';
        }
    }
}