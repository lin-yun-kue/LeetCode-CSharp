using System;

namespace SortArrayByParityII
{
    /// <summary>
    /// Given an array A of non-negative integers, half of the integers in A are odd, and half of the
    /// integers are even.
    /// 
    /// Sort the array so that whenever A[i] is odd, i is odd; and whenever A[i] is even, i is even.
    /// 
    /// You may return any answer array that satisfies this condition.
    /// 
    /// Input: [4,2,5,7]
    /// Output: [4,5,2,7]
    /// Explanation: [4,7,2,5], [2,5,4,7], [2,7,4,5] would also have been accepted.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 4, 2, 5, 7 };
            var solution = new Solution();
            var result = solution.SortArrayByParityII1(input);
            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Solution
    {
        public int[] SortArrayByParityII(int[] A)
        {
            bool isNumberOdd;
            bool isIndexOdd;
            for(var i = 0; i < A.Length - 1; i++)
            {
                isIndexOdd = i % 2 == 1;
                isNumberOdd = A[i] % 2 == 1;

                if (isNumberOdd ^ isIndexOdd)
                {
                    int temp;
                    for(var j = i + 1; j < A.Length; j++)
                    {
                        if (isIndexOdd)
                        {
                            if(A[j] % 2 == 1)
                            {
                                temp = A[i];
                                A[i] = A[j];
                                A[j] = temp;
                                break;
                            }
                        }
                        else
                        {
                            if(A[j] % 2 == 0)
                            {
                                temp = A[i];
                                A[i] = A[j];
                                A[j] = temp;
                                break;
                            }
                        }
                    }
                }
            }
            return A;
        }

        public int[] SortArrayByParityII1(int[] A)
        {
            var result = new int[A.Length];
            var oddIndex = 1;
            var evenIndex = 0;

            foreach(var item in A)
            {
                if(item % 2 == 0)
                {
                    result[evenIndex] = item;
                    evenIndex += 2;
                }
                else
                {
                    result[oddIndex] = item;
                    oddIndex += 2;
                }
            }
            return result;
        }
    }
}
