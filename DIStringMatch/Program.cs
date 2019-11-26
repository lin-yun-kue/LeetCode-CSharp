using System;
using System.Collections.Generic;

namespace DIStringMatch
{
    /// <summary>
    /// Given a string S that only contains "I" (increase) or "D" (decrease), let N = S.length.
    /// Return any permutation A of [0, 1, ..., N] such that for all i = 0, ..., N-1:
    /// If S[i] == "I", then A[i] < A[i+1]
    /// If S[i] == "D", then A[i] > A[i + 1]
    /// 
    /// Input: "IDID"
    /// Output: [0,4,1,3,2]
    /// 
    /// Input: "III"
    /// Output: [0,1,2,3]
    /// 
    /// Input: "DDI"
    /// Output: [3,2,0,1]
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = "IDID";
            //var input = "III";
            var solution = new Solution();
            var result = solution.DiStringMatch(input);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Solution
    {
        public int[] DiStringMatch(string S)
        {
            var N = S.Length;
            var result = new int[S.Length + 1];
            var low = 0;
            var hight = N;

            for (var i = 0; i < N; i++)
            {
                if (S[i] == 'I')
                {
                    result[i] = low++;
                }
                else
                {
                    result[i] = hight--;
                }
            }
            result[N] = low;

            return result;
        }


        public int[] DiStringMatch1(string S)
        {
            var N = S.Length;
            var arr = new int[N + 1];
            var num = 0;
            for (int i = 0; i < N; i++)
                if (S[i] == 'I') 
                    arr[i] = num++;

            arr[N] = num++;

            for (int i = N - 1; i >= 0; i--) 
                if (S[i] == 'D') 
                    arr[i] = num++;
            return arr;
        }
    }
}
