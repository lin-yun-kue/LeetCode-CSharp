using System;

namespace StringBalance
{
    class Program
    {
        /// <summary>
        /// Balanced strings are those who have equal quantity of 'L' and 'R' characters.
        /// Given a balanced string s split it in the maximum amount of balanced strings.
        /// Return the maximum amount of splitted balanced strings.
        /// 
        /// Input: s = "RLRRLLRLRL"
        /// Output: 4
        /// Explanation: s can be split into "RL", "RRLL", "RL", "RL", each substring contains same number of 'L' and 'R'.
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var s = "RLRRLLRLRL";
            var result = BalancedStringSplit(s);
            Console.WriteLine(result);
        }

        public static int BalancedStringSplit(string s)
        {
            int count = 0;
            int numberCount = 0;
            foreach (var i in s)
            {
                if (i == 'R')
                {
                    numberCount++;
                }
                else
                {
                    numberCount--;
                }
                if (numberCount == 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
