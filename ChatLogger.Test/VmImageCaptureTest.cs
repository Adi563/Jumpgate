using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChatLogger.Test
{
    [TestClass]
    public class VmImageCaptureTest
    {
        [TestMethod]
        public void TakeScreenShot()
        {
            VmImageCapture.TakeScreenShot(@"C:\Program Files\Oracle\VirtualBox\VBoxManage", "Jumpgate", $@"C:\Users\Adrian\Downloads\Temp\{System.DateTime.Now.ToString("yyyyMMddHHmmss")}.png");
        }
    }
}