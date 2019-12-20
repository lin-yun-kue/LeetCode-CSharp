using System;
using System.Collections.Generic;

namespace Leaf_Similar_Trees
{
    /// <summary>
    /// Leetcode 872
    /// Consider all the leaves of a binary tree.  From left to right order, the values of those leaves
    /// form a leaf value sequence.
    /// 
    /// Two binary trees are considered leaf-similar if their leaf value sequence is the same.
    /// Return true if and only if the two given trees with head nodes root1 and root2 are leaf-similar.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var root1 = new TreeNode(3);
            root1.left = new TreeNode(5);
            root1.right = new TreeNode(1);
            root1.left.left = new TreeNode(6);
            root1.left.right = new TreeNode(2);
            root1.left.right.left = new TreeNode(7);
            root1.left.right.right = new TreeNode(4);
            root1.right.left = new TreeNode(9);
            root1.right.right = new TreeNode(8);

            var root2 = new TreeNode(3);
            root2.left = new TreeNode(5);
            root2.right = new TreeNode(1);
            root2.left.left = new TreeNode(6);
            root2.left.right = new TreeNode(7);
            root2.right.left = new TreeNode(4);
            root2.right.right = new TreeNode(2);
            root2.right.right.left = new TreeNode(9);
            root2.right.right.right = new TreeNode(8);

            var solution = new Solution();
            var result = solution.LeafSimilar(root1, root2);
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
        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            var s1 = GetSeq(root1);
            var s2 = GetSeq(root2);
            while (s1.MoveNext() && s2.MoveNext())
            {
                if(s1.Current != s2.Current)
                {
                    return false;
                }
            }
            return true;
        }

        public IEnumerator<int> GetSeq(TreeNode r)
        {
            var stack = new Stack<TreeNode>();
            stack.Push(r);
            TreeNode popItem;
            while(stack.TryPop(out popItem))
            {
                if(popItem.left == null && popItem.right == null)
                {
                    yield return popItem.val;
                    continue;
                }
                if(popItem.right != null)
                {
                    stack.Push(popItem.right);
                }
                if (popItem.left != null)
                {
                    stack.Push(popItem.left);
                }
            }
        }
    }
}
