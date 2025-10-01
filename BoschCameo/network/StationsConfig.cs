using CSharpRuntimeCameo.Properties;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;


namespace CSharpRuntimeCameo.network
{
    class StationsConfig
    {
        public DataSet ds_stations;


        /// <summary>
        /// 
        /// </summary>
        public StationsConfig()
        {
            try
            {
                ds_stations = new DataSet();
                ds_stations.ReadXml(Application.StartupPath + @"\Stations.xml");

            }
            catch (Exception)
            {
#if DEBUG
                throw;
#endif
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SaveSettings()
        {
            try
            {
                ds_stations.WriteXml(Application.StartupPath + @"\Stations.xml");
                return true;
            }
            catch
            {
#if DEBUG
                throw;
#endif
            }

            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ArrayList GetStationGroupsArray()
        {
            ArrayList arrGrp = new ArrayList();

            try
            {
                foreach (DataRow drDMT in ds_stations.Tables["dmt"].Rows)
                {
                    foreach (DataRow drRoot in ds_stations.Tables["Node"].Select("DMT_Id=" + drDMT["DMT_Id"].ToString()))
                    {

                        MyObject obj = new MyObject(null);

                        GetMyProperties(Convert.ToInt32(drRoot["node_Id"].ToString()), ref obj);


                        if (obj.Type == eType.Station)
                        {
                            obj.StationName = obj.Name;
                        }


                        GetMyObjects(Convert.ToInt32(drRoot["node_Id"].ToString()), ref obj);

                        arrGrp.Add(obj);
                        Application.DoEvents();
                    }
                }
            }
            catch (Exception exc)
            {
#if DEBUG
                throw exc;
#endif
            }

            return arrGrp;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="stPO_Name"></param>
        /// <param name="iPO_StationID"></param>
        /// <returns></returns>
        public bool GetMyCodecParams(ref string stPO_Name, ref int iPO_StationID)
        {
            try
            {
                stPO_Name = ds_stations.Tables["DMT"].Rows[0]["po_name"].ToString();
                iPO_StationID = Convert.ToInt32(ds_stations.Tables["DMT"].Rows[0]["station"]);
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="iID"></param>
        /// <param name="myObj"></param>
        public void GetMyProperties(int iID, ref MyObject myObj)
        {
            try
            {
                myObj.LiveStream = Settings.LiveVideoStream;

#if DEBUG
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
#endif


                foreach (DataRow drProp in ds_stations.Tables["Property"].Select("node_id=" + iID))
                {
                    switch (drProp["name"].ToString())
                    {


                        case "obj_id":
                            myObj.ID = Convert.ToInt32(drProp["property_text"]);
                            break;



                        case "type":
#if DEBUG
                            Console.WriteLine(myObj.ID + " - " + myObj.Name + " (" + myObj.Address + ") type drProp[\"property_text\"]: " + drProp["property_text"].ToString());
#endif
                            myObj.Type = GetTypeFromString(drProp["property_text"].ToString());
                            myObj.MainType = myObj.Type;

#if DEBUG
                            Console.WriteLine("\t" + myObj.ID + " - " + myObj.Name + " (" + myObj.Address + ") type: " + myObj.Type);
#endif

                            break;



                        case "name":
                            myObj.Name = drProp["property_text"].ToString();
                            break;



                        case "commsettings":
                            string[] st1 = drProp["property_text"].ToString().Split('@');
                            string stTemp;
                            stTemp = st1[0];

                            if (st1.Length > 1) // we've User [/ Password]
                            {
                                string[] stUserPass = st1[0].Split(':');

                                myObj.UserName = stUserPass[0];

                                if (stUserPass.Length > 1)
                                {
                                    myObj.Password = stUserPass[1];
                                }

                                stTemp = st1[1];
                            }


                            //
                            // Here, already like: address[:port][:cam id / input]
                            string[] st = stTemp.Split(':');

                            myObj.CommSettings = st[0];
                            myObj.Address = st[0];


                            int iCamId = 0;
                            myObj.Port = 0;

                            if (st.Length == 2)
                            {
                                if (myObj.Class == eClass.VideoRecorder)
                                {
                                    // :port
                                    myObj.Port = MyConvert.ToInt32(st[1], -1);
                                }
                                else
                                {
                                    // :camid/input
                                    iCamId = MyConvert.ToInt32(st[1], 1);
                                }
                            }
                            else if (st.Length == 3)
                            {
                                // :port:camid/input
                                myObj.Port = MyConvert.ToInt32(st[1], -1);
                                // :camid/input
                                iCamId = MyConvert.ToInt32(st[2], 1);
                            }

                            myObj.CameraInput = iCamId;

                            if (myObj.CameraID == 0)
                            {
                                myObj.CameraID = iCamId;
                            }

                            break;



                        case "specific_config":
                            // ID$#|PS$#|TS$#|ZS$#|RecProfile$#|RecNQ$#|RecHQ$#|JC&lt;..&gt;|ONVIF_URI$%|ONVIF_ProfileToken$%|RecSrcID$%|RecSrcAddr$%|ReplayTrackId$%|
                            myObj.SpecSettings = drProp["property_text"].ToString();

                            myObj.ONVIFURI = Settings.GetSpecificParam(myObj.SpecSettings, "ONVIF_URI", '|', '$');
                            myObj.ONVIF_ProfileToken = Settings.GetSpecificParam(myObj.SpecSettings, "ONVIF_ProfileToken", '|', '$');
                            myObj.RecSrcId = Settings.GetSpecificParam(myObj.SpecSettings, "RecSrcID", '|', '$');
                            myObj.RecSrcAddress = Settings.GetSpecificParam(myObj.SpecSettings, "RecSrcAddr", '|', '$');

                            if ((myObj.Type == eType.CamONVIF
                                ||
                                myObj.MainType == eType.CamONVIF)
                               &&
                               (myObj.RecSrcAddress != null && !myObj.RecSrcAddress.Equals(string.Empty)
                                ||
                                myObj.RecSrcId != null && !myObj.RecSrcId.Equals(string.Empty)))
                            {
                                // we assume we R dealing with an ONVIF camera and its protocol & ProgID R ..
                                myObj.ModelProtocol = MyObject.STR_ONVIF_PROTOCOL;
                                myObj.ProgID = MyObject.STR_ONVIF_PROGID;

                                //ONVIFHelper.AddEquipment(obj)
                            }


                            int iParam;
                            int.TryParse(Settings.GetSpecificParam(myObj.SpecSettings, "ID", '|', '$'), out iParam);
                            myObj.CameraID = iParam;


                            iParam = 0;
                            int.TryParse(Settings.GetSpecificParam(myObj.SpecSettings, "VidIn", '|', '$'), out iParam);
                            myObj.VideoIn = iParam;


                            iParam = 0;
                            int.TryParse(Settings.GetSpecificParam(myObj.SpecSettings, "VidOut", '|', '$'), out iParam);
                            myObj.VideoOut = iParam;


                            iParam = 0;
                            int.TryParse(Settings.GetSpecificParam(myObj.SpecSettings, "Decoder", '|', '$'), out iParam);
                            myObj.Decoder = (short)iParam;


                            iParam = 0;
                            int.TryParse(Settings.GetSpecificParam(myObj.SpecSettings, "PS", '|', '$'), out iParam);
                            myObj.PanSpeed = iParam;
                            iParam = 0;


                            int.TryParse(Settings.GetSpecificParam(myObj.SpecSettings, "TS", '|', '$'), out iParam);
                            myObj.TiltSpeed = iParam;
                            iParam = 0;
                            int.TryParse(Settings.GetSpecificParam(myObj.SpecSettings, "ZS", '|', '$'), out iParam);
                            myObj.ZoomSpeed = iParam;


                            iParam = 0;
                            int.TryParse(Settings.GetSpecificParam(myObj.SpecSettings, "LiveStream", '|', '$'), out iParam);
                            if (iParam > 0)
                            {
                                myObj.LiveStream = iParam;
                            }


                            iParam = 0;
                            int.TryParse(Settings.GetSpecificParam(myObj.SpecSettings, "Multicast", '|', '$'), out iParam);
                            myObj.Multicast = iParam;


                            string[] stPTZFileSettings = Settings.GetSpecificParam(myObj.SpecSettings, "PTZF", '|', '$').ToString().Split(',');
                            bool bResult = false;
                            int iOut = 0;

                            switch (stPTZFileSettings.Length)
                            {
                                case 0:
                                    myObj.PTZEnabled = false;
                                    break;
                                case 1:
                                    bResult = Convert.ToBoolean(Int32.TryParse(stPTZFileSettings[0], out iOut) ? iOut : 0);
                                    myObj.PanEnabled = bResult;
                                    bResult = false;
                                    break;
                                case 2:
                                    bResult = Convert.ToBoolean(Int32.TryParse(stPTZFileSettings[0], out iOut) ? iOut : 0);
                                    myObj.PanEnabled = bResult;
                                    bResult = false;
                                    bResult = Convert.ToBoolean(Int32.TryParse(stPTZFileSettings[1], out iOut) ? iOut : 0);
                                    myObj.TiltEnabled = bResult;
                                    bResult = false;
                                    break;
                                case 3:
                                    bResult = Convert.ToBoolean(Int32.TryParse(stPTZFileSettings[0], out iOut) ? iOut : 0);
                                    myObj.PanEnabled = bResult;
                                    bResult = false;
                                    bResult = Convert.ToBoolean(Int32.TryParse(stPTZFileSettings[1], out iOut) ? iOut : 0);
                                    myObj.TiltEnabled = bResult;
                                    bResult = false;
                                    bResult = Convert.ToBoolean(Int32.TryParse(stPTZFileSettings[2], out iOut) ? iOut : 0);
                                    myObj.ZoomEnabled = bResult;
                                    bResult = false;
                                    break;
                                case 4:
                                    bResult = Convert.ToBoolean(Int32.TryParse(stPTZFileSettings[0], out iOut) ? iOut : 0);
                                    myObj.PanEnabled = bResult;
                                    bResult = false;
                                    bResult = Convert.ToBoolean(Int32.TryParse(stPTZFileSettings[1], out iOut) ? iOut : 0);
                                    myObj.TiltEnabled = bResult;
                                    bResult = false;
                                    bResult = Convert.ToBoolean(Int32.TryParse(stPTZFileSettings[2], out iOut) ? iOut : 0);
                                    myObj.ZoomEnabled = bResult;
                                    bResult = false;
                                    bResult = Convert.ToBoolean(Int32.TryParse(stPTZFileSettings[3], out iOut) ? iOut : 0);
                                    myObj.FocusEnabled = bResult;
                                    bResult = false;
                                    break;
                            }

#if DEBUG
                            Console.WriteLine("MyObject id=" + myObj.ID + " class=" + myObj.Class + " MainType=" + myObj.MainType + " Type=" + myObj.Type);
#endif

                            if (myObj.Class == eClass.Camera)
                            {
                                if (myObj.PanEnabled || myObj.TiltEnabled)
                                {
                                    myObj.PTZEnabled = true;
                                    myObj.Type = eType.PTZ;
                                }
                                else
                                {
                                    myObj.PTZEnabled = false;
                                    myObj.Type = eType.Fixed;
                                }
#if DEBUG
                                Console.WriteLine("\t\tIt's a camera and now id=" + myObj.ID + " class=" + myObj.Class + " MainType=" + myObj.MainType + " Type=" + myObj.Type);
#endif
                            }


                            iParam = 0;
                            int.TryParse(Settings.GetSpecificParam(myObj.SpecSettings, "InCamRec", '|', '$'), out iParam);
                            myObj.InCamRecEnabled = Convert.ToBoolean(iParam);


                            myObj.InCamRecMode = Settings.GetSpecificParam(myObj.SpecSettings, "InCamRecMode", '|', '$').ToString();


                            ////////////////////////////////////////////////////////////////////////////////
                            //
                            // The https$OFF or https$ON prop/value can be present in the specific config of
                            // the equip BUT can be missing and if so, MyObject.HttpsOn should B null...
                            //
                            string strHttps = Settings.GetSpecificParam(myObj.SpecSettings, "https", '|', '$');

                            if (string.Empty.Equals(strHttps))
                            {
                                myObj.HttpsOn = null;

                                myObj.ConnProtocol = string.Empty;
                            }
                            else
                            {
                                myObj.HttpsOn = strHttps.ToLowerInvariant() == "on";

                                myObj.ConnProtocol = myObj.HttpsOn == true ? "https://" : "http://";
                            }
                            ////////////////////////////////////////////////////////////////////////////////


                            // we're going to give PRECEDENCE to the RtpSession and Model TAGs
                            myObj.RtpSession = Settings.GetSpecificParam(myObj.SpecSettings, "RtpSession", '|', '$');

                            if (myObj.RtpSession != null && !myObj.RtpSession.Equals(""))
                            {
                                myObj.ProgID = ""; // let the SDK choose
                            }


                            myObj.ModelProtocol = Settings.GetSpecificParam(myObj.SpecSettings, "Model", '|', '$');


                            //
                            // Protocol - this value could B already set cause the "https" spceific config tag. This'll override it...
                            string strConnProtocol = Settings.GetSpecificParam(myObj.SpecSettings, "Protocol", '|', '$');

                            if (strConnProtocol.Length > 0)
                            {
                                myObj.ConnProtocol = !strConnProtocol.EndsWith("://") ? strConnProtocol + "://" : strConnProtocol;
                            }


                            //
                            // ReplayTrackId$%
                            iParam = int.MinValue;
                            int.TryParse(Settings.GetSpecificParam(myObj.SpecSettings, "ReplayTrackId", '|', '$'), out iParam);
                            myObj.InternalCameraTrackId = iParam > 0 ? iParam : int.MinValue;


                            //
                            // ReplayExtractionEnabled$%
                            iParam = int.MinValue;
                            string strReplayExtractionEnabled = Settings.GetSpecificParam(myObj.SpecSettings, "ReplayExtractionEnabled", '|', '$');

                            if (strReplayExtractionEnabled != null && strReplayExtractionEnabled.Length > 0)
                            {
                                int.TryParse(strReplayExtractionEnabled, out iParam);
                                myObj.IsNoVrmCommReplayExtractionActive = iParam > 0;
                            }


                            break;



                        case "visible":
                            myObj.Visible = (drProp["property_text"].ToString() == "1") ? true : false;
                            break;



                        case "class":
                            myObj.Class = GetClassFromString(drProp["property_text"].ToString());
                            break;



                        case "position":
                            myObj.Position = Convert.ToInt32(drProp["property_text"]);
                            break;



                        case "enabled":
                            if (Convert.ToInt32(drProp["property_text"]) == 1)
                            {
                                myObj.Enabled = true;
                            }
                            break;



                        case "protocol": // ??????????? the XML has no "protocol" field.... "neber"...
                            myObj.ModelProtocol = drProp["property_text"].ToString();
                            break;



                        case "camid":
                            myObj.CameraID = MyConvert.ToInt32(drProp["property_text"].ToString(), 1);
                            break;



                        //case "redundancy":
                        //    myObj.Redundancy = drProp["property_text"].ToString();
                        //    break;



                        //case "videorecorders":
                        //    myObj.Videorecorders = drProp["property_text"].ToString();
                        //    break;



                        //case "storages":
                        //    myObj.Storages = drProp["property_text"].ToString();
                        //    break;


                    }
                    Application.DoEvents();
                }

                myObj.Status = eStatus.Off;


                // Add MyObject to a global (static ;-) ) dictionary...
                MyObject.Add(myObj);

#if DEBUG
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
#endif


            }
            catch (Exception)
            {
#if DEBUG
                throw;
#endif
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        private eClass GetClassFromString(string st)
        {
            try
            {
                switch (st)
                {
                    case "group":
                        return eClass.Group;
                    case "station":
                        return eClass.Station;
                    case "station_zone":
                        return eClass.StationZone;
                    case "sound_zone":
                        return eClass.SoundZone;
                    case "codec":
                        return eClass.Codec;
                    case "amplifier":
                        return eClass.Amplifier;
                    case "camera":
                        return eClass.Camera;
                    case "monitor":
                        return eClass.Monitor;
                    case "videorecorder":
                        return eClass.VideoRecorder;
                    case "videostorage":
                        return eClass.VideoStorage;
                }
            }
            catch (Exception)
            {
#if DEBUG
                throw;
#endif
            }
            return eClass.Undef;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        private eType GetTypeFromString(string st)
        {
            try
            {
                switch (st)
                {
                    case "group":
                        return eType.Group;
                    case "station":
                        return eType.Station;
                    case "station_zone":
                        return eType.StationZone;
                    case "sound_zone":
                        return eType.SoundZone;

                    case "Hitplayer codec":     // ?????????
                        return eType.HitPlayer;

                    case "Crest amplifier":     // ?????????
                        return eType.Crest;


                    case "Scada amplifier":
                        return eType.Scada;

                    //case "PTZF Bosch":
                    //    return eType.PTZ;
                    case "Camera ONVIF":
                    case "ONVIF Camera":
                        return eType.CamONVIF;
                    case "NVR Bosch":
                        return eType.NVR_Bosch;
                    case "DVA Bosch":
                        return eType.DVA_Bosch;
                    case "videorecorder":
                        return eType.VideoRecorder;
                }
            }
            catch (Exception)
            {
#if DEBUG
                throw;
#endif
            }

            return eType.Undef;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="iID"></param>
        /// <param name="obj"></param>
        public void GetMyObjects(int iID, ref MyObject obj)
        {
            try
            {
                foreach (DataRow drObj in ds_stations.Tables["Node"].Select("node_id_0=" + iID))
                {

                    MyObject obj2 = new MyObject(obj);

                    GetMyProperties(Convert.ToInt32(drObj["node_Id"].ToString()), ref obj2);


                    if (obj2.Type == eType.Station)
                    {
                        obj2.StationName = obj2.Name;
                    }
                    else
                    {
                        obj2.StationName = obj.StationName;
                    }


                    // If disabled, all its nodes will also be disabled
                    if (!obj.Enabled)
                    {
                        obj2.Enabled = false;
                    }


                    // If invisible, all its nodes will also be invisible
                    if (!obj.Visible)
                    {
                        obj2.Visible = false;
                    }

                    GetMyObjects(Convert.ToInt32(drObj["node_Id"].ToString()), ref obj2);

                    obj.arrObjects.Add(obj2);

                    Application.DoEvents();

                }

                obj.arrObjects = ReorderObjects(obj.arrObjects);
                
                
                
                
                //SendToCodecsArray(obj);





            }
            catch (Exception)
            {
#if DEBUG
                throw;
#endif
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static ArrayList ReorderObjects(ArrayList arr)
        {
            try
            {
                for (int i = 0; i < arr.Count; i++)
                {
                    for (int j = i; j >= 1; j--)
                    {
                        MyObject moAct = (MyObject)arr[j];
                        MyObject moAnt = (MyObject)arr[j - 1];
                        if (moAct.Position < moAnt.Position)
                        {
                            MyObject moTemp = moAnt;
                            arr[j - 1] = moAct;
                            arr[j] = moTemp;
                        }
                        Application.DoEvents();
                    }
                    Application.DoEvents();
                }

                return arr;
            }
            catch { return arr; }
        }


//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="myObj"></param>
//        private static void SendToCodecsArray(MyObject myObj)
//        {
//            try
//            {

//                if (myObj.IsOnvifEquipment())
//                {
//                    return;
//                }

//                if ((myObj.Class != eClass.Camera) && (myObj.Class != eClass.Monitor) && (myObj.Class != eClass.VideoStorage) && (myObj.Class != eClass.VideoRecorder))
//                {
//                    return;
//                }

//                if ((myObj.Class == eClass.VideoRecorder) && (myObj.Type == eType.VideoRecorder))
//                {
//                    return;
//                }

//                bool bFoundIp = false;

//                if ((myObj.Class == eClass.Camera))
//                {
//                    if ((myObj.Enabled == false) || (myObj.Visible == false))
//                    {
//                        return;
//                    }

//                    if (Settings.OptimizePolling)
//                    {
//                        if (frmMain.MainForm.listInputCodecs == null)
//                        {
//                            frmMain.MainForm.listInputCodecs = new ArrayList();
//                        }

//                        for (int j = 0; j < frmMain.MainForm.listInputCodecs.Count; j++)
//                        {
//                            object obj2 = frmMain.MainForm.listInputCodecs[j];
//                            Codec codec = (Codec)obj2;

//                            if (codec.IP == myObj.CommSettings)
//                            {
//                                bFoundIp = true;

//                                if ((myObj.Class == eClass.Camera) && (myObj.CameraInput > 0))
//                                {
//                                    bool bFoundPort = false;
//                                    for (int i = 0; i < codec.Inputs.Count; i++)
//                                    {
//                                        if (Convert.ToInt32(codec.Inputs[i]) == myObj.CameraInput)
//                                        {
//                                            bFoundPort = true;
//                                            return;
//                                        }
//                                    }

//                                    if (!bFoundPort)
//                                    {
//                                        if ((myObj.Class == eClass.Camera) && (myObj.CameraInput != 0))
//                                        {
//                                            codec.Inputs.Add(myObj.CameraInput);
//                                        }

//                                        codec.Objects.Add(myObj);
//                                    }

//                                    return;
//                                }
//                            }
//                            Application.DoEvents();
//                        }

//                        if (!bFoundIp)
//                        {

//                            Codec codec = new Codec(myObj.ID);
//                            codec.Protocol = myObj.ConnProtocol;
//                            codec.IP = myObj.CommSettings;
//                            codec.Port = myObj.Port;
//                            codec.Password = myObj.Password;
//                            codec.Username = myObj.UserName;
//                            codec.FullUrl = myObj.FullUrl;

//                            if (myObj.Class == eClass.VideoRecorder)
//                            {
//                                codec.Inputs.Add(1);
//                            }
//                            else
//                            {
//                                codec.Inputs.Add(myObj.CameraInput);
//                            }

//                            codec.Type = Codec.CodecType.etInput;
//                            codec.Objects.Add(myObj);
//                            frmMain.MainForm.listInputCodecs.Add(codec);
//                        }
//                    }
//                    // Só para teste para grande n de ligação tcp
//                    else
//                    {
//                        if (frmMain.MainForm.listInputCodecs == null)
//                        {
//                            frmMain.MainForm.listInputCodecs = new ArrayList();
//                        }

//                        Codec codec = new Codec(myObj.ID);
//                        codec.Protocol = myObj.ConnProtocol;
//                        codec.IP = myObj.CommSettings;
//                        codec.Port = myObj.Port;
//                        codec.Password = myObj.Password;
//                        codec.Username = myObj.UserName;
//                        codec.FullUrl = myObj.FullUrl;


//                        if (myObj.Class == eClass.VideoRecorder)
//                        {
//                            codec.Inputs.Add(1);
//                        }
//                        else
//                        {
//                            codec.Inputs.Add(myObj.CameraInput);
//                        }

//                        codec.Type = Codec.CodecType.etInput;
//                        codec.Objects.Add(myObj);
//                        frmMain.MainForm.listInputCodecs.Add(codec);
//                    }
//                }
//                else
//                {
//                    if (frmMain.MainForm.listNonInputCodecs == null)
//                    {
//                        frmMain.MainForm.listNonInputCodecs = new ArrayList();
//                    }

//                    for (int j = 0; j < frmMain.MainForm.listNonInputCodecs.Count; j++)
//                    {
//                        object obj2 = frmMain.MainForm.listNonInputCodecs[j];
//                        Codec c = (Codec)obj2;

//                        if (c.IP == myObj.CommSettings)
//                        {
//                            bFoundIp = true;


//                            for (int i = 0; i < c.Inputs.Count; i++)
//                            {
//                                if (Convert.ToInt32(c.Inputs[i]) == myObj.CameraInput)
//                                {
//                                    return;
//                                }
//                            }


//                            if (myObj.Class == eClass.Monitor)
//                            {
//                                c.Inputs.Add(myObj.CameraInput);
//                            }

//                            c.Objects.Add(myObj);

//                        }
//                        Application.DoEvents();
//                    }

//                    if (!bFoundIp)
//                    {

//                        Codec codec = new Codec(myObj.ID);
//                        codec.Protocol = myObj.ConnProtocol;
//                        codec.IP = myObj.CommSettings;
//                        codec.Port = myObj.Port;
//                        codec.Password = myObj.Password;
//                        codec.Username = myObj.UserName;
//                        codec.FullUrl = myObj.FullUrl;


//                        if (myObj.Class == eClass.Monitor)
//                        {
//                            codec.Inputs.Add(myObj.CameraInput);
//                            codec.Type = Codec.CodecType.etOutput;
//                        }
//                        else if (myObj.Class == eClass.VideoStorage)
//                        {
//                            codec.Type = Codec.CodecType.etVideoStorage;
//                        }
//                        else if (myObj.Class == eClass.VideoRecorder)
//                        {
//                            codec.Inputs.Add(myObj.CameraInput);
//                            codec.Type = Codec.CodecType.etVideoRecorder;
//                        }

//                        if ((myObj.Class == eClass.VideoStorage) && (myObj.Type == eType.DVA_Bosch))
//                        {
//                            codec.bPingOnly = true;
//                        }

//                        codec.Objects.Add(myObj);
//                        frmMain.MainForm.listNonInputCodecs.Add(codec);
//                    }
//                }
//            }
//            catch
//            {
//#if DEBUG
//                throw;
//#endif            
//            }
//        }
    }


}
