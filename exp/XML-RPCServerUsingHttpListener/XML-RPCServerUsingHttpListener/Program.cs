using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Text;
using CookComputing.XmlRpc;

namespace XML_RPCServerUsingHttpListener
{
    class Server
    {
        static void Main(string[] args)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://127.0.0.1:11000/");
            listener.Start();

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                ListenerService svc = new StateNameService();
                svc.ProcessRequest(context);
            }
        }
    }
}
