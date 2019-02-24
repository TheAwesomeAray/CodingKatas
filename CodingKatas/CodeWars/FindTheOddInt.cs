using System.Linq;

namespace CodingKatas
{
    public static class FindTheOddInt
    {
        public static int? Find(int[] seq)
        {
            var distinctInts = seq.Distinct();
            
            for (int i = 0; i < distinctInts.Count(); i++)
            {
                if (seq.Count(x => x == distinctInts.ElementAt(i)) % 2 > 0)
                    return distinctInts.ElementAt(i);
            }

            return null;
        }
    }

    public static class FindTheOddIntSolution
    {
        public static int? Find(int[] seq)
        {
            return seq.GroupBy(x => x).Single(x => x.Count() % 2 == 1).Key;
        }
    }
}
