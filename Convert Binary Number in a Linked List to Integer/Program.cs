using System;
using System.Collections;
using System.Collections.Generic;

namespace Convert_Binary_Number_in_a_Linked_List_to_Integer
{
    /// <summary>
    /// Given head which is a reference node to a singly-linked list. The value of each node in the
    /// linked list is either 0 or 1. The linked list holds the binary representation of a number.
    /// 
    /// Return the decimal value of the number in the linked list.
    /// 
    /// Input: head = [1,0,1]
    /// Output: 5
    /// Explanation: (101) in base 2 = (5) in base 10
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var root = new ListNode(1);
            root.next = new ListNode(0);
            root.next.next = new ListNode(0);
            //root.next.next.next = new ListNode(1);
            var solution = new Solution();
            var result = solution.GetDecimalValue(root);
            Console.WriteLine(result);
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public int GetDecimalValue(ListNode head)
        {
            var list = new List<int>();
            
            while(head != null)
            {
                list.Add(head.val);
                head = head.next;
            }
            int result = 0;
            for(int i = 0, j = list.Count - 1; i < list.Count; i++, j--)
            {
                result += list[i] * (int)Math.Pow(2.0, Convert.ToDouble(j));
            }
            return result;

        }


        public int GetDecimalValue1(ListNode head)
        {
            int res = 0;
            while (head != null)
            {
                res = res * 2 + head.val;
                head = head.next;
            }

            return res;
        }



    }
}
