/* 
 * Copyright (c) 2006 C-Lab. All Rights Reserved. 
 * 
 * This software is the confidential and proprietary information. 
 * It shall be distributed only in accordance with C-Lab. 
 * 
 * C-LAB MAKES NO REPRESENTATIONS OR WARRANTIES ABOUT THE SUITABILITY OF THE 
 * SOFTWARE, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE 
 * IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
 * PURPOSE, OR NON-INFRINGEMENT. C-LAB SHALL NOT BE LIABLE FOR ANY DAMAGES 
 * SUFFERED BY LICENSEE AS A RESULT OF USING, MODIFYING OR DISTRIBUTING 
 * THIS SOFTWARE OR ITS DERIVATIVES. 
 */
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Nwc.XmlRpc;

namespace SiemensBusinessServicesSample
{
    class ObjectClient
    {
        static string server_url = "http://127.0.01:9117";
        static void _Main(string[] args)
        {
            int maxMethodCall = 500;
            DateTime t1;
            DateTime t2;
            XmlRpcRequest client = new XmlRpcRequest();
            XmlRpcResponse response;
            if (args.Length > 0)
            {
                maxMethodCall = Int32.Parse(args[0]);
            }
            Console.WriteLine("==========Send objects - 2 input parameters - started==========");
            Console.WriteLine("Count of the method calls: " + maxMethodCall);
            t1 = DateTime.Now;
            for (int i = 0; i < maxMethodCall; i++)
            {
                client.MethodName = "container.add";
                client.Params.Clear();
                client.Params.Add(i.ToString() + "_m1");
                client.Params.Add(DateTime.Now);
                response = client.Send(server_url);
                //Console.WriteLine(response.Value); 
            }
            t2 = DateTime.Now;
            Console.WriteLine("==========Send objects - 2 input parameters - finished==========");
            Console.WriteLine("Total time = " + (t2 - t1) + "msec");
            Console.WriteLine("==========Send objects - 6 input parameters - started==========");
            Console.WriteLine("Count of the method calls: " + maxMethodCall);
            t1 = DateTime.Now;
            for (int i = 0; i < maxMethodCall; i++)
            {
                client.MethodName = "container.add";
                client.Params.Clear();
                client.Params.Add(i.ToString() + "_m2");
                client.Params.Add(i);
                client.Params.Add((Double)i);
                client.Params.Add(i.ToString());
                ArrayList l = new ArrayList();
                l.Add(i.ToString());
                l.Add(i + 1);
                client.Params.Add(l);
                Hashtable t = new Hashtable();
                t.Add(i.ToString(), i.ToString());
                Int32 j = i + 1;
                t.Add(j.ToString(), j);
                client.Params.Add(t);
                response = client.Send(server_url);
                //Console.WriteLine(response.Value); 
            }
            t2 = DateTime.Now;
            Console.WriteLine("==========Send objects - 6 input parameters - finished==========");
            Console.WriteLine("Total time = " + (t2 - t1) + "msec");
            Console.WriteLine("==========Send objects - 1 input parameter - started==========");
            Console.WriteLine("Count of the method calls: " + maxMethodCall);
            t1 = DateTime.Now;

            for (int i = 0; i < maxMethodCall; i++)
            {
                client.MethodName = "container.get";
                client.Params.Clear();
                client.Params.Add(i.ToString() + "_m1");
                response = client.Send(server_url);
                //Console.WriteLine(response.Value); 
            }

            t2 = DateTime.Now;
            Console.WriteLine("==========Send objects - 1 input parameter - finished==========");
            Console.WriteLine("Total time = " + (t2 - t1) + "msec");
        }
    }
}