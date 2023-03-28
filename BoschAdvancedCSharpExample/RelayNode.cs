using System;
using System.Drawing;
using System.Windows.Forms;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// 
	/// </summary>
	public class RelayNode : ExtendedTreeNode
	{
		private Bosch.VideoSDK.Live.Relay m_relay = null;
		
		private Font m_fontOn = new Font("Arial", 8, FontStyle.Bold);
		private Font m_fontOff = new Font("Arial", 8, FontStyle.Regular);
		private bool m_bState = false;
		private Bosch.VideoSDK.GCALib._IRelayEvents_StateChangedEventHandler m_eventHandler = null;
		bool m_bNameRetrieved = false;

		public RelayNode()
		{
			m_eventHandler = new Bosch.VideoSDK.GCALib._IRelayEvents_StateChangedEventHandler(RelayNode_StateChanged);
		}

		public void SetRelay(Bosch.VideoSDK.Live.Relay relay)
		{
			if (m_relay != null)
				((Bosch.VideoSDK.GCALib._IRelayEvents_Event)m_relay).StateChanged -= m_eventHandler;

			m_bNameRetrieved = false;
			m_relay = relay;

			if (m_relay != null)
				((Bosch.VideoSDK.GCALib._IRelayEvents_Event)m_relay).StateChanged += m_eventHandler;
		}

		public void ToggleState()
		{
			try
			{
				m_relay.SetState(!m_bState);
			}
			catch
			{
				m_mainForm.ErrorMessage("RelayNode", "ToggleState", "Error setting Relay state", true);
			}
		}

		private void RelayNode_StateChanged(Bosch.VideoSDK.Live.Relay EventSource, bool State)
		{
			m_bState = State;
			
			if (State)
			{
				this.NodeFont = m_fontOn;
			}
			else
			{
				this.NodeFont = m_fontOff;
			}
		}

		public override void Cleanup()
		{
			SetRelay(null);
			m_eventHandler = null;
			base.Cleanup();
		}
		public override void RetrieveName()
		{
			if (!m_bNameRetrieved)
			{
				if(m_relay.Enabled)
				{
					this.Text = m_relay.Name + " (Enabled)";
				}
				else
				{
					this.Text = m_relay.Name + " (Disabled)";
				}

				m_bNameRetrieved = true;
			}
		}
	}
}