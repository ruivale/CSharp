using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using CookComputing.XmlRpc;

namespace XML_RPCServerUsingHttpListener
{
    public class ListenerResponse : CookComputing.XmlRpc.IHttpResponse
    {

        public ListenerResponse(HttpListenerResponse response)
        {
            this.response = response;
        }

        string IHttpResponse.ContentType
        {
            get { return response.ContentType; }
            set { response.ContentType = value; }
        }

        TextWriter IHttpResponse.Output
        {
            get { return new StreamWriter(response.OutputStream); }
        }

        Stream IHttpResponse.OutputStream
        {
            get { return response.OutputStream; }
        }

        int IHttpResponse.StatusCode
        {
            get { return response.StatusCode; }
            set { response.StatusCode = value; }
        }

        string IHttpResponse.StatusDescription
        {
            get { return response.StatusDescription; }
            set { response.StatusDescription = value; }
        }

        long ContentLength
        {
            set;
        }

        bool SendChunked { get; set; }


        private HttpListenerResponse response;
    }
}
