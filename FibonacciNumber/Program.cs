using System;

namespace FibonacciNumber
{
    /// <summary>
    /// The Fibonacci numbers, commonly denoted F(n) form a sequence, called the Fibonacci
    /// sequence, such that each number is the sum of the two preceding ones, starting from 0 and 1.
    /// That is,
    /// 
    /// Input: 2
    /// Output: 1
    /// Explanation: F(2) = F(1) + F(0) = 1 + 0 = 1.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = 4;
            var solution = new Solution();
            var result = solution.Fib1(input);
            Console.WriteLine(result);
        }
    }

    public class Solution
    {
        /// <summary>
        /// recursive
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public int Fib(int N)
        {
            if (N <= 1)
                return N;
            return Fib(N - 1) + Fib(N - 2);
        }

        /// <summary>
        /// iterative
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public int Fib1(int N)
        {
            if (N <= 1)
                return N;

            var pr1 = 0;
            var pr2 = 1;
            var result = 0;
            for(var i = 2; i <= N; i++)
            {
                result = pr1 + pr2;
                pr1 = pr2;
                pr2 = result;
            }
            return result;
        }
    }
}
