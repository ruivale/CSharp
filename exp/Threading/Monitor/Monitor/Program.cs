using System;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Monitor
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] iSleepMillis = {120,350,145,220,300,178,199,234,890,234};
            CCTVMonitor[] CCTVMonitors = new CCTVMonitor[10];

            for(int i=0; i<CCTVMonitors.Length; i++)
            {
                CCTVMonitors[i] = new CCTVMonitor(i);
            }

            Console.WriteLine("Starting the Monitor tests. ThreadId: " + Thread.CurrentThread.ManagedThreadId+"\nPress ENTER/RETURN to exit...");

            for (int i = 0; i < CCTVMonitors.Length; i++)
            {
                CCTVMonitors[i].process(iSleepMillis[i], iSleepMillis[i]);
            }
            Console.ReadLine();
        }
    }
}
