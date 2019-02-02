using System;
using System.Collections.Generic;
using System.Linq;


public class SumOfDivided
{
    public static string sumOfDivided(int[] input)
    {
        Dictionary<int, int> result = new Dictionary<int, int>();
        int[] primes = GetPrimes(input);

        foreach (var prime in primes)
        {
            bool primeFactor = false;
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
                result.Add(prime, inputSum);
        }

        return string.Format("({0})", string.Join(")(", result.OrderBy(x => x.Key).Select(x => x.Key + " " + x.Value)));
    }

    private static int[] GetPrimes(int[] input)
    {
        var primeList = new List<int>();

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
                primeList.Add(x);

            isPrime = 0;
        }

        return primeList.ToArray();
    }
}

