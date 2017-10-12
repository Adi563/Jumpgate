using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Decrypt.Test
{
    [TestClass]
    public class NumberFactorizerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var login1 = new byte[] { 0x04, 0xeb, 0x2d, 0x52, 0xdf, 0xa3, 0x5f, 0x87, 0x30, 0x71, 0x09, 0x49, 0x20, 0x26, 0x0d, 0x38, 0x3c, 0xba, 0x98, 0xf3 };
            var login2 = new byte[] { 0xdb, 0x55, 0x94, 0xf8, 0x9e, 0xc5, 0x4e, 0x5d, 0x6f, 0xca, 0x74, 0x40, 0xf2, 0xc1, 0xd5, 0xe7, 0xd0, 0x3f, 0x3a, 0x22 };
            var data = login2;

            var number = System.Numerics.BigInteger.Zero;
            for (int i = 0; i < data.Length; i++)
            {
                var exponent = (data.Length - i - 1) * 2;
                number = System.Numerics.BigInteger.Add(number, new System.Numerics.BigInteger(data[i] * System.Math.Pow(16, exponent)));
            }
            
            var factors = GetFactors(number).ToArray();
        }

        public static System.Collections.Generic.IEnumerable<uint> GetFactors(uint x)
        {
            return GetFactors(new System.Numerics.BigInteger(x)).Select(a => (uint)a);
        }

        public static System.Collections.Generic.IEnumerable<System.Numerics.BigInteger> GetFactors(System.Numerics.BigInteger x)
        {
            if (x == 1) { yield return 1; }

            uint state = 2;

            while (x > 1)
            {
                if (x % state == 0)
                {
                    yield return state;
                    x /= state;
                }
                else
                {
                    state++;
                }
            }
        }
    }
}
