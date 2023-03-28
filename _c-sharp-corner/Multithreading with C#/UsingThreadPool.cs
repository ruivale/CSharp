using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // assign thread pool thread to do the job
        ThreadPool.QueueUserWorkItem(run, 10);

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

    /* this method executed by a separate thread
     * this sholud be match with the WaitCallback
     * (parameters must be passed as an object) 
     */
    static void run(object args)
    {
        // cast our parameter 
        int j = (int)args;

        for (int i = 0; i < j; i++)
        {
            Console.WriteLine("Sub Thread value is : " + i);
            Thread.Sleep(1000);
        }
        Console.WriteLine("Good Bye!!!I'm Sub Thread");
    }
}

