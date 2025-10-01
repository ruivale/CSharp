using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;


namespace CSharpRuntimeCameo.network
{
    public enum eResultCodes { Ok, Fail, fault, warning, systemFault }
    public enum ResponseCode { OK, fault, warning, systemFault }
    public enum SystemFaultCode
    {
        dmlVersionMismatch, notWellformedXml, notValidXml, notCompleteRequest, internalServerError,
        hardwareFault, missingTemplateFault, missingGraphicFault, missingFontFault, resourceExist,
        allFine
    }
    public class Settings
    {
        public enum eKeboardType { None, Pelco, Bosh_intuikey }
        public enum eAppType { CCTV, PA, PID }
        public enum eAspectRatio { Stretch, Letterbox }

        public const string PRODUCTID_CCTV = "f8828dc6-0b9d-4d8d-896a-684197808361";
        public const string PRODUCTID_PA = "6381b5e3-49ef-4e16-a94e-d6f4f3001554";
        public const string PRODUCTID_PID = "7E2A640B-FC03-4602-8C36-8B75DBCD48E7";

        #region /////// SETTINGS CONSTANTES ///////
        public const string DMT_ID = "DMT_ID";
        public const string DMT_NAME = "DMT_NAME";
        public const string DMT_PR = "DMT_PR";
        public const string EQUI_TM = "EQUI_TM";
        public const string CONNECION_TM = "CONNECION_TM";
        public const string RECS_OBTAINANCE_TIMEOUT = "RECS_OBTAINANCE_TIMEOUT";

        // When searching for recordings, normally, the VRM returns recordings w/ its end not exactly now but some secs in the past.
        // This value is the var that holds the nbr of seconds DMT considers normal...
        public const string VRM_RECS_END_DELAY_SECS = "VRM_RECS_END_DELAY_SECS";

        // When searching for recordings, normally, the a camera w/ "in loco recordings" returns recordings w/ its end not exactly
        // now but some secs in the past.
        // This value is the var that holds the nbr of seconds DMT considers normal...
        public const string CAM_RECS_END_DELAY_SECS = "CAM_RECS_END_DELAY_SECS";

        // When displaying the alarms, the alarm interval is tested against its source recs. 
        // If the alarm interval is "inside" the source recs time interval, then the alarm is
        // added to the list of alarms.
        // This value is used to agregate all recs, grouped by source, in a single interval, or
        // in the lesser number os intervals.Example:
        // Recs:
        //   00:00:00      13:27:10
        //   13:27:10      13:27:29
        //   13:27:29      Now
        // since the gap between recs is less than this value (1), we could assume that there's a
        // single rec from[00:00:00 to Now].
        public const string MAX_NBR_SECS_TO_IGNORE_GAPS_IN_RECS = "MAX_NBR_SECS_TO_IGNORE_GAPS_IN_RECS";


        public const string NO_VRM_COMMS_RECORDS_RETENTION_MINS = "NO_VRM_COMMS_RECORD_RETENTION_MINS";
        public const string NO_VRM_COMMS_RECORDS_REPLAY_START_LAG_SECS = "NO_VRM_COMMS_RECORD_REPLAY_START_LAG_SECS";
        public const string NO_VRM_COMMS_RECORDS_REPLAY_TRACK_ID = "NO_VRM_COMMS_RECORD_REPLAY_TRACK_ID";
        public const string NO_VRM_COMMS_RECORDS_EXTRACTION_ACTIVE = "NO_VRM_COMMS_RECORDS_EXTRACTION_ACTIVE";
        public const string NO_VMR_COMMS_REPLAY_EXTRACTION_MAX_SECS = "NO_VMR_COMMS_REPLAY_EXTRACTION_MAX_SECS";
        public const string NO_VMR_COMMS_REPLAY_EXTRACTION_FRAME_CAPTURE_SLEEP = "NO_VMR_COMMS_REPLAY_EXTRACTION_FRAME_CAPTURE_SLEEP";
        public const string NO_VMR_COMMS_RECORDS_REPLAY_CAPTURED_FRAMES_FFMPEG_PATH = "NO_VMR_COMMS_RECORD_REPLAY_CAPTURED_FRAMES_FFMPEG_PATH";
        public const string NO_VMR_COMMS_RECORDS_REPLAY_CAPTURED_FRAMES_NAME = "NO_VMR_COMMS_RECORD_REPLAY_CAPTURED_FRAMES_NAME";
        public const string NO_VMR_COMMS_RECORDS_REPLAY_CAPTURED_FRAMES_FFMPEG_PARMS = "NO_VMR_COMMS_RECORD_REPLAY_CAPTURED_FRAMES_FFMPEG_PARMS";


        public const string CON_TM = "CON_TM";
        public const string LOG_FILE = "LOG_FILE";
        public const string LANG_FILE = "LANG_FILE";
        public const string PROD_ID = "PROD_ID";
        public const string PROD_ID_ENC = "PROD_ID_ENC";
        public const string KEEP_LAYOUT = "KEEP_LAYOUT";
        public const string CON_ON_START = "CON_ON_START";
        public const string CON_POLLING_REQ = "CON_POLLING_REQ";
        public const string MSG_CLEAR_DISPLAY = "MSG_CLEAR_DISPLAY";
        public const string MSG_ON_OFF = "MSG_ON_OFF";
        public const string TEST_TIME = "TEST_TIME";
        public const string PID_GET_MSG = "PID_GET_MSG";

        //PRG - Added string Inoss_check_tm to get from the settings.xml
        public const string INOSS_CHECK_TM = "INOSS_CHECK_TM";
        public const string INOSS_CHECK_ENABLED = "INOSS_CHECK_ENABLED";
        public const string INOSS_AUTHENTICATE_ENABLED = "INOSS_AUTHENTICATE_ENABLED";
        public const string SHOW_INOSS_STATUS = "SHOW_INOSS_STATUS";
        public const string SHOW_MESSAGE_ON_RECOVERY = "SHOW_MESSAGE_ON_RECOVERY";

        // BOSCH Cyber Security

        public const string ENCRYPTED_CONN = "ENCRYPTED_CONN";
        public const string ENCRYPTED_MEDIA_EXPORTS = "ENCRYPTED_MEDIA_EXPORTS";
        public const string FORWARD_SECRECY = "FORWARD_SECRECY";

        // DB
        public const string DB_USE = "DB_USE";
        public const string DB_HOST = "DB_HOST";
        public const string DB_ALIAS = "DB_ALIAS";
        public const string DB_USER = "DB_USER";
        public const string DB_PASS = "DB_PASS";
        public const string DB_PORT = "DB_PORT";
        public const string DB_TIMEOUT = "DB_TM";
        public const string DB_AUTO_SYNC = "DB_AUTO_SYNC";
        public const string DB_AUTO_SYNC_TIME = "DB_AUTO_SYNC_TIME";
        public const string DB_LAST_DMT_SYNC = "DB_LAST_DMT_SYNC";
        public const string DB_LAST_LIST_SYNC = "DB_LAST_LIST_SYNC";
        public const string DB_LAST_TABLES_SYNC = "DB_LAST_TABLES_SYNC";
        public const string DB_CONNECTIONSTRING = "DB_CONNECTIONSTRING";

