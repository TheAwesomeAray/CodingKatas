using System;
using System.Collections.Generic;
using System.Text;

namespace CodingKatas
{
    public class HtoiKata
    {
        public double Htoi(string input)
        {
            int i, n;
            i = n = 0;

            if (input[i] == '0')
            {
                i++;
                if (input[i] == 'x')
                    i++;
            }

            for (; i < input.Length; i++)
            {
                if (input[i] >= '0' && input[i] <= '9')
                    n = n * 16 + input[i] - '0';
                else if (input[i] >= 'A' && input[i] <= 'F')
                    n = n * 16 + input[i] - 'A' + 10;
            }
            

            return n;
        }
    }
}
