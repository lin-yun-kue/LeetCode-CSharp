using System;
using System.Linq;
using System.Text;

namespace Reverse_Words_in_a_String_III
{
    /// <summary>
    /// Given a string, you need to reverse the order of characters in each word within a sentence while
    /// still preserving whitespace and initial word order.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = "Let's take LeetCode contest";
            var solution = new Solution();
            var result = solution.ReverseWords(input);
            Console.WriteLine(result);
        }
    }

    public class Solution
    {
        public string ReverseWords(string s)
        {
            var arrStr = s.Split(' ');
            var strBuild = new StringBuilder();
            for(var i = 0; i < arrStr.Length; i++)
            {
                var maxIndex = arrStr[i].Length - 1;
                for(var j = maxIndex; j >= 0; j--)
                {
                    strBuild.Append(arrStr[i][j]);
                }
                strBuild.Append(" ");
            }
            return strBuild.ToString().TrimEnd();
        }
    }
}
