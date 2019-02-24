namespace CodingKatas
{
    public class ExpandRangeKata
    {
        public string Expand(string s)
        {
            string expandedString = "";

            for (int i = 0, j = 2; j < s.Length; i += 3, j += 3)
            {
                char start = s[i];
                char end = s[j];

                for (int t = start; t <= end; t++)
                    expandedString += (char)t;
            }
            
            return expandedString;
        }
    }
}
