using System;
using System.Collections.Generic;
using System.Linq;

namespace Subset
{
    class Program
    {
        static void Main(string[] args)
        {
            //var input = new int[] { 1, 2, 3 };
            //var input = new int[] { 0 };
            var input = new int[] { 3, 2 ,4, 1 };
            var solution = new Solution();
            //var result = solution.Subsets_Cascade(input);
            var result = solution.Subsets_Backtrack_v2(input);

            for (var i = 0; i < result.Count; i++)
            {
                for (var j= 0; j < result[i].Count; j++)
                {
                    Console.Write($"{result[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }

    /// <summary>
    /// Given an integer array nums of unique elements, return all possible subsets (the power set).
    //  The solution set must not contain duplicate subsets.Return the solution in any order.
    //
    //  Example 1:
    //  Input: nums = [1, 2, 3]
    //  Output: [[], [1], [2], [1,2], [3], [1,3], [2,3], [1,2,3]]
    //  
    //  Example 2:
    //  Input: nums = [0]
    //      Output: [[],[0]]
    //  
    //  Constraints:
    //  1 <= nums.length <= 10
    //  -10 <= nums[i] <= 10
    //  All the numbers of nums are unique.
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// cascade solution
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Subsets_Cascade(int[] nums)
        {
            var result = new List<IList<int>>();
            result.Add(new List<int>());
            for(var i = 0; i < nums.Length; i++)
            {
                var endIndex = result.Count;
                for(var j = 0; j < endIndex; j++)
                {
                    var cascade = new List<int>(result[j]);
                    cascade.Add(nums[i]);
                    result.Add(cascade); 

                }
            }
            return result;
        }





        /// <summary>
        /// backtrace solution
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        private IList<IList<int>> res = new List<IList<int>>();

        public IList<IList<int>> Subsets_Backtrack(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return res;

            Backtrack(nums, 0, new List<int>());

            return res;
        }


        private void Backtrack(int[] nums, int i, List<int> cur)
        {
            //Console.WriteLine($"i: {i}");
            //cur.ForEach(x => Console.Write($"{x} "));
            //Console.WriteLine();
            //Console.WriteLine("-------------");

            res.Add(new List<int>(cur));

            if (nums.Length == i)
                return;

            for (int j = i; j < nums.Length; j++)
            {
                cur.Add(nums[j]);

                Backtrack(nums, j + 1, cur);

                cur.RemoveAt(cur.Count - 1);
            }
        }


        private int takeNumber;
        public IList<IList<int>> Subsets_Backtrack_v2(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return res;

            for(takeNumber = 0; takeNumber <= nums.Length; takeNumber++)
            {
                Backtrack_v2(nums, 0, new List<int>());
            }

            return res;
        }

        private void Backtrack_v2(int[] nums, int first, List<int> cur)
        {
            if(cur.Count == takeNumber)
            {
                res.Add(new List<int>(cur));
                return;
            }

            for(var i = first; i < nums.Length; i++)
            {
                cur.Add(nums[i]);
                Backtrack_v2(nums, i + 1, cur);
                cur.RemoveAt(cur.Count - 1);
            }
        }
    }
}
