using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data;

namespace AdvancedCSharpSample
{
    /// <summary>
    /// Summary description for Search.
    /// </summary>
    public class MediaDatabaseForm : System.Windows.Forms.Form
    {
        public System.Collections.ArrayList m_tracks = null;
        public MainForm m_mainForm;
        public Bosch.VideoSDK.MediaDatabase.MediaDatabase m_mediaDatabase;
        public string m_dbName;
        private bool m_bContinuous = false;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.TextBox m_startyearText;
        private System.Windows.Forms.TextBox m_startmonthText;
        private System.Windows.Forms.TextBox m_startdayText;
        private System.Windows.Forms.TextBox m_starthourText;
        private System.Windows.Forms.TextBox m_startminText;
        private System.Windows.Forms.TextBox m_startsecText;

        private System.Windows.Forms.TextBox m_endyearText;
        private System.Windows.Forms.TextBox m_endmonthText;
        private System.Windows.Forms.TextBox m_enddayText;
        private System.Windows.Forms.TextBox m_endhourText;
        private System.Windows.Forms.TextBox m_endminText;
        private System.Windows.Forms.TextBox m_endsecText;

        //private System.Windows.Forms.DateTimePicker m_startDate;
        //private System.Windows.Forms.DateTimePicker m_endDate;
        //private System.Windows.Forms.DateTimePicker m_startTime;
        //private System.Windows.Forms.DateTimePicker m_endTime;
        
        private Bosch.VideoSDK.MediaDatabase.SearchSession m_trackSearchSession;
        private Bosch.VideoSDK.MediaDatabase.SearchSession m_eventSearchSession;
        private Bosch.VideoSDK.MediaDatabase.SearchSession m_timelineSearchSession;
        private System.Windows.Forms.CheckBox m_chkCam2;
        private System.Windows.Forms.CheckBox m_chkCam3;
        private System.Windows.Forms.CheckBox m_chkCam4;
        private System.Windows.Forms.CheckBox m_chkCam8;
        private System.Windows.Forms.CheckBox m_chkCam7;
        private System.Windows.Forms.CheckBox m_chkCam6;
        private System.Windows.Forms.CheckBox m_chkCam5;
        private System.Windows.Forms.CheckBox m_chkCam12;
        private System.Windows.Forms.CheckBox m_chkCam11;
        private System.Windows.Forms.CheckBox m_chkCam10;
        private System.Windows.Forms.CheckBox m_chkCam9;
        private System.Windows.Forms.CheckBox m_chkCam16;
        private System.Windows.Forms.CheckBox m_chkCam15;
        private System.Windows.Forms.CheckBox m_chkCam14;
        private System.Windows.Forms.CheckBox m_chkCam13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox m_chkAlarm;
        private System.Windows.Forms.CheckBox m_chkMotion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton m_radioTrack;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox m_progressText;
        private System.Windows.Forms.TextBox m_resultText;
        private System.Windows.Forms.RadioButton m_radioEvent;
        private System.Windows.Forms.RadioButton m_radioTimeline;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox m_textTimeout;
        private System.Windows.Forms.TextBox m_textTimelineGran;
        private System.Windows.Forms.CheckBox m_chkFirstAndLast;
        private System.Windows.Forms.Button m_btnSearch;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.CheckBox m_chkCam20;
        private System.Windows.Forms.CheckBox m_chkCam19;
        private System.Windows.Forms.CheckBox m_chkCam18;
        private System.Windows.Forms.CheckBox m_chkCam17;
        private System.Windows.Forms.CheckBox m_chkVideo;
        private System.Windows.Forms.CheckBox m_chkVideoLoss;
        private System.Windows.Forms.Button m_btnAll;
        private System.Windows.Forms.Button m_btnNone;
        private System.Windows.Forms.CheckBox m_chkCam1;
        private System.Windows.Forms.Button m_btnTrackOperations;
        private System.Windows.Forms.RadioButton m_radioContinuousTimeline;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox m_FilterString;
        private System.Windows.Forms.TextBox m_txtTrackID;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button m_btnGetMediaSession;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public MediaDatabaseForm(Bosch.VideoSDK.MediaDatabase.MediaDatabase mdb, string dbName, MainForm mainForm)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            if (mdb != null)
                m_mediaDatabase = mdb;

            DateTime currentTime = DateTime.Now;
            DateTime beginTime = currentTime.AddHours(-24);
            DateTime endTime = currentTime.AddHours(0);


            this.m_startyearText.Text = ""+beginTime.Year;
            this.m_startmonthText.Text = "" + beginTime.Month;
            this.m_startdayText.Text = "" + beginTime.Day;
            this.m_starthourText.Text = "" + beginTime.Hour;
            this.m_startminText.Text = "" + beginTime.Minute;
            this.m_startsecText.Text = "" + beginTime.Second;

            this.m_endyearText.Text = "" + endTime.Year;
            this.m_endmonthText.Text = "" + endTime.Month;
            this.m_enddayText.Text = "" + endTime.Day;
            this.m_endhourText.Text = "" + endTime.Hour;
            this.m_endminText.Text = "" + endTime.Minute;
            this.m_endsecText.Text = "" + endTime.Second;

            /***
            m_startDate.Value = beginTime.ToLocalTime();
            m_startTime.Value = beginTime.ToLocalTime();
            m_endDate.Value = endTime.ToLocalTime();
            m_endTime.Value = endTime.ToLocalTime();
            /**/
            
            m_textTimelineGran.Text = "1800";

            m_dbName = dbName;
            this.Text += " - " + m_dbName;

            // Create an empty track array.
            m_tracks = new System.Collections.ArrayList(0);

