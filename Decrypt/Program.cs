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

            ulong number1 = 0;
            ulong number2 = 0;
            
            while (number2 <= numberTo2 && number1 < numberTo1)
            {
                if (key[15] < byte.MaxValue) { key[15]++; goto Number1Incremented; }
                if (key[14] < byte.MaxValue) { key[15] = 0; key[14]++; goto Number1Incremented; }
                if (key[13] < byte.MaxValue) { key[14] = 0; key[13]++; goto Number1Incremented; }
                if (key[12] < byte.MaxValue) { key[13] = 0; key[12]++; goto Number1Incremented; }
                if (key[11] < byte.MaxValue) { key[12] = 0; key[11]++; goto Number1Incremented; }
                if (key[10] < byte.MaxValue) { key[11] = 0; key[10]++; goto Number1Incremented; }
                if (key[9] < byte.MaxValue) { key[10] = 0; key[9]++; goto Number1Incremented; }
                if (key[8] < byte.MaxValue) { key[9] = 0; key[8]++; goto Number1Incremented; }
                if (key[7] < byte.MaxValue) { key[8] = 0; key[7]++; goto Number1Incremented; }
                if (key[6] < byte.MaxValue) { key[7] = 0; key[6]++; goto Number2Incremented; }
                if (key[5] < byte.MaxValue) { key[6] = 0; key[5]++; goto Number2Incremented; }
                if (key[4] < byte.MaxValue) { key[5] = 0; key[4]++; goto Number2Incremented; }
                if (key[3] < byte.MaxValue) { key[4] = 0; key[3]++; goto Number2Incremented; }
                if (key[2] < byte.MaxValue) { key[3] = 0; key[2]++; goto Number2Incremented; }
                if (key[1] < byte.MaxValue) { key[2] = 0; key[1]++; goto Number2Incremented; }
                if (key[0] < byte.MaxValue) { key[1] = 0; key[0]++; goto Number2Incremented; }

                Number2Incremented:
                number2 = (ulong)(key[0] * 72057594037927936 + key[1] * 281474976710656 + key[2] * 1099511627776 + key[3] * 4294967296 + key[4] * 16777216 + key[5] * 65536 + key[6] * 256 + key[7]);

                Number1Incremented:
                number1 = (ulong)(key[8] * 72057594037927936 + key[9] * 281474976710656 + key[10] * 1099511627776 + key[11] * 4294967296 + key[12] * 16777216 + key[13] * 65536 + key[14] * 256 + key[15]);

                //System.Console.WriteLine(number1);
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