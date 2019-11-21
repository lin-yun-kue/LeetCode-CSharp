using System;
using System.Linq;

namespace ArrayPairSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 1, 4, 3, 2, 5, 6 };
            var solution = new Solution();
            var result = solution.ArrayPairSum1(input);
            Console.WriteLine(result);
        }
    }

    public class Solution
    {
        public int ArrayPairSum(int[] nums)
        {
            Array.Sort(nums);
            var result = 0;
            for(var i = 0; i < nums.Length; i = i + 2)
            {
                result += nums[i];
            }
            return result;
        }

        public int ArrayPairSum1(int[] nums)
        {
            Array.Sort(nums);
            var result = 0;
            var right = nums.Length - 1 - 1;
            var rightFlag = 0;
            for (var i = 0; i < nums.Length/2; i += 2)
            {
                result += nums[i];
                rightFlag = right - i;
                
                if(i != rightFlag)
                    result += nums[right - i];
            }
            return result;
        }
    }
}
