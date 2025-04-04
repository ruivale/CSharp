
using Com.Efacec.ES.TRP.Efarail.Cctv.Grpc.Messages.v1;
using Com.Efacec.ES.TRP.Efarail.Cctv.Grpc.Enums.v1;
using Com.Efacec.ES.TRP.Efarail.Cctv.Grpc.Operation.v1;
using Com.Efacec.ES.TRP.Efarail.Cctv.Grpc.Configuration.v1;
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
        //static readonly string _host = "localhost";

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
        /// Obtains the given targets connection information, if any.
        /// TAO IDL:
        ///          - int getSourcesInTargets(int[] targets, ...);
        /// rpc GetDetailedConnectionsInfo(ListIds) returns(DetailedConnectionsInfoResponse);
        /// </summary>
        public void GetDetailedConnectionsInfo()
        {
            Console.WriteLine("CctvClient.GetDetailedConnectionsInfo()...");

            DetailedConnectionsInfoResponse detailedConnectionsInfoResponse;

            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portOper); // https://localhost:5555
            Console.WriteLine($"CctvClient.GetDetailedConnectionsInfo() - GrpcChannel({_protocol}{_host}:{_portConfig}) created.");

            // Create a client for the Configuration service
            var client = new Operation.OperationClient(channel);
            Console.WriteLine("CctvClient.GetDetailedConnectionsInfo() - Operation.OperationClient(channel) created.");


            // Create a VersionsRequest message
            var listIdsRequest = new ListIds
            {
                WorkstationInfo = new WorkstationInformation
                {
                    Id = 11,
                    UserName = "inoss"
                },
                // target equips list of Ids... or empty
                Ids = { 21331, 21332, 21333, 21334, 21335, 21336, 21337, 21338, 21339, 21340, 21341, 21342, 21343, 21344, 21345, 21346, 21347, 21348, 21349, 21350 }
            };

            try
            {
                Console.WriteLine("CctvClient.GetDetailedConnectionsInfo() - Will call server Operation.GetDetailedConnectionsInfo(..).");

                detailedConnectionsInfoResponse = client.GetDetailedConnectionsInfo(listIdsRequest);

                // Display the response
                Console.WriteLine("\tResponse status: " + detailedConnectionsInfoResponse.Response.ResponseValue);
                Console.WriteLine("\tResponse description: " + detailedConnectionsInfoResponse.Response.Desc);


                foreach (var detailedConnectionInfo in detailedConnectionsInfoResponse.DetailedConnectionInfos)
                {
                    Console.WriteLine($"\t\tConnection: TargetId: {detailedConnectionInfo.TargetId}, SourceObj: {detailedConnectionInfo.SourceObj}, " +
                                      $"Handle: {detailedConnectionInfo.Handle}, SourceId: {detailedConnectionInfo.SourceId}, " +
                                      $"StationId: {detailedConnectionInfo.StationId}, RecSourceId: {detailedConnectionInfo.RecorderSourceId}");
                }

                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}");
            }
        }


        /// <summary>
        /// Normally used to acknowledge sensors and actuators alarms.
        /// TAO IDL:
        ///          - int ackAlarm(workstationInformation_ logInfo, int nEquipId, int[] listAlarmIds, ...);
        /// rpc AckAlarms(AckAlarmsRequest) returns(MultipleRequestsResponse); public void AckAlarms()
        /// </summary>
        public void AckAlarms()
        {

            Console.WriteLine("CctvClient.AckAlarms()...");

            MultipleRequestsResponse response;


            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portOper); // https://localhost:5555
            Console.WriteLine($"CctvClient.AckAlarms() - GrpcChannel({_protocol}{_host}:{_portConfig}) created.");

            // Create a client for the Configuration service
            var client = new Operation.OperationClient(channel);
            Console.WriteLine("CctvClient.AckAlarms() - Operation.OperationClient(channel) created.");


            AckAlarmsRequest request = new AckAlarmsRequest
            {
                WorkstationInfo = new WorkstationInformation
                {
                    Id = 11,
                    UserName = "XXXXX"
                },
                // equip id: 20251, 20252
                EquipId = 103301, //20251,
                // list of alarm Ids... or empty
                AlarmIds = { },
            };

            try
            {
                Console.WriteLine("CctvClient.AckAlarms() - Will call server Operation.AckAlarms(..).");

                response = client.AckAlarms(request);

                // Display the response
                Console.WriteLine("\tResponse status: " + response.GlobalResponse.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.GlobalResponse.Desc);


                foreach (var specificResponse in response.SpecificResponses)
                {
                    Console.WriteLine($"\t\tSpecific response: Response(status: {specificResponse.Response.ResponseValue}, Desc: {specificResponse.Response.Desc}), " +
                                      $"AlarmId: {specificResponse.Id}");
                }

                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}");
            }
        }



        /// <summary>
        /// Used to mark an user/manual alarm associated with the given source identification.
        /// This method return information is the marking handle which can be used to change the user marking.
        /// TAO IDL:
        ///          - int markUserAlarm(workstationInformation_ logInfo, int userId, int SourceId, int alarmSubtypeId, sTag, sSensorAlarmSubtypeTagId, sNotes, IntHolder alarmId);
        ///          
        /// rpc MarkUserAlarm(MarkUserAlarmRequest) returns(NumericResponse);
        /// 
        /// 
        /// // The mark an user alarm message associated with the given source identification. 
        /// message MarkUserAlarmRequest
        /// {
        ///     // The workstation information.
        ///     WorkstationInformation workstationInfo = 1;
        ///     // The user identification.
        ///     google.protobuf.Int64Value userId = 2;
        ///     // The source equipment identification.
        ///     google.protobuf.Int64Value equipId = 3;
        ///     // The alarm sub type identification. (from STV DB. t_sensoralarmsubtypes)
        ///     google.protobuf.Int64Value alarmSubtypeId = 4;
        ///     // The marking parameters. (from STV DB: t_sensralarsubtypes_tags_parms)
        ///     google.protobuf.StringValue param = 5;
        ///     // The marking subtype tag id of the sensor. (from STV DB: t_sensoralarmsubtypes_tags)
        ///     google.protobuf.StringValue alarmSensorSubtypeTagId = 6;
        ///     // The marking notes. (from STV DB: t_video_recalarm_params)
        ///     google.protobuf.StringValue notes = 7;
        /// }
        /// 
        ///
        /// message Response
        /// {
        ///     // The numeric value to return to the caller.
        ///     ResponseValue responseValue = 1;
        ///     // A description of the returned value, if needed/wanted (can be left empty).
        ///     string desc = 2;
        /// }
        /// // Generic numeric message
        /// message NumericResponse
        /// {
        ///     // The numeric value.
        ///     Response response = 1;
        ///     // The numeric response identification
        ///     int64 id = 2;
        /// }
        /// </summary>
        public void MarkUserAlarm()
        {
            Console.WriteLine("CctvClient.MarkUserAlarmAsRead()...");
            NumericResponse response;
            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portOper); // https://localhost:5555
            Console.WriteLine($"CctvClient.MarkUserAlarmAsRead() - GrpcChannel({_protocol}{_host}:{_portOper}) created.");
            // Create a client for the Configuration service
            var client = new Operation.OperationClient(channel);
            Console.WriteLine("CctvClient.MarkUserAlarmAsRead() - Operation.OperationClient(channel) created.");


            try
            {
                response =
            client.MarkUserAlarm(
                new MarkUserAlarmRequest
                {
                    WorkstationInfo = new WorkstationInformation
                    {
                        Id = 11,
                        UserName = "XXXXX"
                    },
                    UserId = 11,
                    EquipId = 103302,
                    AlarmSubtypeId = 1,
                    Param = "",
                    AlarmSensorSubtypeTagId = "",
                    Notes = "",
                });

                // Display the response
                Console.WriteLine("\tResponse id: " + response.Id);
                Console.WriteLine("\t\tResponse status: " + response.Response.ResponseValue);
                Console.WriteLine("\t\tResponse description: " + response.Response.Desc);

                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}");
            }
        }


        /// <summary>
        /// 
        /// NOT YET IMPLEMENTED IN THE SERVER SIDE
        /// 
        /// </summary>
        public void GetSensorAlarmTypes()
        {
            Console.WriteLine("CctvClient.GetSensorAlarmTypes()...");

            ListSensorAlarmTypesResponse response;

            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portOper); // https://localhost:5556
            Console.WriteLine($"CctvClient.GetSensorAlarmTypes() - GrpcChannel({_protocol}{_host}:{_portOper}) created.");
            // Create a client for the Configuration service
            var client = new Operation.OperationClient(channel);
            Console.WriteLine("CctvClient.GetSensorAlarmTypes() - Operation.OperationClient(channel) created.");


            try
            {
                response =
                    client.GetSensorAlarmTypes(new WorkstationInformation
                    {
                        Id = 11,
                        UserName = "XXXXX"
                    });

                // Display the response 
                Console.WriteLine("\tResponse status: " + response.Response.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.Response.Desc);

                foreach (var sensorAlarmType in response.SensorAlarmTypes)
                {
                    Console.WriteLine($"\t\tSensorAlarmType: Id: {sensorAlarmType.Id}, Description: {sensorAlarmType.Description}");
                }

                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}");
            }
        }


        /// <summary>
        /// Used to set a NotAcknowledgedAlarm in a monitor.
        /// For each given monitor:
        ///      - if it belongs to a group of monitors, the alarm is set in it, moving the active alarm in that
        ///        same monitor, if present, to another position in the stack. This does NOT ACKNOWLEDGE the alarm.
        ///      - if it doesn't belong to a group of monitor, i.e., if it's a normal monitor, the alarm is set in
        ///        it and the alarm is ACKNOWLEDGED!
        ///
        /// TAO IDL:
        ///          For a group monitor:
        ///          - int setAlarmOnMonitor(workstationInformation_ logInfo, long alarmId, int monitorId);
        ///          or if the given monitor is groupless monitor:
        ///          - int ackAlarmToTarget(workstationInformation_ logInfo, long alarmId, int monitorId); - THIS ACKNOWLEDGE THE ALARM(s).
        /// rpc SetAlarmsOnMonitor(SetAlarmsOnMonitorRequest) returns(MultipleRequestsResponse);
        /// 
        /// 
        /// The "Set Alarms On Monitor" connection request. 
        /// message AlarmMonitorConnectionInfo
        /// {
        ///     // if true, the operation is directed to a monitor in a group, aka alarm monitor.
        ///     google.protobuf.BoolValue monitorInGroup = 1;
        ///     // the source & target info.
        ///     ConnectionInfo connectionInfo = 2;
        /// }
        /// // The "Set Alarms On Monitor" request. Basically is a list of NotAcknowledgeAlarms identifications and target equipments, normally monitors, identifications.
        /// message SetAlarmsOnMonitorRequest
        /// {
        ///     // The workstation information.
        ///     WorkstationInformation workstationInfo = 1;
        ///     // The connections info, i.e., source and target identifications pairs.
        ///     repeated AlarmMonitorConnectionInfo connectionInfos = 2;
        /// }
        /// // Basic message holder for connections, i.e., only the source and target data. 
        /// message ConnectionInfo
        /// {
        ///     // The source, normally a camera, identification  but could also be a sequence id...
        ///     google.protobuf.Int64Value sourceId = 1;
        ///     // The target equipment, normally a monitor, identification.
        ///     google.protobuf.Int64Value targetId = 2;
        /// }
        /// // Return message when multiple requests are sent in a single invocation.
        /// message MultipleRequestsResponse
        /// {
        ///     // Global reply for the request. If this is OK, then ALL requests were successful. 
        ///     Response globalResponse = 1;
        ///     // The list of IDs and request status of each one of them. 
        ///     // NOTE: if the globalReply is OK, there no need to use this item.
        ///     repeated NumericResponse specificResponses = 2;
        /// }
        /// // Generic numeric message
        /// message NumericResponse
        /// {
        ///     // The numeric value.
        ///     Response response = 1;
        ///     // The numeric response identification
        ///     int64 id = 2;
        /// }
        /// </summary>
        public void SetAlarmOnMonitor()
        {
            Console.WriteLine("CctvClient.SetAlarmOnMonitor()...");

            MultipleRequestsResponse response;

            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portOper); // https://localhost:5555
            Console.WriteLine($"CctvClient.SetAlarmOnMonitor() - GrpcChannel({_protocol}{_host}:{_portOper}) created.");

            // Create a client for the Configuration service
            var client = new Operation.OperationClient(channel);
            Console.WriteLine("CctvClient.SetAlarmOnMonitor() - Operation.OperationClient(channel) created.");


            SetAlarmsOnMonitorRequest request = new SetAlarmsOnMonitorRequest
            {
                WorkstationInfo = new WorkstationInformation
                {
                    Id = 11,
                    UserName = "XXXXX"
                },
                ConnectionInfos = {
                    new AlarmMonitorConnectionInfo()
                    {
                        MonitorInGroup = true,
                        ConnectionInfo = new ConnectionInfo { SourceId = 66252677, TargetId = 21331 }
                    }
                }
            };


            try
            {
                response = client.SetAlarmsOnMonitor(request);

                // Display the response
                Console.WriteLine("\tResponse status: " + response.GlobalResponse.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.GlobalResponse.Desc);


                foreach (var specificResponse in response.SpecificResponses)
                {
                    Console.WriteLine($"\t\tSpecific response: Response(status: {specificResponse.Response.ResponseValue}, Desc: {specificResponse.Response.Desc}), " +
                                      $"AlarmId: {specificResponse.Id}");
                }

                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}");
            }
        }



        /// <summary>
        /// Used to edit user/manual alarm markings data.
        /// TAO IDL:
        ///          - int changeUserMarkAlarm(workstationInformation_ logInfo, int alarmId, int userId, String sTag, String sSensorAlarmSubtypeTagId, String notes, boolean isMarkingEnd);
        /// rpc EditUserMarkAlarm(MarkUserAlarmEditRequest) returns(Response);
        /// 
        /// // The message used to edit an already user/manual alarm marking.
        /// message MarkUserAlarmEditRequest
        /// {
        ///     // The workstation information.
        ///     WorkstationInformation workstationInfo = 1;
        ///     // The alarm identification.
        ///     google.protobuf.Int64Value alarmId = 2;
        ///     // The user identification.
        ///     google.protobuf.Int64Value userId = 3;
        ///     // The marking tag parameter. 
        ///     google.protobuf.StringValue tag = 4;
        ///     // The marking subtype tag id of the sensor. 
        ///     google.protobuf.StringValue alarmSensorSubtypeTagId = 5;
        ///     // The marking notes. (from STV DB: t_video_recalarm_params)
        ///     google.protobuf.StringValue notes = 6;
        ///     // If true it means the marking just occurred. False for all other usages.
        ///     google.protobuf.BoolValue markingEnd =  7;
        /// }
        /// </summary>
        public void EditUserMarkAlarm()
        {
            Console.WriteLine("CctvClient.editUserMarkAlarm()...");
            Response response;
            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portOper); // https://localhost:5555
            Console.WriteLine($"CctvClient.editUserMarkAlarm() - GrpcChannel({_protocol}{_host}:{_portOper}) created.");
            // Create a client for the Configuration service
            var client = new Operation.OperationClient(channel);
            Console.WriteLine("CctvClient.editUserMarkAlarm() - Operation.OperationClient(channel) created.");


            try
            {
                response =
                    client.EditUserMarkAlarm(
                        new MarkUserAlarmEditRequest
                        {
                            WorkstationInfo = new WorkstationInformation
                            {
                                Id = 11,
                                UserName = "XXXXX"
                            },
                            AlarmId = 652579,
                            UserId = 11,
                            Tag = "",
                            AlarmSensorSubtypeTagId = "",
                            Notes = "",
                            MarkingEnd = true
                        });

                Console.WriteLine("\t\tResponse status: " + response.ResponseValue);
                Console.WriteLine("\t\tResponse description: " + response.Desc);

                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}");
            }
        }



        /// <summary>
        /// // Lock/Unlock equipments, normally cameras. The r
        /// NOTE: if the globalResponse, present in the returned MultipleRequestsResponse,
        ///       is OK, there's no need to use the specific lock/unlock response item.
        ///
        ///  Param:
        ///
        ///  Returns: the return is a little bit tricky. To really check for the operation "ping"
        ///           return success this method MUST be called w/ an array of equips with ONLY ONE element.
        ///
        /// TAO IDL:
        ///          - int ping(int IG, int priorityLevel, int[] lockedEquips, int IGTimeout);
        ///          - int releaseEquipment(workstationInformation_ logInfo, int equipId, int IG, int priorityLevel);
        /// rpc LockUnlockEquipments(LockUnlockEquipsRequest) returns(MultipleRequestsResponse);
        /// 
        /// 
        /// // Message used when a lock, or unlock, equipments request is invoked.
        /// message LockUnlockEquipsRequest
        /// {
        ///     // The workstation information.
        ///     WorkstationInformation workstationInfo = 1;
        ///     // The list of identifications, normally from cameras.
        ///     repeated google.protobuf.Int64Value ids = 2;
        ///     // The lock or unlock Operation.
        ///     LockUnlockType lockUnlockType = 3;
        ///     // The operation priority (normally associated w/ user profile priority)
        ///     google.protobuf.Int64Value priority = 4;
        ///     // The lock timeout. If, before this timeout ends, Cctv does not receive further locks, the locks ends.
        ///     google.protobuf.Int64Value timeout = 5;
        /// }
        /// </summary>
        public void LockUnlockEquipments()
        {
            Console.WriteLine("CctvClient.lockUnlockEquipments()...");
            MultipleRequestsResponse response;
            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portOper); // https://localhost:5555
            Console.WriteLine($"CctvClient.lockUnlockEquipments() - GrpcChannel({_protocol}{_host}:{_portOper}) created.");
            // Create a client for the Configuration service
            var client = new Operation.OperationClient(channel);
            Console.WriteLine("CctvClient.lockUnlockEquipments() - Operation.OperationClient(channel) created.");


            try
            {
                response =
                    client.LockUnlockEquipments(
                        new LockUnlockEquipsRequest
                        {
                            WorkstationInfo = new WorkstationInformation
                            {
                                Id = 11,
                                UserName = "XXXXX"
                            },
                            Ids = { 103301, 103302, 21331 },
                            LockUnlockType = LockUnlockType.LckLock,
                            Priority = 1,
                            Timeout = 30000
                        });

                Console.WriteLine("CctvClient.lockUnlockEquipments() - Locking equips...");
                // Display the response
                Console.WriteLine("\tResponse status: " + response.GlobalResponse.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.GlobalResponse.Desc);

                foreach (var specificResponse in response.SpecificResponses)
                {
                    Console.WriteLine($"\t\tSpecific response: Response(status: {specificResponse.Response.ResponseValue}, Desc: {specificResponse.Response.Desc}), " +
                                      $"Id: {specificResponse.Id}");
                }




                response =
                    client.LockUnlockEquipments(
                        new LockUnlockEquipsRequest
                        {
                            WorkstationInfo = new WorkstationInformation
                            {
                                Id = 11,
                                UserName = "XXXXX"
                            },
                            Ids = { 103301, 21331 },
                            LockUnlockType = LockUnlockType.LckUnlock,
                            Priority = 1,
                            Timeout = 30000
                        });

                Console.WriteLine("CctvClient.lockUnlockEquipments() - Unlocking equips...");
                // Display the response
                Console.WriteLine("\tResponse status: " + response.GlobalResponse.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.GlobalResponse.Desc);

                foreach (var specificResponse in response.SpecificResponses)
                {
                    Console.WriteLine($"\t\tSpecific response: Response(status: {specificResponse.Response.ResponseValue}, Desc: {specificResponse.Response.Desc}), " +
                                      $"Id: {specificResponse.Id}");
                }



                response =
                    client.LockUnlockEquipments(
                        new LockUnlockEquipsRequest
                        {
                            WorkstationInfo = new WorkstationInformation
                            {
                                Id = 11,
                                UserName = "XXXXX"
                            },
                            Ids = { 102301 },
                            LockUnlockType = LockUnlockType.LckUnlock,
                            Priority = 1,
                            Timeout = 30000
                        });

                Console.WriteLine("CctvClient.lockUnlockEquipments() - Locking equips...");
                // Display the response
                Console.WriteLine("\tResponse status: " + response.GlobalResponse.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.GlobalResponse.Desc);

                foreach (var specificResponse in response.SpecificResponses)
                {
                    Console.WriteLine($"\t\tSpecific response: Response(status: {specificResponse.Response.ResponseValue}, Desc: {specificResponse.Response.Desc}), " +
                                      $"Id: {specificResponse.Id}");
                }





                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}");
            }
        }


        /// <summary>
        /// // Execute all ptzf cameras presets operations: activate, add, update or delete.
        ///
        /// NOTE: THIS METHOD WILL CALL THE EQUIPMENT (not only the database).
        ///
        /// TAO IDL:
        ///          - int ptzfActivatePreset(int EqId, short nPreset);
        ///          - int ptzfStorePreset(workstationInformation_ logInfo, int EqId, short nPreset);
        ///          and, for saving the real preset name, call the configuraion.idl API "storePreset(PresetConfigStv_)";
        ///          - int ptzfDeletePreset(workstationInformation_ logInfo, int EqId, short nPreset);
        ///          
        /// rpc CamerasPtzfPresetsOperation(CameraPtzfSavePresetsRequest) returns(CameraPtzfSavePresetsResponse);
        /// 
        /// 
        /// // The cameras preset CRUD operations request.
        /// message CameraPtzfSavePresetsRequest
        /// {
        ///     // The workstation information.
        ///     WorkstationInformation workstationInfo = 1;
        ///     // The camera identification.
        ///     repeated CameraPtzfPreset cameraPtzfPresets = 2;
        ///     // The request operation: add, update and delete
        ///     CameraPtzfPresetOperation cameraPtzfPresetOperation = 3;
        /// }
        /// // A camera preset CRUD operation message.
        /// message CameraPtzfPreset
        /// {
        ///     // The camera identification.
        ///     google.protobuf.Int64Value cameraId = 1;
        ///     // The ptzf camera preset slot index.
        ///     google.protobuf.Int64Value index = 2;
        ///     // The ptzf camera preset name.
        ///     google.protobuf.StringValue name = 3;
        /// }
        /// // The cameras presets oprations.
        /// enum CameraPtzfPresetOperation
        /// {
        ///     // since we're dealing w/ OPEN enums, the first element must be zero (0);
        ///     CPO_ACTIVATE = 0;
        ///     CPO_ADD = 1;
        ///     CPO_UPDATE = 2;
        ///     CPO_DELETE = 3;
        /// }
        /// // The cameras preset CRUD operation response.
        /// message CameraPtzfSavePresetResponse
        /// {
        ///     // The response.
        ///     Response response = 1;
        ///     // The camera preset saving information.
        ///     CameraPtzfPreset cameraPtzfPreset = 2;
        /// }
        /// // The cameras preset CRUD operations request.
        /// message CameraPtzfSavePresetsResponse
        /// {
        ///     // Global reply for the request. If this is OK, then ALL requests were successful. 
        ///     Response response = 1;
        ///     // The list of saving cameras presets responses.
        ///     repeated CameraPtzfSavePresetResponse cameraPtzfSavePresetResponses = 2;
        /// }
        /// </summary>
        public void CamerasPtzfPresetsOperation()
        {
            Console.WriteLine("CctvClient.CamerasPtzfPresetsOperation()...");

            CameraPtzfSavePresetsResponse response;

            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portOper); // https://localhost:5555
            Console.WriteLine($"CctvClient.CamerasPtzfPresetsOperation() - GrpcChannel({_protocol}{_host}:{_portOper}) created.");

            // Create a client for the Configuration service
            var client = new Operation.OperationClient(channel);
            Console.WriteLine("CctvClient.CamerasPtzfPresetsOperation() - Operation.OperationClient(channel) created.");


            try
            {
                response = client.CamerasPtzfPresetsOperation(
                    new CameraPtzfSavePresetsRequest
                    {
                        WorkstationInfo = new WorkstationInformation
                        {
                            Id = 11,
                            UserName = "XXXXX"
                        },
                        CameraPtzfPresets = {
                            new CameraPtzfPreset
                            {
                                CameraId = 100309,
                                Index = 5,
                                Name = "Preset 5"
                            },
                            new CameraPtzfPreset
                            {
                                CameraId = 100309,
                                Index = 6,
                                Name = "Preset 6"
                            }
                        },
                        CameraPtzfPresetOperation = CameraPtzfPresetOperation.CpoAdd
                    });
                Console.WriteLine("CctvClient.CamerasPtzfPresetsOperation() - Adding presets...");
                // Display the response
                Console.WriteLine("\tResponse status: " + response.Response.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.Response.Desc);

                foreach (var specificResponse in response.CameraPtzfSavePresetResponses)
                {
                    Console.WriteLine($"\t\tSpecific response: Response(status: {specificResponse.Response.ResponseValue}, Desc: {specificResponse.Response.Desc}), " +
                                      $"CameraId: {specificResponse.CameraPtzfPreset.CameraId}, Index: {specificResponse.CameraPtzfPreset.Index}, Name: {specificResponse.CameraPtzfPreset.Name}");
                }




                response = client.CamerasPtzfPresetsOperation(
                    new CameraPtzfSavePresetsRequest
                    {
                        WorkstationInfo = new WorkstationInformation
                        {
                            Id = 11,
                            UserName = "XXXXX"
                        },
                        CameraPtzfPresets = {
                            new CameraPtzfPreset
                            {
                                CameraId = 100309,
                                Index = 5,
                                Name = "Can be empty. When activating or deleting, the preset name/description is not used."
                            }
                        },
                        CameraPtzfPresetOperation = CameraPtzfPresetOperation.CpoActivate
                    });
                Console.WriteLine("CctvClient.CamerasPtzfPresetsOperation() - Activate preset...");
                // Display the response
                Console.WriteLine("\tResponse status: " + response.Response.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.Response.Desc);

                foreach (var specificResponse in response.CameraPtzfSavePresetResponses)
                {
                    Console.WriteLine($"\t\tSpecific response: Response(status: {specificResponse.Response.ResponseValue}, Desc: {specificResponse.Response.Desc}), " +
                                      $"CameraId: {specificResponse.CameraPtzfPreset.CameraId}, Index: {specificResponse.CameraPtzfPreset.Index}, Name: {specificResponse.CameraPtzfPreset.Name}");
                }




                response = client.CamerasPtzfPresetsOperation(
                    new CameraPtzfSavePresetsRequest
                    {
                        WorkstationInfo = new WorkstationInformation
                        {
                            Id = 11,
                            UserName = "XXXXX"
                        },
                        CameraPtzfPresets = {
                            new CameraPtzfPreset
                            {
                                CameraId = 100309,
                                Index = 5,
                                Name = "Preset 5555"
                            },
                            new CameraPtzfPreset
                            {
                                CameraId = 100309,
                                Index = 6,
                                Name = "Preset 6666"
                            }
                        },
                        CameraPtzfPresetOperation = CameraPtzfPresetOperation.CpoUpdate
                    });
                Console.WriteLine("CctvClient.CamerasPtzfPresetsOperation() - Update presets...");
                // Display the response
                Console.WriteLine("\tResponse status: " + response.Response.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.Response.Desc);

                foreach (var specificResponse in response.CameraPtzfSavePresetResponses)
                {
                    Console.WriteLine($"\t\tSpecific response: Response(status: {specificResponse.Response.ResponseValue}, Desc: {specificResponse.Response.Desc}), " +
                                      $"CameraId: {specificResponse.CameraPtzfPreset.CameraId}, Index: {specificResponse.CameraPtzfPreset.Index}, Name: {specificResponse.CameraPtzfPreset.Name}");
                }




                response = client.CamerasPtzfPresetsOperation(
                    new CameraPtzfSavePresetsRequest
                    {
                        WorkstationInfo = new WorkstationInformation
                        {
                            Id = 11,
                            UserName = "XXXXX"
                        },
                        CameraPtzfPresets = {
                            new CameraPtzfPreset
                            {
                                CameraId = 100309,
                                Index = 5,
                                Name = "Can be empty. When activating or deleting, the preset name/description is not used."
                            },
                            new CameraPtzfPreset
                            {
                                CameraId = 100309,
                                Index = 6,
                                Name = "Can be empty. When activating or deleting, the preset name/description is not used."
                            }
                        },
                        CameraPtzfPresetOperation = CameraPtzfPresetOperation.CpoDelete
                    });
                Console.WriteLine("CctvClient.CamerasPtzfPresetsOperation() - Delete presets...");
                // Display the response
                Console.WriteLine("\tResponse status: " + response.Response.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.Response.Desc);

                foreach (var specificResponse in response.CameraPtzfSavePresetResponses)
                {
                    Console.WriteLine($"\t\tSpecific response: Response(status: {specificResponse.Response.ResponseValue}, Desc: {specificResponse.Response.Desc}), " +
                                      $"CameraId: {specificResponse.CameraPtzfPreset.CameraId}, Index: {specificResponse.CameraPtzfPreset.Index}, Name: {specificResponse.CameraPtzfPreset.Name}");
                }




                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}");
            }
        }



        /// <summary>
        /// Execute all actuator operations: actuate or deactuate.
        /// TAO IDL:
        ///          - int actuate(workstationInformation_ logInfo, int EqId, int lDuration);
        ///          - int deactuate(workstationInformation_ logInfo, int EqId);
        /// 
        /// rpc ExecActuatorOperation(ActuatorOperationsRequest) returns(ActuatorOperationsResponse);
        /// 
        /// 
        /// // The actuator operation: actuate or deactuate.
        /// message ActuatorOperationRequest
        /// {
        ///     // The actuator identification.
        ///     google.protobuf.Int64Value actuatorId = 1;
        ///     // The actuator operation.
        ///     ActuatorOperation actuatorOperation = 2;
        /// }
        /// // The actuator operations request.
        /// message ActuatorOperationsRequest
        /// {
        ///     // The workstation information.
        ///     WorkstationInformation workstationInfo = 1;
        ///     // The list of actuator operations.
        ///     repeated ActuatorOperationRequest actuatorOperationRequests = 2;
        /// }
        /// 
        /// // Single actuator operation request response.
        /// message ActuatorOperationResponse
        /// {
        ///     // The response.
        ///     NumericResponse response = 1;
        ///     // The actuator operation.
        ///     ActuatorOperation actuatorOperation = 2;
        /// }
        /// // Actuators operations requests response.
        /// message ActuatorOperationsResponse
        /// {
        ///     // Global reply for the request. If this is OK, then ALL requests were successful. 
        ///     Response response = 1;
        ///     // The response.
        ///     repeated ActuatorOperationResponse actuatorOperationResponses = 2;
        /// }
        /// 
        /// </summary>
        public void ExecActuatorOperation()
        {
            Console.WriteLine("CctvClient.ExecActuatorOperation()...");

            ActuatorOperationsResponse response;

            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portOper); // https://localhost:5555
            Console.WriteLine($"CctvClient.ExecActuatorOperation() - GrpcChannel({_protocol}{_host}:{_portOper}) created.");

            // Create a client for the Configuration service
            var client = new Operation.OperationClient(channel);
            Console.WriteLine("CctvClient.ExecActuatorOperation() - Operation.OperationClient(channel) created.");


            try
            {
                response =
                    client.ExecActuatorOperation(
                        new ActuatorOperationsRequest
                        {
                            WorkstationInfo = new WorkstationInformation
                            {
                                Id = 11,
                                UserName = "XXXXX"
                            },
                            ActuatorOperationRequests = {
                                    new ActuatorOperationRequest
                                    {
                                        ActuatorId = -9999,
                                        ActuatorOperation = ActuatorOperation.AcoActuate
                                    }
                            }
                        });

                Console.WriteLine("CctvClient.CamerasPtzfPresetsOperation() - ExecActuatorOperation");
                // Display the response
                Console.WriteLine("\tResponse status: " + response.Response.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.Response.Desc);

                foreach (var specificResponse in response.ActuatorOperationResponses)
                {
                    Console.WriteLine($"\t\tSpecific response: Response(id: {specificResponse.Response.Id}," +
                                      $"status: {specificResponse.Response.Response.ResponseValue}, " +
                                      $"Desc: {specificResponse.Response.Response.Desc}), " +
                                      $"ActuatorOperation: {specificResponse.ActuatorOperation}");
                }


                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}");
            }
        }



        /// <summary>
        /// Used to signal the CCTV service that the cameras associated with the given MobileCamHomePos
        /// were PTZFed, i.e., moved, so, CCTV service should proccess the camera PTZF accordingly, normally
        /// and if the "Return to Home Position" is enabled, reset/restart the timer to move the PTZF camera
        /// to its Home position after the configured timeout.
        /// This API is also used to configure the "Go to Home Position" feature.
        /// TAO IDL:
        ///          - 	int ptzf(workstationInformation_ logInfo, MobileCamHomePosReturn_[]);
        ///     rpc PtzfOperationExecuted(MobileCameraAutoHomePositionActivationsRequest) returns(MultipleRequestsResponse);
        /// 
        /// 
        /// // A PTZF operation associated info. Used when a PTZF camera is PTZFed, i.e., moved, 
        /// // and it supports the "Return to Home Position" feature.
        /// // Its used for configuration and operation (reset/restart the "Go to Home Position" timer).
        /// message MobileCameraAutoHomePositionActivation
        /// {
        ///     // The camera identification.
        ///     google.protobuf.Int64Value camId = 1;
        ///     // If true it means the camera has the "Go To Home Position" feature enabled.
        ///     google.protobuf.BoolValue enabled =  2;
        ///     // The "Return to Home Position" timeout, i.e., the ammount of seconds before moving 
        ///     // the camera to its configured home position after the last PTZF operation was performed.
        ///     google.protobuf.Int64Value timeout = 3;
        ///     // The camera preset index used to set the home position.
        ///     google.protobuf.Int64Value preset = 4;
        ///     // True if the home position is set by a PreSet, 
        ///     // false if the home position is set by a pre-configured value (stored in T_OPTIONSSTV [PRESETS_HOME oprtion]).
        ///     google.protobuf.BoolValue hasHomePosSet =  5;
        ///     // If 1 (true), a sequence start will disable the feature for the camera until the sequence is stopped (the camera must be present in the sequence list of operations).
        ///     google.protobuf.BoolValue sequenceMng =  6;
        ///     // If 1 (true), a alarm reaction, which has the camera in its associated macro actions, will disable the feature. For it to be enabled again, the user must start it.
        ///     google.protobuf.BoolValue alarmMng =  7;
        /// }
        /// // The "Go to Home Position" oper/config request message.
        /// message MobileCameraAutoHomePositionActivationsRequest
        /// {
        ///     // The workstation information.
        ///     WorkstationInformation workstationInfo = 1;
        ///     // The PTZF operations.
        ///     repeated MobileCameraAutoHomePositionActivation mobileCameraAutoHomePositionActivations = 2;
        /// }
        /// 
        /// 
        /// // Return message when multiple requests are sent in a single invocation.
        /// message MultipleRequestsResponse
        /// {
        ///     // Global reply for the request. If this is OK, then ALL requests were successful. 
        ///     Response globalResponse = 1;
        ///     // The list of IDs and request status of each one of them. 
        ///     // NOTE: if the globalReply is OK, there no need to use this item.
        ///     repeated NumericResponse specificResponses = 2;
        /// }
        /// // Generic numeric reply
        /// message Response {
        ///     // The numeric value to return to the caller.
        ///     ResponseValue responseValue = 1;
        ///     // A description of the returned value, if needed/wanted (can be left empty).
        ///     string desc = 2;
        /// }
        /// // Generic numeric message
        /// message NumericResponse {
        ///     // The numeric value.
        ///     Response response = 1;
        ///     // The numeric response identification
        ///     int64 id = 2;
        /// }
        /// 
        /// </summary>
        public void PtzfOperationExecuted()
        {
            Console.WriteLine("CctvClient.PtzfOperationExecuted()...");

            MultipleRequestsResponse response;

            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portOper); // https://localhost:5555
            Console.WriteLine($"CctvClient.PtzfOperationExecuted() - GrpcChannel({_protocol}{_host}:{_portOper}) created.");

            // Create a client for the Configuration service
            var client = new Operation.OperationClient(channel);
            Console.WriteLine("CctvClient.PtzfOperationExecuted() - Operation.OperationClient(channel) created.");


            try
            {
                response = client.PtzfOperationExecuted(
                    new MobileCameraAutoHomePositionActivationsRequest
                    {
                        WorkstationInfo = new WorkstationInformation
                        {
                            Id = 11,
                            UserName = "XXXXX"
                        },
                        MobileCameraAutoHomePositionActivations = {
                                new MobileCameraAutoHomePositionActivation
                                {
                                    CamId = 100309,
                                    Enabled = true,
                                    Timeout = 30,
                                    Preset = 5,
                                    HasHomePosSet = true,       // not yet used
                                    SequenceMng = true,         // not yet used
                                    AlarmMng = true             // not yet used
                                }
                        }
                    });

                Console.WriteLine("CctvClient.PtzfOperationExecuted() - PtzfOperationExecuted");

                // Display the response

                Console.WriteLine("\tResponse status: " + response.GlobalResponse.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.GlobalResponse.Desc);

                foreach (var specificResponse in response.SpecificResponses)
                {
                    Console.WriteLine($"\t\tSpecific response: Response(status: {specificResponse.Response.ResponseValue}, Desc: {specificResponse.Response.Desc}), " +
                                      $"Id: {specificResponse.Id}");
                }

                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);

                Console.WriteLine("CctvClient.PtzfOperationExecuted() - PtzfOperationExecuted - END");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}");
            }
        }


        /// <summary>
        /// Starting sequences in the targets, normally monitors, all given in the StartSeqsInTargetsRequest message.
        /// TAO IDL:
        ///          - int setSequenceinTarget(workstationInformation_ logInfo, int SeqID, int TargetID);
        ///          
        ///     rpc StartSequences(StartSequencesRequest) returns (RunningSequencesResponse);
        ///
        /// 
        /// // Information associated to a sequence start.
        /// message SequenceConnInfo
        /// {
        ///     // The connection info, i.e., sequence, the source item in the message, and target.
        ///     ConnectionInfo connectionInfo = 1;
        ///     // Used for syncronous sequences. Values from 0..30, in intervals of 5 meaning seconds.
        ///     // NOTE: nowadays, @2406, not used anymore... but here just in case
        ///     google.protobuf.StringValue syncTime = 2;
        /// }
        /// // The sequences starting command request.
        /// message StartSequencesRequest
        /// {
        ///     // The workstation information.
        ///     WorkstationInformation workstationInfo = 1;
        ///     // The sequences information.
        ///     repeated SequenceConnInfo sequenceConnInfos = 2;
        /// }
        /// 
        /// 
        /// // The running sequence data holder.
        /// message RunningSequence
        /// {
        ///     // The sequence identification. 
        ///     // May not be needed if the handle is set. It can be useful, but not always mandatory.
        ///     google.protobuf.Int64Value id = 1;
        ///     // The running sequence handle, i.e., the running sequence identification.
        ///     google.protobuf.Int64Value handle = 2;
        ///     // The running sequence active target, normally not needed but can be sent just in case.
        ///     google.protobuf.Int64Value targetId = 3;
        ///     // The sequence state. Depending on the operation, this value could be not set.
        ///     SequenceState state = 4;
        ///     // Used for syncronous sequences. Values from 0..30, in intervals of 5 meaning seconds.
        ///     // NOTE: nowadays, @2406, not used anymore... but here just in case.
        ///     google.protobuf.Int64Value syncTime = 5;
        /// }
        /// // The running sequence reply message.
        /// message RunningSequenceResponse
        /// {
        ///     // Global reply for the request. If this is OK, then ALL requests were successful. 
        ///     Response response = 1;
        ///     // The running sequence handle and target
        ///     RunningSequence runningSequence = 2;
        ///     // The running sequence state, i.e., one from SequenceOper (When )
        ///     SequenceOper SequenceOper = 3;
        /// }
        /// // The running sequences reply message, normally used when obtaining all running sequences.
        /// message RunningSequencesResponse
        /// {
        ///     // Global reply for the request. If this is OK, then ALL requests were successful. 
        ///     Response response = 1;
        ///     // The running sequences reply message
        ///     repeated RunningSequenceResponse runningSequencesResponse = 2;
        /// }
        /// 
        /// </summary>
        public int StartSequences()
        {
            int iSeqHandle = 0;

            Console.WriteLine("\nCctvClient.StartSequences()...");

            RunningSequencesResponse response;

            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portOper); // https://localhost:5555
            Console.WriteLine($"CctvClient.StartSequences() - GrpcChannel({_protocol}{_host}:{_portOper}) created.");
            // Create a client for the Configuration service
            var client = new Operation.OperationClient(channel);
            Console.WriteLine("CctvClient.StartSequences() - Operation.OperationClient(channel) created.");


            try
            {
                response = client.StartSequences(
                    new StartSequencesRequest
                    {
                        WorkstationInfo = new WorkstationInformation
                        {
                            Id = 11,
                            UserName = "XXXXX"
                        },
                        SequenceConnInfos = {
                            new SequenceConnInfo
                            {
                                // Cenário LUASRes ID
                                //      Sequence(Id=1529, Name=Teste_x64)
                                //      Target(Id=21334, Name=Monitor 4)
                                ConnectionInfo = new ConnectionInfo
                                {
                                    SourceId = 1529,    // sequence ID 
                                    TargetId = 21334    // target ID
                                },
                                SyncTime = ""           // Not yet used
                            }
                        }
                    });

                Console.WriteLine("CctvClient.StartSequences() - StartSequences");
                // Display the response
                Console.WriteLine("\tResponse status: " + response.Response.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.Response.Desc);

                foreach (var specificResponse in response.RunningSequencesResponse_)
                {
                    Console.WriteLine($"\t\tSpecific response: Response(status: {specificResponse.Response.ResponseValue}, Desc: {specificResponse.Response.Desc}), " +
                                      $"Id: {specificResponse.RunningSequence.Id}, " +
                                      $"Handle: {specificResponse.RunningSequence.Handle}, " +
                                      $"TargetId: {specificResponse.RunningSequence.TargetId}, " +
                                      $"Operation: {specificResponse.SequenceOper}");

                    iSeqHandle = (int)specificResponse.RunningSequence.Handle;
                }

                Console.WriteLine("\tResponse start sequences - END\n");

                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}\n");
            }


            return iSeqHandle;
        }



        /// <summary>
        /// For all given sequences, executes the given operation: stop, pause, restart and steps forward and backward.
        /// TAO IDL:
        ///          - int stopSequence(workstationInformation_ logInfo, int SeqHdl);
        ///          - int startSequence(workstationInformation_ logInfo, int SeqHdl);
        ///          - int pauseSequence(workstationInformation_ logInfo, int SeqHdl);
        ///          - int showNextStep(int SeqHdl);
        ///          - int showPreviousStep(int SeqHdl);
        ///          or if we desire to stop all running sequences using the given sequence id:
        ///          - int stopAllSequences(workstationInformation_ logInfo, int SeqId);
        ///
        ///     rpc ExecSequencesOperation(SequencesOperationRequest) returns(RunningSequencesResponse);
        ///
        /// 
        /// The running sequence data holder.
        /// message RunningSequence
        /// {
        ///     // The sequence identification. 
        ///     // May not be needed if the handle is set. It can be useful, but not always mandatory.
        ///     google.protobuf.Int64Value id = 1;
        ///     // The running sequence handle, i.e., the running sequence identification.
        ///     google.protobuf.Int64Value handle = 2;
        ///     // The running sequence active target, normally not needed but can be sent just in case.
        ///     google.protobuf.Int64Value targetId = 3;
        ///     // The sequence state. Depending on the operation, this value could be not set.
        ///     SequenceState state = 4;
        ///     // Used for syncronous sequences. Values from 0..30, in intervals of 5 meaning seconds.
        ///     // NOTE: nowadays, @2406, not used anymore... but here just in case.
        ///     google.protobuf.Int64Value syncTime = 5;
        /// }
        /// // Sequence operations used, only after a sequence as been started, to execute an operation.
        /// enum SequenceOper
        /// {
        ///     // since we're dealing w/ OPEN enums, the first element must be zero (0);
        ///     SEQOPE_STOP = 0;
        ///     SEQOPE_PAUSE = 1;
        ///     SEQOPE_RESTART = 2;
        ///     SEQOPE_STEP_PREVIOUS = 3;
        ///     SEQOPE_STEP_NEXT = 4;
        /// }
        /// /// // Used when stopping, pausing, restarting sequences. 
        /// // Only a single SequenceOper can be applied to the given list of sequences or targets.
        /// message SequencesOperationRequest
        /// {
        ///     // The workstation information.
        ///     WorkstationInformation workstationInfo = 1;
        ///     // The sequence oper: stop, pause, restart, next or previous step.
        ///     SequenceOper sequenceOper = 2;
        ///     // Items Ids, whatever they mean, i.e., targets equipments or sequences handles 
        ///     // depending on the set prop from MsgRunningSequence.
        ///     repeated RunningSequence runningSequences = 3;
        /// }
        /// // The running sequence reply message.
        /// message RunningSequenceResponse
        /// {
        ///     // Global reply for the request. If this is OK, then ALL requests were successful. 
        ///     Response response = 1;
        ///     // The running sequence handle and target
        ///     RunningSequence runningSequence = 2;
        ///     // The running sequence state, i.e., one from SequenceOper (When )
        ///     SequenceOper SequenceOper = 3;
        /// }
        /// // The running sequences reply message, normally used when obtaining all running sequences.
        /// message RunningSequencesResponse
        /// {
        ///     // Global reply for the request. If this is OK, then ALL requests were successful. 
        ///     Response response = 1;
        ///     // The running sequences reply message
        ///     repeated RunningSequenceResponse runningSequencesResponse = 2;
        /// }
        /// 
        /// </summary>
        public void ExecSequenceOperation()
        {
            Console.WriteLine("\nCctvClient.ExecSequenceOperation()...");

            RunningSequencesResponse response;

            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portOper); // https://localhost:5555
            Console.WriteLine($"CctvClient.ExecSequenceOperation() - GrpcChannel({_protocol}{_host}:{_portOper}) created.");

            // Create a client for the Configuration service
            var client = new Operation.OperationClient(channel);
            Console.WriteLine("CctvClient.ExecSequenceOperation() - Operation.OperationClient(channel) created.");



            Console.WriteLine("CctvClient.ExecSequenceOperation() - will start a sequence...");

            int iSeqHandle = this.StartSequences();

            Console.WriteLine($"CctvClient.ExecSequenceOperation() - the started sequence returned the \"{iSeqHandle}\" handle.");



            Console.WriteLine("CctvClient.ExecSequenceOperation() - waiting to obtain running seqs...");
            Thread.Sleep(2500);

            this.GetRunningSequences();
            Thread.Sleep(1500);


            if (iSeqHandle != 0)
            {
                try
                {
                    response = client.ExecSequencesOperation(
                        new SequencesOperationRequest
                        {
                            WorkstationInfo = new WorkstationInformation
                            {
                                Id = 11,
                                UserName = "XXXXX"
                            },
                            SequenceOper = SequenceOper.SeqopeStop,
                            RunningSequences = { new RunningSequence { Handle = iSeqHandle } }
                        });

                    Console.WriteLine($"CctvClient.ExecSequenceOperation() - ExecSequenceOperation STOP executed (Handle = {iSeqHandle})");
                    // Display the response
                    Console.WriteLine("\tResponse status: " + response.Response.ResponseValue);
                    Console.WriteLine("\tResponse description: " + response.Response.Desc);

                    foreach (var specificResponse in response.RunningSequencesResponse_)
                    {
                        Console.WriteLine($"\t\tSpecific response: Response(status: {specificResponse.Response.ResponseValue}, Desc: {specificResponse.Response.Desc}) " +
                                        $"Sequence(Id:{specificResponse.RunningSequence.Id}  TargetId: {specificResponse.RunningSequence.TargetId} Handle: {specificResponse.RunningSequence.Handle})");
                    }

                    channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n\nError: {ex.Message}\n");
                }
            }
            else
            {
                Console.WriteLine($"\n\nError: the started sequence retruned a invalid handle(0).\n");
            }

            Thread.Sleep(1500);

            try
            {
                response = client.ExecSequencesOperation(
                    new SequencesOperationRequest
                    {
                        WorkstationInfo = new WorkstationInformation
                        {
                            Id = 11,
                            UserName = "XXXXX"
                        },
                        SequenceOper = SequenceOper.SeqopeStop,
                        RunningSequences = { new RunningSequence { Handle = 892836768 } }
                    });

                Console.WriteLine("CctvClient.ExecSequenceOperation() - ExecSequenceOperation STOP executed (Handle = 892836768)");
                // Display the response
                Console.WriteLine("\tResponse status: " + response.Response.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.Response.Desc);

                foreach (var specificResponse in response.RunningSequencesResponse_)
                {
                    Console.WriteLine($"\t\tSpecific response: Response(status: {specificResponse.Response.ResponseValue}, Desc: {specificResponse.Response.Desc}) " +
                                    $"Sequence(Id:{specificResponse.RunningSequence.Id}  TargetId: {specificResponse.RunningSequence.TargetId} Handle: {specificResponse.RunningSequence.Handle})");
                }

                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}\n");
            }


            Console.WriteLine("CctvClient.ExecSequenceOperation() - waiting to obtain running seqs...");

            Thread.Sleep(2500);

            this.GetRunningSequences();

            Console.WriteLine("CctvClient.ExecSequenceOperation() - END\n");
        }



        /// <summary>
        /// Obtain all running sequences.
        /// The request can be filter by the given WorkStation, targets, sequences handles, etc,
        /// configured in the RunningSequencesRequest parameter, if any.
        /// Can be used to obtain:
        ///      - all running sequences, if the given parameter is unset;
        ///      - sequences states;
        ///     - which, if any, sequences are active in the given targets;
        ///      - etc.
        ///
        /// TAO IDL:
        ///      - void getRunningSeqs(...); (returns ALL running seqs BUT NO HANDLE)
        ///      - int getSequenceInTargetData(int targetId, ...); (returns all info)
        ///      - int getSequenceInTarget(int targetId); (we returns the sequence handle)
        ///     rpc GetRunningSequences(RunningSequencesRequest) returns(RunningSequencesResponse);
        ///
        /// 
        /// // The running sequence data holder.
        /// message RunningSequence
        /// {
        ///     // The sequence identification. 
        ///     // May not be needed if the handle is set. It can be useful, but not always mandatory.
        ///     google.protobuf.Int64Value id = 1;
        ///     // The running sequence handle, i.e., the running sequence identification.
        ///     google.protobuf.Int64Value handle = 2;
        ///     // The running sequence active target, normally not needed but can be sent just in case.
        ///     google.protobuf.Int64Value targetId = 3;
        ///     // The sequence state. Depending on the operation, this value could be not set.
        ///     SequenceState state = 4;
        ///     // Used for syncronous sequences. Values from 0..30, in intervals of 5 meaning seconds.
        ///     // NOTE: nowadays, @2406, not used anymore... but here just in case.
        ///     google.protobuf.Int64Value syncTime = 5;
        /// }
        /// // The running sequences data holder.
        /// message RunningSequencesRequest
        /// {
        ///     // The workstation information.
        ///     WorkstationInformation workstationInfo = 1;
        ///     // The running sequencse handles, i.e., the running sequence identification
        ///     repeated RunningSequence runningSequences = 2;
        /// }
        /// 
        /// 
        /// // The running sequence reply message.
        /// message RunningSequenceResponse
        /// {
        ///     // Global reply for the request. If this is OK, then ALL requests were successful. 
        ///     Response response = 1;
        ///     // The running sequence handle and target
        ///     RunningSequence runningSequence = 2;
        ///     // The running sequence state, i.e., one from SequenceOper (When )
        ///     SequenceOper SequenceOper = 3;
        /// }
        /// // The running sequences reply message, normally used when obtaining all running sequences.
        /// message RunningSequencesResponse
        /// {
        ///     // Global reply for the request. If this is OK, then ALL requests were successful. 
        ///     Response response = 1;
        ///     // The running sequences reply message
        ///     repeated RunningSequenceResponse runningSequencesResponse = 2;
        /// }        /// 
        /// </summary>
        public void GetRunningSequences()
        {
            Console.WriteLine("\nCctvClient.GetRunningSequences()...");

            RunningSequencesResponse response;

            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portOper); // https://localhost:5555
            Console.WriteLine($"CctvClient.GetRunningSequences() - GrpcChannel({_protocol}{_host}:{_portOper}) created.");

            // Create a client for the Configuration service
            var client = new Operation.OperationClient(channel);
            Console.WriteLine("CctvClient.GetRunningSequences() - Operation.OperationClient(channel) created.");


            try
            {
                response = client.GetRunningSequences(
                    new RunningSequencesRequest
                    {
                        WorkstationInfo = new WorkstationInformation
                        {
                            Id = 11,
                            UserName = "XXXXX"
                        }
                        //,RunningSequences = { new RunningSequence { TargetId = 21333 }, new RunningSequence { TargetId = 21334 } }
                    });

                Console.WriteLine("CctvClient.GetRunningSequences() - GetRunningSequences");
                // Display the response
                Console.WriteLine("\tResponse status: " + response.Response.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.Response.Desc);

                foreach (var specificResponse in response.RunningSequencesResponse_)
                {
                    Console.WriteLine($"\t\tSpecific response: Response(status: {specificResponse.Response.ResponseValue}, Desc: {specificResponse.Response.Desc}) " +
                        $"Sequence(Id:{specificResponse.RunningSequence.Id}  TargetId: {specificResponse.RunningSequence.TargetId} Handle: {specificResponse.RunningSequence.Handle})");
                }

                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);

                Console.WriteLine("CctvClient.GetRunningSequences() - GetRunningSequences - END\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}\n");
            }
        }



        /// <summary>
        /// For all given macros, executes the given operation, i.e., start or stop.
        /// NOTE: if the globalResponse, present in the returned MultipleRequestsResponse,
        ///       is OK, there's no need to use the specific macro response item.
        /// TAO IDL:
        ///          - int runMacro(workstationInformation_ logInfo, int macroId); (return the macro handle)
        ///          - stopMacro(macroHandle)
        ///          
        ///     rpc ExecMacrosOperation(MacrosOperationRequest) returns (MacroOperationsResponse);
        ///     
        /// // Macro operation
        /// enum MacroOper
        /// {
        ///     // since we're dealing w/ OPEN enums, the first element must be zero (0);
        ///     MACOPE_START = 0;
        ///     MACOPE_STOP = 1;
        /// }
        /// // Used to start and stop macros. 
        /// // Only a single MacroOper can be applied to the given list of macros.
        /// message MacrosOperationRequest
        /// {
        ///     // The workstation information.
        ///     WorkstationInformation workstationInfo = 1;
        ///     // The macro oper, i.e., start or stop.
        ///     MacroOper macroOper = 2;
        ///     // Macros Ids.
        ///     repeated google.protobuf.Int64Value ids = 3;
        /// }
        /// 
        /// // Return message when multiple requests are sent in a single macro operation invocation.
        /// message MacroOperationResponse
        /// {
        ///     // Specific response
        ///     Response response = 1;
        ///     // The macro identification.
        ///     int64 macroId = 2;
        ///     // The macro operation handle. Used when a start/run macro is used/called.
        ///     int64 macroHandle = 3;
        /// }
        /// 
        /// //
        /// // Return message when multiple requests are sent in a single invocation.
        /// message MacroOperationsResponse
        /// {
        ///     // Global reply for the request. If this is OK, then ALL requests were successful. 
        ///     Response globalResponse = 1;
        ///     // The list of macros ids and its handle if the request was for a start/run macro.
        ///     // NOTE: if the globalReply is OK, there no need to use this item.
        ///     repeated MacroOperationResponse macroOperationsResponses = 2;
        /// }
        /// </summary>
        public void ExecMacroOperation()
        {
            Console.WriteLine("CctvClient.ExecMacroOperation()...");

            MacroOperationsResponse response;

            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portOper); // https://localhost:5555
            Console.WriteLine($"CctvClient.ExecMacroOperation() - GrpcChannel({_protocol}{_host}:{_portOper}) created.");

            // Create a client for the Configuration service
            var client = new Operation.OperationClient(channel);
            Console.WriteLine("CctvClient.ExecMacroOperation() - Operation.OperationClient(channel) created.");


            try
            {
                response = client.ExecMacrosOperation(
                    new MacrosOperationRequest
                    {
                        WorkstationInfo = new WorkstationInformation
                        {
                            Id = 11,
                            UserName = "XXXXX"
                        },
                        MacroOper = MacroOper.MacopeStart,
                        Ids = { 2845 }
                    });

                Console.WriteLine("CctvClient.ExecMacroOperation() - ExecMacrosOperation.MacopeStart");

                // Display the response
                Console.WriteLine("\tResponse status: " + response.GlobalResponse.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.GlobalResponse.Desc);


                long lMacroHandle = 0;

                foreach (var specificResponse in response.MacroOperationsResponses)
                {
                    Console.WriteLine($"\t\tSpecific response: Response(status: {specificResponse.Response.ResponseValue}, Desc: {specificResponse.Response.Desc}) " +
                        $"Macro(Id:{specificResponse.MacroId}  Handle: {specificResponse.MacroHandle})");

                    lMacroHandle = specificResponse.MacroHandle;
                }

                Thread.Sleep(3000);


                response = client.ExecMacrosOperation(
                    new MacrosOperationRequest
                    {
                        WorkstationInfo = new WorkstationInformation
                        {
                            Id = 11,
                            UserName = "XXXXX"
                        },
                        MacroOper = MacroOper.MacopeStop,
                        Ids = { lMacroHandle }
                    });

                Console.WriteLine("CctvClient.ExecMacroOperation() - ExecMacrosOperation.MacopeStop");

                // Display the response
                Console.WriteLine("\tResponse status: " + response.GlobalResponse.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.GlobalResponse.Desc);


                foreach (var specificResponse in response.MacroOperationsResponses)
                {
                    Console.WriteLine($"\t\tSpecific response: Response(status: {specificResponse.Response.ResponseValue}, Desc: {specificResponse.Response.Desc}) " +
                        $"Macro(Id:{specificResponse.MacroId}  Handle: {specificResponse.MacroHandle})");
                }

                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);

                Console.WriteLine("CctvClient.ExecMacroOperation() - END");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}");
            }

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
                    foreach (var station in cctvConfig.Stations)
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
                    foreach (var equip in cctvConfig.Equipments)
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



        /// <summary>
        ///   // Used to edit a cameras preset.
        ///
        /// NOTE: THIS METHOD WILL ONLY CHANGE THE STV DATABASE CAMERA PRESET DATA (it will not change anything in the equipment).
        ///
        /// TAO IDL:
        ///          - int storePreset(PresetConfigStv_);
        ///          
        ///       rpc CamerasPresetsEdition(CamerasPresetsEditionRequest) returns (CamerasPresetsEditionResponse);
        ///       
        /// 
        /// // A camera preset CRUD operation message.
        /// message CameraPtzfPreset
        /// {
        ///     // The camera identification.
        ///     google.protobuf.Int64Value cameraId = 1;
        ///     // The ptzf camera preset slot index.
        ///     google.protobuf.Int64Value index = 2;
        ///     // The ptzf camera preset name.
        ///     google.protobuf.StringValue name = 3;
        /// }
        /// // The cameras presets basic edition request (i.e., the STV DB data edition only)
        /// message CamerasPresetsEditionRequest
        /// {
        ///     // The workstation information.
        ///     WorkstationInformation workstationInfo = 1;
        ///     // The list of cameras presets.
        ///     repeated CameraPtzfPreset cameraPtzfPresets = 2;
        /// }
        /// 
        /// 
        /// // The message used when cameras presets are requested. 
        /// message CamerasPresetsResponse
        /// {
        ///     // Global reply for the request. If this is OK, then ALL requests were successful. 
        ///     Response response = 1;
        ///     // The list of cameras presets.
        ///     repeated CameraPtzfPreset cameraPtzfPresets = 2;
        /// }
        /// // The cameras presets basic edition request response (i.e., the STV DB data edition only)
        /// message CamerasPresetsEditionResponse
        /// {
        ///     // Global reply for the request. If this is OK, then ALL requests were successful. 
        ///     Response response = 1;
        ///     // The list of cameras presets which were not correctly configured. The ones that went well are absent from this list.
        ///     repeated CamerasPresetsResponse cameraPtzfPresetsResponses = 2;
        /// }
        /// /// </summary>
        public void CamerasPresetEdition()
        {

            Console.WriteLine("\nCctvClient.CamerasPresetEdition()...");

            CamerasPresetsEditionResponse response;

            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portConfig); // https://localhost:5556
            Console.WriteLine($"CctvClient.CamerasPresetEdition() - GrpcChannel({_protocol}{_host}:{_portConfig}) created.");

            // Create a client for the Configuration service
            var client = new Configuration.ConfigurationClient(channel);
            Console.WriteLine("CctvClient.CamerasPresetEdition() - Configuration.ConfigurationClient(channel) created.");


            try
            {
                Console.WriteLine("CctvClient.CamerasPresetEdition() - Will call server Configuration.GetVersGetAllEquipmentsions(..).");
                // Call the GetVersions RPC method
                response = client.CamerasPresetsEdition(
                    new CamerasPresetsEditionRequest
                    {
                        WorkstationInfo = new WorkstationInformation
                        {
                            Id = 11,
                            UserName = "XXXXX"
                        },
                        CameraPtzfPresets = {
                            new CameraPtzfPreset
                            {
                                CameraId = 100309,
                                Index = 2,
                                Name = "Preset 2_2_2_2"
                            },
                            new CameraPtzfPreset
                            {
                                CameraId = 100309,
                                Index = 3,
                                Name = "Preset 3_3_3_3"
                            }
                        }
                    }
                );



                // Display the response
                Console.WriteLine("\tResponse status: " + response.Response.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.Response.Desc);


                foreach (var cameraPtzfPresetsResponse in response.CameraPtzfPresetsResponses)
                {
                    Console.WriteLine("\t\tResponse status: " + cameraPtzfPresetsResponse.Response.ResponseValue);
                    Console.WriteLine("\t\tResponse description: " + cameraPtzfPresetsResponse.Response.Desc);

                    Console.WriteLine($"\t\tCameraPtzfPresets: {cameraPtzfPresetsResponse.CameraPtzfPresets}");
                }


                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}");
            }


            Console.WriteLine("...CctvClient.CamerasPresetEdition()\n");
        }



        /// <summary>
        /// Used to add, basic and full edition, delete sequences and also edit and delete specific sequences operations (this last two must already exist).
        /// TAO IDL:
        ///          - int addNewVidSeq(workstationInformation_, VideoSequenceConfigStv_); (SequenceConfig.SEQCONF_ADD)
        ///          - int saveVidSeq(workstationInformation_, VideoSequenceConfigStv_ ); (SequenceConfig.SEQCONF_EDIT_BASIC)
        ///          - int saveVidSeqFull(workstationInformation_, VideoSequenceConfigStv_, VidSeqOperationConfigStv_[]); (SequenceConfig.SEQCONF_EDIT_FULL)
        ///          - int deleteVidSeq(workstationInformation_ logInfo, int VidSeqID); (SequenceConfig.SEQCONF_DELETE)
        ///          - int saveVidSeqOperation(VidSeqOperationConfigStv_); (SequenceConfig.SEQCONF_SAVE_OPERATION)
        ///          - int deleteVidSeqOperation(int VidSeqID, int nPos); (SequenceConfig.SEQCONF_DELETE_OPERATION)
        ///     rpc ExecSequenceConfiguration(SequenceConfigRequest) returns(SequenceConfigResponse);
        ///
        /// 
        /// // Sequence configuration operations
        /// enum SequenceConfig
        /// {
        ///     // since we're dealing w/ OPEN enums, the first element must be zero (0);
        ///     SEQCONF_ADD = 0;
        ///     SEQCONF_EDIT_BASIC = 1;
        ///     SEQCONF_EDIT_FULL = 2;
        ///     SEQCONF_DELETE = 3;
        ///     SEQCONF_SAVE_OPERATION = 4;
        ///     SEQCONF_DELETE_OPERATION = 5;
        /// }
        /// // The sequences operation. Basically holds info about a sequence iteraction.
        /// message SequenceOperation
        /// {
        ///     // 
        ///     google.protobuf.Int64Value sequenceId = 1;
        ///     // 
        ///     google.protobuf.Int64Value position = 2;
        ///     // 
        ///     google.protobuf.BoolValue enabled = 3;
        ///     // 
        ///     google.protobuf.Int64Value equipmentId = 4;
        ///     // 
        ///     google.protobuf.StringValue equipmentParam = 5;
        ///     // 
        ///     google.protobuf.Int64Value duration = 6;
        /// }
        /// // The sequence basic information, normally used to define a sequence but NOT a running one.
        /// message Sequence {
        ///     // The sequence identification.
        ///     int64 id = 1;
        ///     // The sequence name.
        ///     string name = 2;
        ///     // The sequence mode: undefined, ciclic or non ciclic.
        ///     SequenceMode mode = 3;
        /// }
        /// // The sequence configuration message.
        /// message SequenceFullData
        /// {
        ///     // The basic sequence data: identification, name and mode.
        ///     Sequence sequence = 1;
        ///     // The list of sequence operations, i.e., its iteractions.
        ///     repeated SequenceOperation sequenceOperations = 2;
        /// }
        /// /// // The sequences configurations request.
        /// message SequenceConfigRequest
        /// {
        ///     // The workstation information.
        ///     WorkstationInformation workstationInfo = 1;
        ///     // The sequence configuration operation: add, basic edit, full edit and delete.
        ///     SequenceConfig sequenceConfig = 2;
        ///     // The sequences configurations to perform.
        ///     repeated SequenceFullData sequencesFullData = 3;
        /// }
        /// 
        /// // The sequence basic info and its operations.
        /// message ListSequenceFullDataResponse
        /// {
        ///     // Global reply for the request. If this is OK, then ALL requests were successful. 
        ///     Response response = 1;
        ///     // The list of complete sequnce data, i.e., its basic data and its operations.
        ///     repeated SequenceFullData sequencesFullData = 2;
        /// }
        /// // The sequences configurations responses.
        /// message SequenceConfigResponse
        /// {
        ///     // Global reply for the request. If this is OK, then ALL requests were successful. 
        ///     Response response = 1;
        ///     // The SequenceConfigurations which were not correctly configured. The ones that went well are absent from this list.
        ///     repeated ListSequenceFullDataResponse sequencesFullDataResponse = 2;
        /// }
        /// </summary>
        public void ExecSequenceConfiguration()
        {
            Console.WriteLine("\nCctvClient.ExecSequenceConfiguration()...");

            SequenceConfigResponse response;

            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portConfig); // https://localhost:5556
            Console.WriteLine($"CctvClient.ExecSequenceConfiguration() - GrpcChannel({_protocol}{_host}:{_portConfig}) created.");

            // Create a client for the Configuration service
            var client = new Configuration.ConfigurationClient(channel);
            Console.WriteLine("CctvClient.ExecSequenceConfiguration() - Configuration.ConfigurationClient(channel) created.");

            try
            {
                response = client.ExecSequenceConfiguration(new SequenceConfigRequest
                {
                    WorkstationInfo = new WorkstationInformation
                    {
                        Id = 11,
                        UserName = "XXXXX"
                    },
                    SequenceConfig = SequenceConfig.SeqconfAdd,
                    SequencesFullData = {
                    new SequenceFullData
                    {
                        Sequence = new Sequence{Id = -1, Name = "Teste CctvProxy I", Mode = SequenceMode.SeqmodCiclic},
                        SequenceOperations =
                        {
                            new SequenceOperation
                            {
                                SequenceId = -1,
                                Position = 0,
                                Enabled = true,
                                EquipmentId = 100301,
                                EquipmentParam = "",
                                Duration = 15
                            },
                            new SequenceOperation
                            {
                                SequenceId = -1,
                                Position = 1,
                                Enabled = true,
                                EquipmentId = 100309,
                                EquipmentParam = "",
                                Duration = 15
                            }
                        }
                    }
                }
                });


                // Display the response
                Console.WriteLine("\tResponse status: " + response.Response.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.Response.Desc);






                foreach (var sequenceFullDataResponse in response.SequencesFullDataResponse)
                {
                    Console.WriteLine("\t\tResponse status: " + sequenceFullDataResponse.Response.ResponseValue);
                    Console.WriteLine("\t\tResponse description: " + sequenceFullDataResponse.Response.Desc);

                    foreach (var sequenceFullData in sequenceFullDataResponse.SequencesFullData)
                    {
                        Console.WriteLine($"\t\tSequence: {sequenceFullData.Sequence.Id}, Name: {sequenceFullData.Sequence.Name}, Mode: {sequenceFullData.Sequence.Mode}");

                        foreach (var sequenceOperation in sequenceFullData.SequenceOperations)
                        {
                            Console.WriteLine($"\t\t\tSequenceOperation: {sequenceOperation.SequenceId}, Position: {sequenceOperation.Position}, Enabled: {sequenceOperation.Enabled}, " +
                                              $"EquipmentId: {sequenceOperation.EquipmentId}, EquipmentParam: {sequenceOperation.EquipmentParam}, Duration: {sequenceOperation.Duration}");
                        }
                    }
                }


                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}");
            }


            Console.WriteLine("...CctvClient.ExecSequenceConfiguration()\n");
        }



        /// <summary>
        ///   // Obtains macros configurations: macros, its actions and its actions parameters.
        /// It can be filtered by setting the request macro or owner id. If not set, or invalid, all macros are returned.
        /// TAO IDL:
        ///          - int getMacroByID(int MacroID, MacroConfigStv_Holder);
        ///          - int getAllMacros(listMacrosHolder);
        ///          - int getAllMacrosFromUser(int userId, listMacrosHolder);
        ///          
        ///     rpc GetMacrosConfiguration(MacrosRequest) returns(ListMacrosFullDataResponse);
        ///     
        /// // The request message when trying to obtain macros, filtered or not, configuration data.
        /// message MacrosRequest
        /// {
        ///     // The workstation information.
        ///     WorkstationInformation workstationInfo = 1;
        ///     // The macro identification. If its an invalid value, it means there's no filter for macro x, i.e., all macros configurations should be returned.
        ///     google.protobuf.Int64Value id = 2;
        ///     // The user/owner which added the macro. If its an invalid value, it means there's no owner id filter set so, should return all macros configurations.
        ///     google.protobuf.Int64Value ownerId = 3;
        /// }
        /// 
        /// //
        /// // Macros action codes, i.e., the tyoe of macro action.
        /// enum MacroActionCode
        /// {
        ///     // since we're dealing w/ OPEN enums, the first element must be zero (0);
        ///     //MACAC_UNKNOWN = 0;
        ///     MACAC_CAM_SELECT = 0;
        ///     MACAC_MULTIPLEX = 1;
        ///     MACAC_SEQUENCE = 2;
        ///     MACAC_PLAY = 3;
        ///     MACAC_RECORD = 4;
        ///     MACAC_STOP_VR = 5;
        ///     MACAC_ACTUATE = 6;
        ///     MACAC_DEACTUATE = 7;
        ///     MACAC_SLEEP = 8;
        ///     MACAC_DISCONNECT = 9;
        ///     MACAC_SET_STATION_STATE = 10;
        ///     MACAC_MARK_ALARM = 11;
        ///     MACAC_UNKNOWN = 999;
        /// }
        /// // The macro action data.
        /// message MacroAction
        /// {
        ///     // The associated macro identification.
        ///     google.protobuf.Int64Value macroId = 1;
        ///     // The associated macro identification.
        ///     google.protobuf.Int64Value actionIdx = 2;
        ///     // The associated macro action code identification.
        ///     MacroActionCode macroActionCode = 3;
        ///     // True is the macro action is enabled.
        ///     google.protobuf.BoolValue enabled = 4;
        /// }
        /// // A macro action parameter.
        /// message MacroActionParameter
        /// {
        ///     // The associated macro identification.
        ///     google.protobuf.Int64Value macroId = 1;
        ///     // The associated macro action number/index.
        ///     google.protobuf.Int64Value actionIdx = 2;
        ///     // The associated macro action parameter number/index.
        ///     google.protobuf.Int64Value paramIdx = 3;
        ///     // The associated macro action parameter value.
        ///     google.protobuf.StringValue value = 4;
        /// }
        /// // A macro action data and its parameters.
        /// message MacroActionFullData
        /// {
        ///     // The macro action
        ///     MacroAction macroAction = 1;
        ///     // The macro action parameters.
        ///     repeated MacroActionParameter macroActionParameters = 2;
        /// }
        /// // The macro basic data, all its actions and the all actions parameters.
        /// message MacroFullData
        /// {
        ///     // The basic macro data.
        ///     Macro macro = 1;
        ///     // The macros actions and all its parameters.
        ///     repeated MacroActionFullData macroActionFullDatas = 2;
        /// }
        /// // The list of macros full data, i.e., macros, its actions and its actions parameters.
        /// message ListMacrosFullDataResponse
        /// {
        ///     // Global reply for the request. If this is OK, then ALL requests were successful. 
        ///     Response response = 1;
        ///     // The list of macros.
        ///     repeated MacroFullData macroFullDatas = 2;
        /// }
        /// </summary>
        public void GetMacrosConfiguration()
        {
            Console.WriteLine("\nCctvClient.GetMacrosConfiguration()...");

            ListMacrosFullDataResponse response;

            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portConfig); // XXXXXXXXXXXXXXXXXXXXXX
            Console.WriteLine($"CctvClient.GetMacrosConfiguration() - GrpcChannel({_protocol}{_host}:{_portConfig}) created.");

            // Create a client for the Configuration service
            var client = new Configuration.ConfigurationClient(channel);
            Console.WriteLine("CctvClient.GetMacrosConfiguration() - Configuration.ConfigurationClient(channel) created.");

            try
            {
                response = client.GetMacrosConfiguration(
                    new MacrosRequest
                    {
                        WorkstationInfo = new WorkstationInformation
                        {
                            Id = 11,
                            UserName = "XXXXX"
                        },
                        OwnerId = 11,
                        Id = 2683
                    });


                // Display the response
                Console.WriteLine("\tResponse status: " + response.Response.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.Response.Desc);


                foreach (var macroFullData in response.MacroFullDatas)
                {
                    Console.WriteLine($"\t\tMacro: {macroFullData.Macro.Id}, Name: {macroFullData.Macro.Name}, OwnerId: {macroFullData.Macro.OwnerId}");

                    foreach (var macroActionFullData in macroFullData.MacroActionFullDatas)
                    {
                        Console.WriteLine($"\t\t\tMacroAction: {macroActionFullData.MacroAction.MacroId}, ActionIdx: {macroActionFullData.MacroAction.ActionIdx}, " +
                                          $"MacroActionCode: {macroActionFullData.MacroAction.MacroActionCode}, Enabled: {macroActionFullData.MacroAction.Enabled}");

                        foreach (var macroActionParameter in macroActionFullData.MacroActionParameters)
                        {
                            Console.WriteLine($"\t\t\t\tMacroActionParameter: {macroActionParameter.MacroId}, ActionIdx: {macroActionParameter.ActionIdx}, " +
                                              $"ParamIdx: {macroActionParameter.ParamIdx}, Value: {macroActionParameter.Value}");
                        }
                    }
                }

                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}");
            }


            Console.WriteLine("...CctvClient.GetMacrosConfiguration()\n");
        }



        /// <summary>
        /// Used to obtain macros actions.
        /// TAO IDL:
        ///          - int getAllActions(int MacroId, listActionsHolder lActions);
        ///     rpc GetMacroActions(MacroActionsRequest) returns(ListMacroActionsResponse);
        ///     
        /// </summary>
        public void GetMacroActions()
        {
            Console.WriteLine("\nCctvClient.GetMacroActions()...");

            ListMacroActionsResponse response;

            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portConfig); // XXXXXXXXXXXXXXXXXXXXXX
            Console.WriteLine($"CctvClient.GetMacroActions() - GrpcChannel({_protocol}{_host}:{_portConfig}) created.");

            // Create a client for the Configuration service
            var client = new Configuration.ConfigurationClient(channel);
            Console.WriteLine("CctvClient.GetMacroActions() - Configuration.ConfigurationClient(channel) created.");


            try
            {
                response = client.GetMacroActions(
                    new MacroActionsRequest
                    {
                        WorkstationInfo = new WorkstationInformation
                        {
                            Id = 11,
                            UserName = "XXXXX"
                        },
                        MacroId = 2683
                    });

                // Display the response
                Console.WriteLine("\tResponse status: " + response.Response.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.Response.Desc);

                foreach (var macroAction in response.MacroActions)
                {
                    Console.WriteLine($"\t\tMacroAction: {macroAction.MacroId}, ActionIdx: {macroAction.ActionIdx}, " +
                                      $"MacroActionCode: {macroAction.MacroActionCode}, Enabled: {macroAction.Enabled}");
                }

                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}\n");
            }

            Console.WriteLine("...CctvClient.GetMacroActions()\n");
        }




        /// <summary>
        /// From the given MacroActionParametersRequest, we can filter the returning data according to the given macro action parameter index.
        /// If no parameter index is given, all the macro action parameters are returned, otherwise, only the desired parameter, if exists, is returned.
        /// TAOL IDL:
        ///          - int getAllActionParameters(int macroId, int actionNr, listActionParametersHolder );
        ///     rpc GetMacroActionParameters(MacroActionParametersRequest) returns(ListMacroActionParameterResponse);
        ///
        /// </summary>
        public void GetMacrosActionParameters()
        {
            Console.WriteLine("\nCctvClient.GetMacrosActionParameters()...");

            ListMacroActionParameterResponse response;
            
            // Address of the gRPC server (change as per your server configuration) and create a channel to the server
            var channel = GrpcChannel.ForAddress(_protocol + _host + ":" + _portConfig); // XXXXXXXXXXXXXXXXXXXXXX
            Console.WriteLine($"CctvClient.GetMacrosActionParameters() - GrpcChannel({_protocol}{_host}:{_portConfig}) created.");
            
            // Create a client for the Configuration service
            var client = new Configuration.ConfigurationClient(channel);
            Console.WriteLine("CctvClient.GetMacrosActionParameters() - Configuration.ConfigurationClient(channel) created.");
            
            
            try
            {
                response = client.GetMacroActionParameters(
                    new MacroActionParametersRequest
                    {
                        WorkstationInfo = new WorkstationInformation
                        {
                            Id = 11,
                            UserName = "XXXXX"
                        },
                        MacroId = 2683,
                        ActionIdx = 2
                    });

                // Display the response
                Console.WriteLine("\tResponse status: " + response.Response.ResponseValue);
                Console.WriteLine("\tResponse description: " + response.Response.Desc);

                foreach (var macroActionParameter in response.MacroActionParameters)
                {
                    Console.WriteLine($"\t\tMacroActionParameter: {macroActionParameter.MacroId}, ActionIdx: {macroActionParameter.ActionIdx}, " +
                                      $"ParamIdx: {macroActionParameter.ParamIdx}, Value: {macroActionParameter.Value}");
                }

                channel.ShutdownAsync().Wait(_millisToWaitForChannelShutdown);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}");
            }

            Console.WriteLine("...CctvClient.GetMacrosActionParameters()\n");
        }


    }
}