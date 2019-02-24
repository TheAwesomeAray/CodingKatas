using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SumOfDivided
{
    public static string sumOfDivided(int[] input)
    {
        Dictionary<int, int> primeFactors = new Dictionary<int, int>();
        StringBuilder bldr = new StringBuilder();
        int max = Math.Max(Math.Abs(input.Max()), Math.Abs(input.Min()));
        var primes = SieveofEratosthenes(max + 1);
        foreach (var prime in primes)
        {
            var factors = input.Where(x => x % prime == 0);

            if (factors.Any())
                primeFactors.Add(prime, factors.Sum());
        }



        return string.Join("", primeFactors.OrderBy(x => x.Key).Select(x => $"({x.Key} {x.Value})"));
    }

    private static LinkedList<int> SieveofEratosthenes(int n)
    {
        //Let A be an array of Boolean values, indexed by integers 2 to n,
        //initially all set to true.
        var a = new bool[n];

        for (int i = 2; i < n; i++)
        {
            a[i] = true;
        }

        for (int i = 2; i < Math.Sqrt(n); i++)
        {
            if (a[i])
            {
                for (int j = (int)Math.Pow(i, 2); j < n; j = j + i)
                    a[j] = false;
            }
        }

        var primes = new LinkedList<int>();
        for (int i = 2; i < a.Length; i++)
            if (a[i])
                primes.AddFirst(i);

        return primes;
    }
}

