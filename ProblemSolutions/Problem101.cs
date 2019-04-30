using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolutions
{
    public class Problem101 : IProblem
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool IsSymmetric(TreeNode root)
        {
            /*
             * 使用递归的方式，将大的问题逐渐的分解为小的问题
             * 
             * 时间复杂度：O(n)，即最多把树整个遍历了一遍
             * 空间复杂度：O(n)，调用栈的数据存储
             */

            if (root == null) return true;
            return IsMirror(root.left, root.right);
        }

        private bool IsMirror(TreeNode nodeFrom, TreeNode nodeTo)
        {
            if (nodeFrom == null && nodeTo == null) return true;
            if (nodeFrom == null || nodeTo == null) return false;

            return nodeFrom.val == nodeTo.val && IsMirror(nodeFrom.left, nodeTo.right) && IsMirror(nodeFrom.right, nodeTo.left);
        }
    }
}