        // CCTV
        public const string OPTIMIZE_POLLING = "OPTIMIZE_POLLING";
        public const string OSD_TIME = "OSD_TIME";
        public const string DEF_LT = "DEF_LAYOUT";
        public const string PRESETS_MAX = "PRESETS_MAX";
        public const string PRESETS_MIN = "PRESETS_MIN";
        public const string ASP_RATIO = "ASP_RATIO";
        public const string KEEP_ASP_RATIO = "KEEP_ASP_RATIO";
        public const string LIVE_VIDEO_STREAM = "LIVE_VIDEO_STREAM";
        public const string CAMERA_CONN_TIMEOUT = "CAM_CONN_TIMEOUT";
        public const string ONVIF_CAMS_CONN_POLL_INTERVAL = "ONVIF_CAMS_CONN_POLL_INTERVAL";
        public const string SEQUENCE_ID = "SEQ_ID";

        public const string BOSCH_CONNECTION_SHOULD_BE_DISCONNECTED = "BOSCH_CONNECTION_SHOULD_BE_DISCONNECTED";

        public const string ZOOMSPEED = "ZOOMSPEED";
        public const string TILTSPEED = "TILTSPEED";
        public const string PANSPEED = "PANSPEED";
        public const string IRISSPEED = "IRISSPEED";
        public const string FOCUSSPEED = "FOCUSSPEED";
        public const string RENDERERID = "RENDERERID";

        public const string KEYB_TYPE = "KEYB_TYPE";
        public const string KEYB_INTERFACE = "KEYB_INTERFACE";
        public const string COM_NAME = "COM_NAME";
        public const string BAUDRATE = "BAUDRATE";
        public const string STOPBITS = "STOPBITS";
        public const string DATABITS = "DATABITS";
        public const string PARITY = "PARITY";
        public const string DEF_REC_IMAGE = "DEF_REC_IMAGE";
        public const string REC_FOLDER = "REC_FOLDER";
        public const string DEF_REC_NAME = "DEF_REC_NAME";
        public const string THREADS_NUMBER = "THREADS_NUMBER";

        public const string REC_FORMAT = "REC_FORMAT";
        public const string REC_VSD_PASSWORD = "REC_VMF_PASSWORD";
        public const string REC_USE_FORMAT_SETTINGS = "REC_USE_FORMAT_SETTINGS";
        public const string REC_USE_VSD_PASSWORD = "REC_USE_VMF_PASSWORD";
        public const string REC_ALLOW_ASF = "REC_ALLOW_ASF";
        public const string REC_ALLOW_MP4 = "REC_ALLOW_MP4";
        public const string REC_ALLOW_BOSCH_MP4 = "REC_ALLOW_BMP4";
        public const string REPLAYS_NBR_OF_RETRIES = "REPLAYS_NBR_OF_RETRIES";
        public const string REPLAYS_CONN_TIMEOUT = "REPLAYS_CONN_TIMEOUT";
        public const string REPLAYS_RETRIES_SLEEP_MILLIS = "REPLAYS_RETRIES_SLEEP_MILLIS";

        public const string EQUIP_PING_TIMEOUT = "EQUIP_PING_TIMEOUT";



        // PA
        public const string TERMINAL_ID = "T_ID";
        public const string MAX_TIME = "RT_MAX";
        public const string PLIST_FILE = "PLIST_FILE";
        public const string CODEC_IP = "COD_IP";
        public const string CODEC_PORT = "COD_PORT";
        public const string CARR_FILE = "CARR_FILE";
        public const string PATH_SCRIPTS = "PATH_SCRIPTS";
        public const string PATH_PLAY = "PATH_PLAY";
        public const string CONT_ID = "CONT_ID";
        public const string EQUI_POL_PR = "EQUI_POL_PR";
        public const string DIF_POL_PR = "DIF_POL_PR";

        // PID
        public const string PID_EQUIPS_CONN_POLL_INTERVAL = "CON_POLLING_PERIOD";
        public const string PID_TESTS = "PID_TEST";
        public const string PID_RESET = "PID_RESET";
        public const string PID_BRIGHTNESS = "PID_BRIGHT";
        public const string PID_FEATURES = "PID_FEATURES";
        public const string PID_MSG_NUM = "PID_MSG_NUM";
        public const string PID_MSG_MAIN_LANG = "PID_MSG_MAIN_LANG";
        public const string PID_MSG_SECONDARY_LANG = "PID_MSG_SEC_LANG";
        public const string PID_GEN_MSG_TWO_LANGS = "PID_GEN_MSG_TWO_LANGS";
        public const string PID_GET_STATIONS_MSGS = "PID_GET_STATIONS_MSGS";
        public const string PID_ALT_MSG_INTVL = "PID_ALT_MSG_INTVL";
        #endregion

        #region /////// SETTINGS PROPERTIES ///////
        private static int iTerminal_ID;
        private static string stTerminalName;
        private static int iEqui_TM;
        private static int iDmt_Priority;
        private static int iPresetsMax;
        private static int iPresetsMin;
        private static int iConectionTM;

        private static int iEquipsPingTimeout;


        public static bool bUse_Encrypted_Conn;
        public static bool bUse_Encrypted_Media_Exports;
        public static bool bUse_Forward_Secrecy;

        private static int iDB_TM;
        private static int iDB_Port;
        private static string stDB_Host;
        private static string stDB_Alias;
        private static string stDB_User;
        private static string stDB_Pass;
        private static string stDB_Conn;
        private static bool bUse_DB;

        private static bool bKeepLayout;
        private static bool bUse_ProdId_Enc;
        public static string stProdId;

        private static string stLogFile;
        private static string stLangFile;

        private static string stMaxTime;
        private static int iCont_ID;
        private static int iEqui_Pol;
        private static int iDif_Pol;

        private static string stPlaylistFile;
        private static string stCarrFile;
        private static string stPathScripts;
        private static string stPathPlay;
        private static eAspectRatio earAsp;
        private static DateTime dtLastDmtSync;
        private static DateTime dtLastListSync;
        private static DateTime dtSyncTime;
        private static bool bAutoSync;

        public static int LiveVideoStream { get; set; }
        public static int CamConnectionTimeout { get; set; }
        public static int OnvifEquipsPollingInterval { get; set; }

        public static bool BoschConnectionShouldBeDisconnected { get; set; }

        public static bool RecAllowASF { get; set; }
        public static bool RecAllowMP4 { get; set; }
        public static bool RecAllowBoschMP4 { get; set; }
        public static string ASFDesc { get; set; }
        public static string MP4Desc { get; set; }
        public static string BMP4Desc { get; set; }

        public static bool KeepAspectRatio { get; set; }

