using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneralClasses.Tasks
{
    class TasksAndExceptions
    {
        private Task taskStartAvlsAgent;

        static void _Main()
        {
            TasksAndExceptions tae = new TasksAndExceptions();


            try
            {
                tae.StartSync("StartSync", 5000);
            }
            catch (Exception e)
            {
                Console.WriteLine("Main(): MainT(" + Thread.CurrentThread.ManagedThreadId + ") StartSync Exception: " + e.Message);
            }


            //try
            //{
            //    tae.StartAsync();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("MainT(" + Thread.CurrentThread.ManagedThreadId + ") StartAsync Exception: " + e.Message);
            //}


            Console.WriteLine("Main(): MainT(" + Thread.CurrentThread.ManagedThreadId + "): ...exiting! Press ENTER to exit.");
            Console.ReadLine();
        }


        public void StartAsync()
        {
            this.taskStartAvlsAgent = Start();
        }

        public void StartSync(String str, int nTimeOut)
        {
            this.taskStartAvlsAgent = Start(str);

            try
            {
                this.taskStartAvlsAgent.Wait(nTimeOut);
            }
            catch (AggregateException ae)
            {
                foreach (Exception exception in ae.InnerExceptions)
                {

                    Console.WriteLine("AggregateException: MainT(" + Thread.CurrentThread.ManagedThreadId + ") StartSync Exception: " + exception.Message);

                    if (!(exception is TaskCanceledException))
                    {
                        // If it's any other kind of exception, re-throw it.
                        throw exception;
                    }
                }
            }
        }

        private Task Start()
        {
            return Start(null /* no Document*/);
        }
        private Task Start(String str)
        {
            // Create a cancellation token source and obtain a cancellation token.
            //CancellationTokenSource cts = new CancellationTokenSource();
            //CancellationToken ct = cts.Token;
            Task taskStartSync = new Task(() => StartAvls(str)/*, ct*/);
            taskStartSync.Start();

            return taskStartSync;
        }

        private void StartAvls(String str)
        {
            Thread.Sleep(3000);

            if (str != null)
            {
                Console.WriteLine("TaskT(" + Thread.CurrentThread.ManagedThreadId + ") String: " + str + ".");
            }

            throw new Exception("******* TaskT(" + Thread.CurrentThread.ManagedThreadId + ") EXCEPTION. String: " + str + ".*******");
        }
    }
}
