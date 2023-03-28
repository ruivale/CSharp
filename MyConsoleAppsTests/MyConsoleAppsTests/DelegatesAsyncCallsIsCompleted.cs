using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyConsoleAppsTests
{
    namespace DelegatesAsyncCallsIsCompleted
    {

        public delegate int MyDelegate(int x);

        public class MyClass
        {

            //A method to be invoke by the delegate

            public int MyMethod(int x)
            {

                //simulate a long running proccess

                System.Threading.Thread.Sleep(3000);

                return x * x;

            }

        }

        class Program
        {

            static void Main_(string[] args)
            {

                MyClass myClass1 = new MyClass();

                MyDelegate del = new MyDelegate(myClass1.MyMethod);

                //Invoke our methe in another thread

                IAsyncResult async = del.BeginInvoke(5, null, null);



                //loop until the method is complete

                while (!async.IsCompleted)
                {

                    Console.WriteLine("Not Completed");
                    System.Threading.Thread.Sleep(250);

                }

                int result = del.EndInvoke(async);

                Console.WriteLine("Result is: {0}", result);

                Console.ReadLine();

            }

        }

    }
}
