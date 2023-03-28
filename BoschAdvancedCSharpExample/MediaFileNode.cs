using System;
using System.Windows.Forms;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// Summary description for MediaFileNode.
	/// </summary>
	public class MediaFileNode : ExtendedTreeNode
	{
		private Bosch.VideoSDK.MediaDatabase.MediaFileReader m_mfr = null;

		public MediaFileNode(string text, Bosch.VideoSDK.MediaDatabase.MediaFileReader mfr)
		{
			this.Text = text;
			m_mfr = mfr;
		}

		public Bosch.VideoSDK.MediaDatabase.MediaFileReader GetMediaFileReader()
		{
			return m_mfr;
		}

		public override void Cleanup()
		{
			m_mfr = null;
			base.Cleanup();
		}
	}
}
