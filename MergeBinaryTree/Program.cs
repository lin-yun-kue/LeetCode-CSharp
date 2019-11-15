using System;
using System.Collections.Generic;

namespace MergeBinaryTree
{
    /// <summary>
    /// Given two binary trees and imagine that when you put one of them to cover the other,
    /// some nodes of the two trees are overlapped while the others are not.
    /// 
    /// You need to merge them into a new binary tree.The merge rule is that if two nodes overlap,
    /// then sum node values up as the new value of the merged node.Otherwise, the NOT null node
    /// will be used as the node of new tree.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = new TreeNode(1);
            t1.left = new TreeNode(3);
            t1.right = new TreeNode(2);
            t1.left.left = new TreeNode(5);

            var t2 = new TreeNode(2);
            t2.left = new TreeNode(1);
            t2.right = new TreeNode(3);
            t2.left.right = new TreeNode(4);
            t2.right.right = new TreeNode(7);

            var solution = new Solution();
            var result = solution.MergeTrees2(t1, t2);
            Console.Read();

        }


    }

    class Solution
    {
        TreeNode node = new TreeNode(0);

        /// <summary>
        /// recursive method
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
                return null;
            Handle(t1, t2, node);
            return node;
        }

        public void Handle(TreeNode t1, TreeNode t2, TreeNode cur)
        {
            cur.val = (t1?.val ?? 0) + (t2?.val ?? 0);

            if(t1?.left != null || t2?.left != null)
            {
                cur.left = new TreeNode(0);
                Handle(t1?.left, t2?.left, cur.left);
            }

            if (t1?.right != null || t2?.right != null)
            {
                cur.right = new TreeNode(0);
                Handle(t1?.right, t2?.right, cur.right);
            }
        }


        /// <summary>
        /// recursive method
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public TreeNode MergeTrees1(TreeNode t1, TreeNode t2)
        {
            
            if (t1 == null)
                return t2;
            if (t2 == null)
                return t1;
            t1.val = t1.val + t2.val;
            t1.left = MergeTrees1(t1.left, t2.left);
            t1.right = MergeTrees1(t1.right, t2.right);
            return t1;
        }

        /// <summary>
        /// Iterative
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public TreeNode MergeTrees2(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
                return t2;
            if (t2 == null)
                return t1;

            var stack = new Stack<TreeNode[]>();
            stack.Push(new TreeNode[] { t1, t2 });

            TreeNode[] popObject;
            while(stack.TryPop(out popObject))
            {
                if(popObject[1] == null)
                {
                    continue;
                }
                popObject[0].val += popObject[1].val;
                if(popObject[0].left == null)
                {
                    popObject[0].left = popObject[1].left;
                }
                else
                {
                    stack.Push(new TreeNode[] { popObject[0].left, popObject[1].left });
                }

                if(popObject[0].right == null)
                {
                    popObject[0].right = popObject[1].right;
                }
                else
                {
                    stack.Push(new TreeNode[] { popObject[0].right, popObject[1].right });
                }
            }
            return t1;
        }
    }

    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
