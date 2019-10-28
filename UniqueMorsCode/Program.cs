using System;
using System.Collections.Generic;
using System.Linq;

namespace UniqueMorsCode
{
    /// <summary>
    /// nternational Morse Code defines a standard encoding where each letter is mapped to a
    /// series of dots and dashes, as follows: "a" maps to ".-", "b" maps to "-...", "c"
    /// maps to "-.-.", and so on.
    /// 
    /// Now, given a list of words, each word can be written as a concatenation of the Morse
    /// code of each letter. For example, "cba" can be written as "-.-..--...", (which is the
    /// concatenation "-.-." + "-..." + ".-"). We'll call such a concatenation, the transformation of a
    /// word.
    /// 
    /// Return the number of different transformations among all words we have.
    /// 
    /// Input: words = ["gin", "zen", "gig", "msg"]
    /// Output: 2
    /// Explanation: 
    /// The transformation of each word is:
    /// "gin" -> "--...-."
    /// "zen" -> "--...-."
    /// "gig" -> "--...--."
    /// "msg" -> "--...--."
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = new String[] { "gin", "zen", "gig", "msg" };
            var solution = new Solution();
            var result = solution.UniqueMorseRepresentations(input);
            Console.WriteLine(result);
        }

        public class Solution
        {
            public string[] MorsCode = 
                { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..",
                ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.",
                "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            public int UniqueMorseRepresentations(string[] words)
            {
                //var morsWord = TranlateToMors(words);
                //return morsWord.Distinct().Count();

                var result = new HashSet<string>();
                var temp = "";
                foreach (var item in words)
                {
                    temp = "";
                    foreach (var c in item)
                    {
                        temp += MorsCode[c - 'a'];
                    }
                    if (!result.Contains(temp))
                    {
                        result.Add(temp);
                    }
                }
                return result.Count;
            }

            public string[] TranlateToMors(string[] words)
            {
                var result = new string[words.Length];
                for(var i = 0; i < words.Length; i++)
                {
                    var temp = "";
                    foreach(var c in words[i])
                    {
                        temp += MorsCode[c - 'a'];
                    }
                    result[i] = temp;
                }
                return result;
            }
        }
    }
}
