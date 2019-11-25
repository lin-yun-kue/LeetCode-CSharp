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
            var solution = new Solution();
            var result = solution.DiStringMatch(input);
            foreach(var item in result)
            {
                Console.WriteLine(item);
            } 
        }
    }

    public class Solution
    {
        public int[] DiStringMatch(string S)
        {
            var result = new int[S.Length + 1];
            var low = 0;
            var hight = S.Length;

            for(var i = 0; i < S.Length; i++)
            {
                if(S[i] == 'I')
                {
                    if(i == 0)
                    {
                        result[i] = low;
                        low++;
                    }
                    result[i+1] = hight;
                    hight--;
                }
                else
                {
                    if(i == 0)
                    {
                        result[i] = hight;
                        hight--;
                    }
                    result[i + 1] = low;
                    low++;
                }
            }

            return result;
        }
    }
}
