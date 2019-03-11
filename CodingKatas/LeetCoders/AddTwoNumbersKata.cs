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

            while (aEnum.MoveNext())
            //bool carry = false;
            int intermediateSum = aEnum.Current + bEnum.Current;

            if (intermediateSum > 9)
            {
                result.AddFirst(intermediateSum % 10);
                //carry = true;
            }
            else
                result.AddFirst(intermediateSum);

            return result;
        }
    }
}
