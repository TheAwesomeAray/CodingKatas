using System.Linq;

namespace CodingKatas
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            var arr = numbers.Split(',');
            int sum = 0;
            foreach (var number in arr)
            {
                if (string.IsNullOrEmpty(number))
                    break;

                sum += int.Parse(number);
            }

            return sum;
        }
    }
}
