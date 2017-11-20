using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChatLogger.Test
{
    [TestClass]
    public class ChatLoggerTest
    {
        [TestMethod]
        public void OcrWebserviceTest()
        {
            byte[] imageData;
            using (var stream = new System.IO.MemoryStream())
            {
                Properties.Resources.screen.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                imageData = stream.ToArray();
            }

            var ocrWebServiceClient = new OcrWebService.OCRWebServiceSoapClient("OCRWebServiceSoap");
            var ocrImageData = new OcrWebService.OCRWSInputImage { fileName = "screen.jpg", fileData = imageData };
            var ocrSettings = new OcrWebService.OCRWSSettings
            {
                ocrLanguages = new OcrWebService.OCRWS_Language[] { OcrWebService.OCRWS_Language.ENGLISH },
                outputDocumentFormat = OcrWebService.OCRWS_OutputFormat.TXT,
                createOutputDocument = true
            };

            var response = ocrWebServiceClient.OCRWebServiceRecognize("hanswurscht", "8F799807-CC64-4138-BF24-A795E5993D18", ocrImageData, ocrSettings);
        }


        [TestMethod]
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