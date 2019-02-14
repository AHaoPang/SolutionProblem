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
    }
}
