using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoOS.Platform;
using VideoOS.Platform.Messaging;
using VideoOS.Platform.UI;
using VideoOS.Platform.Login;
using VideoOS.Platform.ConfigurationItems;
using static VideoOS.Platform.Messaging.MessageId;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using MyOwnMilestoneTests.Util;
using System.Threading;


namespace MyOwnMilestoneTests.Video
{

    /// <summary>
    /// Sample class to activate a camera video stream in a Milestone XProtect VideoWall.
    /// </summary>
    public class VideoActivate
    {

        private VideoOS.Platform.Messaging.Message msg;

        private string _strClientID;

        private FQID _camFQID;
        private FQID _monitorFQID;

            //_presetActivateFQID,
            //_monitorRemoveCamerasFQID,
            //_monitorSetLayoutAndCamerasFQID, 
            //_layoutSetLayoutAndCamerasFQID,
            //_monitorShowTextFQID,
            //_layoutSetLayoutFQID, 
            //_monitorSetLayoutFQID,
            //_monitorApplyXmlFQID,
            //_changeModeFQID;

        private decimal _positionInViewSetLayoutAndCameras, _positionInViewShowText, _positionInViewSetCameras;
        private Collection<FQID> _cameraSetLayoutAndCamerasFQIDCollection, _cameraRemoveCamerasFQIDCollection, _camsFQIDsCollection;

        private MessageCommunication _messageCommunication;
        private object _msgComRec;




        private void ListAllItems()
        {
            // Retrieve all recording servers
            IList<Item> recordingServers = Configuration.Instance.GetItems(ItemHierarchy.Both);
            //IList<Item> recordingServers = Configuration.Instance.GetItems(ItemHierarchy.RecordingServers);

            foreach (Item item in recordingServers)
            {
                Console.WriteLine($"\t" +
                    $"Server Name: {item.Name} \n\t\tFQID(" +
                    $"ObjId:{item.FQID.ObjectId} " +
                    $"\n\t\tParentId:{item.FQID.ParentId} " +
                    $"\n\t\tKind:{item.FQID.Kind} ({Kind.DefaultTypeToNameTable[item.FQID.Kind]}) ({Kind.DefaultTypeToCategoryTable[item.FQID.Kind]}) " +
                    $"\n\t\tServerId:{item.FQID.ServerId} " +
                    $"\n\t\tFolderType:{item.FQID.FolderType} "
                    // + $" \n\t\t[{device.FQID.ToString()}]"
                    );

                GetChildren(item);


                // Retrieve all devices (cameras) under each recording server
                //IList<Item> devices = server.GetChildren();

                //foreach (Item device in devices)
                //{
                //    Console.WriteLine($"\t" +
                //        $"Camera Name: {device.Name} " +
                //        $"\n\t\tFQID: {device.FQID.ObjectId} FQID(" +
                //        $"\n\t\tParentId: {device.FQID.ParentId} " +
                //        $"\n\t\tKind: {device.FQID.Kind} " +
                //        $"\n\t\tServerId: {device.FQID.ServerId} " +
                //        $"\n\t\tFolderType: {device.FQID.FolderType} " 
                //        // + $" \n\t\t[{device.FQID.ToString()}]"
                //        );

                //    //if (device.FQID.Kind == Kind.Camera)
                //    //{
                //    //    Console.WriteLine($"Item Name: {device.Name}, GUID: {device.FQID.ObjectId}");
                //    //}
                //}
            }
        }

        private void GetChildren(Item item)
        {
            IList<Item> devices = item.GetChildren();

            foreach (Item _item in devices)
            {
                Console.WriteLine($"\t" +
                    $"Item Name: {_item.Name} \n\t\tFQID(" +
                    $"ObjId:{_item.FQID.ObjectId} "+
                    $"\n\t\tParentId:{_item.FQID.ParentId} " +
                    $"\n\t\tKind:{item.FQID.Kind} ({Kind.DefaultTypeToNameTable[item.FQID.Kind]}) ({Kind.DefaultTypeToCategoryTable[item.FQID.Kind]}) " +
                    $"\n\t\tServerId:{_item.FQID.ServerId} " +
                    $"\n\t\tFolderType:{_item.FQID.FolderType} "
                    // + $" \n\t\t[{device.FQID.ToString()}]"
                    );

                //if (device.FQID.Kind == Kind.Camera)
                //{
                //    Console.WriteLine($"Item Name: {device.Name}, GUID: {device.FQID.ObjectId}");
                //}

                GetChildren(_item);
            }
        }



