using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using Microsoft.Web.Services3.Security.Tokens;
using System.Xml;
using System.ServiceModel.Channels;


namespace InvokingWebServices
{
    /// <summary>
    /// 
    /// </summary>
    public class PasswordDigestMessageInspector : IClientMessageInspector {

        public string Username { get; set; } 
        public string Password { get; set; }  
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public PasswordDigestMessageInspector(string username, string password) 
        { 
            this.Username = username; 
            this.Password = password; 
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reply"></param>
        /// <param name="correlationState"></param>
        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)     
        {         
            //throw new NotImplementedException();     
        }  

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)    
        {
            // Use the WSE 3.0 security token class     
            UsernameToken token = new UsernameToken(this.Username, this.Password, PasswordOption.SendHashed);      
            
            // Serialize the token to XML     
            XmlElement securityToken = token.GetXml(new XmlDocument());      
            
            //
            MessageHeader securityHeader = 
                MessageHeader.CreateHeader("Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", securityToken, false);    
            request.Headers.Add(securityHeader);     

            // complete     
            return Convert.DBNull;
        }      
    } 
}
