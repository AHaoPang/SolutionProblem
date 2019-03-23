using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolutions
{
    public class Problem200 : IProblem
    {
        public void RunProblem()
        {
            var temp = NumIslands(new char[5, 8]);
        }

        public int NumIslands(char[,] grid)
        {

            /*
             * 深度优先染色
             * 发现岛屿，那么就用DFS的方式把整个岛屿夷为平地
             * 知道检索完整个范围以后方可结束
             * 时间复杂度：O(n^2)
             * 空间复杂度：和递归相关
             */

            int numIslands = 0;
            int zeroDimension = grid.GetLength(0);
            int oneDimension = grid.GetLength(1);

            for (int i = 0; i < zeroDimension; i++)
            {
                for (int j = 0; j < oneDimension; j++)
                {
                    if (grid[i, j] == '0') continue;

                    numIslands++;

                    Recursive(i, j, zeroDimension, oneDimension, grid);
                }
            }

            return numIslands;
        }

        private void Recursive(int i, int j, int maxI, int maxJ, char[,] grid)
        {
            if (i < 0 || i >= maxI) return;
            if (j < 0 || j >= maxJ) return;
            if (grid[i, j] != '1') return;

            grid[i, j] = '0';

            Recursive(i - 1, j, maxI, maxJ, grid);
            Recursive(i + 1, j, maxI, maxJ, grid);
            Recursive(i, j - 1, maxI, maxJ, grid);
            Recursive(i, j + 1, maxI, maxJ, grid);
        }
    }
}
