using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Launcher.Test
{
    [TestClass]
    public class LauncherTest
    {
        [TestMethod]
        public void WriteUserFile()
        {
            //string userName = "Adi563";
            //string password = "hanswurscht";

            string userName = "@Broker01";
            string password = "NqKuKbE1e";

            using (var stream = new System.IO.FileStream(@"C:\Games\Jumpgate\user.bin", System.IO.FileMode.Create))
            {
                Logic.WriteUserFile(stream, userName, password);
            }
        }
    }
}