            // Store a reference to the main form for logging.
            m_mainForm = mainForm;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_startyearText = new System.Windows.Forms.TextBox();
            this.m_startmonthText = new System.Windows.Forms.TextBox();
            this.m_startdayText = new System.Windows.Forms.TextBox();
            this.m_starthourText = new System.Windows.Forms.TextBox();
            this.m_startminText = new System.Windows.Forms.TextBox();
            this.m_startsecText = new System.Windows.Forms.TextBox();
            this.m_endyearText = new System.Windows.Forms.TextBox();
            this.m_endmonthText = new System.Windows.Forms.TextBox();
            this.m_enddayText = new System.Windows.Forms.TextBox();
            this.m_endhourText = new System.Windows.Forms.TextBox();
            this.m_endminText = new System.Windows.Forms.TextBox();
            this.m_endsecText = new System.Windows.Forms.TextBox();
            this.m_btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_chkCam1 = new System.Windows.Forms.CheckBox();
            this.m_chkCam2 = new System.Windows.Forms.CheckBox();
            this.m_chkCam3 = new System.Windows.Forms.CheckBox();
            this.m_chkCam4 = new System.Windows.Forms.CheckBox();
            this.m_chkCam8 = new System.Windows.Forms.CheckBox();
            this.m_chkCam7 = new System.Windows.Forms.CheckBox();
            this.m_chkCam6 = new System.Windows.Forms.CheckBox();
            this.m_chkCam5 = new System.Windows.Forms.CheckBox();
            this.m_chkCam12 = new System.Windows.Forms.CheckBox();
            this.m_chkCam11 = new System.Windows.Forms.CheckBox();
            this.m_chkCam10 = new System.Windows.Forms.CheckBox();
            this.m_chkCam9 = new System.Windows.Forms.CheckBox();
            this.m_chkCam16 = new System.Windows.Forms.CheckBox();
            this.m_chkCam15 = new System.Windows.Forms.CheckBox();
            this.m_chkCam14 = new System.Windows.Forms.CheckBox();
            this.m_chkCam13 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.m_radioTrack = new System.Windows.Forms.RadioButton();
            this.m_radioEvent = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_radioContinuousTimeline = new System.Windows.Forms.RadioButton();
            this.m_radioTimeline = new System.Windows.Forms.RadioButton();
            this.m_chkAlarm = new System.Windows.Forms.CheckBox();
            this.m_chkMotion = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_chkVideo = new System.Windows.Forms.CheckBox();
            this.m_chkVideoLoss = new System.Windows.Forms.CheckBox();
            this.m_textTimeout = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.m_chkFirstAndLast = new System.Windows.Forms.CheckBox();
            this.m_progressText = new System.Windows.Forms.TextBox();
            this.m_resultText = new System.Windows.Forms.TextBox();
            this.m_textTimelineGran = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_btnAll = new System.Windows.Forms.Button();
            this.m_btnNone = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.m_chkCam20 = new System.Windows.Forms.CheckBox();
            this.m_chkCam19 = new System.Windows.Forms.CheckBox();
            this.m_chkCam18 = new System.Windows.Forms.CheckBox();
            this.m_chkCam17 = new System.Windows.Forms.CheckBox();
            this.m_btnTrackOperations = new System.Windows.Forms.Button();
            this.m_FilterString = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.m_btnGetMediaSession = new System.Windows.Forms.Button();
            this.m_txtTrackID = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_startyearText
            // 
            this.m_startyearText.Location = new System.Drawing.Point(72, 8);
            this.m_startyearText.Name = "m_startyearText";
            this.m_startyearText.Size = new System.Drawing.Size(30, 20);
            this.m_startyearText.TabIndex = 1;
            // 
            // m_startmonthText
            // 
            this.m_startmonthText.Location = new System.Drawing.Point(104, 8);
            this.m_startmonthText.Name = "m_startmonthText";
            this.m_startmonthText.Size = new System.Drawing.Size(30, 20);
            this.m_startmonthText.TabIndex = 1;
            // 
            // m_startdayText
            // 
            this.m_startdayText.Location = new System.Drawing.Point(136, 8);
            this.m_startdayText.Name = "m_startdayText";
            this.m_startdayText.Size = new System.Drawing.Size(30, 20);
            this.m_startdayText.TabIndex = 1;
            // 
            // m_starthourText
            // 
            this.m_starthourText.Location = new System.Drawing.Point(168, 8);
            this.m_starthourText.Name = "m_starthourText";
            this.m_starthourText.Size = new System.Drawing.Size(30, 20);
            this.m_starthourText.TabIndex = 3;
            // 
            // m_startminText
            // 
            this.m_startminText.Location = new System.Drawing.Point(200, 8);
            this.m_startminText.Name = "m_startminText";
            this.m_startminText.Size = new System.Drawing.Size(30, 20);
            this.m_startminText.TabIndex = 3;
            // 
            // m_startsecText
            // 
            this.m_startsecText.Location = new System.Drawing.Point(232, 8);
            this.m_startsecText.Name = "m_startsecText";
            this.m_startsecText.Size = new System.Drawing.Size(30, 20);
            this.m_startsecText.TabIndex = 3;
            // 
            // m_endyearText
            // 
            this.m_endyearText.Location = new System.Drawing.Point(72, 32);
            this.m_endyearText.Name = "m_endyearText";
            this.m_endyearText.Size = new System.Drawing.Size(30, 20);
            this.m_endyearText.TabIndex = 2;
            // 
            // m_endmonthText
            // 
            this.m_endmonthText.Location = new System.Drawing.Point(104, 32);
            this.m_endmonthText.Name = "m_endmonthText";
            this.m_endmonthText.Size = new System.Drawing.Size(30, 20);
            this.m_endmonthText.TabIndex = 2;
            // 
            // m_enddayText
            // 
            this.m_enddayText.Location = new System.Drawing.Point(136, 32);
            this.m_enddayText.Name = "m_enddayText";
            this.m_enddayText.Size = new System.Drawing.Size(30, 20);
            this.m_enddayText.TabIndex = 2;
            // 
            // m_endhourText
            // 
            this.m_endhourText.Location = new System.Drawing.Point(168, 32);
            this.m_endhourText.Name = "m_endhourText";
            this.m_endhourText.Size = new System.Drawing.Size(30, 20);
            this.m_endhourText.TabIndex = 4;
            // 
            // m_endminText
            // 
            this.m_endminText.Location = new System.Drawing.Point(200, 32);
            this.m_endminText.Name = "m_endminText";
            this.m_endminText.Size = new System.Drawing.Size(30, 20);
            this.m_endminText.TabIndex = 4;
            // 
            // m_endsecText
            // 
            this.m_endsecText.Location = new System.Drawing.Point(232, 32);
            this.m_endsecText.Name = "m_endsecText";
            this.m_endsecText.Size = new System.Drawing.Size(30, 20);
            this.m_endsecText.TabIndex = 4;
            // 
            // m_btnSearch
            // 
            this.m_btnSearch.Location = new System.Drawing.Point(8, 144);
            this.m_btnSearch.Name = "m_btnSearch";
            this.m_btnSearch.Size = new System.Drawing.Size(88, 23);
            this.m_btnSearch.TabIndex = 55;
            this.m_btnSearch.Text = "Start Search";
            this.m_btnSearch.Click += new System.EventHandler(this.m_btnSearch_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Start Time";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "End Time";
            // 
            // m_chkCam1
            // 
            this.m_chkCam1.Checked = true;
            this.m_chkCam1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCam1.Location = new System.Drawing.Point(488, 16);
            this.m_chkCam1.Name = "m_chkCam1";
            this.m_chkCam1.Size = new System.Drawing.Size(16, 24);
            this.m_chkCam1.TabIndex = 8;
            this.m_chkCam1.Tag = "";
            // 
            // m_chkCam2
            // 
            this.m_chkCam2.Checked = true;
            this.m_chkCam2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCam2.Location = new System.Drawing.Point(504, 16);
            this.m_chkCam2.Name = "m_chkCam2";
            this.m_chkCam2.Size = new System.Drawing.Size(16, 24);
            this.m_chkCam2.TabIndex = 9;
            this.m_chkCam2.Tag = "";
            // 
            // m_chkCam3
            // 
            this.m_chkCam3.Checked = true;
            this.m_chkCam3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCam3.Location = new System.Drawing.Point(520, 16);
            this.m_chkCam3.Name = "m_chkCam3";
            this.m_chkCam3.Size = new System.Drawing.Size(16, 24);
            this.m_chkCam3.TabIndex = 10;
            // 
            // m_chkCam4
            // 
            this.m_chkCam4.Checked = true;
            this.m_chkCam4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCam4.Location = new System.Drawing.Point(536, 16);
            this.m_chkCam4.Name = "m_chkCam4";
            this.m_chkCam4.Size = new System.Drawing.Size(16, 24);
            this.m_chkCam4.TabIndex = 11;
            // 
            // m_chkCam8
            // 
            this.m_chkCam8.Checked = true;
            this.m_chkCam8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCam8.Location = new System.Drawing.Point(600, 16);
            this.m_chkCam8.Name = "m_chkCam8";
            this.m_chkCam8.Size = new System.Drawing.Size(16, 24);
            this.m_chkCam8.TabIndex = 15;
            // 
            // m_chkCam7
            // 
            this.m_chkCam7.Checked = true;
            this.m_chkCam7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCam7.Location = new System.Drawing.Point(584, 16);
            this.m_chkCam7.Name = "m_chkCam7";
            this.m_chkCam7.Size = new System.Drawing.Size(16, 24);
            this.m_chkCam7.TabIndex = 14;
            // 
            // m_chkCam6
            // 
            this.m_chkCam6.Checked = true;
            this.m_chkCam6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCam6.Location = new System.Drawing.Point(568, 16);
            this.m_chkCam6.Name = "m_chkCam6";
            this.m_chkCam6.Size = new System.Drawing.Size(16, 24);
            this.m_chkCam6.TabIndex = 13;
            // 
            // m_chkCam5
            // 
            this.m_chkCam5.Checked = true;
            this.m_chkCam5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCam5.Location = new System.Drawing.Point(552, 16);
            this.m_chkCam5.Name = "m_chkCam5";
            this.m_chkCam5.Size = new System.Drawing.Size(16, 24);
            this.m_chkCam5.TabIndex = 12;
            // 
            // m_chkCam12
            // 
            this.m_chkCam12.Checked = true;
            this.m_chkCam12.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCam12.Location = new System.Drawing.Point(504, 56);
            this.m_chkCam12.Name = "m_chkCam12";
            this.m_chkCam12.Size = new System.Drawing.Size(24, 24);
            this.m_chkCam12.TabIndex = 19;
            // 
            // m_chkCam11
            // 
            this.m_chkCam11.Checked = true;
            this.m_chkCam11.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCam11.Location = new System.Drawing.Point(488, 56);
            this.m_chkCam11.Name = "m_chkCam11";
            this.m_chkCam11.Size = new System.Drawing.Size(16, 24);
            this.m_chkCam11.TabIndex = 18;
            // 
            // m_chkCam10
            // 
            this.m_chkCam10.Checked = true;
            this.m_chkCam10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCam10.Location = new System.Drawing.Point(632, 16);
            this.m_chkCam10.Name = "m_chkCam10";
            this.m_chkCam10.Size = new System.Drawing.Size(16, 24);
            this.m_chkCam10.TabIndex = 17;
            // 
            // m_chkCam9
            // 
            this.m_chkCam9.Checked = true;
            this.m_chkCam9.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCam9.Location = new System.Drawing.Point(616, 16);
            this.m_chkCam9.Name = "m_chkCam9";
            this.m_chkCam9.Size = new System.Drawing.Size(16, 24);
            this.m_chkCam9.TabIndex = 16;
            // 
            // m_chkCam16
            // 
            this.m_chkCam16.Checked = true;
            this.m_chkCam16.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCam16.Location = new System.Drawing.Point(568, 56);
            this.m_chkCam16.Name = "m_chkCam16";
            this.m_chkCam16.Size = new System.Drawing.Size(16, 24);
            this.m_chkCam16.TabIndex = 23;
            // 
            // m_chkCam15
            // 
            this.m_chkCam15.Checked = true;
            this.m_chkCam15.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCam15.Location = new System.Drawing.Point(552, 56);
            this.m_chkCam15.Name = "m_chkCam15";
            this.m_chkCam15.Size = new System.Drawing.Size(16, 24);
            this.m_chkCam15.TabIndex = 22;
            // 
            // m_chkCam14
            // 
            this.m_chkCam14.Checked = true;
            this.m_chkCam14.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCam14.Location = new System.Drawing.Point(536, 56);
            this.m_chkCam14.Name = "m_chkCam14";
            this.m_chkCam14.Size = new System.Drawing.Size(16, 24);
            this.m_chkCam14.TabIndex = 21;
            // 
            // m_chkCam13
            // 
            this.m_chkCam13.Checked = true;
            this.m_chkCam13.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCam13.Location = new System.Drawing.Point(520, 56);
            this.m_chkCam13.Name = "m_chkCam13";
            this.m_chkCam13.Size = new System.Drawing.Size(16, 24);
            this.m_chkCam13.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(488, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "1";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(504, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "2";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(520, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 16);
            this.label6.TabIndex = 27;
            this.label6.Text = "3";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(536, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 16);
            this.label7.TabIndex = 28;
            this.label7.Text = "4";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(552, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 16);
            this.label8.TabIndex = 29;
            this.label8.Text = "5";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(96, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 16);
            this.label9.TabIndex = 30;
            this.label9.Text = "6";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(584, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 16);
            this.label10.TabIndex = 31;
            this.label10.Text = "7";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(600, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 16);
            this.label11.TabIndex = 32;
            this.label11.Text = "8";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(616, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 16);
            this.label12.TabIndex = 33;
            this.label12.Text = "9";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(632, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 16);
            this.label13.TabIndex = 34;
            this.label13.Text = "10";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(488, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 16);
            this.label14.TabIndex = 35;
            this.label14.Text = "11";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(504, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 16);
            this.label15.TabIndex = 36;
            this.label15.Text = "12";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(520, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 16);
            this.label16.TabIndex = 37;
            this.label16.Text = "13";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(536, 80);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(24, 16);
            this.label17.TabIndex = 38;
            this.label17.Text = "14";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(552, 80);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 16);
            this.label18.TabIndex = 39;
            this.label18.Text = "15";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(568, 80);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(24, 16);
            this.label19.TabIndex = 40;
            this.label19.Text = "16";
            // 
            // m_radioTrack
            // 
            this.m_radioTrack.Checked = true;
            this.m_radioTrack.Location = new System.Drawing.Point(8, 24);
            this.m_radioTrack.Name = "m_radioTrack";
            this.m_radioTrack.Size = new System.Drawing.Size(64, 24);
            this.m_radioTrack.TabIndex = 41;
            this.m_radioTrack.TabStop = true;
            this.m_radioTrack.Text = "Track";
            // 
            // m_radioEvent
            // 
            this.m_radioEvent.Location = new System.Drawing.Point(8, 48);
            this.m_radioEvent.Name = "m_radioEvent";
            this.m_radioEvent.Size = new System.Drawing.Size(56, 24);
            this.m_radioEvent.TabIndex = 42;
            this.m_radioEvent.Text = "Event";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_radioContinuousTimeline);
            this.groupBox1.Controls.Add(this.m_radioTrack);
            this.groupBox1.Controls.Add(this.m_radioEvent);
            this.groupBox1.Controls.Add(this.m_radioTimeline);
            this.groupBox1.Location = new System.Drawing.Point(280, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(96, 136);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Type";
            // 
            // m_radioContinuousTimeline
            // 
            this.m_radioContinuousTimeline.Location = new System.Drawing.Point(8, 96);
            this.m_radioContinuousTimeline.Name = "m_radioContinuousTimeline";
            this.m_radioContinuousTimeline.Size = new System.Drawing.Size(80, 32);
            this.m_radioContinuousTimeline.TabIndex = 44;
            this.m_radioContinuousTimeline.Text = "ContinuousTimeline";
            // 
            // m_radioTimeline
            // 
            this.m_radioTimeline.Location = new System.Drawing.Point(8, 72);
            this.m_radioTimeline.Name = "m_radioTimeline";
            this.m_radioTimeline.Size = new System.Drawing.Size(72, 24);
            this.m_radioTimeline.TabIndex = 43;
            this.m_radioTimeline.Text = "Timeline";
            // 
            // m_chkAlarm
            // 
            this.m_chkAlarm.Location = new System.Drawing.Point(8, 56);
            this.m_chkAlarm.Name = "m_chkAlarm";
            this.m_chkAlarm.Size = new System.Drawing.Size(56, 24);
            this.m_chkAlarm.TabIndex = 44;
            this.m_chkAlarm.Text = "Alarm";
            // 
            // m_chkMotion
            // 
            this.m_chkMotion.Location = new System.Drawing.Point(8, 80);
            this.m_chkMotion.Name = "m_chkMotion";
            this.m_chkMotion.Size = new System.Drawing.Size(64, 24);
            this.m_chkMotion.TabIndex = 45;
            this.m_chkMotion.Text = "Motion";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_chkVideo);
            this.groupBox2.Controls.Add(this.m_chkAlarm);
            this.groupBox2.Controls.Add(this.m_chkMotion);
            this.groupBox2.Controls.Add(this.m_chkVideoLoss);
            this.groupBox2.Location = new System.Drawing.Point(384, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(80, 136);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter Event Types";
            // 
            // m_chkVideo
            // 
            this.m_chkVideo.Checked = true;
            this.m_chkVideo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkVideo.Location = new System.Drawing.Point(8, 32);
            this.m_chkVideo.Name = "m_chkVideo";
            this.m_chkVideo.Size = new System.Drawing.Size(64, 24);
            this.m_chkVideo.TabIndex = 64;
            this.m_chkVideo.Text = "Video";
            // 
            // m_chkVideoLoss
            // 
            this.m_chkVideoLoss.Location = new System.Drawing.Point(8, 104);
            this.m_chkVideoLoss.Name = "m_chkVideoLoss";
            this.m_chkVideoLoss.Size = new System.Drawing.Size(64, 24);
            this.m_chkVideoLoss.TabIndex = 65;
            this.m_chkVideoLoss.Text = "Video Loss";
            // 
            // m_textTimeout
            // 
            this.m_textTimeout.Location = new System.Drawing.Point(112, 64);
            this.m_textTimeout.Name = "m_textTimeout";
            this.m_textTimeout.Size = new System.Drawing.Size(72, 20);
            this.m_textTimeout.TabIndex = 47;
            this.m_textTimeout.Text = "10000";
            // 
            // label20
            // 
            this.label20.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label20.Location = new System.Drawing.Point(8, 64);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 16);
            this.label20.TabIndex = 48;
            this.label20.Text = "Timeout:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_chkFirstAndLast
            // 
            this.m_chkFirstAndLast.Location = new System.Drawing.Point(192, 64);
            this.m_chkFirstAndLast.Name = "m_chkFirstAndLast";
            this.m_chkFirstAndLast.Size = new System.Drawing.Size(72, 32);
            this.m_chkFirstAndLast.TabIndex = 54;
            this.m_chkFirstAndLast.Text = "First and Last Only";
            // 
            // m_progressText
            // 
            this.m_progressText.Enabled = false;
            this.m_progressText.Location = new System.Drawing.Point(104, 144);
            this.m_progressText.Name = "m_progressText";
            this.m_progressText.Size = new System.Drawing.Size(56, 20);
            this.m_progressText.TabIndex = 50;
            // 
            // m_resultText
            // 
            this.m_resultText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_resultText.Location = new System.Drawing.Point(8, 176);
            this.m_resultText.Multiline = true;
            this.m_resultText.Name = "m_resultText";
            this.m_resultText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.m_resultText.Size = new System.Drawing.Size(656, 136);
            this.m_resultText.TabIndex = 51;
            this.m_resultText.WordWrap = false;
            // 
            // m_textTimelineGran
            // 
            this.m_textTimelineGran.Location = new System.Drawing.Point(112, 88);
            this.m_textTimelineGran.Name = "m_textTimelineGran";
            this.m_textTimelineGran.Size = new System.Drawing.Size(72, 20);
            this.m_textTimelineGran.TabIndex = 52;
            this.m_textTimelineGran.Text = "60";
            // 
            // label21
            // 
            this.label21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label21.Location = new System.Drawing.Point(0, 89);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(102, 16);
            this.label21.TabIndex = 53;
            this.label21.Text = "Granularity:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label21.Click += new System.EventHandler(this.label21_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.m_btnAll);
            this.groupBox3.Controls.Add(this.m_btnNone);
            this.groupBox3.Location = new System.Drawing.Point(472, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(192, 136);
            this.groupBox3.TabIndex = 47;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter Tracks";
            // 
            // m_btnAll
            // 
            this.m_btnAll.Location = new System.Drawing.Point(16, 104);
            this.m_btnAll.Name = "m_btnAll";
            this.m_btnAll.Size = new System.Drawing.Size(72, 24);
            this.m_btnAll.TabIndex = 0;
            this.m_btnAll.Text = "All";
            this.m_btnAll.Click += new System.EventHandler(this.m_btnAll_Click);
            // 
            // m_btnNone
            // 
            this.m_btnNone.Location = new System.Drawing.Point(104, 104);
            this.m_btnNone.Name = "m_btnNone";
            this.m_btnNone.Size = new System.Drawing.Size(72, 24);
            this.m_btnNone.TabIndex = 1;
            this.m_btnNone.Text = "None";
            this.m_btnNone.Click += new System.EventHandler(this.m_btnNone_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(632, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 63;
            this.label3.Text = "20";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(616, 80);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(24, 16);
            this.label22.TabIndex = 62;
            this.label22.Text = "19";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(600, 80);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(24, 16);
            this.label23.TabIndex = 61;
            this.label23.Text = "18";
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(584, 80);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(24, 16);
            this.label24.TabIndex = 60;
            this.label24.Text = "17";
            // 
            // m_chkCam20
            // 
            this.m_chkCam20.Checked = true;
            this.m_chkCam20.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCam20.Location = new System.Drawing.Point(632, 56);
            this.m_chkCam20.Name = "m_chkCam20";
            this.m_chkCam20.Size = new System.Drawing.Size(16, 24);
            this.m_chkCam20.TabIndex = 59;
            // 
            // m_chkCam19
            // 
            this.m_chkCam19.Checked = true;
            this.m_chkCam19.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCam19.Location = new System.Drawing.Point(616, 56);
            this.m_chkCam19.Name = "m_chkCam19";
            this.m_chkCam19.Size = new System.Drawing.Size(16, 24);
            this.m_chkCam19.TabIndex = 58;
            // 
            // m_chkCam18
            // 
            this.m_chkCam18.Checked = true;
            this.m_chkCam18.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCam18.Location = new System.Drawing.Point(600, 56);
            this.m_chkCam18.Name = "m_chkCam18";
            this.m_chkCam18.Size = new System.Drawing.Size(16, 24);
            this.m_chkCam18.TabIndex = 57;
            // 
            // m_chkCam17
            // 
            this.m_chkCam17.Checked = true;
            this.m_chkCam17.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCam17.Location = new System.Drawing.Point(584, 56);
            this.m_chkCam17.Name = "m_chkCam17";
            this.m_chkCam17.Size = new System.Drawing.Size(24, 24);
            this.m_chkCam17.TabIndex = 56;
            // 
            // m_btnTrackOperations
            // 
            this.m_btnTrackOperations.Location = new System.Drawing.Point(192, 144);
            this.m_btnTrackOperations.Name = "m_btnTrackOperations";
            this.m_btnTrackOperations.Size = new System.Drawing.Size(104, 23);
            this.m_btnTrackOperations.TabIndex = 64;
            this.m_btnTrackOperations.Text = "Track Operations...";
            this.m_btnTrackOperations.Click += new System.EventHandler(this.m_btnTrackOperations_Click);
            // 
            // m_FilterString
            // 
            this.m_FilterString.Location = new System.Drawing.Point(112, 112);
            this.m_FilterString.Name = "m_FilterString";
            this.m_FilterString.Size = new System.Drawing.Size(120, 20);
            this.m_FilterString.TabIndex = 65;
            this.m_FilterString.TextChanged += new System.EventHandler(this.m_FilterString_TextChanged);
            // 
            // label25
            // 
            this.label25.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label25.Location = new System.Drawing.Point(16, 112);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(80, 16);
            this.label25.TabIndex = 66;
            this.label25.Text = "StringFilter:";
            // 
            // m_btnGetMediaSession
            // 
            this.m_btnGetMediaSession.Location = new System.Drawing.Point(328, 144);
            this.m_btnGetMediaSession.Name = "m_btnGetMediaSession";
            this.m_btnGetMediaSession.Size = new System.Drawing.Size(120, 23);
            this.m_btnGetMediaSession.TabIndex = 67;
            this.m_btnGetMediaSession.Text = "GetMediaSession";
            this.m_btnGetMediaSession.Click += new System.EventHandler(this.m_btnGetMediaSession_Click);
            // 
            // m_txtTrackID
            // 
            this.m_txtTrackID.Location = new System.Drawing.Point(512, 144);
            this.m_txtTrackID.Name = "m_txtTrackID";
            this.m_txtTrackID.Size = new System.Drawing.Size(32, 20);
            this.m_txtTrackID.TabIndex = 68;
            this.m_txtTrackID.Text = "0";
            // 
            // label26
            // 
            this.label26.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label26.Location = new System.Drawing.Point(456, 144);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(48, 24);
            this.label26.TabIndex = 69;
            this.label26.Text = "TrackID:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MediaDatabaseForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(672, 317);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.m_txtTrackID);
            this.Controls.Add(this.m_btnGetMediaSession);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.m_FilterString);
            this.Controls.Add(this.m_btnTrackOperations);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.m_chkCam20);
            this.Controls.Add(this.m_chkCam19);
            this.Controls.Add(this.m_chkCam18);
            this.Controls.Add(this.m_chkCam17);
            this.Controls.Add(this.m_textTimelineGran);
            this.Controls.Add(this.m_resultText);
            this.Controls.Add(this.m_progressText);
            this.Controls.Add(this.m_textTimeout);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.m_chkFirstAndLast);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_chkCam16);
            this.Controls.Add(this.m_chkCam15);
            this.Controls.Add(this.m_chkCam14);
            this.Controls.Add(this.m_chkCam13);
            this.Controls.Add(this.m_chkCam12);
            this.Controls.Add(this.m_chkCam11);
            this.Controls.Add(this.m_chkCam10);
            this.Controls.Add(this.m_chkCam9);
            this.Controls.Add(this.m_chkCam8);
            this.Controls.Add(this.m_chkCam7);
            this.Controls.Add(this.m_chkCam6);
            this.Controls.Add(this.m_chkCam5);
            this.Controls.Add(this.m_chkCam4);
            this.Controls.Add(this.m_chkCam3);
            this.Controls.Add(this.m_chkCam2);
            this.Controls.Add(this.m_chkCam1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_btnSearch);
            this.Controls.Add(this.m_endyearText);
            this.Controls.Add(this.m_endmonthText);
            this.Controls.Add(this.m_enddayText);
            this.Controls.Add(this.m_startyearText);
            this.Controls.Add(this.m_startmonthText);
            this.Controls.Add(this.m_startdayText);
            this.Controls.Add(this.m_endhourText);
            this.Controls.Add(this.m_endminText);
            this.Controls.Add(this.m_endsecText);
            this.Controls.Add(this.m_starthourText);
            this.Controls.Add(this.m_startminText);
            this.Controls.Add(this.m_startsecText);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "MediaDatabaseForm";
            this.Text = "Media Database";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private Bosch.VideoSDK.MediaDatabase.Time64 FillStartTime()
        {
            Bosch.VideoSDK.MediaDatabase.Time64 t64 = new Bosch.VideoSDK.MediaDatabase.Time64();
            /***
            DateTime dt = new DateTime(
                m_startDate.Value.Year,
                m_startDate.Value.Month,
                m_startDate.Value.Day,
                m_startTime.Value.Hour,
                m_startTime.Value.Minute,
                m_startTime.Value.Second);       
            /**/

            DateTime dt = new DateTime(
                int.Parse(this.m_startyearText.Text),
                int.Parse(this.m_startmonthText.Text),
                int.Parse(this.m_startdayText.Text),
                int.Parse(this.m_starthourText.Text),
                int.Parse(this.m_startminText.Text),
                int.Parse(this.m_startsecText.Text));

            t64.UTC = dt;

            return t64;
        }

