using System;

namespace CodingKatas
{
    public static class OnesAndZeros
    {
        public static int BinaryArrayToNumber(int[] binaryArray)
        {
            var binaryString = string.Join("", binaryArray);
            return Convert.ToInt32(binaryString, 2);
        }
    }
}
