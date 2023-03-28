using System;
using System.Threading;
using System.Runtime.InteropServices;

// Target a specific processor for the thread to run on


public class ThreadProcessor
{

    [DllImport("kernel32.dll")]

    static extern IntPtr GetCurrentThread();

    [DllImport("kernel32.dll")]

    static extern IntPtr SetThreadAffinityMask(IntPtr hThread, IntPtr dwThreadAffinityMask);



    public static void Usage()
    {

        int cpu = 0;

        ThreadProcessor tp = new ThreadProcessor();

        Console.WriteLine("Spike CPU 1");

        tp.SpikeCPU(cpu);



        if (tp._ex != null)
        {

            Console.WriteLine(tp._ex.Message);

        }

        else
        {



            if (Environment.ProcessorCount > 1)
            {

                while (++cpu < Environment.ProcessorCount)
                {

                    Thread.Sleep(1000);

                    Console.WriteLine("Spike CPU " + (cpu + 1).ToString());

                    tp.SpikeCPU(cpu);



                    if (tp._ex != null)
                    {

                        Console.WriteLine(tp._ex.Message);

                        break;

                    }

                }



            }

            else // Either a single CPU or hyperthreading not enabled in the OS or the BIOS.
            {

                Console.WriteLine("This PC does not have two processors available.");

            }

        }



    }



    private Thread _worker;

    private const int PiSignificantDigits = 750; // Adjust to your processor



    // Spike the CPU and waith for it to finish

    public void SpikeCPU(int targetCPU)
    {



        // Create a worker thread for the work.

        _worker = new Thread(DoBusyWork);



        // Background is set so not to not prevent the

        // mainprocess from terminating if someone closes it.

        _worker.IsBackground = true;



        _worker.Start((object)targetCPU);

        _worker.Join(); // Wait for it to be done.

    }





    public void DoBusyWork(object target)
    {

        try
        {

            int processor = (int)target;

            Thread tr = Thread.CurrentThread;



            if (Environment.ProcessorCount > 1)
            {

                SetThreadAffinityMask(GetCurrentThread(),

                    new IntPtr(1 << processor));

            }



            CalculatePI.Process(PiSignificantDigits);

        }

        catch (Exception ex)
        {

            _ex = ex;

        }



    }



    public Exception _ex = null;





}

