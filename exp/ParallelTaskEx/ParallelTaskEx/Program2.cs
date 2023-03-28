using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTaskEx
{
    class Program2
    {
        public void ParallelTask()
        {
            Stopwatch watch = new Stopwatch();

            #region Sequencial Task
            /*Start Timer*/
            watch.Start();

            /*Task to be performed*/
            for (int index = 0; index < 15; index++)
            {
                Console.WriteLine("Digging completed for " + index + "mts. area");
                Thread.Sleep(1000);

            }
            /*Stop Timer*/
            watch.Stop();
            Console.WriteLine("Time required single handed: " + watch.Elapsed.Seconds);
            #endregion

            #region Parallel Task
            watch = new Stopwatch();
            watch.Start();
            System.Threading.Tasks.Parallel.For(0, 15, index =>
            {
                Console.WriteLine("Digging completed for " + index + "mts. area ");
                Thread.Sleep(1000);

            }
            );
            watch.Stop();
            Console.WriteLine("Time required time for Parallel digging: " + watch.Elapsed.Seconds);
            #endregion

            #region ParallelLoopState check
            Console.WriteLine("Using Break");
            Parallel.For(0, 15, (int index, ParallelLoopState loopState) =>
            {
                if (index == 10)
                {
                    loopState.Break();

                }
                Console.WriteLine("Digging for " + index + "mts. area ");
                Thread.Sleep(1000);

            });
            #endregion
        }

    }
}