        public static int ReplaysNbrOfRetries { get; set; }
        public static int ReplaysConnTimeout { get; set; }
        public static int ReplaysRetriesSleepMillis { get; set; }

        public static bool KeepLayout
        {
            get
            {
                return bKeepLayout;
            }
            set
            {
                bKeepLayout = value;
            }
        }
        public static bool AutoSync
        {
            get
            {
                return bAutoSync;
            }
            set
            {
                bAutoSync = value;
            }
        }
        public static DateTime LastDmtSync
        {
            get
            {
                return dtLastDmtSync;
            }
            set
            {
                dtLastDmtSync = value;
            }
        }
        public static DateTime LastListSync
        {
            get
            {
                return dtLastListSync;
            }
            set
            {
                dtLastListSync = value;
            }
        }
        public static DateTime SyncTime
        {
            get
            {
                return dtSyncTime;
            }
            set
            {
                dtSyncTime = value;
            }
        }
        public static string PlaylistFile
        {
            get
            {
                return stPlaylistFile;
            }
        }
        public static string CarrFile
        {
            get
            {
                return stCarrFile;
            }
        }
        public static string PathScripts
        {
            get
            {
                return stPathScripts;
            }
        }
        public static string PathPlay
        {
            get
            {
                return stPathPlay;
            }
        }
        public static int Equi_Pol
        {
            get
            {
                return iEqui_Pol;
            }
        }
        public static int Dif_Pol
        {
            get
            {
                return iDif_Pol;
            }
        }
        public static int Cont_ID
        {
            get
            {
                return iCont_ID;
            }
        }
        public static int TerminalId
        {
            get
            {
                return iTerminal_ID;
            }
        }
        public static string TerminalName
        {
            get
            {
                return stTerminalName;
            }
        }
        public static string MaxTime
        {
            get
            {
                return stMaxTime;
            }
        }
        public static string ProdId
        {
            get
            {
                return stProdId;
            }
        }
        public static int Equi_TM
        {
            get
            {
                return iEqui_TM;
            }
        }


        public static int EquipmentConnectionTimeout
        { get; private set; }

        public static int RecordingsObtainanceTimeout
        { get; private set; }



        /// <summary>
        /// When searching for recordings, normally, the VRM returns recordings w/ its end not exactly now but some secs in the past.
        /// This value is the var that holds the nbr of seconds DMT considers normal...
        /// </summary>
        public static int VrmRecsEndDelaySecs
        { get; private set; }

        /// <summary>
        /// When searching for recordings, normally, the a camera w/ "in loco recordings" returns recordings w/ its end not exactly
        /// now but some secs in the past.
        /// This value is the var that holds the nbr of seconds DMT considers normal...
        /// </summary>
        public static int CamRecsEndDelaySecs
        { get; private set; }

        /// <summary>
        /// When displaying the alarms, the alarm interval is tested against its source recs. 
        /// If the alarm interval is "inside" the source recs time interval, then the alarm is
        /// added to the list of alarms.
        /// This value is used to agregate all recs, grouped by source, in a single interval, or
        /// in the lesser number os intervals.Example:
        /// Recs:
        ///   00:00:00      13:27:10
        ///   13:27:10      13:27:29
        ///   13:27:29      Now
        /// since the gap between recs is less than this value (1), we could assume that there's a
        /// single rec from[00:00:00 to Now].
        /// </summary>
        public static int MaxNbrOfSecsToIgnoreGapsInRecordings
        { get; private set; }


        /// <summary>
        /// The typical configuration used to set in the camera/vrm/recording device to retain the recordins (normally 7 days)
        /// </summary>
        public static int NoVrmCommsRecordsRetentionMins
        { get; private set; }

        /// <summary>
        /// The number of seconds a replay, based on a recording built by DMT (when no VRM comms R available), should e started from NOW (NOW - X secs)
        /// </summary>
        public static int NoVrmCommsRecordsReplayStartLagSecs
        { get; private set; }

        /// <summary>
        /// The camera's track Id to use when no vmr comms are available when records are being searched.
        /// If it's different from 1, f.i. -1, it means the track Id different from 1 should be used. We use this because 
        /// there's always a TrackId=1 but if other track exist, its Id can be any number and its almost useless defining such an Id.
        /// IF IT'S -999 IT MEANS ALL CAMERAS TRACKS SHOULD BE LISTED.
        /// If the camera has, in its specific config, the ReplayTrackId TAG, then it's this TrackId that must be used.
        /// </summary>
        public static int NoVrmCommsRecordsReplayTrackId
        { get; private set; }

        /// <summary>
        /// Normally, extracting records directly from cameras, through active replays, it's not possible when no communicaX
        /// are not available between the camera and VRM/iSCSI. This prop enables/disables, globally, the extraction buttons.
        /// </summary>
        public static bool NoVrmCommsRecordsExtractionActive
        { get; private set; }

        /// <summary>
        /// Maximum number of secs an extraction can have when no VRM comms R available...
        /// </summary>
        public static int NoVrmCommsReplayExtractionMaxSecs
        { get; private set; }

        /// <summary>
        /// Maximum number of secs an extraction can have when no VRM comms R available... 
        /// </summary>
        public static int NoVrmCommsReplayExtractionFrameCaptureSleep
        { get; private set; }


        public static int PresetsMax
        {
            get
            {
                return iPresetsMax;
            }
        }
        public static int PresetsMin
        {
            get
            {
                return iPresetsMin;
            }
        }
        public static int DB_TM
        {
            get
            {
                return iDB_TM;
            }
        }
        /*
        private static int iSequenceId = 0;
        public static int SequenceId
        {
            get
            {
                return iSequenceId;
            }
            set
            {
                iSequenceId = value;
            }
        }
        */
        //PRG - Added set and get method Inoss_check_tm
        public static bool InossAuthenticateEnabled
        {
            get; private set;
        }
        public static bool InossCheckStatusEnabled
        {
            get; private set;
        }
        public static int InossCheckStatusTM
        {
            get; private set;
        }
        public static bool ShowInossStatus
        {
            get; private set;
        }
        public static bool ShowMessageOnInossStatusRecovery
        {
            get; private set;
        }
        public static int ConnectionTM
        {
            get
            {
                return iConectionTM;
            }
        }
        public static int EquipsPingTimeout
        {
            get
            {
                return iEquipsPingTimeout;
            }
        }

        public static int DefRecName
        {
            get; private set;
        }
        public static string DB_Host
        {
            get
            {
                return stDB_Host;
            }
        }
        public static string DB_Alias
        {
            get
            {
                return stDB_Alias;
            }
        }
        public static string DB_User
        {
            get
            {
                return stDB_User;
            }
        }
        public static string DB_Pass
        {
            get
            {
                return stDB_Pass;
            }
        }
        public static string DB_Conn
        {
            get
            {
                return stDB_Conn;
            }
        }
        public static int DB_Port
        {
            get
            {
                return iDB_Port;
            }
        }
        public static int DMT_Priority
        {
            get
            {
                return iDmt_Priority;
            }
        }
        public static eAspectRatio ASP_Ratio
        {
            get
            {
                return earAsp;
            }
        }

