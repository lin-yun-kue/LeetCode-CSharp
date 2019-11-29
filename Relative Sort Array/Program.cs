using System;
using System.Collections.Generic;
using System.Linq;

namespace Relative_Sort_Array
{
    /// <summary>
    /// Given two arrays arr1 and arr2, the elements of arr2 are distinct, and all elements in arr2 
    /// are also in arr1.
    /// 
    /// Sort the elements of arr1 such that the relative ordering of items in arr1 are the same as in
    /// arr2.Elements that don't appear in arr2 should be placed at the end of arr1 in ascending order.
    /// 
    /// Input: arr1 = [2,3,1,3,2,4,6,7,9,2,19], arr2 = [2,1,4,3,9,6]
    /// Output: [2,2,2,1,4,3,3,9,6,7,19]
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var arr1 = new int[] { 2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19 };
            var arr2 = new int[] { 2, 1, 4, 3, 9, 6 };
            var solution = new Solution();
            var result = solution.RelativeSortArray(arr1, arr2);
            foreach (var item in result)
            {
                Console.Write($"{item}, ");
            }
        }
    }

    public class Solution
    {
        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            var result = new int[arr1.Length];
            var dic = new Dictionary<int, int>();

            foreach (var item in arr1)
            {
                if (dic.ContainsKey(item))
                {
                    dic[item] += 1;
                }
                else
                {
                    dic.Add(item, 1);
                }
            }

            var flag = 0;
            foreach (var item in arr2)
            {
                if (dic.ContainsKey(item))
                {
                    var loopTime = flag + dic[item];
                    for (; flag < loopTime;flag++)
                    {
                        result[flag] = item;
                    }
                    dic.Remove(item);
                }
            }
            foreach(var item in dic.OrderBy(x => x.Key))
            {
                var loopTime = flag + dic[item.Key];
                for (; flag < loopTime; flag++)
                {
                    result[flag] = item.Key;
                }
            }


            return result;
        }
    }
}
