using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;
using Nwc.XmlRpc;

namespace AnXMLRPCPackageForDotNetClient
{
    class SampleClient
    {

        /// <summary>Simple logging to Console.</summary>
        static public void WriteEntry(String msg, EventLogEntryType type)
        {
            if (type != EventLogEntryType.Information) // ignore debug msgs
                Console.WriteLine("{0}: {1}", type, msg);
        }

        /// Series of calls to the sample server.
        public static void Main()
        {
            XmlRpcResponse response;

            // Use the console logger above.
            Logger.Delegate = new Logger.LoggerDelegate(WriteEntry);


            // Send the sample.Ping RPC
            XmlRpcRequest client = new XmlRpcRequest();
            //client.MethodName = "sample.Ping";
            ////Console.WriteLine(client);
            //response = client.Send("http://127.0.0.1:5050");
            //if (response.IsFault)
            //    Console.WriteLine("Fault {0}: {1}", response.FaultCode, response.FaultString);
            //else
            //    Console.WriteLine("Ping - Response: " + response.Value);

            Console.WriteLine("---------------------------------------------------------------------------------");



            //// Send the sample.Echo RPC
            //client.MethodName = "sample.Echo";
            //client.Params.Clear();
            //client.Params.Add("Hello");
            //Console.WriteLine(client);
            //response = client.Send("http://127.0.0.1:5050");
            //if (response.IsFault)
            //    Console.WriteLine("Fault {0}: {1}", response.FaultCode, response.FaultString);
            //else
            //{
            //    Console.WriteLine("Echo - Response: " + response.Value);
            //    Console.WriteLine(response);
            //    Console.WriteLine();
            //}


            Console.WriteLine("---------------------------------------------------------------------------------");


            //// Send the sample.Add RPC
            //client.MethodName = "sample.Add";
            //client.Params.Clear();
            //client.Params.Add(9);
            //client.Params.Add(6);
            ////Console.WriteLine(client);
            //response = client.Send("http://127.0.0.1:5050");
            //if (response.IsFault)
            //    Console.WriteLine("Fault {0}: {1}", response.FaultCode, response.FaultString);
            //else
            //    Console.WriteLine("Add - Response: " + response.Value);

            Console.WriteLine("---------------------------------------------------------------------------------");


            //// Send the sample.Add RPC
            //client.MethodName = "sample.AddValues";
            //client.Params.Clear();
            //AddingInfo ai = new AddingInfo(9, 6);
            //client.Params.Add(ai);
            //Console.WriteLine(client);
            //response = client.Send("http://127.0.0.1:5050");
            //if (response.IsFault)
            //    Console.WriteLine("Fault {0}: {1}", response.FaultCode, response.FaultString);
            //else
            //    Console.WriteLine("AddValues(" + ai.ToString() + ") - Response: " + response.Value);


            Console.WriteLine("---------------------------------------------------------------------------------");


            //// Send the sample.Add RPC
            //client.MethodName = "sample.GetAddingInfo";
            //client.Params.Clear();
            //int i1 = 9;
            //int i2 = 6;
            //client.Params.Add(i1);
            //client.Params.Add(i2);
            ////Console.WriteLine(client);
            //response = client.Send("http://127.0.0.1:5050");
            //if (response.IsFault)
            //    Console.WriteLine("Fault {0}: {1}", response.FaultCode, response.FaultString);
            //else
            //{
            //    AddingInfo ai = (AddingInfo)response.Value;
            //    Console.WriteLine("GetAddingInfo({0},{1}) - Response: {2}", i1, i2, ai.ToString());
            //}


            

            Console.WriteLine("---------------------------------------------------------------------------------");


            ////// Send the sample.Add RPC
            //client.MethodName = "sample.AddAllValues";
            //client.Params.Clear();
            //int[] values = {1, 2, 3, 4, 5};
            //client.Params.Add(values);
            //Console.WriteLine(client);
            //response = client.Send("http://127.0.0.1:5050");
            //if (response.IsFault)
            //    Console.WriteLine("Fault {0}: {1}", response.FaultCode, response.FaultString);
            //else
            //    Console.WriteLine("AddAllValues() - Response: " + response.Value);

            //Console.WriteLine("---------------------------------------------------------------------------------");


            ////// Send the sample.Add RPC
            //client.MethodName = "sample.AreIntValuesDifferent";
            //client.Params.Clear();
            //int i1 = 9;
            //int i2 = 6;
            //client.Params.Add(i1);
            //client.Params.Add(i2);
            //Console.WriteLine(client);
            //response = client.Send("http://127.0.0.1:5050");
            //if (response.IsFault)
            //    Console.WriteLine("Fault {0}: {1}", response.FaultCode, response.FaultString);
            //else
            //    Console.WriteLine("AreIntValuesDifferent({0},{1}) - Response: {2}", i1, i2, response.Value);

            //Console.WriteLine("---------------------------------------------------------------------------------");

            ////// Send the sample.Add RPC
            //client.MethodName = "sample.AreLongValuesDifferent";
            //client.Params.Clear();
            //long l1 = 9999999999999;
            //long l2 = 6666666666666;
            //client.Params.Add(l1);
            //client.Params.Add(l2);
            //Console.WriteLine(client);
            //response = client.Send("http://127.0.0.1:5050");
            //if (response.IsFault)
            //    Console.WriteLine("Fault {0}: {1}", response.FaultCode, response.FaultString);
            //else
            //    Console.WriteLine("AreLongValuesDifferent({0},{1}) - Response: {2}", l1, l2, response.Value);


            //// Send the sample.Broken RPC
            //client.MethodName = "sample.Broken";
            //client.Params.Clear();
            //response = client.Send("http://127.0.0.1:5050");
            //if (response.IsFault)
            //    Console.WriteLine("Fault {0}: {1}", response.FaultCode, response.FaultString);
            //else
            //    Console.WriteLine("Broken - Response: " + response.Value);




            Console.ReadKey();
        }
    }
}
