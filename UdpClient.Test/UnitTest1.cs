using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UdpClient.Test
{
    using System.Linq;

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

            //TODO: Sometimes e3 01 00  and rest is contained in one package and otherwise
            bytesReceived = udpClient.Receive(ref endPoint);
            //bytesReceived = udpClient.Receive(ref endPoint);

            var bytesToSent = new byte[] { 0x00, 0x80, 0x02, 0xa0, 0x04, 0x07 }.
                Concat(bytesReceived.Skip(9).Take(20)).
                Concat(new byte[] {0x4f, 0x50, 0xc9, 0x6f, 0xad, 0x4e, 0x21, 0xba, 0xc7, 0x5c, 0x37, 0xdf, 0x9f, 0x45, 0x7e, 0x96, 0x21, 0xa8, 0x69, 0x60, 0x23, 0x67, 0xcc, 0x10, 0xf9, 0xb2, 0xeb, 0x31, 0x87, 0xc3, 0xe7, 0x1f }).
                ToArray();

            udpClient.Send(bytesToSent, bytesToSent.Length, endPoint);
            bytesReceived = udpClient.Receive(ref endPoint);
        }
    }
}