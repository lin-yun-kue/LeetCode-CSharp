using System;
using System.Collections;

namespace Palindrome
{
    /// <summary>
    /// From head to tail and tail to head are same string
    /// input 12321
    /// output true
    /// 
    /// input 1221
    /// output true
    /// 
    /// input 123333
    /// output false
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var result = IsPalindrome1(input);
            //var result = IsPalindrome2(input);
            //var result = IsPalindrome3(input);
            Console.WriteLine(result);
        }

        /// <summary>
        /// queue & stack
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsPalindrome1(string input)
        {
            if (input.Length == 0 || input.Length == 1)
            {
                return true;
            }

            var inputArray = input.ToCharArray();

            var que = new Queue();
            var stack = new Stack();

            foreach (var i in inputArray)
            {
                que.Enqueue(i);
                stack.Push(i);
            }

            while (que.Count > 0 && stack.Count > 0)
            {
                if ((char)que.Dequeue() != (char)stack.Pop())
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// string reverse read
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsPalindrome2(string input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                var head = input[i];
                var tail = input[input.Length - i - 1];
                if (head != tail)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// recursive
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsPalindrome3(string input, int flag = 0)
        {
            if (input.Length / 2 < flag || input.Length == 0 || input.Length == 1)
            {
                return true;
            }
            if (input[flag] != input[input.Length - flag - 1])
            {
                return false;
            }
            else
            {
                return IsPalindrome3(input, ++flag);
            }
        }
    }
}
