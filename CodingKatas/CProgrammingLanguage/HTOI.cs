using System;
using System.Collections.Generic;
using System.Text;

namespace CodingKatas
{
    public class HtoiKata
    {
        public double Htoi(string input)
        {
            int n = 0;

            int i = GetStartingIndex(input);

            for (; i < input.Length; i++)
                n = n * 16 + ConvertHexidecimalToInt(input[i]);
            
            return n;
        }

        private int ConvertHexidecimalToInt(char c)
        {
            if (c >= '0' && c <= '9')
                return c - '0';
            else if (c >= 'A' && c <= 'F')
                return c - 'A' + 10;
            else if (c >= 'a' && c <= 'f')
                return c - 'a' + 10;
            else
                throw new InvalidOperationException("Invalid Hexidecimal provided.");
        }

        private int GetStartingIndex(string input)
        {
            int i = 0;

            if (input[i] == '0')
            {
                i++;
                if (input[i] == 'x' || input[i] == 'X')
                    i++;
            }

            return i;
        }
    }
}
