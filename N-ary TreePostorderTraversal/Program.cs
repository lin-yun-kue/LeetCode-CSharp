using System;
using System.Collections.Generic;
using System.Linq;

namespace N_ary_TreePostorderTraversal
{
    /// <summary>
    /// Given an n-ary tree, return the postorder traversal of its nodes' values.
    /// 
    /// Nary-Tree input serialization is represented in their level order traversal,
    /// each group of children is separated by the null value(See examples).
    /// 
    /// Input: root = [1,null,3,2,4,null,5,6]
    /// Output: [5,6,3,2,4,1]
    /// 
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
            var result = solution.Postorder1(root);

            foreach (var item in result)
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

    class Solution
    {
        private List<int> result = new List<int>();

        /// <summary>
        /// recursive method
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Postorder(Node root)
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
            if(root.children != null)
            {
                foreach(var item in root.children)
                {
                    Handle(item);
                }
            }
            result.Add(root.val);
        }

        public IList<int> Postorder1(Node root)
        {
            if(root == null)
            {
                return new List<int>();
            }
            var stack = new Stack<Node>();
            var calcStack = new Stack<Node>();
            stack.Push(root);


            Node tempNode;
            while(stack.TryPop(out tempNode))
            {
                calcStack.Push(tempNode);
                if(tempNode.children != null)
                {
                    foreach(var item in tempNode.children)
                    {
                        stack.Push(item);
                    }
                }
            }
            
            return calcStack.Select(x => x.val).ToList();
        }
    }
}
