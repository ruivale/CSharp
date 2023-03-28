using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;
using Nwc.XmlRpc;

namespace AnXMLRPCPackageForDotNetServer
{

    class SampleServer
    {
        const int PORT = 5050;

        /// <summary>
        /// Simple logging to Console.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="type"></param>
        static public void WriteEntry(String msg, EventLogEntryType type)
        {
            if (type != EventLogEntryType.Information) // ignore debug msgs
                Console.WriteLine("{0}: {1}", type, msg);
        }

        /// Application starts here.
        public static void Main()
        {
            // Use the console logger above.
            Logger.Delegate = new Logger.LoggerDelegate(WriteEntry);

            XmlRpcServer server = new XmlRpcServer(PORT);
            server.Add("sample", new SampleServer());
            Console.WriteLine("Web Server Running on port {0} ... Press ^C to Stop...", PORT);
            server.Start();
        }

        /// <summary>
        /// A method that returns the current time.
        /// </summary>
        /// <returns></returns>
        public DateTime Ping()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// A method that echos back it's arguement.
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public String Echo(String arg)
        {
            return arg;
        }

        /// <summary>
        /// Method that returns the sum of both given ints.
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        public int Add(int i1, int i2)
        {
            return i1 + i2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        public AddingInfo GetAddingInfo(int i1, int i2)
        {
            return new AddingInfo(i1, i2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public int AddAllValues(int[] values)
        {
            int sum = 0;

            foreach(int value in values)
                sum += value;

            return sum;
        }

        /// <summary>
        /// Method that returns the sum of the AddingInfo two ints.
        /// </summary>
        /// <param name="ai"></param>
        /// <returns></returns>
        public int AddValues(AddingInfo ai)
        {
            return ai.FirstValue + ai.SecondValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        public Boolean AreIntValuesDifferent(int i1, int i2)
        {
            return i1 != i2;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        public Boolean AreLongValuesDifferent(long l1, long l2)
        {
            return l1 != l2;
        }
    }
}
