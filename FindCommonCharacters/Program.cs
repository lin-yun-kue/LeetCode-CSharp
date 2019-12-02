using System;
using System.Collections.Generic;

namespace FindCommonCharacters
{
    /// <summary>
    /// Given an array A of strings made only from lowercase letters, return a list of all characters that
    /// show up in all strings within the list (including duplicates).  For example, if a character occurs 3 
    /// times in all strings but not 4 times, you need to include that character three times in the final
    /// answer.
    /// You may return the answer in any order.
    /// 
    /// Input: ["bella","label","roller"]
    /// Output: ["e","l","l"]
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = new string[] { "bella", "label", "roller" };
            var solution = new Solution();
            var result = solution.CommonChars(input);
            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Solution
    {
        public IList<string> CommonChars(string[] A)
        {
            var listDic = new List<Dictionary<char, int>>();

            foreach(var item in A)
            {
                var tempDic = new Dictionary<char, int>();
                foreach(var c in item)
                {
                    if (tempDic.ContainsKey(c))
                    {
                        tempDic[c] += 1;
                    }
                    else
                    {
                        tempDic.Add(c, 1);
                    }
                }
                listDic.Add(tempDic);
            }
            var result = new List<string>();
            foreach(var item in listDic[0])
            {
                var isValid = true;
                var minVal = item.Value;
                for(var i = 1; i < listDic.Count; i++)
                {
                    if (listDic[i].ContainsKey(item.Key)) {
                        if(listDic[i][item.Key] < minVal)
                        {
                            minVal = listDic[i][item.Key];
                        }
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }
                if (isValid)
                {
                    for (var i = 0; i < minVal; i++)
                    {
                        result.Add(item.Key.ToString());
                    }
                }
            }
            return result;
        }
    }
}
