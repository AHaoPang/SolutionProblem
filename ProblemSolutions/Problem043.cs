using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolutions
{
    public class Problem043 : IProblem
    {
        public void RunProblem()
        {
            var temp = Multiply("123", "456");
            if (temp != "56088") throw new Exception();

            temp = Multiply("2", "3");
            if (temp != "6") throw new Exception();
        }

        public string Multiply(string num1, string num2)
        {
            /*
             * 大数相乘，输入的是字符串，输出的也是字符串
             * 思路：
             *  1.模拟手动计算乘法时的处理方式
             *  2.按照每一位，计算出一个字符串
             *  3.将多个字符串，按位来求和
             *  
             * 时间复杂度：O(m*n)，因为要让每个位都计算出一个字符串
             * 空间复杂度：O(m)，基本上要临时存储乘数位个字符串
             * 
             * 考察点：
             *  1.大数乘法
             *  2.字符串的使用
             */

            //特殊情况处理
            if (num1 == "0" || num2 == "0") return "0";

            //得到M个字符串
            List<string> subStrings = new List<string>(num2.Length);
            for (int i = num2.Length - 1; i >= 0; i--)
            {
                int value2 = int.Parse(num2[i].ToString());
                if (value2 == 0) continue;

                var valueStr = "";
                int increasePos = 0;
                for (int j = num1.Length - 1; j >= 0; j--)
                {
                    var value1 = int.Parse(num1[j].ToString());
                    var increasePosTemp = increasePos % 10;

                    var newValue = value2 * value1 + increasePosTemp;

                    valueStr = $"{newValue % 10}" + valueStr;
                    increasePos = increasePos / 10 + newValue / 10;
                }
                if (increasePos != 0)
                    valueStr = $"{increasePos}" + valueStr;

                int loopCount = num2.Length - 1 - i;
                for (int k = 0; k < loopCount; k++)
                    valueStr += "0";

                subStrings.Add(valueStr);
            }

            //对M个字符串做求和处理
            var tempStr = subStrings[0];
            for (int i = 1; i < subStrings.Count; i++)
                tempStr = StrAdd(tempStr, subStrings[i]);

            //返回目标值
            return tempStr;
        }

        private string StrAdd(string s1, string s2)
        {
            int s1Pos = s1.Length - 1;
            int s2Pos = s2.Length - 1;

            string forReturn = "";
            int increasePos = 0;
            while (s1Pos >= 0 || s2Pos >= 0)
            {
                int v1 = 0;
                if (s1Pos >= 0)
                {
                    v1 = int.Parse(s1[s1Pos].ToString());
                    s1Pos--;
                }

                int v2 = 0;
                if (s2Pos >= 0)
                {
                    v2 = int.Parse(s2[s2Pos].ToString());
                    s2Pos--;
                }

                int increaseTemp = increasePos % 10;

                int newValue = v1 + v2 + increaseTemp;

                forReturn = $"{newValue % 10}" + forReturn;
                increasePos = increasePos / 10 + newValue / 10;
            }

            if (increasePos != 0)
                forReturn = $"{increasePos}" + forReturn;

            return forReturn;
        }
    }
}
