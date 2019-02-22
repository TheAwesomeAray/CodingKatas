using System;
using System.Collections.Generic;
using System.Text;

namespace CodingKatas
{
    public class HtoiKata
    {
        public double Htoi(string input)
        {
            int i, n, hexValue;
            i = n = hexValue = 0;

            if (input[i] == '0')
            {
                i++;
                if (input[i] == 'x')
                    i++;
            }

            for (; i < input.Length; i++)
            {
                if (input[i] >= '0' && input[i] <= '9')
                    hexValue = input[i] - '0';
                else if (input[i] >= 'A' && input[i] <= 'F')
                    hexValue = input[i] - 'A' + 10;

                n = n * 16 + hexValue;
            }

           


            return n;
        }
    }
}
