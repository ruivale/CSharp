using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GeneralClasses.Collections
{
    class DictionaryTests
    {
        static void Main_()
        {

            Dictionary<int, string> dic = new Dictionary<int, string>();

            dic[1] = "One";
            dic.Add(2, "two");

            Console.WriteLine("Dic: ");
            dic.Keys.ToList().ForEach(k => Console.WriteLine("\t" + k + ": " + dic[k]));


            Console.WriteLine("\nPress ENTER to exit...");
            Console.ReadLine();
        }
        static void Main__()
        {

            List<int> list = new List<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            Console.WriteLine("\nDic: ");
            list.ForEach(k => Console.WriteLine("\t" + k + ": "));

            List<int> list2 = list.TakeWhile(k => k < 2).ToList<int>();
            Console.WriteLine("\nDic list: ");
            list2.ForEach(k => Console.WriteLine("\t" + k + ": "));

            List<int> list3 = list.SkipWhile(k => k < 2).ToList<int>();
            Console.WriteLine("\nDic list: ");
            list3.ForEach(k => Console.WriteLine("\t" + k + ": "));


            Console.WriteLine("\nPress ENTER to exit...");
            Console.ReadLine();
        }

        static void _Main()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.AutoReset = false;
            timer.Interval = 2500;
            timer.Elapsed += OnTimerRequest;
            timer.Enabled = true;

            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }
        private static int nTimerExec = 0;
        private static Object LOCK = new Object();
        public static void OnTimerRequest(Object sender, System.Timers.ElapsedEventArgs e)
        {

            if (Monitor.TryEnter(LOCK))
            {
                Console.WriteLine("OnTimerRequest ENTER ... " + DateTime.Now);

                try
                {
                    if (nTimerExec++ % 3 == 0)
                    {
                        int nMillis = 5470;
                        Console.WriteLine("\tOnTimerRequest WILL SLEEP... " + DateTime.Now + " -> " + DateTime.Now.AddMilliseconds(nMillis));
                        Thread.Sleep(nMillis);
                    }
                    else
                    {
                        Console.WriteLine("OnTimerRequest " + DateTime.Now);
                    }
                }
                finally
                {
                    Monitor.Exit(LOCK);
                }
            }
            else
            {
                Console.WriteLine("OnTimerRequest ENTER DENIED... " + DateTime.Now);
            }
        }
    }
}