        public static bool Use_ProdId_Enc
        {
            get
            {
                return bUse_ProdId_Enc;
            }
        }

        public static bool Use_Encrypted_Conn
        {
            get
            {
                return bUse_Encrypted_Conn;
            }
        }
        public static bool Use_Encrypted_Media_Exports
        {
            get
            {
                return bUse_Encrypted_Media_Exports;
            }
        }
        public static bool Use_Forward_Secrecy
        {
            get
            {
                return bUse_Forward_Secrecy;
            }
        }

        public static bool Use_DB
        {
            get
            {
                return bUse_DB;
            }
        }
        public static string LogFile
        {
            get
            {
                return stLogFile;
            }
        }
        public static string LangFile
        {
            get
            {
                return stLangFile;
            }
        }
        public static string Password
        {
            get
            {
                //if (Use_ProdId_Enc)
                //{
                //    return EncDec.Encrypt(ProdId, OS.GetLicenseID());
                //}
                //else
                //{
                    return ProdId;
                //}
            }
        }

        public static int iTestTime;
        public static int TestTime
        {
            get
            {
                return iTestTime;
            }
        }

        private static int iPidEquipsPollingInterval = 5000;
        public static int PidEquipsPollingInterval
        {
            get
            {
                return iPidEquipsPollingInterval;
            }
        }

        private static bool iPidTestsAvailable = true;
        public static bool PidTestsAvailable
        {
            get
            {
                return iPidTestsAvailable;
            }
        }

        private static bool iPidResetAvailable = true;
        public static bool PidResetAvailable
        {
            get
            {
                return iPidResetAvailable;
            }
        }

        private static bool iPidBrightnessControl = true;
        public static bool PidBrightnessControl
        {
            get
            {
                return iPidBrightnessControl;
            }
        }

        private static bool iPidSpecialFeatures = false;
        public static bool PidSpecialFeaturesAvailable
        {
            get
            {
                return iPidSpecialFeatures;
            }
        }

        private static int iPidMessageNumber = 0;
        public static int PidMessageNumber
        {
            get
            {
                return iPidMessageNumber;
            }
            set
            {
                iPidMessageNumber = value;
            }
        }

        private static int iPidAlternatingMessageInterval = 0;
        public static int PidAlternatingMessageInterval
        {
            get
            {
                return iPidAlternatingMessageInterval;
            }
            set
            {
                iPidAlternatingMessageInterval = value;
            }
        }
        private static string iPidMainLanguage = "";
        public static string PidMainLanguage
        {
            get
            {
                return iPidMainLanguage;
            }
            set
            {
                iPidMainLanguage = value;
            }
        }

        private static string iPidSecondaryLanguage = "";
        public static string PidSecondaryLanguage
        {
            get
            {
                return iPidSecondaryLanguage;
            }
            set
            {
                iPidSecondaryLanguage = value;
            }
        }

        private static bool iPidGenMsgHasTwoLangs = false;
        public static bool PidGenMsgHasTwoLangs
        {
            get
            {
                return iPidGenMsgHasTwoLangs;
            }
            set
            {
                iPidGenMsgHasTwoLangs = value;
            }
        }

        private static bool iPidGetStationsMsgs = false;
        public static bool PidGetStationsMsgs
        {
            get
            {
                return iPidGetStationsMsgs;
            }
            set
            {
                iPidGetStationsMsgs = value;
            }
        }

        // CCTV Settings
        private static int iThreadsMax = 10;
        public static int ThreadsMax
        {
            get
            {
                return iThreadsMax;
            }
        }

        private static int iZoomSpeed;
        private static int iTiltSpeed;
        private static int iPanSpeed;
        private static int iIrisSpeed;
        private static int iFocusSpeed;
        private static int iRendererId;

        public static int ZoomSpeed
        {
            get
            {
                return iZoomSpeed;
            }
        }
        public static int TiltSpeed
        {
            get
            {
                return iTiltSpeed;
            }
        }
        public static int PanSpeed
        {
            get
            {
                return iPanSpeed;
            }
        }
        public static int IrisSpeed
        {
            get
            {
                return iIrisSpeed;
            }
        }
        public static int FocusSpeed
        {
            get
            {
                return iFocusSpeed;
            }
        }
        public static int RendererId
        {
            get
            {
                return iRendererId;
            }
        }

        private static int iOSD_TM;
        public static int OSD_time
        {
            get
            {
                return iOSD_TM;
            }
        }
        private static int iDef_Layout;
        public static int Def_Layout
        {
            get
            {
                return iDef_Layout;
            }
        }

        private static string stRecFolder;
        public static string RecFolder
        {
            get
            {
                if (stRecFolder == string.Empty)
                {
                    stRecFolder = Application.StartupPath + @"\LocalRecordings";
                }
                return stRecFolder;
            }
        }

        /// <summary>
        /// From Bosch VideoSDK 5.71 documentation:
        ///   Bosch.VideoSDK.MediaDatabase.MediaFileFormatEnum.mffMPEGActiveX,     // 1
        ///   Bosch.VideoSDK.MediaDatabase.MediaFileFormatEnum.mffASF,             // 2
        ///   Bosch.VideoSDK.MediaDatabase.MediaFileFormatEnum.mffISOMP4           // 3
        /// </summary>
        public enum RecordingFormat
        {
            Undefined = 0,
            BMP4 = 1,
            ASF = 2,
            MP4 = 3
        }

        private static RecordingFormat iRecordingsFormat; // 1 - MP4 // 2 - VSD
        public static RecordingFormat RecordingsFormat
        {
            get
            {
                if (iRecordingsFormat == RecordingFormat.Undefined)
                {
                    iRecordingsFormat = RecordingFormat.MP4;
                }

                return iRecordingsFormat;
            }
        }

        private static string stVsdRecFormatPassword;
        public static string VsdRecFormatPassword
        {
            get
            {
                return stVsdRecFormatPassword;
            }
            set
            {
                stVsdRecFormatPassword = value;
            }
        }

        private static bool bUseRecordingFilesSettings;
        public static bool UseRecordingFilesSettings
        {
            get
            {
                return bUseRecordingFilesSettings;
            }
        }

        private static bool bUseRecordingFilesPassword;
        public static bool UseRecordingFilesPassword
        {
            get
            {
                return bUseRecordingFilesPassword;
            }
        }

        private static string stRecImgSize;
        public static string RecImageSize
        {
            get
            {
                if ((stRecImgSize == null) || (stRecImgSize == ""))
                {
                    return "FULL";
                }
                return stRecImgSize;
            }
        }

        private static bool bOptimizePolling;
        public static bool OptimizePolling
        {
            get
            {
                return bOptimizePolling;
            }
        }

        private static bool bConnectionOnStart;
        public static bool ConnectionOnStart
        {
            get
            {
                return bConnectionOnStart;
            }
        }

