using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyConsoleAppsTests
{
    namespace MicrosoftEventPattern
    {

        public class MyClass
        {

            public delegate void MyDelegate(object sender, MyEventArgs e);

            public event MyDelegate MyEvent;



            public class MyEventArgs : EventArgs
            {

                public readonly string message;

                public MyEventArgs(string message)
                {

                    this.message = message;

                }

            }

            //this method will be used to raise the event.

            public void RaiseEvent(string msg)
            {

                if (MyEvent != null)

                    MyEvent(this, new MyClass.MyEventArgs(msg));

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

            static void myClass1_MyEvent(object sender, MyClass.MyEventArgs e)
            {

                if (sender is MyClass)
                {

                    MyClass myClass = (MyClass)sender;

                    Console.WriteLine("Your Message is: {0}", e.message);

                }

            }

        }

    }
}
