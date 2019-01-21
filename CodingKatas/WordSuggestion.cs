using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingKatas
{
    public class WordSuggestion
    {
        private IEnumerable<string> _words;

        public WordSuggestion(IEnumerable<string> words)
        {
            _words = words;
        }

        public string FindMostSimilar(string term)
        {
            Dictionary<string, int> characterDifferences = new Dictionary<string, int>();

            foreach (var word in _words)
                characterDifferences.Add(word, LevenshteinDistance(term, term.Length, word, word.Length));

            return characterDifferences.First(x => x.Value == characterDifferences.Min(y => y.Value)).Key;
        }

        public int LevenshteinDistance(string s, int len_s, string t, int len_t)
        {
            int cost;
            
            if (len_s == 0) return len_t;
            if (len_t == 0) return len_s;

            /* test if last characters of the strings match */
            if (s[len_s - 1] == t[len_t - 1])
                cost = 0;
            else
                cost = 1;

            /* return minimum of delete char from s, delete char from t, and delete char from both */
            return new[] { LevenshteinDistance(s, len_s - 1, t, len_t) + 1,
                           LevenshteinDistance(s, len_s, t, len_t - 1) + 1,
                           LevenshteinDistance(s, len_s - 1, t, len_t - 1) + cost }.Min();
        }

    }


}