        private static bool bPollingRequest;
        public static bool PollingRequest
        {
            get
            {
                return bPollingRequest;
            }
        }
        private static bool bClearMessageDisplay;
        public static bool ClearMessageDisplay
        {
            get
            {
                return bClearMessageDisplay;
            }
        }

        private static bool bMsgOnOff;
        public static bool MsgOnOff
        {
            get
            {
                return bMsgOnOff;
            }
        }

        private static bool bGetDisplayMessage;
        public static bool GetDisplayMessage
        {
            get
            {
                return bGetDisplayMessage;
            }
        }
        #region // Keboard Settings
        static string stKeyboard;
        static string stInterface;
        static string stComName;
        static int iBaudRate;
        static int iDataBits;
        static string stParity;
        static string stStopBits;

        public static eKeboardType KeyboardType
        {
            get
            {
                if (stKeyboard == "Pelco")
                {
                    return eKeboardType.Pelco;
                }
                else if (stKeyboard == "Bosch_intuikey")
                {
                    return eKeboardType.Bosh_intuikey;
                }

                return eKeboardType.None;
            }
        }
        public static string ComName
        {
            get
            {
                return stComName;
            }
        }
        public static string Interface
        {
            get
            {
                return stInterface;
            }
        }
        public static int BaudRate
        {
            get
            {
                return iBaudRate;
            }
        }
        public static int DataBits
        {
            get
            {
                return iDataBits;
            }
        }
        public static Parity pParity
        {
            get
            {
                if (stParity == "Even")
                {
                    return Parity.Even;
                }
                else if (stParity == "Mark")
                {
                    return Parity.Mark;
                }

                if (stParity == "Odd")
                {
                    return Parity.Odd;
                }

                if (stParity == "Space")
                {
                    return Parity.Space;
                }

                return Parity.None;
            }
        }
        public static StopBits sStopBits
        {
            get
            {
                if ((stStopBits == "One") || (stStopBits == "1"))
                {
                    return StopBits.One;
                }
                else if ((stStopBits == "OnePointFive") || (stStopBits == "1,5") || (stStopBits == "1.5"))
                {
                    return StopBits.OnePointFive;
                }

                if ((stStopBits == "Two") || (stStopBits == "2"))
                {
                    return StopBits.Two;
                }

                return StopBits.None;
            }
        }

        public static string NoVrmCommsRecordsReplayCapturedFramesFfmpegPath
        {
            get;
            private set;
        }
        public static string NoVrmCommsRecordsReplayCapturedFramesName
        {
            get;
            private set;
        }

        public static string NoVrmCommsRecordsReplayCapturedFramesFfmpegParams
        {
            get;
            private set;
        }

        #endregion // Keboard Settings
        #endregion


        public static string getName()
        {
            string name = "";

            Random myRand = new Random(94724183);

            for (int i = 0; i < 30; i++)
            {
                name += (char)myRand.Next(0, 128);
            }

            return name;
        }



        public static DataSet ds_settings;
        static Settings()
        {
            ReloadSettings();
        }

        public static void ReloadSettings()
        {
            ds_settings = new DataSet();
            var settingsFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"Settings.xml");
            if (File.Exists(settingsFilePath))
                ds_settings.ReadXml(settingsFilePath);


            bConnectionOnStart = MyConvert.ToBoolean(GetValueStr(Settings.CON_ON_START), true);
            bPollingRequest = MyConvert.ToBoolean(GetValueStr(Settings.CON_POLLING_REQ), true);
            bClearMessageDisplay = MyConvert.ToBoolean(GetValueStr(Settings.MSG_CLEAR_DISPLAY), false);
            bMsgOnOff = MyConvert.ToBoolean(GetValueStr(Settings.MSG_ON_OFF), false);
            bGetDisplayMessage = MyConvert.ToBoolean(GetValueStr(Settings.PID_GET_MSG), false);
            iTestTime = MyConvert.ToInt32(GetValueStr(Settings.TEST_TIME), 20);


            iTerminal_ID = MyConvert.ToInt32(GetValueStr(Settings.DMT_ID), 0);
            iEqui_TM = MyConvert.ToInt32(GetValueStr(Settings.EQUI_TM), 60000);


            EquipmentConnectionTimeout = MyConvert.ToInt32(GetValueStr(Settings.CONNECION_TM), 600);

            RecordingsObtainanceTimeout = MyConvert.ToInt32(GetValueStr(Settings.RECS_OBTAINANCE_TIMEOUT), 20000);


            // When searching for recordings, normally, the VRM returns recordings w/ its end not exactly now but some secs in the past.
            // This value is the var that holds the nbr of seconds DMT considers normal...
            VrmRecsEndDelaySecs =
                MyConvert.ToInt32(GetValueStr(Settings.VRM_RECS_END_DELAY_SECS), 90);

            // When searching for recordings, normally, the a camera w/ "in loco recordings" returns recordings w/ its end not exactly
            // now but some secs in the past.
            // This value is the var that holds the nbr of seconds DMT considers normal...
            CamRecsEndDelaySecs =
                MyConvert.ToInt32(GetValueStr(Settings.CAM_RECS_END_DELAY_SECS), 120);

            // When displaying the alarms, the alarm interval is tested against its source recs. 
            // If the alarm interval is "inside" the source recs time interval, then the alarm is
            // added to the list of alarms.
            // This value is used to agregate all recs, grouped by source, in a single interval, or
            // in the lesser number os intervals.Example:
            // Recs:
            //   00:00:00      13:27:10
            //   13:27:10      13:27:29
            //   13:27:29      Now
            // since the gap between recs is less than this value (1), we could assume that there's a
            // single rec from[00:00:00 to Now].
            MaxNbrOfSecsToIgnoreGapsInRecordings =
                MyConvert.ToInt32(GetValueStr(Settings.MAX_NBR_SECS_TO_IGNORE_GAPS_IN_RECS), 2);


            // The typical configuration used to set in the camera/vrm/recording device to retain the recordins (normally 7 days)
            NoVrmCommsRecordsRetentionMins =
                MyConvert.ToInt32(
                    GetValueStr(Settings.NO_VRM_COMMS_RECORDS_RETENTION_MINS),
                    60 /* mins */ * 24 /* hours */ * 7 /* days */); // 10080

            // The number of seconds a replay, based on a recording built by DMT (when no VRM comms R available), should e started from NOW (NOW - X secs)
            NoVrmCommsRecordsReplayStartLagSecs =
                MyConvert.ToInt32(
                    GetValueStr(Settings.NO_VRM_COMMS_RECORDS_REPLAY_START_LAG_SECS),
                    30 /* secs */);

            // The camera's track Id to use when no vmr comms are available when records are being searched.
            // If it's different from 1, f.i. -1, it means the track Id different from 1 should be used. We use this because 
            // there's always a TrackId=1 but if other track exist, its Id can be any number and its almost useless defining such an Id.
            // IF IT'S -999 IT MEANS ALL CAMERAS TRACKS SHOULD BE LISTED.
            // If the camera has, in its specific config, the ReplayTrackId TAG, then it's this TrackId that must be used.
            NoVrmCommsRecordsReplayTrackId =
                MyConvert.ToInt32(
                    GetValueStr(Settings.NO_VRM_COMMS_RECORDS_REPLAY_TRACK_ID),
                    -1);

