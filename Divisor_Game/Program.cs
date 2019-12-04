using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortestDistancetoaCharacter
{
    /// <summary>
    /// Given a string S and a character C, return an array of integers representing the shortest
    /// distance from the character C in the string.
    /// 
    /// Input: S = "loveleetcode", C = 'e'
    /// Output: [3, 2, 1, 0, 1, 0, 0, 1, 2, 2, 1, 0]
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var s = "loveleetcode";
            var c = 'e';
            var solution = new Solution();
            var result = solution.ShortestToChar1(s, c);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Solution
    {
        public int[] ShortestToChar(string S, char C)
        {
            var result = new int[S.Length];
            var flagList = S.Select((s, i) => i).Where(i => S[i] == C).ToList();

            var flag = 0;
            for (var i = 0; i < S.Length; i++)
            {
                var diff1 = Math.Abs(i - flagList[flag]);
                var diff2 = Math.Abs(flag + 1 < flagList.Count
                    ? i - flagList[flag + 1]
                    : int.MaxValue);
                if (diff1 < diff2)
                {
                    result[i] = diff1;
                }
                else
                {
                    result[i] = diff2;
                    flag++;
                }
            }
            return result;
        }

        public int[] ShortestToChar1(string S, char C)
        {
            int len = S.Length;
            int closedIndx = -len;
            int[] distance1 = new int[len];
            int[] distance2 = new int[len];
            char[] arr = S.ToCharArray();



            // find all
            for (int i = 0; i < len; i++)
            {
                if (arr[i] == C)
                {
                    closedIndx = i;
                    distance1[i] = 0;
                }
                else
                {
                    distance1[i] = Math.Abs(closedIndx - i);
                }
            }
            closedIndx = 0;
            for (int i = (len - 1); i >= 0; i--)
            {
                if (arr[i] == C)
                {
                    closedIndx = i;
                    distance2[i] = 0;
                }
                else
                {
                    distance2[i] = Math.Abs(closedIndx - i);
                }
            }

            // consolidate result
            for (int i = 0; i < len; i++)
            {
                if (distance1[i] >= distance2[i])
                    distance1[i] = distance2[i];
            }

            return distance1;
        }
    }
}
