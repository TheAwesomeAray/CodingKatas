namespace CodingKatas.LeetCoders
{
    public class AtoiKata
    {
        public int Atoi(string input)
        {
            int result = input[0] - '0';

            for (int i = 1; i < input.Length; i++)
                result = result * 10 + input[i] - '0';

            return result;
        }
    }
}
