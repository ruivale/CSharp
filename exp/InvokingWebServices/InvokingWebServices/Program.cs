using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Discovery;


namespace InvokingWebServices
{
    class Program
    {
        static void Main_(string[] args)
        {
            var endPoint = new UdpDiscoveryEndpoint(DiscoveryVersion.WSDiscoveryApril2005);

            var discoveryClient = new DiscoveryClient(endPoint);

            discoveryClient.FindProgressChanged += discoveryClient_FindProgressChanged;
            discoveryClient.FindCompleted += discoveryClient_FindCompleted;

            FindCriteria findCriteria = new FindCriteria();
            findCriteria.Duration = TimeSpan.MaxValue;
            findCriteria.MaxResults = int.MaxValue;

            Console.WriteLine("\nSearching (remember to switch off the firewall) ...");
            while (true)
            {
                discoveryClient.FindAsync(findCriteria);
                Console.WriteLine("Press any key to find again...");
                Console.ReadKey();
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("Searching ...");
            }
        }

        static void discoveryClient_FindCompleted(object sender, FindCompletedEventArgs e)
        {
            Console.WriteLine("FindCompleted - " + ((System.ServiceModel.Discovery.DiscoveryClient)sender).Endpoint.Name + ", " + e.Result);
        }


        static void discoveryClient_FindProgressChanged(object sender, FindProgressChangedEventArgs e)
        {
            Console.WriteLine();
            //Check endpoint metadata here for required types.
            List<Uri> listUris = e.EndpointDiscoveryMetadata.ListenUris.ToList();
            foreach (Uri uri in listUris)
            {
                Console.WriteLine(uri.ToString());
            }


            Console.WriteLine("FindProgressChanged - "+((System.ServiceModel.Discovery.DiscoveryClient)sender).Endpoint.Name+", "+e);
        }
    }
}