        private Bosch.VideoSDK.MediaDatabase.Time64 FillEndTime()
        {
            Bosch.VideoSDK.MediaDatabase.Time64 t64 = new Bosch.VideoSDK.MediaDatabase.Time64();

            /***
            DateTime dt = new DateTime(
                m_endDate.Value.Year,
                m_endDate.Value.Month,
                m_endDate.Value.Day,
                m_endTime.Value.Hour,
                m_endTime.Value.Minute,
                m_endTime.Value.Second);
            /**/
            DateTime dt = new DateTime(
                int.Parse(this.m_endyearText.Text),
                int.Parse(this.m_endmonthText.Text),
                int.Parse(this.m_enddayText.Text),
                int.Parse(this.m_endhourText.Text),
                int.Parse(this.m_endminText.Text),
                int.Parse(this.m_endsecText.Text));

            t64.UTC = dt;

            return t64;
        }

        private void FillIdentifierFilter(Bosch.VideoSDK.MediaDatabase.SearchSession searchSession)
        {
            searchSession.ClearIdentifierFilter();

            if (m_chkCam1.Checked)
                searchSession.AddIdentifierFilter(1);
            if (m_chkCam2.Checked)
                searchSession.AddIdentifierFilter(2);
            if (m_chkCam3.Checked)
                searchSession.AddIdentifierFilter(3);
            if (m_chkCam4.Checked)
                searchSession.AddIdentifierFilter(4);
            if (m_chkCam5.Checked)
                searchSession.AddIdentifierFilter(5);
            if (m_chkCam6.Checked)
                searchSession.AddIdentifierFilter(6);
            if (m_chkCam7.Checked)
                searchSession.AddIdentifierFilter(7);
            if (m_chkCam8.Checked)
                searchSession.AddIdentifierFilter(8);
            if (m_chkCam9.Checked)
                searchSession.AddIdentifierFilter(9);
            if (m_chkCam10.Checked)
                searchSession.AddIdentifierFilter(10);
            if (m_chkCam11.Checked)
                searchSession.AddIdentifierFilter(11);
            if (m_chkCam12.Checked)
                searchSession.AddIdentifierFilter(12);
            if (m_chkCam13.Checked)
                searchSession.AddIdentifierFilter(13);
            if (m_chkCam14.Checked)
                searchSession.AddIdentifierFilter(14);
            if (m_chkCam15.Checked)
                searchSession.AddIdentifierFilter(15);
            if (m_chkCam16.Checked)
                searchSession.AddIdentifierFilter(16);
            if (m_chkCam17.Checked)
                searchSession.AddIdentifierFilter(17);
            if (m_chkCam18.Checked)
                searchSession.AddIdentifierFilter(18);
            if (m_chkCam19.Checked)
                searchSession.AddIdentifierFilter(19);
            if (m_chkCam20.Checked)
                searchSession.AddIdentifierFilter(20);
        }

