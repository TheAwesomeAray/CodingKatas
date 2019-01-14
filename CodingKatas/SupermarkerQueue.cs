using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingKatas
{
    public static class SupermarkerQueue
    {
        public static long QueueTime(int[] customers, int n)
        {
            var queues = new List<Queue>();

            for (int i = 1; i <= n; i++)
                queues.Add(new Queue());

            for (int i = 0; i < customers.Length; i++)
            {
                if (queues.Where(x => !x.Occupied).Count() == 0)
                {
                    int minimumTimeRemaining = queues.Min(y => y.TimeRemaining);
                    queues.ForEach(x => x.Wait(minimumTimeRemaining));
                }

                queues.FirstOrDefault(x => !x.Occupied).OccupyQueue(customers[i]);
            }

            return queues.Max(x => x.TotalWait);
        }

        public class Queue
        {
            public bool Occupied { get; set; }
            public int TimeRemaining { get; set; }
            public long TotalWait { get; set; }

            public void OccupyQueue(int waitTime)
            {
                Occupied = true;
                TimeRemaining = waitTime;
                TotalWait += waitTime;
            }

            public void Wait(int timeWaited)
            {
                TimeRemaining -= timeWaited;

                if (TimeRemaining == 0)
                    Occupied = false;
            }
        }
    }

    public static class SupermarketQueueSolution
    {
        public static long QueueTime(int[] customers, int n)
        {
            var registers = new List<int>(Enumerable.Repeat(0, n));

            for (int i = 0; i < customers.Length; i++)
                registers[registers.IndexOf(registers.Min())] += customers[i];

            return registers.Max();
        }
    }
}
