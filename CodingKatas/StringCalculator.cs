namespace CodingKatas
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            char[] delimeter = new[] { ',', '\n' };

            if (numbers.Contains("//"))
            {
                delimeter = new[] { numbers.ToCharArray()[2] };
                numbers = numbers.Substring(numbers.IndexOf('\n') + 1, 
                    numbers.Length - numbers.IndexOf('\n') - 1);
            }

            var arr = numbers.Split(delimeter);
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
