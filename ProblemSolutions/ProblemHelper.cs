using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolutions
{
    /// <summary>
    /// 解题辅助类的工具
    /// </summary>
    public static class ProblemHelper
    {
        /// <summary>
        /// 判断两个数组是相等的（内部的值一致）
        /// </summary>
        public static bool ArrayIsEqual(int[] arr1,int[] arr2)
        {
            if (arr1.Length != arr1.Length) return false;

            var arr1Temp = arr1.OrderBy(i => i).ToArray();
            var arr2Temp = arr2.OrderBy(i => i).ToArray();

            for (int i = 0; i < arr1Temp.Length; i++)
                if (arr1Temp[i] != arr2Temp[i]) return false;

            return true;
        }
    }
}
