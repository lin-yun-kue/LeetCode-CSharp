using System;
using System.Collections.Generic;

namespace UnivaluedBinaryTree
{
    /// <summary>
    /// A binary tree is univalued if every node in the tree has the same value.
    /// 
    /// Return true if and only if the given tree is univalued.
    /// 
    /// Input: [1,1,1,1,1,null,1]
    /// Output: true
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(1);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(1);
            root.right.right = new TreeNode(1);

            var solution = new Solution();
            var result = solution.IsUnivalTree1(root);
            Console.WriteLine(result);
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
        private bool isUnivalTree = true;
        private int unival;
        /// <summary>
        /// recursive method
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsUnivalTree(TreeNode root)
        {
            unival = root.val;
            Handle(root);
            return isUnivalTree;
        }

        public void Handle(TreeNode root)
        {
            if (isUnivalTree == false) 
                return;
            
            if (root.val != unival) 
                isUnivalTree = false;

            if (root.left != null && isUnivalTree)
                Handle(root.left);

            if (root.right != null && isUnivalTree)
                Handle(root.right);
        }

        /// <summary>
        /// iterative method
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsUnivalTree1(TreeNode root)
        {
            var stack = new Stack<TreeNode>();
            stack.Push(root);
            var unival = root.val;
            TreeNode popItem;
            while(stack.TryPop(out popItem))
            {
                if(popItem.val != unival)
                {
                    return false;
                }
                if(popItem.left != null)
                    stack.Push(popItem.left);
                if(popItem.right != null)
                    stack.Push(popItem.right);
            }
            return true;
        }

    }
}
