using System;
using System.Linq;

namespace HeightChecker
{
    /// <summary>
    /// Students are asked to stand in non-decreasing order of heights for an annual photo.
    /// 
    /// Return the minimum number of students not standing in the right positions.  (This is 
    /// the number of students that must move in order for all students to be standing in non-decreasing order
    /// of height.)
    /// 
    /// Input: [1,1,4,2,1,3]
    /// Output: 3
    /// Explanation: 
    /// Students with heights 4, 3 and the last 1 are not standing in the right positions.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 1, 1, 4, 2, 1, 3 };
            var solution = new Solution();
            var result = solution.HeightChecker(input);
            Console.WriteLine(result);
        }
    }

    public class Solution
    {
        public int HeightChecker(int[] heights)
        {
            var result = 0;

            var rightHeight = heights.OrderBy(x => x).ToArray();

            for(var i = 0; i < heights.Length; i++)
            {
                if(heights[i] != rightHeight[i])
                {
                    result++;
                }
            }

            return result;
        }
    }
}