            // Normally, extracting records directly from cameras, through active replays, it's not possible when no communicaX
            // are available between the camera and VRM/iSCSI. This prop enables/disables, globally, the extraction buttons.            
            NoVrmCommsRecordsExtractionActive =
                 MyConvert.ToBoolean(GetValueStr(Settings.NO_VRM_COMMS_RECORDS_EXTRACTION_ACTIVE), true);

            // Maximum number of secs an extraction can have when no VRM comms R available... 
            NoVrmCommsReplayExtractionMaxSecs =
                 MyConvert.ToInt32(GetValueStr(Settings.NO_VMR_COMMS_REPLAY_EXTRACTION_MAX_SECS), 120);

            // Number of millis for the "no vmr comms" replay extraction procedure thread sleeps between capturing frames in the replaying Cameo.. 
            NoVrmCommsReplayExtractionFrameCaptureSleep =
                 MyConvert.ToInt32(GetValueStr(Settings.NO_VMR_COMMS_REPLAY_EXTRACTION_FRAME_CAPTURE_SLEEP), 10);

            // the ffmpeg application path
            NoVrmCommsRecordsReplayCapturedFramesFfmpegPath =
                GetValueStr(Settings.NO_VMR_COMMS_RECORDS_REPLAY_CAPTURED_FRAMES_FFMPEG_PATH).Length > 0 ?
                    GetValueStr(Settings.NO_VMR_COMMS_RECORDS_REPLAY_CAPTURED_FRAMES_FFMPEG_PATH) :
                    @".\ffmpeg.exe";
            // the ffmpeg application parameters to use when converting the recording replay captured frames to a video file when no comms are available w/ VRM
            NoVrmCommsRecordsReplayCapturedFramesName =
                GetValueStr(Settings.NO_VMR_COMMS_RECORDS_REPLAY_CAPTURED_FRAMES_NAME).Length > 0 ?
                    GetValueStr(Settings.NO_VMR_COMMS_RECORDS_REPLAY_CAPTURED_FRAMES_NAME) :
                    "frame*.jpg";
            // the ffmpeg application parameters to use when converting the recording replay captured frames to a video file when no comms are available w/ VRM
            NoVrmCommsRecordsReplayCapturedFramesFfmpegParams =
                GetValueStr(Settings.NO_VMR_COMMS_RECORDS_REPLAY_CAPTURED_FRAMES_FFMPEG_PARMS).Length > 0 ?
                    GetValueStr(Settings.NO_VMR_COMMS_RECORDS_REPLAY_CAPTURED_FRAMES_FFMPEG_PARMS) :
                    "-r {0} -f image2 -i frame%d.jpg -vcodec mpeg4 -b:v 7200k";


            iDB_TM = MyConvert.ToInt32(GetDatabaseValue(Settings.DB_TIMEOUT), 10);
            iDB_Port = MyConvert.ToInt32(GetDatabaseValue(Settings.DB_PORT), 1521);
            iOSD_TM = MyConvert.ToInt32(GetValueStr(Settings.OSD_TIME), 0);
            iPresetsMax = MyConvert.ToInt32(GetValueStr(Settings.PRESETS_MAX), 20);
            iPresetsMin = MyConvert.ToInt32(GetValueStr(Settings.PRESETS_MIN), 20);
            iDmt_Priority = MyConvert.ToInt32(GetValueStr(Settings.DMT_PR), 0);
            iCont_ID = MyConvert.ToInt32(GetValueStr(Settings.CONT_ID), 0);
            iEqui_Pol = MyConvert.ToInt32(GetValueStr(Settings.EQUI_POL_PR), 10);
            iDif_Pol = MyConvert.ToInt32(GetValueStr(Settings.DIF_POL_PR), 10);
            LiveVideoStream = MyConvert.ToInt32(GetValueStr(Settings.LIVE_VIDEO_STREAM), 1);
            CamConnectionTimeout = MyConvert.ToInt32(GetValueStr(Settings.CAMERA_CONN_TIMEOUT), 3) * 1000;
            OnvifEquipsPollingInterval = MyConvert.ToInt32(GetValueStr(Settings.ONVIF_CAMS_CONN_POLL_INTERVAL), 15) * 1000;

            BoschConnectionShouldBeDisconnected = MyConvert.ToBoolean(GetValueStr(Settings.BOSCH_CONNECTION_SHOULD_BE_DISCONNECTED), false);

            ReplaysNbrOfRetries = MyConvert.ToInt32(GetOptionValue(Settings.REPLAYS_NBR_OF_RETRIES), 1);
            ReplaysConnTimeout = MyConvert.ToInt32(GetOptionValue(Settings.REPLAYS_CONN_TIMEOUT), 10) * 1000;
            ReplaysRetriesSleepMillis = MyConvert.ToInt32(GetOptionValue(Settings.REPLAYS_RETRIES_SLEEP_MILLIS), 150);

            DefRecName = MyConvert.ToInt32(GetOptionValue(Settings.DEF_REC_NAME), 1);
            RecAllowASF = MyConvert.ToBoolean(GetOptionValue(Settings.REC_ALLOW_ASF), false);
            RecAllowMP4 = MyConvert.ToBoolean(GetOptionValue(Settings.REC_ALLOW_MP4), true);
            RecAllowBoschMP4 = MyConvert.ToBoolean(GetOptionValue(Settings.REC_ALLOW_BOSCH_MP4), false);
            ASFDesc = GetOptionDescription(Settings.REC_ALLOW_ASF);
            MP4Desc = GetOptionDescription(Settings.REC_ALLOW_MP4);
            BMP4Desc = GetOptionDescription(Settings.REC_ALLOW_BOSCH_MP4);

            stMaxTime = GetValueStr(Settings.MAX_TIME);
            stTerminalName = GetValueStr(Settings.DMT_NAME);
            stDB_Host = GetDatabaseValue(Settings.DB_HOST);
            stDB_Alias = GetDatabaseValue(Settings.DB_ALIAS);
            stDB_User = GetDatabaseValue(Settings.DB_USER);
            stDB_Pass = GetDatabaseValue(Settings.DB_PASS);
            stDB_Conn = GetDatabaseValue(Settings.DB_CONNECTIONSTRING);
            stProdId = GetValueStr(Settings.PROD_ID);
            stLogFile = GetValueStr(Settings.LOG_FILE);
            stLangFile = GetValueStr(Settings.LANG_FILE);

            stPlaylistFile = GetValueStr(Settings.PLIST_FILE);
            stCarrFile = GetValueStr(Settings.CARR_FILE);
            stPathScripts = GetValueStr(Settings.PATH_SCRIPTS);
            stPathPlay = GetValueStr(Settings.PATH_PLAY);
            stRecImgSize = GetOptionValue(Settings.DEF_REC_IMAGE);

