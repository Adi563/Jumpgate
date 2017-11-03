namespace Decrypt
{
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string keyFromString = args[0];
            string keyFromStringPadded = keyFromString.PadLeft(32, '0');

            string keyToString = args[1];
            string keyToStringPadded = keyToString.PadLeft(32, '0');

            var key = StringToByteArray(keyFromStringPadded);
            var keyTo = StringToByteArray(keyToStringPadded);

            var numbersTo = ConvertByteArrayToNumber(keyTo);
            var numberTo1 = numbersTo[0];
            var numberTo2 = numbersTo[1];

            //ulong number1 = 0;
            //ulong number2 = 0;

            var aes = System.Security.Cryptography.Aes.Create();
            aes.KeySize = 128;
            aes.Key = new byte[16];
            aes.GenerateIV();
            aes.Padding = System.Security.Cryptography.PaddingMode.None;

            var encryptedData = new byte[] { 0x06, 0xa3, 0xa1, 0xab, 0x1e, 0x10, 0x9c, 0xa9, 0x40, 0x14, 0xd7, 0x2f, 0x40, 0xdf, 0x51, 0x73, 0x63, 0xf3, 0x08, 0xa9, 0x47, 0x10, 0xe0, 0x03, 0xe3, 0xd8, 0x6a, 0x35, 0x22, 0x7c, 0x28, 0x95, 0xce, 0xd5, 0xbe, 0x72, 0x8d, 0x04, 0xfe, 0x26, 0x9b, 0x60, 0xa9, 0xf6, 0x0a, 0xc8, 0x87, 0x5d };
            var decryptedData = new byte[encryptedData.Length];

            while (key[0] <= keyTo[0] && key[1] <= keyTo[1] && key[2] <= keyTo[2] && key[3] <= keyTo[3] && key[4] <= keyTo[4] && key[5] <= keyTo[5] && key[6] <= keyTo[6] && key[7] <= keyTo[7] && key[8] <= keyTo[8] && key[9] <= keyTo[9] && key[10] <= keyTo[10] && key[11] <= keyTo[11] && key[12] <= keyTo[12] && key[13] <= keyTo[13] && key[14] <= keyTo[14] && key[15] <= keyTo[15])
            {
                if (key[15] < byte.MaxValue) { key[15]++; goto Number1Incremented; }
                if (key[14] < byte.MaxValue) { key[15] = 0; key[14]++; goto Number1Incremented; }
                if (key[13] < byte.MaxValue) { key[15] = key[14] = 0; key[13]++; goto Number1Incremented; }
                if (key[12] < byte.MaxValue) { key[15] = key[14] = key[13] = 0; key[12]++; goto Number1Incremented; }
                if (key[11] < byte.MaxValue) { key[15] = key[14] = key[13] = key[12] = 0; key[11]++; goto Number1Incremented; }
                if (key[10] < byte.MaxValue) { key[15] = key[14] = key[13] = key[12] = key[11] = 0; key[10]++; goto Number1Incremented; }
                if (key[9] < byte.MaxValue) { key[15] = key[14] = key[13] = key[12] = key[11] = key[10] = 0; key[9]++; goto Number1Incremented; }
                if (key[8] < byte.MaxValue) { key[15] = key[14] = key[13] = key[12] = key[11] = key[10] = key[9] = 0; key[8]++; goto Number1Incremented; }
                if (key[7] < byte.MaxValue) { key[15] = key[14] = key[13] = key[12] = key[11] = key[10] = key[9] = key[8] = 0; key[7]++; goto Number1Incremented; }
                if (key[6] < byte.MaxValue) { key[15] = key[14] = key[13] = key[12] = key[11] = key[10] = key[9] = key[8] = key[7] = 0; key[6]++; goto Number2Incremented; }
                if (key[5] < byte.MaxValue) { key[15] = key[14] = key[13] = key[12] = key[11] = key[10] = key[9] = key[8] = key[7] = key[6] = 0; key[5]++; goto Number2Incremented; }
                if (key[4] < byte.MaxValue) { key[15] = key[14] = key[13] = key[12] = key[11] = key[10] = key[9] = key[8] = key[7] = key[6] = key[5] = 0; key[4]++; goto Number2Incremented; }
                if (key[3] < byte.MaxValue) { key[15] = key[14] = key[13] = key[12] = key[11] = key[10] = key[9] = key[8] = key[7] = key[6] = key[5] = key[4] = 0; key[3]++; goto Number2Incremented; }
                if (key[2] < byte.MaxValue) { key[15] = key[14] = key[13] = key[12] = key[11] = key[10] = key[9] = key[8] = key[7] = key[6] = key[5] = key[4] = key[3] = 0; key[2]++; goto Number2Incremented; }
                if (key[1] < byte.MaxValue) { key[15] = key[14] = key[13] = key[12] = key[11] = key[10] = key[9] = key[8] = key[7] = key[6] = key[5] = key[4] = key[3] = key[2] = 0; key[1]++; goto Number2Incremented; }
                if (key[0] < byte.MaxValue) { key[15] = key[14] = key[13] = key[12] = key[11] = key[10] = key[9] = key[8] = key[7] = key[6] = key[5] = key[4] = key[3] = key[2] = key[1] = 0; key[0]++; goto Number2Incremented; }

                //Number2Incremented:
                //number2 = (ulong)(key[0] * 72057594037927936 + key[1] * 281474976710656 + key[2] * 1099511627776 + key[3] * 4294967296 + key[4] * 16777216 + key[5] * 65536 + key[6] * 256 + key[7]);

                //Number1Incremented:
                //number1 = (ulong)(key[8] * 72057594037927936 + key[9] * 281474976710656 + key[10] * 1099511627776 + key[11] * 4294967296 + key[12] * 16777216 + key[13] * 65536 + key[14] * 256 + key[15]);

                Number2Incremented:
                Number1Incremented:

                aes.Key = key;
                var decryptor = aes.CreateDecryptor();
                decryptor.TransformBlock(encryptedData, 0, encryptedData.Length, decryptedData, 0);

                if (decryptedData[45] == 'x' && decryptedData[46] == 'x' && decryptedData[47] == 'x')
                { System.Console.WriteLine(System.Text.Encoding.ASCII.GetString(decryptedData)); }
            }
        }

        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => System.Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private static ulong[] ConvertByteArrayToNumber(byte[] key)
        {
            return new ulong[]
            {
                (ulong)(key[8] * 72057594037927936 + key[9] * 281474976710656 + key[10] * 1099511627776 + key[11] * 4294967296 + key[12] * 16777216 + key[13] * 65536 + key[14] * 256 + key[15]),
                (ulong)(key[0] * 72057594037927936 + key[1] * 281474976710656 + key[2] * 1099511627776 + key[3] * 4294967296 + key[4] * 16777216 + key[5] * 65536 + key[6] * 256 + key[7]),
            };
        }
    }
}