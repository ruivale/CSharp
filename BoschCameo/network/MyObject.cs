using Bosch.VideoSDK.Live;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CSharpRuntimeCameo.network
{
    public enum eStatus { On, Off, Dif }
    public enum eType { Undef, Group, Station, StationZone, SoundZone, HitPlayer, Crest, Scada, Fixed, PTZ, CamONVIF, NVR_Bosch, DVA_Bosch, VideoRecorder }
    public enum eClass { Undef, Group, Station, StationZone, SoundZone, Codec, Amplifier, Camera, Monitor, VideoRecorder, VideoStorage }

    public delegate void RefreshCallback();

    public class MyObject
    {

        #region /////// PROPERTIES VARIABLES///////
        /// <summary>
        /// ProgID to be used when connecting an ONVIF camera.
        /// </summary>
        public static string STR_ONVIF_PROGID = "GCA.ONVIF.DeviceProxy";
        public static string STR_ONVIF_DEVICE_URI = "/onvif/device_service";
        public static string STR_ONVIF_PROTOCOL = "http";

        public static string STR_RTSP_PROTOCOL = "rtsp";


        private static readonly string STR_CAM_VIDIN_NAME_JUNCTION = "_";

        private static readonly char CH_REDUNDANCY_VALUES_SEPARATOR = '|';
        private static readonly char CH_REDUNDANCY_TAG_VALUES_SEPARATOR = ';';

        private static readonly char CH_LIST_EQUIP_IDS_VALUES_SEPARATOR = ';';


        // Used to retrieve info from the redundancy xml prop node for videorecorders signalling this object has a main VR.
        private static readonly string STR_MAIN_DUAL_VR = "MainDualVR";
        // Used to retrieve info from the redundancy xml prop node for videorecorders. These're this object secondary VRs.
        private static readonly string STR_SEC_VR = "SecVR$";
        // Used to retrieve info from the redundancy xml prop node for videorecorders. These're this object main VRs.
        private static readonly string STR_MAIN_VR = "MainVR$";


        // The collection of ALL MyObjects in the system...
        private static Dictionary<int, MyObject> dicMyObjects = new Dictionary<int, MyObject>(512);

        // The collection of ALL cameras in the system...
        private static Dictionary<string, MyObject> dicMyObjectCams = new Dictionary<string, MyObject>(512);




        private MyObject Owner;
        public ArrayList arrObjects;

        private int iID;
        private int nPort;
        private eType etType;
        private eType mainType;
        private string stName;
        private string stStation;
        private string stComSettings;
        private string stAddress;
        private string stConnProtocol;
        private string stSpecSettings;
        private string stUser;
        private string stPassword;
        private string stProtocol = "Bosch-AutoDome";

        private string stProgID = "";

        private string stONVIFURI;
        private string stONVIF_ProfileToken;
        private string stRecSrcId;
        private string stRecSrcAddress;

        /// <summary>
        /// If configured in the camera specific config, it's meant to be used to start replays, 
        /// directly from the camera's SDCard, for the track Id that matches this value.
        /// </summary>
        private int iInternalCameraTrackId = int.MinValue;

        /// Normally, extracting records directly from cameras, through active replays, it's not possible when no communicaX
        /// are available between the camera and VRM/iSCSI. This prop enables/disables, globally, the extraction buttons.
        private Nullable<bool> isNoVrmCommReplayExtractionActive = null;


        private int iCamId;
        private int iInput;
        private int iVideoIn;
        private int iVideoOut;
        private short iDecoder;
        private eClass ecClass;
        private int iPosition;
        private bool bVisible;
        private bool hasConn;
        private eStatus ssStatus;
        private bool bEnabled;
        private int iHomePosition = 0;
        private eStatus esAlarm;
        public MyObject ActualCamera = null;

        private int iPanSpeed;
        private int iTiltSpeed;
        private int iZoomSpeed;

        private bool bPanEnabled = false;
        private bool bTiltEnabled = false;
        private bool bZoomEnabled = false;
        private bool bFocusEnabled = false;
        private string stPTZFSettings = "";
        private bool bPTZEnabled = false;
        private int iMulticast = 0;
        private bool bInCamRecEnabled = false;
        private string stInCamRecMode = "";

        private bool bSequencePaused;
        private bool bSequenceActionFailed = false;
        private bool bSequenceActionConnecting = false;
        private int iSequenceActionFailedIndex;
        private int iSyncSequence;
        private int iSyncElapsed;
        private int iTempSeconds;
        private int iTimeElapsed;
        private int iFailedConnections;

        private System.Timers.Timer tSequenceTimer;
        private CameraController cCamController;


        // Normally, can have TAGs: MainDualVR, SecVR and MainVR
        private string stRedundancy = "";
        // List of videorecorders the camera, if one, can be connected to.
        private string stVideorecorders = "";

        // List of videorecorder's videostorages.
        private string stStorages = "";

        // true if this VideoRecorder, if it's one, is a main VideoRecorder.
        private bool isMainDualVR = false;
        // all secondary VideoRecorders associated w/ this one, if it's one
        private int[] arrSecVRs;
        // all main VideoRecorders associated w/ this one, if it's one
        private int[] arrMainVRs;

        // all videorecorders associated w/ this camera, it's one
        private int[] arrVideoRecorders;

        // all videorecorder's associated videostorages
        private int[] arrVideoStorages;


        private TreeNode treeNode; // Used in the treeview...

        #endregion





        /// <summary>
        /// 
        /// Since Bosch equips allow connections using no "login:pass" or no "login", 
        /// this receives a user_login, analogMon password and analogMon server_host_info. 
        /// If all three parameters are not null and not empty, this method returns login:pass@server
        /// If no password is found, it returns login@server
        /// If no user_login and no password is given, it returns server
        /// 
        /// </summary>
        /// <param name="myObj"></param>
        /// <returns>[protocol][strUser[:strPass]@]strAddress[:nPort]</returns>
        public static string GetURL(MyObject myObj)
        {
            return GetURL(myObj.ConnProtocol, myObj.Address, myObj.Port, myObj.UserName, myObj.Password, myObj.RtpSession);
        }


        /// <summary>
        /// 
        /// Since Bosch equips allow connections using no "login:pass" or no "login", 
        /// this receives a user_login, analogMon password and analogMon server_host_info. 
        /// If all three parameters are not null and not empty, this method returns login:pass@server
        /// If no password is found, it returns login@server
        /// If no user_login and no password is given, it returns server
        /// 
        /// </summary>
        /// <param name="strProtocol"></param>
        /// <param name="strAddress"></param>
        /// <param name="nPort"></param>
        /// <param name="strUser"></param>
        /// <param name="strPass"></param>
        /// <param name="strRtpSession"></param>
        /// <returns>[protocol][strUser[:strPass]@]strAddress[:nPort]</returns>
        public static string GetURL(string strProtocol, string strAddress, int nPort, string strUser, string strPass, string strRtpSession)
        {
            string strURL;

            strUser = strUser != null && strUser.Length > 0 ? strUser : "";
            strPass = strPass != null && strPass.Length > 0 ? strPass : "";

            if (strUser.Length > 0)
            {
                // WITH USER
                if (strPass.Length > 0)
                {
                    // WITH PASS
                    strURL = strUser + ":" + strPass + "@" + strAddress;
                }
                else
                {
                    // NO PASS
                    strURL = strUser + "@" + strAddress;
                }
            }
            else
            {
                strURL = strAddress;
            }


            strURL += (nPort > 0 ? ":" + nPort : string.Empty);



            if (strProtocol?.Length > 0)
            {
                strURL = (strProtocol.IndexOf("://") > 0 ? strProtocol : strProtocol + ".//") + strURL;
            }

            else if (!string.IsNullOrWhiteSpace(strRtpSession))
            {
                strURL =
                    string.Format("{0}://{1}{2}{3}",
                                  MyObject.STR_RTSP_PROTOCOL,
                                  strURL,
                                  strRtpSession.StartsWith("/") ? "" : "/",
                                  strRtpSession);
            }

            return strURL;
        }



        #region /////// PROPERTIES ///////


        public System.Timers.Timer SequenceTimer
        {
            get
            {
                return tSequenceTimer;
            }
            set
            {
                tSequenceTimer = value;
            }
        }

        public CameraController CamController
        {
            get
            {
                return cCamController;
            }
            set
            {
                cCamController = value;
            }
        }

        public bool SequencePaused
        {
            get
            {
                return bSequencePaused;
            }
            set
            {
                bSequencePaused = value;
            }
        }

        public bool SequenceActionFailed
        {
            get
            {
                return bSequenceActionFailed;
            }
            set
            {
                bSequenceActionFailed = value;
            }
        }

        public bool SequenceActionConnecting
        {
            get
            {
                return bSequenceActionConnecting;
            }
            set
            {
                bSequenceActionConnecting = value;
            }
        }
        public int SequenceActionFailedIndex
        {
            get
            {
                return iSequenceActionFailedIndex;
            }
            set
            {
                iSequenceActionFailedIndex = value;
            }
        }
        public int SyncSequence
        {
            get
            {
                return iSyncSequence;
            }
            set
            {
                iSyncSequence = value;
            }
        }

        public int SyncElapsed
        {
            get
            {
                return iSyncElapsed;
            }
            set
            {
                iSyncElapsed = value;
            }
        }

        public int FailedConnections
        {
            get
            {
                return iFailedConnections;
            }
            set
            {
                iFailedConnections = value;
            }
        }

        public int TempSeconds
        {
            get
            {
                return iTempSeconds;
            }
            set
            {
                iTempSeconds = value;
            }
        }

        public int TimeElapsed
        {
            get
            {
                return iTimeElapsed;
            }
            set
            {
                iTimeElapsed = value;
            }
        }



        public string FullUrl
        {
            get
            {
                string strURL = "";


                // trying to figure out if there're credentials to use...
                if ((UserName != null) && (UserName != ""))
                {
                    if ((Password != null) && (Password != ""))
                    {
                        strURL = ":" + Password;
                    }

                    strURL = UserName + strURL + "@";
                }


                // concat username:password, if present, w/ the address...
                strURL += Address;


                // addng the port value, is any, to the end...
                strURL += (Port > 0 ? ":" + Port : string.Empty);


                //
                // if the "Protocol" is set in the specific config, IT PRECEDES ALL OTHER protocol related TAGs
                //
                if (ConnProtocol?.Length > 0)
                {
                    strURL = (ConnProtocol.IndexOf("://") > 0 ? ConnProtocol : ConnProtocol + ".//") + strURL;
                }

                else if (HttpsOn != null)
                {
                    bool isHttpsOn = HttpsOn ?? false;

                    if (isHttpsOn)
                    {
                        strURL = string.Format("https://{0}", strURL);
                    }
                    else
                    {
                        strURL = string.Format("http://{0}", strURL);
                    }
                }

                else if (!string.IsNullOrWhiteSpace(RtpSession))
                {
                    strURL = string.Format("{0}://{1}{2}{3}"
                        , MyObject.STR_RTSP_PROTOCOL
                        , strURL
                        , RtpSession.StartsWith("/") ? "" : "/"
                        , RtpSession);
                }

                else if (IsOnvifEquipment())
                {
                    var onvifUri = (this.ONVIFURI != null && !this.ONVIFURI.Equals("") ? this.ONVIFURI : STR_ONVIF_DEVICE_URI);

                    strURL = string.Format("{0}://{1}{2}{3}"
                        , (this.ModelProtocol != null && !this.ModelProtocol.Equals("") ? this.ModelProtocol : STR_ONVIF_PROTOCOL)
                        , strURL
                        , onvifUri.StartsWith("/") ? "" : "/"
                        , onvifUri);
                }


                return strURL;
            }
        }




        /// <summary>
        /// Checks for ONVIF.
        /// </summary>
        /// <returns>true if this equipment is an ONVIF one</returns>
        public bool IsOnvifEquipment()
        {
            return
                (Type == eType.CamONVIF || MainType == eType.CamONVIF)

                &&

                 (RecSrcId != null && !RecSrcId.Equals(string.Empty) ||
                  RecSrcAddress != null && !RecSrcAddress.Equals(string.Empty) ||
                  ONVIFURI != null && !ONVIFURI.Equals(string.Empty) ||
                  ONVIF_ProfileToken != null && !ONVIF_ProfileToken.Equals(string.Empty));
        }



        /// <summary>
        /// If this is a camera connected to VRM through a Video Stream Gateway (SVG).
        /// </summary>
        /// <returns>true if this is a camera connected to VRM through a SVG.</returns>
        public bool IsVsgCamera()
        {
            return
                this.Class == eClass.Camera
                &&
                (this.Type == eType.Fixed || this.Type == eType.PTZ)
                &&
                this.RecSrcId != null && !this.RecSrcId.Equals(string.Empty)
                &&
                this.RecSrcAddress != null && !this.RecSrcAddress.Equals(string.Empty);
        }

        public int ID
        {
            get
            {
                return iID;
            }
            set
            {
                iID = value;
            }
        }
        public int CameraID
        {
            get
            {
                return iCamId;
            }
            set
            {
                iCamId = value;
            }
        }

        public Boolean? HttpsOn
        {
            get; set;
        }

        public int CameraInput
        {
            get
            {
                if (this.IsOnvifEquipment())
                {
                    return 1;
                }
                else
                {
                    return iInput;
                }
            }
            set
            {
                iInput = value;
            }
        }
        public int VideoIn
        {
            get
            {
                return iVideoIn;
            }
            set
            {
                iVideoIn = value;
            }
        }
        public int VideoOut
        {
            get
            {
                return iVideoOut;
            }
            set
            {
                iVideoOut = value;
            }
        }
        public short Decoder
        {
            get
            {
                return iDecoder;
            }
            set
            {
                iDecoder = value;
            }
        }
        public int HomePosition
        {
            get
            {
                return iHomePosition;
            }
            set
            {
                iHomePosition = value;
            }
        }
        public string Name
        {
            get
            {
                return stName;
            }
            set
            {
                stName = value;
            }
        }
        public string TreeName
        {
            get
            {
                return VideoIn + MyObject.STR_CAM_VIDIN_NAME_JUNCTION + Name;
            }
            set
            {
                stName = value;
            }
        }
        public string MyName
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }
        public string StationName
        {
            get
            {
                return stStation;
            }
            set
            {
                stStation = value;
            }
        }
        public string CommSettings
        {
            get
            {
                return stComSettings;
            }
            set
            {
                stComSettings = value;
            }
        }
        public string Address
        {
            get
            {
                return stAddress;
            }
            set
            {
                stAddress = value;
            }
        }
        public string ConnProtocol
        {
            get
            {
                return stConnProtocol;
            }
            set
            {
                stConnProtocol = value;
            }
        }
        public int Port
        {
            get
            {
                return nPort;
            }
            set
            {
                nPort = value;
            }
        }
        public string SpecSettings
        {
            get
            {
                return stSpecSettings;
            }
            set
            {
                stSpecSettings = value;
            }
        }
        public string UserName
        {
            get
            {
                return stUser;
            }
            set
            {
                stUser = value;
            }
        }
        public string Password
        {
            get
            {
                return stPassword;
            }
            set
            {
                stPassword = value;
            }
        }
        public string ModelProtocol
        {
            get
            {
                return stProtocol;
            }
            set
            {
                stProtocol = value;
            }
        }

        /// <summary>
        /// This is the ProgID to use while connecting using the Bosch VideoSDK.
        /// 
        /// @since 20140206
        /// </summary>
        public string ProgID
        {
            get
            {
                return stProgID;
            }
            set
            {
                stProgID = value;
            }
        }
        /// <summary>
        /// This value indicate the ONVIF device URI. 
        /// After obtaining this service reference, we can obtain all other services, if we need them.
        /// 
        /// @since 20140205
        /// </summary>
        public string ONVIFURI
        {
            get
            {
                return stONVIFURI;
            }
            set
            {
                stONVIFURI = value;
            }
        }
        /// <summary>
        /// This value indicate the ONVIF camera PTZ profile token to use if one wants to control the camera. 
        /// 
        /// @since 20140205
        /// </summary>
        public string ONVIF_ProfileToken
        {
            get
            {
                return stONVIF_ProfileToken;
            }
            set
            {
                stONVIF_ProfileToken = value;
            }
        }
        /// <summary>
        /// The Bosch VRM, to record ONVIF cameras video, must be connected to/with a StreamGateway.
        /// This is the ONVIF camera source ID in its associated StreamGateway.
        /// 
        /// @since 20140205
        /// </summary>
        public string RecSrcId
        {
            get
            {
                return stRecSrcId;
            }
            set
            {
                stRecSrcId = value;
            }
        }
        /// <summary>
        /// The ONVIF camera associated StreamGateway connection point.
        /// 
        /// @since 20140205
        /// </summary>
        public string RecSrcAddress
        {
            get
            {
                return stRecSrcAddress;
            }
            set
            {
                stRecSrcAddress = value.Replace(";", ":");
            }
        }

        /// <summary>
        /// @since 20140205
        /// </summary>
        public int PanSpeed
        {
            get
            {
                return iPanSpeed;
            }
            set
            {
                iPanSpeed = value;
            }
        }
        /// <summary>
        /// @since 20140205
        /// </summary>
        public int TiltSpeed
        {
            get
            {
                return iTiltSpeed;
            }
            set
            {
                iTiltSpeed = value;
            }
        }
        /// <summary>
        /// @since 20140205
        /// </summary>
        public int ZoomSpeed
        {
            get
            {
                return iZoomSpeed;
            }
            set
            {
                iZoomSpeed = value;
            }
        }

        /// <summary>
        /// @since 20200319
        /// </summary>
        public int Multicast
        {
            get
            {
                return iMulticast;
            }
            set
            {
                iMulticast = value;
            }
        }

        /// <summary>
        /// When rtpsession is present it will be added to the end of the url
        /// @since 20200522
        /// </summary>
        public string RtpSession
        {
            get; set;
        }

        /// <summary>
        /// @since 20200319
        /// </summary>
        public string PTZFSettings
        {
            get
            {
                return stPTZFSettings;
            }
            set
            {
                stPTZFSettings = value;
            }
        }
        /// <summary>
        /// @since 20200319
        /// </summary>
        public bool PanEnabled
        {
            get
            {
                return bPanEnabled;
            }
            set
            {
                bPanEnabled = value;
            }
        }

        /// <summary>
        /// @since 20200319
        /// </summary>
        public bool TiltEnabled
        {
            get
            {
                return bTiltEnabled;
            }
            set
            {
                bTiltEnabled = value;
            }
        }

        /// <summary>
        /// @since 20200319
        /// </summary>
        public bool ZoomEnabled
        {
            get
            {
                return bZoomEnabled;
            }
            set
            {
                bZoomEnabled = value;
            }
        }

        /// <summary>
        /// @since 20200319
        /// </summary>
        public bool FocusEnabled
        {
            get
            {
                return bFocusEnabled;
            }
            set
            {
                bFocusEnabled = value;
            }
        }

        /// <summary>
        /// @since 20200319
        /// </summary>
        public bool PTZEnabled
        {
            get
            {
                return bPTZEnabled;
            }
            set
            {
                bPTZEnabled = value;
            }
        }

        /// <summary>
        /// @since 20200319
        /// </summary>
        public bool InCamRecEnabled
        {
            get
            {
                return bInCamRecEnabled;
            }
            set
            {
                bInCamRecEnabled = value;
            }
        }
        /// <summary>
        /// @since 20200319
        /// </summary>
        public string InCamRecMode
        {
            get
            {
                return stInCamRecMode;
            }
            set
            {
                stInCamRecMode = value;
            }
        }

        public eClass Class
        {
            get
            {
                return ecClass;
            }
            set
            {
                ecClass = value;

                if (etType == eType.Undef && ecClass == eClass.Camera)
                {
                    etType = eType.Fixed;
                }
            }
        }
        public eType Type
        {
            get
            {
                return etType;
            }
            set
            {
                if (value != eType.Undef)
                {
                    etType = value;
                }
            }
        }
        public eType MainType
        {
            get
            {
                return mainType;
            }
            set
            {
                mainType = value;
            }
        }
        public int Position
        {
            get
            {
                return iPosition;
            }
            set
            {
                iPosition = value;
            }
        }
        public bool HasConnection
        {
            get
            {
                return hasConn;
            }
            set
            {
                hasConn = value;
            }
        }
        public bool Visible
        {
            get
            {
                return bVisible;
            }
            set
            {
                bVisible = value;
            }
        }
        public eStatus Status
        {
            get
            {
                return ssStatus;
            }
            set
            {
                ssStatus = value;

                if (Owner != null)
                {
                    Owner.Status = value;
                }
            }
        }
        public int ZonesCount
        {
            get
            {
                int i = CountMyZones(arrObjects);
                return i;
            }
        }
        public bool Enabled
        {
            get
            {
                return bEnabled;
            }
            set
            {
                bEnabled = value;
            }
        }
        public eStatus Alarm
        {
            get
            {
                return esAlarm;
            }
            set
            {
                esAlarm = value;
            }
        }


        public bool Online { get; set; }

        public bool FirstAction { get; set; }



        public int LiveStream { get; set; }

        /// <summary>
        /// If configured in the camera specific config, it's meant to be used to start replays, 
        /// directly from the camera's SDCard, for the track Id that matches this value.
        /// </summary>
        public int InternalCameraTrackId
        {
            get
            {
                return this.iInternalCameraTrackId;
            }
            set
            {
                this.iInternalCameraTrackId = value;
            }
        }

        /// <summary>
        /// Normally, extracting records directly from cameras, through active replays, it's not possible when no communicaX
        /// are available between the camera and VRM/iSCSI. This prop enables/disables, specifically for this camera, the extraction buttons.
        /// </summary>
        public Nullable<bool> IsNoVrmCommReplayExtractionActive
        {
            get
            {
                return this.isNoVrmCommReplayExtractionActive;
            }
            set
            {
                this.isNoVrmCommReplayExtractionActive = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public TreeNode TreeNode
        {
            get
            {
                return treeNode;
            }
            set
            {
                treeNode = value;
            }
        }

        #endregion



        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        public MyObject(MyObject owner)
        {
            try
            {
                arrObjects = new ArrayList();

                if (owner != null)
                {
                    Owner = (MyObject)owner;
                }
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
        /// <param name="owner"></param>
        /// <param name="iId"></param>
        /// <param name="etTp"></param>
        /// <param name="stNam"></param>
        /// <param name="stCS"></param>
        /// <param name="stSS"></param>
        /// <param name="ecCls"></param>
        /// <param name="iPos"></param>
        /// <param name="bVis"></param>
        public MyObject(MyObject owner, int iId, eType etTp, string stNam, string stCS, string stSS, eClass ecCls, int iPos, bool bVis)
        {
            try
            {

                if (owner != null)
                {
                    Owner = (MyObject)owner;
                }

                iID = iId;
                etType = etTp;
                mainType = etType;
                stName = stNam;
                stComSettings = stCS;
                stSpecSettings = stSS;
                ecClass = ecCls;
                iPosition = iPos;
                bVisible = bVis;
                ssStatus = eStatus.Off;
                arrObjects = new ArrayList();
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
        /// <param name="iId"></param>
        /// <param name="etTp"></param>
        /// <param name="stNam"></param>
        /// <param name="stCS"></param>
        /// <param name="stSS"></param>
        /// <param name="ecCls"></param>
        /// <param name="iPos"></param>
        /// <param name="bVis"></param>
        public void AddObject(int iId, eType etTp, string stNam, string stCS, string stSS, eClass ecCls, int iPos, bool bVis)
        {
            try
            {
                MyObject obj = new MyObject(this, iId, etTp, stNam, stCS, stSS, ecCls, iPos, bVis);

                arrObjects.Add(obj);
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
        private int CountMyZones(ArrayList arr)
        {
            int iCount = 0;
            try
            {
                for (int i = 0; i < arr.Count; i++)
                {
                    MyObject obj = (MyObject)arr[i];
                    if (obj.Type == eType.SoundZone || obj.Type == eType.StationZone)
                        iCount++;
                }
            }
            catch (Exception)
            {
#if DEBUG
                throw;
#endif

            }

            return iCount;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="myObj"></param>
        internal static void Add(MyObject myObj)
        {
            if (myObj != null)
            {
                MyObject.dicMyObjects[myObj.ID] = myObj;

                if (myObj.Class == eClass.Camera && myObj.Name != null && myObj.Name.Length > 0)
                {
                    MyObject.dicMyObjectCams[myObj.VideoIn + MyObject.STR_CAM_VIDIN_NAME_JUNCTION + myObj.Name] = myObj;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="iMyObjectId"></param>
        /// <returns></returns>
        public static MyObject Get(int iMyObjectId)
        {
            return MyObject.dicMyObjects[iMyObjectId];
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="iMyObjectId"></param>
        /// <returns></returns>
        public static MyObject GetCamera(string strName)
        {
            return MyObject.dicMyObjectCams[strName];
        }


        /// <summary>
        /// Given the camera VidIn appended to "_" and name, it returns a MyObject representing the it.
        /// </summary>
        /// <param name="strCamName"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static MyObject GetCameraFromNamePrefix(string strCamNamePrefix)
        {
            if (strCamNamePrefix == null || strCamNamePrefix.Length < 1)
            {
                return null;
            }

            foreach(string key in MyObject.dicMyObjectCams.Keys)
            {
                if (key.StartsWith(strCamNamePrefix))
                {
                    return MyObject.dicMyObjectCams[key];
                }
            }

            //foreach (MyObject myObj in MyObject.dicMyObjects.Values)
            //{
            //    if (myObj.Class == eClass.Camera && myObj.Name.StartsWith(strCamNamePrefix))
            //    {
            //        return myObj;
            //    }
            //}

            return null;
        }


        /// <summary>
        /// Using the given FullUrl, try to find ALL MyObject pointing to it.
        /// </summary>
        /// <param name="strFullUrl"></param>
        /// <returns></returns>
        public static List<MyObject> GetByFullUrl(string strFullUrl)
        {
            if (strFullUrl == null || strFullUrl.Length < 1)
            {
                return new List<MyObject>(0);
            }

            List<MyObject> list = new List<MyObject>(4);

            foreach (MyObject myObj in MyObject.dicMyObjects.Values)
            {
                if (myObj.FullUrl.Equals(strFullUrl))
                {
                    list.Add(myObj);
                }
            }

            return list;
        }

    }
}
