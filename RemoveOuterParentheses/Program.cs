using System;
using System.Collections.Generic;

namespace RemoveOuterParentheses
{
    /// <summary>
    /// Input: "(()())(())"
    /// Output: "()()()"
    /// 
    /// Input: "(()())(())(()(()))"
    /// Output: "()()()()(())"
    /// 
    /// "()()"
    /// ""
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = new List<string>() { "(()())(())", "(()())(())(()(()))", "()()" };
            var results = new List<string>();

            var solution = new Solution();

            foreach(var item in inputs)
            {
                var result = solution.RemoveOuterParentheses1(item);
                results.Add(result);
                Console.WriteLine(result);
            }
        }

        public class Solution
        {
            /// <summary>
            /// que solution
            /// </summary>
            /// <param name="s"></param>
            /// <returns></returns>
            public string RemoveOuterParentheses(string s)
            {
                var q = new Queue<char>(s);
                var result = string.Empty;
                var tempString = string.Empty;
                var count = 0;
                while(q.Count > 0)
                {
                    var temp = q.Dequeue();
                    tempString += temp;

                    if (temp == '(')
                    {
                        count++;
                    }
                    else
                    {
                        count--;
                    }
                    if(count == 0)
                    {
                        if(tempString.Length > 0)
                        {
                            result += tempString.Substring(1, tempString.Length - 2);
                        }
                        tempString = string.Empty;
                    }
                }
                return result;
            }

            public string RemoveOuterParentheses1(string s)
            {
                var result = string.Empty;
                var count = 1;
                for (var i = 1; i < s.Length - 1; i++)
                {
                    var current = s[i];
                    if (current == '(')
                    {
                        count++;
                        result += current;
                    }
                    else
                    {
                        count--;
                        if (count == 0)
                        {
                            count = 1;
                            i++;
                        }
                        else
                        {
                            result += current;
                        }
                    }
                }
                return result;
            }
        }
    }
}
