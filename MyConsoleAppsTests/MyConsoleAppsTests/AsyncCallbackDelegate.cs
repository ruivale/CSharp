using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Messaging;

namespace MyConsoleAppsTests
{
namespace AsyncCallbackDelegate

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

    class Program

    {

        static void Main_(string[] args)

        {

            MyClass myClass1 = new MyClass();

            MyDelegate del = new MyDelegate(myClass1.MyMethod);

            //Invoke our methe in another thread

            IAsyncResult async = del.BeginInvoke(5, new AsyncCallback(MyCallBack), "A message from the main thread");

            Console.WriteLine("Proccessing the Operation....");

            Console.ReadLine();

        }

        static void MyCallBack(IAsyncResult async)
        {

            AsyncResult ar = (AsyncResult)async;

            MyDelegate del = (MyDelegate)ar.AsyncDelegate;

            int x = del.EndInvoke(async);



            //make use of the state object.

            string msg = (string)async.AsyncState;

            Console.WriteLine("{0}, Result is: {1}", msg, x);

        }


    }

}
}
