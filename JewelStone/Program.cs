using System;
using System.Linq;

namespace JewelStone
{
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
