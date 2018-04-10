using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChatLogger.Test
{
    [TestClass]
    public class VmImageCaptureTest
    {
        [TestMethod]
        public void TakeScreenShot()
        {
            while (true)
            {
                VmImageCapture.TakeScreenShot(@"C:\Program Files\Oracle\VirtualBox\VBoxManage", "Jumpgate", $@"C:\Users\Adrian\Downloads\Jumpgate\{System.DateTime.Now.ToString("yyyyMMddHHmmss")}.png");
                System.Threading.Thread.Sleep(10000);
            }
        }
    }
}