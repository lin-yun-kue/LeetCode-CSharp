using System;
using System.Collections.Generic;
using System.Linq;

namespace N_aryTreePreorderTraversal
{
    /// <summary>
    /// Given an n-ary tree, return the preorder traversal of its nodes' values.
    /// 
    /// Nary-Tree input serialization is represented in their level order traversal, each group of children is
    /// separated by the null value(See examples).
    /// 
    /// Input: root = [1,null,3,2,4,null,5,6]
    /// Output: [1,3,5,6,2,4]
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var root = new Node(1);
            root.children = new List<Node>()
            {
                new Node(3, new List<Node>(){ 
                    new Node(5),
                    new Node(6)
                }),
                new Node(2),
                new Node(4)
            };
            var solution = new Solution();
            var result = solution.Preorder1(root);
            foreach(var item in result)
            {
                Console.Write($"{item}, ");
            }
        }
    }

    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }

    public class Solution
    {
        public List<int> result = new List<int>();
        
        /// <summary>
        /// Recursive method
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Preorder(Node root)
        {
            if(root == null)
            {
                return result;
            }
            Handle(root);
            return result;
        }

        public void Handle(Node root)
        {
            result.Add(root.val);
            if (root.children != null)
            {
                foreach(var item in root.children)
                {
                    Handle(item);
                }
            }
        }

        /// <summary>
        /// Iterative method
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Preorder1(Node root)
        {
            var result = new List<int>();
            if(root == null)
            {
                return result;
            }
            var stack = new Stack<Node>();

            stack.Push(root);

            Node popItem;
            while (stack.TryPop(out popItem))
            {
                result.Add(popItem.val);
                if(popItem.children != null)
                {
                    foreach(var item in popItem.children.Reverse())
                    {
                        stack.Push(item);
                    }
                }
            }
            return result;
        }

    }
}
