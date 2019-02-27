using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolutions
{
    public class Problem052 : IProblem
    {
        public void RunProblem()
        {
            var temp = TotalNQueens(4);
        }

        public int TotalNQueens(int n)
        {
            PutQueens(n, 0, 0, 0, 0);

            return totalWays2;
        }

        int totalWays2 = 0;

        private void PutQueens(int totalRow,int curRow,int col,int pie,int na)
        {
            //递归中止条件
            if (curRow == totalRow)
            {
                totalWays2++;
                return;
            }

            //当前行有多少可填写位置？
            var pos = (~(col | pie | na)) & ((1 << totalRow) - 1);

            //挨个儿遍历这些位置，并继续下去
            while(pos > 0)
            {
                var v = pos & -pos;

                PutQueens(totalRow, curRow + 1, col | v, (pie | v) << 1, (na | v) >> 1);

                pos = pos & (pos - 1);
            }
        }

        #region Way1
        public int TotalNQueensV1(int n)
        {
            NQueens(0, n, new bool[n], new HashSet<int>(), new HashSet<int>());

            return totalCount;
        }

        private int totalCount = 0;

        private void NQueens(int curPos, int tCount, IList<bool> colPos, HashSet<int> pie, HashSet<int> na)
        {
            if (curPos == tCount)
            {
                totalCount++;
                return;
            }

            for (int i = 0; i < tCount; i++)
            {
                //不满足的情况，跳过
                if (colPos[i] || pie.Contains(curPos + i) || na.Contains(curPos - i)) continue;

                //满足的情况，继续深入
                colPos[i] = true;
                pie.Add(curPos + i);
                na.Add(curPos - i);

                NQueens(curPos + 1, tCount, colPos, pie, na);

                colPos[i] = false;
                pie.Remove(curPos + i);
                na.Remove(curPos - i);
            }
        } 
        #endregion
    }
}
