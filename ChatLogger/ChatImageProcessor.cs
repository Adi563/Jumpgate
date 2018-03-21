namespace ChatLogger
{
    public class ChatImageProcessor
    {
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
    }
}