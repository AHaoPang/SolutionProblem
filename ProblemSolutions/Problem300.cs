using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolutions
{
    public class Problem300 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int LengthOfLIS(int[] nums)
        {
            if (nums.Length < 1) return 0;

            int curMin = nums[0] + 1;
            for (int i = 0; i < nums.Length; i++)
                if (curMin > nums[i])
                {
                    curMin = nums[i];
                    NextItemRecursive(nums[i], i + 1, 1, nums);
                }

            return recursiveMaxLength;
        }

        #region 回溯法
        /*
         * 本质是找出了所有的可能性，然后筛选出最长的！
         * 数组中每个元素都有“选”和“不选”这两种情况
         * 时间复杂度：O(2^n);
         * 空间复杂度：O(n^2);-->这里的复杂度还是有些疑问的-->抽象为统计两个树的节点数量=2*(n*(1+2^n)/2)=n+n*2^n
         */

        private int recursiveMaxLength = 0;

        /// <summary>
        /// 以当前的状态，朝着哪里更进一步
        /// </summary>
        /// <param name="curNum">当前状态/数字</param>
        /// <param name="nextPos">下一个位置</param>
        /// <param name="curLength">当前的长度</param>
        private void NextItemRecursive(int curNum, int nextPos, int curLength, int[] nums)
        {
            //end point
            if (nextPos == nums.Length)
            {
                if (recursiveMaxLength < curLength) recursiveMaxLength = curLength;
                return;
            }

            //回溯的思路：
            //数字大的时候，可以选可以不选
            //数字小的时候，则一定不能选
            if (nums[nextPos] > curNum)
                NextItemRecursive(nums[nextPos], nextPos + 1, curLength + 1, nums);

            NextItemRecursive(curNum, nextPos + 1, curLength, nums);
        }

        #endregion
    }
}
