using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new DelegateTest();

            new EventTest().OnPrintEvent();


            Console.ReadLine();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class DelegateTest
    {
        public delegate void Print(string val);
        public DelegateTest()
        {
            Print p = new Print(PrintValue);
            p += new Print(PrintData);
            p.Invoke("Test");
        }
        private void PrintData(string s)
        {
            Console.WriteLine("DelegateTest::PrintData" + s);
        }
        public void PrintValue(string s)
        {
            Console.WriteLine("DelegateTest::PrintValue" + s);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class EventTest
    {
        public delegate void Print(string val);
        public event Print PrintEvent;
        public EventTest()
        {
            this.PrintEvent += PrintData;
            this.PrintEvent += PrintValue;
        }
        public virtual void OnPrintEvent()
        {
            if (PrintEvent != null)
            {
                PrintEvent("Test");
            }
        }
        private void PrintData(string s)
        {
            Console.WriteLine("EventTest::PrintData" + s);
        }
        public void PrintValue(string s)
        {
            Console.WriteLine("EventTest::PrintValue" + s);
        }
    }
}
