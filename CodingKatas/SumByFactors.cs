using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SumOfDivided
{
    public static string sumOfDivided(int[] input)
    {
        StringBuilder bldr = new StringBuilder();
        var primes = GetPrimes(input);

        while(primes.Count > 0)
        { 
            bool primeFactor = false;
            int prime = primes.First();
            primes.RemoveFirst();
            var inputSum = 0;

            foreach (int i in input)
            {
                if (i % prime == 0)
                {
                    primeFactor = true;
                    inputSum += i;
                }
            }

            if (primeFactor)
                bldr.Append($"({prime} {inputSum})");
        }

        return bldr.ToString();
    }

    private static LinkedList<int> GetPrimes(int[] input)
    {
        var primeList = new LinkedList<int>();

        for (int x = 2; x <= Math.Max(Math.Abs(input.Max()), Math.Abs(input.Min())); x++)
        {
            int isPrime = 0;
            for (int y = 1; y < x; y++)
            {
                if (x % y == 0)
                    isPrime++;

                if (isPrime == 2) break;
            }
            if (isPrime != 2)
                primeList.AddLast(x);

            isPrime = 0;
        }

        return primeList;
    }
}

