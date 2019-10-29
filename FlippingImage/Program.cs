using System;
using System.Linq;

namespace FlippingImage
{
    /// <summary>
    /// Given a binary matrix A, we want to flip the image horizontally, then invert it, and return the resulting image.
    /// To flip an image horizontally means that each row of the image is reversed.For example,
    /// flipping[1, 1, 0] horizontally results in [0, 1, 1].
    /// To invert an image means that each 0 is replaced by 1, and each 1 is replaced by 0. For example,
    /// inverting[0, 1, 1] results in [1, 0, 0].
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[][]
            {
                new int[] { 1, 1, 0 },
                new int[] { 1, 0, 1 },
                new int[] { 0, 0, 0 }
            };
            var solution = new Solution();
            var result = solution.FlipAndInvertImage1(input);

            foreach(var row in result)
            {
                foreach(var item in row)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }
        }

        public class Solution
        {
            public int[][] FlipAndInvertImage(int[][] A)
            {
                for (var i = 0; i < A.Length; i++)
                {
                    A[i] = A[i].Reverse().ToArray();
                    for (var j = 0; j < A[i].Count(); j++)
                    {
                        A[i][j] = A[i][j] ^ 1;
                    }
                }
                return A;
            }

            public int[][] FlipAndInvertImage1(int[][] A)
            {
                var rowIndex = A[0].Length -1;
                var r = rowIndex;
                var l = 0;

                foreach(var row in A)
                {
                    while(r >= l)
                    {
                        var temp = row[l];
                        row[l] = row[r] ^ 1;
                        row[r] = temp ^ 1;
                        l++;
                        r--;
                    }
                    r = rowIndex;
                    l = 0;
                }
                return A;
            }
        }
    }
}