        private void FillEventFilter(Bosch.VideoSDK.MediaDatabase.SearchSession searchSession)
        {
            searchSession.ClearEventFilter();

            try
            {
                if (m_chkAlarm.Checked)
                    searchSession.AddEventFilter(Bosch.VideoSDK.MediaDatabase.EventTypeEnum.eteContact);
            }
            catch (Exception e)
            {
                m_mainForm.ErrorMessage("MediaDatabaseForm", "FillEventFilter", e.Message, true);
            }

            try
            {
                if (m_chkMotion.Checked)
                    searchSession.AddEventFilter(Bosch.VideoSDK.MediaDatabase.EventTypeEnum.eteMotion);
            }
            catch (Exception e)
            {
                m_mainForm.ErrorMessage("MediaDatabaseForm", "FillEventFilter", e.Message, true);
            }

            try
            {
                if (m_chkVideo.Checked)
                    searchSession.AddEventFilter(Bosch.VideoSDK.MediaDatabase.EventTypeEnum.eteVideoRecorded);
            }
            catch (Exception e)
            {
                m_mainForm.ErrorMessage("MediaDatabaseForm", "FillEventFilter", e.Message, true);
            }

            try
            {
                if (m_chkVideoLoss.Checked)
                    searchSession.AddEventFilter(Bosch.VideoSDK.MediaDatabase.EventTypeEnum.eteVideoLoss);
            }
            catch (Exception e)
            {
                m_mainForm.ErrorMessage("MediaDatabaseForm", "FillEventFilter", e.Message, true);
            }
        }

