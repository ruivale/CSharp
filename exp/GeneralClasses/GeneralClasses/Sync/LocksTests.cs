using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneralClasses.Sync
{
    public class LocksTests
    {

        private object _lock = new object();

        static void Main_()
        {
            LocksTests lt = new LocksTests();

            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }


        private LocksTests()
        {
            Task task1 = new Task(() => m1());
            task1.Start();
            Task task2 = new Task(() => m3());
            task2.Start();
        }

        private void m1()
        {
            Console.WriteLine("Trying 2 lock m1...");
            lock (_lock)
            {
                Console.WriteLine("\t\tm1");
                Thread.Sleep(2000);
                m2();
            }
            Console.WriteLine("...m1 unlocked.");
        }
        private void m2()
        {
            Console.WriteLine("Trying 2 lock m2...");
            lock (_lock)
            {
                Console.WriteLine("\t\tm2");
            }
            Console.WriteLine("...m2 unlocked.");
        }
        private void m3()
        {
            Console.WriteLine("Trying 2 lock m3...");
            lock (_lock)
            {
                Console.WriteLine("\t\tm3");
            }
            Console.WriteLine("...m3 unlocked.");
        }
    }
}
