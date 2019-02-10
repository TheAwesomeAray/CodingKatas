using System;
using System.Collections.Generic;
using System.Text;

namespace CodingKatas
{
    public class FizzBuzzKata
    {
        public void FizzBuzz(int[] input)
        {
            foreach (var element in input)
                Console.WriteLine(FizzBuzzTranslator.Translate(element));
        }
    }

    public static class FizzBuzzTranslator
    {
        public static string Translate(int input)
        {
            if (input % 3 == 0)
                return "Fizz\n";

            return $"{input.ToString()}\n";
        }
    }
}
