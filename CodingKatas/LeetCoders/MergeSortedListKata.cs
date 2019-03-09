using System;
using System.Collections.Generic;
using System.Text;

namespace CodingKatas.LeetCoders
{
    public class MergeSortedListKata
    {
        public List<int> Sort(List<int> a, List<int> b)
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
    }
}
