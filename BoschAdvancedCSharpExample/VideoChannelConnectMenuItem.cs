using System;
using System.Runtime.InteropServices;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// Summary description for VideoChannelConnectMenuItem.
	/// </summary>
	public class VideoChannelConnectMenuItem : System.Windows.Forms.MenuItem
	{
		public MainForm m_mainForm = null;

		private Bosch.VideoSDK.Live.VideoInput			m_videoInput = null;
		private Bosch.VideoSDK.Live.VideoOutputChannel	m_outputChannel = null;
		Bosch.VideoSDK.Live.AudioChannelFlags m_remoteAudio = 0;

		public VideoChannelConnectMenuItem(	Bosch.VideoSDK.Live.VideoInput videoInput,
											Bosch.VideoSDK.Live.VideoOutputChannel outputChannel,
											Bosch.VideoSDK.Live.AudioChannelFlags audioChannel,
											String MenuText)
		{
			//
			// TODO: Add constructor logic here
			//
			this.m_videoInput = videoInput;
			this.m_outputChannel = outputChannel;
			this.m_remoteAudio = audioChannel;

			this.Text = MenuText;
			this.Click +=new EventHandler(VideoChannelConnectMenuItem_Click);
		}

		private void VideoChannelConnectMenuItem_Click(object sender, EventArgs e)
		{
			// BAM!!! Establish the connection! (well, display a dialog to do it anyway)
			try
			{
				m_outputChannel.ConnectTo(m_videoInput.Stream, m_remoteAudio);
			}
			catch (COMException ex)
			{
				m_mainForm.ErrorMessage("VideoChannelConnectMenuItem", "Click", ex.Message, true);
			}
			catch 
			{
				m_mainForm.ErrorMessage("VideoChannelConnectMenuItem", "Click", "ConnectTo failed!", true);
			}
		}
	}
}
