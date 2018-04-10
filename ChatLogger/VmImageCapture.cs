namespace ChatLogger
{
    public class VmImageCapture
    {
        public static void TakeScreenShot(string vmManageFilePath, string vmName, string screenShotFilePath)
        {
            var process = System.Diagnostics.Process.Start(vmManageFilePath, $"controlvm {vmName} screenshotpng {screenShotFilePath}");
        }
    }
}