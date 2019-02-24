namespace CodingKatas
{
    public class EscapeKata
    {
        public void Escape(char[] s, char[] t)
        {
            int j = 0;

            for (int i = 0; i < t.Length; i++)
            {
                switch (t[i])
                {
                    case '\t':
                        s[j++] = '\\';
                        s[j] = 't';
                        break;
                    case '\n':
                        s[j++] = '\\';
                        s[j] = 'n';
                        break;
                    default:
                        s[j] = t[i];
                        break;
                }
                j++;
            }
        }
    }
}
