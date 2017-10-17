using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Decrypt.Test
{
    [TestClass]
    public class DeflatTest
    {
        [TestMethod]
        public void Compress()
        {
            using (var streamUncompressed = new System.IO.FileStream(@"C:\Users\Adrian\Downloads\2008_civic_sedan.pdf", System.IO.FileMode.Open))
            using (var streamCompressed = new System.IO.FileStream(@"C:\Users\Adrian\Downloads\2008_civic_sedan.z", System.IO.FileMode.Create))
            {
                var deflateStream = new System.IO.Compression.DeflateStream(streamCompressed, System.IO.Compression.CompressionMode.Compress);
                streamUncompressed.CopyTo(deflateStream);
            }
        }

        [TestMethod]
        public void Decompress()
        {
            using (var streamUncompressed = new System.IO.FileStream(@"C:\Users\Adrian\Downloads\7z1604-x64_2.exe", System.IO.FileMode.Create))
            using (var streamCompressed = new System.IO.FileStream(@"C:\Users\Adrian\Downloads\7z1604-x64.z", System.IO.FileMode.Open))
            {
                var deflateStream = new System.IO.Compression.DeflateStream(streamCompressed, System.IO.Compression.CompressionMode.Decompress);
                deflateStream.CopyTo(streamUncompressed);
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            byte[] data = new byte[] { 0x74, 0x11, 0x09, 0x41, 0x04, 0xb9, 0xd4, 0xfe, 0x4d, 0x5f, 0x9d, 0x84, 0x71, 0x23, 0x73, 0x7b, 0x9c, 0x42, 0x63, 0xf0, 0x0c, 0x3b, 0x45, 0xf2, 0x43, 0xb8, 0xd8, 0xfa, 0x94, 0xa6, 0xe2, 0x69, 0xf5, 0x3b, 0xd2, 0xb6, 0xa3, 0x5a, 0x1c, 0x60, 0x0f, 0x45, 0x84, 0x84, 0x50, 0x80, 0x20, 0x71 };

            var streamCompressed = new System.IO.MemoryStream(data);
            var streamDecompressed = new System.IO.MemoryStream();
            

            var deflateStream = new System.IO.Compression.DeflateStream(streamCompressed, System.IO.Compression.CompressionMode.Decompress);
            deflateStream.CopyTo(streamDecompressed);
        }
    }
}