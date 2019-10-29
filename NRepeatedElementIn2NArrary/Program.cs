using System;
using System.Collections.Generic;

namespace NRepeatedElementIn2NArrary
{
    /// <summary>
    /// In a array A of size 2N, there are N+1 unique elements, and exactly one of these elements is
    /// repeated N times.
    /// 
    /// Return the element repeated N times.
    /// 
    /// Input: [1,2,3,3]
    /// Output: 3
    /// 
    /// Input: [2,1,2,5,3,2]
    /// Output: 2
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 5, 1, 5, 2, 5, 3, 5, 4 };
            var solution = new Solution();
            var result = solution.RepeatedNTimes1(input);
            Console.WriteLine(result);
        }

        class Solution
        {
            public int RepeatedNTimes(int[] A)
            {
                var hash = new HashSet<int>();
                foreach (var i in A)
                {
                    if(hash.Add(i) == false)
                    {
                        return i;
                    }
                }
                return 0;
            }

            public int RepeatedNTimes1(int[] A)
            {
                for(var i = 0; i < (A.Length / 2) + 1; i++)
                {
                    for(var j = i+1; j < A.Length; j++)
                    {
                        if(A[i] == A[j])
                        {
                            return A[i];
                        }
                    }
                }
                return 0;
            }
        }
    }
}
