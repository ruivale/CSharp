using System;
using System.Windows.Forms;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// 
	/// </summary>
	public class AudioOutputNode : ExtendedTreeNode
	{
		public Bosch.VideoSDK.Live.AudioOutput m_audioOutput = null;
		public bool m_bConnected = false;
		private bool m_bNameRetrieved = false;

		public AudioOutputNode()
		{
		}

		public void SetAudioOutput(Bosch.VideoSDK.Live.AudioOutput audioOutput)
		{
			m_audioOutput = audioOutput;
			m_bNameRetrieved = false;
		}

		public override void RetrieveName()
		{
			if (!m_bNameRetrieved)
			{
				this.Text = m_audioOutput.Name;
				m_bNameRetrieved = true;
			}
		}
	}
}
