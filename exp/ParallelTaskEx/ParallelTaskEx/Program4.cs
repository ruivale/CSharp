using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTaskEx
{
    class Program4
    {
        public void ContinueWithExample()
        {
            Task t2 = null;
            Task t = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Digging is in progress");
            });

            Console.WriteLine("");
            
            t2 = t.ContinueWith((a) => {
                Console.WriteLine("Clean the area");
                for (int index = 1; index <= 5; index++)
                {
                  Console.WriteLine("Cleaning...." + index);
                }
                Console.WriteLine("Cleaning done");
            });

            Task.WaitAll(t, t2);// To ensure both tasks are completed
            Console.Read();
        }


        
    }
}
