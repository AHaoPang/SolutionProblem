using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NETFramework45Attempt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listTemp = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var ttt = listTemp.Skip(5).Take(5).ToList();

            ttt = listTemp.Skip(0).Take(20).ToList();

            ttt = listTemp.Skip(20).Take(5).ToList();

            int total = 10;
            List<List<int>> listResult = new List<List<int>>(total);
            for (int j = 0; j < total; j++)
                listResult.Add(null);

            List<Task> tasks = new List<Task>();
            for (int i = 0; i < total; i++)
            {
                Console.WriteLine($"Main i={i}");
                var taskTemp = GetValueAsync(i).ContinueWith(taskResult => { listResult[taskResult.Result.Item1] = taskResult.Result.Item2; });
                tasks.Add(taskTemp);
            }

            Task.WaitAll(tasks.ToArray());



            Console.ReadKey();
        }

        static Task<Tuple<int, List<int>>> GetValueAsync(int i)
        {
            return Task.Run(() => { return GetValues(i); });
        }

        static Tuple<int, List<int>> GetValues(int i)
        {
            Console.WriteLine($"GetValues i={i}");

            var k = i * 10;

            List<int> forReturn = new List<int>();

            for (int j = 0; j < 10; j++)
                forReturn.Add(k + j);

            Random r = new Random();

            var randomValue = r.Next(1, 10);

            Thread.Sleep(randomValue * 1000);
            return Tuple.Create(i, forReturn);
        }
    }
}
