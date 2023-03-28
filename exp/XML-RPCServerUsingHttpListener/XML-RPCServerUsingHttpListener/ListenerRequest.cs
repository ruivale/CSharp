using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;


namespace XML_RPCServerUsingHttpListener
{
    public class ListenerRequest : CookComputing.XmlRpc.IHttpRequest
    {
        public ListenerRequest(HttpListenerRequest request)
        {
            this.request = request;
        }

        public Stream InputStream
        {
            get { return request.InputStream; }
        }

        public string HttpMethod
        {
            get { return request.HttpMethod; }
        }

        private HttpListenerRequest request;
    }
}
