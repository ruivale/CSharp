using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyConsoleAppsTests
{
    namespace DelegatesAsynchronousCalls
    {

        class Program
        {

            public delegate int MyDelegate(int x);

            public class MyClass
            {

                //A method to be invoke by the delegate

                public int MyMethod(int x)
                {

                    //simulate a long running proccess

                    System.Threading.Thread.Sleep(5000);

                    return x * x;

                }

            }

            static void Main_(string[] args)
            {

                MyClass myClass1 = new MyClass();

                MyDelegate del = new MyDelegate(myClass1.MyMethod);

                //Invoke our method in another thread

                IAsyncResult async = del.BeginInvoke(5, null, null);

                //do something while MyMethod is executing.

                Console.WriteLine("Proccessing operation...");

                //recieve the results.

                int result = del.EndInvoke(async);

                Console.WriteLine("Result is: {0}", result);

                Console.ReadLine();

            }

        }

    }
}
