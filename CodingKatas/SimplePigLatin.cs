using System.Collections.Generic;
using System.Linq;

namespace CodingKatas
{
    public class SimplePigLatin
    {
        public static string PigIt(string str)
        {
            List<string> sentence = new List<string>();

            foreach (var word in str.Split(' '))
                sentence.Add($"{word.Substring(1, word.Length - 1)}{word.Substring(0, 1)}ay");
            
            return sentence.Aggregate((a, b) => a + " " + b);
        }
    }

    public class SimplePigLatinSolution
    {
        public static string PigIt(string str)
        {
            return string.Join(" ", str.Split(' ').Select(w => w.Substring(1) + w[0] + "ay"));
        }
    }
}