        private bool StartTrackSearch()
        {
            bool bStarted = true;

            if (m_trackSearchSession == null)
            {
                try
                {
                    //create search session
                    m_trackSearchSession = m_mediaDatabase.CreateSearchSession(Bosch.VideoSDK.MediaDatabase.SearchTypeEnum.steTrack);
                }
                catch(System.Exception e)
                {
                    m_mainForm.ErrorMessage("MediaDatabaseForm", "StartTrackSearch", e.Message, true);
                    bStarted = false;
                    return bStarted;
                }
                //register for "TrackAvailable" event
                ((Bosch.VideoSDK.GCALib._ISearchSessionEvents_Event)m_trackSearchSession).TrackAvailable += new
                    Bosch.VideoSDK.GCALib._ISearchSessionEvents_TrackAvailableEventHandler(OnTrackAvailable);
            }

            //register for "Progress" Events
            ((Bosch.VideoSDK.GCALib._ISearchSessionEvents_Event)m_trackSearchSession).Progress += new
                Bosch.VideoSDK.GCALib._ISearchSessionEvents_ProgressEventHandler(OnProgress);

            // Empty the current track array.
            m_tracks.Clear();

            // Print a header.
            m_resultText.Text += System.Environment.NewLine;
            m_resultText.Text += "------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            m_resultText.Text += System.Environment.NewLine;
            m_resultText.Text += "TRACK SEARCH RESULTS";
            m_resultText.Text += System.Environment.NewLine;
            m_resultText.Text += System.Environment.NewLine;

            // Set start and end time for search.
            m_trackSearchSession.StartTimeFilter = FillStartTime();
            Bosch.VideoSDK.MediaDatabase.Time64 time64Start = m_trackSearchSession.StartTimeFilter;
            if (time64Start != null)
            {
                string tempString = "";

                tempString = time64Start.UTC.ToString("yyyy-MM-dd HH:mm:ss");
                tempString = tempString.PadRight(30, ' ');
                m_resultText.Text += tempString;
            }
            else
            {
                m_resultText.Text += " no start time to send to the NVR    ";
            }

            m_resultText.Text += System.Environment.NewLine;


            m_trackSearchSession.EndTimeFilter = FillEndTime();
            Bosch.VideoSDK.MediaDatabase.Time64 time64End = m_trackSearchSession.EndTimeFilter;
            if (time64End != null)
            {                              
                string tempString = "";

                tempString = time64End.UTC.ToString("yyyy-MM-dd HH:mm:ss");
                tempString = tempString.PadRight(30, ' ');
                m_resultText.Text += tempString;
            }
            else
            {
                m_resultText.Text += " no end time to send to the NVR      ";
            }
            m_resultText.Text += System.Environment.NewLine;
            m_resultText.Text += System.Environment.NewLine;




            // Add which tracks to search.
            FillIdentifierFilter(m_trackSearchSession);

            // Set first and last only flag.
            m_trackSearchSession.FirstAndLastOnly = m_chkFirstAndLast.Checked;

            // Set Filter string
            m_trackSearchSession.StringFilter = m_FilterString.Text;

            // Start the search.
            try
            {
                m_trackSearchSession.Start(int.Parse(m_textTimeout.Text));
            }
            catch (System.Exception e)
            {
                m_mainForm.ErrorMessage("MediaDatabaseForm", "StartTrackSearch", e.Message, true);
                bStarted = false;
            }

            return bStarted;
        }

