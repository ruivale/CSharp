using Bosch.VideoSDK;
using Bosch.VideoSDK.AxCameoLib;
using Bosch.VideoSDK.Device;
using Bosch.VideoSDK.GCALib;
using Bosch.VideoSDK.Live;
using CSharpRuntimeCameo;
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
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TCameoMainWindow
{
	public partial class MainWindow : Form
	{
        public enum HRESULT : uint
        {
            S_OK = 0,
            E_FAIL = 0x80004005,
            E_UNEXPECTED = 0x8000FFFF,
            E_NOTIMPL = 0x80004001,
            E_INVALIDARG = 0x80070057,
            Other = 0xFFFFFFFE,
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Load(object sender, EventArgs e)
		{
			m_axCameo = new Bosch.VideoSDK.AxCameoLib.AxCameo();
			panelCameo.Controls.Add(m_axCameo);
			m_axCameo.Dock = DockStyle.Fill;
			m_cameo = (Bosch.VideoSDK.CameoLib.Cameo)m_axCameo.GetOcx();
			
			m_deviceConnector.ConnectResult += 
                new Bosch.VideoSDK.GCALib._IDeviceConnectorEvents_ConnectResultEventHandler(DeviceConnectorEvents_ConnectResultEventHandler);

            m_axCameo.VideoStatus += 
                new Bosch.VideoSDK.AxCameoLib._ICameoEvents_VideoStatusEventHandler(CameoEvents_VideoStatusEventHandler);
            m_axCameo.InformationChanged += 
                new Bosch.VideoSDK.AxCameoLib._ICameoEvents_InformationChangedEventHandler(CameoEvents_InformationChangedEventHandler);

            comboBoxProgID.SelectedIndex = 0;
            comboBoxStreamEncoder.SelectedIndex = 0;
            comboBoxStreamProtocol.SelectedIndex = 0;   
            comboBoxVideoInput.SelectedIndex = 0;   
            checkBoxMulticast.Checked = false;
            checkBoxHttp.Checked = false;
            checkBoxHttps.Checked = false;
            comboBoxCoding.SelectedIndex = comboBoxCoding.Items.Count - 1; // last is "Default"  

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
            catch (Exception exc)
            {
                Log.WriteLog(
                        Application.StartupPath + @"\" + Log.LOGFILENAME,
                        "Cannot determine SDK HW acceleration mode. Msg: " + exc.Message+"\n"+exc.StackTrace); 
                MessageBox.Show(this, "Cannot determine SDK HW acceleration mode.");
			}

			this.checkBoxHWAcceleration.Enabled = false;
		}



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			if ((m_state == State.Connecting) || (m_state == State.Disconnecting))
				e.Cancel = true;
		}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			m_deviceConnector.ConnectResult -= 
                new Bosch.VideoSDK.GCALib._IDeviceConnectorEvents_ConnectResultEventHandler(
                    DeviceConnectorEvents_ConnectResultEventHandler);

			if (m_state == State.Connected)
			{
				m_deviceProxy.ConnectionStateChanged -= 
                    new Bosch.VideoSDK.GCALib._IDeviceProxyEvents_ConnectionStateChangedEventHandler(
                        DeviceProxyEvents_ConnectionStateChangedEventHandler);
				m_deviceProxy.Disconnect();
			}

			m_axCameo.Dispose();
		}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void ButtonConnect_Click(object sender, EventArgs e)
		{
			if (m_state == State.Disconnected)
			{
				try
				{
					Bosch.VideoSDK.Core core = new Bosch.VideoSDK.Core();
					IHardwareDecodingProperties ihdp = (IHardwareDecodingProperties)core;

					Console.WriteLine("IHardwareDecodingProperties.isHardwareDecodingEnabled? " + ihdp.HardwareDecodingEnabled);
                    Log.WriteLog(
                            Application.StartupPath + @"\" + Log.LOGFILENAME,
                            "IHardwareDecodingProperties.isHardwareDecodingEnabled ? " + ihdp.HardwareDecodingEnabled);

                    this.Text = textBoxUrl.Text + " (HWAcceleraX? "+ ihdp.HardwareDecodingEnabled + ")";

					m_state = State.Connecting;


                    string strUrl =
                        this.checkBoxHttp.Checked ?
                                "http://" :
                                this.checkBoxHttps.Checked ?
                                    "https://" :
                                    string.Empty;

                    if (this.myObjectSelected != null && this.myObjectSelected.FullUrl.Length > 0)
                    {
                        strUrl += this.myObjectSelected.FullUrl;

                        m_deviceConnector.ConnectAsync(strUrl, comboBoxProgID.Text);
                    }
                    else
                    {
                        strUrl += textBoxUrl.Text;

                        m_deviceConnector.ConnectAsync(textBoxUrl.Text, comboBoxProgID.Text);
                    }

                    Log.WriteLog(
                            Application.StartupPath + @"\" + Log.LOGFILENAME,
                            $"Trying to ConnectAsync({strUrl}, {comboBoxProgID.Text})...");

                    this.SetCompsState(false);

                }
                catch (Exception exc)
				{
                    Log.WriteLog(
                            Application.StartupPath + @"\" + Log.LOGFILENAME,
                            "Cannot connect to " + this.labelCamActive.Text + " (" + this.textBoxUrl.Text + ") Msg: " + exc.Message + "\n" + exc.StackTrace);
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
            this.comboBoxCoding.Enabled = state;
            this.checkBoxMulticast.Enabled = state;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectResult"></param>
        /// <param name="url"></param>
        /// <param name="deviceProxy"></param>
		private void DeviceConnectorEvents_ConnectResultEventHandler(
                Bosch.VideoSDK.Device.ConnectResultEnum connectResult, 
                string url, 
                Bosch.VideoSDK.Device.DeviceProxy deviceProxy)
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
					catch (Exception exc)
					{
                        Log.WriteLog(
                                Application.StartupPath + @"\" + Log.LOGFILENAME,
                                "Failed to render file video stream. Msg: " + exc.Message + "\n" + exc.StackTrace);
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

                            // Encoder
                            deviceProxy.VideoInputs[nVdoInput].Stream.Encoder = comboBoxStreamEncoder.SelectedIndex;
                            int iEncoderSet = deviceProxy.VideoInputs[nVdoInput].Stream.Encoder;


                            // Coding
                            if (comboBoxCoding.SelectedIndex < comboBoxCoding.Items.Count - 1) // last is "Default"
                            {
                                try
                                {
                                    deviceProxy.VideoInputs[nVdoInput].Stream.Coding =
                                        (CodingEnum)Enum.GetValues(typeof(CodingEnum)).GetValue(comboBoxCoding.SelectedIndex);
                                }
                                catch (Exception exc)
                                {
                                    Log.WriteLog(
                                            Application.StartupPath + @"\" + Log.LOGFILENAME,
                                            "Failed to set DataStream.Coding to "+ comboBoxCoding.SelectedValue +
                                            ". Msg: " + exc.Message + "\n" + exc.StackTrace);
                                }
                            }
                            CodingEnum coding = deviceProxy.VideoInputs[nVdoInput].Stream.Coding;


                            // Protocol
                            deviceProxy.VideoInputs[nVdoInput].Stream.Protocol =
                                (StreamingProtocolEnum)Enum.GetValues(typeof(StreamingProtocolEnum)).GetValue(comboBoxStreamProtocol.SelectedIndex);
                            StreamingProtocolEnum streamingProtocol = deviceProxy.VideoInputs[nVdoInput].Stream.Protocol;


                            // Multicast    
                            deviceProxy.VideoInputs[nVdoInput].Stream.Multicast = this.checkBoxMulticast.Checked;
                            bool isMulticast = deviceProxy.VideoInputs[nVdoInput].Stream.Multicast;


                            Log.WriteLog(
                                    Application.StartupPath + @"\" + Log.LOGFILENAME,
                                    $"Setting Cameo DataStream(VdoInput: {nVdoInput}, Encoder: {iEncoderSet}, " +
                                        $"Coding: {coding}, Multicast: {isMulticast}, Protocol: {streamingProtocol})");

                            deviceProxy.VideoInputs[nVdoInput].Stream.ConnectionStateChanged +=
                                new Bosch.VideoSDK.GCALib._IDataStreamEvents_ConnectionStateChangedEventHandler(
                                    DataStreamEvents_ConnectionStateChangedEventHandler);
                            deviceProxy.VideoInputs[nVdoInput].Stream.Disconnected += 
                                new Bosch.VideoSDK.GCALib._IDataStreamEvents_DisconnectedEventHandler(
                                    DataStreamEvents_DisconnectedEventHandler);

                            m_cameo.SetVideoStream(deviceProxy.VideoInputs[nVdoInput].Stream);
						}
						catch (Exception exc)
						{
                            HRESULT hr = CheckException(exc, "{0}: Failed to set datastream encoder and/or coding and/or protocol!", url);

                            Log.WriteLog(
                                    Application.StartupPath + @"\" + Log.LOGFILENAME,
                                    "Failed to render video stream. Msg: " + exc.Message + "\n" + exc.StackTrace);

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
				m_deviceProxy.ConnectionStateChanged += 
                    new Bosch.VideoSDK.GCALib._IDeviceProxyEvents_ConnectionStateChangedEventHandler(
                        DeviceProxyEvents_ConnectionStateChangedEventHandler);
				m_state = State.Connected;
			}
			else
			{
				if (deviceProxy != null)
				{
					deviceProxy.Disconnect();
				}

				m_state = State.Disconnected;

                Log.WriteLog(
                        Application.StartupPath + @"\" + Log.LOGFILENAME,
                         "Failed to connect to " + this.labelCamActive.Text + " (" + this.textBoxUrl.Text + ")");

                MessageBox.Show(this, "Failed to connect to " + this.labelCamActive.Text + " (" + this.textBoxUrl.Text + ")");

                this.SetCompsState(true);
            }

			UpdateGUI();
		}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDataStream"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void DataStreamEvents_DisconnectedEventHandler(DataStream pDataStream)
        {
            Log.WriteLog(
                    Application.StartupPath + @"\" + Log.LOGFILENAME,
                    "DataStreamEvents_DisconnectedEventHandler: " + GetPrintableDataStream(pDataStream));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDataStream"></param>
        /// <param name="State"></param>
        private void DataStreamEvents_ConnectionStateChangedEventHandler(DataStream pDataStream, ConnectResultEnum state)
        {
            Log.WriteLog(
                    Application.StartupPath + @"\" + Log.LOGFILENAME,
                    "DataStreamEvents_ConnectionStateChangedEventHandler: " + 
                        GetPrintableDataStream(pDataStream) + " State:" + state);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDataStream"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private string GetPrintableDataStream(DataStream pDataStream)
        {
            if(pDataStream == null)
            {
                return "DataStream is null";
            }   

            StringBuilder sb = new StringBuilder("DataStream(");

            try
            {
                sb.Append("coding:" + pDataStream.Coding);
                sb.Append(" encoder:" + pDataStream.Encoder);
                sb.Append(" keyframemode:" + pDataStream.KeyFrameMode);
                sb.Append(" mediatype:" + pDataStream.MediaType);
                sb.Append(" Multicast?" + pDataStream.Multicast);
                sb.Append(" Protocol:" + pDataStream.Protocol);
            }
            catch (Exception exc)
            {
                Log.WriteLog(
                        Application.StartupPath + @"\" + Log.LOGFILENAME,
                        "Failed to obtain Datastream info. Msg: " + exc.Message + "\n" + exc.StackTrace);
            }

            return sb.Append(")").ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventSource"></param>
        /// <param name="state"></param>
        private void DeviceProxyEvents_ConnectionStateChangedEventHandler(object eventSource, ConnectResultEnum state)
		{

            Log.WriteLog(
                    Application.StartupPath + @"\" + Log.LOGFILENAME,
                    "DeviceProxy_ConnectionStateChanged: " + state);

            if (state == ConnectResultEnum.creConnectionTerminated)
			{
				m_cameo.SetVideoStream(null);
				m_deviceProxy.ConnectionStateChanged -= 
                    new Bosch.VideoSDK.GCALib._IDeviceProxyEvents_ConnectionStateChangedEventHandler(
                        DeviceProxyEvents_ConnectionStateChangedEventHandler);
				m_deviceProxy = null;
				m_state = State.Disconnected;

				UpdateGUI();
			}
		}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="vdoStatusEvt"></param>
        private void CameoEvents_VideoStatusEventHandler(object sender, _ICameoEvents_VideoStatusEvent vdoStatusEvt)
        {
            Log.WriteLog(
                    Application.StartupPath + @"\" + Log.LOGFILENAME,
                    "AxCameo_VideoStatus: VideoStatusEvent(" +                         
                        "\"" + vdoStatusEvt.status.ToString() +
                        "\"(" + ((int)vdoStatusEvt.status) + "), p1: " +vdoStatusEvt.param1+", p2: "+vdoStatusEvt.param2+")");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="infoChangedEvt"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void CameoEvents_InformationChangedEventHandler(object sender, _ICameoEvents_InformationChangedEvent infoChangedEvt)
        {
            Log.WriteLog(
                    Application.StartupPath + @"\" + Log.LOGFILENAME,
                    "AxCameo_InformationChanged: " + GetPrintableInfoChangedEvent(infoChangedEvt));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="infoChangedEvt"></param>
        /// <returns></returns>
        private string GetPrintableInfoChangedEvent(_ICameoEvents_InformationChangedEvent infoChangedEvt)
        {
            if(infoChangedEvt == null || infoChangedEvt.info == null)
            {
                return "InformationChangedEvent or InformationChangedEvent.info is null";

            }
            StringBuilder sb = new StringBuilder("InformationChangedEvent(");

            try
            {
                CodingEnum coding =
                    (CodingEnum)Enum.GetValues(typeof(CodingEnum)).GetValue(infoChangedEvt.info.Coding);

                sb.Append("name:\"" + infoChangedEvt.info.CameraName);
                sb.Append("\" coding:" + coding +"(" + infoChangedEvt.info.Coding + ")");
                sb.Append(" discontinuity:" + infoChangedEvt.info.Discontinuity);
                sb.Append(" time:" + infoChangedEvt.info.Time);
                sb.Append(" authstt:" + infoChangedEvt.info.AuthenticationStatus);
                sb.Append(" cmprssrtio:" + infoChangedEvt.info.CompressionRatio);
                sb.Append(" device:" + infoChangedEvt.info.DeviceName);
                sb.Append(" flags:" + infoChangedEvt.info.Flags);
                sb.Append(" mac:" + infoChangedEvt.info.MacAddress);
                sb.Append(" zone:" + infoChangedEvt.info.TimeZoneOffset);
                sb.Append(" uid:" + infoChangedEvt.info.UniqueID);
            }
            catch (Exception exc)
            {
                Log.WriteLog(
                        Application.StartupPath + @"\" + Log.LOGFILENAME,
                        "Failed to obtain ICameoEvents_InformationChangedEvent info. Msg: " + exc.Message + "\n" + exc.StackTrace);
            }

            return sb.Append(")").ToString();

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxUrl_KeyDown(object sender, KeyEventArgs e)
		{
            if (((e.KeyCode == Keys.Return) || (e.KeyCode == Keys.Enter)) && bttConnect.Enabled)
            {
                ButtonConnect_Click(this, EventArgs.Empty);
            }
		}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void TextBoxUrl_TextChanged(object sender, EventArgs e)
		{
			UpdateGUI();
		}


        /// <summary>
        /// 
        /// </summary>
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="exc"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static HRESULT CheckException(Exception exc, string format, params object[] args)
        {
            string message = string.Format(format, args) + ": " + exc.Message;
            
            Log.WriteLog(Application.StartupPath + @"\" + Log.LOGFILENAME, message);

            if (exc.GetType() == typeof(System.Runtime.InteropServices.COMException))
            {
                uint errorCode = (uint)((System.Runtime.InteropServices.COMException)exc).ErrorCode;

                if (errorCode == (uint)HRESULT.E_FAIL)
                {
                    Log.WriteLog(
                        Application.StartupPath + @"\" + Log.LOGFILENAME,
                        "E_FAIL exception must be handled in application at runtime.");

                    return HRESULT.E_FAIL;
                }
                else if (errorCode == (uint)HRESULT.E_UNEXPECTED)
                {
                    Log.WriteLog(
                        Application.StartupPath + @"\" + Log.LOGFILENAME,
                        "E_UNEXPECTED exception must be resolved in application code.");
                }
            }
            else if (exc.GetType() == typeof(System.NotImplementedException))
            {
                Log.WriteLog(
                    Application.StartupPath + @"\" + Log.LOGFILENAME,
                    "E_NOTIMPL exception will be handled in application at runtime.");

                return HRESULT.E_NOTIMPL;
            }
            else if (exc.GetType() == typeof(System.ArgumentException))
            {
                Log.WriteLog(
                    Application.StartupPath + @"\" + Log.LOGFILENAME, 
                    "E_INVALIDARG exception must be resolved in application code.");
            }

            if (MessageBox.Show(message + "\n\nTerminate application?", "Unexpected Exception", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                Log.WriteLog(
                    Application.StartupPath + @"\" + Log.LOGFILENAME, 
                    "Terminating application after unexpected exception. Issue has to be resolved either in application code or in VideoSDK code.");
                
                throw exc;
            }
            else
            {
                Log.WriteLog(
                    Application.StartupPath + @"\" + Log.LOGFILENAME, 
                    "Ignoring unexpected exception. Issue has to be resolved either in application code or in VideoSDK code.");

                return HRESULT.IgnoreAndFixLater;
            }
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static HRESULT GetHRESULT(Exception e)
        {
            if (e.GetType() == typeof(System.Runtime.InteropServices.COMException))
            {
                uint errorCode = (uint)((System.Runtime.InteropServices.COMException)e).ErrorCode;
            
                if (errorCode == (uint)HRESULT.E_FAIL)
                {
                    return HRESULT.E_FAIL;
                }
                else if (errorCode == (uint)HRESULT.E_UNEXPECTED)
                {
                    return HRESULT.E_UNEXPECTED;
                }
            }
            else if (e.GetType() == typeof(System.NotImplementedException))
            {
                return HRESULT.E_NOTIMPL;
            }
            else if (e.GetType() == typeof(System.ArgumentException))
            {
                return HRESULT.E_INVALIDARG;
            }

            return HRESULT.Other;
        }

        private void checkBoxHttp_Click(object sender, EventArgs e)
        {
            this.checkBoxHttps.Checked = false;
        }

        private void checkBoxHttps_Click(object sender, EventArgs e)
        {
            this.checkBoxHttp.Checked = false;  
        }
    }
}
