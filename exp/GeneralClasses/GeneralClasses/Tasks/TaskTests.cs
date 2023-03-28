using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneralClasses
{
    class TaskTests
    {
        static void _Main()
        {

            // Create a cancellation token source and obtain a cancellation token.
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;
            // Create and start a long-running task.
            Task task = new Task(() => doWork(/*cts*/), ct);
            task.Start();
            // Cancel the task.
            //cts.Cancel();
            // Handle the TaskCanceledException.
            try
            {
                task.Wait();
            }
            catch (AggregateException ae)
            {
                Console.WriteLine("\nEXCEPTION: "+ae.Message+"\n");

                foreach (var inner in ae.InnerExceptions)
                {
                    if (inner is TaskCanceledException)
                    {
                        Console.WriteLine("\t\tException: The task was cancelled.");
                    }
                    else
                    {
                        // If it's any other kind of exception, re-throw it.
                        //throw new Exception("NEW EXCEPTION");
                        Console.WriteLine("\t\t\tEXCEPTION: " + inner.Message + "\n");
                    }
                }
            }
            Console.WriteLine("MainT(" + Thread.CurrentThread.ManagedThreadId + "): ...exiting! Press ENTER to exit.");
            Console.ReadLine();


            //try
            //{
            //    Task taskStartSync = new Task(() =>
            //    {
            //        Console.WriteLine("Task(" + Thread.CurrentThread.ManagedThreadId + "): started. Press ENTER to continue...");
            //        Console.ReadLine();
            //        Console.WriteLine("Task(" + Thread.CurrentThread.ManagedThreadId + "): ...task terminating.");

            //        throw new Exception("EXCEPTION: in task...");
            //    });
            //    Console.WriteLine("MainT(" + Thread.CurrentThread.ManagedThreadId + "): Task will be started...");
            //    taskStartSync.Start();
            //    Console.WriteLine("MainT(" + Thread.CurrentThread.ManagedThreadId + "): We'll wait for the task to terminate...");
            //    taskStartSync.Wait(5000);
            //    Console.WriteLine("MainT(" + Thread.CurrentThread.ManagedThreadId + "): ...exiting! Press ENTER to exit.");
            //    Console.ReadLine();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("exception in MainT: " + e.Message);
            //}
        }

        // Method run by the task.
        private static void doWork(/*CancellationTokenSource cts*/)
        {
            Console.WriteLine("Task(" + Thread.CurrentThread.ManagedThreadId + "): started. Sleep 4 4 secs......");
            //Console.ReadLine();
            Thread.Sleep(4000);
            Console.WriteLine("Task(" + Thread.CurrentThread.ManagedThreadId + "): ...task terminating.");

            //cts.Cancel();

            //cts.Token.ThrowIfCancellationRequested();

            throw new Exception("EXCEPTION: in task...");


            //for (int i = 0; i < 100; i++)
            //{
            //    Thread.SpinWait(500000);
            //    // Throw an OperationCanceledException if cancellation was requested.
            //    token.ThrowIfCancellationRequested();
            //}
        }
    }
}
