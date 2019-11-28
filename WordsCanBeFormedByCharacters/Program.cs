using System;
using System.Collections.Generic;

namespace WordsCanBeFormedByCharacters
{
    /// <summary>
    /// You are given an array of strings words and a string chars.
    /// A string is good if it can be formed by characters from chars(each character can only be used once).
    /// Return the sum of lengths of all good strings in words.
    /// 
    /// Input: words = ["cat","bt","hat","tree"], chars = "atach"
    /// Output: 6
    /// Explanation: 
    /// The strings that can be formed are "cat" and "hat" so the answer is 3 + 3 = 6.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var words = new string[] { "cat", "bt", "hat", "tree" };
            var chars = "atach";
            var solution = new Solution();
            var result = solution.CountCharacters(words, chars);
            Console.WriteLine(result);
        }
    }

    public class Solution
    {
        public int CountCharacters(string[] words, string chars)
        {
            var charDic = new Dictionary<char, int>();
            foreach(var item in chars)
            {
                if (charDic.ContainsKey(item))
                {
                    charDic[item] += 1;
                }
                else
                {
                    charDic.Add(item, 1);
                }
            }
            var result = 0;
            
            foreach(var item in words)
            {
                Dictionary<char, int> tempDic = new Dictionary<char, int>();
                var isFormed = true;

                foreach (var c in item)
                {
                    if(charDic.ContainsKey(c) == false)
                    {
                        isFormed = false;
                        break;
                    }

                    if (tempDic.ContainsKey(c))
                    {
                        tempDic[c] += 1;
                    }
                    else
                    {
                        tempDic.Add(c, 1);
                    }

                    if (charDic[c] < tempDic[c])
                    {
                        isFormed = false;
                        break;
                    }
                }
                if (isFormed)
                {
                    result += item.Length;
                }
            }
            return result;
        }
    }
}
