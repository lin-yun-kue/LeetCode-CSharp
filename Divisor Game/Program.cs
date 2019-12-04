using System;

namespace ShortestDistancetoaCharacter
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = 5;
            var solution = new Solution();
            var result = solution.DivisorGame(input);
            Console.WriteLine(result);
        }
    }

    public class Solution
    {
        public bool DivisorGame(int N)
        {
            var aRound = true;
            while(N != 1)
            {
                N -= 1;
                aRound = !aRound;
            }
            return aRound == true ? false : true;
        }

        public bool DivisorGame1(int N)
        {
            return N % 2 == 0;
        }


    }
}
