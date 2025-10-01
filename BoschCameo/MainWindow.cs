using Bosch.VideoSDK;
using Bosch.VideoSDK.GCALib;
using Bosch.VideoSDK.Live;
using CSharpRuntimeCameo.network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TCameoMainWindow
{
	public partial class MainWindow : Form
	{
		private enum HRESULT : uint
		{
			S_OK = 0,
			E_FAIL = 0x80004005,
			E_UNEXPECTED = 0x8000FFFF,
			E_NOTIMPL = 0x80004001,
			E_INVALIDARG = 0x80070057,
			IgnoreAndFixLater = 0xFFFFFFFF
		};

		private enum State
		{
			Disconnected,
			Connecting,
			Connected,
			Disconnecting
		}


        private State m_state = State.Disconnected;

        Bosch.VideoSDK.Device.DeviceFinderClass m_deviceFinder = null;

        private Bosch.VideoSDK.Device.DeviceConnector m_deviceConnector = new Bosch.VideoSDK.Device.DeviceConnectorClass();
        private Bosch.VideoSDK.Device.DeviceProxy m_deviceProxy = null;
        private Bosch.VideoSDK.AxCameoLib.AxCameo m_axCameo = null;
        private Bosch.VideoSDK.CameoLib.Cameo m_cameo = null;

        private MyObject myObjectSelected = null;


        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
		{
			InitializeComponent();
		}


        private void MainWindow_Load(object sender, EventArgs e)
		{
			m_axCameo = new Bosch.VideoSDK.AxCameoLib.AxCameo();
			panelCameo.Controls.Add(m_axCameo);
			m_axCameo.Dock = DockStyle.Fill;
			m_cameo = (Bosch.VideoSDK.CameoLib.Cameo)m_axCameo.GetOcx();
			
			m_deviceConnector.ConnectResult += new Bosch.VideoSDK.GCALib._IDeviceConnectorEvents_ConnectResultEventHandler(DeviceConnector_ConnectResult);
			
            comboBoxProgID.SelectedIndex = 0;
            comboBoxStreamEncoder.SelectedIndex = 0;
            comboBoxStreamProtocol.SelectedIndex = 0;   
            comboBoxVideoInput.SelectedIndex = 0;   

            UpdateGUI();

			textBoxUrl.Text = "[user[:pass@]]address";
			textBoxUrl.Focus();
			textBoxUrl.SelectAll();

			try
            {
                Bosch.VideoSDK.Core core = new Bosch.VideoSDK.Core();
                IHardwareDecodingProperties ihdp = (IHardwareDecodingProperties)core;
				this.checkBoxHWAcceleration.Checked = ihdp.HardwareDecodingEnabled;
			}
            catch (Exception)
            {
				MessageBox.Show(this, "Cannot determine SDK HW acceleration mode.");
			}

			this.checkBoxHWAcceleration.Enabled = false;
		}

		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			if ((m_state == State.Connecting) || (m_state == State.Disconnecting))
				e.Cancel = true;
		}

		private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			m_deviceConnector.ConnectResult -= new Bosch.VideoSDK.GCALib._IDeviceConnectorEvents_ConnectResultEventHandler(DeviceConnector_ConnectResult);
			if (m_state == State.Connected)
			{
				m_deviceProxy.ConnectionStateChanged -= new Bosch.VideoSDK.GCALib._IDeviceProxyEvents_ConnectionStateChangedEventHandler(DeviceProxy_ConnectionStateChanged);
				m_deviceProxy.Disconnect();
			}
			m_axCameo.Dispose();
		}

		private void ButtonConnect_Click(object sender, EventArgs e)
		{
			if (m_state == State.Disconnected)
			{
				try
				{
					Bosch.VideoSDK.Core core = new Bosch.VideoSDK.Core();
					IHardwareDecodingProperties ihdp = (IHardwareDecodingProperties)core;

					Console.WriteLine("IHardwareDecodingProperties.isHardwareDecodingEnabled? " + ihdp.HardwareDecodingEnabled);

					this.Text = textBoxUrl.Text + " (HWAcceleraX? "+ ihdp.HardwareDecodingEnabled + ")";

					m_state = State.Connecting;


                    if (this.myObjectSelected != null && this.myObjectSelected.FullUrl.Length > 0)
                    {
                        m_deviceConnector.ConnectAsync(this.myObjectSelected.FullUrl, comboBoxProgID.Text);
                    }
                    else
                    {
                        m_deviceConnector.ConnectAsync(textBoxUrl.Text, comboBoxProgID.Text);
                    }

                    this.SetCompsState(false);

                }
                catch (Exception ex)
				{
        			MessageBox.Show(this, "Cannot connect to "+ this.labelCamActive.Text + " (" + this.textBoxUrl.Text + ")");

                    m_state = State.Disconnected;
				}
			}
			else if (m_state == State.Connected)
			{
				m_state = State.Disconnecting;
				m_deviceProxy.Disconnect();

				this.Text = String.Empty;
				textBoxUrl.Focus();
				textBoxUrl.SelectAll();

                this.SetCompsState(true);

            }

			UpdateGUI();
		}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        private void SetCompsState(bool state)
        {
            this.buttonCam.Enabled = state;
            this.comboBoxProgID.Enabled = state;
            this.comboBoxStreamEncoder.Enabled = state;
            this.comboBoxStreamProtocol.Enabled = state;
            this.comboBoxVideoInput.Enabled = state;
            this.textBoxUrl.Enabled = state;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectResult"></param>
        /// <param name="url"></param>
        /// <param name="deviceProxy"></param>
		private void DeviceConnector_ConnectResult(Bosch.VideoSDK.Device.ConnectResultEnum connectResult, string url, Bosch.VideoSDK.Device.DeviceProxy deviceProxy)
		{
			bool success = false;

			if (connectResult == Bosch.VideoSDK.Device.ConnectResultEnum.creInitialized)
			{
				if (url.ToLower().IndexOf("file") == 0)
				{
					Bosch.VideoSDK.MediaDatabase.PlaybackController pc = new Bosch.VideoSDK.MediaDatabase.PlaybackController();
					Bosch.VideoSDK.MediaSession session = deviceProxy.MediaDatabase.GetMediaSession(-1, pc);

					success = true;

					try
					{
						m_cameo.SetVideoStream(session.GetVideoStream());
						pc.Play(100);
					}
					catch (Exception ex)
					{
						MessageBox.Show(this, "Failed to render file video stream...");
						success = false;
					}
				}
				else
				{
					if (deviceProxy.VideoInputs.Count > 0)
					{
						success = true;

                        try
                        {
                            int nVdoInput = comboBoxVideoInput.SelectedIndex + 1;

                            deviceProxy.VideoInputs[nVdoInput].Stream.Encoder = comboBoxStreamEncoder.SelectedIndex;
                            deviceProxy.VideoInputs[nVdoInput].Stream.Protocol =
                                (StreamingProtocolEnum)Enum.GetValues(typeof(StreamingProtocolEnum)).GetValue(comboBoxStreamProtocol.SelectedIndex);

                            m_cameo.SetVideoStream(deviceProxy.VideoInputs[nVdoInput].Stream);
						}
						catch (Exception ex)
						{
                            MessageBox.Show(this, "Failed to render video stream...");
							success = false;
                            this.SetCompsState(true);
                        }
					}
				}
			}

			if (success)
			{
				m_deviceProxy = deviceProxy;
				m_deviceProxy.ConnectionStateChanged += new Bosch.VideoSDK.GCALib._IDeviceProxyEvents_ConnectionStateChangedEventHandler(DeviceProxy_ConnectionStateChanged);
				m_state = State.Connected;
			}
			else
			{
				if (deviceProxy != null)
				{
					deviceProxy.Disconnect();
				}

				m_state = State.Disconnected;
				MessageBox.Show(this, "Failed to connect to " + this.labelCamActive.Text + " (" + this.textBoxUrl.Text + ")");
            }

			UpdateGUI();
		}

		private void DeviceProxy_ConnectionStateChanged(object eventSource, Bosch.VideoSDK.Device.ConnectResultEnum state)
		{
			if (state == Bosch.VideoSDK.Device.ConnectResultEnum.creConnectionTerminated)
			{
				m_cameo.SetVideoStream(null);
				m_deviceProxy.ConnectionStateChanged -= new Bosch.VideoSDK.GCALib._IDeviceProxyEvents_ConnectionStateChangedEventHandler(DeviceProxy_ConnectionStateChanged);
				m_deviceProxy = null;
				m_state = State.Disconnected;

				UpdateGUI();
			}
		}

		private void TextBoxUrl_KeyDown(object sender, KeyEventArgs e)
		{
			if (((e.KeyCode == Keys.Return) || (e.KeyCode == Keys.Enter)) && bttConnect.Enabled)
				ButtonConnect_Click(this, EventArgs.Empty);
		}

		private void TextBoxUrl_TextChanged(object sender, EventArgs e)
		{
			UpdateGUI();
		}

		private void UpdateGUI()
		{
			if (m_state == State.Disconnected)
			{
				bttConnect.Text = "Connect";
				bttConnect.Enabled = (textBoxUrl.Text.Length > 0);
			}
			else if (m_state == State.Connecting)
			{
				bttConnect.Text = "Connecting";
				bttConnect.Enabled = false;
				checkBoxHWAcceleration.Enabled = false;
			}
			else if (m_state == State.Connected)
			{
				bttConnect.Text = "Disconnect";
				bttConnect.Enabled = true;
				checkBoxHWAcceleration.Enabled = false;
			}
			else // if (m_state == State.Disconnecting)
			{
				bttConnect.Text = "Disconnecting";
				bttConnect.Enabled = false;
				checkBoxHWAcceleration.Enabled = false;
			}
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCam_Click(object sender, EventArgs e)
        {
            new CamerasChooser(this).ShowDialog(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myObject"></param>
        internal void ProcessCameraSelection(MyObject myObject)
        {
            this.myObjectSelected = myObject;

            if (myObject != null)
            {
                this.labelCamActive.Text = "Camera: "+ myObject.TreeName + " (" + myObject.StationName + ")";

                try
                {
                    this.comboBoxVideoInput.SelectedIndex = myObject.CameraInput - 1;
                    this.comboBoxStreamEncoder.SelectedIndex = myObject.LiveStream /*- 1*/;
                }
                catch(Exception e)
                {
                    ;                       
                }

                if (myObject.UserName.Length > 0)
                {
                    if (myObject.Password.Length > 0)
                    {
                        textBoxUrl.Text = myObject.UserName + ":" +
                            "********" + //myObject.Password + 
                            "@" + myObject.Address;
                    }
                    else
                    {
                        textBoxUrl.Text = myObject.UserName + "@" + myObject.Address;
                    }
                }
                else
                {
                    textBoxUrl.Text = myObject.Address;
                }

                //comboBoxProgID.Text = myObject.ProgID;
            }
            else
            {
                this.labelCamActive.Text = "Camera: ...";
            }
        }
    }
}
