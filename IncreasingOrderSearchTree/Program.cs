using System;
using System.Collections.Generic;

namespace IncreasingOrderSearchTree
{
    /// <summary>
    /// Given a binary search tree, rearrange the tree in in-order so that the leftmost node in the tree is
    /// now the root of the tree, and every node has no left child and only 1 right child.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(5);
            root.left = new TreeNode(3);
            root.right = new TreeNode(6);
            root.left.left = new TreeNode(2);
            root.left.right = new TreeNode(4);
            root.left.left.left = new TreeNode(1);
            root.right.right = new TreeNode(8);
            root.right.right.left = new TreeNode(7);
            root.right.right.right = new TreeNode(9);

            var solution = new Solution();
            var result = solution.IncreasingBST1(root);
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
        private TreeNode result;
        private TreeNode current;

        /// <summary>
        /// recursive
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode IncreasingBST(TreeNode root)
        {
            Handle(root);
            return result;
        }

        private void Handle(TreeNode root)
        {
            if (root.left != null)
            {
                Handle(root.left);
            }
            if (result == null)
            {
                result = new TreeNode(root.val);
                current = result;
            }
            else
            {
                current.right = new TreeNode(root.val);
                current = current.right;
            }
            if (root.right != null)
            {
                Handle(root.right);
            }
        }

        /// <summary>
        /// iterative method
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode IncreasingBST1(TreeNode root)
        {
            TreeNode result = new TreeNode(0);
            TreeNode pre = result;
            TreeNode cur = root;
            var stack = new Stack<TreeNode>();
            TreeNode popItem;

            while (cur != null || stack.Count != 0) {
                while (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }

                popItem = stack.Pop();

                pre.right = new TreeNode(popItem.val);
                pre = pre.right;

                cur = popItem.right;
            }

            return result.right;
        }
    }
}
