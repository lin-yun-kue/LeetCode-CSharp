using System;
using System.Collections.Generic;

namespace MaximumDepthofN_aryTree
{
    /// <summary>
    /// Given a n-ary tree, find its maximum depth.
    /// 
    /// The maximum depth is the number of nodes along the longest path from the root node down to 
    /// the farthest leaf node.
    /// 
    /// Nary-Tree input serialization is represented in their level order traversal, each group of children is
    /// separated by the null value (See examples).
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
            var result = solution.MaxDepth1(root);
            Console.WriteLine(result);
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
        public int Result = 0;

        /// <summary>
        /// recursive
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(Node root)
        {
            if(root == null)
            {
                return Result;
            }
            Handle(root);
            return Result;
        }

        public void Handle(Node root, int dep = 1)
        {
            if(dep > Result)
            {
                Result = dep;
            }

            if(root.children != null)
            {
                var nextDep = dep + 1;
                foreach(var item in root.children)
                {
                    Handle(item, nextDep);
                }
            }
        }

        public int MaxDepth1(Node root)
        {
            var result = 0;
            if(root == null)
            {
                return result;
            }
            var stack = new Stack<(Node, int)>();

            stack.Push((root, 1));

            while (stack.TryPop(out (Node, int) popItem))
            {
                if (popItem.Item2 > result)
                {
                    result = popItem.Item2;
                }
                if (popItem.Item1.children != null)
                {
                    var nextDepth = popItem.Item2 + 1;
                    foreach (var item in popItem.Item1.children)
                    {
                        stack.Push((item, nextDepth));
                    }
                }
            }
            return result;
        }
    }
}
