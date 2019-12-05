using System;
using System.Linq;

namespace Reverse_String
{
    /// <summary>
    /// Write a function that reverses a string. The input string is given as an array of characters char[].
    /// Do not allocate extra space for another array, you must do this by modifying the input
    /// array in-place with O(1) extra memory.
    /// You may assume all the characters consist of printable ascii characters.
    /// 
    /// Input: ["h","e","l","l","o"]
    /// Output: ["o","l","l","e","h"]
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = new char[] { 'h', 'e', 'l', 'l', 'o' };
            var solution = new Solution();
            solution.ReverseString(input);
            foreach(var item in input)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Solution
    {
        public void ReverseString(char[] s)
        {
            var last = s.Length - 1;
            var first = 0;
            char temp;
            while(last > first)
            {
                temp = s[first];
                s[first] = s[last];
                s[last] = temp;
                last--;
                first++;
            }
        }
    }
}
