namespace CodingKatas
{
    public class ExpandRangeKata
    {
        public string Expand(string s)
        {
            char start = s[0];
            char end = s[2];
            string expandedString = start.ToString();

            for (int i = start + 1; i <= end; i++)
                expandedString += (char)i;

            return expandedString;
        }
    }
}
