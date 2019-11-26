using System;

namespace SearchInBST
{
    /// <summary>
    /// Given the root node of a binary search tree (BST) and a value. You need to find the node in the 
    /// BST that the node's value equals the given value. Return the subtree rooted with that node. If 
    /// such node doesn't exist, you should return NULL.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(4);
            root.left = new TreeNode(2);
            root.right = new TreeNode(7);
            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(3);

            var solution = new Solution();
            var result = solution.SearchBST1(root, 8);

            Console.WriteLine(result.val);
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
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null)
                return default;
            if(root.val == val)
            {
                return root;
            }
            if(root.val > val && root.left != null)
            {
                return SearchBST(root.left, val);
            }
            if(root.val < val && root.right != null)
            {
                return SearchBST(root.right, val);
            }
            return default;
        }

        private TreeNode target = null;


        public TreeNode SearchBST1(TreeNode root, int val)
        {
            if (root == null)
                return default;
            Handle(root, val);
            return target;
        }

        public void Handle(TreeNode root, int val)
        {
            if(root.val == val)
            {
                target = root;
                return;
            }
            if(root.val > val && root.left != null)
            {
                Handle(root.left, val);
            }
            if(root.val < val && root.right != null)
            {
                Handle(root.right, val);
            }
            return;
        }
    }
}
