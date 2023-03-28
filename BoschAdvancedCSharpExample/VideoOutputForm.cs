using System;
using System.Runtime.InteropServices;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// 
	/// </summary>
	public class VideoOutputForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox m_cboLayouts;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox m_lstCameos;
		private System.Windows.Forms.ListBox m_lstConnections;


		private MainForm m_mainForm = null;
		private Bosch.VideoSDK.Live.VideoOutput m_videoOutput = null;
		private Bosch.VideoSDK.GCALib._IVideoOutputChannelEvents_ConnectionEventHandler m_handlerConnection = null;
		private Bosch.VideoSDK.GCALib._IVideoOutputChannelEvents_DisconnectionEventHandler m_handlerDisconnection = null;



		private Bosch.VideoSDK.Live.DisplayLayout[] m_displayLayouts;
		private Bosch.VideoSDK.Live.DisplayConfiguration m_currentDisplayConfig;

		private System.Windows.Forms.Button m_btnUpdate;
		private System.Windows.Forms.Button m_btnSetSource;
		private System.Windows.Forms.Button m_btnClearSource;
		private System.Windows.Forms.Button m_btnDisconnect;

		private int m_nCameoCount;
		private short m_nSelectedVideo;
		private short m_nSelectedCameo;


		public VideoOutputForm(Bosch.VideoSDK.Live.VideoOutput videoOutput, MainForm mainForm)
		{
			m_nCameoCount = 0;
			m_nSelectedVideo = -1;
			m_nSelectedCameo = -1;

			InitializeComponent();

			m_mainForm = mainForm;
			m_videoOutput = videoOutput;

			this.Text += " - " + m_videoOutput.Name;

			m_handlerConnection = new Bosch.VideoSDK.GCALib._IVideoOutputChannelEvents_ConnectionEventHandler(VideoOutputChannel_Connection);
			m_handlerDisconnection = new Bosch.VideoSDK.GCALib._IVideoOutputChannelEvents_DisconnectionEventHandler(VideoOutputChannel_Disconnection);

			m_displayLayouts = m_videoOutput.SupportedLayouts;
			m_mainForm = mainForm;
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_cboLayouts = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_lstCameos = new System.Windows.Forms.ListBox();
			this.m_btnUpdate = new System.Windows.Forms.Button();
			this.m_lstConnections = new System.Windows.Forms.ListBox();
			this.m_btnSetSource = new System.Windows.Forms.Button();
			this.m_btnClearSource = new System.Windows.Forms.Button();
			this.m_btnDisconnect = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_cboLayouts
			// 
			this.m_cboLayouts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboLayouts.Location = new System.Drawing.Point(384, 16);
			this.m_cboLayouts.Name = "m_cboLayouts";
			this.m_cboLayouts.Size = new System.Drawing.Size(176, 21);
			this.m_cboLayouts.TabIndex = 0;
			this.m_cboLayouts.SelectedIndexChanged += new System.EventHandler(this.m_cboLayouts_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(248, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Connections:";
			// 
			// m_lstCameos
			// 
			this.m_lstCameos.Location = new System.Drawing.Point(384, 40);
			this.m_lstCameos.Name = "m_lstCameos";
			this.m_lstCameos.Size = new System.Drawing.Size(176, 251);
			this.m_lstCameos.TabIndex = 7;
			this.m_lstCameos.SelectedIndexChanged += new System.EventHandler(this.m_lstCameos_SelectedIndexChanged);
			// 
			// m_btnUpdate
			// 
			this.m_btnUpdate.Location = new System.Drawing.Point(416, 296);
			this.m_btnUpdate.Name = "m_btnUpdate";
			this.m_btnUpdate.Size = new System.Drawing.Size(112, 32);
			this.m_btnUpdate.TabIndex = 8;
			this.m_btnUpdate.Text = "Update Display";
			// 
			// m_lstConnections
			// 
			this.m_lstConnections.Location = new System.Drawing.Point(8, 40);
			this.m_lstConnections.Name = "m_lstConnections";
			this.m_lstConnections.Size = new System.Drawing.Size(296, 251);
			this.m_lstConnections.TabIndex = 9;
			this.m_lstConnections.SelectedIndexChanged += new System.EventHandler(this.m_lstConnections_SelectedIndexChanged);
			// 
			// m_btnSetSource
			// 
			this.m_btnSetSource.Location = new System.Drawing.Point(312, 40);
			this.m_btnSetSource.Name = "m_btnSetSource";
			this.m_btnSetSource.Size = new System.Drawing.Size(64, 32);
			this.m_btnSetSource.TabIndex = 10;
			this.m_btnSetSource.Text = ">>";
			this.m_btnSetSource.Click += new System.EventHandler(this.m_btnSetSource_Click);
			// 
			// m_btnClearSource
			// 
			this.m_btnClearSource.Location = new System.Drawing.Point(312, 80);
			this.m_btnClearSource.Name = "m_btnClearSource";
			this.m_btnClearSource.Size = new System.Drawing.Size(64, 32);
			this.m_btnClearSource.TabIndex = 11;
			this.m_btnClearSource.Text = "<<";
			this.m_btnClearSource.Click += new System.EventHandler(this.m_btnClearSource_Click);
			// 
			// m_btnDisconnect
			// 
			this.m_btnDisconnect.Location = new System.Drawing.Point(96, 296);
			this.m_btnDisconnect.Name = "m_btnDisconnect";
			this.m_btnDisconnect.Size = new System.Drawing.Size(112, 32);
			this.m_btnDisconnect.TabIndex = 12;
			this.m_btnDisconnect.Text = "Disconnect Source";
			this.m_btnDisconnect.Click += new System.EventHandler(this.m_btnDisconnect_Click);
			// 
			// VideoOutputForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(570, 335);
			this.Controls.Add(this.m_btnDisconnect);
			this.Controls.Add(this.m_btnClearSource);
			this.Controls.Add(this.m_btnSetSource);
			this.Controls.Add(this.m_lstConnections);
			this.Controls.Add(this.m_btnUpdate);
			this.Controls.Add(this.m_lstCameos);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_cboLayouts);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "VideoOutputForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Monitor Configuration";
			this.Load += new System.EventHandler(this.VideoOutputForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void VideoOutputForm_Load(object sender, System.EventArgs e)
		{
			string sLayout;
			int nItem;
			Bosch.VideoSDK.Live.DisplayLayout layout;
			Bosch.VideoSDK.Live.DisplayLayout currentLayout = null;

			LoadVideoSources();

			m_currentDisplayConfig = m_videoOutput.GetDisplayConfiguration();

			if (m_currentDisplayConfig != null)
			{
				currentLayout = m_currentDisplayConfig.Layout;
			}

			for (int i = m_displayLayouts.GetLowerBound(0); i <= m_displayLayouts.GetUpperBound(0); i++)
			{
				layout = m_displayLayouts[i];
				sLayout = layout.Description;
				nItem = m_cboLayouts.Items.Add(sLayout);

				if (m_currentDisplayConfig != null)
				{
					if (layout.CameoCount == currentLayout.CameoCount)
					{
						m_cboLayouts.SelectedIndex = nItem;
					}
				}
			}
		}

		public void LoadVideoSources()
		{
			Bosch.VideoSDK.Live.VideoOutputChannels channels;

			m_lstConnections.Items.Clear();
			channels = m_videoOutput.Channels;

			if (channels != null)
			{
				for (short i = 1; i <= channels.Count; i++)
				{
					m_lstConnections.Items.Add(GetDecoderDescription(channels[i]));
					
					if (channels[i].IsDecoder)
					{
						((Bosch.VideoSDK.GCALib._IVideoOutputChannelEvents_Event)channels[i]).Connection += m_handlerConnection;
						((Bosch.VideoSDK.GCALib._IVideoOutputChannelEvents_Event)channels[i]).Disconnection += m_handlerDisconnection;
					}
				}
			}
		}

		private void VideoOutputChannel_Connection(Bosch.VideoSDK.MediaSession mediaSession)
		{
			Bosch.VideoSDK.Live.VideoOutputChannels channels = m_videoOutput.Channels;
			for (short i = 1; i <= channels.Count; i++)
			{
				if (channels[i].MediaSession == mediaSession)
				{
					m_lstConnections.Items[i - 1] = GetDecoderDescription(channels[i]);
				}
			}
			
		}

		private void VideoOutputChannel_Disconnection(Bosch.VideoSDK.MediaSession mediaSession, short status)
		{
			Bosch.VideoSDK.Live.VideoOutputChannels channels = m_videoOutput.Channels;
			for (short i = 1; i <= channels.Count; i++)
			{
				if (channels[i].MediaSession == mediaSession)
				{
					m_lstConnections.Items[i - 1] = channels[i].Name + " [Not Connected]";
				}
			}
		}

		private void m_cboLayouts_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			short nIndex;
			Bosch.VideoSDK.Live.DisplayLayout selectedLayout;
			Bosch.VideoSDK.Live.DisplayLayout currentLayout;

			nIndex = (short) m_cboLayouts.SelectedIndex;

			selectedLayout = m_displayLayouts[nIndex];
			currentLayout = m_currentDisplayConfig.Layout;

			if (currentLayout.LayoutID != selectedLayout.LayoutID)
			{
				m_currentDisplayConfig.Layout = selectedLayout;
				m_videoOutput.SetDisplayConfiguration(m_currentDisplayConfig);
			}
			m_lstCameos.Items.Clear();

			// The DisplayConfiguration might be different to GET it...
			m_currentDisplayConfig = m_videoOutput.GetDisplayConfiguration();
			m_nCameoCount = m_currentDisplayConfig.Layout.CameoCount;


			for (short i = 1; i <= m_nCameoCount; i++)
			{
				m_lstCameos.Items.Add(
							GetMappingString(
								m_currentDisplayConfig.get_CameoMapping(i), i));
			}
		}

		private string GetMappingString(short videoSourceIndex, short cameoIndex)
		{
			string sReturn = "Cameo " + cameoIndex;

			switch (videoSourceIndex)		{
				case -1: 	{
					sReturn += " - DEVICE DEFAULT";
					break;	}

				case 0:		{
					sReturn += " - UNASSIGNED";
					break;	}

				default:	{
					sReturn += " - " + m_videoOutput.Channels[videoSourceIndex].Name;
					break;	}
			}

			return sReturn;
		}

		private string GetDecoderDescription(Bosch.VideoSDK.Live.VideoOutputChannel channel)
		{
			string sReturn = channel.Name;

			if (channel.IsDecoder)
			{
				Bosch.VideoSDK.MediaSession	mediaSession = channel.MediaSession;

				if (mediaSession == null)
				{
					sReturn+= " [Not Connected]";
				}
				else
				{
					sReturn+= " [" + mediaSession.SessionID + "] " + mediaSession.SourceURL + ":";// mediaSession.SourceID;
					// Add some details about the mediaSession.VideoStream
				}
			}

			return sReturn;
		}

		private void m_btnSet_Click(object sender, System.EventArgs e)
		{
		
		}

		private void m_btnClear_Click(object sender, System.EventArgs e)
		{
		
		}

		private void m_btnSetSource_Click(object sender, System.EventArgs e)
		{
			m_currentDisplayConfig.set_CameoMapping(m_nSelectedCameo, m_nSelectedVideo);

			m_videoOutput.SetDisplayConfiguration(m_currentDisplayConfig);
			m_lstCameos.Items[m_nSelectedCameo - 1] = 
						GetMappingString(m_nSelectedVideo, m_nSelectedCameo);
		}

		private void m_btnClearSource_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_currentDisplayConfig.set_CameoMapping(m_nSelectedCameo, 0);

				m_videoOutput.SetDisplayConfiguration(m_currentDisplayConfig);
				m_lstCameos.Items[m_nSelectedCameo - 1] = 
					GetMappingString(0, m_nSelectedCameo);
			}
			catch (COMException ex)
			{
				m_mainForm.ErrorMessage("VideoOutputForm", "m_btnClearSource_Click", ex.Message, true);
			}
			catch 
			{
				m_mainForm.ErrorMessage("VideoOutputForm", "m_btnClearSource_Click", "Device does not support clearing the cameos on a monitor!", true);
			}
		}

		private void m_lstConnections_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			EnableSetSource();
		}

		private void m_lstCameos_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			EnableSetSource();
			m_btnClearSource.Enabled = (m_nSelectedCameo > 0);
		}

		private void EnableSetSource()
		{
			m_nSelectedVideo = (short) m_lstConnections.SelectedIndex;
			m_nSelectedCameo = (short) m_lstCameos.SelectedIndex;

			m_nSelectedVideo++;
			m_nSelectedCameo++;

			m_btnSetSource.Enabled = (m_nSelectedVideo > 0 && m_nSelectedCameo > 0);
			m_btnDisconnect.Enabled = (m_nSelectedVideo > 0);
		}

		private void m_btnDisconnect_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (m_nSelectedVideo > 0)
				{
					Bosch.VideoSDK.Live.VideoOutputChannel channel = m_videoOutput.Channels[m_nSelectedVideo];
					channel.Disconnect();
				}
			}
			catch (COMException ex)
			{
				m_mainForm.ErrorMessage("VideoOutputForm", "m_btnDisconnect_Click", ex.Message, true);
			}
			catch 
			{
				m_mainForm.ErrorMessage("VideoOutputForm", "m_btnDisconnect_Click", "DisconnectFrom failed!", true);
			}
		}
	}
}
