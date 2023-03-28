using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// Summary description for PlaybackControllersForm.
	/// </summary>
	public class PlaybackControllersForm : System.Windows.Forms.Form
	{
		private MainForm m_mainForm = null;

		private System.Windows.Forms.ListBox m_lbControllers;
		private System.Windows.Forms.Button m_btnPlay;
		private System.Windows.Forms.TextBox m_txtRate;
		private System.Windows.Forms.Button m_btnNew;
		private System.Windows.Forms.DateTimePicker m_seekDate;
		private System.Windows.Forms.DateTimePicker m_seekTime;
		private System.Windows.Forms.Button m_btnSeek;
		private System.Windows.Forms.Button m_btnSeekIFrame;
		private System.Windows.Forms.Button m_btnStep;
		private System.Windows.Forms.TextBox m_txtNumFrames;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox m_cbTrickMode;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label m_lblDisplayTime;

		private Bosch.VideoSDK.MediaDatabase.PlaybackController m_CurrentController;
		private Bosch.VideoSDK.GCALib._IPlaybackControllerEvents_PlaybackTimeEventHandler m_eventPlaybackTime;
		private Bosch.VideoSDK.GCALib._IPlaybackControllerEvents_PlaybackSpeedEventHandler m_eventPlaybackSpeed;
		private System.Windows.Forms.Label m_lblPlaybackSpeed;
		private System.Windows.Forms.Button m_btnRemoveMediaSessions;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PlaybackControllersForm(MainForm mainForm)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();


			// The event handler must be created before we initialized the list
			// and select a controller
			m_CurrentController = null;
			m_eventPlaybackTime = new Bosch.VideoSDK.GCALib._IPlaybackControllerEvents_PlaybackTimeEventHandler(PlaybackController_PlaybackTime);
			m_eventPlaybackSpeed = new Bosch.VideoSDK.GCALib._IPlaybackControllerEvents_PlaybackSpeedEventHandler(PlaybackController_PlaybackSpeed);


			m_mainForm = mainForm;
			m_mainForm.PutControllersInListBox(m_lbControllers);
			m_lbControllers.SelectedIndex = 0;
			
			// Default the seek time to one hour in the past.
			System.DateTime dt = DateTime.Now.AddHours(-1).ToUniversalTime();

			m_seekDate.Value = dt;
			m_seekTime.Value = dt;
			
			this.MouseWheel+=new MouseEventHandler(PlaybackControllersForm_MouseWheel);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PlaybackControllersForm));
			this.m_lbControllers = new System.Windows.Forms.ListBox();
			this.m_btnPlay = new System.Windows.Forms.Button();
			this.m_txtRate = new System.Windows.Forms.TextBox();
			this.m_btnNew = new System.Windows.Forms.Button();
			this.m_seekDate = new System.Windows.Forms.DateTimePicker();
			this.m_seekTime = new System.Windows.Forms.DateTimePicker();
			this.m_btnSeek = new System.Windows.Forms.Button();
			this.m_btnSeekIFrame = new System.Windows.Forms.Button();
			this.m_btnStep = new System.Windows.Forms.Button();
			this.m_txtNumFrames = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_btnRemoveMediaSessions = new System.Windows.Forms.Button();
			this.m_lblPlaybackSpeed = new System.Windows.Forms.Label();
			this.m_lblDisplayTime = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_cbTrickMode = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_lbControllers
			// 
			this.m_lbControllers.AccessibleDescription = resources.GetString("m_lbControllers.AccessibleDescription");
			this.m_lbControllers.AccessibleName = resources.GetString("m_lbControllers.AccessibleName");
			this.m_lbControllers.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("m_lbControllers.Anchor")));
			this.m_lbControllers.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_lbControllers.BackgroundImage")));
			this.m_lbControllers.ColumnWidth = ((int)(resources.GetObject("m_lbControllers.ColumnWidth")));
			this.m_lbControllers.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("m_lbControllers.Dock")));
			this.m_lbControllers.Enabled = ((bool)(resources.GetObject("m_lbControllers.Enabled")));
			this.m_lbControllers.Font = ((System.Drawing.Font)(resources.GetObject("m_lbControllers.Font")));
			this.m_lbControllers.HorizontalExtent = ((int)(resources.GetObject("m_lbControllers.HorizontalExtent")));
			this.m_lbControllers.HorizontalScrollbar = ((bool)(resources.GetObject("m_lbControllers.HorizontalScrollbar")));
			this.m_lbControllers.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("m_lbControllers.ImeMode")));
			this.m_lbControllers.IntegralHeight = ((bool)(resources.GetObject("m_lbControllers.IntegralHeight")));
			this.m_lbControllers.ItemHeight = ((int)(resources.GetObject("m_lbControllers.ItemHeight")));
			this.m_lbControllers.Location = ((System.Drawing.Point)(resources.GetObject("m_lbControllers.Location")));
			this.m_lbControllers.Name = "m_lbControllers";
			this.m_lbControllers.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("m_lbControllers.RightToLeft")));
			this.m_lbControllers.ScrollAlwaysVisible = ((bool)(resources.GetObject("m_lbControllers.ScrollAlwaysVisible")));
			this.m_lbControllers.Size = ((System.Drawing.Size)(resources.GetObject("m_lbControllers.Size")));
			this.m_lbControllers.TabIndex = ((int)(resources.GetObject("m_lbControllers.TabIndex")));
			this.m_lbControllers.Visible = ((bool)(resources.GetObject("m_lbControllers.Visible")));
			this.m_lbControllers.SelectedIndexChanged += new System.EventHandler(this.m_lbControllers_SelectedIndexChanged);
			// 
			// m_btnPlay
			// 
			this.m_btnPlay.AccessibleDescription = resources.GetString("m_btnPlay.AccessibleDescription");
			this.m_btnPlay.AccessibleName = resources.GetString("m_btnPlay.AccessibleName");
			this.m_btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("m_btnPlay.Anchor")));
			this.m_btnPlay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_btnPlay.BackgroundImage")));
			this.m_btnPlay.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("m_btnPlay.Dock")));
			this.m_btnPlay.Enabled = ((bool)(resources.GetObject("m_btnPlay.Enabled")));
			this.m_btnPlay.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("m_btnPlay.FlatStyle")));
			this.m_btnPlay.Font = ((System.Drawing.Font)(resources.GetObject("m_btnPlay.Font")));
			this.m_btnPlay.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPlay.Image")));
			this.m_btnPlay.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_btnPlay.ImageAlign")));
			this.m_btnPlay.ImageIndex = ((int)(resources.GetObject("m_btnPlay.ImageIndex")));
			this.m_btnPlay.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("m_btnPlay.ImeMode")));
			this.m_btnPlay.Location = ((System.Drawing.Point)(resources.GetObject("m_btnPlay.Location")));
			this.m_btnPlay.Name = "m_btnPlay";
			this.m_btnPlay.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("m_btnPlay.RightToLeft")));
			this.m_btnPlay.Size = ((System.Drawing.Size)(resources.GetObject("m_btnPlay.Size")));
			this.m_btnPlay.TabIndex = ((int)(resources.GetObject("m_btnPlay.TabIndex")));
			this.m_btnPlay.Text = resources.GetString("m_btnPlay.Text");
			this.m_btnPlay.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_btnPlay.TextAlign")));
			this.m_btnPlay.Visible = ((bool)(resources.GetObject("m_btnPlay.Visible")));
			this.m_btnPlay.Click += new System.EventHandler(this.m_btnPlay_Click);
			// 
			// m_txtRate
			// 
			this.m_txtRate.AccessibleDescription = resources.GetString("m_txtRate.AccessibleDescription");
			this.m_txtRate.AccessibleName = resources.GetString("m_txtRate.AccessibleName");
			this.m_txtRate.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("m_txtRate.Anchor")));
			this.m_txtRate.AutoSize = ((bool)(resources.GetObject("m_txtRate.AutoSize")));
			this.m_txtRate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_txtRate.BackgroundImage")));
			this.m_txtRate.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("m_txtRate.Dock")));
			this.m_txtRate.Enabled = ((bool)(resources.GetObject("m_txtRate.Enabled")));
			this.m_txtRate.Font = ((System.Drawing.Font)(resources.GetObject("m_txtRate.Font")));
			this.m_txtRate.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("m_txtRate.ImeMode")));
			this.m_txtRate.Location = ((System.Drawing.Point)(resources.GetObject("m_txtRate.Location")));
			this.m_txtRate.MaxLength = ((int)(resources.GetObject("m_txtRate.MaxLength")));
			this.m_txtRate.Multiline = ((bool)(resources.GetObject("m_txtRate.Multiline")));
			this.m_txtRate.Name = "m_txtRate";
			this.m_txtRate.PasswordChar = ((char)(resources.GetObject("m_txtRate.PasswordChar")));
			this.m_txtRate.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("m_txtRate.RightToLeft")));
			this.m_txtRate.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("m_txtRate.ScrollBars")));
			this.m_txtRate.Size = ((System.Drawing.Size)(resources.GetObject("m_txtRate.Size")));
			this.m_txtRate.TabIndex = ((int)(resources.GetObject("m_txtRate.TabIndex")));
			this.m_txtRate.Text = resources.GetString("m_txtRate.Text");
			this.m_txtRate.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("m_txtRate.TextAlign")));
			this.m_txtRate.Visible = ((bool)(resources.GetObject("m_txtRate.Visible")));
			this.m_txtRate.WordWrap = ((bool)(resources.GetObject("m_txtRate.WordWrap")));
			// 
			// m_btnNew
			// 
			this.m_btnNew.AccessibleDescription = resources.GetString("m_btnNew.AccessibleDescription");
			this.m_btnNew.AccessibleName = resources.GetString("m_btnNew.AccessibleName");
			this.m_btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("m_btnNew.Anchor")));
			this.m_btnNew.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_btnNew.BackgroundImage")));
			this.m_btnNew.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("m_btnNew.Dock")));
			this.m_btnNew.Enabled = ((bool)(resources.GetObject("m_btnNew.Enabled")));
			this.m_btnNew.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("m_btnNew.FlatStyle")));
			this.m_btnNew.Font = ((System.Drawing.Font)(resources.GetObject("m_btnNew.Font")));
			this.m_btnNew.Image = ((System.Drawing.Image)(resources.GetObject("m_btnNew.Image")));
			this.m_btnNew.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_btnNew.ImageAlign")));
			this.m_btnNew.ImageIndex = ((int)(resources.GetObject("m_btnNew.ImageIndex")));
			this.m_btnNew.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("m_btnNew.ImeMode")));
			this.m_btnNew.Location = ((System.Drawing.Point)(resources.GetObject("m_btnNew.Location")));
			this.m_btnNew.Name = "m_btnNew";
			this.m_btnNew.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("m_btnNew.RightToLeft")));
			this.m_btnNew.Size = ((System.Drawing.Size)(resources.GetObject("m_btnNew.Size")));
			this.m_btnNew.TabIndex = ((int)(resources.GetObject("m_btnNew.TabIndex")));
			this.m_btnNew.Text = resources.GetString("m_btnNew.Text");
			this.m_btnNew.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_btnNew.TextAlign")));
			this.m_btnNew.Visible = ((bool)(resources.GetObject("m_btnNew.Visible")));
			this.m_btnNew.Click += new System.EventHandler(this.m_btnNew_Click);
			// 
			// m_seekDate
			// 
			this.m_seekDate.AccessibleDescription = resources.GetString("m_seekDate.AccessibleDescription");
			this.m_seekDate.AccessibleName = resources.GetString("m_seekDate.AccessibleName");
			this.m_seekDate.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("m_seekDate.Anchor")));
			this.m_seekDate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_seekDate.BackgroundImage")));
			this.m_seekDate.CalendarFont = ((System.Drawing.Font)(resources.GetObject("m_seekDate.CalendarFont")));
			this.m_seekDate.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("m_seekDate.Dock")));
			this.m_seekDate.DropDownAlign = ((System.Windows.Forms.LeftRightAlignment)(resources.GetObject("m_seekDate.DropDownAlign")));
			this.m_seekDate.Enabled = ((bool)(resources.GetObject("m_seekDate.Enabled")));
			this.m_seekDate.Font = ((System.Drawing.Font)(resources.GetObject("m_seekDate.Font")));
			this.m_seekDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.m_seekDate.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("m_seekDate.ImeMode")));
			this.m_seekDate.Location = ((System.Drawing.Point)(resources.GetObject("m_seekDate.Location")));
			this.m_seekDate.Name = "m_seekDate";
			this.m_seekDate.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("m_seekDate.RightToLeft")));
			this.m_seekDate.Size = ((System.Drawing.Size)(resources.GetObject("m_seekDate.Size")));
			this.m_seekDate.TabIndex = ((int)(resources.GetObject("m_seekDate.TabIndex")));
			this.m_seekDate.Visible = ((bool)(resources.GetObject("m_seekDate.Visible")));
			// 
			// m_seekTime
			// 
			this.m_seekTime.AccessibleDescription = resources.GetString("m_seekTime.AccessibleDescription");
			this.m_seekTime.AccessibleName = resources.GetString("m_seekTime.AccessibleName");
			this.m_seekTime.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("m_seekTime.Anchor")));
			this.m_seekTime.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_seekTime.BackgroundImage")));
			this.m_seekTime.CalendarFont = ((System.Drawing.Font)(resources.GetObject("m_seekTime.CalendarFont")));
			this.m_seekTime.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("m_seekTime.Dock")));
			this.m_seekTime.DropDownAlign = ((System.Windows.Forms.LeftRightAlignment)(resources.GetObject("m_seekTime.DropDownAlign")));
			this.m_seekTime.Enabled = ((bool)(resources.GetObject("m_seekTime.Enabled")));
			this.m_seekTime.Font = ((System.Drawing.Font)(resources.GetObject("m_seekTime.Font")));
			this.m_seekTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.m_seekTime.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("m_seekTime.ImeMode")));
			this.m_seekTime.Location = ((System.Drawing.Point)(resources.GetObject("m_seekTime.Location")));
			this.m_seekTime.Name = "m_seekTime";
			this.m_seekTime.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("m_seekTime.RightToLeft")));
			this.m_seekTime.Size = ((System.Drawing.Size)(resources.GetObject("m_seekTime.Size")));
			this.m_seekTime.TabIndex = ((int)(resources.GetObject("m_seekTime.TabIndex")));
			this.m_seekTime.Visible = ((bool)(resources.GetObject("m_seekTime.Visible")));
			// 
			// m_btnSeek
			// 
			this.m_btnSeek.AccessibleDescription = resources.GetString("m_btnSeek.AccessibleDescription");
			this.m_btnSeek.AccessibleName = resources.GetString("m_btnSeek.AccessibleName");
			this.m_btnSeek.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("m_btnSeek.Anchor")));
			this.m_btnSeek.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_btnSeek.BackgroundImage")));
			this.m_btnSeek.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("m_btnSeek.Dock")));
			this.m_btnSeek.Enabled = ((bool)(resources.GetObject("m_btnSeek.Enabled")));
			this.m_btnSeek.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("m_btnSeek.FlatStyle")));
			this.m_btnSeek.Font = ((System.Drawing.Font)(resources.GetObject("m_btnSeek.Font")));
			this.m_btnSeek.Image = ((System.Drawing.Image)(resources.GetObject("m_btnSeek.Image")));
			this.m_btnSeek.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_btnSeek.ImageAlign")));
			this.m_btnSeek.ImageIndex = ((int)(resources.GetObject("m_btnSeek.ImageIndex")));
			this.m_btnSeek.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("m_btnSeek.ImeMode")));
			this.m_btnSeek.Location = ((System.Drawing.Point)(resources.GetObject("m_btnSeek.Location")));
			this.m_btnSeek.Name = "m_btnSeek";
			this.m_btnSeek.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("m_btnSeek.RightToLeft")));
			this.m_btnSeek.Size = ((System.Drawing.Size)(resources.GetObject("m_btnSeek.Size")));
			this.m_btnSeek.TabIndex = ((int)(resources.GetObject("m_btnSeek.TabIndex")));
			this.m_btnSeek.Text = resources.GetString("m_btnSeek.Text");
			this.m_btnSeek.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_btnSeek.TextAlign")));
			this.m_btnSeek.Visible = ((bool)(resources.GetObject("m_btnSeek.Visible")));
			this.m_btnSeek.Click += new System.EventHandler(this.m_btnSeek_Click);
			// 
			// m_btnSeekIFrame
			// 
			this.m_btnSeekIFrame.AccessibleDescription = resources.GetString("m_btnSeekIFrame.AccessibleDescription");
			this.m_btnSeekIFrame.AccessibleName = resources.GetString("m_btnSeekIFrame.AccessibleName");
			this.m_btnSeekIFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("m_btnSeekIFrame.Anchor")));
			this.m_btnSeekIFrame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_btnSeekIFrame.BackgroundImage")));
			this.m_btnSeekIFrame.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("m_btnSeekIFrame.Dock")));
			this.m_btnSeekIFrame.Enabled = ((bool)(resources.GetObject("m_btnSeekIFrame.Enabled")));
			this.m_btnSeekIFrame.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("m_btnSeekIFrame.FlatStyle")));
			this.m_btnSeekIFrame.Font = ((System.Drawing.Font)(resources.GetObject("m_btnSeekIFrame.Font")));
			this.m_btnSeekIFrame.Image = ((System.Drawing.Image)(resources.GetObject("m_btnSeekIFrame.Image")));
			this.m_btnSeekIFrame.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_btnSeekIFrame.ImageAlign")));
			this.m_btnSeekIFrame.ImageIndex = ((int)(resources.GetObject("m_btnSeekIFrame.ImageIndex")));
			this.m_btnSeekIFrame.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("m_btnSeekIFrame.ImeMode")));
			this.m_btnSeekIFrame.Location = ((System.Drawing.Point)(resources.GetObject("m_btnSeekIFrame.Location")));
			this.m_btnSeekIFrame.Name = "m_btnSeekIFrame";
			this.m_btnSeekIFrame.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("m_btnSeekIFrame.RightToLeft")));
			this.m_btnSeekIFrame.Size = ((System.Drawing.Size)(resources.GetObject("m_btnSeekIFrame.Size")));
			this.m_btnSeekIFrame.TabIndex = ((int)(resources.GetObject("m_btnSeekIFrame.TabIndex")));
			this.m_btnSeekIFrame.Text = resources.GetString("m_btnSeekIFrame.Text");
			this.m_btnSeekIFrame.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_btnSeekIFrame.TextAlign")));
			this.m_btnSeekIFrame.Visible = ((bool)(resources.GetObject("m_btnSeekIFrame.Visible")));
			this.m_btnSeekIFrame.Click += new System.EventHandler(this.m_btnSeekIFrame_Click);
			// 
			// m_btnStep
			// 
			this.m_btnStep.AccessibleDescription = resources.GetString("m_btnStep.AccessibleDescription");
			this.m_btnStep.AccessibleName = resources.GetString("m_btnStep.AccessibleName");
			this.m_btnStep.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("m_btnStep.Anchor")));
			this.m_btnStep.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_btnStep.BackgroundImage")));
			this.m_btnStep.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("m_btnStep.Dock")));
			this.m_btnStep.Enabled = ((bool)(resources.GetObject("m_btnStep.Enabled")));
			this.m_btnStep.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("m_btnStep.FlatStyle")));
			this.m_btnStep.Font = ((System.Drawing.Font)(resources.GetObject("m_btnStep.Font")));
			this.m_btnStep.Image = ((System.Drawing.Image)(resources.GetObject("m_btnStep.Image")));
			this.m_btnStep.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_btnStep.ImageAlign")));
			this.m_btnStep.ImageIndex = ((int)(resources.GetObject("m_btnStep.ImageIndex")));
			this.m_btnStep.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("m_btnStep.ImeMode")));
			this.m_btnStep.Location = ((System.Drawing.Point)(resources.GetObject("m_btnStep.Location")));
			this.m_btnStep.Name = "m_btnStep";
			this.m_btnStep.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("m_btnStep.RightToLeft")));
			this.m_btnStep.Size = ((System.Drawing.Size)(resources.GetObject("m_btnStep.Size")));
			this.m_btnStep.TabIndex = ((int)(resources.GetObject("m_btnStep.TabIndex")));
			this.m_btnStep.Text = resources.GetString("m_btnStep.Text");
			this.m_btnStep.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_btnStep.TextAlign")));
			this.m_btnStep.Visible = ((bool)(resources.GetObject("m_btnStep.Visible")));
			this.m_btnStep.Click += new System.EventHandler(this.m_btnStep_Click);
			// 
			// m_txtNumFrames
			// 
			this.m_txtNumFrames.AccessibleDescription = resources.GetString("m_txtNumFrames.AccessibleDescription");
			this.m_txtNumFrames.AccessibleName = resources.GetString("m_txtNumFrames.AccessibleName");
			this.m_txtNumFrames.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("m_txtNumFrames.Anchor")));
			this.m_txtNumFrames.AutoSize = ((bool)(resources.GetObject("m_txtNumFrames.AutoSize")));
			this.m_txtNumFrames.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_txtNumFrames.BackgroundImage")));
			this.m_txtNumFrames.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("m_txtNumFrames.Dock")));
			this.m_txtNumFrames.Enabled = ((bool)(resources.GetObject("m_txtNumFrames.Enabled")));
			this.m_txtNumFrames.Font = ((System.Drawing.Font)(resources.GetObject("m_txtNumFrames.Font")));
			this.m_txtNumFrames.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("m_txtNumFrames.ImeMode")));
			this.m_txtNumFrames.Location = ((System.Drawing.Point)(resources.GetObject("m_txtNumFrames.Location")));
			this.m_txtNumFrames.MaxLength = ((int)(resources.GetObject("m_txtNumFrames.MaxLength")));
			this.m_txtNumFrames.Multiline = ((bool)(resources.GetObject("m_txtNumFrames.Multiline")));
			this.m_txtNumFrames.Name = "m_txtNumFrames";
			this.m_txtNumFrames.PasswordChar = ((char)(resources.GetObject("m_txtNumFrames.PasswordChar")));
			this.m_txtNumFrames.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("m_txtNumFrames.RightToLeft")));
			this.m_txtNumFrames.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("m_txtNumFrames.ScrollBars")));
			this.m_txtNumFrames.Size = ((System.Drawing.Size)(resources.GetObject("m_txtNumFrames.Size")));
			this.m_txtNumFrames.TabIndex = ((int)(resources.GetObject("m_txtNumFrames.TabIndex")));
			this.m_txtNumFrames.Text = resources.GetString("m_txtNumFrames.Text");
			this.m_txtNumFrames.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("m_txtNumFrames.TextAlign")));
			this.m_txtNumFrames.Visible = ((bool)(resources.GetObject("m_txtNumFrames.Visible")));
			this.m_txtNumFrames.WordWrap = ((bool)(resources.GetObject("m_txtNumFrames.WordWrap")));
			// 
			// groupBox1
			// 
			this.groupBox1.AccessibleDescription = resources.GetString("groupBox1.AccessibleDescription");
			this.groupBox1.AccessibleName = resources.GetString("groupBox1.AccessibleName");
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox1.Anchor")));
			this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
			this.groupBox1.Controls.Add(this.m_btnRemoveMediaSessions);
			this.groupBox1.Controls.Add(this.m_lblPlaybackSpeed);
			this.groupBox1.Controls.Add(this.m_lblDisplayTime);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.m_cbTrickMode);
			this.groupBox1.Controls.Add(this.m_btnSeekIFrame);
			this.groupBox1.Controls.Add(this.m_btnSeek);
			this.groupBox1.Controls.Add(this.m_seekTime);
			this.groupBox1.Controls.Add(this.m_seekDate);
			this.groupBox1.Controls.Add(this.m_txtRate);
			this.groupBox1.Controls.Add(this.m_txtNumFrames);
			this.groupBox1.Controls.Add(this.m_btnPlay);
			this.groupBox1.Controls.Add(this.m_btnStep);
			this.groupBox1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox1.Dock")));
			this.groupBox1.Enabled = ((bool)(resources.GetObject("groupBox1.Enabled")));
			this.groupBox1.Font = ((System.Drawing.Font)(resources.GetObject("groupBox1.Font")));
			this.groupBox1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox1.ImeMode")));
			this.groupBox1.Location = ((System.Drawing.Point)(resources.GetObject("groupBox1.Location")));
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox1.RightToLeft")));
			this.groupBox1.Size = ((System.Drawing.Size)(resources.GetObject("groupBox1.Size")));
			this.groupBox1.TabIndex = ((int)(resources.GetObject("groupBox1.TabIndex")));
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = resources.GetString("groupBox1.Text");
			this.groupBox1.Visible = ((bool)(resources.GetObject("groupBox1.Visible")));
			// 
			// m_btnRemoveMediaSessions
			// 
			this.m_btnRemoveMediaSessions.AccessibleDescription = resources.GetString("m_btnRemoveMediaSessions.AccessibleDescription");
			this.m_btnRemoveMediaSessions.AccessibleName = resources.GetString("m_btnRemoveMediaSessions.AccessibleName");
			this.m_btnRemoveMediaSessions.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("m_btnRemoveMediaSessions.Anchor")));
			this.m_btnRemoveMediaSessions.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_btnRemoveMediaSessions.BackgroundImage")));
			this.m_btnRemoveMediaSessions.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("m_btnRemoveMediaSessions.Dock")));
			this.m_btnRemoveMediaSessions.Enabled = ((bool)(resources.GetObject("m_btnRemoveMediaSessions.Enabled")));
			this.m_btnRemoveMediaSessions.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("m_btnRemoveMediaSessions.FlatStyle")));
			this.m_btnRemoveMediaSessions.Font = ((System.Drawing.Font)(resources.GetObject("m_btnRemoveMediaSessions.Font")));
			this.m_btnRemoveMediaSessions.Image = ((System.Drawing.Image)(resources.GetObject("m_btnRemoveMediaSessions.Image")));
			this.m_btnRemoveMediaSessions.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_btnRemoveMediaSessions.ImageAlign")));
			this.m_btnRemoveMediaSessions.ImageIndex = ((int)(resources.GetObject("m_btnRemoveMediaSessions.ImageIndex")));
			this.m_btnRemoveMediaSessions.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("m_btnRemoveMediaSessions.ImeMode")));
			this.m_btnRemoveMediaSessions.Location = ((System.Drawing.Point)(resources.GetObject("m_btnRemoveMediaSessions.Location")));
			this.m_btnRemoveMediaSessions.Name = "m_btnRemoveMediaSessions";
			this.m_btnRemoveMediaSessions.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("m_btnRemoveMediaSessions.RightToLeft")));
			this.m_btnRemoveMediaSessions.Size = ((System.Drawing.Size)(resources.GetObject("m_btnRemoveMediaSessions.Size")));
			this.m_btnRemoveMediaSessions.TabIndex = ((int)(resources.GetObject("m_btnRemoveMediaSessions.TabIndex")));
			this.m_btnRemoveMediaSessions.Text = resources.GetString("m_btnRemoveMediaSessions.Text");
			this.m_btnRemoveMediaSessions.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_btnRemoveMediaSessions.TextAlign")));
			this.m_btnRemoveMediaSessions.Visible = ((bool)(resources.GetObject("m_btnRemoveMediaSessions.Visible")));
			this.m_btnRemoveMediaSessions.Click += new System.EventHandler(this.m_btnRemoveMediaSessions_Click);
			// 
			// m_lblPlaybackSpeed
			// 
			this.m_lblPlaybackSpeed.AccessibleDescription = resources.GetString("m_lblPlaybackSpeed.AccessibleDescription");
			this.m_lblPlaybackSpeed.AccessibleName = resources.GetString("m_lblPlaybackSpeed.AccessibleName");
			this.m_lblPlaybackSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("m_lblPlaybackSpeed.Anchor")));
			this.m_lblPlaybackSpeed.AutoSize = ((bool)(resources.GetObject("m_lblPlaybackSpeed.AutoSize")));
			this.m_lblPlaybackSpeed.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("m_lblPlaybackSpeed.Dock")));
			this.m_lblPlaybackSpeed.Enabled = ((bool)(resources.GetObject("m_lblPlaybackSpeed.Enabled")));
			this.m_lblPlaybackSpeed.Font = ((System.Drawing.Font)(resources.GetObject("m_lblPlaybackSpeed.Font")));
			this.m_lblPlaybackSpeed.Image = ((System.Drawing.Image)(resources.GetObject("m_lblPlaybackSpeed.Image")));
			this.m_lblPlaybackSpeed.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_lblPlaybackSpeed.ImageAlign")));
			this.m_lblPlaybackSpeed.ImageIndex = ((int)(resources.GetObject("m_lblPlaybackSpeed.ImageIndex")));
			this.m_lblPlaybackSpeed.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("m_lblPlaybackSpeed.ImeMode")));
			this.m_lblPlaybackSpeed.Location = ((System.Drawing.Point)(resources.GetObject("m_lblPlaybackSpeed.Location")));
			this.m_lblPlaybackSpeed.Name = "m_lblPlaybackSpeed";
			this.m_lblPlaybackSpeed.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("m_lblPlaybackSpeed.RightToLeft")));
			this.m_lblPlaybackSpeed.Size = ((System.Drawing.Size)(resources.GetObject("m_lblPlaybackSpeed.Size")));
			this.m_lblPlaybackSpeed.TabIndex = ((int)(resources.GetObject("m_lblPlaybackSpeed.TabIndex")));
			this.m_lblPlaybackSpeed.Text = resources.GetString("m_lblPlaybackSpeed.Text");
			this.m_lblPlaybackSpeed.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_lblPlaybackSpeed.TextAlign")));
			this.m_lblPlaybackSpeed.Visible = ((bool)(resources.GetObject("m_lblPlaybackSpeed.Visible")));
			// 
			// m_lblDisplayTime
			// 
			this.m_lblDisplayTime.AccessibleDescription = resources.GetString("m_lblDisplayTime.AccessibleDescription");
			this.m_lblDisplayTime.AccessibleName = resources.GetString("m_lblDisplayTime.AccessibleName");
			this.m_lblDisplayTime.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("m_lblDisplayTime.Anchor")));
			this.m_lblDisplayTime.AutoSize = ((bool)(resources.GetObject("m_lblDisplayTime.AutoSize")));
			this.m_lblDisplayTime.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("m_lblDisplayTime.Dock")));
			this.m_lblDisplayTime.Enabled = ((bool)(resources.GetObject("m_lblDisplayTime.Enabled")));
			this.m_lblDisplayTime.Font = ((System.Drawing.Font)(resources.GetObject("m_lblDisplayTime.Font")));
			this.m_lblDisplayTime.Image = ((System.Drawing.Image)(resources.GetObject("m_lblDisplayTime.Image")));
			this.m_lblDisplayTime.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_lblDisplayTime.ImageAlign")));
			this.m_lblDisplayTime.ImageIndex = ((int)(resources.GetObject("m_lblDisplayTime.ImageIndex")));
			this.m_lblDisplayTime.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("m_lblDisplayTime.ImeMode")));
			this.m_lblDisplayTime.Location = ((System.Drawing.Point)(resources.GetObject("m_lblDisplayTime.Location")));
			this.m_lblDisplayTime.Name = "m_lblDisplayTime";
			this.m_lblDisplayTime.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("m_lblDisplayTime.RightToLeft")));
			this.m_lblDisplayTime.Size = ((System.Drawing.Size)(resources.GetObject("m_lblDisplayTime.Size")));
			this.m_lblDisplayTime.TabIndex = ((int)(resources.GetObject("m_lblDisplayTime.TabIndex")));
			this.m_lblDisplayTime.Text = resources.GetString("m_lblDisplayTime.Text");
			this.m_lblDisplayTime.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_lblDisplayTime.TextAlign")));
			this.m_lblDisplayTime.Visible = ((bool)(resources.GetObject("m_lblDisplayTime.Visible")));
			// 
			// label1
			// 
			this.label1.AccessibleDescription = resources.GetString("label1.AccessibleDescription");
			this.label1.AccessibleName = resources.GetString("label1.AccessibleName");
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label1.Anchor")));
			this.label1.AutoSize = ((bool)(resources.GetObject("label1.AutoSize")));
			this.label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label1.Dock")));
			this.label1.Enabled = ((bool)(resources.GetObject("label1.Enabled")));
			this.label1.Font = ((System.Drawing.Font)(resources.GetObject("label1.Font")));
			this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
			this.label1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.ImageAlign")));
			this.label1.ImageIndex = ((int)(resources.GetObject("label1.ImageIndex")));
			this.label1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label1.ImeMode")));
			this.label1.Location = ((System.Drawing.Point)(resources.GetObject("label1.Location")));
			this.label1.Name = "label1";
			this.label1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label1.RightToLeft")));
			this.label1.Size = ((System.Drawing.Size)(resources.GetObject("label1.Size")));
			this.label1.TabIndex = ((int)(resources.GetObject("label1.TabIndex")));
			this.label1.Text = resources.GetString("label1.Text");
			this.label1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.TextAlign")));
			this.label1.Visible = ((bool)(resources.GetObject("label1.Visible")));
			// 
			// m_cbTrickMode
			// 
			this.m_cbTrickMode.AccessibleDescription = resources.GetString("m_cbTrickMode.AccessibleDescription");
			this.m_cbTrickMode.AccessibleName = resources.GetString("m_cbTrickMode.AccessibleName");
			this.m_cbTrickMode.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("m_cbTrickMode.Anchor")));
			this.m_cbTrickMode.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("m_cbTrickMode.Appearance")));
			this.m_cbTrickMode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_cbTrickMode.BackgroundImage")));
			this.m_cbTrickMode.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_cbTrickMode.CheckAlign")));
			this.m_cbTrickMode.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("m_cbTrickMode.Dock")));
			this.m_cbTrickMode.Enabled = ((bool)(resources.GetObject("m_cbTrickMode.Enabled")));
			this.m_cbTrickMode.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("m_cbTrickMode.FlatStyle")));
			this.m_cbTrickMode.Font = ((System.Drawing.Font)(resources.GetObject("m_cbTrickMode.Font")));
			this.m_cbTrickMode.Image = ((System.Drawing.Image)(resources.GetObject("m_cbTrickMode.Image")));
			this.m_cbTrickMode.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_cbTrickMode.ImageAlign")));
			this.m_cbTrickMode.ImageIndex = ((int)(resources.GetObject("m_cbTrickMode.ImageIndex")));
			this.m_cbTrickMode.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("m_cbTrickMode.ImeMode")));
			this.m_cbTrickMode.Location = ((System.Drawing.Point)(resources.GetObject("m_cbTrickMode.Location")));
			this.m_cbTrickMode.Name = "m_cbTrickMode";
			this.m_cbTrickMode.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("m_cbTrickMode.RightToLeft")));
			this.m_cbTrickMode.Size = ((System.Drawing.Size)(resources.GetObject("m_cbTrickMode.Size")));
			this.m_cbTrickMode.TabIndex = ((int)(resources.GetObject("m_cbTrickMode.TabIndex")));
			this.m_cbTrickMode.Text = resources.GetString("m_cbTrickMode.Text");
			this.m_cbTrickMode.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("m_cbTrickMode.TextAlign")));
			this.m_cbTrickMode.Visible = ((bool)(resources.GetObject("m_cbTrickMode.Visible")));
			this.m_cbTrickMode.CheckedChanged += new System.EventHandler(this.m_cbTrickMode_CheckedChanged);
			// 
			// PlaybackControllersForm
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.m_btnNew);
			this.Controls.Add(this.m_lbControllers);
			this.Controls.Add(this.groupBox1);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "PlaybackControllersForm";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void m_btnNew_Click(object sender, System.EventArgs e)
		{
			Bosch.VideoSDK.MediaDatabase.PlaybackControllerClass pc = m_mainForm.CreateNewController();

			m_mainForm.LogUserMessage("PlaybackControllersForm", "m_btnNew_Click", m_btnNew.Text + " (" + pc.Name + ")");

			PlaybackControllerWrapper wrapper = new PlaybackControllerWrapper(pc);
			m_lbControllers.Items.Add(wrapper);
		}
	
		protected override void OnClosing(CancelEventArgs e)
		{
			m_mainForm.OnPlaybackControllerFormClosed();
			base.OnClosing (e);
		}

		private Bosch.VideoSDK.MediaDatabase.PlaybackController GetSelectedController()
		{
			return ((PlaybackControllerWrapper)m_lbControllers.SelectedItem).m_pc;
		}

		private Bosch.VideoSDK.MediaDatabase.Time64 FillSeekTime()
		{
			Bosch.VideoSDK.MediaDatabase.Time64 t64 = new Bosch.VideoSDK.MediaDatabase.Time64();
			
			DateTime dt = new DateTime(
				m_seekDate.Value.Year,
				m_seekDate.Value.Month,
				m_seekDate.Value.Day,
				m_seekTime.Value.Hour,
				m_seekTime.Value.Minute,
				m_seekTime.Value.Second);
			
			t64.UTC = dt;

			return t64;
		}

		private void m_btnPlay_Click(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("PlaybackControllersForm", "m_btnPlay_Click", m_btnPlay.Text + " " + m_txtRate.Text + " (" + GetSelectedController().Name + ")");
			GetSelectedController().Play(int.Parse(m_txtRate.Text));
		}

		private void m_btnSeek_Click(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("PlaybackControllersForm", "m_btnSeek_Click", m_btnSeek.Text + " " + m_seekDate.Text + " " + m_seekTime.Text + " (" + GetSelectedController().Name + ")");
			GetSelectedController().Seek(FillSeekTime());
		}

		private void m_btnSeekIFrame_Click(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("PlaybackControllersForm", "m_btnSeekIFrame_Click", m_btnSeekIFrame.Text + " " + m_seekDate.Text + " " + m_seekTime.Text + " (" + GetSelectedController().Name + ")");
			GetSelectedController().SeekIFrame(FillSeekTime());
		}

		private void m_btnStep_Click(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("PlaybackControllersForm", "m_btnStep_Click", m_btnStep.Text + " " + m_txtNumFrames.Text + " (" + GetSelectedController().Name + ")");
			try
			{
				GetSelectedController().Step(null, int.Parse(m_txtNumFrames.Text));
			}
			catch (COMException ex)
			{
				m_mainForm.ErrorMessage("PlaybackControllerForm", "m_btnStep_Click", ex.Message, true);
			}
			catch 
			{
				m_mainForm.ErrorMessage("PlaybackControllerForm", "m_btnStep_Click", "Step method failed!", true);
			}
		}

		private void m_cbTrickMode_CheckedChanged(object sender, System.EventArgs e)
		{
			if (m_cbTrickMode.Checked)
			{
				m_mainForm.LogUserMessage("PlaybackControllersForm", "m_cbTrickMode_CheckedChanged", m_cbTrickMode.Text + " checked (" + GetSelectedController().Name + ")");

				GetSelectedController().SmoothReverseEnabled = true;
				m_btnStep.Enabled = true;
				m_txtNumFrames.Enabled = true;
			}
			else
			{
				m_mainForm.LogUserMessage("PlaybackControllersForm", "m_cbTrickMode_CheckedChanged", m_cbTrickMode.Text + " unchecked (" + GetSelectedController().Name + ")");

				GetSelectedController().SmoothReverseEnabled = false;
				m_btnStep.Enabled = false;
				m_txtNumFrames.Enabled = false;
			}

		}

		private void PlaybackControllersForm_MouseWheel(object sender, MouseEventArgs e)
		{
			if (!m_cbTrickMode.Checked) return;

			if (e.Delta > 0) 
			{
				GetSelectedController().Step(null, 1);
			}
			else if (e.Delta < 0) 
			{
				GetSelectedController().Step(null, -1);
			}
		}

		private void PlaybackController_PlaybackTime(Bosch.VideoSDK.MediaDatabase.Time64 currentPlaybackTime)
		{
			if (currentPlaybackTime != null)
			{
				m_lblDisplayTime.Text = currentPlaybackTime.UTC.ToString("yyyy-MM-dd hh:mm:ss.fff tt");
			}
		}

		private void PlaybackController_PlaybackSpeed(int speed)
		{
			m_lblPlaybackSpeed.Text = "(" + speed + ")";
		}

		private void m_lbControllers_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_lblPlaybackSpeed.Text = "";

			if (m_CurrentController != null)
			{
				((Bosch.VideoSDK.GCALib._IPlaybackControllerEvents_Event)m_CurrentController).PlaybackTime -= m_eventPlaybackTime;
				((Bosch.VideoSDK.GCALib._IPlaybackControllerEvents_Event)m_CurrentController).PlaybackSpeed -= m_eventPlaybackSpeed;
			}
			
			m_CurrentController = GetSelectedController();
			if (m_CurrentController != null)
			{
				((Bosch.VideoSDK.GCALib._IPlaybackControllerEvents_Event)m_CurrentController).PlaybackTime += m_eventPlaybackTime;
				((Bosch.VideoSDK.GCALib._IPlaybackControllerEvents_Event)m_CurrentController).PlaybackSpeed += m_eventPlaybackSpeed;
			}

			m_lblDisplayTime.Text = "";
			m_lblPlaybackSpeed.Text = "";
		}

		private void m_btnRemoveMediaSessions_Click(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("PlaybackControllersForm", "m_btnRemoveMediaSessions_Click", m_btnRemoveMediaSessions.Text + " (" + GetSelectedController().Name + ")");

			Bosch.VideoSDK.MediaSessions msCollection = GetSelectedController().MediaSessions;

			foreach (Bosch.VideoSDK.MediaSession ms in msCollection)
			{
				msCollection.Remove(ms);
			}
		}
	}
}
