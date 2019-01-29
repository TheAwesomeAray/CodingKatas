using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingKatas
{
    public class SumByFactors
    {
        public static string SumOfDivided(int[] input)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            int[] primes = GetPrimes(input);

            foreach (var prime in primes)
            {
                var inputSum = input.Sum();
                
                foreach (int i in input.OrderByDescending(x => x))
                {
                    if (i % prime == 0)
                    {
                        if (inputSum % prime == 0)
                            result.Add(prime, inputSum);
                        else
                            result.Add(prime, i);
                        break;
                    }
                }
            }

            return string.Format("({0})", string.Join(")(", result.OrderBy(x => x.Key).Select(x => new string(x.Key + " " + x.Value))));
        }

        private static int[] GetPrimes(int[] input)
        {
            var primeList = new List<int>();

            for (int i = 2; i < Math.Abs(input.Min()); i++)
            {
                if (IsPrime(i))
                    primeList.Add(i);
            }

            return primeList.ToArray();
        }

        private static bool IsPrime(int i)
        {
            return i == 2 || i % 2 == 1;
        }
    }
}
