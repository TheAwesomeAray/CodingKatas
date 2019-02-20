using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingKatas
{
    public class TwoSumKata
    {
        public int[] TwoSum(int[] nums, int target)
        {
            return OnePassHashTable(nums, target);
        }

        private int[] BruteForce(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
                for (int j = i + 1; j < nums.Length; j++)
                    if (nums[j] == target - nums[i])
                        return new[] { i, j };

            throw new InvalidOperationException("No Solution Exists");
        }

        private int[] TwoPassHashTable(int[] nums, int target)
        {
            var numberDict = new Dictionary<int, int>();
           
            for (int i = 0; i < nums.Length && !numberDict.ContainsKey(nums[i]); i++)
                numberDict.Add(nums[i], i);

            for (int i = 0; i < nums.Length; i++)
                if (numberDict.ContainsKey(target - nums[i]))
                    return new int[] { i, numberDict[target - nums[i]]};

            throw new InvalidOperationException("No Solution Exists");
        }

        private int[] OnePassHashTable(int[] nums, int target)
        {
            var numberDict = new Dictionary<int, int>();
    
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (numberDict.ContainsKey(complement))
                    return new[] { i, numberDict[complement] };

                if (!numberDict.ContainsKey(nums[i]))
                    numberDict.Add(nums[i], i);
            }

            throw new InvalidOperationException("No Solution Exists");
        }
    }
}
