namespace CodingKatas.LeetCoders
{
    public class AtoiKata
    {
        public int Atoi(string input)
        {
            int result, sign, i;
            result = i = sign = 0;

            if (input[0] == '-')
            {
                sign = -1;
                i++;
            }
            else
                sign = 1;

            result = input[i++] - '0';

            for (; i < input.Length; i++)
                result = result * 10 + input[i] - '0';

            return result * sign;
        }
    }
}
