using System;
using System.Linq;

namespace CodingKatas
{
    public class FizzBuzzKata
    {
        public void FizzBuzz(Translator translator)
        {
            var input = Enumerable.Range(1, 100).ToArray();
            Console.WriteLine(translator.Translate(input));
        }
    }

    public class FizzBuzzExtraCreditTranslator : Translator
    {
        protected override string TranslateElement(int input)
        {
            var stringInput = input.ToString();

            if (stringInput.Contains("3"))
                return "Fizz";
            if (stringInput.Contains("5"))
                return "Buzz";

            return stringInput;
        }
    }

    public class FizzBuzzTranslator : Translator
    {
        protected override string TranslateElement(int input)
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

    public abstract class Translator
    {
        public string Translate(int[] input)
        {
            var translatedInputs = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
                translatedInputs[i] = TranslateElement(input[i]);

            return string.Join("\n", translatedInputs);
        }

        protected abstract string TranslateElement(int input);
    }
}
