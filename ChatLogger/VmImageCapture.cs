namespace ChatLogger
{
    public class VmImageCapture
    {
        public static void TakeScreenShot(string vmManageFilePath, string vmName, string screenShotFilePath)
        {
            //var process = System.Diagnostics.Process.Start(vmManageFilePath, $"controlvm {vmName} screenshotpng {screenShotFilePath}");
            var process = new System.Diagnostics.Process();
            process.StartInfo.FileName = vmManageFilePath;
            process.StartInfo.Arguments = $"controlvm {vmName} screenshotpng {screenShotFilePath}";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.Start();
        }
    }
}