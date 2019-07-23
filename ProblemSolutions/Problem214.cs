using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolutions
{
    public class Problem214 : IProblem
    {
        public void RunProblem()
        {
            var temp = ShortestPalindrome("aacecaaa");
            if (temp != "aaacecaaa") throw new Exception();

            temp = ShortestPalindrome("abcd");
            if (temp != "dcbabcd") throw new Exception();
        }

        public string ShortestPalindrome(string s)
        {
            /*
             * 最短回文串的构造
             * 思路：
             *  1.首先找到从左边开始的已有串中的最大回文串，然后把其余的补足，就是结果了
             *  2.反转字符串，依次交错比较两个字符串，直到找到目标值
             *  
             * 时间复杂度：O(n^2)，一次缩短一点，每次都要比较几乎所有的字符串，但是因为使用了系统提供的字符串比较函数，所以速度会快一些
             * 空间复杂度：O(1)
             */

            var reverseStr = new string(s.Reverse().ToArray());

            for (int i = 0; i < s.Length; i++)
                if (s.Substring(0, s.Length - i) == reverseStr.Substring(i))
                    return reverseStr.Substring(0, i) + s;

            return s;
        }
    }
}
