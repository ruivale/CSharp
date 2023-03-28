using System;
using System.Windows.Forms;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// 
	/// </summary>
	public class VideoOutputNode : ExtendedTreeNode
	{
		public Bosch.VideoSDK.Live.VideoOutput m_videoOutput = null;
		bool m_bNameRetrieved = false;
		
		public VideoOutputNode()
		{
		}

		public void SetVideoOutput(Bosch.VideoSDK.Live.VideoOutput videoOutput)
		{
			m_bNameRetrieved = false;
			m_videoOutput = videoOutput;

		}

		public override void Cleanup()
		{
			SetVideoOutput(null);
			base.Cleanup();
		}

		public override void RetrieveName()
		{
			if (!m_bNameRetrieved)
			{
				this.Text = m_videoOutput.Name;
				m_bNameRetrieved = true;
			}
		}


	}
}
