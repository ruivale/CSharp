using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTaskEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Program2 p2 = new Program2();
            p2.ParallelTask();

            ParallelInvoke pt = new ParallelInvoke();
            //pt.CallAllTask();

            Program3 p3 = new Program3();
            //p3.PLINQEx();

            Program4 p4 = new Program4();
            //p4.ContinueWithExample();

            Console.Read();
        }
    }
}
