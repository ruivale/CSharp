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
        static readonly string _host = "172.19.181.215";
//        static readonly string _host = "localhost";
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
                Console.WriteLine("CctvClient.GetVersions() - Will call server Operation.GetVersions(..).");
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


        /// <summary>
        /// 
        /// </summary>
        public void GetAllEquipments()
        {

            Console.WriteLine("CctvClient.GetAllEquipments()...");

            ListEquipmentsResponse listEquipmentsResponse;

            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portConfig); // https://localhost:5556
            Console.WriteLine($"CctvClient.GetAllEquipments() - GrpcChannel({_protocol}{_host}:{_portConfig}) created.");

            // Create a client for the Configuration service
            var client = new Configuration.ConfigurationClient(channel);
            Console.WriteLine("CctvClient.GetAllEquipments() - Configuration.ConfigurationClient(channel) created.");


            // Create a VersionsRequest message
            var listIdsRequest = new ListIds
            {
                WorkstationInfo = new WorkstationInformation
                {
                    Id = 11,
                    UserName = "inoss"
                },
                // empty list of Ids
                //Ids = {-1}
                // station: 130000 (Sobral de Ceira)
                Ids = { 129000, 130000, 131000, 132000 }
                //Ids = { }
            };

            //listIdsRequest.Ids.Clear(); 

            try
            {
                Console.WriteLine("CctvClient.GetAllEquipments() - Will call server Configuration.GetVersGetAllEquipmentsions(..).");
                // Call the GetVersions RPC method
                listEquipmentsResponse = client.GetAllEquipments(listIdsRequest);

                // Display the response
                Console.WriteLine("\tResponse status: " + listEquipmentsResponse.Response.ResponseValue);
                Console.WriteLine("\tResponse description: " + listEquipmentsResponse.Response.Desc);

                foreach (var equip in listEquipmentsResponse.Equipments)
                {
                    Console.WriteLine($"\t\tEquipment: {equip.Id}, Name: {equip.Name}, Station: {equip.StationId}, " +
                                      $"Type: {equip.Type}, Enabled?: {equip.Enabled}, CommSettings: {equip.CommSettings}, " +
                                      $"GenState: {equip.GenericState}, SpecState: {equip.SpecificState}, " +
                                      $"GenConf: {equip.GenericConfig}, SpecConf: {equip.SpecificConfig}, " +
                                      $"BoxId: {equip.BoxId}");

                    //Console.WriteLine($"\tEquipment: {equip.Id}, Name: {equip.Name}, Station: {equip.StationId}");
                }

                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}");
            }


            Console.WriteLine("...CctvClient.GetAllEquipments()");
        }


        /// <summary>
        /// Used to obtain all the network data: agent, stations, equipment classes, equipment types and equipments.
        /// If the given ListIds has no ids set, it means all configured agent information should be returned.
        ///
        /// NOTE: THIS IS NOT RELATED WITH THE GUI/GI STV DATABASE TABLES (T_IG_*).
        ///
        /// TAO IDL:
        ///    - int getAgentConfigByID(int ID, AgentConfigStv_Holder, listStationsHolder, listEquipClassesHolder, listEquipTypesConfHolder, listEquipsConfHolder, lastUpdated);
        ///     rpc GetAgentNetworkConfigById(ListIds) returns(CctvConfigResponse);
        /// </summary>
        public void GetAgentNetworkConfigById()
        {

            Console.WriteLine("CctvClient.GetAgentNetworkConfigById()...");

            CctvConfigResponse cctvConfigResponse;

            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portConfig); // https://localhost:5556
            Console.WriteLine($"CctvClient.GetAgentNetworkConfigById() - GrpcChannel({_protocol}{_host}:{_portConfig}) created.");

            // Create a client for the Configuration service
            var client = new Configuration.ConfigurationClient(channel);
            Console.WriteLine("CctvClient.GetAgentNetworkConfigById() - Configuration.ConfigurationClient(channel) created.");


            // Create a VersionsRequest message
            var listIdsRequest = new ListIds
            {
                WorkstationInfo = new WorkstationInformation
                {
                    Id = 11,
                    UserName = "inoss"
                },
                // empty list of Ids
                //Ids = {-1}
                // Agent: 100211
                Ids = { 100211 }
                //Ids = { }
            };

            //listIdsRequest.Ids.Clear(); 

            try
            {
                Console.WriteLine("CctvClient.GetAgentNetworkConfigById() - Will call server Configuration.GetVersGetAllEquipmentsions(..).");
                // Call the GetVersions RPC method
                cctvConfigResponse = client.GetAgentNetworkConfigById(listIdsRequest);

                // Display the response
                Console.WriteLine("\tResponse status: " + cctvConfigResponse.Response.ResponseValue);
                Console.WriteLine("\tResponse description: " + cctvConfigResponse.Response.Desc);

                foreach (var cctvConfig in cctvConfigResponse.CctvConfigs)
                {
                    //Agent agent = 1;
                    Console.WriteLine($"\tAgent: {cctvConfig.Agent.Id}, Add: {cctvConfig.Agent.Address}, " +
                                      $"Enabled? {cctvConfig.Agent.Enabled}, ServerId: {cctvConfig.Agent.ServerId}");

                    //repeated Station stations = 2;
                    foreach(var station in cctvConfig.Stations)
                    {
                        Console.WriteLine($"\t\tStation: {station.Id}, Name: {station.Name}, Status: {station.Status}, " +
                                          $"Enabled?: {station.Enabled}, PollTimeout: {station.PollingTimeout}, Type: {station.Type}");
                    }

                    //repeated EquipmentClass equipmentClasses = 3;
                    foreach (var equipClass in cctvConfig.EquipmentClasses)
                    {
                        Console.WriteLine($"\t\tEquipmentClass: {equipClass.Id}, Name: {equipClass.Name}, SxGenConf: {equipClass.SxGenericConfig}");
                    }

                    //repeated EquipmentType equipmentTypes = 4;
                    foreach (var equipType in cctvConfig.EquipmentTypes)
                    {
                        Console.WriteLine($"\t\tEquipmentType: {equipType.Id}, Name: {equipType.Name}, ClassId: {equipType.ClassId}, " +
                                          $"GenConf: {equipType.GenericConfig}, SpecConf: {equipType.SpecificConfig}");
                    }

                    //repeated Equipment equipments = 5;
                    foreach(var equip in cctvConfig.Equipments)
                    {
                        Console.WriteLine($"\t\tEquipment: {equip.Id}, Name: {equip.Name}, Station: {equip.StationId}, " +
                                          $"Type: {equip.Type}, Enabled?: {equip.Enabled}, CommSettings: {equip.CommSettings}, " +
                                          $"GenState: {equip.GenericState}, SpecState: {equip.SpecificState}, " +
                                          $"GenConf: {equip.GenericConfig}, SpecConf: {equip.SpecificConfig}, " +
                                          $"BoxId: {equip.BoxId}");
                    }
                }

                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}");
            }


            Console.WriteLine("...CctvClient.GetAgentNetworkConfigById()");
        }
    }
}
