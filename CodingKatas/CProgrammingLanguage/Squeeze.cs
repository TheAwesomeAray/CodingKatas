using System;
using System.Collections.Generic;
using System.Text;

namespace CodingKatas
{
    public class SqueezeKata
    {
        public string Squeeze(string s1, string s2)
        {
            for (int i = 0; i < s1.Length; i++)
                for (int j = 0; j < s2.Length; j++)
                    if (s1[i] == s2[j])
                        s1 = s1.Remove(i, 1);

            return s1;
        }
    }
}
