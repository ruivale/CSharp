using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyConsoleAppsTests
{
    namespace EventsInCSharp
    {

        public class MyClass
        {

            public delegate void MyDelegate(string message);

            public event MyDelegate MyEvent;



            //this method will be used to raise the event.

            public void RaiseEvent(string message)
            {

                if (MyEvent != null)

                    MyEvent(message);

            }

        }

        class Program
        {

            static void Main_(string[] args)
            {

                MyClass myClass1 = new MyClass();

                myClass1.MyEvent += new MyClass.MyDelegate(myClass1_MyEvent);



                Console.WriteLine("Please enter a message\n");

                string msg = Console.ReadLine();



                //here is we raise the event.

                myClass1.RaiseEvent(msg);

                Console.Read();

            }

            //this method will be executed when the event raised.

            static void myClass1_MyEvent(string message)
            {

                Console.WriteLine("Your Message is: {0}", message);

            }

        }

    }

}
