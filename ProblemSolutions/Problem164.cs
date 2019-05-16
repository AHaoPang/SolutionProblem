using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolutions
{
    public class Problem164 : IProblem
    {
        public void RunProblem()
        {
            var temp = MaximumGap(new int[] { 3, 6, 9, 1 });
        }

        public int MaximumGap(int[] nums)
        {
            /*
             * 思路：借用key-value的方式，再结合有序字典
             */


            int forReturn = 0;
            if (nums.Length < 2) return forReturn;

            SortedDictionary<int, int> sortedDic = new SortedDictionary<int, int>();

            foreach(var numItem in nums)
                sortedDic[numItem] = 1;

            var keys = sortedDic.Keys.ToList();
            for (int i = 0; i < keys.Count - 1; i++)
                if (keys[i + 1] - keys[i] > forReturn) forReturn = keys[i + 1] - keys[i];

            return forReturn;
        }

        public int MaximumGap1(int[] nums)
        {
            /*
             * 思路：
             * 1.先对数组排序；
             * 2.然后比较相邻的数字的差值，取到最大值；
             * 
             * 时间复杂度：O(nlogn)
             * 空间复杂度: O(1)
             */

            if (nums.Length < 2) return 0;

            var orderedNums = nums.OrderBy(i => i).ToList();

            int maxGapTemp = 0;
            for (int i = 0; i < orderedNums.Count - 1; i++)
                if (orderedNums[i + 1] - orderedNums[i] > maxGapTemp) maxGapTemp = orderedNums[i + 1] - orderedNums[i];

            return maxGapTemp;
        }
    }
}
