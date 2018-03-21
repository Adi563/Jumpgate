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
            new ChatImageProcessor().ScreenCaptureTest();
        }
    }
}