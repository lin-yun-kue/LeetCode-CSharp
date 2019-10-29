using System;
using System.Collections.Generic;
using System.Linq;

namespace UniqueOccurrences
{
    /// <summary>
    /// Given an array of integers arr, write a function that returns true if and only if the number of
    /// occurrences of each value in the array is unique.
    /// arr = [1,2,2,1,1,3]
    /// Explanation: The value 1 has 3 occurrences, 2 has 2 and 3 has 1. No two values
    /// have the same number of occurrences.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 1, 2, 2, 1, 1, 3 };
            var solution = new Solution();
            var result = solution.UniqueOccurrences(input);
            Console.WriteLine(result);
        }

        class Solution
        {
            public bool UniqueOccurrences(int[] arr) 
            {
                var dic = new Dictionary<int, int>();

                foreach(var item in arr)
                {
                    if (dic.ContainsKey(item))
                    {
                        dic[item]++;
                    }
                    else
                    {
                        dic.Add(item, 1);
                    }
                }

                return dic.GroupBy(x => x.Value).Count(x => x.Count() > 1) == 0;

                //foreach (KeyValuePair<int, int> kp in dic)
                //{
                //    int key = kp.Key;
                //    int val = kp.Value;
                //    foreach (KeyValuePair<int, int> pair in dic)
                //    {
                //        if (pair.Key != kp.Key && pair.Value == kp.Value)
                //        {
                //            return false;
                //        }
                //    }
                //}
                //return true;
            }
        }
    }
}
