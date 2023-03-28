using System;
using System.Windows.Forms;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// Summary description for VideoInputNode.
	/// </summary>
	public class VideoInputNode : ExtendedTreeNode
	{
		public Bosch.VideoSDK.Live.VideoInput m_videoInput = null;
		public int m_nPhysicalCameraNumber;
		private bool m_bNameRetrieved = false;
		
		public VideoInputNode()
		{			
		}

		public void SetVideoInput(Bosch.VideoSDK.Live.VideoInput videoInput, int nNum)
		{
			m_bNameRetrieved = false;
			m_videoInput = videoInput;
			m_nPhysicalCameraNumber = nNum;
		}

		public override void RetrieveName()
		{
			if (!m_bNameRetrieved)
			{
				this.Text = m_videoInput.Name;
				m_bNameRetrieved = true;
			}
		}

		public override void Cleanup()
		{
			SetVideoInput(null, 0);
			base.Cleanup();
		}
	}
}
