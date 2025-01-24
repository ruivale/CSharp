
using Com.Efacec.ES.TRP.Efarail.Cctv.Grpc.Operation.Services;
using Com.Efacec.ES.TRP.Efarail.Cctv.Grpc;
using Com.Efacec.ES.TRP.Efarail.Cctv.Grpc.Messages.v1;
using Com.Efacec.ES.TRP.Efarail.Cctv.Grpc.Enums.v1;
using Grpc.Net.Client;
using System.Threading.Channels;
using Google.Protobuf.WellKnownTypes;


namespace TestInossCctvSaRPC.Client
{
    public class CctvClient
    {

        static readonly string _protocol = "https://";
        static readonly string _host = "localhost";
        static readonly int _portOper = 5555;
        static readonly int _portConfig = 5556;

        static readonly int _millisToWaitForChannelShutdown = 5000;



        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void _Main(string[] args)
        {

            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portOper); // https://localhost:5555

            // Create a client for the Operation service
            var client = new Operation.OperationClient(channel);

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
                // Call the GetVersions RPC method
                ListCctvVersionsResponse response = client.GetVersions(versionsRequest);

                // Display the response
                Console.WriteLine("Response Status: " + response.Response.ResponseValue);
                Console.WriteLine("Description: " + response.Response.Desc);

                foreach (var version in response.CctvVersions)
                {
                    Console.WriteLine($"Module: {version.VersionMod}, Version: {version.Version}.{version.SubVersion}.{version.Revision}.{version.Build}");
                }

                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="versionsRequest"></param>
        /// <returns></returns>
        public ListCctvVersionsResponse GetVersions(VersionsRequest versionsRequest)
        {
            ListCctvVersionsResponse response;

            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portOper); // https://localhost:5555

            // Create a client for the Operation service
            var client = new Operation.OperationClient(channel);

            try
            {
                // Call the GetVersions RPC method
                response = client.GetVersions(versionsRequest);

                // Display the response
                Console.WriteLine("Response Status: " + response.Response.ResponseValue);
                Console.WriteLine("Description: " + response.Response.Desc);

                foreach (var version in response.CctvVersions)
                {
                    Console.WriteLine($"Module: {version.VersionMod}, Version: {version.Version}.{version.SubVersion}.{version.Revision}.{version.Build}");
                }

                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                response = new ListCctvVersionsResponse
                {
                    Response = new Response
                    {
                        ResponseValue = ResponseValue.RError,
                        Desc = ex.Message
                    }
                };
            }

            return response;
        }
    }
}