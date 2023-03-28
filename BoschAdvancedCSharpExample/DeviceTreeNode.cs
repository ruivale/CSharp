using System;
using System.Windows.Forms;
using System.Drawing;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// Summary description for DeviceTreeNode.
	/// </summary>
	public class DeviceTreeNode : ExtendedTreeNode
	{
		public string m_deviceName = "";
		public string m_deviceProtocol = "";
		public string m_deviceAddress = "";
		public string m_deviceDescription = "";
		public string m_deviceUrl = "";
		public string m_username = "";
		public string m_password = "";
		public string m_progID = "";
		public string m_nodeText = "";
		public bool m_bConnected = false;
		private Bosch.VideoSDK.Device.DeviceProxy m_deviceProxy = null;
		public Bosch.VideoSDK.CodingEnum m_coding = Bosch.VideoSDK.CodingEnum.ceMPEG4;
		public Bosch.VideoSDK.Live.AudioChannelFlags m_remoteAudio = Bosch.VideoSDK.Live.AudioChannelFlags.acfNone;
		public int m_encoder = 0;
		public bool m_multicast = false;
		public Bosch.VideoSDK.StreamingProtocolEnum m_Protocol = Bosch.VideoSDK.StreamingProtocolEnum.speTCP;
		public bool m_liveVideoPropertiesChanged = false;
		private Font m_treeFontConnected = new Font("Arial", 8, FontStyle.Bold);
		private Font m_treeFontDisconnected = new Font("Arial", 8, FontStyle.Regular);
		private Font m_treeFontUnavailable = new Font("Arial", 8, FontStyle.Bold | FontStyle.Italic);
		private Bosch.VideoSDK.GCALib._IDeviceProxyEvents_ConnectionStateChangedEventHandler m_eventHandler = null;

		public DeviceTreeNode(string text)
		{
			this.Text = text;			
		}

		public void SetDeviceProxy(Bosch.VideoSDK.Device.DeviceProxy deviceProxy)
		{
			m_deviceProxy = deviceProxy;
			m_bConnected = true;

			// Initialize the Live Video properties from the First video Input
			if (m_deviceProxy.VideoInputs.Count > 0)
			{
				Bosch.VideoSDK.DataStream dataStream = m_deviceProxy.VideoInputs[1].Stream;

				try
				{
					m_coding	= dataStream.Coding;
					m_multicast	= dataStream.Multicast;
					m_Protocol	= dataStream.Protocol;
				} 
				catch
				{
					// Divar will return NOT IMPLEMENTED for the protocol property
				}
			}

			if (m_eventHandler == null)
				m_eventHandler = new Bosch.VideoSDK.GCALib._IDeviceProxyEvents_ConnectionStateChangedEventHandler(OnConnectionStateChanged);

			m_deviceProxy.ConnectionStateChanged += m_eventHandler;
		}

		public Bosch.VideoSDK.Device.DeviceProxy GetDeviceProxy()
		{
			return m_deviceProxy;
		}

		public void Disconnect()
		{
			if (m_deviceProxy != null && m_bConnected)
			{
				NodeFont = m_treeFontDisconnected;
				m_deviceProxy.Disconnect();
				Cleanup();
			}
		}
		public void OnConnectionStateChanged(object o, Bosch.VideoSDK.Device.ConnectResultEnum connectResult)
		{
			switch (connectResult) 
			{
				case Bosch.VideoSDK.Device.ConnectResultEnum.creConnected:
				{
					NodeFont = m_treeFontConnected;
					this.Text = this.Text.Trim();
					break;
				}

				case Bosch.VideoSDK.Device.ConnectResultEnum.creInitialized:
				{
					NodeFont = m_treeFontConnected;
					this.Text = this.Text.Trim();
					break;
				}

				case Bosch.VideoSDK.Device.ConnectResultEnum.creConnectionLost: 	
				{
					NodeFont = m_treeFontUnavailable;
					break; 
				}

				default:
				{
					NodeFont = m_treeFontDisconnected;
					Cleanup();
					break;
				}
			}
		}

		public override void Cleanup()
		{
			if (m_deviceProxy != null)
			{
				//m_deviceProxy.ConnectionStateChanged -= m_eventHandler;
				m_deviceProxy = null;
			}

			m_eventHandler = null;

			m_bConnected = false;

			base.Cleanup();
		}
	}
}
