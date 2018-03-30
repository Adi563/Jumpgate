using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChatLogger.Test
{
    [TestClass]
    public class ChatLoggerTest
    {
        //[TestMethod]
        //public void OcrWebserviceTest()
        //{
        //    byte[] imageData;

        //    var stream = this.GetType().Assembly.GetManifestResourceStream("ChatLogger.Test.Rescources.chat.jpg");
        //    //imageData = stream.ToArray();
        //    var bitmap = System.Drawing.Bitmap.FromStream(stream);
            

        //    var ocrWebServiceClient = new OcrWebService.OCRWebServiceSoapClient("OCRWebServiceSoap");
        //    var ocrImageData = new OcrWebService.OCRWSInputImage { fileName = "screen.jpg", fileData = imageData };
        //    var ocrSettings = new OcrWebService.OCRWSSettings
        //    {
        //        ocrLanguages = new OcrWebService.OCRWS_Language[] { OcrWebService.OCRWS_Language.ENGLISH },
        //        outputDocumentFormat = OcrWebService.OCRWS_OutputFormat.TXT,
        //        createOutputDocument = true
        //    };

        //    var response = ocrWebServiceClient.OCRWebServiceRecognize("hanswurscht", "8F799807-CC64-4138-BF24-A795E5993D18", ocrImageData, ocrSettings);
        //}


        [TestMethod]
        public void ScreenCaptureTest()
        {
            new ChatImageProcessor().ScreenCaptureTest(@"C:\Users\Adrian\Downloads\Temp\chat.txt");
        }

        [TestMethod]
        public void GetChatImageFromScreenshot()
        {
            var screenshot = System.Drawing.Bitmap.FromFile(@"C:\Users\Adrian\Downloads\Temp\VirtualBox_Jumpgate_23_03_2018_10_40_27.png");
            var image = new ChatImageProcessor().GetChatImageFromScreenshot(screenshot);
            image.Save(@"C:\Users\Adrian\Downloads\Temp\chat.png");
        }

        [TestMethod]
        public void ConvertChatImageToText()
        {
            var stream = this.GetType().Assembly.GetManifestResourceStream("ChatLogger.Test.Rescources.SpecialCharacters.png");
            //var stream = System.IO.File.Open(@"C:\Users\Adrian\Downloads\Temp\chat.png", System.IO.FileMode.Open);

            var bitmap = System.Drawing.Bitmap.FromStream(stream);

            var chatImageProcessor = new ChatImageProcessor();
            string text = chatImageProcessor.ConvertChatImageToText((System.Drawing.Bitmap)bitmap);
        }
    }
}