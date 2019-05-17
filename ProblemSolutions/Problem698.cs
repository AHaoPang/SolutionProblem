using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolutions
{
    public class Problem698 : IProblem
    {
        public void RunProblem()
        {
            var nums = new int[] { 4, 3, 2, 3, 5, 2, 1 };
            int k = 4;
            var temp = CanPartitionKSubsets(nums, k);
        }

        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            /*
             * 思路：回溯法
             * 1.序列中的每个数字，都有放在k个不同集的可能性；（假设集合有序，编号0~K-1）
             * 2.将各种不同的组合穷举出来，然后分别去验证是否满足要求
             * 3.若所有的组合都不满足要求，那么结果就是false
             * 
             * 时间复杂度：O(m^n) --> 指数级别的，复杂度异常的高了
             */

            return Recursive(nums, k, 0, new int[k][]);
        }

        private bool Recursive(int[] nums, int k, int arrayIndex, int[][] resultArray)
        {
            if (arrayIndex == nums.Length) return IsOk(resultArray);

            for (int i = 0; i < k; i++)
            {
                if (resultArray[i] == null)
                {
                    resultArray[i] = new int[nums.Length];
                    for (int j = 0; j < resultArray[i].Length; j++) resultArray[i][j] = -1;
                }

                int l = 0;
                for (; l < k; l++)
                {
                    if (resultArray[i][l] == -1)
                    {
                        resultArray[i][l] = nums[arrayIndex];
                        break;
                    }
                }

                if (Recursive(nums, k, arrayIndex + 1, resultArray)) return true;

                resultArray[i][l] = -1;
            }

            //所有可能性都试过了，还没有满足要求的，那么就说明不可能了
            return false;
        }

        private bool IsOk(int[][] resultArray)
        {
            int sumTemp = 0;
            int compareValue = 0;
            for (int i = 0; i < resultArray.Length; i++)
            {
                //一个集合没放数字，那么就是false
                if (resultArray[i] == null) return false;

                sumTemp = 0;
                for (int j = 0; j < resultArray[i].Length; j++) if (resultArray[i][j] != -1)
                        sumTemp += resultArray[i][j];

                if (i == 0) compareValue = sumTemp;
                else if (compareValue != sumTemp) return false;
            }

            return true;
        }
    }
}
