using System;
using System.Linq;

namespace SquaresOfSortedArray
{
    /// <summary>
    /// Given an array of integers A sorted in non-decreasing order, return an array of
    /// the squares of each number, also in sorted non-decreasing order.
    /// 
    /// Input: [-4,-1,0,3,10]
    /// Output: [0,1,9,16,100]
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { -4, -1, 0, 3, 10 };
            var solution = new Solution();
            var result = solution.SortedSquares1(input);
            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
        }

        class Solution
        {
            /// <summary>
            /// linq solution
            /// </summary>
            /// <param name="A"></param>
            /// <returns></returns>
            public int[] SortedSquares(int[] A)
            {
                return A.Select(x => x * x).OrderBy(x => x).ToArray();
            }

            public int[] SortedSquares1(int[] A)
            {
                var result = new int[A.Length];
                var left = 0;
                var right = A.Length - 1;
                var current = A.Length - 1;

                var leftSqr = 0;
                var rightSqr = 0;
                while(current >= 0)
                {
                    leftSqr = A[left] * A[left];
                    rightSqr = A[right] * A[right];
                    if (leftSqr < rightSqr)
                    {
                        result[current] = rightSqr;
                        right--;
                    }
                    else
                    {
                        result[current] = leftSqr;
                        left++;
                    }
                    current--;
                }
                return result;
            }
        }
    }
}
