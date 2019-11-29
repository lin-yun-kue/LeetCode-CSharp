using System;
using System.Linq;

namespace Projection_Area_of_3D_Shapes
{
    /// <summary>
    /// On a N* N grid, we place some 1 * 1 * 1 cubes that are axis-aligned with the x, y, and z axes.
    /// Each value v = grid[i][j] represents a tower of v cubes placed on top of grid cell (i, j).
    /// 
    /// Now we view the projection of these cubes onto the xy, yz, and zx planes.
    /// 
    /// A projection is like a shadow, that maps our 3 dimensional figure to a 2 dimensional plane. 
    /// 
    /// Here, we are viewing the "shadow" when looking at the cubes from the top, the front, and the
    /// side.
    /// 
    /// Return the total area of all three projections.
    /// 
    /// Input: [[2]]
    /// Output: 5
    /// 
    /// Input: [[1,2],[3,4]]
    /// Output: 17
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[][]
            {
                new int[]{ 1, 2 },
                new int[]{ 3, 4 }
            };

            var solution = new Solution();
            var result = solution.ProjectionArea(input);
            Console.WriteLine(result);
        }
    }

    public class Solution
    {
        public int ProjectionArea(int[][] grid)
        {
            var len = grid.Length;

            var xyProject = 0;
            var zxProject = 0;
            var zyProject = 0;

            for (var i = 0; i < len; i++)
            {
                xyProject += grid[i].Count(x => x != 0);
                zxProject += grid[i].Max();

                var max = 0;
                for (var j = 0; j < len; j++)
                {
                    if (grid[j][i] > max)
                    {
                        max = grid[j][i];
                    }
                }
                zyProject += max;
            }
            return xyProject + zxProject + zyProject;
        }
    }
}