        private bool StartEventSearch()
        {
            bool bStarted = true;

            if (m_eventSearchSession == null)
            {
                try
                {
                    //create search session
                    m_eventSearchSession = m_mediaDatabase.CreateSearchSession(Bosch.VideoSDK.MediaDatabase.SearchTypeEnum.steEvent);
                }
                catch (System.Exception e)
                {
                    m_mainForm.ErrorMessage("MediaDatabaseForm", "StartEventSearch", e.Message, true);
                    bStarted = false;
                    return bStarted;
                }

                //register for "ResultAvailable" event
                ((Bosch.VideoSDK.GCALib._ISearchSessionEvents_Event)m_eventSearchSession).ResultAvailable += new
                    Bosch.VideoSDK.GCALib._ISearchSessionEvents_ResultAvailableEventHandler(OnResultAvailable);
            }

            //register for "Progress" Events
            ((Bosch.VideoSDK.GCALib._ISearchSessionEvents_Event)m_eventSearchSession).Progress += new
                Bosch.VideoSDK.GCALib._ISearchSessionEvents_ProgressEventHandler(OnProgress);

            // Print a header.
            m_resultText.Text += System.Environment.NewLine;
            m_resultText.Text += "------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            m_resultText.Text += System.Environment.NewLine;
            m_resultText.Text += "EVENT SEARCH RESULTS";
            m_resultText.Text += System.Environment.NewLine;
            m_resultText.Text += System.Environment.NewLine;

            // Set start and end time for search.
            m_eventSearchSession.StartTimeFilter = FillStartTime();
            m_eventSearchSession.EndTimeFilter = FillEndTime();

            // Add which tracks to search.
            FillIdentifierFilter(m_eventSearchSession);

            // Add event filters.
            FillEventFilter(m_eventSearchSession);

            // Set first and last only flag.
            m_eventSearchSession.FirstAndLastOnly = m_chkFirstAndLast.Checked;

            // Start the search.
            try
            {
                m_eventSearchSession.Start(int.Parse(m_textTimeout.Text));
            }
            catch (System.Exception e)
            {
                m_mainForm.ErrorMessage("MediaDatabaseForm", "StartEventSearch", e.Message, true);
                bStarted = false;
            }

            return bStarted;
        }

