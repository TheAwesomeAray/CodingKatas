using System;
using System.Collections.Generic;
using System.Text;

namespace CodingKatas.LeetCoders
{
    public class AtoiKata
    {
        public int Atoi(string input)
        {
            var character = input[0];

            return character - '0';
        }
    }
}
