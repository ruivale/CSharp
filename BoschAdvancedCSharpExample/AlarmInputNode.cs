using System;
using System.Drawing;
using System.Windows.Forms;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// 
	/// </summary>
	public class AlarmInputNode : ExtendedTreeNode
	{
		private Bosch.VideoSDK.Live.AlarmInput m_alarmInput = null;
		private Font m_fontOn = new Font("Arial", 8, FontStyle.Bold);
		private Font m_fontOff = new Font("Arial", 8, FontStyle.Regular);
		private Bosch.VideoSDK.GCALib._IAlarmInputEvents_StateChangedEventHandler m_eventHandler = null;
		bool m_bNameRetrieved = false;

		public AlarmInputNode()
		{
			m_eventHandler = new Bosch.VideoSDK.GCALib._IAlarmInputEvents_StateChangedEventHandler(AlarmInputNode_StateChanged);
		}

		public void SetAlarmInput(Bosch.VideoSDK.Live.AlarmInput ai)
		{
			if (m_alarmInput != null)
				((Bosch.VideoSDK.GCALib._IAlarmInputEvents_Event)m_alarmInput).StateChanged -= m_eventHandler;

			m_bNameRetrieved = false;
			m_alarmInput = ai;

			if (m_alarmInput != null)
				((Bosch.VideoSDK.GCALib._IAlarmInputEvents_Event)m_alarmInput).StateChanged += m_eventHandler;
		}

		private void AlarmInputNode_StateChanged(Bosch.VideoSDK.Live.AlarmInput EventSource, bool State)
		{
			if (State)
			{
				this.Text += " ";
				this.NodeFont = m_fontOn;
			}
			else
			{
				this.NodeFont = m_fontOff;
			}
		}

		public override void Cleanup()
		{
			SetAlarmInput(null);
			m_eventHandler = null;
			base.Cleanup();
		}
		public override void RetrieveName()
		{
			if (!m_bNameRetrieved)
			{
				this.Text = m_alarmInput.Name + " ";
				m_bNameRetrieved = true;
			}
		}
	}
}