        private bool StartTimelineSearch()
        {
            bool bStarted = true;

            try
            {
                //create search session
                if (m_bContinuous)
                    m_timelineSearchSession = m_mediaDatabase.CreateSearchSession(Bosch.VideoSDK.MediaDatabase.SearchTypeEnum.steContinuousTimeline);
                else
                    m_timelineSearchSession = m_mediaDatabase.CreateSearchSession(Bosch.VideoSDK.MediaDatabase.SearchTypeEnum.steTimeline);
            }
            catch (System.Exception e)
            {
                m_mainForm.ErrorMessage("MediaDatabaseForm", "StartTimelineSearch", e.Message, true);
                bStarted = false;
                return bStarted;
            }

            //register for "TimelineAvailable" event
            ((Bosch.VideoSDK.GCALib._ISearchSessionEvents_Event)m_timelineSearchSession).TimelineAvailable += new
                Bosch.VideoSDK.GCALib._ISearchSessionEvents_TimelineAvailableEventHandler(OnTimelineAvailable);

            //register for "Progress" Events
            ((Bosch.VideoSDK.GCALib._ISearchSessionEvents_Event)m_timelineSearchSession).Progress += new
                Bosch.VideoSDK.GCALib._ISearchSessionEvents_ProgressEventHandler(OnProgress);

            // Clear results.
            //m_resultText.Text = "";

            //set start and end time for search
            m_timelineSearchSession.StartTimeFilter = FillStartTime();
            m_timelineSearchSession.EndTimeFilter = FillEndTime();

            //add which tracks to search
            FillIdentifierFilter(m_timelineSearchSession);

            //add event filters
            FillEventFilter(m_timelineSearchSession);

            // Set the desired granularity (number of seconds) per column.
            m_timelineSearchSession.TimelineGranularity = int.Parse(m_textTimelineGran.Text);

            try
            {
                m_timelineSearchSession.Start(int.Parse(m_textTimeout.Text));
            }
            catch (System.Exception e)
            {
                m_mainForm.ErrorMessage("MediaDatabaseForm", "StartTimelineSearch", e.Message, true);
                bStarted = false;
            }

            return bStarted;
        }

        private void OnTrackAvailable(
                Bosch.VideoSDK.MediaDatabase.SearchTypeEnum se,
                Bosch.VideoSDK.MediaDatabase.Track track,
                Bosch.VideoSDK.MediaDatabase.SearchSession searchSession){

            Bosch.VideoSDK.MediaDatabase.Time64 time64;
            string resultString;
            string tempString;

            tempString = track.Name;
            tempString = tempString.PadRight(35, ' ');
            resultString = "TrackName:"+tempString;

            tempString = track.TrackID.ToString();
            tempString = tempString.PadRight(5, ' ');
            resultString += "TrackID:" + tempString;

            tempString = track.SourceID.ToString();
            tempString = tempString.PadRight(5, ' ');
            resultString += "SrcID:"+tempString;

            tempString = track.SourceURL;
            tempString = tempString.PadRight(20, ' ');
            resultString += "SrcURL:"+tempString;

            time64 = track.StartTime;
            if (time64 != null)
            {
                tempString = time64.UTC.ToString("yyyy-MM-dd HH:mm:ss");
                tempString = tempString.PadRight(30, ' ');
                resultString += tempString;
            }
            else
            {
                resultString += " start time null  ";
            }

            time64 = track.EndTime;
            if (time64 != null)
            {
                tempString = time64.UTC.ToString("yyyy-MM-dd HH:mm:ss");
                tempString = tempString.PadRight(30, ' ');
                resultString += tempString;
            }
            else
            {
                resultString += " end time null      ";
            }


            tempString = track.get_MediaType(0).ToString();
            tempString = tempString.PadRight(20, ' ');
            resultString += "MediaType(0): ";
            resultString += tempString;

            resultString += System.Environment.NewLine;

            m_resultText.Text += resultString;

            m_resultText.Text += System.Environment.NewLine;
            m_resultText.Text += "------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            m_resultText.Text += System.Environment.NewLine;

            m_resultText.Focus();
            m_resultText.ScrollToCaret();

            // Store the track for later use.
            m_tracks.Insert(m_tracks.Count, track);
        }

        private void OnResultAvailable(
                Bosch.VideoSDK.MediaDatabase.SearchTypeEnum se,
                Bosch.VideoSDK.MediaDatabase.SearchResult result,
                Bosch.VideoSDK.MediaDatabase.SearchSession searchSession) {

            string resultString;
            resultString = result.TrackID + "\t";
            resultString += result.Text + "\t";
            resultString += result.EventType.ToString() + "\t";
            resultString += result.StartTime.UTC.ToString("yyyy-MM-dd hh:mm:ss.fff tt") + "\t";

            if (null != result.EndTime)
            {
                resultString += result.EndTime.UTC.ToString("yyyy-MM-dd hh:mm:ss.fff tt") + "\t";
            }

            resultString += System.Environment.NewLine;
            m_resultText.Text += resultString;
            m_resultText.Text += System.Environment.NewLine;
            m_resultText.Text += "------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            m_resultText.Text += System.Environment.NewLine;

            m_resultText.Focus();
            m_resultText.ScrollToCaret();
        }

        private void OnTimelineAvailable(
                Bosch.VideoSDK.MediaDatabase.SearchTypeEnum eType,
                Bosch.VideoSDK.MediaDatabase.Timeline piResult,
                Bosch.VideoSDK.MediaDatabase.SearchSession searchSession){

            Bosch.VideoSDK.MediaDatabase.TimelineRowInfo rowInfo;
            string resultString;
            string tempString;

            m_resultText.Text += System.Environment.NewLine;
            m_resultText.Text += "------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            m_resultText.Text += System.Environment.NewLine;
            resultString = "TIMELINE SEARCH RESULTS";
            resultString += System.Environment.NewLine;
            resultString += System.Environment.NewLine;

            resultString += "START: " + piResult.StartTime.UTC.ToString("yyyy-MM-dd hh:mm:ss.fff tt") + System.Environment.NewLine;
            resultString += "END:   " + piResult.EndTime.UTC.ToString("yyyy-MM-dd hh:mm:ss.fff tt") + System.Environment.NewLine;
            resultString += "ROWS:  " + piResult.RowCount + " ";
            resultString += "COLUMNS: " + piResult.ColCount + " ";
            resultString += "GRANULARITY: " + piResult.Granularity + " sec" + System.Environment.NewLine;

            resultString += System.Environment.NewLine;

            for (int r = 1; r <= piResult.RowCount; r++)
            {
                rowInfo = piResult.get_TimelineInfo(r);

                tempString = r + ":";
                tempString = tempString.PadRight(5, ' ');
                resultString += tempString;

                tempString = " " + rowInfo.TrackID;
                tempString = tempString.PadRight(5, ' ');
                resultString += tempString;

                tempString = rowInfo.EventType.ToString();
                tempString = tempString.PadRight(18, ' ');
                resultString += tempString;

                for (int c = 1; c <= piResult.ColCount; c++)
                {
                    if (piResult.GetCell(r, c))
                        resultString += "X";
                    else
                        resultString += "-";
                }

                resultString += System.Environment.NewLine;
            }
            m_resultText.Text += resultString;
            m_resultText.Text += System.Environment.NewLine;
            m_resultText.Text += "------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            m_resultText.Text += System.Environment.NewLine;

            m_resultText.Focus();
            m_resultText.ScrollToCaret();
        }

