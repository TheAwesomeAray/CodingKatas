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
                characterDifferences.Add(word, GetMinimumChangedCharactersToMakeMatch(term, word));

            return characterDifferences.First(x => x.Value == characterDifferences.Min(y => y.Value)).Key;
        }

        public int GetMinimumChangedCharactersToMakeMatch(string s, string t)
        {
            int[,] d = new int[s.Length, t.Length];

            for (int i = 0; i < s.Length; i++)
                d[i, 0] = 0;

            for (int i = 1; i < s.Length; i++)
                d[i, 0] = i;

            for (int j = 1; j < t.Length; j++)
                d[0, j] = j;

            for (int j = 1; j < t.Length; j++)
            {
                for (int i = 1; i < s.Length; i++)
                {
                    int substutionCost;
                    if (s[i] == t[j])
                        substutionCost = 0;
                    else
                        substutionCost = 1;

                    d[i, j] = new[] { d[i - 1, j] + 1,
                                     d[i, j - 1] + 1,
                                     d[i - 1, j - 1] + substutionCost }.Min();
                }
            }

            return d[s.Length - 1, t.Length - 1];
        }
    }
}
