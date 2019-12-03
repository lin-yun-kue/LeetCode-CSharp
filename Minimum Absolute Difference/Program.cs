using System;
using System.Collections.Generic;

namespace Minimum_Absolute_Difference
{
    /// <summary>
    /// Given an array of distinct integers arr, find all pairs of elements with the minimum absolute
    /// difference of any two elements. 
    /// 
    /// Return a list of pairs in ascending order(with respect to pairs), each pair[a, b] follows
    /// 
    /// a, b are from arr
    /// a < b
    /// b - a equals to the minimum absolute difference of any two elements in arr
    /// 
    /// Input: arr = [4,2,1,3]
    /// Output: [[1,2],[2,3],[3,4]]
    /// Explanation: The minimum absolute difference is 1. List all pairs with 
    /// difference equal to 1 in ascending order.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 40, 11, 26, 27, -20 };
            var solution = new Solution();
            var result = solution.MinimumAbsDifference(input);
            foreach (var item in result)
            {
                foreach (var n in item)
                {
                    Console.Write($"{n}, ");
                }
                Console.WriteLine();
            }
        }
    }

    class Node
    {
        public int Value;

        public Node(int val) => this.Value = val;
    }

    public class Solution
    {

        public IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            Array.Sort(arr);
            int minVal = int.MaxValue;
            var result = new List<IList<int>>();

            for (var i = 0; i < arr.Length - 1; i++)
            {
                var diff = arr[i + 1] - arr[i];
                if(diff <= minVal)
                {
                    if(diff < minVal)
                    {
                        result.Clear();
                    }
                    minVal = diff;
                    var list = new List<int>() { arr[i], arr[i + 1] };
                    result.Add(list);
                }
            }
            return result;
        }
    }
}
