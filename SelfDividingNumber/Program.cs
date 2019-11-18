using System;
using System.Collections.Generic;

namespace SelfDividingNumber
{
    /// <summary>
    /// A self-dividing number is a number that is divisible by every digit it contains.
    /// 
    /// For example, 128 is a self-dividing number because 128 % 1 == 0, 128 % 2 == 0, and 128 % 8 == 0.
    /// 
    /// Also, a self-dividing number is not allowed to contain the digit zero.
    /// 
    /// Given a lower and upper number bound, output a list of every possible self dividing number,
    /// including the bounds if possible.
    /// 
    /// Input: 
    /// left = 1, right = 22
    /// Output: [1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22]
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var left = 1;
            var right = 22;
            var solution = new Solution();
            var result = solution.SelfDividingNumbers1(left, right);
            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
        }

        class Solution
        {
            public IList<int> SelfDividingNumbers(int left, int right)
            {
                var result = new List<int>();
                for(var i = left; i <= right; i++)
                {
                    var isSelfDivide = true;
                    foreach(var n in i.ToString())
                    {
                        if(n == '0' || i % (n - '0') != 0)
                        {
                            isSelfDivide = false;
                            break;
                        }

                    }
                    if (isSelfDivide)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }

            public IList<int> SelfDividingNumbers1(int left, int right)
            {
                var result = new List<int>();
                for(var i = left; i <= right; i++)
                {
                    int currentDigit = 0;
                    int tempNum = i;
                    bool isSelfDivide = true;
                    while(tempNum > 0)
                    {
                        currentDigit = tempNum % 10;
                        if(currentDigit == 0 || i % currentDigit != 0)
                        {
                            isSelfDivide = false;
                            break;
                        }
                        tempNum /= 10;
                    }
                    if (isSelfDivide)
                        result.Add(i);
                }
                return result;

            }
        }
    }
}
