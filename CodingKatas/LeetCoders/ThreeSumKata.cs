using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingKatas.LeetCoders
{
    public class ThreeSumKata
    {
        public int[][] ThreeSum(int[] input)
        {
            List<int[]> solutions = new List<int[]>();

            for (int i = 0; i < input.Length; i++)
            {
                int first = input[i];

                for (int j = i + 1; j < input.Length; j++)
                {
                    int second = input[j];

                    for (int t = j + 1; t < input.Length; t++)
                    {
                        if (first + second + input[t] == 0)
                        {
                            bool copy = false;

                            var potentialSolution = new int[] { first, second, input[t] };
                            Array.Sort(potentialSolution);
                            foreach (var solution in solutions)
                            {
                                if (potentialSolution.SequenceEqual(solution))
                                    copy = true;
                            }
                                
                            if (!copy)
                                solutions.Add(potentialSolution);
                        }

                    }
                }
            }

            return solutions.ToArray();
        }
    }
}
