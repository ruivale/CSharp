using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTaskEx
{
    class ParallelInvoke
    {
        private void OtherTask()
        {
            for (int index = 1; index <= 15; index++)
            {
                Console.WriteLine("Work on other task.." + index);
                Thread.Sleep(1000);
            }
        }

        private void Digging()
        {
            for (int index = 1; index <= 15; index++)
            {
                Console.WriteLine("Digging completed for " + index + "mts. area");
                Thread.Sleep(1000);
            }
        }

        private void CleanIt()
        {
            for (int index = 1; index <= 15; index++)
            {
                Console.WriteLine("Clean the area parallely " + index + "mts. area");
                Thread.Sleep(1000);
            }
        }

        public void CallAllTask()
        {
            Parallel.Invoke(
                new Action(OtherTask)
                , new Action(Digging)
                , new Action(CleanIt));
        }
    }
}
