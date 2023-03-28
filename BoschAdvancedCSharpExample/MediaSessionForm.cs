using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// Summary description for MediaSessionForm.
	/// </summary>
	public class MediaSessionForm : System.Windows.Forms.Form
	{
		private MainForm m_mainForm;
		private Bosch.VideoSDK.MediaSession m_ms = null;

		private System.Windows.Forms.Button m_btnPlayVideoInCameo;
		private System.Windows.Forms.Button m_btnPlayAudio;
		private System.Windows.Forms.TextBox m_txtTrackName;
		private System.Windows.Forms.TextBox m_txtControllerName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox m_txtDBName;
		private System.Windows.Forms.Button m_btnAddVideo;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button m_btnAddAudio;
		private System.Windows.Forms.TrackBar m_volumeTrackBar;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MediaSessionForm(
                Bosch.VideoSDK.MediaSession ms, 
                string dbName, 
                string trackName, 
                string controllerName, 
                MainForm mainForm)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_mainForm = mainForm;
			m_ms = ms;
			m_txtTrackName.Text = trackName;
			m_txtControllerName.Text = controllerName;
			m_txtDBName.Text = dbName;
			m_volumeTrackBar.Value = m_volumeTrackBar.Maximum / 2;

			if (m_ms.GetVideoStream() == null)
			{
				m_btnPlayVideoInCameo.Enabled = false;
				m_btnAddVideo.Enabled = false;
			}

			if (m_ms.GetAudioStream() == null)
			{
				m_btnPlayAudio.Enabled = false;
				m_btnAddAudio.Enabled = false;
				m_volumeTrackBar.Enabled = false;
			}
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
			this.m_btnPlayVideoInCameo = new System.Windows.Forms.Button();
			this.m_btnPlayAudio = new System.Windows.Forms.Button();
			this.m_txtTrackName = new System.Windows.Forms.TextBox();
			this.m_txtControllerName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.m_txtDBName = new System.Windows.Forms.TextBox();
			this.m_btnAddVideo = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.m_btnAddAudio = new System.Windows.Forms.Button();
			this.m_volumeTrackBar = new System.Windows.Forms.TrackBar();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_volumeTrackBar)).BeginInit();
			this.SuspendLayout();
			// 
			// m_btnPlayVideoInCameo
			// 
			this.m_btnPlayVideoInCameo.Location = new System.Drawing.Point(8, 16);
			this.m_btnPlayVideoInCameo.Name = "m_btnPlayVideoInCameo";
			this.m_btnPlayVideoInCameo.Size = new System.Drawing.Size(136, 23);
			this.m_btnPlayVideoInCameo.TabIndex = 0;
			this.m_btnPlayVideoInCameo.Text = "Play in Cameo";
			this.m_btnPlayVideoInCameo.Click += new System.EventHandler(this.m_btnPlayVideoInCameo_Click);
			// 
			// m_btnPlayAudio
			// 
			this.m_btnPlayAudio.Location = new System.Drawing.Point(8, 16);
			this.m_btnPlayAudio.Name = "m_btnPlayAudio";
			this.m_btnPlayAudio.Size = new System.Drawing.Size(136, 23);
			this.m_btnPlayAudio.TabIndex = 1;
			this.m_btnPlayAudio.Text = "Play in AudioReceiver";
			this.m_btnPlayAudio.Click += new System.EventHandler(this.m_btnPlayAudio_Click);
			// 
			// m_txtTrackName
			// 
			this.m_txtTrackName.Location = new System.Drawing.Point(112, 32);
			this.m_txtTrackName.Name = "m_txtTrackName";
			this.m_txtTrackName.ReadOnly = true;
			this.m_txtTrackName.Size = new System.Drawing.Size(256, 20);
			this.m_txtTrackName.TabIndex = 2;
			this.m_txtTrackName.Text = "";
			// 
			// m_txtControllerName
			// 
			this.m_txtControllerName.Location = new System.Drawing.Point(112, 56);
			this.m_txtControllerName.Name = "m_txtControllerName";
			this.m_txtControllerName.ReadOnly = true;
			this.m_txtControllerName.Size = new System.Drawing.Size(256, 20);
			this.m_txtControllerName.TabIndex = 3;
			this.m_txtControllerName.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Track Name:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Controller Name:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "DB Name:";
			// 
			// m_txtDBName
			// 
			this.m_txtDBName.Location = new System.Drawing.Point(112, 8);
			this.m_txtDBName.Name = "m_txtDBName";
			this.m_txtDBName.ReadOnly = true;
			this.m_txtDBName.Size = new System.Drawing.Size(256, 20);
			this.m_txtDBName.TabIndex = 6;
			this.m_txtDBName.Text = "";
			// 
			// m_btnAddVideo
			// 
			this.m_btnAddVideo.Location = new System.Drawing.Point(8, 48);
			this.m_btnAddVideo.Name = "m_btnAddVideo";
			this.m_btnAddVideo.Size = new System.Drawing.Size(136, 23);
			this.m_btnAddVideo.TabIndex = 8;
			this.m_btnAddVideo.Text = "Add to Media File Writer";
			this.m_btnAddVideo.Click += new System.EventHandler(this.m_btnAddVideo_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_btnAddVideo);
			this.groupBox1.Controls.Add(this.m_btnPlayVideoInCameo);
			this.groupBox1.Location = new System.Drawing.Point(8, 88);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(152, 88);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Video Stream";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.m_btnAddAudio);
			this.groupBox2.Controls.Add(this.m_btnPlayAudio);
			this.groupBox2.Controls.Add(this.m_volumeTrackBar);
			this.groupBox2.Location = new System.Drawing.Point(168, 88);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 88);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Audio Stream";
			// 
			// m_btnAddAudio
			// 
			this.m_btnAddAudio.Location = new System.Drawing.Point(8, 48);
			this.m_btnAddAudio.Name = "m_btnAddAudio";
			this.m_btnAddAudio.Size = new System.Drawing.Size(136, 23);
			this.m_btnAddAudio.TabIndex = 2;
			this.m_btnAddAudio.Text = "Add to Media File Writer";
			this.m_btnAddAudio.Click += new System.EventHandler(this.m_btnAddAudio_Click);
			// 
			// m_volumeTrackBar
			// 
			this.m_volumeTrackBar.Location = new System.Drawing.Point(152, 16);
			this.m_volumeTrackBar.Name = "m_volumeTrackBar";
			this.m_volumeTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.m_volumeTrackBar.Size = new System.Drawing.Size(42, 64);
			this.m_volumeTrackBar.TabIndex = 11;
			this.m_volumeTrackBar.Scroll += new System.EventHandler(this.m_volumeTrackBar_Scroll);
			// 
			// MediaSessionForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 181);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_txtDBName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_txtControllerName);
			this.Controls.Add(this.m_txtTrackName);
			this.Name = "MediaSessionForm";
			this.Text = "Media Session";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_volumeTrackBar)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void m_btnPlayVideoInCameo_Click(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("MediaSessionForm", "m_btnPlayVideoInCameo_Click", m_btnPlayVideoInCameo.Text);

			try
			{
				if (m_ms.GetVideoStream() != null)
					m_mainForm.AssignNextCameo(m_ms.GetVideoStream());
				else
					m_mainForm.ErrorMessage("MediaSessionForm", "m_btnPlayVideoInCameo_Click", "This media session does not have a video stream.", true);
			}
			catch
			{
				m_mainForm.ErrorMessage("MediaSessionForm", "m_btnPlayVideoInCameo_Click", "Error assigning video stream to cameo.", true);
			}
		}

		private void m_btnPlayAudio_Click(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("MediaSessionForm", "m_btnPlayAudio_Click", m_btnPlayAudio.Text);

			try
			{
				if (m_ms.GetAudioStream() != null)
				{
					Bosch.VideoSDK.DataStream ds = m_ms.GetAudioStream();

					ds.Volume = m_volumeTrackBar.Value * 100 / m_volumeTrackBar.Maximum;
					m_mainForm.m_audioReceiver.AddStream(m_ms.GetAudioStream());
					m_mainForm.m_audioStreams.Push(m_ms.GetAudioStream());
				}
				else
				{
					m_mainForm.ErrorMessage("MediaSessionForm", "m_btnPlayAudio_Click", "This media session does not have an audio stream.", true);
				}
			}
			catch
			{
				m_mainForm.ErrorMessage("MediaSessionForm", "m_btnPlayAudio_Click", "Error assigning audio stream to audio receiver.", true);
			}
		}

		private void m_btnAddVideo_Click(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("MediaSessionForm", "m_btnAddVideo_Click", m_btnAddVideo.Text);
			m_mainForm.AddStreamToMediaWriter(Bosch.VideoSDK.MediaTypeEnum.mteVideo, m_ms.GetVideoStream(), m_txtDBName.Text);
		}

		private void m_btnAddAudio_Click(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("MediaSessionForm", "m_btnAddAudio_Click", m_btnAddAudio.Text);
			m_mainForm.AddStreamToMediaWriter(Bosch.VideoSDK.MediaTypeEnum.mteAudio, m_ms.GetAudioStream(), m_txtDBName.Text);
		}

		private void m_volumeTrackBar_Scroll(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("MediaSessionForm", "m_volumeTrackBar_Scroll", "User scrolled volume track bar");

			if (m_ms.GetAudioStream() != null)
			{
				Bosch.VideoSDK.DataStream ds = m_ms.GetAudioStream();

				ds.Volume = m_volumeTrackBar.Value * 100 / m_volumeTrackBar.Maximum;
			}

		}
	}
}