            // iSequenceId = MyConvert.ToInt16(GetConfigValue(Settings.SEQUENCE_ID), 0);

            if ((stLogFile == null) || (stLogFile == ""))
            {
                stLogFile = Path.GetDirectoryName(Application.ExecutablePath) + "Log.dat";
            }

            if ((stLangFile == null) || (stLangFile == ""))
            {
                stLangFile = Path.GetDirectoryName(Application.ExecutablePath) + "Lang.xml";
            }

            bUse_ProdId_Enc = MyConvert.ToBoolean(GetValueStr(Settings.PROD_ID_ENC), false);

            bUse_DB = MyConvert.ToBoolean(GetValueStr(Settings.DB_USE), false/*true*/);

            bUse_Encrypted_Conn = MyConvert.ToBoolean(GetValueStr(Settings.ENCRYPTED_CONN), false/*true*/);

            bUse_Encrypted_Media_Exports = MyConvert.ToBoolean(GetValueStr(Settings.ENCRYPTED_MEDIA_EXPORTS), false/*true*/);

            bUse_Forward_Secrecy = MyConvert.ToBoolean(GetValueStr(Settings.FORWARD_SECRECY), false/*true*/);

            //if (ProdId == "")
            //{
            //    if (Ap == eAppType.CCTV)
            //    {
            stProdId = PRODUCTID_CCTV;
            //    }
            //    else
            //    {
            //        stProdId = PRODUCTID_PA;
            //    }
            //}

            bKeepLayout = MyConvert.ToBoolean(GetOptionValue(Settings.KEEP_LAYOUT), false);
            iDef_Layout = MyConvert.ToInt32(GetOptionValue(Settings.DEF_LT), 0);
            earAsp = eAspectRatio.Stretch;

            if (GetOptionValue(Settings.ASP_RATIO) == "letterbox")
            {
                earAsp = eAspectRatio.Letterbox;
            }

            KeepAspectRatio = MyConvert.ToBoolean(GetOptionValue(Settings.KEEP_ASP_RATIO), false);


            dtLastDmtSync = MyConvert.ToDateTime(GetConfigValue(Settings.DB_LAST_DMT_SYNC), DateTime.Now);
            dtLastListSync = MyConvert.ToDateTime(GetConfigValue(Settings.DB_LAST_LIST_SYNC), MyConvert.ToDateTime(GetConfigValue(Settings.DB_LAST_TABLES_SYNC), DateTime.Now));
            dtSyncTime = MyConvert.ToDateTime(GetDatabaseValue(Settings.DB_AUTO_SYNC_TIME), DateTime.Now);
            bAutoSync = MyConvert.ToBoolean(GetDatabaseValue(Settings.DB_AUTO_SYNC), false);

            bOptimizePolling = MyConvert.ToBoolean(GetValueStr(Settings.OPTIMIZE_POLLING), true);


            //Keyboard Settings
            stKeyboard = GetValueStr(Settings.KEYB_TYPE);
            stInterface = GetValueStr(Settings.KEYB_INTERFACE);
            stComName = GetValueStr(Settings.COM_NAME);
            iBaudRate = MyConvert.ToInt32(GetValueStr(Settings.BAUDRATE), 4800);
            iDataBits = MyConvert.ToInt32(GetValueStr(Settings.DATABITS), 8);
            stStopBits = GetValueStr(Settings.STOPBITS);
            stParity = GetValueStr(Settings.PARITY);

            //Speed Settings
            iZoomSpeed = MyConvert.ToInt32(GetValueStr(Settings.ZOOMSPEED), 100);
            iPanSpeed = MyConvert.ToInt32(GetValueStr(Settings.PANSPEED), 100);
            iTiltSpeed = MyConvert.ToInt32(GetValueStr(Settings.TILTSPEED), 100);
            iFocusSpeed = MyConvert.ToInt32(GetValueStr(Settings.FOCUSSPEED), 100);
            iIrisSpeed = MyConvert.ToInt32(GetValueStr(Settings.IRISSPEED), 100);

            // Equips timeouts
            iConectionTM = MyConvert.ToInt32(GetOptionValue(Settings.CON_TM), 5000);
            EquipmentConnectionTimeout = iConectionTM;
            iEquipsPingTimeout = MyConvert.ToInt32(GetOptionValue(Settings.EQUIP_PING_TIMEOUT), 100);

            iRendererId = MyConvert.ToInt32(GetValueStr(Settings.RENDERERID), 0);



            //Inoss Status Check
            //PRG - iInossStatusTM to get value from settings.xml
            var splitted = GetDatabaseValue(Settings.INOSS_CHECK_TM).Split(':');
            var minutes = splitted.Length > 0 && int.TryParse(splitted[0], out int min) ? min : 0;
            var seconds = splitted.Length > 1 && int.TryParse(splitted[1], out int sec) ? sec : 0;
            InossCheckStatusTM = (minutes * 60 + seconds) * 1000;
            InossCheckStatusEnabled = MyConvert.ToBoolean(GetDatabaseValue(Settings.INOSS_CHECK_ENABLED), false);
            InossAuthenticateEnabled = MyConvert.ToBoolean(GetValueStr(Settings.INOSS_AUTHENTICATE_ENABLED), false);
            ShowInossStatus = MyConvert.ToBoolean(GetValueStr(Settings.SHOW_INOSS_STATUS), true);
            ShowMessageOnInossStatusRecovery = MyConvert.ToBoolean(GetValueStr(Settings.SHOW_MESSAGE_ON_RECOVERY), true);

            stRecFolder = GetOptionValue(Settings.REC_FOLDER);
            iRecordingsFormat = (RecordingFormat)MyConvert.ToInt32(GetOptionValue(Settings.REC_FORMAT), (int)RecordingFormat.MP4);

            stVsdRecFormatPassword = GetOptionValue(Settings.REC_VSD_PASSWORD);


            //if (stVsdRecFormatPassword != "")
            //{
            //    VsdRecFormatPassword = EncDec.Decrypt(stVsdRecFormatPassword, getName());
            //}

            bUseRecordingFilesSettings = MyConvert.ToBoolean(GetOptionValue(Settings.REC_USE_FORMAT_SETTINGS), true);
            bUseRecordingFilesPassword = MyConvert.ToBoolean(GetOptionValue(Settings.REC_USE_VSD_PASSWORD), true);

            iThreadsMax = MyConvert.ToInt32(GetValueStr(Settings.THREADS_NUMBER), 10);


