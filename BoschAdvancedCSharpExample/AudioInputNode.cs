using System;
using System.Windows.Forms;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// 
	/// </summary>
	public class AudioInputNode : ExtendedTreeNode
	{
		public Bosch.VideoSDK.Live.AudioInput m_audioInput = null;
		bool m_bNameRetrieved = false;
		
		public AudioInputNode()
		{
		}

		public void SetAudioInput(Bosch.VideoSDK.Live.AudioInput audioInput)
		{
			m_audioInput = audioInput;
			m_bNameRetrieved = false;
		}

		public override void RetrieveName()
		{
			if (!m_bNameRetrieved)
			{
				this.Text = m_audioInput.Name;
				m_bNameRetrieved = true;
			}
		}
	}
}
