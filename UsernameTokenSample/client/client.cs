//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;

namespace Microsoft.ServiceModel.Samples.CustomToken
{
    //Client implementation code.
    class Client
    {
        static void Main()
        {
            ChannelFactory<IEchoService> channelFactory = null;
            IEchoService client = null;

            try
            {
                Binding userNameBinding = BindingHelper.userNameBinding();
                EndpointAddress serviceAddress = new EndpointAddress("http://localhost/servicemodelsamples/service.svc");

                // Create a client with given client endpoint configuration
                channelFactory = new ChannelFactory<IEchoService>(userNameBinding, serviceAddress);

                // configure the username credentials on the channel factory 
                UsernameClientCredentials credentials = new UsernameClientCredentials(new UsernameInfo("User1", "P@ssw0rd"));

                // replace ClientCredentials with UsernameClientCredentials
                channelFactory.Endpoint.Behaviors.Remove(typeof(ClientCredentials));
                channelFactory.Endpoint.Behaviors.Add(credentials);

                client = channelFactory.CreateChannel();

                Console.WriteLine("Echo service returned: {0}", client.Echo());

                ((IChannel)client).Close();
                channelFactory.Close();
            }
            catch (CommunicationException e)
            {
                Abort((IChannel)client, channelFactory);

                // if there is a fault then print it out
                FaultException fe = null;
                Exception tmp = e;
                while (tmp != null)
                {
                    fe = tmp as FaultException;
                    if (fe != null)
                    {
                        break;
                    }
                    tmp = tmp.InnerException;
                }
                if (fe != null)
                {
                    Console.WriteLine("The server sent back a fault: {0}", fe.CreateMessageFault().Reason.GetMatchingTranslation().Text);
                }
                else
                {
                    Console.WriteLine("The request failed with exception: {0}", e);
                }
            }
            catch (TimeoutException)
            {
                Abort((IChannel)client, channelFactory);
                Console.WriteLine("The request timed out");
            }
            catch (Exception e)
            {
                Abort((IChannel)client, channelFactory);
                Console.WriteLine("The request failed with unexpected exception: {0}", e);
            }

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }

        static void Abort(IChannel channel, ChannelFactory cf)
        {
            if (channel != null)
                channel.Abort();
            if (cf != null)
                cf.Abort();
        }
    }
}