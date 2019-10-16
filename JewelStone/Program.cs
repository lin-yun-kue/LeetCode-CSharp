using System;
using System.Linq;

namespace JewelStone
{
    /// <summary>
    /// You're given strings J representing the types of stones that are jewels, and S
    /// representing the stones you have.  Each character in S is a type of stone you have.  You
    /// want to know how many of the stones you have are also jewels.
    /// 
    /// The letters in J are guaranteed distinct, and all characters in J and S are letters. Letters
    /// are case sensitive, so "a" is considered a different type of stone from "A".
    /// 
    /// Input: J = "aA", S = "aAAbbbb"
    /// Output: 3
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var jewel = "aA";
            var stones = "aAAbbb";
            var result = NubJewelsInStones(jewel, stones);
            Console.WriteLine(result);
        }

        public static int NubJewelsInStones(string J, string S)
        {
            //method one
            //return S.Count(x => J.Contains(x));

            //method two
            var count = 0;
            S.ToList().ForEach(x => {
                if (J.Contains(x))
                {
                    count++;
                }
            });
            return count;
        }
    }
}