        private void OnProgress(int progress, Bosch.VideoSDK.MediaDatabase.SearchSession searchSession)
        {
            m_progressText.Text = progress + "%";

            if (100 == progress && !m_bContinuous)
            {
                m_btnSearch.Text = "Start Search";
            }
        }

        private void m_btnAll_Click(object sender, System.EventArgs e)
        {
            m_chkCam1.Checked = true;
            m_chkCam2.Checked = true;
            m_chkCam3.Checked = true;
            m_chkCam4.Checked = true;
            m_chkCam5.Checked = true;
            m_chkCam6.Checked = true;
            m_chkCam7.Checked = true;
            m_chkCam8.Checked = true;
            m_chkCam9.Checked = true;
            m_chkCam10.Checked = true;
            m_chkCam11.Checked = true;
            m_chkCam12.Checked = true;
            m_chkCam13.Checked = true;
            m_chkCam14.Checked = true;
            m_chkCam15.Checked = true;
            m_chkCam16.Checked = true;
            m_chkCam17.Checked = true;
            m_chkCam18.Checked = true;
            m_chkCam19.Checked = true;
            m_chkCam20.Checked = true;
        }

        private void m_btnNone_Click(object sender, System.EventArgs e)
        {
            m_chkCam1.Checked = false;
            m_chkCam2.Checked = false;
            m_chkCam3.Checked = false;
            m_chkCam4.Checked = false;
            m_chkCam5.Checked = false;
            m_chkCam6.Checked = false;
            m_chkCam7.Checked = false;
            m_chkCam8.Checked = false;
            m_chkCam9.Checked = false;
            m_chkCam10.Checked = false;
            m_chkCam11.Checked = false;
            m_chkCam12.Checked = false;
            m_chkCam13.Checked = false;
            m_chkCam14.Checked = false;
            m_chkCam15.Checked = false;
            m_chkCam16.Checked = false;
            m_chkCam17.Checked = false;
            m_chkCam18.Checked = false;
            m_chkCam19.Checked = false;
            m_chkCam20.Checked = false;
        }

        private void m_btnSearch_Click(object sender, System.EventArgs e)
        {
            m_mainForm.LogUserMessage("MediaDatabaseForm", "m_btnSearch_Click", m_btnSearch.Text);

            m_progressText.Text = "0%";

            if ("Start Search" == m_btnSearch.Text)
            {
                /***
                if ((m_endDate.Value.Date < m_startDate.Value.Date) ||
                    (m_endDate.Value.Date == m_startDate.Value.Date &&
                    m_endTime.Value.TimeOfDay <= m_startTime.Value.TimeOfDay))
                {
                    m_mainForm.ErrorMessage("MediaDatabaseForm", "m_btnSearch_Click", "A search cannot be performed because the end time is less than the start time.", true);
                }
                else
                {
                /**/
                    bool bStarted = false;
                    m_bContinuous = false;

                    // FixGranularity
                    {
                        DateTime dtEnd = new DateTime(
                            int.Parse(this.m_endyearText.Text),
                            int.Parse(this.m_endmonthText.Text),
                            int.Parse(this.m_enddayText.Text),
                            int.Parse(this.m_endhourText.Text),
                            int.Parse(this.m_endminText.Text),
                            int.Parse(this.m_endsecText.Text));

                        DateTime dtStart = new DateTime(
                            int.Parse(this.m_startyearText.Text),
                            int.Parse(this.m_startmonthText.Text),
                            int.Parse(this.m_startdayText.Text),
                            int.Parse(this.m_starthourText.Text),
                            int.Parse(this.m_startminText.Text),
                            int.Parse(this.m_startsecText.Text));


                        System.TimeSpan ts = dtEnd.Subtract(dtStart);
                        //System.TimeSpan ts = m_endDate.Value.Subtract(m_startDate.Value);

                        double nInterval = ts.TotalSeconds / 128;

                        // force continuous timeline searches to use a minimum granularity
                        if (m_radioContinuousTimeline.Checked)
                        {
                            if (int.Parse(m_textTimelineGran.Text) < nInterval)
                            {
                                m_textTimelineGran.Text = nInterval.ToString("##");
                            }
                        }
                    }
                    m_btnSearch.Text = "Stop Search";

                    if (m_radioTrack.Checked)
                    {
                        bStarted = StartTrackSearch();
                    }
                    else if (m_radioEvent.Checked)
                    {
                        bStarted = StartEventSearch();
                    }
                    else if (m_radioTimeline.Checked)
                    {
                        bStarted = StartTimelineSearch();
                    }
                    else if (m_radioContinuousTimeline.Checked)
                    {
                        m_bContinuous = true;
                        bStarted = StartTimelineSearch();
                    }

                    if (!bStarted)
                        m_btnSearch.Text = "Start Search";
                //}
            }
            else
            {
                //Cancel Search
                if (m_trackSearchSession != null)
                    m_trackSearchSession.Stop();

                if (m_eventSearchSession != null)
                    m_eventSearchSession.Stop();

                if (m_timelineSearchSession != null)
                    m_timelineSearchSession.Stop();

                m_btnSearch.Text = "Start Search";
            }
        }

        private void m_btnTrackOperations_Click(object sender, System.EventArgs e)
        {
            m_mainForm.LogUserMessage("MediaDatabaseForm", "m_btnTrackOperations_Click", m_btnTrackOperations.Text);

            if (m_tracks.Count > 0)
            {
                SelectTrackForm newForm = new SelectTrackForm(this, m_dbName);
                newForm.Show();
            }
            else
            {
                m_mainForm.ErrorMessage("MediaDatabaseForm", "m_btnTrackOperations_Click", "You must perform a track search first.", true);
            }
        }

        public void PutTracksInListBox(System.Windows.Forms.ListBox lb)
        {
            for (int i = 0; i < m_tracks.Count; i++)
            {
                Bosch.VideoSDK.MediaDatabase.Track track = (Bosch.VideoSDK.MediaDatabase.Track)m_tracks[i];
                TrackWrapper wrapper = new TrackWrapper(track);
                lb.Items.Add(wrapper);
            }
        }


        protected override void OnResize(EventArgs e)
        {
            m_resultText.Width = this.Size.Width - m_resultText.Left - 20;
            m_resultText.Height = this.Size.Height - m_resultText.Top - 30;
            base.OnResize (e);
        }

        private void m_btnGetMediaSession_Click(object sender, System.EventArgs e)
        {
            m_mainForm.LogUserMessage("MediaDatabaseForm", "m_btnGetMediaSession_Click", m_btnGetMediaSession.Text + " " + m_txtTrackID.Text);

            Bosch.VideoSDK.MediaSession ms = null;
            Bosch.VideoSDK.MediaDatabase.PlaybackController pc = (Bosch.VideoSDK.MediaDatabase.PlaybackController)m_mainForm.m_controllers[0];

            try
            {
                ms = m_mediaDatabase.GetMediaSession(int.Parse(m_txtTrackID.Text), pc);
            
                MediaSessionForm newForm = new MediaSessionForm(ms, m_dbName, "", pc.Name, m_mainForm);
                newForm.Show();
            }
            catch
            {
                m_mainForm.ErrorMessage("MediaDatabaseForm", "m_btnGetMediaSession_Click", "Error calling mediaDatabase.GetMediaSession", true);
            }

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void m_FilterString_TextChanged(object sender, EventArgs e)
        {

        }
    }


}
