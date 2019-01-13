using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingKatas
{
    public static class SumDigitPowers
    {
        public static long[] SumDigPow(long a, long b)
        {
            List<long> passingValues = new List<long>();

            for (long i = a; i < b; i++)
            {
                if (EvaluateSumDigitPowerEquality(i))
                    passingValues.Add(i);
            }

            return passingValues.ToArray();
        }

        private static bool EvaluateSumDigitPowerEquality(long i)
        {
            var digits = i.ToString().ToCharArray().Select(x => char.GetNumericValue(x));
            var total = AggregateDigits(digits);
            return total == i;
        }

        private static double AggregateDigits(IEnumerable<double> digits)
        {
            double runningTotal = 0;
            double power = 1;

            foreach (var digit in digits)
            {
                runningTotal += Math.Pow(digit, power);
                power++;
            }

            return runningTotal;
        }
    }

    public class SumDigitPowersSolution
    {
        public static long[] SumDigPow(long a, long b)
        {
            List<long> values = new List<long>();
            for (long i = a; i <= b; i++)
            {
                if (IsEureka(i))
                    values.Add(i);
            }

            return values.ToArray();
        }

        private static bool IsEureka(long i)
        {
            return i.ToString().Select((c, x) => Math.Pow(Char.GetNumericValue(c), x + 1)).Sum() == i;
        }
    }
}
