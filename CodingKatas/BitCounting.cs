using System;
using System.Linq;
using System.Text;

namespace CodingKatas
{
    public static class BitCounting
    {
        private static byte one => Encoding.Unicode.GetBytes("1")[0];

        public static int CountBits(int n)
        {
            var bytes = Encoding.Unicode.GetBytes(Convert.ToString(n, 2));
            return bytes.Count(x => x == one);
        }
    }

    public static class BitCountingSolution
    {
        public static int CountBits(int n)
        {
            return Convert.ToString(n, 2).Count(x => x == '1');
        }
    }
}
