namespace CodingKatas.CProgrammingLanguage
{
    public class StringIndexKata
    {
        public int StringIndex(string s, string t)
        {
            for (int i = s.Length - 1; i >= 0; i--)
            {
                int j, k;
                for (j = t.Length - 1, k = i; j >= 0 && s[k] == t[j]; j--, k--)
                    ;

                if (j == -1)
                    return k + 1;
            }

            return -1;
        }
    }
}
