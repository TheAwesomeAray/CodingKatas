using System.Collections.Generic;
using System.Linq;

namespace CodingKatas
{
    public static class RemoveTheMinimum
    {
        public static List<int> RemoveSmallest(List<int> numbers)
        {
            var listWithoutMinimum = new List<int>();

            if (numbers.Count == 0)
                return listWithoutMinimum;

            var smallestIndex = numbers.FindIndex(x => x == numbers.Min());

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i != smallestIndex)
                    listWithoutMinimum.Add(numbers[i]);
            }

            return listWithoutMinimum;
        }
    }

    public static class RemoveTheMinimumSolution
    {
        public static List<int> RemoveSmallest(List<int> numbers)
        {
            var numbersCopy = numbers.ToList();
            numbersCopy.Remove(numbersCopy.DefaultIfEmpty().Min());
            return numbersCopy;
        }
    }

}
