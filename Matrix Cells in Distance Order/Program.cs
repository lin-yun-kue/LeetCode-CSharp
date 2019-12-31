using System;
using System.Collections.Generic;
using System.Linq;

namespace Matrix_Cells_in_Distance_Order
{
    /// <summary>
    /// We are given a matrix with R rows and C columns has cells with integer coordinates
    /// (r, c), where 0 <= r < R and 0 <= c < C.
    /// 
    /// Additionally, we are given a cell in that matrix with coordinates(r0, c0).
    /// 
    /// Return the coordinates of all cells in the matrix, sorted by their distance from
    /// (r0, c0) from smallest distance to largest distance.Here, the distance between two
    /// cells (r1, c1) and (r2, c2) is the Manhattan distance, |r1 - r2| + |c1 - c2|.  
    /// (You may return the answer in any order that satisfies this condition.)
    ///
    /// Input: R = 2, C = 2, r0 = 0, c0 = 1
    /// Output: [[0,1],[0,0],[1,1],[1,0]]
    /// Explanation: The distances from (r0, c0) to other cells are: [0,1,1,2]
    /// The answer[[0,1],[1,1],[0,0],[1,0]] would also be accepted as correct.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int R = 2, C = 3, r0 = 1, c0 = 2;

            var solution = new Solution();
            var result = solution.AllCellsDistOrder1(R, C, r0, c0);
            foreach (var item in result)
            {
                foreach (var c in item)
                {
                    Console.Write($"{c}, ");
                }
                Console.WriteLine();
            }
        }
    }

    public class Solution
    {
        public int[][] AllCellsDistOrder(int R, int C, int r0, int c0)
        {
            var positionDistance = new Dictionary<int[], int>();
            for (var i = 0; i < R; i++)
            {
                for (var j = 0; j < C; j++)
                {
                    var r = Math.Abs(i - r0);
                    var c = Math.Abs(j - c0);
                    positionDistance.Add(new int[] { i, j }, r + c);
                }
            }

            return positionDistance.OrderBy(x => x.Value).Select(x => x.Key).ToArray();
        }

        public int[][] AllCellsDistOrder1(int R, int C, int r0, int c0)
        {
            bool[,] visited = new bool[R, C];

            Queue<int[]> toVisit = new Queue<int[]>();
            toVisit.Enqueue(new int[] { r0, c0 });
            visited[r0, c0] = true;

            IList<int[]> result = new List<int[]>();
            while (toVisit.Count > 0)
            {
                int[] curr = toVisit.Dequeue();
                result.Add(curr);

                if (curr[0] + 1 < R && !visited[curr[0] + 1, curr[1]])
                {
                    toVisit.Enqueue(new int[] { curr[0] + 1, curr[1] });
                    visited[curr[0] + 1, curr[1]] = true;
                }
                if (curr[0] - 1 >= 0 && !visited[curr[0] - 1, curr[1]])
                {
                    toVisit.Enqueue(new int[] { curr[0] - 1, curr[1] });
                    visited[curr[0] - 1, curr[1]] = true;
                }
                if (curr[1] + 1 < C && !visited[curr[0], curr[1] + 1])
                {
                    toVisit.Enqueue(new int[] { curr[0], curr[1] + 1 });
                    visited[curr[0], curr[1] + 1] = true;
                }
                if (curr[1] - 1 >= 0 && !visited[curr[0], curr[1] - 1])
                {
                    toVisit.Enqueue(new int[] { curr[0], curr[1] - 1 });
                    visited[curr[0], curr[1] - 1] = true;
                }
            }
            return result.ToArray();
        }

    }
}
