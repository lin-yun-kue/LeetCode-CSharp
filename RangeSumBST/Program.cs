using System;

namespace RangeSumBST
{
    /// <summary>
    /// Given the root node of a binary search tree, return the sum of values of all nodes with value between L and R (inclusive).
    /// The binary search tree is guaranteed to have unique values.
    /// 
    /// Input: root = [10,5,15,3,7,null,18], L = 7, R = 15
    /// Output: 32
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var values = new int?[] { 10, 5, 15, 3, 7, null, 18 };
            TreeNode root = new TreeNode(values[0]);
            root.left = new TreeNode(values[1]);
            root.right = new TreeNode(values[2]);
            root.left.left = new TreeNode(values[3]);
            root.left.right = new TreeNode(values[4]);
            root.right.left = new TreeNode(values[5]);
            root.right.right = new TreeNode(values[6]);
            
            int L = 7;
            int R = 15;

            var result = RangeSumBST(root, L, R);

            Console.WriteLine(result);
        }

        /// <summary>
        /// recursive
        /// </summary>
        /// <param name="root"></param>
        /// <param name="L"></param>
        /// <param name="R"></param>
        /// <returns></returns>
        public static int RangeSumBST(TreeNode root, int L, int R)
        {
            var val = 0;

            if (root.val.HasValue && root.val >= L && root.val <= R)
            {
                val = root.val.Value;
            }
            if (root.left != null && root.val >= L)
            {
                val += RangeSumBST(root.left, L, R);
            }
            if (root.right != null && root.val <= R)
            {
                val += RangeSumBST(root.right, L, R);
            }

            return val;
        }
    }

    public class TreeNode
    {
      public int? val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int? x) { val = x; }
  }
}
