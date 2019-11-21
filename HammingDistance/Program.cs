using System;
using System.Collections;
using System.Linq;

namespace HammingDistance
{
    /// <summary>
    /// The Hamming distance between two integers is the number of positions at which the
    /// corresponding bits are different.
    /// Given two integers x and y, calculate the Hamming distance.
    /// 
    /// Input: x = 1, y = 4
    /// Output: 2
    /// 
    /// Explanation:
    ///        *   *
    /// 1   (0 0 0 1)
    /// 4   (0 1 0 0)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            var x = 1;
            var y = 4;
            var result = solution.HammingDistance2(x, y);
            Console.WriteLine(result);
        }

        class Solution
        {
            public int HammingDistance(int x, int y)
            {
                var xBitArr = new BitArray(new int[] { x });
                var yBitArr = new BitArray(new int[] { y });
                var result = 0;
                for(var i = 0; i < xBitArr.Length; i++)
                {
                    if(xBitArr[i] != yBitArr[i])
                    {
                        result++;
                    }
                }
                return result;
            }

            public int HammingDistance1(int x, int y)
            {
                int result = 0;
                int temp = x ^ y;
                while (temp != 0)
                {
                    temp &= temp - 1;
                    result++;
                }

                return result;
            }

            public int HammingDistance2(int x, int y)
            {
                int result = 0;
                int temp = x ^ y;
                var bitArr = new BitArray(new int[] { temp });
                for(var i = 0; i<bitArr.Length; i++)
                {
                    if (bitArr[i])
                    {
                        result++;
                    }
                }
                return result;
            }


        }
    }
}
