using System;
using System.Collections.Generic;
using System.Linq;

namespace JudgeCirlcle
{
    /// <summary>
    /// There is a robot starting at position (0, 0), the origin, on a 2D plane. 
    /// Given a sequence of its moves, judge if this robot ends up at (0, 0) after 
    /// it completes its moves.
    /// The move sequence is represented by a string, and the character moves[i] represents
    /// its ith move.Valid moves are R (right), L (left), U (up), and D (down). If the robot
    /// returns to the origin after it finishes all of its moves, return true. Otherwise, 
    /// return false.
    /// Note: The way that the robot is "facing" is irrelevant. "R" will always make the 
    /// robot move to the right once, "L" will always make it move left, etc.Also, assume
    /// that the magnitude of the robot's movement is the same for each move.
    /// 
    /// Input: "UD"
    /// Output: true 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = "UDLLR";
            var solution = new Solution();
            var result = solution.JudgeCircle1(input);
            Console.WriteLine(result);
        }

        class Solution
        {
            public bool JudgeCircle(string moves)
            {
                var arr = moves.ToCharArray();
                var dic = new Dictionary<char, int>()
                {
                    { 'U', 0 },
                    { 'D', 0 },
                    { 'R', 0 },
                    { 'L', 0 }
                };

                foreach (var item in arr)
                {
                    dic[item]++;
                }

                if (dic['U'] == dic['D'] && dic['R'] == dic['L'])
                {
                    return true;
                }
                return false;
            }

            public bool JudgeCircle1(string moves)
            {
                var h = 0;
                var v = 0;
                foreach(var item in moves)
                {
                    if (item == 'U')
                        v++;
                    if (item == 'D')
                        v--;
                    if (item == 'R')
                        h++;
                    if (item == 'L')
                        h--;
                }

                if (h == 0 && v == 0)
                    return true;
                else
                    return false;
            }

            public bool JudgeCircle2(string moves)
            {
                return moves.Count(x => x == 'R') == moves.Count(x => x == 'L') && moves.Count(x => x == 'U') == moves.Count(x => x == 'D');
            }
        }
    }
}
