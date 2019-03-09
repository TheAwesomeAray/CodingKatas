using System;
using System.Collections.Generic;
using System.Text;

namespace CodingKatas.LeetCoders
{
    public class MergeSortedListKata
    {
        public List<int> Merge(List<int> a, List<int> b)
        {
            var mergedList = new List<int>();
            int i = 0, j = 0;
            while (i < a.Count || j < b.Count)
            {
                if (i == a.Count)
                {
                    while (j < b.Count)
                        mergedList.Add(b[j++]);

                    return mergedList;
                }
                    
                if (j == b.Count)
                {
                    while (j < b.Count)
                        mergedList.Add(b[j++]);

                    return mergedList;
                }
                   
                if (a[i] < b[j])
                    mergedList.Add(a[i++]);
                else
                    mergedList.Add(b[j++]);
            
            }
            
            return mergedList;
        }

        public LinkedListNode<int> Merge(LinkedListNode<int> a, LinkedListNode<int> b)
        {
            if (a == null)
                return b;
            if (b == null)
                return a;

            LinkedListNode<int> mergeHead;

            if (a.Value < b.Value)
            {
                mergeHead = a;
                var nextNode = mergeHead.Next;
                nextNode = Merge(a.Next, b);
            }
            else
            {
                mergeHead = b;
                var nextNode = mergeHead.Next;
                nextNode = Merge(a, b.Next);
            }

            return mergeHead;
        }
    }
}
