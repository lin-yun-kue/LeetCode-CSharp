using System;
using System.Linq;

namespace SortArrayByParity
{
    /// <summary>
    /// Given an array A of non-negative integers, return an array consisting of all the even elements of 
    /// A, followed by all the odd elements of A.
    /// You may return any answer array that satisfies this condition.
    /// Input: [3,1,2,4]
    /// Output: [2,4,3,1]
    /// The outputs [4,2,3,1], [2,4,1,3], and [4,2,1,3] would also be accepted.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] {6, 2, 1, 3 };
            var solution = new Solution();
            var result = solution.SortArrayByParity3(input);
            foreach(var item in result)
            {
                Console.Write(item);
            }
        }

        class Solution
        {
            public int[] SortArrayByParity(int[] A)
            {
                var evenNumber = A.Where(x => x % 2 == 0);
                var oddNumber = A.Where(x => x % 2 == 1);
                return evenNumber.Concat(oddNumber).ToArray();
            }

            public int[] SortArrayByParity1(int[] A)
            {
                int end = A.Length - 1;
                int start = 0;

                while (end > start)
                {
                    if (A[start] % 2 == 0)
                    {
                        start++;
                    }
                    else
                    {
                        var temp = A[start];
                        A[start] = A[end];
                        A[end] = temp;
                        end--;

                    }
                }
                return A;
            }

            public int[] SortArrayByParity2(int[] A)
            {
                for (int i = 0, j = A.Length - 1; j > i;)
                {
                    if (A[i] % 2 == 0)
                    {
                        i++;
                    }
                    else
                    {
                        var temp = A[i];
                        A[i] = A[j];
                        A[j] = temp;
                        j--;
                    }
                }
                return A;
            }

            public int[] SortArrayByParity3(int[] A)
            {
                int oddIndex = 0;
                for (int i = 0; i < A.Length; i++)
                {
                    if ((A[i] & 1) == 0)
                    {
                        int t = A[i];
                        A[i] = A[oddIndex];
                        A[oddIndex] = t;
                        oddIndex++;
                    }
                }

                return A;
            }
        }
    }
}
