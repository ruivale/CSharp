using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.IO;
using System.Runtime.InteropServices;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		// Data members
		private System.Timers.Timer m_cdTimer = null;
		private bool m_cdTestRunning = false;
		private bool m_cdTestConnected = false;
		private System.Timers.Timer m_cmtTimer = null;
		private bool m_cmtTestRunning = false;
		private int m_cmtMinutesElapsed = 0;

		public Bosch.VideoSDK.DiagnosticLogClass m_sdkLogfile = null;
		private Bosch.VideoSDK.Device.DeviceConnectorClass m_deviceConnector = null;
		private Bosch.VideoSDK.MediaDatabase.MediaFileWriterClass m_mediaFileWriter = null;
		public Bosch.VideoSDK.AudioLib.AudioReceiverClass m_audioReceiver = null;
		private Bosch.VideoSDK.AudioLib.AudioSourceClass m_audioSource = null;

		private int m_mediaFileVideoTrackID = 0;
		private int m_mediaFileAudioTrackID = 0;
		
		public System.Collections.Stack m_audioStreams = null;
		
		private const int m_maxCameos = 25;
		private const int m_borderSizeV = 8;
		private const int m_borderSizeH = 8;
		
		private int m_rows = 1;
		private int m_cols = 1;

		private Font m_treeFontConnected = new Font("Arial", 8, FontStyle.Bold);
		private Font m_treeFontDisconnected = new Font("Arial", 8, FontStyle.Regular);

		private Size m_defaultWindowSize;
		
		private Bosch.VideoSDK.AxCameoLib.AxCameo[] m_cameoArray;
		public Bosch.VideoSDK.AxCameoLib.AxCameo m_activeCameo = null;
		
		private int m_currentCameoIndex = 0;
		private bool m_bPreIncrementCameo = false;

		private int m_seqDeviceIndex = 0;
		private int m_seqVideoInputIndex = 0;

		private int m_salvoDeviceIndex = 0;
		private int m_salvoVideoInputIndex = 0;
		
		private System.Timers.Timer m_sequenceTimer = null;

		public System.Collections.ArrayList m_controllers = null;

		private System.Windows.Forms.TreeView m_deviceTree;
		private System.Windows.Forms.ContextMenu m_deviceTreeMenu;
		private System.Windows.Forms.MainMenu m_mainMenu;
		private System.Windows.Forms.MenuItem m_fileMenu;
		private System.Windows.Forms.MenuItem m_fileExitMenuItem;
		private System.Windows.Forms.MenuItem m_treeContextMenuConnect;
		private System.Windows.Forms.MenuItem m_treeContextMenuProperties;
		private System.Windows.Forms.MenuItem m_fileOpenMenuItem;
		private System.Windows.Forms.MenuItem m_fileSaveMenuItem;
		private System.Windows.Forms.MenuItem m_optionsMenu;
		private System.Windows.Forms.MenuItem m_useProgIDMenuItem;
		private System.Windows.Forms.MenuItem m_actionsMenu;
		private System.Windows.Forms.MenuItem m_actionsConnectAllMenuItem;
		private System.Windows.Forms.MenuItem m_actionsOpenDetectMenuItem;
		private System.Windows.Forms.MenuItem m_actionsDisconnectAllMenuItem;
		private System.Windows.Forms.MenuItem m_actionsVcaConfigMenuItem;
		private System.Windows.Forms.MenuItem m_useAsyncConnectMenuItem;
		private System.Windows.Forms.MenuItem m_restoreWindowMenuItem;
		private System.Windows.Forms.MenuItem m_treeContextMenuCameraController;
		private System.Windows.Forms.MenuItem m_cycleCameosMenuItem;
		private System.Windows.Forms.MenuItem m_useVMR9MenuItem;
		private System.Windows.Forms.OpenFileDialog m_openFileDialog;
		private System.Windows.Forms.SaveFileDialog m_saveFileDialog;
		private System.Windows.Forms.MenuItem m_treeContextMenuLiveProperties;
		private System.Windows.Forms.MenuItem m_stopAudioMenuItem;
		private System.Windows.Forms.MenuItem m_addMediaFileMenuItem;
		private System.Windows.Forms.MenuItem m_videoOutputMenuItem;
		private System.Windows.Forms.MenuItem m_startRecordingMenuItem;
		private System.Windows.Forms.MenuItem m_seqMenuItem;
		private System.Windows.Forms.MenuItem m_treeContextMenuMediaDatabase;
		private System.Windows.Forms.MenuItem m_separatorMenuItem;
		private System.Windows.Forms.MenuItem m_openPlaybackMenuItem;
		private System.Windows.Forms.MenuItem m_fileOpenMediaMenuItem;
		private System.Windows.Forms.ContextMenu m_mediaFileContextMenu;
		private System.Windows.Forms.MenuItem m_mediaFileContextMenuMediaDatabase;
		private System.Windows.Forms.MenuItem m_clearCameoSubmenu;
		private System.Windows.Forms.MenuItem m_clearCameoAllMenuItem;
		private System.Windows.Forms.MenuItem m_clearCameoActiveMenuItem;
		private System.Windows.Forms.MenuItem m_keepAspectRatioMenuItem;
		private System.Windows.Forms.MenuItem m_snapVideoToWindowMenuItem;
		private System.Windows.Forms.ContextMenu m_avOutputContextMenu;
		private System.Windows.Forms.MenuItem m_sendAudioMenuItem;
		private System.Windows.Forms.MenuItem m_selectAudioMenuItem;
		private System.Windows.Forms.ContextMenu m_videoInputContextMenu;
		private System.Windows.Forms.ContextMenu m_videoOutputContextMenu;
		private System.Windows.Forms.ContextMenu m_audioInputContextMenu;
		private System.Windows.Forms.MenuItem m_volumeSubMenu;
		private System.Windows.Forms.MenuItem m_volume25MenuItem;
		private System.Windows.Forms.MenuItem m_volume50MenuItem;
		private System.Windows.Forms.MenuItem m_volume75MenuItem;
		private System.Windows.Forms.MenuItem m_volume100MenuItem;
		private System.Windows.Forms.MenuItem m_volume0MenuItem;
		private System.Windows.Forms.MenuItem m_dzMenuItem;
		private System.Windows.Forms.MenuItem m_runGCMenuItem;
		private System.Windows.Forms.MenuItem m_runCdTestMenuItem;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem m_runCmtMenuItem;
		private System.Windows.Forms.MenuItem m_logLevel0MenuItem;
		private System.Windows.Forms.MenuItem m_logLevel1MenuItem;
		private System.Windows.Forms.MenuItem m_logLevel2MenuItem;
		private System.Windows.Forms.MenuItem m_logLevel3MenuItem;
		private System.Windows.Forms.ListBox m_lbMessages;
		private System.Windows.Forms.MenuItem m_lipSyncMenuItem;
		private System.Windows.Forms.MenuItem m_cameoContextMenuItem;
		private System.Windows.Forms.MenuItem m_1CameoMenuItem;
		private System.Windows.Forms.MenuItem m_4CameosMenuItem;
		private System.Windows.Forms.MenuItem m_9CameosMenuItem;
		private System.Windows.Forms.MenuItem m_16CameosMenuItem;
		private System.Windows.Forms.MenuItem m_25CameosMenuItem;
		private System.Windows.Forms.MenuItem m_loggingMenuItem;
		private System.Windows.Forms.MenuItem m_cameoArrangementMenuItem;
		private System.Windows.Forms.MenuItem m_captureSnapshotMenuItem;
		private System.Windows.Forms.SaveFileDialog m_saveCaptureFileDialog;
		private System.Windows.Forms.MenuItem m_inputCameraController;
		private System.Windows.Forms.MenuItem m_inputConnectTo;
		private System.Windows.Forms.MenuItem m_actionsViewNativeVideoSizeMenuItem;
		private System.Windows.Forms.MenuItem m_salvoCameosMenuItem;
		private System.Windows.Forms.MenuItem m_enableRendererFallbackMenuItem;
		private System.Windows.Forms.MenuItem m_addAudioToWriterMenuItem;
		private System.Windows.Forms.MenuItem m_mediaFileContextMenuCloseFile;
		private System.Windows.Forms.MenuItem m_displayFileCommentMenuItem;

		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			// Required for Windows Form Designer support
			InitializeComponent();

			// Create and initialize the Video SDK's diagnostic logfile.
			// Here we create the file "SampleLog.txt" to be 8 MB in size.
			m_sdkLogfile = new Bosch.VideoSDK.DiagnosticLogClass();
			m_sdkLogfile.SetLogFilenameAndSize("SampleLog.txt", 8);
			m_sdkLogfile.LoggingLevel = 2;

			// Write a message to the log to indicate that we are starting up.
			LogUserMessage("MainForm", "MainForm", "Starting Advanced C# Sample");

			// Create the Video SDK's device connector and
			// add event handlers for its event.
			m_deviceConnector = new Bosch.VideoSDK.Device.DeviceConnectorClass();
			m_deviceConnector.ConnectResult += new Bosch.VideoSDK.GCALib._IDeviceConnectorEvents_ConnectResultEventHandler(OnConnectResult);

			// Create a media file writer component and register
			// for the "recording stopped" event.
			m_mediaFileWriter = new Bosch.VideoSDK.MediaDatabase.MediaFileWriterClass();
			m_mediaFileWriter.RecordingStopped += new Bosch.VideoSDK.GCALib._IMediaFileWriterEvents_RecordingStoppedEventHandler(m_mediaFileWriter_RecordingStopped);

			// Note the current windows size in case it should be restored later.
			m_defaultWindowSize = this.Size;

			// Create the audio receiver and source.
			m_audioReceiver = new Bosch.VideoSDK.AudioLib.AudioReceiverClass();
			
			// Catch exception when audio driver not installed.
			try
			{
				m_audioSource = new Bosch.VideoSDK.AudioLib.AudioSourceClass();
				m_audioSource.SelectDevice(0);
				m_audioSource.EnableInput(0, true);
			}
			catch
			{
			}

			// Create the list of assigned audio streams.
			m_audioStreams = new System.Collections.Stack();

			// Create the sequence timer with a 5 second interval.
			m_sequenceTimer = new System.Timers.Timer(5000);
			m_sequenceTimer.Elapsed += new System.Timers.ElapsedEventHandler(m_sequenceTimer_Elapsed);

			// Create the array of playback controllers, initizlly sized at zero.
			m_controllers = new System.Collections.ArrayList(0);
			CreateNewController();

			// Open the tree configuration file.
			OpenFile("tree.xml");
			
			// Create timers.
			m_cdTimer = new System.Timers.Timer(10000);
			m_cdTimer.Elapsed += new System.Timers.ElapsedEventHandler(m_cdTimer_Elapsed);
			m_cdTimer.SynchronizingObject = this;

			m_cmtTimer = new System.Timers.Timer(60000);
			m_cmtTimer.Elapsed += new System.Timers.ElapsedEventHandler(m_cmtTimer_Elapsed);

			// Add the version number to the title bar.
			this.Text += " " + System.Reflection.Assembly.GetAssembly(this.GetType()).GetName().Version;

            this.AddDevice("172.18.56.71", "", "172.18.56.71", "NVR", "", "", "");
		}

		protected override void OnLoad(EventArgs e)
		{
			// Create the cameo ActiveX controls.
			m_cameoArray = new Bosch.VideoSDK.AxCameoLib.AxCameo[m_maxCameos];

			for (int i = 0; i < m_cameoArray.Length; i++)
			{
				m_cameoArray[i] = new Bosch.VideoSDK.AxCameoLib.AxCameo();
				this.Controls.Add(m_cameoArray[i]);

				m_cameoArray[i].MouseAction +=new Bosch.VideoSDK.AxCameoLib._ICameoEvents_MouseActionEventHandler(OnCameoMouseAction);
				m_cameoArray[i].VideoStatus +=new Bosch.VideoSDK.AxCameoLib._ICameoEvents_VideoStatusEventHandler(OnCameoVideoStatus);
			}

			SetUseVMR9(m_useVMR9MenuItem.Checked);

			m_activeCameo = m_cameoArray[0];
			m_activeCameo.Active = true;
			m_activeCameo.EnableOverlay = true;

			base.OnLoad (e);
		}

		public void ErrorMessage(string className, string functionName, string msg, bool bShowMessageBox)
		{
			if (bShowMessageBox)
				MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

			m_lbMessages.Items.Add(DateTime.Now.ToString() + " " + msg);
			m_lbMessages.SelectedIndex = m_lbMessages.Items.Count - 1;

			m_sdkLogfile.LogMessage(
				className,
				functionName,
				"SAMPLE_USER",
				1,
				"ERROR MSG: " + msg);
		}

		public void LogMessage(string className, string functionName, string msg)
		{
			m_sdkLogfile.LogMessage(
				className,
				functionName,
				"SAMPLE",
				1,
				msg);
		}

		public void LogUserMessage(string className, string functionName, string msg)
		{
			m_sdkLogfile.LogMessage(
				className,
				functionName,
				"SAMPLE_USER",
				1,
				msg);
		}

		private void SetUseVMR9(bool flag)
		{
			int i = 0;
			bool bVisible;

			if (m_cameoArray != null)
			{
				for (i = 0; i < (m_maxCameos); i++)
				{
					bVisible = m_cameoArray[i].Visible;
					m_cameoArray[i].Visible = true;

					if (flag)
						m_cameoArray[i].PreferredRenderer = Bosch.VideoSDK.CameoLib.RendererEnum.reVMR9;
					else
						m_cameoArray[i].PreferredRenderer = Bosch.VideoSDK.CameoLib.RendererEnum.reVMR7;

					m_cameoArray[i].Visible = bVisible;
				}
			}
		}

		private void SetEnableRendererFallback(bool flag)
		{
			int i = 0;
			bool bVisible;

			if (m_cameoArray != null)
			{
				for (i = 0; i < (m_maxCameos); i++)
				{
					bVisible = m_cameoArray[i].Visible;
					m_cameoArray[i].Visible = true;
					m_cameoArray[i].EnableRendererFallback = flag;
					m_cameoArray[i].Visible = bVisible;
				}
			}
		}

		private void SetKeepAspectRatio(bool flag)
		{
			int i = 0;
			bool bVisible;

			if (m_cameoArray != null)
			{
				for (i = 0; i < (m_maxCameos); i++)
				{
					bVisible = m_cameoArray[i].Visible;
					m_cameoArray[i].Visible = true;
					m_cameoArray[i].KeepAspectRatio = flag;
					m_cameoArray[i].Visible = bVisible;
				}
			}
		}

		private void SetSnapVideoToWindow(bool flag)
		{
			int i = 0;
			bool bVisible;

			if (m_cameoArray != null)
			{
				for (i = 0; i < (m_maxCameos); i++)
				{
					bVisible = m_cameoArray[i].Visible;
					m_cameoArray[i].Visible = true;
					m_cameoArray[i].SnapVideoToWindow = flag;
					m_cameoArray[i].Visible = bVisible;
				}
			}
		}

		private void ArrangeControls()
		{
			int i = 0;
			int availableWidth = 0;
			int availableHeight = 0;
			int cameoWidth = 0;
			int cameoHeight = 0;
			int messagesHeight = 0;

			// Arrange the device tree according to the client area's height.
			m_deviceTree.Left = m_borderSizeH;
			m_deviceTree.Top = 0;
			messagesHeight = m_lbMessages.Size.Height;
			m_deviceTree.Height = this.ClientRectangle.Height - messagesHeight - m_borderSizeV;

			m_lbMessages.Left = m_borderSizeH;
			m_lbMessages.Top = m_deviceTree.Top + m_deviceTree.Height;
			
			// Arrange the cameos according to the size available to the right of the device tree.
			if (m_cameoArray != null)
			{
				for (i = 0; i < m_maxCameos; i++)
					m_cameoArray[i].Visible = false;

				availableWidth = this.ClientRectangle.Width - m_deviceTree.Width - m_borderSizeH * 3;
				availableHeight = this.ClientRectangle.Height - m_borderSizeV;
				
				cameoWidth = (availableWidth - m_borderSizeH * (m_cols - 1)) / m_cols;
				cameoHeight = (availableHeight - m_borderSizeV * (m_rows - 1)) / m_rows;

				i = 0;
				for (int r = 0; r < m_rows; r++)
				{
					for (int c = 0; c < m_cols; c++)
					{
						m_cameoArray[i].Visible = true;
						m_cameoArray[i].Size = new System.Drawing.Size(cameoWidth, cameoHeight);
						m_cameoArray[i].Left = m_deviceTree.Right + m_borderSizeH * (c + 1) + cameoWidth * c;
						m_cameoArray[i].Top = m_borderSizeV * (r) + cameoHeight * r;
						i++;
					}
				}
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.m_deviceTree = new System.Windows.Forms.TreeView();
			this.m_deviceTreeMenu = new System.Windows.Forms.ContextMenu();
			this.m_treeContextMenuConnect = new System.Windows.Forms.MenuItem();
			this.m_treeContextMenuProperties = new System.Windows.Forms.MenuItem();
			this.m_treeContextMenuCameraController = new System.Windows.Forms.MenuItem();
			this.m_treeContextMenuLiveProperties = new System.Windows.Forms.MenuItem();
			this.m_treeContextMenuMediaDatabase = new System.Windows.Forms.MenuItem();
			this.m_mainMenu = new System.Windows.Forms.MainMenu();
			this.m_fileMenu = new System.Windows.Forms.MenuItem();
			this.m_fileOpenMenuItem = new System.Windows.Forms.MenuItem();
			this.m_fileSaveMenuItem = new System.Windows.Forms.MenuItem();
			this.m_fileOpenMediaMenuItem = new System.Windows.Forms.MenuItem();
			this.m_separatorMenuItem = new System.Windows.Forms.MenuItem();
			this.m_fileExitMenuItem = new System.Windows.Forms.MenuItem();
			this.m_actionsMenu = new System.Windows.Forms.MenuItem();
			this.m_actionsOpenDetectMenuItem = new System.Windows.Forms.MenuItem();
			this.m_actionsConnectAllMenuItem = new System.Windows.Forms.MenuItem();
			this.m_actionsDisconnectAllMenuItem = new System.Windows.Forms.MenuItem();
			this.m_restoreWindowMenuItem = new System.Windows.Forms.MenuItem();
			this.m_captureSnapshotMenuItem = new System.Windows.Forms.MenuItem();
			this.m_stopAudioMenuItem = new System.Windows.Forms.MenuItem();
			this.m_seqMenuItem = new System.Windows.Forms.MenuItem();
			this.m_openPlaybackMenuItem = new System.Windows.Forms.MenuItem();
			this.m_salvoCameosMenuItem = new System.Windows.Forms.MenuItem();
			this.m_clearCameoSubmenu = new System.Windows.Forms.MenuItem();
			this.m_clearCameoAllMenuItem = new System.Windows.Forms.MenuItem();
			this.m_clearCameoActiveMenuItem = new System.Windows.Forms.MenuItem();
			this.m_startRecordingMenuItem = new System.Windows.Forms.MenuItem();
			this.m_selectAudioMenuItem = new System.Windows.Forms.MenuItem();
			this.m_dzMenuItem = new System.Windows.Forms.MenuItem();
			this.m_actionsVcaConfigMenuItem = new System.Windows.Forms.MenuItem();
			this.m_actionsViewNativeVideoSizeMenuItem = new System.Windows.Forms.MenuItem();
			this.m_optionsMenu = new System.Windows.Forms.MenuItem();
			this.m_useProgIDMenuItem = new System.Windows.Forms.MenuItem();
			this.m_useAsyncConnectMenuItem = new System.Windows.Forms.MenuItem();
			this.m_cycleCameosMenuItem = new System.Windows.Forms.MenuItem();
			this.m_useVMR9MenuItem = new System.Windows.Forms.MenuItem();
			this.m_enableRendererFallbackMenuItem = new System.Windows.Forms.MenuItem();
			this.m_keepAspectRatioMenuItem = new System.Windows.Forms.MenuItem();
			this.m_snapVideoToWindowMenuItem = new System.Windows.Forms.MenuItem();
			this.m_loggingMenuItem = new System.Windows.Forms.MenuItem();
			this.m_logLevel0MenuItem = new System.Windows.Forms.MenuItem();
			this.m_logLevel1MenuItem = new System.Windows.Forms.MenuItem();
			this.m_logLevel2MenuItem = new System.Windows.Forms.MenuItem();
			this.m_logLevel3MenuItem = new System.Windows.Forms.MenuItem();
			this.m_lipSyncMenuItem = new System.Windows.Forms.MenuItem();
			this.m_cameoContextMenuItem = new System.Windows.Forms.MenuItem();
			this.m_cameoArrangementMenuItem = new System.Windows.Forms.MenuItem();
			this.m_1CameoMenuItem = new System.Windows.Forms.MenuItem();
			this.m_4CameosMenuItem = new System.Windows.Forms.MenuItem();
			this.m_9CameosMenuItem = new System.Windows.Forms.MenuItem();
			this.m_16CameosMenuItem = new System.Windows.Forms.MenuItem();
			this.m_25CameosMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.m_runCdTestMenuItem = new System.Windows.Forms.MenuItem();
			this.m_runCmtMenuItem = new System.Windows.Forms.MenuItem();
			this.m_runGCMenuItem = new System.Windows.Forms.MenuItem();
			this.m_openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.m_saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.m_videoInputContextMenu = new System.Windows.Forms.ContextMenu();
			this.m_addMediaFileMenuItem = new System.Windows.Forms.MenuItem();
			this.m_inputCameraController = new System.Windows.Forms.MenuItem();
			this.m_inputConnectTo = new System.Windows.Forms.MenuItem();
			this.m_videoOutputContextMenu = new System.Windows.Forms.ContextMenu();
			this.m_videoOutputMenuItem = new System.Windows.Forms.MenuItem();
			this.m_mediaFileContextMenu = new System.Windows.Forms.ContextMenu();
			this.m_mediaFileContextMenuMediaDatabase = new System.Windows.Forms.MenuItem();
			this.m_mediaFileContextMenuCloseFile = new System.Windows.Forms.MenuItem();
			this.m_avOutputContextMenu = new System.Windows.Forms.ContextMenu();
			this.m_sendAudioMenuItem = new System.Windows.Forms.MenuItem();
			this.m_audioInputContextMenu = new System.Windows.Forms.ContextMenu();
			this.m_addAudioToWriterMenuItem = new System.Windows.Forms.MenuItem();
			this.m_volumeSubMenu = new System.Windows.Forms.MenuItem();
			this.m_volume0MenuItem = new System.Windows.Forms.MenuItem();
			this.m_volume25MenuItem = new System.Windows.Forms.MenuItem();
			this.m_volume50MenuItem = new System.Windows.Forms.MenuItem();
			this.m_volume75MenuItem = new System.Windows.Forms.MenuItem();
			this.m_volume100MenuItem = new System.Windows.Forms.MenuItem();
			this.m_lbMessages = new System.Windows.Forms.ListBox();
			this.m_saveCaptureFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.m_displayFileCommentMenuItem = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// m_deviceTree
			// 
			this.m_deviceTree.AllowDrop = true;
			this.m_deviceTree.ContextMenu = this.m_deviceTreeMenu;
			this.m_deviceTree.ImageIndex = -1;
			this.m_deviceTree.Location = new System.Drawing.Point(8, 0);
			this.m_deviceTree.Name = "m_deviceTree";
			this.m_deviceTree.SelectedImageIndex = -1;
			this.m_deviceTree.Size = new System.Drawing.Size(240, 488);
			this.m_deviceTree.TabIndex = 5;
			this.m_deviceTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_deviceTree_MouseDown);
			this.m_deviceTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_deviceTree_AfterSelect);
			this.m_deviceTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_deviceTree_BeforeExpand);
			// 
			// m_deviceTreeMenu
			// 
			this.m_deviceTreeMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							 this.m_treeContextMenuConnect,
																							 this.m_treeContextMenuProperties,
																							 this.m_treeContextMenuCameraController,
																							 this.m_treeContextMenuLiveProperties,
																							 this.m_treeContextMenuMediaDatabase});
			this.m_deviceTreeMenu.Popup += new System.EventHandler(this.m_deviceTreeMenu_Popup);
			// 
			// m_treeContextMenuConnect
			// 
			this.m_treeContextMenuConnect.Index = 0;
			this.m_treeContextMenuConnect.Text = "Connect";
			this.m_treeContextMenuConnect.Click += new System.EventHandler(this.m_treeContextMenuConnect_Click);
			// 
			// m_treeContextMenuProperties
			// 
			this.m_treeContextMenuProperties.Index = 1;
			this.m_treeContextMenuProperties.Text = "Device Properties...";
			this.m_treeContextMenuProperties.Click += new System.EventHandler(this.m_treeContextMenuProperties_Click);
			// 
			// m_treeContextMenuCameraController
			// 
			this.m_treeContextMenuCameraController.Index = 2;
			this.m_treeContextMenuCameraController.Text = "Camera Controller...";
			this.m_treeContextMenuCameraController.Click += new System.EventHandler(this.m_treeContextMenuCameraController_Click);
			// 
			// m_treeContextMenuLiveProperties
			// 
			this.m_treeContextMenuLiveProperties.Index = 3;
			this.m_treeContextMenuLiveProperties.Text = "Live Video Properties...";
			this.m_treeContextMenuLiveProperties.Click += new System.EventHandler(this.m_treeContextMenuLiveProperties_Click);
			// 
			// m_treeContextMenuMediaDatabase
			// 
			this.m_treeContextMenuMediaDatabase.Index = 4;
			this.m_treeContextMenuMediaDatabase.Text = "Media Database...";
			this.m_treeContextMenuMediaDatabase.Click += new System.EventHandler(this.m_treeContextMenuMediaDatabase_Click);
			// 
			// m_mainMenu
			// 
			this.m_mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.m_fileMenu,
																					   this.m_actionsMenu,
																					   this.m_optionsMenu,
																					   this.menuItem1});
			// 
			// m_fileMenu
			// 
			this.m_fileMenu.Index = 0;
			this.m_fileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.m_fileOpenMenuItem,
																					   this.m_fileSaveMenuItem,
																					   this.m_fileOpenMediaMenuItem,
																					   this.m_separatorMenuItem,
																					   this.m_fileExitMenuItem});
			this.m_fileMenu.Text = "File";
			// 
			// m_fileOpenMenuItem
			// 
			this.m_fileOpenMenuItem.Index = 0;
			this.m_fileOpenMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.m_fileOpenMenuItem.Text = "Open Device Tree...";
			this.m_fileOpenMenuItem.Click += new System.EventHandler(this.m_fileOpenMenuItem_Click);
			// 
			// m_fileSaveMenuItem
			// 
			this.m_fileSaveMenuItem.Index = 1;
			this.m_fileSaveMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.m_fileSaveMenuItem.Text = "Save Device Tree...";
			this.m_fileSaveMenuItem.Click += new System.EventHandler(this.m_fileSaveMenuItem_Click);
			// 
			// m_fileOpenMediaMenuItem
			// 
			this.m_fileOpenMediaMenuItem.Index = 2;
			this.m_fileOpenMediaMenuItem.Text = "Open Media File...";
			this.m_fileOpenMediaMenuItem.Click += new System.EventHandler(this.m_fileOpenMediaMenuItem_Click);
			// 
			// m_separatorMenuItem
			// 
			this.m_separatorMenuItem.Index = 3;
			this.m_separatorMenuItem.Text = "-";
			// 
			// m_fileExitMenuItem
			// 
			this.m_fileExitMenuItem.Index = 4;
			this.m_fileExitMenuItem.Text = "Exit";
			this.m_fileExitMenuItem.Click += new System.EventHandler(this.m_fileExitMenuItem_Click);
			// 
			// m_actionsMenu
			// 
			this.m_actionsMenu.Index = 1;
			this.m_actionsMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						  this.m_actionsOpenDetectMenuItem,
																						  this.m_actionsConnectAllMenuItem,
																						  this.m_actionsDisconnectAllMenuItem,
																						  this.m_restoreWindowMenuItem,
																						  this.m_captureSnapshotMenuItem,
																						  this.m_stopAudioMenuItem,
																						  this.m_seqMenuItem,
																						  this.m_openPlaybackMenuItem,
																						  this.m_salvoCameosMenuItem,
																						  this.m_clearCameoSubmenu,
																						  this.m_startRecordingMenuItem,
																						  this.m_selectAudioMenuItem,
																						  this.m_dzMenuItem,
																						  this.m_actionsVcaConfigMenuItem,
																						  this.m_actionsViewNativeVideoSizeMenuItem});
			this.m_actionsMenu.Text = "Actions";
			// 
			// m_actionsOpenDetectMenuItem
			// 
			this.m_actionsOpenDetectMenuItem.Index = 0;
			this.m_actionsOpenDetectMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
			this.m_actionsOpenDetectMenuItem.Text = "Open Detection Window...";
			this.m_actionsOpenDetectMenuItem.Click += new System.EventHandler(this.m_actionsOpenDetectMenuItem_Click);
			// 
			// m_actionsConnectAllMenuItem
			// 
			this.m_actionsConnectAllMenuItem.Index = 1;
			this.m_actionsConnectAllMenuItem.Text = "Connect All";
			this.m_actionsConnectAllMenuItem.Click += new System.EventHandler(this.m_actionsConnectAllMenuItem_Click);
			// 
			// m_actionsDisconnectAllMenuItem
			// 
			this.m_actionsDisconnectAllMenuItem.Index = 2;
			this.m_actionsDisconnectAllMenuItem.Text = "Disconnect All";
			this.m_actionsDisconnectAllMenuItem.Click += new System.EventHandler(this.m_actionsDisconnectAllMenuItem_Click);
			// 
			// m_restoreWindowMenuItem
			// 
			this.m_restoreWindowMenuItem.Index = 3;
			this.m_restoreWindowMenuItem.Text = "Restore Default Window Size";
			this.m_restoreWindowMenuItem.Click += new System.EventHandler(this.m_restoreWindowMenuItem_Click);
			// 
			// m_captureSnapshotMenuItem
			// 
			this.m_captureSnapshotMenuItem.Index = 4;
			this.m_captureSnapshotMenuItem.Text = "Capture Snapshot...";
			this.m_captureSnapshotMenuItem.Click += new System.EventHandler(this.m_captureSnapshotMenuItem_Click);
			// 
			// m_stopAudioMenuItem
			// 
			this.m_stopAudioMenuItem.Index = 5;
			this.m_stopAudioMenuItem.Text = "Stop all Audio Streams";
			this.m_stopAudioMenuItem.Click += new System.EventHandler(this.m_stopAudioMenuItem_Click);
			// 
			// m_seqMenuItem
			// 
			this.m_seqMenuItem.Index = 6;
			this.m_seqMenuItem.Text = "Sequence Connected Video Inputs";
			this.m_seqMenuItem.Click += new System.EventHandler(this.m_seqMenuItem_Click);
			// 
			// m_openPlaybackMenuItem
			// 
			this.m_openPlaybackMenuItem.Index = 7;
			this.m_openPlaybackMenuItem.Text = "Open Playback Controllers...";
			this.m_openPlaybackMenuItem.Click += new System.EventHandler(this.m_openPlaybackMenuItem_Click);
			// 
			// m_salvoCameosMenuItem
			// 
			this.m_salvoCameosMenuItem.Index = 8;
			this.m_salvoCameosMenuItem.Text = "Salvo All Cameos";
			this.m_salvoCameosMenuItem.Click += new System.EventHandler(this.m_salvoCameosMenuItem_Click);
			// 
			// m_clearCameoSubmenu
			// 
			this.m_clearCameoSubmenu.Index = 9;
			this.m_clearCameoSubmenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								this.m_clearCameoAllMenuItem,
																								this.m_clearCameoActiveMenuItem});
			this.m_clearCameoSubmenu.Text = "Clear Cameo";
			// 
			// m_clearCameoAllMenuItem
			// 
			this.m_clearCameoAllMenuItem.Index = 0;
			this.m_clearCameoAllMenuItem.Text = "All";
			this.m_clearCameoAllMenuItem.Click += new System.EventHandler(this.m_clearCameoAllMenuItem_Click);
			// 
			// m_clearCameoActiveMenuItem
			// 
			this.m_clearCameoActiveMenuItem.Index = 1;
			this.m_clearCameoActiveMenuItem.Text = "Active";
			this.m_clearCameoActiveMenuItem.Click += new System.EventHandler(this.m_clearCameoActiveMenuItem_Click);
			// 
			// m_startRecordingMenuItem
			// 
			this.m_startRecordingMenuItem.Enabled = false;
			this.m_startRecordingMenuItem.Index = 10;
			this.m_startRecordingMenuItem.Text = "Start MediaFileWriter Recording";
			this.m_startRecordingMenuItem.Click += new System.EventHandler(this.m_startRecordingMenuItem_Click);
			// 
			// m_selectAudioMenuItem
			// 
			this.m_selectAudioMenuItem.Index = 11;
			this.m_selectAudioMenuItem.Text = "Select Audio Input...";
			this.m_selectAudioMenuItem.Click += new System.EventHandler(this.m_selectAudioMenuItem_Click);
			// 
			// m_dzMenuItem
			// 
			this.m_dzMenuItem.Index = 12;
			this.m_dzMenuItem.Text = "Digital Zoom...";
			this.m_dzMenuItem.Click += new System.EventHandler(this.m_dzMenuItem_Click);
			// 
			// m_actionsVcaConfigMenuItem
			// 
			this.m_actionsVcaConfigMenuItem.Index = 13;
			this.m_actionsVcaConfigMenuItem.Text = "VcaConfig";
			this.m_actionsVcaConfigMenuItem.Click += new System.EventHandler(this.m_actionsVcaConfigMenuItem_Click);
			// 
			// m_actionsViewNativeVideoSizeMenuItem
			// 
			this.m_actionsViewNativeVideoSizeMenuItem.Index = 14;
			this.m_actionsViewNativeVideoSizeMenuItem.Text = "View Native Video Size...";
			this.m_actionsViewNativeVideoSizeMenuItem.Click += new System.EventHandler(this.m_actionsViewNativeVideoSizeMenuItem_Click);
			// 
			// m_optionsMenu
			// 
			this.m_optionsMenu.Index = 2;
			this.m_optionsMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						  this.m_useProgIDMenuItem,
																						  this.m_useAsyncConnectMenuItem,
																						  this.m_cycleCameosMenuItem,
																						  this.m_useVMR9MenuItem,
																						  this.m_enableRendererFallbackMenuItem,
																						  this.m_keepAspectRatioMenuItem,
																						  this.m_snapVideoToWindowMenuItem,
																						  this.m_loggingMenuItem,
																						  this.m_lipSyncMenuItem,
																						  this.m_cameoContextMenuItem,
																						  this.m_cameoArrangementMenuItem});
			this.m_optionsMenu.Text = "Options";
			// 
			// m_useProgIDMenuItem
			// 
			this.m_useProgIDMenuItem.Checked = true;
			this.m_useProgIDMenuItem.Index = 0;
			this.m_useProgIDMenuItem.Text = "Use ProgID for Connect";
			this.m_useProgIDMenuItem.Click += new System.EventHandler(this.m_useProgIDMenuItem_Click);
			// 
			// m_useAsyncConnectMenuItem
			// 
			this.m_useAsyncConnectMenuItem.Checked = true;
			this.m_useAsyncConnectMenuItem.Index = 1;
			this.m_useAsyncConnectMenuItem.Text = "Use Asynchronous Connect";
			this.m_useAsyncConnectMenuItem.Click += new System.EventHandler(this.m_useAsyncConnectMenuItem_Click);
			// 
			// m_cycleCameosMenuItem
			// 
			this.m_cycleCameosMenuItem.Index = 2;
			this.m_cycleCameosMenuItem.Text = "Cycle Through Cameos";
			this.m_cycleCameosMenuItem.Click += new System.EventHandler(this.m_cycleCameosMenuItem_Click);
			// 
			// m_useVMR9MenuItem
			// 
			this.m_useVMR9MenuItem.Checked = true;
			this.m_useVMR9MenuItem.Index = 3;
			this.m_useVMR9MenuItem.Text = "Use VMR9";
			this.m_useVMR9MenuItem.Click += new System.EventHandler(this.m_useVMR9MenuItem_Click);
			// 
			// m_enableRendererFallbackMenuItem
			// 
			this.m_enableRendererFallbackMenuItem.Index = 4;
			this.m_enableRendererFallbackMenuItem.Text = "Enable Renderer Fallback";
			this.m_enableRendererFallbackMenuItem.Click += new System.EventHandler(this.m_enableRendererFallbackMenuItem_Click);
			// 
			// m_keepAspectRatioMenuItem
			// 
			this.m_keepAspectRatioMenuItem.Checked = true;
			this.m_keepAspectRatioMenuItem.Index = 5;
			this.m_keepAspectRatioMenuItem.Text = "Keep 4:3 Aspect Ratio";
			this.m_keepAspectRatioMenuItem.Click += new System.EventHandler(this.m_keepAspectRatioMenuItem_Click);
			// 
			// m_snapVideoToWindowMenuItem
			// 
			this.m_snapVideoToWindowMenuItem.Index = 6;
			this.m_snapVideoToWindowMenuItem.Text = "Snap Video To Window";
			this.m_snapVideoToWindowMenuItem.Click += new System.EventHandler(this.m_snapVideoToWindowMenuItem_Click);
			// 
			// m_loggingMenuItem
			// 
			this.m_loggingMenuItem.Index = 7;
			this.m_loggingMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							  this.m_logLevel0MenuItem,
																							  this.m_logLevel1MenuItem,
																							  this.m_logLevel2MenuItem,
																							  this.m_logLevel3MenuItem});
			this.m_loggingMenuItem.Text = "Logging";
			// 
			// m_logLevel0MenuItem
			// 
			this.m_logLevel0MenuItem.Index = 0;
			this.m_logLevel0MenuItem.Text = "Level 0";
			this.m_logLevel0MenuItem.Click += new System.EventHandler(this.m_logLevel0MenuItem_Click);
			// 
			// m_logLevel1MenuItem
			// 
			this.m_logLevel1MenuItem.Index = 1;
			this.m_logLevel1MenuItem.Text = "Level 1";
			this.m_logLevel1MenuItem.Click += new System.EventHandler(this.m_logLevel1MenuItem_Click);
			// 
			// m_logLevel2MenuItem
			// 
			this.m_logLevel2MenuItem.Checked = true;
			this.m_logLevel2MenuItem.Index = 2;
			this.m_logLevel2MenuItem.Text = "Level 2";
			this.m_logLevel2MenuItem.Click += new System.EventHandler(this.m_logLevel2MenuItem_Click);
			// 
			// m_logLevel3MenuItem
			// 
			this.m_logLevel3MenuItem.Index = 3;
			this.m_logLevel3MenuItem.Text = "Level 3";
			this.m_logLevel3MenuItem.Click += new System.EventHandler(this.m_logLevel3MenuItem_Click);
			// 
			// m_lipSyncMenuItem
			// 
			this.m_lipSyncMenuItem.Checked = true;
			this.m_lipSyncMenuItem.Index = 8;
			this.m_lipSyncMenuItem.Text = "Enable MPEG2 Lip Sync";
			this.m_lipSyncMenuItem.Click += new System.EventHandler(this.m_lipSyncMenuItem_Click);
			// 
			// m_cameoContextMenuItem
			// 
			this.m_cameoContextMenuItem.Index = 9;
			this.m_cameoContextMenuItem.Text = "Enable Cameo Context Menu";
			this.m_cameoContextMenuItem.Click += new System.EventHandler(this.m_cameoContextMenuItem_Click);
			// 
			// m_cameoArrangementMenuItem
			// 
			this.m_cameoArrangementMenuItem.Index = 10;
			this.m_cameoArrangementMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																									   this.m_1CameoMenuItem,
																									   this.m_4CameosMenuItem,
																									   this.m_9CameosMenuItem,
																									   this.m_16CameosMenuItem,
																									   this.m_25CameosMenuItem});
			this.m_cameoArrangementMenuItem.Text = "Cameo Arrangement";
			// 
			// m_1CameoMenuItem
			// 
			this.m_1CameoMenuItem.Index = 0;
			this.m_1CameoMenuItem.Text = "Single";
			this.m_1CameoMenuItem.Click += new System.EventHandler(this.m_1CameoMenuItem_Click);
			// 
			// m_4CameosMenuItem
			// 
			this.m_4CameosMenuItem.Checked = true;
			this.m_4CameosMenuItem.Index = 1;
			this.m_4CameosMenuItem.Text = "Quad";
			this.m_4CameosMenuItem.Click += new System.EventHandler(this.m_4CameosMenuItem_Click);
			// 
			// m_9CameosMenuItem
			// 
			this.m_9CameosMenuItem.Index = 2;
			this.m_9CameosMenuItem.Text = "3 x 3";
			this.m_9CameosMenuItem.Click += new System.EventHandler(this.m_9CameosMenuItem_Click);
			// 
			// m_16CameosMenuItem
			// 
			this.m_16CameosMenuItem.Index = 3;
			this.m_16CameosMenuItem.Text = "4 x 4";
			this.m_16CameosMenuItem.Click += new System.EventHandler(this.m_16CameosMenuItem_Click);
			// 
			// m_25CameosMenuItem
			// 
			this.m_25CameosMenuItem.Index = 4;
			this.m_25CameosMenuItem.Text = "5 x 5";
			this.m_25CameosMenuItem.Click += new System.EventHandler(this.m_25CameosMenuItem_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 3;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.m_runCdTestMenuItem,
																					  this.m_runCmtMenuItem,
																					  this.m_runGCMenuItem});
			this.menuItem1.Text = "Tests";
			// 
			// m_runCdTestMenuItem
			// 
			this.m_runCdTestMenuItem.Index = 0;
			this.m_runCdTestMenuItem.Text = "Run Connect and Disconnect Test";
			this.m_runCdTestMenuItem.Click += new System.EventHandler(this.m_runCdTestMenuItem_Click);
			// 
			// m_runCmtMenuItem
			// 
			this.m_runCmtMenuItem.Index = 1;
			this.m_runCmtMenuItem.Text = "Run Stability Test";
			this.m_runCmtMenuItem.Click += new System.EventHandler(this.m_runCmtMenuItem_Click);
			// 
			// m_runGCMenuItem
			// 
			this.m_runGCMenuItem.Index = 2;
			this.m_runGCMenuItem.Text = "Run Garbage Collection";
			this.m_runGCMenuItem.Click += new System.EventHandler(this.m_runGCMenuItem_Click);
			// 
			// m_openFileDialog
			// 
			this.m_openFileDialog.Filter = "Device Tree Files|*.xml|All files|*.*";
			this.m_openFileDialog.Title = "Advanced Video SDK C# Sample - Open Device Tree";
			// 
			// m_saveFileDialog
			// 
			this.m_saveFileDialog.DefaultExt = "xml";
			this.m_saveFileDialog.Filter = "Device Tree Files|*.xml|All files|*.*";
			this.m_saveFileDialog.Title = "Advanced Video SDK C# Sample - Save Device Tree";
			// 
			// m_videoInputContextMenu
			// 
			this.m_videoInputContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																									this.m_addMediaFileMenuItem,
																									this.m_inputCameraController,
																									this.m_inputConnectTo});
			this.m_videoInputContextMenu.Popup += new System.EventHandler(this.m_videoInputContextMenu_Popup);
			// 
			// m_addMediaFileMenuItem
			// 
			this.m_addMediaFileMenuItem.Index = 0;
			this.m_addMediaFileMenuItem.Text = "Add to Media File Writer";
			this.m_addMediaFileMenuItem.Click += new System.EventHandler(this.m_addMediaFileMenuItem_Click);
			// 
			// m_inputCameraController
			// 
			this.m_inputCameraController.Index = 1;
			this.m_inputCameraController.Text = "Camera Controller...";
			this.m_inputCameraController.Click += new System.EventHandler(this.m_inputCameraController_Click);
			// 
			// m_inputConnectTo
			// 
			this.m_inputConnectTo.Index = 2;
			this.m_inputConnectTo.Text = "Connect To";
			// 
			// m_videoOutputContextMenu
			// 
			this.m_videoOutputContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																									 this.m_videoOutputMenuItem});
			// 
			// m_videoOutputMenuItem
			// 
			this.m_videoOutputMenuItem.Index = 0;
			this.m_videoOutputMenuItem.Text = "Configure Video Monitor";
			this.m_videoOutputMenuItem.Click += new System.EventHandler(this.m_videoOutputMenuItem_Click);
			// 
			// m_mediaFileContextMenu
			// 
			this.m_mediaFileContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								   this.m_mediaFileContextMenuMediaDatabase,
																								   this.m_displayFileCommentMenuItem,
																								   this.m_mediaFileContextMenuCloseFile});
			// 
			// m_mediaFileContextMenuMediaDatabase
			// 
			this.m_mediaFileContextMenuMediaDatabase.Index = 0;
			this.m_mediaFileContextMenuMediaDatabase.Text = "Media Database...";
			this.m_mediaFileContextMenuMediaDatabase.Click += new System.EventHandler(this.m_mediaFileContextMenuMediaDatabase_Click);
			// 
			// m_mediaFileContextMenuCloseFile
			// 
			this.m_mediaFileContextMenuCloseFile.Index = 2;
			this.m_mediaFileContextMenuCloseFile.Text = "CloseFile";
			this.m_mediaFileContextMenuCloseFile.Click += new System.EventHandler(this.m_mediaFileContextMenuCloseFile_Click);
			// 
			// m_avOutputContextMenu
			// 
			this.m_avOutputContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								  this.m_sendAudioMenuItem});
			// 
			// m_sendAudioMenuItem
			// 
			this.m_sendAudioMenuItem.Index = 0;
			this.m_sendAudioMenuItem.Text = "Send Audio";
			this.m_sendAudioMenuItem.Click += new System.EventHandler(this.m_sendAudioMenuItem_Click);
			// 
			// m_audioInputContextMenu
			// 
			this.m_audioInputContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																									this.m_addAudioToWriterMenuItem,
																									this.m_volumeSubMenu});
			// 
			// m_addAudioToWriterMenuItem
			// 
			this.m_addAudioToWriterMenuItem.Index = 0;
			this.m_addAudioToWriterMenuItem.Text = "Add to Media File Writer";
			this.m_addAudioToWriterMenuItem.Click += new System.EventHandler(this.m_addMediaFileMenuItem_Click);
			// 
			// m_volumeSubMenu
			// 
			this.m_volumeSubMenu.Index = 1;
			this.m_volumeSubMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.m_volume0MenuItem,
																							this.m_volume25MenuItem,
																							this.m_volume50MenuItem,
																							this.m_volume75MenuItem,
																							this.m_volume100MenuItem});
			this.m_volumeSubMenu.Text = "Volume";
			// 
			// m_volume0MenuItem
			// 
			this.m_volume0MenuItem.Index = 0;
			this.m_volume0MenuItem.Text = "0%";
			this.m_volume0MenuItem.Click += new System.EventHandler(this.m_volume0MenuItem_Click);
			// 
			// m_volume25MenuItem
			// 
			this.m_volume25MenuItem.Index = 1;
			this.m_volume25MenuItem.Text = "25%";
			this.m_volume25MenuItem.Click += new System.EventHandler(this.m_volume25MenuItem_Click);
			// 
			// m_volume50MenuItem
			// 
			this.m_volume50MenuItem.Index = 2;
			this.m_volume50MenuItem.Text = "50%";
			this.m_volume50MenuItem.Click += new System.EventHandler(this.m_volume50MenuItem_Click);
			// 
			// m_volume75MenuItem
			// 
			this.m_volume75MenuItem.Index = 3;
			this.m_volume75MenuItem.Text = "75%";
			this.m_volume75MenuItem.Click += new System.EventHandler(this.m_volume75MenuItem_Click);
			// 
			// m_volume100MenuItem
			// 
			this.m_volume100MenuItem.Index = 4;
			this.m_volume100MenuItem.Text = "100%";
			this.m_volume100MenuItem.Click += new System.EventHandler(this.m_volume100MenuItem_Click);
			// 
			// m_lbMessages
			// 
			this.m_lbMessages.HorizontalScrollbar = true;
			this.m_lbMessages.Location = new System.Drawing.Point(8, 496);
			this.m_lbMessages.Name = "m_lbMessages";
			this.m_lbMessages.Size = new System.Drawing.Size(240, 108);
			this.m_lbMessages.TabIndex = 6;
			// 
			// m_saveCaptureFileDialog
			// 
			this.m_saveCaptureFileDialog.DefaultExt = "jpg";
			this.m_saveCaptureFileDialog.Filter = "JPEG (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp";
			// 
			// m_displayFileCommentMenuItem
			// 
			this.m_displayFileCommentMenuItem.Index = 1;
			this.m_displayFileCommentMenuItem.Text = "Display File Comment";
			this.m_displayFileCommentMenuItem.Click += new System.EventHandler(this.m_displayFileCommentMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1072, 625);
			this.Controls.Add(this.m_lbMessages);
			this.Controls.Add(this.m_deviceTree);
			this.Menu = this.m_mainMenu;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Advanced Video SDK C# Sample ";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		public void OnDetectFormClosed()
		{
			m_actionsOpenDetectMenuItem.Enabled = true;
		}

		public void OnPlaybackControllerFormClosed()
		{
			m_openPlaybackMenuItem.Enabled = true;
		}

		public void AddDevice(string name, string protocol, string address, string descr, string username, string password, string progID)
		{
			// Add the device to the tree view.
			string nodeText = name + " (" + address + ")";
			
			DeviceTreeNode node = new DeviceTreeNode(nodeText);

			node.m_nodeText = nodeText;
			node.m_deviceName = name;
			node.m_deviceProtocol = protocol;
			node.m_deviceAddress = address;
			node.m_deviceDescription = descr;
			node.m_username = username;
			node.m_password = password;
			node.m_progID = progID;
			node.ImageIndex = 0;
			node.NodeFont = m_treeFontDisconnected;
			node.m_mainForm = this;
			
			m_deviceTree.Nodes.Add(node);
		}

		private void m_actionsOpenDetectMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_actionsDetectOpenMenuItem_Click", m_actionsOpenDetectMenuItem.Text);

			// Create the detection form and show it.
			if (m_actionsOpenDetectMenuItem.Enabled == true)
			{
				DetectForm detectForm = new DetectForm(this);
				detectForm.Show();
				m_actionsOpenDetectMenuItem.Enabled = false;
			}
		}

		private void m_fileExitMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_fileExitMenuItem_Click", m_fileExitMenuItem.Text);
			this.Close();
		}

		private void m_deviceTreeMenu_Popup(object sender, System.EventArgs e)
		{
			if (m_deviceTree.SelectedNode is DeviceTreeNode)
			{
				DeviceTreeNode node = (DeviceTreeNode)m_deviceTree.SelectedNode;
				
				if (node.m_bConnected)
				{
					m_treeContextMenuConnect.Text = "Disconnect";
				}
				else
				{
					m_treeContextMenuConnect.Text = "Connect";
				}
			}
	
		}

		private void ConnectToDevice(DeviceTreeNode node)
		{
			if (!node.m_bConnected)
			{
				// Connect to the device using a URL that we build.  
				// The connection will be signalled into the OnConnection event handler.
			
				node.m_deviceUrl = "";

				if (node.m_deviceProtocol != "")
					node.m_deviceUrl += node.m_deviceProtocol + "://";

				if (node.m_username != "")
				{
					node.m_deviceUrl += node.m_username;

					if (node.m_password != "")
						node.m_deviceUrl += ":" + node.m_password;

					node.m_deviceUrl += "@";
				}

				node.m_deviceUrl += node.m_deviceAddress;

				try
				{
					string progID;

					if (m_useProgIDMenuItem.Checked)
						progID = node.m_progID;
					else
						progID = "";

					if (m_useAsyncConnectMenuItem.Checked)
					{
						// The asynchronous connect option is selected, so establish the
						// connection asynchronously.  The m_deviceConnector will send the result
						// of the connection attempt through its ConnectResult event, which
						// is sinked by our OnConnectResult method.

						LogMessage("MainForm", "ConnectToDevice", "Trying to connect (async) to " + node.m_deviceUrl + ".");

						m_deviceConnector.ConnectAsync(node.m_deviceUrl, progID);
					}
					else
					{
						// Establish the connection synchronously.  This will block until the
						// connection result is known.  The ConnectResult event is not used to
						// signal the result in this case.  Instead, the returned deviceProxy
						// will indicate the result with its ConnectResult property.

						LogMessage("MainForm", "ConnectToDevice", "Trying to connect (sync) to " + node.m_deviceUrl + ".");

						Bosch.VideoSDK.Device.DeviceProxy deviceProxy = m_deviceConnector.Connect(node.m_deviceUrl, progID);
						OnConnectResult(deviceProxy.ConnectionState, node.m_deviceUrl, deviceProxy);
					}
				}
				catch (COMException e)
				{
					ErrorMessage("MainForm", "ConnectToDevice", "Error " + String.Format("{0:x}", e.ErrorCode) + ": " + e.Message, false);
				}
			}
		}

		private void OnConnectResult(Bosch.VideoSDK.Device.ConnectResultEnum result, string url, Bosch.VideoSDK.Device.DeviceProxy deviceProxy)
		{
			switch (result)
			{

				case Bosch.VideoSDK.Device.ConnectResultEnum.creInitialized:
				case Bosch.VideoSDK.Device.ConnectResultEnum.creConnected:
					LogMessage("MainForm", "OnConnectResult", "Connected to " + url + ".");

					// The connection was successfully established.
					foreach (TreeNode treeNode in m_deviceTree.Nodes)
					{
						DeviceTreeNode deviceTreeNode;
						if (treeNode is DeviceTreeNode)
							deviceTreeNode = (DeviceTreeNode)treeNode;
						else continue;
					
						if (deviceTreeNode.m_deviceUrl == url)
						{
							// Indicate that we are connected.
							treeNode.Text += ' ';
							deviceTreeNode.NodeFont = m_treeFontConnected;
							deviceTreeNode.SetDeviceProxy(deviceProxy);

							// Add live video inputs.
							ExtendedTreeNode liveVideoInputsNode = new ExtendedTreeNode();
							liveVideoInputsNode.m_mainForm = this;
							liveVideoInputsNode.Text = "Video Inputs";
							deviceTreeNode.Nodes.Add(liveVideoInputsNode);

							int i = 1;
							foreach (Bosch.VideoSDK.Live.VideoInput vi in deviceProxy.VideoInputs)
							{
								VideoInputNode liveVideoInputNode = new VideoInputNode();
								liveVideoInputNode.m_mainForm = this;
								liveVideoInputNode.SetVideoInput(vi, i);
								liveVideoInputsNode.Nodes.Add(liveVideoInputNode);
								i++;
							}
							
							// Add live video outputs.
							ExtendedTreeNode liveVideoOutputsNode = new ExtendedTreeNode();
							liveVideoOutputsNode.m_mainForm = this;
							liveVideoOutputsNode.Text = "Video Outputs";
							deviceTreeNode.Nodes.Add(liveVideoOutputsNode);

							foreach (Bosch.VideoSDK.Live.VideoOutput vo in deviceProxy.VideoOutputs)
							{
								VideoOutputNode liveVideoOutputNode = new VideoOutputNode();
								liveVideoOutputNode.m_mainForm = this;
								liveVideoOutputNode.SetVideoOutput(vo);
								liveVideoOutputsNode.Nodes.Add(liveVideoOutputNode);
							}
							
							// Add live audio inputs.
							ExtendedTreeNode liveAudioInputsNode = new ExtendedTreeNode();
							liveAudioInputsNode.m_mainForm = this;
							liveAudioInputsNode.Text = "Audio Inputs";
							deviceTreeNode.Nodes.Add(liveAudioInputsNode);
							
							foreach (Bosch.VideoSDK.Live.AudioInput ai in deviceProxy.AudioInputs)
							{
								AudioInputNode liveAudioInputNode = new AudioInputNode();
								liveAudioInputNode.m_mainForm = this;
								liveAudioInputNode.SetAudioInput(ai);
								liveAudioInputsNode.Nodes.Add(liveAudioInputNode);
							}

							// Add live audio outputs.
							ExtendedTreeNode liveAudioOutputsNode = new ExtendedTreeNode();
							liveAudioOutputsNode.m_mainForm = this;
							liveAudioOutputsNode.Text = "Audio Outputs";
							deviceTreeNode.Nodes.Add(liveAudioOutputsNode);

							foreach (Bosch.VideoSDK.Live.AudioOutput ao in deviceProxy.AudioOutputs)
							{
								AudioOutputNode liveAudioOutputNode = new AudioOutputNode();
								liveAudioOutputNode.m_mainForm = this;
								liveAudioOutputNode.SetAudioOutput(ao);
								liveAudioOutputsNode.Nodes.Add(liveAudioOutputNode);
							}

							// Add relays.
							ExtendedTreeNode relaysNode = new ExtendedTreeNode();
							relaysNode.m_mainForm = this;
							relaysNode.Text = "Relays";
							deviceTreeNode.Nodes.Add(relaysNode);

							foreach (Bosch.VideoSDK.Live.Relay relay in deviceProxy.Relays)
							{
								RelayNode relayNode = new RelayNode();
								relayNode.m_mainForm = this;
								relayNode.SetRelay(relay);
								relaysNode.Nodes.Add(relayNode);
							}

							// Add alarm inputs.
							ExtendedTreeNode alarmInputsNode = new ExtendedTreeNode();
							alarmInputsNode.m_mainForm = this;
							alarmInputsNode.Text = "Alarm Inputs";
							deviceTreeNode.Nodes.Add(alarmInputsNode);

							foreach (Bosch.VideoSDK.Live.AlarmInput ai in deviceProxy.AlarmInputs)
							{
								AlarmInputNode aiNode = new AlarmInputNode();
								aiNode.m_mainForm = this;
								aiNode.SetAlarmInput(ai);
								alarmInputsNode.Nodes.Add(aiNode);
							}
						}
					}

					break;
			
				case Bosch.VideoSDK.Device.ConnectResultEnum.creConnectionFailure:
					ErrorMessage("MainForm", "OnConnectResult", "Error connecting to " + url + ".", false);
					break;

				case Bosch.VideoSDK.Device.ConnectResultEnum.creConnectionUnavailable:
					ErrorMessage("MainForm", "OnConnectResult", "Connection to " + url + " unavailable.", false);
					break;

				case Bosch.VideoSDK.Device.ConnectResultEnum.creIncompatibleDevice:
					ErrorMessage("MainForm", "OnConnectResult", "Device at " + url + " is not compatible with Video SDK.", false);
					break;

				case Bosch.VideoSDK.Device.ConnectResultEnum.creInvalidCredentials:
					ErrorMessage("MainForm", "OnConnectResult", "Invalid username/password for " + url + ".", false);
					break;

				case Bosch.VideoSDK.Device.ConnectResultEnum.creTimedOut:
					ErrorMessage("MainForm", "OnConnectResult", "Connection to " + url + " timed out.", false);
					break;

				default:
					ErrorMessage("MainForm", "OnConnectResult", "Error <" + result.ToString() + "> connecting to " + url + ".", false);
					break;
			}
		}

		private void DisconnectFromDevice(DeviceTreeNode node)
		{
			if (node.m_bConnected)
			{
				try
				{
					node.Disconnect();
					LogMessage("MainForm", "DisconnectFromDevice", "Disconnected from " + node.m_deviceUrl + ".");
				}
				catch (Exception e)
				{
					ErrorMessage("MainForm", "DisconnectFromDevice",
						"Error trying to disconnect from " + node.m_deviceAddress + ". " + e.Message, false);
				}
			}
		}

		private void m_treeContextMenuConnect_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_treeContextMenuConnect_Click", m_treeContextMenuConnect.Text + ": " + m_deviceTree.SelectedNode.Text);

			if (m_deviceTree.SelectedNode is DeviceTreeNode)
			{
				DeviceTreeNode node = (DeviceTreeNode)m_deviceTree.SelectedNode;

				if (node.m_bConnected)
					DisconnectFromDevice(node);
				else
					ConnectToDevice(node);
			}
		}

		private void m_treeContextMenuProperties_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_treeContextMenuProperties_Click", m_treeContextMenuProperties.Text);

			if (m_deviceTree.SelectedNode is DeviceTreeNode)
			{
				DevicePropertiesForm propsForm = new DevicePropertiesForm((DeviceTreeNode)m_deviceTree.SelectedNode);
				propsForm.Show();
			}
		}

		private void m_fileSaveMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_fileSaveMenuItem_Click", m_fileSaveMenuItem.Text);

			DialogResult buttonClicked = m_saveFileDialog.ShowDialog();
			if (buttonClicked.Equals(DialogResult.OK))
			{
				SaveFile(m_saveFileDialog.FileName);
			}
		}

		private void m_fileOpenMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_fileOpenMenuItem_Click", m_fileOpenMenuItem.Text);

			m_openFileDialog.Filter = "Device Tree Files|*.xml|All files|*.*";
			m_openFileDialog.Title = "Advanced Video SDK C# Sample - Open Device Tree";
			DialogResult buttonClicked = m_openFileDialog.ShowDialog();
			if (buttonClicked.Equals(DialogResult.OK))
			{
				m_deviceTree.Nodes.Clear();
				OpenFile(m_openFileDialog.FileName);
			}
		}

		private void SaveFile(string filename)
		{
			DeviceTreeNode deviceTreeNode = null;
			XmlDocument treeXmlDoc = new XmlDocument();
			treeXmlDoc.LoadXml("<m_deviceTree/>");

			foreach (TreeNode treeNode in m_deviceTree.Nodes)
			{
				if (treeNode is DeviceTreeNode)
				{
					deviceTreeNode = (DeviceTreeNode)treeNode;

					XmlNode newNode;
					newNode = treeXmlDoc.CreateNode(XmlNodeType.Element, "device", "");

					XmlElement newElem;
					newElem = treeXmlDoc.CreateElement("name");
					newElem.InnerText = deviceTreeNode.m_deviceName;
					newNode.AppendChild(newElem);

					newElem = treeXmlDoc.CreateElement("protocol");
					newElem.InnerText = deviceTreeNode.m_deviceProtocol;
					newNode.AppendChild(newElem);

					newElem = treeXmlDoc.CreateElement("address");
					newElem.InnerText = deviceTreeNode.m_deviceAddress;
					newNode.AppendChild(newElem);

					newElem = treeXmlDoc.CreateElement("description");
					newElem.InnerText = deviceTreeNode.m_deviceDescription;
					newNode.AppendChild(newElem);

					newElem = treeXmlDoc.CreateElement("username");
					newElem.InnerText = deviceTreeNode.m_username;
					newNode.AppendChild(newElem);

					newElem = treeXmlDoc.CreateElement("password");
					newElem.InnerText = deviceTreeNode.m_password;
					newNode.AppendChild(newElem);

					newElem = treeXmlDoc.CreateElement("progID");
					newElem.InnerText = deviceTreeNode.m_progID;
					newNode.AppendChild(newElem);

					treeXmlDoc.DocumentElement.AppendChild(newNode);
				}
			}

			try
			{
				treeXmlDoc.Save(filename);
			}
			catch
			{
				MessageBox.Show("Error saving device tree", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void OpenFile(string filename)
		{
			XmlDocument treeXmlDoc = new XmlDocument();
			
			try
			{
				treeXmlDoc.Load(filename);

				foreach (XmlNode xmlNode in treeXmlDoc.ChildNodes)
				{
					if (xmlNode.Name == "m_deviceTree")
					{
						foreach (XmlNode childNode in xmlNode.ChildNodes)
						{
							string sProtocol = "";
							try 
							{ 
								sProtocol = childNode["protocol"].InnerText;
							}
							catch 
							{
							}
							AddDevice(
								childNode["name"].InnerText
								,sProtocol
								,childNode["address"].InnerText
								,childNode["description"].InnerText
								,childNode["username"].InnerText
								,childNode["password"].InnerText
								,childNode["progID"].InnerText
								);
						}
					}
				}
			}
			catch
			{
				// File not found.
			}
		}

		private void m_actionsConnectAllMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_actionsConnectAllMenuItem_Click", m_actionsConnectAllMenuItem.Text);

			foreach (TreeNode treeNode in m_deviceTree.Nodes)
			{
				DeviceTreeNode deviceTreeNode = treeNode as DeviceTreeNode;
				if (deviceTreeNode != null)
					ConnectToDevice(deviceTreeNode);
			}
		}

		private void m_actionsDisconnectAllMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_actionsDisconnectAllMenuItem_Click", m_actionsDisconnectAllMenuItem.Text);

			m_sequenceTimer.Stop();

			foreach (TreeNode treeNode in m_deviceTree.Nodes)
			{
				DeviceTreeNode deviceTreeNode = treeNode as DeviceTreeNode;
				if (deviceTreeNode != null)
					DisconnectFromDevice(deviceTreeNode);
			}
		}
	
		protected override void OnResize(EventArgs e)
		{
			ArrangeControls();
			base.OnResize (e);
		}
	
		protected override void OnActivated(EventArgs e)
		{
			ArrangeControls();
			base.OnActivated (e);
		}

		private void m_deviceTree_MouseDown(object sender, MouseEventArgs e)
		{
			// Make sure the correct menu and node are selected when the mouse buttons are pressed.
			TreeNode node = m_deviceTree.GetNodeAt(e.X, e.Y);

			if (node != null)
			{
				if (node is DeviceTreeNode)
				{
					DeviceTreeNode dtnode = (DeviceTreeNode)node;
					m_deviceTree.ContextMenu = m_deviceTreeMenu;

					if (dtnode.m_bConnected)
						m_treeContextMenuConnect.Text = "Disconnect";
					else
						m_treeContextMenuConnect.Text = "Connect";
				}
				else if (node is VideoInputNode)
				{
					m_deviceTree.ContextMenu = m_videoInputContextMenu;
				}
				else if (node is VideoOutputNode)
				{
					m_deviceTree.ContextMenu = m_videoOutputContextMenu;
				}
				else if (node is AudioInputNode)
				{
					m_deviceTree.ContextMenu = m_audioInputContextMenu;
				}
				else if (node is RelayNode)
				{
					RelayNode rnode = (RelayNode)node;
					rnode.ToggleState();
				}
				else if (node is MediaFileNode)
				{
					m_deviceTree.ContextMenu = m_mediaFileContextMenu;
				}
				else if (node is AudioOutputNode)
				{
					AudioOutputNode anode = (AudioOutputNode)node;

					m_deviceTree.ContextMenu = m_avOutputContextMenu;

					if (anode.m_bConnected)
						m_sendAudioMenuItem.Text = "Stop Audio";
					else
						m_sendAudioMenuItem.Text = "Send Audio";
				}
				else
				{
					m_deviceTree.ContextMenu = null;
				}

				m_deviceTree.SelectedNode = node;
			}
			else
			{
				m_deviceTree.ContextMenu = null;
			}
		}

		private void m_deviceTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			LogUserMessage("MainForm", "m_deviceTree_AfterSelect", "User selected tree node: " + m_deviceTree.SelectedNode.Text);
			
			// If the selected node is a video or audio input, then start rendering it's stream.
			if (m_deviceTree.SelectedNode is AudioInputNode)
			{
				AudioInputNode node = (AudioInputNode)m_deviceTree.SelectedNode;
				DeviceTreeNode deviceNode = (DeviceTreeNode)node.Parent.Parent;

				// Set the audio stream's coding and lip sync properties.
				if (deviceNode.m_liveVideoPropertiesChanged)
				{
					try
					{
						node.m_audioInput.Stream.Coding = deviceNode.m_coding;
						node.m_audioInput.Stream.Protocol = deviceNode.m_Protocol;
						node.m_audioInput.Stream.EnableLipSync = m_lipSyncMenuItem.Checked;
					}
					catch
					{
						ErrorMessage("MainForm", "m_deviceTree_AfterSelect", "Error setting audio stream properties", true);
					}
				}

				try
				{
					// Save the running audio streams so they can be shut off later.
					m_audioStreams.Push(node.m_audioInput.Stream);

					// AddStream will start playing the audio.
					m_audioReceiver.AddStream(node.m_audioInput.Stream);
				}
				catch
				{
					ErrorMessage("MainForm", "m_deviceTree_AfterSelect",
						"Error assigning audio stream to audio receiver", false);
				}
			}
			else if (m_deviceTree.SelectedNode is VideoInputNode)
			{	
				VideoInputNode node = (VideoInputNode)m_deviceTree.SelectedNode;
				DeviceTreeNode deviceNode = (DeviceTreeNode)node.Parent.Parent;

				// Set the video stream's multicast, encoder, and coding properties.
				if (deviceNode.m_liveVideoPropertiesChanged)
				{
					try
					{
						node.m_videoInput.Stream.Protocol = deviceNode.m_Protocol;
					}
					catch
					{
						ErrorMessage("MainForm", "m_deviceTree_AfterSelect", "Error setting video stream properties (Protocol)", true);
					}

					try
					{
						node.m_videoInput.Stream.Multicast = deviceNode.m_multicast;
					}
					catch
					{
						ErrorMessage("MainForm", "m_deviceTree_AfterSelect", "Error setting video stream properties (Multicast)", true);
					}

					try
					{
						node.m_videoInput.Stream.Encoder = deviceNode.m_encoder;
					}
					catch
					{
						ErrorMessage("MainForm", "m_deviceTree_AfterSelect", "Error setting video stream properties (Encoder)", true);
					}

					try
					{
						node.m_videoInput.Stream.Coding = deviceNode.m_coding;
					}
					
					catch
					{
						ErrorMessage("MainForm", "m_deviceTree_AfterSelect", "Error setting video stream properties (Coding)", true);
					}
				}

				// Play the video.
				AssignNextCameo(node.m_videoInput.Stream);
			}
			
		}		
	
		protected override void OnClosing(CancelEventArgs e)
		{
			LogUserMessage("MainForm", "OnClosing", "Closing Advanced C# Sample");
			m_sequenceTimer.Stop();
			m_controllers.Clear();
			base.OnClosing (e);
		}

		private void m_treeContextMenuCameraController_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_treeContextMenuCameraController_Click",
				m_treeContextMenuCameraController.Text);

			if (m_deviceTree.SelectedNode is DeviceTreeNode)
			{
				DeviceTreeNode node = (DeviceTreeNode)m_deviceTree.SelectedNode;
				Bosch.VideoSDK.Device.DeviceProxy deviceProxy = node.GetDeviceProxy();

				if (deviceProxy != null)
				{
					try
					{
						Bosch.VideoSDK.Live.CameraController cc = (Bosch.VideoSDK.Live.CameraController)deviceProxy.VideoInputs[1].CameraController;

						if (cc != null)
						{
							CameraControllerForm ccForm = new CameraControllerForm(cc, this);
							ccForm.Show();
						}
					}	
					catch
					{
						ErrorMessage("MainForm", "m_treeContextMenuCameraController_Click",
							"This device does not support ICameraController", true);
					}
				}
			}
		}

		private void m_useProgIDMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_useProgIDMenuItem_Click", m_useProgIDMenuItem.Text);

			m_useProgIDMenuItem.Checked = !m_useProgIDMenuItem.Checked;
		}

		private void m_useAsyncConnectMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_useAsyncConnectMenuItem_Click", m_useAsyncConnectMenuItem.Text);

			m_useAsyncConnectMenuItem.Checked = !m_useAsyncConnectMenuItem.Checked;
		}

		private void m_cycleCameosMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_cycleCameosMenuItem_Click", m_cycleCameosMenuItem.Text);

			m_cycleCameosMenuItem.Checked = !m_cycleCameosMenuItem.Checked;
		}

		private void m_useVMR9MenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_useVMR9MenuItem_Click", m_useVMR9MenuItem.Text);

			m_useVMR9MenuItem.Checked = !m_useVMR9MenuItem.Checked;

			SetUseVMR9(m_useVMR9MenuItem.Checked);
		}

		private void m_enableRendererFallbackMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_enableRendererFallbackMenuItem_Click", m_enableRendererFallbackMenuItem.Text);

			m_enableRendererFallbackMenuItem.Checked = !m_enableRendererFallbackMenuItem.Checked;

			SetEnableRendererFallback(m_enableRendererFallbackMenuItem.Checked);
		}

		private void m_treeContextMenuLiveProperties_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_treeContextMenuLiveProperties_Click",
				m_treeContextMenuLiveProperties.Text);

			if (m_deviceTree.SelectedNode is DeviceTreeNode)
			{
				LiveVideoProperties propsForm = new LiveVideoProperties((DeviceTreeNode)m_deviceTree.SelectedNode);
				propsForm.Show();
			}

		}

		private void m_restoreWindowMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_restoreWindowMenuItem_Click", m_restoreWindowMenuItem.Text);

			this.Size = m_defaultWindowSize;
		}

		private void m_stopAudioMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_stopAudioMenuItem_Click", m_stopAudioMenuItem.Text);

			try
			{
				while (m_audioStreams.Count > 0)
					m_audioReceiver.RemoveStream((m_audioStreams.Pop()));
			}
			catch
			{
				ErrorMessage("MainForm", "m_stopAudioMenuItem_Click",
					"Error removing stream from m_audioReceiver.", true);
			}
		}

		private void OnCameoMouseAction(object sender, Bosch.VideoSDK.AxCameoLib._ICameoEvents_MouseActionEvent e)
		{
			Bosch.VideoSDK.AxCameoLib.AxCameo cameo = (Bosch.VideoSDK.AxCameoLib.AxCameo)sender;

			if (e.evt == Bosch.VideoSDK.CameoLib.MouseEventEnum.meeLButtonDown && m_activeCameo != cameo)
			{
				if (m_activeCameo != null)
				{
					m_activeCameo.Active = false;
					m_activeCameo.EnableOverlay = false;
				}


				m_activeCameo = cameo;
				m_activeCameo.Active = true;
				m_activeCameo.EnableOverlay = true;


				for (int i = 0; i < m_cameoArray.Length; i++)
				{
					if (m_activeCameo == m_cameoArray[i])
					{
						m_currentCameoIndex = i;
					}
				}

				// Turn off pre-increment because a new cameo was selected.
				m_bPreIncrementCameo = false;
			}

			// Only log infrequent mouse events.
			if (e.evt != Bosch.VideoSDK.CameoLib.MouseEventEnum.meeMouseMove)
				LogMessage("MainForm", "OnCameoMouseAction", e.evt.ToString() + " (wParam: "  + e.wParam + ", lParam: " + e.lParam + ")");
		}

		private void OnCameoVideoStatus(object sender, Bosch.VideoSDK.AxCameoLib._ICameoEvents_VideoStatusEvent e)
		{
			string msg = "Cameo VideoStatus: " + e.status.ToString();

			m_lbMessages.Items.Add(DateTime.Now.ToString() + " " + msg);
			m_lbMessages.SelectedIndex = m_lbMessages.Items.Count - 1;
		}

		private void m_treeContextMenuMediaDatabase_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_treeContextMenuMediaDatabase_Click",
				m_treeContextMenuMediaDatabase.Text);

			if (m_deviceTree.SelectedNode is DeviceTreeNode)
			{
				DeviceTreeNode node = (DeviceTreeNode)m_deviceTree.SelectedNode;
				Bosch.VideoSDK.Device.DeviceProxy deviceProxy = node.GetDeviceProxy();

				if (deviceProxy != null)
				{
					Bosch.VideoSDK.MediaDatabase.MediaDatabase mdb = (Bosch.VideoSDK.MediaDatabase.MediaDatabase)deviceProxy.MediaDatabase;

					if (mdb != null)
					{
						MediaDatabaseForm newMediaDatabaseForm = new MediaDatabaseForm(mdb, node.Text, this);
						newMediaDatabaseForm.Show();
					}
					else
					{
						MessageBox.Show("This device does not support a media database.",
										"Error",
										MessageBoxButtons.OK,
										MessageBoxIcon.Information);
					}
				}
			}
		}

		public void AddStreamToMediaWriter(
			Bosch.VideoSDK.MediaTypeEnum mediaType,
			Bosch.VideoSDK.DataStream stream,
			string url)
		{
			try
			{
				string trackName = "";
				int trackID = 0;

				if (mediaType == Bosch.VideoSDK.MediaTypeEnum.mteVideo)
					trackID = m_mediaFileVideoTrackID++;
				else
					trackID = m_mediaFileAudioTrackID++;

				trackName = "Sample Track " + trackID.ToString();

				m_mediaFileWriter.AddStream(
					stream,
					mediaType,
					trackID,
					trackName,
					url,
					0);

				// enable menu item - Start MediaFileWriter Recording
				m_startRecordingMenuItem.Enabled = true;
			}
			catch
			{
				ErrorMessage("MainForm", "m_addMediaFileMenuItem_Click",
					"Error adding stream to m_mediaFileWriter.", true);
			}
		}

		private void m_addMediaFileMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_addMediaFileMenuItem_Click",
				m_addMediaFileMenuItem.Text);

			Bosch.VideoSDK.DataStream stream = null;
			Bosch.VideoSDK.MediaTypeEnum mediaType = Bosch.VideoSDK.MediaTypeEnum.mteVideo;

			if (m_deviceTree.SelectedNode is VideoInputNode)
			{
				VideoInputNode node = (VideoInputNode)m_deviceTree.SelectedNode;
				stream = node.m_videoInput.Stream;
				mediaType = Bosch.VideoSDK.MediaTypeEnum.mteVideo;
			}
			else if (m_deviceTree.SelectedNode is AudioInputNode)
			{
				AudioInputNode node = (AudioInputNode)m_deviceTree.SelectedNode;
				stream = node.m_audioInput.Stream;
				mediaType = Bosch.VideoSDK.MediaTypeEnum.mteAudio;
			}

			string url = "";

			if (m_deviceTree.SelectedNode.Parent.Parent is DeviceTreeNode)
			{
				DeviceTreeNode deviceNode = (DeviceTreeNode)m_deviceTree.SelectedNode.Parent.Parent;
				url = deviceNode.m_deviceUrl;
			}

			AddStreamToMediaWriter(mediaType, stream, url);
		}

		private void m_videoOutputMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_videoOutputMenuItem_Click",
				m_videoOutputMenuItem.Text);

			if (m_deviceTree.SelectedNode is VideoOutputNode)
			{
				VideoOutputNode node = (VideoOutputNode)m_deviceTree.SelectedNode;
				string url = "Unknown";

				if (node.Parent.Parent is DeviceTreeNode)
				{
					DeviceTreeNode deviceNode = (DeviceTreeNode)node.Parent.Parent;
					url = deviceNode.m_deviceUrl;
				}

				VideoOutputForm newVideoOutputForm = new VideoOutputForm(node.m_videoOutput, this);
				newVideoOutputForm.Show();
			}
		}

		private void m_startRecordingMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_startRecordingMenuItem_Click",
				m_startRecordingMenuItem.Text);

			// Depending on the state, start or stop recording.
			if (m_startRecordingMenuItem.Text == "Start MediaFileWriter Recording")
			{
				StartRecordingForm startForm = new StartRecordingForm();

				startForm.m_fileSizeTextBox.Text = m_mediaFileWriter.FileSizeLimitKB.ToString();
				startForm.m_filenameTextBox.Text = "testMediaFile";
				startForm.m_fileCommentTextBox.Text = "This is a Video SDK demo media file, created on " + 
					DateTime.Now.ToShortDateString() + " at " +
					DateTime.Now.ToShortTimeString() + ".";

				startForm.ShowDialog();

				if (!startForm.m_bCancel)
				{
					try
					{
						m_mediaFileWriter.FileSizeLimitKB = int.Parse(startForm.m_fileSizeTextBox.Text);
						m_mediaFileWriter.FileFormat = startForm.m_format;
						m_mediaFileWriter.StartRecording(startForm.m_filenameTextBox.Text, startForm.m_fileCommentTextBox.Text);
						m_startRecordingMenuItem.Text = "Stop MediaFileWriter Recording";
					}
					catch
					{
						ErrorMessage("MainForm", "m_stopRecordingMenuItem_Click",
							"Error calling m_mediaFileWriter.StartRecording for " + startForm.m_filenameTextBox.Text + ".", true);
					}
				}
			}
			else
			{
				try
				{
					m_mediaFileWriter.StopRecording();
				}
				catch
				{
					ErrorMessage("MainForm", "m_stopRecordingMenuItem_Click",
						"Error calling m_mediaFileWriter.StopRecording.", true);
				}
			}
		}

		public void AssignNextCameo(Bosch.VideoSDK.DataStream dataStream)
		{
			// If the menu option is checked, advance to the next cameo.
					
			if (m_cycleCameosMenuItem.Checked)
			{
				if (m_bPreIncrementCameo)
				{
					do
					{
						m_currentCameoIndex++;

						if (m_currentCameoIndex >= m_cameoArray.Length)
						{
							m_currentCameoIndex = 0;
						}
					} while (m_currentCameoIndex != 0 &&
						m_cameoArray[m_currentCameoIndex].Visible == false);

					Bosch.VideoSDK.AxCameoLib.AxCameo cameo = m_cameoArray[m_currentCameoIndex];
					
					if (m_activeCameo != cameo)
					{
						if (m_activeCameo != null)
						{
							m_activeCameo.Active = false;
							m_activeCameo.EnableOverlay = false;
						}

						m_activeCameo = cameo;
					}
				}
			}
					
			if (m_activeCameo == null)
			{
				m_activeCameo = m_cameoArray[m_currentCameoIndex];
			}

			try
			{
				m_activeCameo.Active = true;
				m_activeCameo.EnableOverlay = true;
				m_activeCameo.SetVideoStream(dataStream);
			}
			catch (COMException ex)
			{
				ErrorMessage("MainForm", "AssignNextCameo", "Error " + String.Format("{0:x}", ex.ErrorCode) + ": " + ex.Message, false);
			}

			// Only pre-increment the cameo after one has been assigned already.
			m_bPreIncrementCameo = true;
		}

		private Bosch.VideoSDK.Live.VideoInput FindNextVideoInput(ref int deviceIndex, ref int videoInputIndex)
		{
			Bosch.VideoSDK.Live.VideoInput foundVideoInput = null;
			DeviceTreeNode deviceNode = null;
			int numDevicesChecked = 0;
			
			// Loop through all device nodes until we either find the next video input or
			// until we have checked all devices and found no video inputs.
			while (foundVideoInput == null && numDevicesChecked <= m_deviceTree.GetNodeCount(false))
			{
				if (m_deviceTree.Nodes[deviceIndex] is DeviceTreeNode)
				{
					deviceNode = (DeviceTreeNode)m_deviceTree.Nodes[deviceIndex];

					// Check if there is another video input on the current device.
					if (deviceNode.m_bConnected)
					{
						// Advance to the next video input.  This modifies the reference parameter.
						videoInputIndex++;
						if (videoInputIndex <= deviceNode.GetDeviceProxy().VideoInputs.Count)
						{
							// Found the next video input.
							foundVideoInput = deviceNode.GetDeviceProxy().VideoInputs[videoInputIndex];
						}
					}
				}
				
				// If no more inputs on current device or device not connected, advance to the next device in the tree.
				if (foundVideoInput == null)
				{
					// Advance to the next device.  This modifies the reference parameter.
					deviceIndex++;
					
					if (deviceIndex >= m_deviceTree.Nodes.Count)
						deviceIndex = 0;

					// Reset the video input index.  This modifies the reference parameter.
					videoInputIndex = 0;
				}

				numDevicesChecked++;
			}  // end whwile
			
			return foundVideoInput;
		}

		private void AdvanceSequence()
		{
			Bosch.VideoSDK.Live.VideoInput nextVideoInput = null;

			nextVideoInput = FindNextVideoInput(ref m_seqDeviceIndex, ref m_seqVideoInputIndex);

			if (nextVideoInput != null)
				AssignNextCameo(nextVideoInput.Stream);
		}

		private void m_seqMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_seqMenuItem_Click",
				m_seqMenuItem.Text);

			if (!m_sequenceTimer.Enabled)
			{
				if (this.m_deviceTree.Nodes.Count > 0)
				{
					//start sequences instantly
					m_sequenceTimer_Elapsed(null, null);
					m_sequenceTimer.Start();
					m_seqMenuItem.Text = "Stop Sequence";
				}
			}
			else
			{
				m_sequenceTimer.Stop();
				m_seqMenuItem.Text = "Sequence Connected Video Inputs";
			}
		}

		private void m_sequenceTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			for(int i = 0; i < m_rows * m_cols; i++)
			{
				AdvanceSequence();
			}
		}

		private void m_openPlaybackMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_openPlaybackMenuItem_Click", m_openPlaybackMenuItem.Text);

			// Create the form and show it.
			if (m_openPlaybackMenuItem.Enabled == true)
			{
				PlaybackControllersForm playbackControllersForm = new PlaybackControllersForm(this);
				playbackControllersForm.Show();
				
				m_openPlaybackMenuItem.Enabled = false;
			}
		}

		public Bosch.VideoSDK.MediaDatabase.PlaybackControllerClass CreateNewController()
		{
			Bosch.VideoSDK.MediaDatabase.PlaybackControllerClass pc = new Bosch.VideoSDK.MediaDatabase.PlaybackControllerClass();
			m_controllers.Insert(m_controllers.Count, pc);
			pc.Name = "controller " + m_controllers.Count;
			
			return pc;
		}

		public void PutControllersInListBox(System.Windows.Forms.ListBox lb)
		{
			
			for (int i = 0; i < m_controllers.Count; i++)
			{
				Bosch.VideoSDK.MediaDatabase.PlaybackController pc = (Bosch.VideoSDK.MediaDatabase.PlaybackController)m_controllers[i];
				PlaybackControllerWrapper wrapper = new PlaybackControllerWrapper(pc);
				lb.Items.Add(wrapper);
			}
	
		}

		private void m_fileOpenMediaMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_fileOpenMediaMenuItem_Click", m_fileOpenMediaMenuItem.Text);

			m_openFileDialog.Filter = "Video SDK Media Files|*.vmf|All files|*.*";
			m_openFileDialog.Title = "Advanced Video SDK C# Sample - Open Media File";
			DialogResult buttonClicked = m_openFileDialog.ShowDialog();
			if (buttonClicked.Equals(DialogResult.OK))
			{
				Bosch.VideoSDK.MediaDatabase.MediaFileReader mfr = null;

				try
				{
					mfr = new Bosch.VideoSDK.MediaDatabase.MediaFileReader();
					mfr.OpenFile(m_openFileDialog.FileName);
					MediaFileNode newNode = new MediaFileNode(m_openFileDialog.FileName, mfr);
					newNode.m_mainForm = this;
					m_deviceTree.Nodes.Add(newNode);
				}
				catch
				{
					ErrorMessage("MainForm", "m_fileOpenMediaMenuItem_Click", "Error opening media file", true);
				}				
			}
		}

		private void m_mediaFileContextMenuMediaDatabase_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_mediaFileContextMenuMediaDatabase_Click",
				m_mediaFileContextMenuMediaDatabase.Text);

			if (m_deviceTree.SelectedNode is MediaFileNode)
			{
				MediaFileNode node = (MediaFileNode)m_deviceTree.SelectedNode;
				Bosch.VideoSDK.MediaDatabase.MediaFileReader mfr = node.GetMediaFileReader();

				if (mfr != null)
				{
					Bosch.VideoSDK.MediaDatabase.MediaDatabase mdb = null;
					mdb = (Bosch.VideoSDK.MediaDatabase.MediaDatabase)mfr.GetMediaDatabase();

					if (mdb != null)
					{
						MediaDatabaseForm newMediaDatabaseForm = new MediaDatabaseForm(mdb, node.Text, this);
						newMediaDatabaseForm.Show();
					}		
				}
			}
		}

		private void m_mediaFileContextMenuCloseFile_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_mediaFileContextMenuCloseFile_Click",
				m_mediaFileContextMenuCloseFile.Text);

			// Close the file and remove the node.

			if (m_deviceTree.SelectedNode is MediaFileNode)
			{
				MediaFileNode node = (MediaFileNode)m_deviceTree.SelectedNode;
				Bosch.VideoSDK.MediaDatabase.MediaFileReader mfr = node.GetMediaFileReader();

				if (mfr != null)
				{
					mfr.CloseFile();
				}

				m_deviceTree.Nodes.Remove(m_deviceTree.SelectedNode);
			}
		}

		private void m_displayFileCommentMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_displayFileCommentMenuItem_Click",
				m_displayFileCommentMenuItem.Text);

			if (m_deviceTree.SelectedNode is MediaFileNode)
			{
				MediaFileNode node = (MediaFileNode)m_deviceTree.SelectedNode;
				Bosch.VideoSDK.MediaDatabase.MediaFileReader mfr = node.GetMediaFileReader();

				if (mfr != null)
				{
					MessageBox.Show(this, mfr.FileComment, "Media File Comment");
				}
			}
		}

		private void m_clearCameoAllMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_clearCameoAllMenuItem_Click",
				m_clearCameoAllMenuItem.Text);

			for (int i = 0; i < m_cameoArray.Length; i++)
			{
				if (m_cameoArray[i] != null &&
					m_cameoArray[i].Visible)
					m_cameoArray[i].SetVideoStream(null);
			}
		}

		private void m_clearCameoActiveMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_clearCameoActiveMenuItem_Click",
				m_clearCameoActiveMenuItem.Text);

			if (m_activeCameo != null)
				m_activeCameo.SetVideoStream(null);
		}

		private void m_keepAspectRatioMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_keepAspectRatioMenuItem_Click", m_keepAspectRatioMenuItem.Text);

			m_keepAspectRatioMenuItem.Checked = !m_keepAspectRatioMenuItem.Checked;

			SetKeepAspectRatio(m_keepAspectRatioMenuItem.Checked);
		}

		private void m_snapVideoToWindowMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_snapVideoToWindowMenuItem_Click", m_snapVideoToWindowMenuItem.Text);

			m_snapVideoToWindowMenuItem.Checked = !m_snapVideoToWindowMenuItem.Checked;

			SetSnapVideoToWindow(m_snapVideoToWindowMenuItem.Checked);
		}

		private void m_sendAudioMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_sendAudioMenuItem_Click", m_sendAudioMenuItem.Text);

			if (m_deviceTree.SelectedNode is AudioOutputNode)
			{
				AudioOutputNode node = (AudioOutputNode)m_deviceTree.SelectedNode;

				if (!node.m_bConnected)
				{
					try
					{
						node.m_audioOutput.SetStream(m_audioSource.Stream);
						node.m_bConnected = true;
						m_sendAudioMenuItem.Text = "Stop Audio";
					}
					catch
					{
						ErrorMessage("MainForm", "m_sendAudioMenuItem_Click", "Error starting audio stream to the device.", true);
					}
				}
				else
				{
					try
					{
						node.m_audioOutput.SetStream(null);
						node.m_bConnected = false;
						m_sendAudioMenuItem.Text = "Send Audio";
					}
					catch
					{
						ErrorMessage("MainForm", "m_sendAudioMenuItem_Click", "Error stopping audio stream to the device.", true);
					}
				}
				
			}
		}

		private void m_selectAudioMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_selectAudioMenuItem_Click", m_selectAudioMenuItem.Text);

			SelectAudioInputForm newForm = new SelectAudioInputForm(m_audioSource);
			newForm.Show();
		}

		private void SetSelectedNodeVolume(int vol)
		{
			if (m_deviceTree.SelectedNode is AudioInputNode)
			{
				AudioInputNode node = (AudioInputNode)m_deviceTree.SelectedNode;

				try
				{
					node.m_audioInput.Stream.Volume = vol;
				}
				catch
				{
					ErrorMessage("MainForm", "SetSelectedNodeVolume", "Error setting audio volume.", true);
				}
			}
		}

		private void m_volume0MenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_volume0MenuItem_Click", m_volume0MenuItem.Text);
			SetSelectedNodeVolume(0);
		}

		private void m_volume25MenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_volume25MenuItem_Click", m_volume25MenuItem.Text);
			SetSelectedNodeVolume(25);
		}

		private void m_volume50MenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_volume50MenuItem_Click", m_volume50MenuItem.Text);
			SetSelectedNodeVolume(50);
		}

		private void m_volume75MenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_volume75MenuItem_Click", m_volume75MenuItem.Text);
			SetSelectedNodeVolume(75);
		}

		private void m_volume100MenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_volume100MenuItem_Click", m_volume100MenuItem.Text);
			SetSelectedNodeVolume(100);
		}

		private void m_dzMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_dzMenuItem_Click", m_dzMenuItem.Text);
			DigitalZoomForm form = new DigitalZoomForm(this);
			form.Show();
		}

		private void m_runGCMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_runGCMenuItem_Click", m_runGCMenuItem.Text + " START");
			GC.Collect();
			GC.WaitForPendingFinalizers();
			LogUserMessage("MainForm", "m_runGCMenuItem_Click", m_runGCMenuItem.Text + " END");
		}

		private void m_runCdTestMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_runCdTestMenuItem_Click", m_runCdTestMenuItem.Text);

			if (!m_cdTestRunning)
			{
				m_cdTimer.Start();
				m_runCdTestMenuItem.Text = "Stop Connect and Disconnect Test";
				m_cdTestRunning = true;
			}
			else
			{
				m_cdTimer.Stop();
				m_runCdTestMenuItem.Text = "Run Connect and Disconnect Test";
				m_cdTestRunning = false;
			}
		}

		private void m_cdTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			if (!m_cdTestConnected)
			{
				LogMessage("MainForm", "m_cdTimer_Elapsed", "Connecting all devices");

				m_actionsConnectAllMenuItem.PerformClick();
				m_cdTestConnected = true;
			}
			else
			{
				LogMessage("MainForm", "m_cdTimer_Elapsed", "Disconnecting all devices");

				m_actionsDisconnectAllMenuItem.PerformClick();
				m_cdTestConnected = false;
			}
		}

		private void m_runCmtMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_runCmtMenuItem_Click", m_runCmtMenuItem.Text);

			if (!m_cmtTestRunning)
			{
				m_cmtMinutesElapsed = 0;
				DoCmt();
				m_cmtTimer.Start();
				m_runCmtMenuItem.Text = "Stop Stability Test";
				m_cmtTestRunning = true;
			}
			else
			{
				m_cmtTimer.Stop();
				m_runCmtMenuItem.Text = "Run Stability Test";
				m_cmtTestRunning = false;
			}
		}

		private void DoCmt()
		{
			switch (m_cmtMinutesElapsed)
			{
				case 0:
					LogMessage("MainForm", "DoCmt", "Min: " + m_cmtMinutesElapsed + " Starting CD test.");
					m_runCdTestMenuItem.PerformClick();
					break;
				case 120:
					LogMessage("MainForm", "DoCmt", "Min: " + m_cmtMinutesElapsed + " Stopping CD test.");
					m_runCdTestMenuItem.PerformClick();
					break;
				case 121:
					LogMessage("MainForm", "DoCmt", "Min: " + m_cmtMinutesElapsed + " Disconnect all devices.");
					m_actionsDisconnectAllMenuItem.PerformClick();
					break;
				case 239:
					LogMessage("MainForm", "DoCmt", "Min: " + m_cmtMinutesElapsed + " Connect all devices for SEQ test.");
					m_actionsConnectAllMenuItem.PerformClick();
					break;
				case 240:
					LogMessage("MainForm", "DoCmt", "Min: " + m_cmtMinutesElapsed + " Starting SEQ test.");
					m_seqMenuItem.PerformClick();
					break;
				case 360:
					LogMessage("MainForm", "DoCmt", "Min: " + m_cmtMinutesElapsed + " Stopping SEQ test.");
					m_seqMenuItem.PerformClick();
					break;
				case 361:
					LogMessage("MainForm", "DoCmt", "Min: " + m_cmtMinutesElapsed + " Test complete - disconnect all devices.");
					m_actionsDisconnectAllMenuItem.PerformClick();

					m_cmtTimer.Stop();
					m_runCmtMenuItem.Text = "Run Comprehensive Memory Test";
					m_cmtTestRunning = false;
					break;
				default:
					LogMessage("MainForm", "DoCmt", "Min: " + m_cmtMinutesElapsed);
					break;
			}
		}

		private void m_cmtTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			m_cmtMinutesElapsed++;
			DoCmt();
		}

		private void m_logLevel0MenuItem_Click(object sender, System.EventArgs e)
		{
			m_sdkLogfile.LoggingLevel = 1;

			LogUserMessage(
				"MainForm", 
				"m_logLevel0MenuItem_Click",
				m_logLevel0MenuItem.Text);

			m_sdkLogfile.LoggingLevel = 0;

			m_logLevel0MenuItem.Checked = true;
			m_logLevel1MenuItem.Checked = false;
			m_logLevel2MenuItem.Checked = false;
			m_logLevel3MenuItem.Checked = false;
		}

		private void m_logLevel1MenuItem_Click(object sender, System.EventArgs e)
		{
			m_sdkLogfile.LoggingLevel = 1;
			
			LogUserMessage(
				"MainForm", 
				"m_logLevel1MenuItem_Click",
				m_logLevel1MenuItem.Text);
			
			m_logLevel0MenuItem.Checked = false;
			m_logLevel1MenuItem.Checked = true;
			m_logLevel2MenuItem.Checked = false;
			m_logLevel3MenuItem.Checked = false;
		}

		private void m_logLevel2MenuItem_Click(object sender, System.EventArgs e)
		{
			m_sdkLogfile.LoggingLevel = 2;

			LogUserMessage(
				"MainForm", 
				"m_logLevel2MenuItem_Click",
				m_logLevel2MenuItem.Text);

			m_logLevel0MenuItem.Checked = false;
			m_logLevel1MenuItem.Checked = false;
			m_logLevel2MenuItem.Checked = true;
			m_logLevel3MenuItem.Checked = false;
		}

		private void m_logLevel3MenuItem_Click(object sender, System.EventArgs e)
		{
			m_sdkLogfile.LoggingLevel = 3;

			LogUserMessage(
				"MainForm", 
				"m_logLevel3MenuItem_Click",
				m_logLevel3MenuItem.Text);

			m_logLevel0MenuItem.Checked = false;
			m_logLevel1MenuItem.Checked = false;
			m_logLevel2MenuItem.Checked = false;
			m_logLevel3MenuItem.Checked = true;
		}

		private void m_lipSyncMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_lipSyncMenuItem_Click", m_lipSyncMenuItem.Text);

			m_lipSyncMenuItem.Checked = !m_lipSyncMenuItem.Checked;
		}

		private void SetEnableCameoContextMenu(bool flag)
		{
			int i = 0;

			if (m_cameoArray != null)
			{
				for (i = 0; i < (m_rows * m_cols); i++)
				{
					m_cameoArray[i].EnableContextMenu = flag;
				}
			}
		}

		private void m_cameoContextMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_cameoContextMenuItem_Click", m_cameoContextMenuItem.Text);
		
			m_cameoContextMenuItem.Checked = !m_cameoContextMenuItem.Checked;

			SetEnableCameoContextMenu(m_cameoContextMenuItem.Checked);
		}

		private void CheckArrangementMenuItems(bool bFlag)
		{
			m_1CameoMenuItem.Checked = bFlag;
			m_4CameosMenuItem.Checked = bFlag;
			m_9CameosMenuItem.Checked = bFlag;
			m_16CameosMenuItem.Checked = bFlag;
			m_25CameosMenuItem.Checked = bFlag;
		}

		private void m_1CameoMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_1CameoMenuItem_Click", m_1CameoMenuItem.Text);

			m_rows = 1;
			m_cols = 1;
			ArrangeControls();
			CheckArrangementMenuItems(false);
			m_1CameoMenuItem.Checked = true;
		}

		private void m_4CameosMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_4CameosMenuItem_Click", m_4CameosMenuItem.Text);

			m_rows = 2;
			m_cols = 2;
			ArrangeControls();
			CheckArrangementMenuItems(false);
			m_4CameosMenuItem.Checked = true;
		}

		private void m_9CameosMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_9CameosMenuItem_Click", m_9CameosMenuItem.Text);
		
			m_rows = 3;
			m_cols = 3;
			ArrangeControls();
			CheckArrangementMenuItems(false);
			m_9CameosMenuItem.Checked = true;
		}

		private void m_16CameosMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_16CameosMenuItem_Click", m_16CameosMenuItem.Text);
		
			m_rows = 4;
			m_cols = 4;
			ArrangeControls();
			CheckArrangementMenuItems(false);
			m_16CameosMenuItem.Checked = true;
		}

		private void m_25CameosMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_25CameosMenuItem_Click", m_25CameosMenuItem.Text);
		
			m_rows = 5;
			m_cols = 5;
			ArrangeControls();
			CheckArrangementMenuItems(false);
			m_25CameosMenuItem.Checked = true;
		}

		private void m_captureSnapshotMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_captureSnapshotMenuItem_Click", m_captureSnapshotMenuItem.Text);

			DialogResult buttonClicked = m_saveCaptureFileDialog.ShowDialog();
			if (buttonClicked.Equals(DialogResult.OK))
			{
				try
				{
					if (1 == m_saveCaptureFileDialog.FilterIndex)
						m_activeCameo.CaptureFormat = Bosch.VideoSDK.CameoLib.ImageFormatEnum.ifeJPEG;
					else
						m_activeCameo.CaptureFormat = Bosch.VideoSDK.CameoLib.ImageFormatEnum.ifeBitmap;

					m_activeCameo.CaptureSingleFrame(m_saveCaptureFileDialog.FileName);
				}
				catch
				{
					ErrorMessage("MainForm", "m_captureSnapshotMenuItem_Click",
						"Error capturing file.", true);
				}
			}
		}
		#region VCA_Config
		public void detachVcaConfigDialog(VcaConfigDialog d) {
			for (int i=0; i<4; i++) 
				if (d == m_vcaConfigDialog[i]) m_vcaConfigDialog[i] = null;
		}
