using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTaskEx
{
    class Program3
    {
        public void PLINQEx()
        {
            Stopwatch watch = new Stopwatch();

            int[] arr = { 10, 13, 4, 6, 8, 5, 9, 78, 88, 44, 67, 10 };

            #region using LINQ
            Console.WriteLine("Using LINQ");
            bool[] result = arr.Select(x => CheckForEven(x)).ToArray();

            for (int index = 0; index < arr.Length; index++)
            {
                Console.WriteLine(arr[index] + " is a even number:" + result[index]);
            }
            #endregion

            Console.WriteLine();

            #region PLINQ
            Console.WriteLine("Using PLINQ");
            bool[] result1 = arr.AsParallel().Select(x => CheckForEven(x)).ToArray();
           
            for (int index = 0; index < arr.Length; index++)
            {
                Console.WriteLine(arr[index] + " is a even number:" + result1[index]);
            }
            #endregion
        }

        private bool CheckForEven(int p)
        {
            if (p % 2 == 0)
                return true;
            else return false;
        }

    }
}
