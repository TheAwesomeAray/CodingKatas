using System.Collections.Generic;
using System.Linq;

namespace CodingKatas
{
    public class JosephusSurvivor
    {
        public static int FindSurvivor(int n, int k)
        {
            int targetIndex = -1;
            var survivors = new HashSet<int>(Enumerable.Range(1, n));
            
            while (survivors.Count > 1)
            {
                for (int i = 0; i < k; i++)
                {
                    if (++targetIndex >= survivors.Count)
                        targetIndex = 0;
                }
                    

                var target = survivors.ElementAt(targetIndex);
                survivors.Remove(target);
                targetIndex--;
            }

            return survivors.Single();
        }

        public class JosephusSurvivorSolution
        {
            public static int FindSurvivor(int n, int k)
            {
                if (n == 1)
                    return 1;
                else
                    return (FindSurvivor(n - 1, k) + k - 1) % n + 1;
            }
        }
    }
}
