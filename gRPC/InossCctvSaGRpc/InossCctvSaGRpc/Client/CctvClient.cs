using Com.Efacec.ES.TRP.Efarail.Cctv.Grpc.v1;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InossCctvSaGRpc
{
    public class CctvClient
    {

        static readonly string _protocol = "http://";
        static readonly string _host = "localhost";
        static readonly int _portOper = 5555;
        static readonly int _portConfig = 5556;

        static readonly int _millisToWaitForChannelShutdown = 5000;



        /// <summary>
        /// 250124
        ///     Obtain the Operation service version
        ///     TAO IDL:
        ///         rpc GetVersions(VersionsRequest) returns(ListCctvVersionsResponse);
        ///         
        /// </summary>
        /// <param name="versionsRequest"></param>
        /// <returns></returns>
        public void GetVersions()
        {

            Console.WriteLine("CctvClient.GetVersions()...");

            ListCctvVersionsResponse response;

            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portOper); // https://localhost:5555
            Console.WriteLine($"CctvClient.GetVersions() - GrpcChannel({_protocol}{_host}:{_portOper}) created.");

            // Create a client for the Operation service
            var client = new Operation.OperationClient(channel);
            Console.WriteLine("CctvClient.GetVersions() - Operation.OperationClient(channel) created.");

            // Create a VersionsRequest message
            var versionsRequest = new VersionsRequest
            {
                WorkstationInfo = new WorkstationInformation
                {
                    Id = 11,
                    UserName = "inoss"
                },
                VersionMod = VersionMod.VermodAll
            };

            try
            {
                Console.WriteLine("CctvClient.GetVersions() - Will call server GetVersions(..).");
                // Call the GetVersions RPC method
                response = client.GetVersions(versionsRequest);

                // Display the response
                Console.WriteLine("\tResponse status: " + response.Response.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.Response.Desc);

                foreach (var version in response.CctvVersions)
                {
                    Console.WriteLine($"\tModule: {version.VersionMod}, Version: {version.Version}.{version.SubVersion}.{version.Revision}.{version.Build}");
                }

                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}");
            }

            Console.WriteLine("CctvClient.GetVersions()...");
        }
    }
}
