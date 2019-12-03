using System;
using System.Collections.Generic;
using System.Text;

namespace Remove_All_Adjacent_Duplicates_In_String
{
    /// <summary>
    /// Given a string S of lowercase letters, a duplicate removal consists of choosing two adjacent and
    /// equal letters, and removing them.
    /// 
    /// We repeatedly make duplicate removals on S until we no longer can.
    /// 
    /// Return the final string after all such duplicate removals have been made.It is guaranteed the
    /// answer is unique.
    /// 
    /// Input: "abbaca"
    /// Output: "ca"
    /// Explanation:
    /// For example, in "abbaca" we could remove "bb" since the letters are adjacent
    /// and equal, and this is the only possible move.  The result of this move is that
    /// the string is "aaca", of which only "aa" is possible, so the final string is "ca".
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = "aaaaaaaa";
            var solution = new Solution();
            var result = solution.RemoveDuplicates2(input);
            Console.WriteLine(result);
        }
    }

    public class Solution
    {
        public string RemoveDuplicates(string S)
        {
            var flag = 0;

            while (flag < S.Length - 1)
            {
                if(S[flag] == S[flag + 1])
                {
                    S = S.Substring(0, flag ) + S.Substring(flag + 2, S.Length - flag - 2);
                    flag = 0;
                    continue;
                }
                flag++;
            }
            return S;
        }

        public string RemoveDuplicates1(string S)
        {
            var stack = new Stack<char>(S);
            var resultStack = new Stack<char>();

            while(stack.TryPop(out var popItem))
            {

                resultStack.TryPeek(out var preItem);
                if(preItem == popItem)
                {
                    resultStack.Pop();
                }
                else
                {
                    resultStack.Push(popItem);
                }
            }

            return string.Join("", resultStack.ToArray());
        }

        public string RemoveDuplicates2(string S)
        {
            var sb = new StringBuilder();

            foreach(var c in S)
            {
                if (sb.Length == 0 || sb[sb.Length - 1] != c)
                {
                    sb.Append(c);
                }
                else
                {
                    sb.Length--;
                }
            }
            return sb.ToString();
        }

    }
}