//		private void vc_StateChanged(Bosch.VideoSDK.Live.VcaConfig EventSource, Bosch.VideoSDK.Live.VcaConfigStates State) {
//			if (m_vcaConfigDialog != null) m_vcaConfigDialog[0].setStatus(State.ToString());
//		}
		const int MAX_CAMEO = 25;
		private Bosch.VideoSDK.Live.VcaConfig[] m_vcaConfig = new Bosch.VideoSDK.Live.VcaConfig[MAX_CAMEO];
		private VcaConfigDialog[] m_vcaConfigDialog = new VcaConfigDialog[MAX_CAMEO];
		private void m_actionsVcaConfigMenuItem_Click(object sender, EventArgs e) {
			m_vcaConfig[m_currentCameoIndex] = m_activeCameo.VcaConfig as Bosch.VideoSDK.Live.VcaConfig;
//			m_vcaConfig[m_currentCameoIndex].StateChanged += new Bosch.VideoSDK.GCALib._IVcaConfigEvents_StateChangedEventHandler(vc_StateChanged);

			m_vcaConfigDialog[m_currentCameoIndex] = 
				new VcaConfigDialog(this, m_vcaConfig[m_currentCameoIndex], "VCA Cameo "+(m_currentCameoIndex+1));
			m_vcaConfigDialog[m_currentCameoIndex].TopMost = true;
			m_vcaConfigDialog[m_currentCameoIndex].Show();
			m_vcaConfigDialog[m_currentCameoIndex].setStatus(m_vcaConfig[m_currentCameoIndex].State.ToString());
		}
		#endregion

		private void m_inputCameraController_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_inputCameraController_Click",
				m_inputCameraController.Text);

			if (m_deviceTree.SelectedNode is VideoInputNode)
			{
				VideoInputNode node = (VideoInputNode)m_deviceTree.SelectedNode;

				if (node.Parent.Parent is DeviceTreeNode)
				{
					DeviceTreeNode deviceNode = (DeviceTreeNode)node.Parent.Parent;
					Bosch.VideoSDK.Device.DeviceProxy deviceProxy = deviceNode.GetDeviceProxy();

					if (deviceProxy != null)
					{
						try
						{
							Bosch.VideoSDK.Live.CameraController cc = (Bosch.VideoSDK.Live.CameraController)deviceProxy.VideoInputs[node.m_nPhysicalCameraNumber].CameraController;

							if (cc != null)
							{
								CameraControllerForm ccForm = new CameraControllerForm(cc, this);
								ccForm.Show();
							}
						}	
						catch
						{
							ErrorMessage("MainForm", "m_inputCameraController_Click",
								"This device does not support ICameraController", true);
						}
					}
				}
			}	
		}

		
		private void m_videoInputContextMenu_Popup(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_videoInputContextMenu_Popup",
				"");
			VideoInputNode videoInputNode = m_deviceTree.SelectedNode as VideoInputNode;

			if (videoInputNode != null)
			{
				DeviceTreeNode nodeParent = videoInputNode.Parent.Parent as DeviceTreeNode;

				// Clear the OLD menu first
				m_inputConnectTo.MenuItems.Clear();

				// Check for VideoOutputs on THIS device, theses are displayed through 
				// updating the Display on the Video Output (it's always CONNECTED)


				// Check all OTHER devices, if its VideoOutput.Channels have Decoders,
				// then they can be added. A connection must be established and and THEN
				// the channel can be displayed.

				// Add for each connected device that has video outputs?
				foreach (TreeNode treeNode in m_deviceTree.Nodes)
				{
					DeviceTreeNode deviceTreeNode = treeNode as DeviceTreeNode;
					if (deviceTreeNode != null)
					{
						if (deviceTreeNode.m_bConnected)
						{
							// Find the VideoOutputs!
							foreach (TreeNode deviceNode in deviceTreeNode.Nodes)
							{
								if (deviceNode.Text == "Video Outputs")
								{
									System.Windows.Forms.MenuItem menuCurrentParent = m_inputConnectTo;
									System.Windows.Forms.MenuItem deviceMenu = null;
									foreach (TreeNode childNode in deviceNode.Nodes)
									{
										System.Windows.Forms.MenuItem outputMenu = null;
										VideoOutputNode videoOutputNode = childNode as VideoOutputNode;

										if (videoOutputNode != null)
										{
											foreach (Bosch.VideoSDK.Live.VideoOutputChannel channel
														 in videoOutputNode.m_videoOutput.Channels)
											{
												if (channel.IsDecoder)
												{
													VideoChannelConnectMenuItem channelMenu;

													if (videoOutputNode.m_videoOutput.Channels.Count > 1)
													{
														// Multiple channels, use the Channels name
														channelMenu = new VideoChannelConnectMenuItem(videoInputNode.m_videoInput, 
																										channel, 
																										nodeParent.m_remoteAudio,
																										channel.Name);

														if (deviceMenu == null)
														{
															deviceMenu = new System.Windows.Forms.MenuItem(deviceTreeNode.Text/*, onclick*/);
															m_inputConnectTo.MenuItems.Add(deviceMenu);
															menuCurrentParent = deviceMenu;
														}
														if (deviceNode.Nodes.Count > 1)
														{
															if (outputMenu == null)
															{
																outputMenu = new System.Windows.Forms.MenuItem(videoOutputNode.m_videoOutput.Name);
																deviceMenu.MenuItems.Add(outputMenu);
															}
															menuCurrentParent = outputMenu;
														}
														menuCurrentParent.MenuItems.Add(channelMenu);
													}
													else if (deviceNode.Nodes.Count > 1)
													{
														// Single channel but multiple outputs, use the output name
														channelMenu = new VideoChannelConnectMenuItem(videoInputNode.m_videoInput, 
																										channel, 
																										nodeParent.m_remoteAudio, 
																										videoOutputNode.m_videoOutput.Name);
														if (deviceMenu == null)
														{
															deviceMenu = new System.Windows.Forms.MenuItem(deviceTreeNode.Text/*, onclick*/);
															m_inputConnectTo.MenuItems.Add(deviceMenu);
														}
														deviceMenu.MenuItems.Add(channelMenu);
													}
													else
													{
														// Single channel with single output, use the Device name
														channelMenu = new VideoChannelConnectMenuItem(videoInputNode.m_videoInput, 
																										channel, 
																										nodeParent.m_remoteAudio, 
																										deviceTreeNode.Text);
														m_inputConnectTo.MenuItems.Add(channelMenu);
													}
													channelMenu.m_mainForm = this;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		
		private void m_deviceTree_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			TreeView tv = sender as TreeView;
			TreeNode tn = tv.SelectedNode;

			if (tn != null)
			{
				foreach (TreeNode treeNode in tn.Nodes)
				{
					ExtendedTreeNode extendedTreeNode = treeNode as ExtendedTreeNode;
					if (extendedTreeNode != null)
						extendedTreeNode.RetrieveName();
				}
			}
		}

		private void m_actionsViewNativeVideoSizeMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_actionsViewNativeVideoSizeMenuItem_Click",
				m_actionsViewNativeVideoSizeMenuItem.Text);

			long lWidth = 0;
			long lHeight = 0;
			string message;

			if (m_activeCameo != null)
			{
				try
				{
					lWidth = m_activeCameo.NativeVideoWidth;
					lHeight = m_activeCameo.NativeVideoHeight;
				}
				catch
				{
					ErrorMessage("MainForm", "m_actionsViewNativeVideoSizeMenuItem_Click", "Error getting native video size.", true);
				}
			}

			message = "Width: " + lWidth.ToString() + ", Height: " + lHeight.ToString();
			MessageBox.Show(message, "Native Video Size", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void m_salvoCameosMenuItem_Click(object sender, System.EventArgs e)
		{
			LogUserMessage("MainForm", "m_salvoCameosMenuItem_Click", m_salvoCameosMenuItem.Text);
			Bosch.VideoSDK.Live.VideoInput nextVideoInput = null;

			// Fill all visible cameos.
			for (int i = 0; i < m_maxCameos; i++)
			{
				if (m_cameoArray[i].Visible)
				{
					nextVideoInput = FindNextVideoInput(ref m_salvoDeviceIndex, ref m_salvoVideoInputIndex);

					if (nextVideoInput != null)
					{
						try
						{
							m_cameoArray[i].SetVideoStream(nextVideoInput.Stream);
						}
						catch (COMException ex)
						{
							ErrorMessage("MainForm", "m_salvoCameosMenuItem_Click", "Error " + String.Format("{0:x}", ex.ErrorCode) + ": " + ex.Message, false);
						}
					}
				}
			}		
		}

		private void m_mediaFileWriter_RecordingStopped(Bosch.VideoSDK.MediaDatabase.RecordingStoppedEnum Reason)
		{
			string msg = "Media file recording stopped, Reason: " + Reason.ToString();

			LogMessage("MainForm", "m_mediaFileWriter_RecordingStopped", msg);
			
			m_lbMessages.Items.Add(DateTime.Now.ToString() + " " + msg);
			m_lbMessages.SelectedIndex = m_lbMessages.Items.Count - 1;		

			// Reset the menu item's text and state and also the media file track IDs.
			m_startRecordingMenuItem.Text = "Start MediaFileWriter Recording";
			m_startRecordingMenuItem.Enabled = false;
			m_mediaFileVideoTrackID = 0;
			m_mediaFileAudioTrackID = 0;
		}
	}
}
