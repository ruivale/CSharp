namespace PanasonicAxTest
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.camPos1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblUid = new System.Windows.Forms.Label();
            this.btLogin = new System.Windows.Forms.Button();
            this.camPos2 = new System.Windows.Forms.Button();
            this.camerasGroupBox = new System.Windows.Forms.GroupBox();
            this.camPos16 = new System.Windows.Forms.Button();
            this.camPos15 = new System.Windows.Forms.Button();
            this.camPos14 = new System.Windows.Forms.Button();
            this.camPos13 = new System.Windows.Forms.Button();
            this.camPos12 = new System.Windows.Forms.Button();
            this.camPos11 = new System.Windows.Forms.Button();
            this.camPos10 = new System.Windows.Forms.Button();
            this.camPos9 = new System.Windows.Forms.Button();
            this.camPos8 = new System.Windows.Forms.Button();
            this.camPos7 = new System.Windows.Forms.Button();
            this.camPos6 = new System.Windows.Forms.Button();
            this.camPos5 = new System.Windows.Forms.Button();
            this.camPos4 = new System.Windows.Forms.Button();
            this.camPos3 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.txtServerHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCamNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.displayTimer = new System.Windows.Forms.Timer(this.components);
            this.mainTab = new System.Windows.Forms.TabControl();
            this.tabLiveVideo = new System.Windows.Forms.TabPage();
            this.btStopLive = new System.Windows.Forms.Button();
            this.recCtl = new AxHD300SDKCONTROLLERLib.AxHD300SDKController();
            this.tabRecordings = new System.Windows.Forms.TabPage();
            this.bExtract = new System.Windows.Forms.Button();
            this.btSearch = new System.Windows.Forms.Button();
            this.getRecordsProgress = new System.Windows.Forms.ProgressBar();
            this.btGetRecordings = new System.Windows.Forms.Button();
            this.recordsDataGrid = new System.Windows.Forms.DataGridView();
            this.RecordNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FrameTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FrameNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CameraNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isAlarmed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bWorkerGetRecords = new System.ComponentModel.BackgroundWorker();
            this.mainFormTab = new System.Windows.Forms.TabControl();
            this.tabPageVideo = new System.Windows.Forms.TabPage();
            this.btLogout = new System.Windows.Forms.Button();
            this.tabPageAlarm = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblDiskCopy2 = new System.Windows.Forms.Label();
            this.lblDiskCopy1 = new System.Windows.Forms.Label();
            this.lblHDDCopy = new System.Windows.Forms.Label();
            this.lblHDDEvent = new System.Windows.Forms.Label();
            this.lblHDDNormal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.recorderKeyboard = new System.Windows.Forms.GroupBox();
            this.btCam16 = new System.Windows.Forms.Button();
            this.btCam15 = new System.Windows.Forms.Button();
            this.btCam14 = new System.Windows.Forms.Button();
            this.btCam13 = new System.Windows.Forms.Button();
            this.btCam12 = new System.Windows.Forms.Button();
            this.btCam11 = new System.Windows.Forms.Button();
            this.btCam10 = new System.Windows.Forms.Button();
            this.btCam9 = new System.Windows.Forms.Button();
            this.btCam8 = new System.Windows.Forms.Button();
            this.btCam7 = new System.Windows.Forms.Button();
            this.btCam6 = new System.Windows.Forms.Button();
            this.btCam5 = new System.Windows.Forms.Button();
            this.btCam4 = new System.Windows.Forms.Button();
            this.btCam3 = new System.Windows.Forms.Button();
            this.btCam1 = new System.Windows.Forms.Button();
            this.btCam2 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.activeCamerasListBox = new System.Windows.Forms.CheckedListBox();
            this.groupBoxRec = new System.Windows.Forms.GroupBox();
            this.lblNoCamerasRec = new System.Windows.Forms.LinkLabel();
            this.camerasListBox = new System.Windows.Forms.CheckedListBox();
            this.lblAllCamerasRec = new System.Windows.Forms.LinkLabel();
            this.boxLblREC = new System.Windows.Forms.Label();
            this.lblREC = new System.Windows.Forms.Label();
            this.btStopRecAll = new System.Windows.Forms.Button();
            this.btStartRec = new System.Windows.Forms.Button();
            this.btAlarmReset = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.statusListBox = new System.Windows.Forms.ListBox();
            this.btMonitorToggle = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.alarmsListBox = new System.Windows.Forms.ListBox();
            this.statusTimer = new System.Windows.Forms.Timer(this.components);
            this.alarmTimer = new System.Windows.Forms.Timer(this.components);
            this.recordingsDataSet = new PanasonicAxTest.RecordingsDataSet();
            this.groupBox1.SuspendLayout();
            this.camerasGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.mainTab.SuspendLayout();
            this.tabLiveVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recCtl)).BeginInit();
            this.tabRecordings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordsDataGrid)).BeginInit();
            this.mainFormTab.SuspendLayout();
            this.tabPageVideo.SuspendLayout();
            this.tabPageAlarm.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.recorderKeyboard.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBoxRec.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordingsDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // camPos1
            // 
            this.camPos1.Location = new System.Drawing.Point(6, 19);
            this.camPos1.Name = "camPos1";
            this.camPos1.Size = new System.Drawing.Size(32, 23);
            this.camPos1.TabIndex = 1;
            this.camPos1.Text = "1";
            this.camPos1.UseVisualStyleBackColor = true;
            this.camPos1.Click += new System.EventHandler(this.camPos1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblUid);
            this.groupBox1.Location = new System.Drawing.Point(182, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 51);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "UID";
            // 
            // lblUid
            // 
            this.lblUid.Location = new System.Drawing.Point(61, 19);
            this.lblUid.Name = "lblUid";
            this.lblUid.Size = new System.Drawing.Size(100, 23);
            this.lblUid.TabIndex = 0;
            this.lblUid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(381, 31);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(75, 23);
            this.btLogin.TabIndex = 3;
            this.btLogin.Text = "Login";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.button2_Click);
            // 
            // camPos2
            // 
            this.camPos2.Location = new System.Drawing.Point(44, 19);
            this.camPos2.Name = "camPos2";
            this.camPos2.Size = new System.Drawing.Size(32, 23);
            this.camPos2.TabIndex = 5;
            this.camPos2.Text = "2";
            this.camPos2.UseVisualStyleBackColor = true;
            this.camPos2.Click += new System.EventHandler(this.camPos2_Click);
            // 
            // camerasGroupBox
            // 
            this.camerasGroupBox.Controls.Add(this.camPos16);
            this.camerasGroupBox.Controls.Add(this.camPos15);
            this.camerasGroupBox.Controls.Add(this.camPos14);
            this.camerasGroupBox.Controls.Add(this.camPos13);
            this.camerasGroupBox.Controls.Add(this.camPos12);
            this.camerasGroupBox.Controls.Add(this.camPos11);
            this.camerasGroupBox.Controls.Add(this.camPos10);
            this.camerasGroupBox.Controls.Add(this.camPos9);
            this.camerasGroupBox.Controls.Add(this.camPos8);
            this.camerasGroupBox.Controls.Add(this.camPos7);
            this.camerasGroupBox.Controls.Add(this.camPos6);
            this.camerasGroupBox.Controls.Add(this.camPos5);
            this.camerasGroupBox.Controls.Add(this.camPos4);
            this.camerasGroupBox.Controls.Add(this.camPos3);
            this.camerasGroupBox.Controls.Add(this.camPos1);
            this.camerasGroupBox.Controls.Add(this.camPos2);
            this.camerasGroupBox.Location = new System.Drawing.Point(535, 130);
            this.camerasGroupBox.Name = "camerasGroupBox";
            this.camerasGroupBox.Size = new System.Drawing.Size(163, 140);
            this.camerasGroupBox.TabIndex = 7;
            this.camerasGroupBox.TabStop = false;
            this.camerasGroupBox.Text = "Cameras";
            // 
            // camPos16
            // 
            this.camPos16.Location = new System.Drawing.Point(120, 106);
            this.camPos16.Name = "camPos16";
            this.camPos16.Size = new System.Drawing.Size(32, 23);
            this.camPos16.TabIndex = 19;
            this.camPos16.Text = "16";
            this.camPos16.UseVisualStyleBackColor = true;
            this.camPos16.Click += new System.EventHandler(this.camPos16_Click);
            // 
            // camPos15
            // 
            this.camPos15.Location = new System.Drawing.Point(82, 106);
            this.camPos15.Name = "camPos15";
            this.camPos15.Size = new System.Drawing.Size(32, 23);
            this.camPos15.TabIndex = 18;
            this.camPos15.Text = "15";
            this.camPos15.UseVisualStyleBackColor = true;
            this.camPos15.Click += new System.EventHandler(this.camPos15_Click);
            // 
            // camPos14
            // 
            this.camPos14.Location = new System.Drawing.Point(44, 106);
            this.camPos14.Name = "camPos14";
            this.camPos14.Size = new System.Drawing.Size(32, 23);
            this.camPos14.TabIndex = 17;
            this.camPos14.Text = "14";
            this.camPos14.UseVisualStyleBackColor = true;
            this.camPos14.Click += new System.EventHandler(this.camPos14_Click);
            // 
            // camPos13
            // 
            this.camPos13.Location = new System.Drawing.Point(6, 106);
            this.camPos13.Name = "camPos13";
            this.camPos13.Size = new System.Drawing.Size(32, 23);
            this.camPos13.TabIndex = 16;
            this.camPos13.Text = "13";
            this.camPos13.UseVisualStyleBackColor = true;
            this.camPos13.Click += new System.EventHandler(this.camPos13_Click);
            // 
            // camPos12
            // 
            this.camPos12.Location = new System.Drawing.Point(120, 77);
            this.camPos12.Name = "camPos12";
            this.camPos12.Size = new System.Drawing.Size(32, 23);
            this.camPos12.TabIndex = 15;
            this.camPos12.Text = "12";
            this.camPos12.UseVisualStyleBackColor = true;
            this.camPos12.Click += new System.EventHandler(this.camPos12_Click);
            // 
            // camPos11
            // 
            this.camPos11.Location = new System.Drawing.Point(82, 77);
            this.camPos11.Name = "camPos11";
            this.camPos11.Size = new System.Drawing.Size(32, 23);
            this.camPos11.TabIndex = 14;
            this.camPos11.Text = "11";
            this.camPos11.UseVisualStyleBackColor = true;
            this.camPos11.Click += new System.EventHandler(this.camPos11_Click);
            // 
            // camPos10
            // 
            this.camPos10.Location = new System.Drawing.Point(44, 77);
            this.camPos10.Name = "camPos10";
            this.camPos10.Size = new System.Drawing.Size(32, 23);
            this.camPos10.TabIndex = 13;
            this.camPos10.Text = "10";
            this.camPos10.UseVisualStyleBackColor = true;
            this.camPos10.Click += new System.EventHandler(this.camPos10_Click);
            // 
            // camPos9
            // 
            this.camPos9.Location = new System.Drawing.Point(6, 77);
            this.camPos9.Name = "camPos9";
            this.camPos9.Size = new System.Drawing.Size(32, 23);
            this.camPos9.TabIndex = 12;
            this.camPos9.Text = "9";
            this.camPos9.UseVisualStyleBackColor = true;
            this.camPos9.Click += new System.EventHandler(this.camPos9_Click);
            // 
            // camPos8
            // 
            this.camPos8.Location = new System.Drawing.Point(120, 48);
            this.camPos8.Name = "camPos8";
            this.camPos8.Size = new System.Drawing.Size(32, 23);
            this.camPos8.TabIndex = 11;
            this.camPos8.Text = "8";
            this.camPos8.UseVisualStyleBackColor = true;
            this.camPos8.Click += new System.EventHandler(this.camPos8_Click);
            // 
            // camPos7
            // 
            this.camPos7.Location = new System.Drawing.Point(82, 48);
            this.camPos7.Name = "camPos7";
            this.camPos7.Size = new System.Drawing.Size(32, 23);
            this.camPos7.TabIndex = 10;
            this.camPos7.Text = "7";
            this.camPos7.UseVisualStyleBackColor = true;
            this.camPos7.Click += new System.EventHandler(this.camPos7_Click);
            // 
            // camPos6
            // 
            this.camPos6.Location = new System.Drawing.Point(44, 48);
            this.camPos6.Name = "camPos6";
            this.camPos6.Size = new System.Drawing.Size(32, 23);
            this.camPos6.TabIndex = 9;
            this.camPos6.Text = "6";
            this.camPos6.UseVisualStyleBackColor = true;
            this.camPos6.Click += new System.EventHandler(this.camPos6_Click);
            // 
            // camPos5
            // 
            this.camPos5.Location = new System.Drawing.Point(6, 48);
            this.camPos5.Name = "camPos5";
            this.camPos5.Size = new System.Drawing.Size(32, 23);
            this.camPos5.TabIndex = 8;
            this.camPos5.Text = "5";
            this.camPos5.UseVisualStyleBackColor = true;
            this.camPos5.Click += new System.EventHandler(this.camPos5_Click);
            // 
            // camPos4
            // 
            this.camPos4.Location = new System.Drawing.Point(120, 19);
            this.camPos4.Name = "camPos4";
            this.camPos4.Size = new System.Drawing.Size(32, 23);
            this.camPos4.TabIndex = 7;
            this.camPos4.Text = "4";
            this.camPos4.UseVisualStyleBackColor = true;
            this.camPos4.Click += new System.EventHandler(this.camPos4_Click);
            // 
            // camPos3
            // 
            this.camPos3.Location = new System.Drawing.Point(82, 19);
            this.camPos3.Name = "camPos3";
            this.camPos3.Size = new System.Drawing.Size(32, 23);
            this.camPos3.TabIndex = 6;
            this.camPos3.Text = "3";
            this.camPos3.UseVisualStyleBackColor = true;
            this.camPos3.Click += new System.EventHandler(this.camPos3_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtServerPort);
            this.groupBox3.Controls.Add(this.txtServerHost);
            this.groupBox3.Location = new System.Drawing.Point(3, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(167, 51);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Server";
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(115, 19);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(46, 20);
            this.txtServerPort.TabIndex = 1;
            this.txtServerPort.Text = "80";
            this.txtServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtServerHost
            // 
            this.txtServerHost.Location = new System.Drawing.Point(6, 19);
            this.txtServerHost.Name = "txtServerHost";
            this.txtServerHost.Size = new System.Drawing.Size(100, 20);
            this.txtServerHost.TabIndex = 0;
            this.txtServerHost.Text = "172.18.56.69";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Camera:";
            // 
            // lblCamNo
            // 
            this.lblCamNo.Location = new System.Drawing.Point(58, 8);
            this.lblCamNo.Name = "lblCamNo";
            this.lblCamNo.Size = new System.Drawing.Size(100, 23);
            this.lblCamNo.TabIndex = 10;
            this.lblCamNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Time:";
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(286, 8);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(120, 23);
            this.lblTime.TabIndex = 12;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // displayTimer
            // 
            this.displayTimer.Interval = 500;
            this.displayTimer.Tick += new System.EventHandler(this.displayTimer_Tick);
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.tabLiveVideo);
            this.mainTab.Controls.Add(this.tabRecordings);
            this.mainTab.Enabled = false;
            this.mainTab.Location = new System.Drawing.Point(9, 71);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(727, 423);
            this.mainTab.TabIndex = 13;
            this.mainTab.Deselected += new System.Windows.Forms.TabControlEventHandler(this.mainTab_Deselected);
            this.mainTab.SelectedIndexChanged += new System.EventHandler(this.mainTab_SelectedIndexChanged);
            // 
            // tabLiveVideo
            // 
            this.tabLiveVideo.Controls.Add(this.btStopLive);
            this.tabLiveVideo.Controls.Add(this.recCtl);
            this.tabLiveVideo.Controls.Add(this.lblTime);
            this.tabLiveVideo.Controls.Add(this.camerasGroupBox);
            this.tabLiveVideo.Controls.Add(this.label1);
            this.tabLiveVideo.Controls.Add(this.label2);
            this.tabLiveVideo.Controls.Add(this.lblCamNo);
            this.tabLiveVideo.Location = new System.Drawing.Point(4, 22);
            this.tabLiveVideo.Name = "tabLiveVideo";
            this.tabLiveVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabLiveVideo.Size = new System.Drawing.Size(719, 397);
            this.tabLiveVideo.TabIndex = 0;
            this.tabLiveVideo.Text = "Live Video";
            this.tabLiveVideo.UseVisualStyleBackColor = true;
            // 
            // btStopLive
            // 
            this.btStopLive.Location = new System.Drawing.Point(541, 276);
            this.btStopLive.Name = "btStopLive";
            this.btStopLive.Size = new System.Drawing.Size(146, 23);
            this.btStopLive.TabIndex = 14;
            this.btStopLive.Text = "Stop Live Video";
            this.btStopLive.UseVisualStyleBackColor = true;
            this.btStopLive.Click += new System.EventHandler(this.btStopLive_Click);
            // 
            // recCtl
            // 
            this.recCtl.Enabled = true;
            this.recCtl.Location = new System.Drawing.Point(6, 34);
            this.recCtl.Name = "recCtl";
            this.recCtl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("recCtl.OcxState")));
            this.recCtl.Size = new System.Drawing.Size(488, 353);
            this.recCtl.TabIndex = 13;
            this.recCtl.Error += new AxHD300SDKCONTROLLERLib._DHD300SDKControllerEvents_ErrorEventHandler(this.recCtl_Error);
            // 
            // tabRecordings
            // 
            this.tabRecordings.Controls.Add(this.bExtract);
            this.tabRecordings.Controls.Add(this.btSearch);
            this.tabRecordings.Controls.Add(this.getRecordsProgress);
            this.tabRecordings.Controls.Add(this.btGetRecordings);
            this.tabRecordings.Controls.Add(this.recordsDataGrid);
            this.tabRecordings.Location = new System.Drawing.Point(4, 22);
            this.tabRecordings.Name = "tabRecordings";
            this.tabRecordings.Padding = new System.Windows.Forms.Padding(3);
            this.tabRecordings.Size = new System.Drawing.Size(719, 397);
            this.tabRecordings.TabIndex = 1;
            this.tabRecordings.Text = "Recordings";
            this.tabRecordings.UseVisualStyleBackColor = true;
            // 
            // bExtract
            // 
            this.bExtract.Location = new System.Drawing.Point(621, 367);
            this.bExtract.Name = "bExtract";
            this.bExtract.Size = new System.Drawing.Size(75, 23);
            this.bExtract.TabIndex = 5;
            this.bExtract.Text = "Extract...";
            this.bExtract.UseVisualStyleBackColor = true;
            this.bExtract.Click += new System.EventHandler(this.buttonExtract_Click_1);
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(495, 6);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 23);
            this.btSearch.TabIndex = 4;
            this.btSearch.Text = "Search...";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // getRecordsProgress
            // 
            this.getRecordsProgress.Location = new System.Drawing.Point(6, 6);
            this.getRecordsProgress.Name = "getRecordsProgress";
            this.getRecordsProgress.Size = new System.Drawing.Size(483, 23);
            this.getRecordsProgress.TabIndex = 2;
            // 
            // btGetRecordings
            // 
            this.btGetRecordings.Location = new System.Drawing.Point(576, 6);
            this.btGetRecordings.Name = "btGetRecordings";
            this.btGetRecordings.Size = new System.Drawing.Size(134, 23);
            this.btGetRecordings.TabIndex = 1;
            this.btGetRecordings.Text = "Get All Recordings";
            this.btGetRecordings.UseVisualStyleBackColor = true;
            this.btGetRecordings.Click += new System.EventHandler(this.btGetRecordings_Click);
            // 
            // recordsDataGrid
            // 
            this.recordsDataGrid.AllowUserToAddRows = false;
            this.recordsDataGrid.AllowUserToDeleteRows = false;
            this.recordsDataGrid.AllowUserToOrderColumns = true;
            this.recordsDataGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.recordsDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.recordsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.recordsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RecordNo,
            this.FrameTime,
            this.FrameNo,
            this.CameraNo,
            this.isAlarmed,
            this.Description});
            this.recordsDataGrid.Location = new System.Drawing.Point(6, 35);
            this.recordsDataGrid.MultiSelect = false;
            this.recordsDataGrid.Name = "recordsDataGrid";
            this.recordsDataGrid.ReadOnly = true;
            this.recordsDataGrid.RowHeadersVisible = false;
            this.recordsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.recordsDataGrid.Size = new System.Drawing.Size(704, 326);
            this.recordsDataGrid.TabIndex = 0;
            this.recordsDataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.recordsDataGrid_CellDoubleClick);
            this.recordsDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.recordsDataGrid_CellContentClick);
            // 
            // RecordNo
            // 
            this.RecordNo.DataPropertyName = "RecordNo";
            this.RecordNo.HeaderText = "Record No";
            this.RecordNo.Name = "RecordNo";
            this.RecordNo.ReadOnly = true;
            // 
            // FrameTime
            // 
            this.FrameTime.DataPropertyName = "FrameTime";
            this.FrameTime.HeaderText = "Time";
            this.FrameTime.Name = "FrameTime";
            this.FrameTime.ReadOnly = true;
            // 
            // FrameNo
            // 
            this.FrameNo.DataPropertyName = "FrameNo";
            this.FrameNo.HeaderText = "Start Frame";
            this.FrameNo.Name = "FrameNo";
            this.FrameNo.ReadOnly = true;
            // 
            // CameraNo
            // 
            this.CameraNo.DataPropertyName = "CameraNo";
            this.CameraNo.HeaderText = "Camera";
            this.CameraNo.Name = "CameraNo";
            this.CameraNo.ReadOnly = true;
            // 
            // isAlarmed
            // 
            this.isAlarmed.DataPropertyName = "Alarm";
            this.isAlarmed.HeaderText = "Alarm";
            this.isAlarmed.Name = "isAlarmed";
            this.isAlarmed.ReadOnly = true;
            this.isAlarmed.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isAlarmed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Text";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // bWorkerGetRecords
            // 
            this.bWorkerGetRecords.WorkerReportsProgress = true;
            this.bWorkerGetRecords.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWorkerGetRecords_DoWork);
            this.bWorkerGetRecords.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bWorkerGetRecords_RunWorkerCompleted);
            this.bWorkerGetRecords.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bWorkerGetRecords_ProgressChanged);
            // 
            // mainFormTab
            // 
            this.mainFormTab.Controls.Add(this.tabPageVideo);
            this.mainFormTab.Controls.Add(this.tabPageAlarm);
            this.mainFormTab.Location = new System.Drawing.Point(3, 78);
            this.mainFormTab.Name = "mainFormTab";
            this.mainFormTab.SelectedIndex = 0;
            this.mainFormTab.Size = new System.Drawing.Size(770, 533);
            this.mainFormTab.TabIndex = 15;
            // 
            // tabPageVideo
            // 
            this.tabPageVideo.Controls.Add(this.btLogout);
            this.tabPageVideo.Controls.Add(this.mainTab);
            this.tabPageVideo.Controls.Add(this.groupBox1);
            this.tabPageVideo.Controls.Add(this.btLogin);
            this.tabPageVideo.Location = new System.Drawing.Point(4, 22);
            this.tabPageVideo.Name = "tabPageVideo";
            this.tabPageVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVideo.Size = new System.Drawing.Size(762, 507);
            this.tabPageVideo.TabIndex = 0;
            this.tabPageVideo.Text = "Video";
            this.tabPageVideo.UseVisualStyleBackColor = true;
            // 
            // btLogout
            // 
            this.btLogout.Enabled = false;
            this.btLogout.Location = new System.Drawing.Point(462, 31);
            this.btLogout.Name = "btLogout";
            this.btLogout.Size = new System.Drawing.Size(75, 23);
            this.btLogout.TabIndex = 15;
            this.btLogout.Text = "Logout";
            this.btLogout.UseVisualStyleBackColor = true;
            this.btLogout.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPageAlarm
            // 
            this.tabPageAlarm.Controls.Add(this.groupBox6);
            this.tabPageAlarm.Controls.Add(this.recorderKeyboard);
            this.tabPageAlarm.Controls.Add(this.groupBox5);
            this.tabPageAlarm.Controls.Add(this.groupBoxRec);
            this.tabPageAlarm.Controls.Add(this.btAlarmReset);
            this.tabPageAlarm.Controls.Add(this.groupBox4);
            this.tabPageAlarm.Controls.Add(this.btMonitorToggle);
            this.tabPageAlarm.Controls.Add(this.groupBox2);
            this.tabPageAlarm.Location = new System.Drawing.Point(4, 22);
            this.tabPageAlarm.Name = "tabPageAlarm";
            this.tabPageAlarm.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAlarm.Size = new System.Drawing.Size(762, 507);
            this.tabPageAlarm.TabIndex = 1;
            this.tabPageAlarm.Text = "Monitor / Commands";
            this.tabPageAlarm.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblDiskCopy2);
            this.groupBox6.Controls.Add(this.lblDiskCopy1);
            this.groupBox6.Controls.Add(this.lblHDDCopy);
            this.groupBox6.Controls.Add(this.lblHDDEvent);
            this.groupBox6.Controls.Add(this.lblHDDNormal);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Location = new System.Drawing.Point(7, 211);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(197, 128);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Available Disk Space";
            // 
            // lblDiskCopy2
            // 
            this.lblDiskCopy2.AutoSize = true;
            this.lblDiskCopy2.Location = new System.Drawing.Point(101, 99);
            this.lblDiskCopy2.Name = "lblDiskCopy2";
            this.lblDiskCopy2.Size = new System.Drawing.Size(0, 13);
            this.lblDiskCopy2.TabIndex = 9;
            // 
            // lblDiskCopy1
            // 
            this.lblDiskCopy1.AutoSize = true;
            this.lblDiskCopy1.Location = new System.Drawing.Point(101, 79);
            this.lblDiskCopy1.Name = "lblDiskCopy1";
            this.lblDiskCopy1.Size = new System.Drawing.Size(0, 13);
            this.lblDiskCopy1.TabIndex = 8;
            // 
            // lblHDDCopy
            // 
            this.lblHDDCopy.AutoSize = true;
            this.lblHDDCopy.Location = new System.Drawing.Point(101, 59);
            this.lblHDDCopy.Name = "lblHDDCopy";
            this.lblHDDCopy.Size = new System.Drawing.Size(0, 13);
            this.lblHDDCopy.TabIndex = 7;
            // 
            // lblHDDEvent
            // 
            this.lblHDDEvent.AutoSize = true;
            this.lblHDDEvent.Location = new System.Drawing.Point(101, 39);
            this.lblHDDEvent.Name = "lblHDDEvent";
            this.lblHDDEvent.Size = new System.Drawing.Size(0, 13);
            this.lblHDDEvent.TabIndex = 6;
            // 
            // lblHDDNormal
            // 
            this.lblHDDNormal.AutoSize = true;
            this.lblHDDNormal.Location = new System.Drawing.Point(101, 19);
            this.lblHDDNormal.Name = "lblHDDNormal";
            this.lblHDDNormal.Size = new System.Drawing.Size(0, 13);
            this.lblHDDNormal.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Disk COPY2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Disk COPY1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "HDD Copy";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "HDD Event";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "HDD Normal";
            // 
            // recorderKeyboard
            // 
            this.recorderKeyboard.Controls.Add(this.btCam16);
            this.recorderKeyboard.Controls.Add(this.btCam15);
            this.recorderKeyboard.Controls.Add(this.btCam14);
            this.recorderKeyboard.Controls.Add(this.btCam13);
            this.recorderKeyboard.Controls.Add(this.btCam12);
            this.recorderKeyboard.Controls.Add(this.btCam11);
            this.recorderKeyboard.Controls.Add(this.btCam10);
            this.recorderKeyboard.Controls.Add(this.btCam9);
            this.recorderKeyboard.Controls.Add(this.btCam8);
            this.recorderKeyboard.Controls.Add(this.btCam7);
            this.recorderKeyboard.Controls.Add(this.btCam6);
            this.recorderKeyboard.Controls.Add(this.btCam5);
            this.recorderKeyboard.Controls.Add(this.btCam4);
            this.recorderKeyboard.Controls.Add(this.btCam3);
            this.recorderKeyboard.Controls.Add(this.btCam1);
            this.recorderKeyboard.Controls.Add(this.btCam2);
            this.recorderKeyboard.Location = new System.Drawing.Point(210, 53);
            this.recorderKeyboard.Name = "recorderKeyboard";
            this.recorderKeyboard.Size = new System.Drawing.Size(258, 152);
            this.recorderKeyboard.TabIndex = 6;
            this.recorderKeyboard.TabStop = false;
            this.recorderKeyboard.Text = "Recorder Keyboard";
            // 
            // btCam16
            // 
            this.btCam16.Location = new System.Drawing.Point(202, 106);
            this.btCam16.Name = "btCam16";
            this.btCam16.Size = new System.Drawing.Size(32, 23);
            this.btCam16.TabIndex = 35;
            this.btCam16.Text = "16";
            this.btCam16.UseVisualStyleBackColor = true;
            this.btCam16.Click += new System.EventHandler(this.btCam16_Click);
            // 
            // btCam15
            // 
            this.btCam15.Location = new System.Drawing.Point(140, 106);
            this.btCam15.Name = "btCam15";
            this.btCam15.Size = new System.Drawing.Size(32, 23);
            this.btCam15.TabIndex = 34;
            this.btCam15.Text = "15";
            this.btCam15.UseVisualStyleBackColor = true;
            this.btCam15.Click += new System.EventHandler(this.btCam15_Click);
            // 
            // btCam14
            // 
            this.btCam14.Location = new System.Drawing.Point(78, 106);
            this.btCam14.Name = "btCam14";
            this.btCam14.Size = new System.Drawing.Size(32, 23);
            this.btCam14.TabIndex = 33;
            this.btCam14.Text = "14";
            this.btCam14.UseVisualStyleBackColor = true;
            this.btCam14.Click += new System.EventHandler(this.btCam14_Click);
            // 
            // btCam13
            // 
            this.btCam13.Location = new System.Drawing.Point(16, 106);
            this.btCam13.Name = "btCam13";
            this.btCam13.Size = new System.Drawing.Size(32, 23);
            this.btCam13.TabIndex = 32;
            this.btCam13.Text = "13";
            this.btCam13.UseVisualStyleBackColor = true;
            this.btCam13.Click += new System.EventHandler(this.btCam13_Click);
            // 
            // btCam12
            // 
            this.btCam12.Location = new System.Drawing.Point(202, 77);
            this.btCam12.Name = "btCam12";
            this.btCam12.Size = new System.Drawing.Size(32, 23);
            this.btCam12.TabIndex = 31;
            this.btCam12.Text = "12";
            this.btCam12.UseVisualStyleBackColor = true;
            this.btCam12.Click += new System.EventHandler(this.btCam12_Click);
            // 
            // btCam11
            // 
            this.btCam11.Location = new System.Drawing.Point(140, 77);
            this.btCam11.Name = "btCam11";
            this.btCam11.Size = new System.Drawing.Size(32, 23);
            this.btCam11.TabIndex = 30;
            this.btCam11.Text = "11";
            this.btCam11.UseVisualStyleBackColor = true;
            this.btCam11.Click += new System.EventHandler(this.btCam11_Click);
            // 
            // btCam10
            // 
            this.btCam10.Location = new System.Drawing.Point(78, 77);
            this.btCam10.Name = "btCam10";
            this.btCam10.Size = new System.Drawing.Size(32, 23);
            this.btCam10.TabIndex = 29;
            this.btCam10.Text = "10";
            this.btCam10.UseVisualStyleBackColor = true;
            this.btCam10.Click += new System.EventHandler(this.btCam10_Click);
            // 
            // btCam9
            // 
            this.btCam9.Location = new System.Drawing.Point(16, 77);
            this.btCam9.Name = "btCam9";
            this.btCam9.Size = new System.Drawing.Size(32, 23);
            this.btCam9.TabIndex = 28;
            this.btCam9.Text = "9";
            this.btCam9.UseVisualStyleBackColor = true;
            this.btCam9.Click += new System.EventHandler(this.btCam9_Click);
            // 
            // btCam8
            // 
            this.btCam8.Location = new System.Drawing.Point(202, 48);
            this.btCam8.Name = "btCam8";
            this.btCam8.Size = new System.Drawing.Size(32, 23);
            this.btCam8.TabIndex = 27;
            this.btCam8.Text = "8";
            this.btCam8.UseVisualStyleBackColor = true;
            this.btCam8.Click += new System.EventHandler(this.btCam8_Click);
            // 
            // btCam7
            // 
            this.btCam7.Location = new System.Drawing.Point(140, 48);
            this.btCam7.Name = "btCam7";
            this.btCam7.Size = new System.Drawing.Size(32, 23);
            this.btCam7.TabIndex = 26;
            this.btCam7.Text = "7";
            this.btCam7.UseVisualStyleBackColor = true;
            this.btCam7.Click += new System.EventHandler(this.btCam7_Click);
            // 
            // btCam6
            // 
            this.btCam6.Location = new System.Drawing.Point(78, 48);
            this.btCam6.Name = "btCam6";
            this.btCam6.Size = new System.Drawing.Size(32, 23);
            this.btCam6.TabIndex = 25;
            this.btCam6.Text = "6";
            this.btCam6.UseVisualStyleBackColor = true;
            this.btCam6.Click += new System.EventHandler(this.btCam6_Click);
            // 
            // btCam5
            // 
            this.btCam5.Location = new System.Drawing.Point(16, 48);
            this.btCam5.Name = "btCam5";
            this.btCam5.Size = new System.Drawing.Size(32, 23);
            this.btCam5.TabIndex = 24;
            this.btCam5.Text = "5";
            this.btCam5.UseVisualStyleBackColor = true;
            this.btCam5.Click += new System.EventHandler(this.btCam5_Click);
            // 
            // btCam4
            // 
            this.btCam4.Location = new System.Drawing.Point(202, 19);
            this.btCam4.Name = "btCam4";
            this.btCam4.Size = new System.Drawing.Size(32, 23);
            this.btCam4.TabIndex = 23;
            this.btCam4.Text = "4";
            this.btCam4.UseVisualStyleBackColor = true;
            this.btCam4.Click += new System.EventHandler(this.btCam4_Click);
            // 
            // btCam3
            // 
            this.btCam3.Location = new System.Drawing.Point(140, 19);
            this.btCam3.Name = "btCam3";
            this.btCam3.Size = new System.Drawing.Size(32, 23);
            this.btCam3.TabIndex = 22;
            this.btCam3.Text = "3";
            this.btCam3.UseVisualStyleBackColor = true;
            this.btCam3.Click += new System.EventHandler(this.btCam3_Click);
            // 
            // btCam1
            // 
            this.btCam1.Location = new System.Drawing.Point(16, 19);
            this.btCam1.Name = "btCam1";
            this.btCam1.Size = new System.Drawing.Size(32, 23);
            this.btCam1.TabIndex = 20;
            this.btCam1.Text = "1";
            this.btCam1.UseVisualStyleBackColor = true;
            this.btCam1.Click += new System.EventHandler(this.btCam1_Click);
            // 
            // btCam2
            // 
            this.btCam2.Location = new System.Drawing.Point(78, 19);
            this.btCam2.Name = "btCam2";
            this.btCam2.Size = new System.Drawing.Size(32, 23);
            this.btCam2.TabIndex = 21;
            this.btCam2.Text = "2";
            this.btCam2.UseVisualStyleBackColor = true;
            this.btCam2.Click += new System.EventHandler(this.btCam2_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.activeCamerasListBox);
            this.groupBox5.Location = new System.Drawing.Point(210, 211);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(258, 128);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "My Active Cameras";
            // 
            // activeCamerasListBox
            // 
            this.activeCamerasListBox.FormattingEnabled = true;
            this.activeCamerasListBox.IntegralHeight = false;
            this.activeCamerasListBox.Items.AddRange(new object[] {
            "CAM 1",
            "CAM 2",
            "CAM 3",
            "CAM 4",
            "CAM 5",
            "CAM 6",
            "CAM 7",
            "CAM 8",
            "CAM 9",
            "CAM 10",
            "CAM 11",
            "CAM 12",
            "CAM 13",
            "CAM 14",
            "CAM 15",
            "CAM 16"});
            this.activeCamerasListBox.Location = new System.Drawing.Point(30, 19);
            this.activeCamerasListBox.MultiColumn = true;
            this.activeCamerasListBox.Name = "activeCamerasListBox";
            this.activeCamerasListBox.Size = new System.Drawing.Size(199, 93);
            this.activeCamerasListBox.TabIndex = 7;
            // 
            // groupBoxRec
            // 
            this.groupBoxRec.Controls.Add(this.lblNoCamerasRec);
            this.groupBoxRec.Controls.Add(this.camerasListBox);
            this.groupBoxRec.Controls.Add(this.lblAllCamerasRec);
            this.groupBoxRec.Controls.Add(this.boxLblREC);
            this.groupBoxRec.Controls.Add(this.lblREC);
            this.groupBoxRec.Controls.Add(this.btStopRecAll);
            this.groupBoxRec.Controls.Add(this.btStartRec);
            this.groupBoxRec.Enabled = false;
            this.groupBoxRec.Location = new System.Drawing.Point(7, 53);
            this.groupBoxRec.Name = "groupBoxRec";
            this.groupBoxRec.Size = new System.Drawing.Size(197, 152);
            this.groupBoxRec.TabIndex = 4;
            this.groupBoxRec.TabStop = false;
            this.groupBoxRec.Text = "Rec";
            // 
            // lblNoCamerasRec
            // 
            this.lblNoCamerasRec.AutoSize = true;
            this.lblNoCamerasRec.Location = new System.Drawing.Point(30, 14);
            this.lblNoCamerasRec.Name = "lblNoCamerasRec";
            this.lblNoCamerasRec.Size = new System.Drawing.Size(33, 13);
            this.lblNoCamerasRec.TabIndex = 6;
            this.lblNoCamerasRec.TabStop = true;
            this.lblNoCamerasRec.Text = "None";
            this.lblNoCamerasRec.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNoCamerasRec_LinkClicked);
            // 
            // camerasListBox
            // 
            this.camerasListBox.FormattingEnabled = true;
            this.camerasListBox.Items.AddRange(new object[] {
            "CAM 1",
            "CAM 2",
            "CAM 3",
            "CAM 4",
            "CAM 5",
            "CAM 6",
            "CAM 7",
            "CAM 8",
            "CAM 9",
            "CAM 10",
            "CAM 11",
            "CAM 12",
            "CAM 13",
            "CAM 14",
            "CAM 15",
            "CAM 16"});
            this.camerasListBox.Location = new System.Drawing.Point(6, 31);
            this.camerasListBox.Name = "camerasListBox";
            this.camerasListBox.Size = new System.Drawing.Size(89, 109);
            this.camerasListBox.TabIndex = 6;
            // 
            // lblAllCamerasRec
            // 
            this.lblAllCamerasRec.AutoSize = true;
            this.lblAllCamerasRec.Location = new System.Drawing.Point(6, 14);
            this.lblAllCamerasRec.Name = "lblAllCamerasRec";
            this.lblAllCamerasRec.Size = new System.Drawing.Size(18, 13);
            this.lblAllCamerasRec.TabIndex = 5;
            this.lblAllCamerasRec.TabStop = true;
            this.lblAllCamerasRec.Text = "All";
            this.lblAllCamerasRec.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAllCamerasRec_LinkClicked);
            // 
            // boxLblREC
            // 
            this.boxLblREC.BackColor = System.Drawing.Color.Black;
            this.boxLblREC.Location = new System.Drawing.Point(134, 41);
            this.boxLblREC.Name = "boxLblREC";
            this.boxLblREC.Size = new System.Drawing.Size(13, 11);
            this.boxLblREC.TabIndex = 5;
            // 
            // lblREC
            // 
            this.lblREC.AutoSize = true;
            this.lblREC.Location = new System.Drawing.Point(127, 24);
            this.lblREC.Name = "lblREC";
            this.lblREC.Size = new System.Drawing.Size(29, 13);
            this.lblREC.TabIndex = 3;
            this.lblREC.Text = "REC";
            // 
            // btStopRecAll
            // 
            this.btStopRecAll.Location = new System.Drawing.Point(104, 106);
            this.btStopRecAll.Name = "btStopRecAll";
            this.btStopRecAll.Size = new System.Drawing.Size(73, 23);
            this.btStopRecAll.TabIndex = 2;
            this.btStopRecAll.Text = "Stop All";
            this.btStopRecAll.UseVisualStyleBackColor = true;
            this.btStopRecAll.Click += new System.EventHandler(this.btStopRecAll_Click);
            // 
            // btStartRec
            // 
            this.btStartRec.Location = new System.Drawing.Point(104, 65);
            this.btStartRec.Name = "btStartRec";
            this.btStartRec.Size = new System.Drawing.Size(73, 23);
            this.btStartRec.TabIndex = 1;
            this.btStartRec.Text = "Start";
            this.btStartRec.UseVisualStyleBackColor = true;
            this.btStartRec.Click += new System.EventHandler(this.btStartRec_Click);
            // 
            // btAlarmReset
            // 
            this.btAlarmReset.Enabled = false;
            this.btAlarmReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAlarmReset.ForeColor = System.Drawing.Color.Red;
            this.btAlarmReset.Location = new System.Drawing.Point(296, 17);
            this.btAlarmReset.Name = "btAlarmReset";
            this.btAlarmReset.Size = new System.Drawing.Size(98, 30);
            this.btAlarmReset.TabIndex = 3;
            this.btAlarmReset.Text = "Alarm Reset";
            this.btAlarmReset.UseVisualStyleBackColor = true;
            this.btAlarmReset.Click += new System.EventHandler(this.btAlarmReset_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.statusListBox);
            this.groupBox4.Location = new System.Drawing.Point(474, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(282, 331);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Status Message Received";
            // 
            // statusListBox
            // 
            this.statusListBox.FormattingEnabled = true;
            this.statusListBox.Location = new System.Drawing.Point(6, 19);
            this.statusListBox.Name = "statusListBox";
            this.statusListBox.Size = new System.Drawing.Size(270, 303);
            this.statusListBox.TabIndex = 3;
            // 
            // btMonitorToggle
            // 
            this.btMonitorToggle.Location = new System.Drawing.Point(98, 17);
            this.btMonitorToggle.Name = "btMonitorToggle";
            this.btMonitorToggle.Size = new System.Drawing.Size(98, 30);
            this.btMonitorToggle.TabIndex = 1;
            this.btMonitorToggle.Text = "Start Monitor";
            this.btMonitorToggle.UseVisualStyleBackColor = true;
            this.btMonitorToggle.Click += new System.EventHandler(this.btMonitorToggle_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.alarmsListBox);
            this.groupBox2.Location = new System.Drawing.Point(7, 339);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(750, 162);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alarms";
            // 
            // alarmsListBox
            // 
            this.alarmsListBox.FormattingEnabled = true;
            this.alarmsListBox.Location = new System.Drawing.Point(6, 19);
            this.alarmsListBox.Name = "alarmsListBox";
            this.alarmsListBox.Size = new System.Drawing.Size(738, 134);
            this.alarmsListBox.TabIndex = 0;
            // 
            // statusTimer
            // 
            this.statusTimer.Interval = 3000;
            this.statusTimer.Tick += new System.EventHandler(this.statusTimer_Tick);
            // 
            // alarmTimer
            // 
            this.alarmTimer.Interval = 700;
            this.alarmTimer.Tick += new System.EventHandler(this.alarmTimer_Tick);
            // 
            // recordingsDataSet
            // 
            this.recordingsDataSet.DataSetName = "RecordingsDataSet";
            this.recordingsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 618);
            this.Controls.Add(this.mainFormTab);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Panasonic Digital Disk Recorder Tester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.camerasGroupBox.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.mainTab.ResumeLayout(false);
            this.tabLiveVideo.ResumeLayout(false);
            this.tabLiveVideo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recCtl)).EndInit();
            this.tabRecordings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recordsDataGrid)).EndInit();
            this.mainFormTab.ResumeLayout(false);
            this.tabPageVideo.ResumeLayout(false);
            this.tabPageAlarm.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.recorderKeyboard.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBoxRec.ResumeLayout(false);
            this.groupBoxRec.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recordingsDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button camPos1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblUid;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Button camPos2;
        private System.Windows.Forms.GroupBox camerasGroupBox;
        private System.Windows.Forms.Button camPos7;
        private System.Windows.Forms.Button camPos6;
        private System.Windows.Forms.Button camPos5;
        private System.Windows.Forms.Button camPos4;
        private System.Windows.Forms.Button camPos3;
        private System.Windows.Forms.Button camPos16;
        private System.Windows.Forms.Button camPos15;
        private System.Windows.Forms.Button camPos14;
        private System.Windows.Forms.Button camPos13;
        private System.Windows.Forms.Button camPos12;
        private System.Windows.Forms.Button camPos11;
        private System.Windows.Forms.Button camPos10;
        private System.Windows.Forms.Button camPos9;
        private System.Windows.Forms.Button camPos8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.TextBox txtServerHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCamNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer displayTimer;
        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TabPage tabLiveVideo;
        private System.Windows.Forms.TabPage tabRecordings;
        private System.Windows.Forms.Button btGetRecordings;
        private System.Windows.Forms.DataGridView recordsDataGrid;
        private System.Windows.Forms.ProgressBar getRecordsProgress;
        private RecordingsDataSet recordingsDataSet;
        private System.Windows.Forms.Button btSearch;
        private AxHD300SDKCONTROLLERLib.AxHD300SDKController recCtl;
        private System.ComponentModel.BackgroundWorker bWorkerGetRecords;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FrameTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn FrameNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CameraNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn isAlarmed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.TabControl mainFormTab;
        private System.Windows.Forms.TabPage tabPageVideo;
        private System.Windows.Forms.Button btLogout;
        private System.Windows.Forms.TabPage tabPageAlarm;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox alarmsListBox;
        private System.Windows.Forms.Button btMonitorToggle;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox statusListBox;
        private System.Windows.Forms.Button btAlarmReset;
        private System.Windows.Forms.Timer statusTimer;
        private System.Windows.Forms.GroupBox groupBoxRec;
        private System.Windows.Forms.Button btStopRecAll;
        private System.Windows.Forms.Button btStartRec;
        private System.Windows.Forms.Label boxLblREC;
        private System.Windows.Forms.Label lblREC;
        private System.Windows.Forms.Timer alarmTimer;
        private System.Windows.Forms.CheckedListBox camerasListBox;
        private System.Windows.Forms.LinkLabel lblNoCamerasRec;
        private System.Windows.Forms.LinkLabel lblAllCamerasRec;
        private System.Windows.Forms.Button btStopLive;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckedListBox activeCamerasListBox;
        private System.Windows.Forms.GroupBox recorderKeyboard;
        private System.Windows.Forms.Button btCam16;
        private System.Windows.Forms.Button btCam15;
        private System.Windows.Forms.Button btCam14;
        private System.Windows.Forms.Button btCam13;
        private System.Windows.Forms.Button btCam12;
        private System.Windows.Forms.Button btCam11;
        private System.Windows.Forms.Button btCam10;
        private System.Windows.Forms.Button btCam9;
        private System.Windows.Forms.Button btCam8;
        private System.Windows.Forms.Button btCam7;
        private System.Windows.Forms.Button btCam6;
        private System.Windows.Forms.Button btCam5;
        private System.Windows.Forms.Button btCam4;
        private System.Windows.Forms.Button btCam3;
        private System.Windows.Forms.Button btCam1;
        private System.Windows.Forms.Button btCam2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDiskCopy2;
        private System.Windows.Forms.Label lblDiskCopy1;
        private System.Windows.Forms.Label lblHDDCopy;
        private System.Windows.Forms.Label lblHDDEvent;
        private System.Windows.Forms.Label lblHDDNormal;
        private System.Windows.Forms.Button bExtract;
    }
}

