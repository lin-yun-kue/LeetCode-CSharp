using System;

namespace StringBalance
{
    class Program
    {
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
            foreach(var i in s)
            {
                if(i == 'R')
                {
                    numberCount++;
                }
                else
                {
                    numberCount--;
                }
                if(numberCount == 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
