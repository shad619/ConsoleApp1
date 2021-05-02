using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        public static int collector = 0;

        static void Main(string[] args)
        {
            // int[] inputs = new int[] { 1, 2 };      // answer 3
            // int[] inputs = new int[] { 1, 5, 2, 1 };     // answer 7
            int[] inputs = new int[] { 1, 5, 5, 4, 3, 7, 1 };    // answer 13
            // int[] inputs = new int[] { 1 };      // answer 1

            // convert int array into a list of array. each item has the original value at index 0, and the score at index 1
            List<int[]> lst = new List<int[]>();
            foreach (int i in inputs)
            {
                lst.Add(new int[] { i, 1 });
            }
            
            // run through list forward comparing to previous index
            for (int i = 1; i < lst.Count; i++)
            {
                lst[i] = comparer2(lst[i], lst[i - 1]);
            }

            // run through list backward comparing to next index
            for (int i = lst.Count - 1; i > 0; i--)
            {
                lst[i - 1] = comparer2(lst[i - 1], lst[i]);
            }

            // extract score from each item using LINQ
            collector = (from itm in lst
                     select itm[1]).ToList().Sum();

            Console.WriteLine($"the answer is {collector}");
        }

        private static int[] comparer2(int[] curr, int[] prev)
        {
            int score = curr[1];
            if (curr[0] > prev[0] && curr[1] <= prev[1]) score = prev[1] + 1;
            if (curr[0] == prev[0] && curr[1] < prev[1]) score = prev[1];
            return new int[] { curr[0], score };
        }
    }
}
