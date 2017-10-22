using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UdpClient.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var udpClient = new System.Net.Sockets.UdpClient();
            var endPoint = new System.Net.IPEndPoint(System.Net.IPAddress.Parse("194.87.95.140"), 5150);

            udpClient.Send(new byte[] { 0x0a, 0x00 }, 2, endPoint);
            var bytesReceived = udpClient.Receive(ref endPoint);

            udpClient.Send(new byte[] { 0x00, 0x00, 0x27, 0x00, 0x05 }, 5, endPoint);
            bytesReceived = udpClient.Receive(ref endPoint);
            bytesReceived = udpClient.Receive(ref endPoint);
        }
    }
}
