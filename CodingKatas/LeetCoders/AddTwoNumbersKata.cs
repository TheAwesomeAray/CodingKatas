using System;
using System.Collections.Generic;
using System.Text;

namespace CodingKatas.LeetCoders
{
    public class AddTwoNumbersKata
    {
        public LinkedList<int> AddTwoNumbers(LinkedList<int> a, LinkedList<int> b)
        {
            var aEnum = a.GetEnumerator();
            var bEnum = b.GetEnumerator();
            LinkedList<int> result = new LinkedList<int>();
            while (aEnum.MoveNext() && bEnum.MoveNext())
            {
                var intermediateSum = aEnum.Current + bEnum.Current;
                if (intermediateSum >= 10)
                {
                    result.First.Value += 1;
                    result.AddFirst(intermediateSum % 10);
                }
                else
                    result.AddFirst(intermediateSum);
            }

            return result;
        }
    }
}
