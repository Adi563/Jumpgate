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
        public void CompressData()
        {
            var data = System.Text.Encoding.ASCII.GetBytes("test");
            byte[] data2;
            using (var streamUncompressed = new System.IO.MemoryStream(data))
            using (var streamCompressed = new System.IO.MemoryStream())
            {
                var deflateStream = new System.IO.Compression.DeflateStream(streamCompressed, System.IO.Compression.CompressionMode.Compress, true);
                streamUncompressed.CopyTo(deflateStream);
                deflateStream.Close();

                data2 = streamCompressed.ToArray();
            }
        }

        [TestMethod]
        public void DecompressData()
        {
            byte[] data = new byte[] { 43, 73, 45, 46, 1, 0 };
            var data2 = new byte[100];

            using (var streamUncompressed = new System.IO.MemoryStream(data2))
            using (var streamCompressed = new System.IO.MemoryStream(data))
            {
                var deflateStream = new System.IO.Compression.DeflateStream(streamCompressed, System.IO.Compression.CompressionMode.Decompress);
                deflateStream.CopyTo(streamUncompressed);
                deflateStream.Flush();
                deflateStream.Close();
            }
        }
    }
}