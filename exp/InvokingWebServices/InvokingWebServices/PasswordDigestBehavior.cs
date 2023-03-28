using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
//using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;


namespace InvokingWebServices
{
    public class PasswordDigestBehavior : IEndpointBehavior 
    {   
        public string Username { get; set; }     
        public string Password { get; set; }      
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public PasswordDigestBehavior(string username, string password)     
        {         
            this.Username = username;         
            this.Password = password;     
        } 
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="bindingParameters"></param>
        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)     
        {         
            //throw new NotImplementedException();     
        }      
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="clientRuntime"></param>
        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)     
        {         
            clientRuntime.MessageInspectors.Add(new PasswordDigestMessageInspector(this.Username, this.Password));     
        }      
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="endpointDispatcher"></param>
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)     
        {         
            //throw new NotImplementedException();     
        }      
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        public void Validate(ServiceEndpoint endpoint)     
        {         
            //throw new NotImplementedException();     
        }
      
    } 
}
