using System;
using System.Linq;

namespace CodingKatas
{
    public class ReverseIntegerKata
    {
        public int Reverse(int x)
        {
            bool negative = x < 0;

            var arr = Math.Abs(x).ToString()
                       .ToCharArray()
                       .Reverse();

            var reversedInteger = int.Parse(new string(arr.ToArray()));

            if (negative)
                return reversedInteger * -1;
            

            return reversedInteger;
        }
    }
}