        /// <summary>
        /// 
        /// </summary>
        public VideoActivate()
        {
            _strClientID = $"{Environment.MachineName}-VideoWallControllerSample/{Process.GetCurrentProcess().Id}/{DateTime.UtcNow.Hour}:{DateTime.UtcNow.Minute}";

            _cameraSetLayoutAndCamerasFQIDCollection = new Collection<FQID>();
            _cameraRemoveCamerasFQIDCollection = new Collection<FQID>();
            _camsFQIDsCollection = new Collection<FQID>();

            _positionInViewSetLayoutAndCameras = 1;// setPositionSetLayoutAndCamerasNumeric.Value;
            _positionInViewShowText = 1;// setPositionShowTextNumeric.Value;
            _positionInViewSetCameras = 1;// setPositionSetCamerasNumeric.Value;

            MessageCommunicationManager.Start(EnvironmentManager.Instance.MasterSite.ServerId);
            _messageCommunication = MessageCommunicationManager.Get(EnvironmentManager.Instance.MasterSite.ServerId);
            _msgComRec = _messageCommunication.RegisterCommunicationFilter(VideoWallMessageCommunicationHandler, new CommunicationIdFilter(MessageId.Control.VideoWallIndication));

        }





        /// <summary>
        /// 
        /// </summary>
        public void Init()
        {
            Console.WriteLine();
            Console.WriteLine();

            //ListAllCameras();
            CamerasHelper.ObtainAllCameras();

            foreach (Camera cam in CamerasHelper.GetAllCameras())
            {
                Console.WriteLine(cam.ToString("\n\t\t"));

                VideoOS.Platform.ConfigurationItems.Camera camera = new VideoOS.Platform.ConfigurationItems.Camera(cam.FQID);

                foreach (StreamDefinition stream in camera.StreamFolder.Streams)
                {
                    Console.WriteLine($"\n\t\t\tStream: {stream.Name}");
                }   

            }
            Console.WriteLine();



            MonitorsHelper.ObtainAllMonitors();

            foreach (Monitor monitor in MonitorsHelper.GetAllMonitors())
            {
                Console.WriteLine(monitor.ToString("\n\t\t"));
            }
            Console.WriteLine("\n\n\n\n\n");



            //ViewsHelper.ObtainAllViews();

            //foreach (View view in ViewsHelper.GetAllViews())
            //{
            //    Console.WriteLine(view.ToString("\n\t\t"));
            //}
            //Console.WriteLine("\n\n\n\n\n");




            //List<Item> listCams = Utils.ObtainAll(Kind.Camera, IsCamera);




            ItemsHelper.ObtainAllItems();












            //Console.WriteLine("\n\n");

            //ListAllItems();
            //MonitorsHelper.GetCurrentMonitorLayout();



            //string strFqidCam195 = "488bc0bf-d5ee-4e94-9fbe-c155769ca042";
            //string strFqidVWMon1 = "90aaa255-3e05-47b8-a4b2-ffa498966f03";

            //FQID fqidCam195 = CamerasHelper.GetCamera(strFqidCam195).FQID;
            //FQID fqidVWMon1 = MonitorsHelper.GetMonitor(strFqidVWMon1).FQID;

            //sendCameraToMonitor(fqidCam195, fqidVWMon1, 1);






        }



        private void selectCamera(FQID fQIDCamera)
        {
            this._camFQID = fQIDCamera;

            this._camsFQIDsCollection.Clear(); // for now we are only adding one camera
            this._camsFQIDsCollection.Add(fQIDCamera);



            // From CoPilot
            //// Get the camera FQID
            //FQID cameraFQID = Configuration.Instance.GetItems(Item.ItemType.Camera, true).FirstOrDefault().FQID;
            //// Add the camera to the collection
            //_cameraSetLayoutAndCamerasFQIDCollection.Add(cameraFQID);
            //_cameraRemoveCamerasFQIDCollection.Add(cameraFQID);
            //_cameraSetCamerasFQIDCollection.Add(cameraFQID);

            // From MS sample
            //"selectCameraSetCamerasButton":
            //        SelectCameraToListBox(selectCameraSetCamerasButton, cameraToShowSetCamerasListBox, _cameraSetCamerasFQIDCollection);
            //if (_positionInViewSetCameras != default(decimal) && _monitorSetCamerasFQID != null)
            //    sendSetCamerasButton.Enabled = true;



            //// trying to obtain the camera FQID...
            //List<Guid> listGuidsKindsFilter = new List<Guid> { Kind.Camera };
            //IEnumerable<Item> items = Configuration.Instance.GetItems();



            //itemPicker = new ItemPickerWpfWindow()
            //{
            //    KindsFilter = new List<Guid> { Kind.Camera },
            //    SelectionMode = SelectionModeOptions.AutoCloseOnSelect,
            //    Items = Configuration.Instance.GetItems()
            //};

            //if (itemPicker.ShowDialog().Value)
            //{
            //    _selectedItem = itemPicker.SelectedItems.First();
            //    button.Text = "Select more cameras";
            //    _cameraSetCamerasFQIDCollection.Add(_selectedItem.FQID);
            //    listBox.Items.Add(_selectedItem.Name);
            //}

        }