            iPidEquipsPollingInterval = MyConvert.ToInt32(GetValueStr(Settings.PID_EQUIPS_CONN_POLL_INTERVAL), 5000);
            iPidTestsAvailable = MyConvert.ToBoolean(GetValueStr(Settings.PID_TESTS), true);
            iPidResetAvailable = MyConvert.ToBoolean(GetValueStr(Settings.PID_RESET), true);
            iPidBrightnessControl = MyConvert.ToBoolean(GetValueStr(Settings.PID_BRIGHTNESS), false);
            iPidSpecialFeatures = MyConvert.ToBoolean(GetValueStr(Settings.PID_FEATURES), false);
            iPidMessageNumber = MyConvert.ToInt16(GetConfigValue(Settings.PID_MSG_NUM), 0);
            iPidAlternatingMessageInterval = MyConvert.ToInt32(GetValueStr(Settings.PID_ALT_MSG_INTVL), 0) * 1000;
            iPidMainLanguage = GetValueStr(Settings.PID_MSG_MAIN_LANG);
            iPidSecondaryLanguage = GetValueStr(Settings.PID_MSG_SECONDARY_LANG);
            iPidGenMsgHasTwoLangs = MyConvert.ToBoolean(GetValueStr(Settings.PID_GEN_MSG_TWO_LANGS), true);
            iPidGetStationsMsgs = MyConvert.ToBoolean(GetValueStr(Settings.PID_GET_STATIONS_MSGS), true);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Ap"></param>
        public Settings(eAppType Ap)
        {
            //if (ProdId == "")
            //{
            if (Ap == eAppType.CCTV)
            {
                dtLastDmtSync = MyConvert.ToDateTime(GetConfigValue(Settings.DB_LAST_DMT_SYNC), DateTime.Now);
                dtLastListSync = MyConvert.ToDateTime(GetConfigValue(Settings.DB_LAST_LIST_SYNC), DateTime.Now);
                stProdId = PRODUCTID_CCTV;
            }
            else if (Ap == eAppType.PID)
            {
                dtLastDmtSync = MyConvert.ToDateTime(GetConfigValue(Settings.DB_LAST_DMT_SYNC), DateTime.Now);
                dtLastListSync = MyConvert.ToDateTime(GetConfigValue(Settings.DB_LAST_TABLES_SYNC), DateTime.Now);
                stProdId = PRODUCTID_PID;
            }
            else
            {
                stProdId = PRODUCTID_PA;
            }
            //}

        }

        public static bool SaveSettings()
        {
            bool saved = false;

            try
            {
                ds_settings.WriteXml(Application.StartupPath + @"\Settings.xml");

                saved = true;
            }
            catch (Exception exc)
            {
                Log.WriteLog(Application.StartupPath + @"\" + Log.LOGFILENAME, "Cannot save settings. \n" + exc.ToString());
            }

            return saved;
        }

        public static string GetValueStr(string stSetting)
        {
            if (ds_settings.Tables["settings"] == null)
            {
                return "";
            }

            DataRow[] foundRows = ds_settings.Tables["settings"].Select("ID='" + stSetting + "'");


            string stRes = "";

            if ((foundRows != null) && (foundRows.Length > 0))
            {
                stRes = foundRows[0]["Value"].ToString();
            }

            ds_settings.Dispose();

            return stRes;
        }
        public static string GetOptionValue(string stSetting)
        {
            if (ds_settings.Tables["options"] == null) return "";

            //Settings stgs = new Settings();
            DataRow[] foundRows = ds_settings.Tables["options"].Select("ID='" + stSetting + "'");

            string stRes = "";
            if ((foundRows != null) && (foundRows.Length > 0))
                stRes = foundRows[0]["Value"].ToString();

            ds_settings.Dispose();

            return stRes;
        }
        public static string GetOptionDescription(string stSetting)
        {
            if (ds_settings.Tables["options"] == null) return "";

            //Settings stgs = new Settings();
            DataRow[] foundRows = ds_settings.Tables["options"].Select("ID='" + stSetting + "'");

            string stRes = "";
            if ((foundRows != null) && (foundRows.Length > 0))
                stRes = foundRows[0]["Description"].ToString();

            ds_settings.Dispose();

            return stRes;
        }
        public static string GetDatabaseValue(string stSetting)
        {
            if (ds_settings.Tables["database"] == null) return "";

            //Settings stgs = new Settings();
            DataRow[] foundRows = ds_settings.Tables["database"].Select("ID='" + stSetting + "'");

            string stRes = "";
            if ((foundRows != null) && (foundRows.Length > 0))
                stRes = foundRows[0]["Value"].ToString();

            ds_settings.Dispose();

            return stRes;
        }
        public static string GetConfigValue(string stSetting)
        {
            if (ds_settings.Tables["config"] == null) return "";

            //Settings stgs = new Settings();
            DataRow[] foundRows = ds_settings.Tables["config"].Select("ID='" + stSetting + "'");

            string stRes = "";
            if ((foundRows != null) && (foundRows.Length > 0))
                stRes = foundRows[0]["Value"].ToString();

            ds_settings.Dispose();

            return stRes;
        }


        /// <summary>
        /// Like:
        ///         stParams:       RecSrcID$101|https$ON|ID$4|
        ///         stParameter:    ID
        ///         sSep1:          |
        ///         sSep2:          $
        ///         
        /// </summary>
        /// <param name="stParams"></param>
        /// <param name="stParameter"></param>
        /// <param name="cSep1"></param>
        /// <param name="Sep2"></param>
        /// <returns></returns>
        public static string GetSpecificParam(string stParams, string stParameter, char cSep1, char Sep2)
        {
            string[] st = stParams.Split(cSep1);

            foreach (string stPar in st)
            {
                int i = 0;
                string[] stTemp = stPar.Split(Sep2);

                while (i < stTemp.Length)
                {
                    if ((stTemp[i++] == stParameter) && (i < stTemp.Length))
                        return stTemp[i];
                }
            }
            return "";
        }

        public static string GetPAParam(string stParams, string stParameter)
        {
            int iIndex = stParams.IndexOf(stParameter);

            string st = "";
            int iCount = stParams.Length - (iIndex + 4);
            char[] ch = new char[iCount];
            stParams.CopyTo(iIndex + 4, ch, 0, iCount);
            st = ConvertCharToString(ch);
            iIndex = st.IndexOf('|');
            ch = new char[iIndex];
            st.CopyTo(0, ch, 0, iIndex);
            st = ConvertCharToString(ch);
            return st;

        }

        public static void SaveConfigs(string stField, string stValue)
        {
            //Settings stgs = new Settings(Settings.eAppType.CCTV);
            DataRow[] dr = Settings.ds_settings.Tables["Config"].Select("ID='" + stField + "'");

            if (dr.Length == 0)
            {
                return;
            }

            dr[0][3] = stValue;

            Settings.SaveSettings();


            /** RVALE 20140707
            Settings stgs = new Settings(Settings.eAppType.CCTV);
            DataRow[] dr;
            dr = stgs.ds_settings.Tables["Config"].Select("ID='" + stField + "'");
            if (dr.Length == 0) return;

            dr[0][3] = stValue;

            stgs.SaveSettings();
            /**/
        }

        public static string ConvertCharToString(char[] c)
        {
            string st = "";
            for (int i = 0; i < c.Length; i++)
                st += c[i];

            return st;
        }
    }
}
