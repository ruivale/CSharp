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
using System.Diagnostics;
using System.Text;
using Nwc.XmlRpc;

namespace SiemensBusinessServicesSample
{
    class ObjectServer : XmlRpcServer
    {
        const int PORT = 9118;

        public ObjectServer()
            : base(PORT)
        {
        }
        public ObjectServer(int port)
            : base(port)
        {
        }
        /// <summary>Simple logging to Console.</summary> 
        static public void WriteEntry(String msg, LogLevel type)
        {
            if (type != LogLevel.Information)
            { // ignore debug msgs 
                Console.WriteLine("{0}: {1}", type, msg);
            }
        }
        /// Application starts here. 
        public static void Main(string[] args)
        {
            // Use the console logger above. 
            Logger.Delegate = new Logger.LoggerDelegate(WriteEntry);
            ObjectServer server = new ObjectServer(PORT);


            server.Add("container", new ObjectServer());
            //server.Add("container", new ObjectContainer());


            Console.WriteLine("Web Server Running on port {0} ... Press ^C to Stop...", PORT);
            server.Start();
        }
    }
}
