using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Decrypt.Test
{
    using System.Linq;

    [TestClass]
    public class AesTest
    {
        [TestMethod]
        public void Encrypt()
        {
            var decryptedData = System.Text.Encoding.ASCII.GetBytes("Test ist ein Testxxx".PadRight(32));

            var aes = System.Security.Cryptography.Aes.Create();
            aes.KeySize = 128;
            aes.Key = new byte[] { 0x27, 0x8c, 0x9b, 0xd8, 0xcc, 0xca, 0x0f, 0x86, 0x4b, 0x0c, 0xa3, 0x02, 0x20, 0xc5, 0x87, 0xa2 };
            aes.GenerateIV();
            aes.Padding = System.Security.Cryptography.PaddingMode.Zeros;

            var decryptedDataWithIv = decryptedData.Concat(aes.IV).ToArray();

            var encryptor = aes.CreateEncryptor();
            var encryptedData = encryptor.TransformFinalBlock(decryptedDataWithIv, 0, decryptedDataWithIv.Length);

            string encryptedDataString = string.Join(",", encryptedData.Select(b => "0x" + b.ToString("X2")));
        }

        [TestMethod]
        public void Decrypt()
        {
            var encryptedData = new byte[] { 0x23, 0x3C, 0x96, 0x4A, 0x8D, 0x98, 0x96, 0xC6, 0xFC, 0xB2, 0x37, 0x17, 0xC2, 0x7E, 0x83, 0xA8, 0x3D, 0xAB, 0xA6, 0xC7, 0x0E, 0xD5, 0xD6, 0x1F, 0x13, 0xBB, 0x33, 0x87, 0x9B, 0xA9, 0x9F, 0x75, 0x27, 0xAC, 0x0C, 0x40, 0x00, 0xCB, 0x5E, 0x13, 0xA7, 0xB5, 0xB6, 0x36, 0xCE, 0xBE, 0xF4, 0xA9 };

            var aes = System.Security.Cryptography.Aes.Create();
            aes.KeySize = 128;
            aes.Key = new byte[] { 0x27, 0x8c, 0x9b, 0xd8, 0xcc, 0xca, 0x0f, 0x86, 0x4b, 0x0c, 0xa3, 0x02, 0x20, 0xc5, 0x87, 0xa2 };
            aes.GenerateIV();
            aes.Padding = System.Security.Cryptography.PaddingMode.Zeros;

            var decryptor = aes.CreateDecryptor();
            var decryptedDataWtihIv = new byte[encryptedData.Length];
            decryptor.TransformBlock(encryptedData, 0, encryptedData.Length, decryptedDataWtihIv, 0);

            aes.IV = decryptedDataWtihIv.Skip(decryptedDataWtihIv.Length - aes.IV.Length).Take(aes.IV.Length).ToArray();
            decryptor = aes.CreateDecryptor();
            decryptor.TransformBlock(encryptedData, 0, aes.IV.Length, decryptedDataWtihIv, 0);

            var decryptedData = decryptedDataWtihIv.Take(decryptedDataWtihIv.Length - aes.IV.Length).ToArray();
            System.Diagnostics.Debug.Write(System.Text.Encoding.ASCII.GetString(decryptedData));
        }

        [TestMethod]
        public void EncryptAndSignAndAddInitialisationVecor()
        {
            var decryptedData = System.Text.Encoding.ASCII.GetBytes("Test ist ein xxx".PadRight(16));

            var aes = System.Security.Cryptography.Aes.Create();
            aes.KeySize = 128;
            aes.Key = new byte[] { 0x27, 0x8c, 0x9b, 0xd8, 0xcc, 0xca, 0x0f, 0x86, 0x4b, 0x0c, 0xa3, 0x02, 0x20, 0xc5, 0x87, 0xa2 };
            aes.IV = new byte[] { 0x22, 0x8c, 0x9b, 0xd8, 0xcc, 0xca, 0x0f, 0x86, 0x4b, 0x0c, 0xa3, 0x02, 0x20, 0xc5, 0x87, 0xa2 };
            aes.Padding = System.Security.Cryptography.PaddingMode.None;

            // Sign plaintext. Concat plaintext with last block of encryption
            var encryptor = aes.CreateEncryptor();
            var signatureData = encryptor.TransformFinalBlock(decryptedData, 0, decryptedData.Length);

            //Add IV and encrypt plaintext message with signature
            var decryptedDataWithSignatureAndIv = decryptedData.Concat(signatureData).Concat(aes.IV).ToArray();
            var encryptedData = encryptor.TransformFinalBlock(decryptedDataWithSignatureAndIv, 0, decryptedDataWithSignatureAndIv.Length);

            string encryptedDataString = string.Join(",", encryptedData.Select(b => "0x" + b.ToString("X2")));
        }

        [TestMethod]
        public void DecryptAndCheckSignature()
        {
            var encryptedData = new byte[] { 0x8E, 0xF2, 0x30, 0x9E, 0x81, 0x5E, 0xFB, 0x9D, 0x30, 0x21, 0x2B, 0x3A, 0xA7, 0x9F, 0x21, 0xFD, 0x09, 0x64, 0x12, 0x2D, 0xC1, 0xDC, 0x01, 0xFA, 0xA6, 0xB7, 0xF8, 0xB0, 0x42, 0x4F, 0x8C, 0xD1, 0x02, 0x36, 0xEE, 0x02, 0xD3, 0xB4, 0x54, 0xF6, 0xD0, 0x17, 0x7F, 0x04, 0xD9, 0x0A, 0xF8, 0xF8 };

            var aes = System.Security.Cryptography.Aes.Create();
            aes.KeySize = 128;
            aes.Key = new byte[] { 0x27, 0x8c, 0x9b, 0xd8, 0xcc, 0xca, 0x0f, 0x86, 0x4b, 0x0c, 0xa3, 0x02, 0x20, 0xc5, 0x87, 0xa2 };
            aes.GenerateIV();
            aes.Padding = System.Security.Cryptography.PaddingMode.None;

            var decryptor = aes.CreateDecryptor();
            var decryptedDataWithSignatureAndIv = decryptor.TransformFinalBlock(encryptedData, 0, encryptedData.Length);

            aes.IV = decryptedDataWithSignatureAndIv.Skip(decryptedDataWithSignatureAndIv.Length - aes.IV.Length).Take(aes.IV.Length).ToArray();
            decryptor = aes.CreateDecryptor();
            decryptedDataWithSignatureAndIv = decryptor.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            
            var signatureData = decryptedDataWithSignatureAndIv.Skip(decryptedDataWithSignatureAndIv.Length - 16 - aes.IV.Length).Take(16).ToArray();
            var decryptedData = decryptedDataWithSignatureAndIv.Take(decryptedDataWithSignatureAndIv.Length - signatureData.Length - aes.IV.Length).ToArray();
            System.Diagnostics.Debug.Write(System.Text.Encoding.ASCII.GetString(decryptedData));

            var encryptor = aes.CreateEncryptor();
            var signatureData2 = encryptor.TransformFinalBlock(decryptedData, 0, decryptedData.Length);

            bool signatureOk = signatureData.SequenceEqual(signatureData2);
        }
        
        [TestMethod]
        public void Decrypt2()
        {
            var aes = System.Security.Cryptography.Aes.Create();
            aes.KeySize = 128;
            aes.Key = new byte[] { 0x27, 0x8c, 0x9b, 0xd8, 0xcc, 0xca, 0x0f, 0x86, 0x4b, 0x0c, 0xa3, 0x02, 0x20, 0xc5, 0x87, 0xa2 };
            aes.IV = new byte[] { 0x06, 0xa3, 0xa1, 0xab, 0x1e, 0x10, 0x9c, 0xa9, 0x40, 0x14, 0xd7, 0x2f, 0x40, 0xdf, 0x51, 0x73 };
            aes.Padding = System.Security.Cryptography.PaddingMode.None;

            var decryptor = aes.CreateDecryptor();

            var encryptedData = new byte[] { 0x06, 0xa3, 0xa1, 0xab, 0x1e, 0x10, 0x9c, 0xa9, 0x40, 0x14, 0xd7, 0x2f, 0x40, 0xdf, 0x51, 0x73, 0x63, 0xf3, 0x08, 0xa9, 0x47, 0x10, 0xe0, 0x03, 0xe3, 0xd8, 0x6a, 0x35, 0x22, 0x7c, 0x28, 0x95, 0xce, 0xd5, 0xbe, 0x72, 0x8d, 0x04, 0xfe, 0x26, 0x9b, 0x60, 0xa9, 0xf6, 0x0a, 0xc8, 0x87, 0x5d };
            var decryptedData = new byte[encryptedData.Length];
            decryptor.TransformBlock(encryptedData, 0, encryptedData.Length, decryptedData, 0);

            System.Diagnostics.Debug.Write(System.Text.Encoding.ASCII.GetString(decryptedData));
        }

        [TestMethod]
        public void GenerateKey()
        {
            byte[] key = new byte[16];
            ulong number = 0;

            //2^0+2^8+2^16+2^24+2^32...

            var stopWatch = System.Diagnostics.Stopwatch.StartNew();

            while (number++ < 3471082340)
            {
                key[7] = (byte)(number >> 56);
                key[6] = (byte)(number >> 48);
                key[5] = (byte)(number >> 40);
                key[4] = (byte)(number >> 32);
                key[3] = (byte)(number >> 24);
                key[2] = (byte)(number >> 16);
                key[1] = (byte)(number >> 8);
                key[0] = (byte)number;
            }

            stopWatch.Stop();

            System.Diagnostics.Debug.WriteLine(stopWatch.Elapsed);
        }

        [TestMethod]
        public void GenerateKeyAndDecrypt()
        {
            var aes = System.Security.Cryptography.Aes.Create();
            aes.KeySize = 128;
            aes.Key = new byte[16];
            aes.GenerateIV();
            aes.Padding = System.Security.Cryptography.PaddingMode.None;

            var encryptedData = new byte[] { 0x06, 0xa3, 0xa1, 0xab, 0x1e, 0x10, 0x9c, 0xa9, 0x40, 0x14, 0xd7, 0x2f, 0x40, 0xdf, 0x51, 0x73, 0x63, 0xf3, 0x08, 0xa9, 0x47, 0x10, 0xe0, 0x03, 0xe3, 0xd8, 0x6a, 0x35, 0x22, 0x7c, 0x28, 0x95, 0xce, 0xd5, 0xbe, 0x72, 0x8d, 0x04, 0xfe, 0x26, 0x9b, 0x60, 0xa9, 0xf6, 0x0a, 0xc8, 0x87, 0x5d };
            var decryptedData = new byte[encryptedData.Length];

            byte[] key = new byte[16];
            ulong number1 = ulong.MaxValue - 1;
            ulong number2 = 0;

            //2^0+2^8+2^16+2^24+2^32...
            
            while (number2 < ulong.MaxValue)
            {
                key[0] = (byte)number1;
                if (key[0] < byte.MaxValue) { goto NumberIncrease; }

                key[1] = (byte)(number1 >> 8);
                if (key[1] < byte.MaxValue) { goto NumberIncrease; }

                key[2] = (byte)(number1 >> 16);
                if (key[2] < byte.MaxValue) { goto NumberIncrease; }

                key[3] = (byte)(number1 >> 24);
                if (key[3] < byte.MaxValue) { goto NumberIncrease; }

                key[4] = (byte)(number1 >> 32);
                if (key[4] < byte.MaxValue) { goto NumberIncrease; }

                key[5] = (byte)(number1 >> 40);
                if (key[5] < byte.MaxValue) { goto NumberIncrease; }

                key[6] = (byte)(number1 >> 48);
                if (key[6] < byte.MaxValue) { goto NumberIncrease; }

                key[7] = (byte)(number1 >> 56);
                if (key[7] < byte.MaxValue) { goto NumberIncrease; } else { number2++; }

                key[8] = (byte)number2;
                if (key[8] < byte.MaxValue) { goto NumberIncrease; }

                key[9] = (byte)(number2 >> 8);
                if (key[9] < byte.MaxValue) { goto NumberIncrease; }

                key[10] = (byte)(number2 >> 16);
                if (key[10] < byte.MaxValue) { goto NumberIncrease; }

                key[11] = (byte)(number2 >> 24);
                if (key[11] < byte.MaxValue) { goto NumberIncrease; }

                key[12] = (byte)(number2 >> 32);
                if (key[12] < byte.MaxValue) { goto NumberIncrease; }

                key[13] = (byte)(number2 >> 40);
                if (key[13] < byte.MaxValue) { goto NumberIncrease; }

                key[14] = (byte)(number2 >> 48);
                if (key[14] < byte.MaxValue) { goto NumberIncrease; }

                key[15] = (byte)(number2 >> 56);
                //if (key[15] < byte.MaxValue) { goto NumberIncrease; }

                NumberIncrease:
                number1++;

                //aes.Key = key;
                //var decryptor = aes.CreateDecryptor();
                //decryptor.TransformBlock(encryptedData, 0, encryptedData.Length, decryptedData, 0);

                //if (decryptedData[45] == 'x' && decryptedData[46] == 'x' && decryptedData[47] == 'x')
                //{ System.Diagnostics.Debug.WriteLine(System.Text.Encoding.ASCII.GetString(decryptedData)); }
            }
        }
    }
}