        private void selectMonitor(FQID fQIDMonitor)
        {
            this._monitorFQID = fQIDMonitor;

            // From CoPilot
            //"selectMonitorSetCamerasButton":
            //        _monitorSetCamerasFQID = SelectItem(Kind.VideoWallMonitor, selectMonitorSetCamerasButton);
            //if (_cameraSetCamerasFQIDCollection.Count != 0 && _positionInViewSetCameras != default(decimal))
            //    sendSetCamerasButton.Enabled = true;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fQIDCamera"></param>
        /// <param name="fQIDMonitor"></param>
        /// <param name="nPosition"></param>
        private void sendCameraToMonitor(FQID fQIDCamera, FQID fQIDMonitor, int nPosition)
        {
            this._camsFQIDsCollection.Add(fQIDCamera);

            VideoWallSetCamerasCommandData vWSetCamsCmdDataSettings = new VideoWallSetCamerasCommandData
            {
                CameraFQIDList = _camsFQIDsCollection,
                Position = nPosition,
            };
            msg = new VideoOS.Platform.Messaging.Message(MessageId.Control.VideoWallSetCamerasCommand, vWSetCamsCmdDataSettings);
            Collection<object> objects = EnvironmentManager.Instance.SendMessage(msg, fQIDMonitor);

            Console.WriteLine("Message sent to monitor: " + fQIDMonitor.ObjectId.ToString()+". Response:");   

            foreach (object obj in objects)
            {
                Console.WriteLine("\t"+obj.ToString());
            }

            //EnvironmentManager.Instance.SendMessage(msg, _monitorFQID);


            this._camsFQIDsCollection.Clear();


            // From MS sample
            //case "sendSetCamerasButton":
            //VideoWallSetCamerasCommandData settings = new VideoWallSetCamerasCommandData
            //{
            //    CameraFQIDList = _cameraSetCamerasFQIDCollection,
            //    Position = (int)_positionInViewSetCameras,
            //};
            //msg = new VideoOS.Platform.Messaging.Message(MessageId.Control.VideoWallSetCamerasCommand, settings);
            //EnvironmentManager.Instance.SendMessage(msg, _monitorSetCamerasFQID);
            //_cameraSetCamerasFQIDCollection.Clear();
            //sendSetCamerasButton.Enabled = false;
            //cameraToShowSetCamerasListBox.Items.Clear();
            //selectCameraSetCamerasButton.Text = "Select camera";

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="destination"></param>
        /// <param name="sender"></param>
        /// <returns></returns>
        private object VideoWallMessageCommunicationHandler(VideoOS.Platform.Messaging.Message message, FQID destination, FQID sender)
        {

            

            var data = message.Data as VideoWallIndicationData;
            var reason = message.Reason;
            var relatedFqid = message.RelatedFQID;
            var action = data.ActionId;
            var itemFQID = data.FQID;
            string strItemKind = null;


            Console.WriteLine($"Message({message.MessageId.ToString()}) received from: {sender?.ObjectId.ToString()} to: {destination?.ObjectId.ToString()}");
            //Console.WriteLine("\tSender     : " + sender?.ToString());
            //Console.WriteLine("\tDestination: " + destination?.ToString());
            //Console.WriteLine("\tMessage: " + reason + " RelatedFQID: "+ relatedFqid.ObjectId.ToString());


            if (itemFQID.Kind == Kind.VideoWall)
            {
                strItemKind = "Smart wall";
            }
            else if (itemFQID.Kind == Kind.VideoWallMonitor)
            {
                strItemKind = "Smart wall monitor";
            }
            else if (itemFQID.Kind == Kind.View)
            {
                strItemKind = "View";
            }

            if (string.Equals(action, "DELETED") || itemFQID.Kind == Kind.View)
            {
                Console.WriteLine(string.Format(@"{0}  Message (DEL or View): {1} of GUID: {2} is {3} ParentId: {4}", DateTime.Now, strItemKind, itemFQID.ObjectId.ToString(), action, itemFQID.ParentId), data);
            }
            else
            {
                Console.WriteLine(string.Format(@"{0}  Message: {1} {2} is {3}", DateTime.Now, strItemKind, Configuration.Instance.GetItem(itemFQID).Name, action), data);
            }

            return null;
        }


        /// <summary>
        /// Should be called when the application is closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Finish(object sender, EventArgs e)
        {
            _messageCommunication.UnRegisterCommunicationFilter(_msgComRec);
            VideoOS.Platform.SDK.Environment.RemoveAllServers();
        }
    }
}
