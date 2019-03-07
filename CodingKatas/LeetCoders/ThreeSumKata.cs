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
            if (input.Length <= 2)
                return solutions.ToArray(); //If we don't have even three numbers, return

            Array.Sort(input);
            
            //Since we need a minimum of three numbers, we can stop 3 prior to the end
            for (int i = 0; i < input.Length - 2; i++) 
            {
                int a = input[i];
                if (a > 0) break; //Since we need to equal zero, if a is already positive, 
                //gathering three numbers that equal zero will be impossible, and we should return.

                //If we are not within the first iteration of the loop, and the current value and last value are
                //the same, we can skip this iteration because we are guaranteed to already have the solution recorded
                if (i > 0 && a == input[i - 1])
                    continue;

                for (int j = i + 1, k = input.Length; j < k;)
                {
                    int b = input[j];
                    int c = input[k];

                    int value = a + b + c;

                    if (value == 0)
                    {
                        solutions.Add(new int[] { a, b, c });
                        while (j < k && b == input[++j])
                            ;
                        while (j < k && c == input[--k])
                            ;
                    }
                    else if (value > 0)
                        k--;
                    else
                        j++;
                }
            }

            return solutions.ToArray();
        }
    }
}
