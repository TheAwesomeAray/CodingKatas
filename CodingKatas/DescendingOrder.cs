using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingKatas
{
    public class DescendingOrderKata
    {
        public static int DescendingOrder(int num)
        {
            string temp = num.ToString();
            var ints = GetIntList(temp);
            var orderedInts = ints.OrderByDescending(x => x);
            return GetString(orderedInts);
        }

        private static int GetString(IOrderedEnumerable<int> ints)
        {
            string result = "";
            foreach (var element in ints)
            {
                result += element.ToString();
            }
            return int.Parse(result);
        }

        private static List<int> GetIntList(string temp)
        {
            var ints = new List<int>();
            for (int i = 0; i < temp.Length; i++)
            {
                ints.Add(int.Parse(temp[i].ToString()));
            }
            return ints;
        }
    }

    public class DescendingOrderKataSolution
    {
        public static int DescendingOrder(int num)
        {
            char[] arr = num.ToString().ToCharArray();
            Array.Sort(arr);
            Array.Reverse(arr);
            return Convert.ToInt32(new string(arr));
        }
    }
}
