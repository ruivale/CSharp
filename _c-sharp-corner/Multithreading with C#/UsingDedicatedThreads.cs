using System;
using System.Threading;

class UsingDedicatedThreads
{
    static void Main(string[] args)
    {
        // create thread start delegate instance - contains the method to execute by the thread
        ThreadStart ts = new ThreadStart(run);
        // create new thread
        Thread thrd = new Thread(ts);
        // start thread
        thrd.Start();

        // makes the main thread sleep - let sub thread to run
        Thread.Sleep(1000);

        for (int t = 10; t > 0; t--)
        {
            Console.WriteLine("Main Thread value is :" + t);
            Thread.Sleep(1000);
        }

        Console.WriteLine("Good Bye!!!I'm main Thread");
        Console.ReadLine();

    }

    // this method executed by a separate thread
    static void run()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Sub Thread value is : " + i);
            Thread.Sleep(1000);
        }
        Console.WriteLine("Good Bye!!!I'm Sub Thread");
    }
}
