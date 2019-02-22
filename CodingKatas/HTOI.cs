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

            if (input[i] >= '0' && input[i] <= '9')
                n = input[i] - '0';

            return n;
        }
    }
}
