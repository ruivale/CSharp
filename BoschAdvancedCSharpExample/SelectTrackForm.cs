using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// Summary description for SelectTrackForm.
	/// </summary>
	public class SelectTrackForm : System.Windows.Forms.Form
	{
		private MediaDatabaseForm m_parentForm = null;
		public MainForm m_mainForm = null;
		private string m_dbName;
		private bool m_bUseTrack = true;

		private System.Windows.Forms.ListBox m_lbTracks;
		private System.Windows.Forms.ListBox m_lbPlaybackControllers;
		private System.Windows.Forms.Button m_btnGetMediaSession;
		private System.Windows.Forms.RadioButton m_optTrack;
		private System.Windows.Forms.RadioButton m_optMediaDB;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SelectTrackForm(MediaDatabaseForm parentForm, string dbName)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_parentForm = parentForm;
			m_parentForm.PutTracksInListBox(m_lbTracks);
			m_lbTracks.SelectedIndex = 0;

			m_mainForm = m_parentForm.m_mainForm;
			m_mainForm.PutControllersInListBox(m_lbPlaybackControllers);
			m_lbPlaybackControllers.SelectedIndex = 0;

			m_dbName = dbName;
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
			this.m_lbTracks = new System.Windows.Forms.ListBox();
			this.m_lbPlaybackControllers = new System.Windows.Forms.ListBox();
			this.m_btnGetMediaSession = new System.Windows.Forms.Button();
			this.m_optTrack = new System.Windows.Forms.RadioButton();
			this.m_optMediaDB = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// m_lbTracks
			// 
			this.m_lbTracks.Location = new System.Drawing.Point(8, 16);
			this.m_lbTracks.Name = "m_lbTracks";
			this.m_lbTracks.Size = new System.Drawing.Size(272, 95);
			this.m_lbTracks.TabIndex = 0;
			// 
			// m_lbPlaybackControllers
			// 
			this.m_lbPlaybackControllers.Location = new System.Drawing.Point(8, 128);
			this.m_lbPlaybackControllers.Name = "m_lbPlaybackControllers";
			this.m_lbPlaybackControllers.Size = new System.Drawing.Size(272, 95);
			this.m_lbPlaybackControllers.TabIndex = 1;
			// 
			// m_btnGetMediaSession
			// 
			this.m_btnGetMediaSession.Location = new System.Drawing.Point(80, 264);
			this.m_btnGetMediaSession.Name = "m_btnGetMediaSession";
			this.m_btnGetMediaSession.Size = new System.Drawing.Size(144, 23);
			this.m_btnGetMediaSession.TabIndex = 2;
			this.m_btnGetMediaSession.Text = "Get Media Session";
			this.m_btnGetMediaSession.Click += new System.EventHandler(this.m_btnGetMediaSession_Click);
			// 
			// m_optTrack
			// 
			this.m_optTrack.Checked = true;
			this.m_optTrack.Location = new System.Drawing.Point(8, 232);
			this.m_optTrack.Name = "m_optTrack";
			this.m_optTrack.Size = new System.Drawing.Size(120, 16);
			this.m_optTrack.TabIndex = 3;
			this.m_optTrack.TabStop = true;
			this.m_optTrack.Text = "Use Track object";
			this.m_optTrack.CheckedChanged += new System.EventHandler(this.m_optTrack_Changed);
			// 
			// m_optMediaDB
			// 
			this.m_optMediaDB.Location = new System.Drawing.Point(144, 232);
			this.m_optMediaDB.Name = "m_optMediaDB";
			this.m_optMediaDB.Size = new System.Drawing.Size(128, 16);
			this.m_optMediaDB.TabIndex = 4;
			this.m_optMediaDB.Text = "Use Media Database";
			this.m_optMediaDB.CheckedChanged += new System.EventHandler(this.m_optMediaDB_Changed);
			// 
			// SelectTrackForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 293);
			this.Controls.Add(this.m_optMediaDB);
			this.Controls.Add(this.m_optTrack);
			this.Controls.Add(this.m_btnGetMediaSession);
			this.Controls.Add(this.m_lbPlaybackControllers);
			this.Controls.Add(this.m_lbTracks);
			this.Name = "SelectTrackForm";
			this.Text = "Select Track";
			this.ResumeLayout(false);

		}
		#endregion

		private void m_btnGetMediaSession_Click(object sender, System.EventArgs e)
		{
			Bosch.VideoSDK.MediaSession ms = null;

			m_mainForm.LogUserMessage("SelectTrackForm", "m_btnGetMediaSession_Click", "Opening media session window");

			Bosch.VideoSDK.MediaDatabase.Track track = ((TrackWrapper)m_lbTracks.SelectedItem).m_track;
			Bosch.VideoSDK.MediaDatabase.PlaybackController pc = ((PlaybackControllerWrapper)m_lbPlaybackControllers.SelectedItem).m_pc;

			if (m_bUseTrack)
			{
				try
				{
					ms = track.GetMediaSession(pc);
				}
				catch
				{
					m_mainForm.ErrorMessage("SelectTrackForm", "m_btnGetMediaSession_Click", "Error calling track.GetMediaSession", true);
				}
			}
			else
			{
				try
				{
					ms = m_parentForm.m_mediaDatabase.GetMediaSession(track.TrackID, pc);
				}
				catch
				{
					m_mainForm.ErrorMessage("SelectTrackForm", "m_btnGetMediaSession_Click", "Error calling mediaDatabase.GetMediaSession", true);
				}
			}
			MediaSessionForm newForm = new MediaSessionForm(ms, m_dbName, track.Name, pc.Name, m_mainForm);
			newForm.Show();
		}

		private void m_optTrack_Changed(object sender, System.EventArgs e)
		{
			m_bUseTrack = true;
		}

		private void m_optMediaDB_Changed(object sender, System.EventArgs e)
		{
			m_bUseTrack = false;
		}
	}
}

