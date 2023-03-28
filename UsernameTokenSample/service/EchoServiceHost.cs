//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;

namespace Microsoft.ServiceModel.Samples.CustomToken
{
    public class EchoServiceHostFactory : ServiceHostFactoryBase
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            return new EchoServiceHost(baseAddresses);
        }
    }
	
    class EchoServiceHost : ServiceHost
    {
        public EchoServiceHost(params Uri[] addresses)
            : base(typeof(EchoService), addresses)
	{
	}

        override protected void InitializeRuntime()
        {
            // create an instance of UsernameServiceCredentials and add it to the behaviors
            // also add here the password provider
            UsernameServiceCredentials serviceCredentials = new UsernameServiceCredentials(new UsernamePasswordProvider());
            this.Description.Behaviors.Remove((typeof(ServiceCredentials)));
            this.Description.Behaviors.Add(serviceCredentials);

            // register a username binding for the endpoint.
            Binding usernameBinding = BindingHelper.userNameBinding();
            this.AddServiceEndpoint(typeof(IEchoService), usernameBinding, string.Empty);

            base.InitializeRuntime();
        }
    }
}
