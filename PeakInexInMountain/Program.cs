using System;
using System.Linq;

namespace PeakInexInMountain
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 0, 1, 2, 0 };
            var solution = new Solution();
            var result = solution.PeakIndexInMountainArray1(input);
            Console.WriteLine(result);
        }
    }

    public class Solution
    {
        public int PeakIndexInMountainArray(int[] A)
        {
            var maxNum = A.Max();
            var result = Array.IndexOf(A, maxNum);
            return result;
        }

        public int PeakIndexInMountainArray1(int[] A)
        {
            var maxNum = 0;
            var result = 0;
            for(var i = 0; i< A.Length; i++)
            {
                if(A[i] > maxNum || i == 0)
                {
                    maxNum = A[i];
                    result = i;
                }
                else
                {
                    break;
                }
            }
            return result;
        }

    }
}
