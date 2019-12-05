using System;
using System.Collections.Generic;

namespace Occurrences_After_Bigram
{
    /// <summary>
    /// Given words first and second, consider occurrences in some text of the form "first 
    /// second third", where second comes immediately after first, and third comes
    /// immediately after second.
    /// 
    /// For each such occurrence, add "third" to the answer, and return the answer.
    /// 
    /// Input: text = "alice is a good girl she is a good student", first = "a", second = "good"
    /// Output: ["girl","student"]
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var text = "alice is a good girl she is a good student";
            var first = "a";
            var second = "good";
            var solution = new Solution();
            var result = solution.FindOcurrences(text, first, second);
            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Solution
    {
        public string[] FindOcurrences(string text, string first, string second)
        {
            var arr = text.Split(' ');
            var result = new List<string>();

            string cur;
            string next;
            for(var i = 0; i < arr.Length - 2; i++)
            {
                cur = arr[i];
                next = arr[i + 1];

                if(cur == first && next == second)
                {
                    result.Add(arr[i + 2]);
                    i++;
                }
            }
            return result.ToArray();
        }
    }
}
