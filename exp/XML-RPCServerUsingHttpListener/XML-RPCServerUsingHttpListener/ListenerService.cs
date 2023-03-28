using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using CookComputing.XmlRpc;

namespace XML_RPCServerUsingHttpListener
{
    public abstract class ListenerService : XmlRpcHttpServerProtocol
    {
        public virtual void ProcessRequest(HttpListenerContext RequestContext)
        {
            try
            {
                IHttpRequest req = new ListenerRequest(RequestContext.Request);
                IHttpResponse resp = new ListenerResponse(RequestContext.Response);
                HandleHttpRequest(req, resp);
                RequestContext.Response.OutputStream.Close();
            }
            catch (Exception ex)
            {
                // "Internal server error"
                RequestContext.Response.StatusCode = 500;
                RequestContext.Response.StatusDescription = ex.Message;
            }
        }
    }
}
