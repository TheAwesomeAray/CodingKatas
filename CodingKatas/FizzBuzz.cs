using System;
using System.Linq;

namespace CodingKatas
{
    public class FizzBuzzKata
    {
        public void FizzBuzz()
        {
            var input = Enumerable.Range(1, 100).ToArray();
            Console.WriteLine(FizzBuzzTranslator.Translate(input));
        }
    }

    public static class FizzBuzzTranslator
    {
        public static string Translate(int[] input)
        {
            var translatedInputs = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
                translatedInputs[i] = TranslateElement(input[i]);

            return string.Join("\n", translatedInputs);
        }

        private static string TranslateElement(int input)
        {
            if (input % 3 == 0 && input % 5 == 0)
                return "FizzBuzz";
            if (input % 3 == 0)
                return "Fizz";
            else if (input % 5 == 0)
                return "Buzz";

            return input.ToString();
        }
    }
}
