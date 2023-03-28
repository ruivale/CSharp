using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// Summary description for CameraControllerForm.
	/// </summary>
	public class CameraControllerForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button m_ptzButton;
		private System.Windows.Forms.Button m_stopButton;
		private System.Windows.Forms.TextBox m_panSpeedText;
		private System.Windows.Forms.TextBox m_tiltSpeedText;
		private System.Windows.Forms.TextBox m_zoomSpeedText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button m_setupControllerButton;
		private System.Windows.Forms.DataGrid m_paramGrid;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox m_modelCombo;
		private System.Windows.Forms.Button m_setParametersButton;
		private System.Windows.Forms.Button m_auxOnButton;
		private System.Windows.Forms.Button m_auxOffButton;
		private System.Windows.Forms.ComboBox m_auxDropDown;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button m_focusGoButton;
		private System.Windows.Forms.Button m_focusStopButton;
		private System.Windows.Forms.TextBox m_focusSpeedText;
		private System.Windows.Forms.Button m_irisStopButton;
		private System.Windows.Forms.Button m_irisGoButton;
		private System.Windows.Forms.TextBox m_irisSpeedText;

		// Data members
		private Bosch.VideoSDK.Live.CameraController m_cameraController = null;
		private Bosch.VideoSDK.Live.PTZModeEnum m_ptzMode = Bosch.VideoSDK.Live.PTZModeEnum.ptzNormalized;
		private MainForm m_mainForm = null;
		private System.Windows.Forms.RadioButton m_absRadio;
		private System.Windows.Forms.RadioButton m_normRadio;
		private System.Windows.Forms.TextBox m_panMaxText;
		private System.Windows.Forms.TextBox m_tiltMaxText;
		private System.Windows.Forms.TextBox m_zoomMaxText;
		private System.Windows.Forms.Button m_PreSetGotoButton;
		private System.Windows.Forms.TextBox m_preSetText;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Button m_PreSetSetButton;
		private System.Windows.Forms.Button m_sendDataButton;
		private System.Windows.Forms.TextBox m_sendDataText;
		private DataTable m_paramTable = null;

		public CameraControllerForm(Bosch.VideoSDK.Live.CameraController cameraController, MainForm mainForm)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_mainForm = mainForm;

			this.Height = this.Height / 3 * 2;

			m_cameraController = cameraController;

			try
			{
				foreach (string modelName in m_cameraController.ModelNames)
					m_modelCombo.Items.Add(modelName);
			}
			catch
			{
			}

			try
			{
				if (m_cameraController.IsControllable)
				{
					foreach (Bosch.VideoSDK.Live.AuxCommand auxCommand in m_cameraController.AuxCommands)
						m_auxDropDown.Items.Add(auxCommand.Description);
				}
			}
			catch
			{
			}

			// Initialize the parameter data grid.
			m_paramTable = new DataTable();
			m_paramTable.Columns.Add(new DataColumn("Parameter", typeof(string)));
			m_paramTable.Columns.Add(new DataColumn("Value", typeof(string)));
			m_paramGrid.DataSource = m_paramTable;

			// Default PTZ mode to normalized.
			m_ptzMode = Bosch.VideoSDK.Live.PTZModeEnum.ptzNormalized;
			m_normRadio.Checked = true;

			EvaluateControllableFlag();
		}

		public void EvaluateControllableFlag()
		{
			m_ptzButton.Enabled = m_cameraController.IsControllable;
			m_stopButton.Enabled = m_cameraController.IsControllable;
			m_auxOnButton.Enabled = m_cameraController.IsControllable;
			m_auxOffButton.Enabled = m_cameraController.IsControllable;
			m_auxDropDown.Enabled = m_cameraController.IsControllable;
			m_focusGoButton.Enabled = m_cameraController.IsControllable;
			m_focusStopButton.Enabled = m_cameraController.IsControllable;
			m_irisGoButton.Enabled = m_cameraController.IsControllable;
			m_irisStopButton.Enabled = m_cameraController.IsControllable;
			//m_setupControllerButton.Enabled = !m_cameraController.IsControllable;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_ptzButton = new System.Windows.Forms.Button();
			this.m_stopButton = new System.Windows.Forms.Button();
			this.m_panSpeedText = new System.Windows.Forms.TextBox();
			this.m_tiltSpeedText = new System.Windows.Forms.TextBox();
			this.m_zoomSpeedText = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.m_setupControllerButton = new System.Windows.Forms.Button();
			this.m_paramGrid = new System.Windows.Forms.DataGrid();
			this.label4 = new System.Windows.Forms.Label();
			this.m_modelCombo = new System.Windows.Forms.ComboBox();
			this.m_setParametersButton = new System.Windows.Forms.Button();
			this.m_auxOnButton = new System.Windows.Forms.Button();
			this.m_auxOffButton = new System.Windows.Forms.Button();
			this.m_auxDropDown = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_sendDataText = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.m_zoomMaxText = new System.Windows.Forms.TextBox();
			this.m_tiltMaxText = new System.Windows.Forms.TextBox();
			this.m_panMaxText = new System.Windows.Forms.TextBox();
			this.m_normRadio = new System.Windows.Forms.RadioButton();
			this.m_absRadio = new System.Windows.Forms.RadioButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.m_focusStopButton = new System.Windows.Forms.Button();
			this.m_focusGoButton = new System.Windows.Forms.Button();
			this.m_focusSpeedText = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.m_irisStopButton = new System.Windows.Forms.Button();
			this.m_irisGoButton = new System.Windows.Forms.Button();
			this.m_irisSpeedText = new System.Windows.Forms.TextBox();
			this.m_PreSetGotoButton = new System.Windows.Forms.Button();
			this.m_PreSetSetButton = new System.Windows.Forms.Button();
			this.m_preSetText = new System.Windows.Forms.TextBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.m_sendDataButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.m_paramGrid)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_ptzButton
			// 
			this.m_ptzButton.Location = new System.Drawing.Point(8, 24);
			this.m_ptzButton.Name = "m_ptzButton";
			this.m_ptzButton.Size = new System.Drawing.Size(48, 24);
			this.m_ptzButton.TabIndex = 0;
			this.m_ptzButton.Text = "PTZ";
			this.m_ptzButton.Click += new System.EventHandler(this.m_ptzButton_Click);
			// 
			// m_stopButton
			// 
			this.m_stopButton.Location = new System.Drawing.Point(8, 48);
			this.m_stopButton.Name = "m_stopButton";
			this.m_stopButton.Size = new System.Drawing.Size(48, 23);
			this.m_stopButton.TabIndex = 1;
			this.m_stopButton.Text = "Stop";
			this.m_stopButton.Click += new System.EventHandler(this.m_stopButton_Click);
			// 
			// m_panSpeedText
			// 
			this.m_panSpeedText.Location = new System.Drawing.Point(64, 24);
			this.m_panSpeedText.Name = "m_panSpeedText";
			this.m_panSpeedText.Size = new System.Drawing.Size(40, 20);
			this.m_panSpeedText.TabIndex = 2;
			this.m_panSpeedText.Text = "50";
			// 
			// m_tiltSpeedText
			// 
			this.m_tiltSpeedText.Location = new System.Drawing.Point(112, 24);
			this.m_tiltSpeedText.Name = "m_tiltSpeedText";
			this.m_tiltSpeedText.Size = new System.Drawing.Size(40, 20);
			this.m_tiltSpeedText.TabIndex = 3;
			this.m_tiltSpeedText.Text = "0";
			// 
			// m_zoomSpeedText
			// 
			this.m_zoomSpeedText.Location = new System.Drawing.Point(160, 24);
			this.m_zoomSpeedText.Name = "m_zoomSpeedText";
			this.m_zoomSpeedText.Size = new System.Drawing.Size(40, 20);
			this.m_zoomSpeedText.TabIndex = 4;
			this.m_zoomSpeedText.Text = "0";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(64, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Pan";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(112, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Tilt";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(160, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "Zoom";
			// 
			// m_setupControllerButton
			// 
			this.m_setupControllerButton.Location = new System.Drawing.Point(8, 240);
			this.m_setupControllerButton.Name = "m_setupControllerButton";
			this.m_setupControllerButton.Size = new System.Drawing.Size(416, 23);
			this.m_setupControllerButton.TabIndex = 11;
			this.m_setupControllerButton.Text = "Controller Setup...";
			this.m_setupControllerButton.Click += new System.EventHandler(this.m_setupControllerButton_Click);
			// 
			// m_paramGrid
			// 
			this.m_paramGrid.CaptionVisible = false;
			this.m_paramGrid.DataMember = "";
			this.m_paramGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.m_paramGrid.Location = new System.Drawing.Point(8, 304);
			this.m_paramGrid.Name = "m_paramGrid";
			this.m_paramGrid.Size = new System.Drawing.Size(416, 72);
			this.m_paramGrid.TabIndex = 16;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 272);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 16);
			this.label4.TabIndex = 15;
			this.label4.Text = "Camera Model:";
			// 
			// m_modelCombo
			// 
			this.m_modelCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_modelCombo.Location = new System.Drawing.Point(96, 272);
			this.m_modelCombo.Name = "m_modelCombo";
			this.m_modelCombo.Size = new System.Drawing.Size(328, 21);
			this.m_modelCombo.TabIndex = 14;
			this.m_modelCombo.SelectedIndexChanged += new System.EventHandler(this.m_modelCombo_SelectedIndexChanged);
			// 
			// m_setParametersButton
			// 
			this.m_setParametersButton.Location = new System.Drawing.Point(8, 384);
			this.m_setParametersButton.Name = "m_setParametersButton";
			this.m_setParametersButton.Size = new System.Drawing.Size(416, 23);
			this.m_setParametersButton.TabIndex = 17;
			this.m_setParametersButton.Text = "Commit Parameters";
			this.m_setParametersButton.Click += new System.EventHandler(this.m_setParametersButton_Click);
			// 
			// m_auxOnButton
			// 
			this.m_auxOnButton.Location = new System.Drawing.Point(16, 112);
			this.m_auxOnButton.Name = "m_auxOnButton";
			this.m_auxOnButton.Size = new System.Drawing.Size(32, 23);
			this.m_auxOnButton.TabIndex = 18;
			this.m_auxOnButton.Text = "ON";
			this.m_auxOnButton.Click += new System.EventHandler(this.m_auxOnButton_Click);
			// 
			// m_auxOffButton
			// 
			this.m_auxOffButton.Location = new System.Drawing.Point(48, 112);
			this.m_auxOffButton.Name = "m_auxOffButton";
			this.m_auxOffButton.Size = new System.Drawing.Size(40, 23);
			this.m_auxOffButton.TabIndex = 19;
			this.m_auxOffButton.Text = "OFF";
			this.m_auxOffButton.Click += new System.EventHandler(this.m_auxOffButton_Click);
			// 
			// m_auxDropDown
			// 
			this.m_auxDropDown.Location = new System.Drawing.Point(96, 112);
			this.m_auxDropDown.Name = "m_auxDropDown";
			this.m_auxDropDown.Size = new System.Drawing.Size(320, 21);
			this.m_auxDropDown.TabIndex = 20;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_sendDataText);
			this.groupBox1.Location = new System.Drawing.Point(8, 96);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(416, 72);
			this.groupBox1.TabIndex = 21;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Aux Commands";
			// 
			// m_sendDataText
			// 
			this.m_sendDataText.Location = new System.Drawing.Point(88, 40);
			this.m_sendDataText.Name = "m_sendDataText";
			this.m_sendDataText.Size = new System.Drawing.Size(320, 20);
			this.m_sendDataText.TabIndex = 0;
			this.m_sendDataText.Text = "<enter hex string>";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.m_zoomMaxText);
			this.groupBox2.Controls.Add(this.m_tiltMaxText);
			this.groupBox2.Controls.Add(this.m_panMaxText);
			this.groupBox2.Controls.Add(this.m_normRadio);
			this.groupBox2.Controls.Add(this.m_ptzButton);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.m_zoomSpeedText);
			this.groupBox2.Controls.Add(this.m_tiltSpeedText);
			this.groupBox2.Controls.Add(this.m_panSpeedText);
			this.groupBox2.Controls.Add(this.m_stopButton);
			this.groupBox2.Controls.Add(this.m_absRadio);
			this.groupBox2.Location = new System.Drawing.Point(8, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(416, 72);
			this.groupBox2.TabIndex = 22;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "PTZ";
			// 
			// m_zoomMaxText
			// 
			this.m_zoomMaxText.Enabled = false;
			this.m_zoomMaxText.Location = new System.Drawing.Point(160, 48);
			this.m_zoomMaxText.Name = "m_zoomMaxText";
			this.m_zoomMaxText.Size = new System.Drawing.Size(40, 20);
			this.m_zoomMaxText.TabIndex = 12;
			this.m_zoomMaxText.Text = "";
			// 
			// m_tiltMaxText
			// 
			this.m_tiltMaxText.Enabled = false;
			this.m_tiltMaxText.Location = new System.Drawing.Point(112, 48);
			this.m_tiltMaxText.Name = "m_tiltMaxText";
			this.m_tiltMaxText.Size = new System.Drawing.Size(40, 20);
			this.m_tiltMaxText.TabIndex = 11;
			this.m_tiltMaxText.Text = "";
			// 
			// m_panMaxText
			// 
			this.m_panMaxText.Enabled = false;
			this.m_panMaxText.Location = new System.Drawing.Point(64, 48);
			this.m_panMaxText.Name = "m_panMaxText";
			this.m_panMaxText.Size = new System.Drawing.Size(40, 20);
			this.m_panMaxText.TabIndex = 10;
			this.m_panMaxText.Text = "";
			// 
			// m_normRadio
			// 
			this.m_normRadio.Location = new System.Drawing.Point(248, 16);
			this.m_normRadio.Name = "m_normRadio";
			this.m_normRadio.Size = new System.Drawing.Size(80, 24);
			this.m_normRadio.TabIndex = 9;
			this.m_normRadio.Text = "Normalized";
			this.m_normRadio.CheckedChanged += new System.EventHandler(this.m_normRadio_CheckedChanged);
			// 
			// m_absRadio
			// 
			this.m_absRadio.Location = new System.Drawing.Point(248, 40);
			this.m_absRadio.Name = "m_absRadio";
			this.m_absRadio.Size = new System.Drawing.Size(72, 24);
			this.m_absRadio.TabIndex = 8;
			this.m_absRadio.Text = "Absolute";
			this.m_absRadio.CheckedChanged += new System.EventHandler(this.m_absRadio_CheckedChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.m_focusStopButton);
			this.groupBox3.Controls.Add(this.m_focusGoButton);
			this.groupBox3.Controls.Add(this.m_focusSpeedText);
			this.groupBox3.Location = new System.Drawing.Point(152, 176);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(136, 56);
			this.groupBox3.TabIndex = 23;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Focus";
			// 
			// m_focusStopButton
			// 
			this.m_focusStopButton.Location = new System.Drawing.Point(40, 24);
			this.m_focusStopButton.Name = "m_focusStopButton";
			this.m_focusStopButton.Size = new System.Drawing.Size(40, 23);
			this.m_focusStopButton.TabIndex = 26;
			this.m_focusStopButton.Text = "Stop";
			this.m_focusStopButton.Click += new System.EventHandler(this.m_focusStopButton_Click);
			// 
			// m_focusGoButton
			// 
			this.m_focusGoButton.Location = new System.Drawing.Point(8, 24);
			this.m_focusGoButton.Name = "m_focusGoButton";
			this.m_focusGoButton.Size = new System.Drawing.Size(32, 23);
			this.m_focusGoButton.TabIndex = 25;
			this.m_focusGoButton.Text = "Go";
			this.m_focusGoButton.Click += new System.EventHandler(this.m_focusGoButton_Click);
			// 
			// m_focusSpeedText
			// 
			this.m_focusSpeedText.Location = new System.Drawing.Point(88, 24);
			this.m_focusSpeedText.Name = "m_focusSpeedText";
			this.m_focusSpeedText.Size = new System.Drawing.Size(32, 20);
			this.m_focusSpeedText.TabIndex = 8;
			this.m_focusSpeedText.Text = "100";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.m_irisStopButton);
			this.groupBox4.Controls.Add(this.m_irisGoButton);
			this.groupBox4.Controls.Add(this.m_irisSpeedText);
			this.groupBox4.Location = new System.Drawing.Point(296, 176);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(128, 56);
			this.groupBox4.TabIndex = 24;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Iris";
			// 
			// m_irisStopButton
			// 
			this.m_irisStopButton.Location = new System.Drawing.Point(40, 24);
			this.m_irisStopButton.Name = "m_irisStopButton";
			this.m_irisStopButton.Size = new System.Drawing.Size(40, 23);
			this.m_irisStopButton.TabIndex = 29;
			this.m_irisStopButton.Text = "Stop";
			this.m_irisStopButton.Click += new System.EventHandler(this.m_irisStopButton_Click);
			// 
			// m_irisGoButton
			// 
			this.m_irisGoButton.Location = new System.Drawing.Point(8, 24);
			this.m_irisGoButton.Name = "m_irisGoButton";
			this.m_irisGoButton.Size = new System.Drawing.Size(32, 23);
			this.m_irisGoButton.TabIndex = 28;
			this.m_irisGoButton.Text = "Go";
			this.m_irisGoButton.Click += new System.EventHandler(this.m_irisGoButton_Click);
			// 
			// m_irisSpeedText
			// 
			this.m_irisSpeedText.Location = new System.Drawing.Point(88, 24);
			this.m_irisSpeedText.Name = "m_irisSpeedText";
			this.m_irisSpeedText.Size = new System.Drawing.Size(32, 20);
			this.m_irisSpeedText.TabIndex = 27;
			this.m_irisSpeedText.Text = "100";
			// 
			// m_PreSetGotoButton
			// 
			this.m_PreSetGotoButton.Location = new System.Drawing.Point(16, 200);
			this.m_PreSetGotoButton.Name = "m_PreSetGotoButton";
			this.m_PreSetGotoButton.Size = new System.Drawing.Size(40, 23);
			this.m_PreSetGotoButton.TabIndex = 25;
			this.m_PreSetGotoButton.Text = "Goto";
			this.m_PreSetGotoButton.Click += new System.EventHandler(this.m_PreSetGotoButton_Click);
			// 
			// m_PreSetSetButton
			// 
			this.m_PreSetSetButton.Location = new System.Drawing.Point(56, 200);
			this.m_PreSetSetButton.Name = "m_PreSetSetButton";
			this.m_PreSetSetButton.Size = new System.Drawing.Size(32, 23);
			this.m_PreSetSetButton.TabIndex = 26;
			this.m_PreSetSetButton.Text = "Set";
			this.m_PreSetSetButton.Click += new System.EventHandler(this.m_PreSetSetButton_Click);
			// 
			// m_preSetText
			// 
			this.m_preSetText.Location = new System.Drawing.Point(96, 200);
			this.m_preSetText.Name = "m_preSetText";
			this.m_preSetText.Size = new System.Drawing.Size(40, 20);
			this.m_preSetText.TabIndex = 27;
			this.m_preSetText.Text = "1";
			// 
			// groupBox5
			// 
			this.groupBox5.Location = new System.Drawing.Point(8, 176);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(136, 56);
			this.groupBox5.TabIndex = 28;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Pre Sets";
			// 
			// m_sendDataButton
			// 
			this.m_sendDataButton.Location = new System.Drawing.Point(16, 136);
			this.m_sendDataButton.Name = "m_sendDataButton";
			this.m_sendDataButton.Size = new System.Drawing.Size(72, 23);
			this.m_sendDataButton.TabIndex = 29;
			this.m_sendDataButton.Text = "SendData";
			this.m_sendDataButton.Click += new System.EventHandler(this.m_sendDataButton_Click);
			// 
			// CameraControllerForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(434, 415);
			this.Controls.Add(this.m_sendDataButton);
			this.Controls.Add(this.m_preSetText);
			this.Controls.Add(this.m_PreSetSetButton);
			this.Controls.Add(this.m_PreSetGotoButton);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.m_auxDropDown);
			this.Controls.Add(this.m_auxOffButton);
			this.Controls.Add(this.m_auxOnButton);
			this.Controls.Add(this.m_setParametersButton);
			this.Controls.Add(this.m_paramGrid);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.m_modelCombo);
			this.Controls.Add(this.m_setupControllerButton);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox5);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "CameraControllerForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "CameraControllerForm";
			((System.ComponentModel.ISupportInitialize)(this.m_paramGrid)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void CallPTZ(int panSpeed, int tiltSpeed, int zoomSpeed)
		{
			try
			{
				m_cameraController.PTZ(panSpeed, tiltSpeed, zoomSpeed, m_ptzMode);
			}
			catch
			{
				m_mainForm.ErrorMessage("CameraControllerForm", "CallPTZ", "Error calling PTZ", true);
			}
		}

		private void CallAuxActivate(int command, bool bOnOffFlag)
		{
			try
			{
				m_cameraController.AuxCommands[command].Activate(bOnOffFlag);
			}
			catch
			{
				m_mainForm.ErrorMessage("CameraControllerForm", "CallAuxActivate", "Error calling Activate", true);
			}
		}

		private void CallFocus(int speed)
		{
			try
			{
				m_cameraController.Focus(speed);
			}
			catch
			{
				m_mainForm.ErrorMessage("CameraControllerForm", "CallFocus", "Error calling Focus", true);
			}
		}

		private void CallIris(int speed)
		{
			try
			{
				m_cameraController.Iris(speed);
			}
			catch
			{
				m_mainForm.ErrorMessage("CameraControllerForm", "CallIris", "Error calling Iris", true);
			}
		}

		private void m_ptzButton_Click(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("CameraControllerForm", "m_ptzButton_Click", m_ptzButton.Text);

			try
			{
				int panSpeed = System.Convert.ToInt32(m_panSpeedText.Text);
				int tiltSpeed = System.Convert.ToInt32(m_tiltSpeedText.Text);
				int zoomSpeed = System.Convert.ToInt32(m_zoomSpeedText.Text);

				CallPTZ(panSpeed, tiltSpeed, zoomSpeed);
			}
			catch
			{
				m_mainForm.ErrorMessage("CameraControllerForm", "m_ptzButton_Click", "Error calling ptz", true);
			}
		}

		private void m_stopButton_Click(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("CameraControllerForm", "m_stopButton_Click",
				m_stopButton.Text);

			CallPTZ(0, 0, 0);
		}

		private void m_setupControllerButton_Click(object sender, System.EventArgs e)
		{

			m_mainForm.LogUserMessage("CameraControllerForm", "m_setupControllerButton_Click", 
				m_setupControllerButton.Text);

			if (m_setupControllerButton.Text == "Controller Setup...")
			{
				this.Height = this.Height * 3 / 2;
				m_setupControllerButton.Text = "Hide Controller Setup";
			}
			else
			{
				this.Height = this.Height / 3 * 2;
				m_setupControllerButton.Text = "Controller Setup...";
			}
		}

		private void m_modelCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string model = (string)m_modelCombo.Items[m_modelCombo.SelectedIndex];

			m_mainForm.LogUserMessage("CameraControllerForm", "m_modelCombo_SelectedIndexChanged",
				"Selected " + model);

			try
			{
				// Setup the selected model.
				m_cameraController.SetController(model, "", 1);

				// Clear and then re-populate the parameter table.
				m_paramTable.Rows.Clear();

				foreach (Bosch.VideoSDK.Live.NameValuePair pair in m_cameraController.Parameters)
				{
					DataRow newRow;
					newRow = m_paramTable.NewRow();
					newRow["Parameter"] = pair.Name;
					newRow["Value"] = pair.Value;
					m_paramTable.Rows.Add(newRow);
				}

				// Clear and populate the aux drop down with aux commands.
				m_auxDropDown.Items.Clear();

				foreach (Bosch.VideoSDK.Live.AuxCommand auxCommand in m_cameraController.AuxCommands)
					m_auxDropDown.Items.Add(auxCommand.Description);
			
				EvaluateControllableFlag();
			}
			catch
			{
				m_mainForm.ErrorMessage("CameraControllerForm", "m_modelCombo_SelectedIndexChanged", "Unable to set selected camera model", true);
			}
		}

		private void m_setParametersButton_Click(object sender, System.EventArgs e)
		{
			int i = 1;

			m_mainForm.LogUserMessage("CameraControllerForm", "m_setParametersButton_Click", m_setParametersButton.Text);

			foreach (DataRow row in m_paramTable.Rows)
				m_cameraController.Parameters[i++].Value = row["Value"].ToString();

		}

		private void m_auxOnButton_Click(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("CameraControllerForm", "m_auxOnButton_Click", m_auxOnButton.Text);

			CallAuxActivate(m_auxDropDown.SelectedIndex + 1, true);
		}

		private void m_auxOffButton_Click(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("CameraControllerForm", "m_auxOffButton_Click", m_auxOffButton.Text);

			CallAuxActivate(m_auxDropDown.SelectedIndex + 1, false);
		}

		private void m_focusGoButton_Click(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("CameraControllerForm", "m_focusGoButton_Click", m_focusGoButton.Text);

			try
			{
				int speed = System.Convert.ToInt32(m_focusSpeedText.Text);
				CallFocus(speed);
			}
			catch
			{
				m_mainForm.ErrorMessage("CameraControllerForm", "m_focusGoButton_Click", "Error setting focus", true);
			}
		}

		private void m_focusStopButton_Click(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("CameraControllerForm", "m_focusStopButton_Click", m_focusStopButton.Text);

			CallFocus(0);
		}

		private void m_irisGoButton_Click(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("CameraControllerForm", "m_irisGoButton_Click", m_irisGoButton.Text);

			try
			{
				int speed = System.Convert.ToInt32(m_irisSpeedText.Text);
				CallIris(speed);
			}
			catch
			{
				m_mainForm.ErrorMessage("CameraControllerForm", "m_irisGoButton_Click", "Error setting iris", true);
			}
		}

		private void m_irisStopButton_Click(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("CameraControllerForm", "m_irisStopButton_Click", m_irisStopButton.Text);

			CallIris(0);
		}

		private void m_normRadio_CheckedChanged(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("CameraControllerForm", "m_normRadio_CheckedChanged", m_normRadio.Text);

			m_ptzMode = Bosch.VideoSDK.Live.PTZModeEnum.ptzNormalized;
			m_panMaxText.Text = "100";
			m_tiltMaxText.Text = "100";
			m_zoomMaxText.Text = "100";
		}

		private void m_absRadio_CheckedChanged(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("CameraControllerForm", "m_absRadio_CheckedChanged", m_absRadio.Text);

			m_ptzMode = Bosch.VideoSDK.Live.PTZModeEnum.ptzAbsolute;
			m_panMaxText.Text = m_cameraController.MaxAbsolutePanSpeed.ToString();
			m_tiltMaxText.Text = m_cameraController.MaxAbsoluteTiltSpeed.ToString();
			m_zoomMaxText.Text = "100";
		}

		private void m_PreSetGotoButton_Click(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("CameraControllerForm", "m_PreSetGotoButton_Click", m_preSetText.Text);

			try
			{
				m_cameraController.GotoPreset(System.Convert.ToInt32(m_preSetText.Text));
			}
			catch
			{
				m_mainForm.ErrorMessage("CameraControllerForm", "m_PreSetGotoButton_Click", "Error Going to preset", true);
			}
		}

		private void m_PreSetSetButton_Click(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("CameraControllerForm", "m_PreSetSetButton_Click", m_preSetText.Text);

			try
			{
				m_cameraController.SetPreset(System.Convert.ToInt32(m_preSetText.Text));
			}
			catch
			{
				m_mainForm.ErrorMessage("CameraControllerForm", "m_PreSetSetButton_Click", "Error setting preset", true);
			}
		}

		private void m_sendDataButton_Click(object sender, System.EventArgs e)
		{
			string text;
			byte[] data;
			byte oneByte = 0;
			byte halfByte = 0;
			int len = 0;
			int j = 0;
			char ch;
			bool bFirstDone = false;

			// Convert from hexadecimal text to binary and send to the camera controller.

			text = m_sendDataText.Text;
			len = text.Length / 2;
			data = new byte[len];

			for (int i = 0; i < text.Length; i++)
			{
				ch = text[i];

				if (ch <= '9' && ch >= '0')
					halfByte = (byte)((int)ch - '0');
				else if (ch <= 'F' && ch >= 'A')
					halfByte = (byte)((int)ch - 'A' + 0xA);
				else if (ch <= 'f' && ch >= 'a')
					halfByte = (byte)((int)ch - 'a' + 0xA);
				else
					halfByte = 0;

				if (!bFirstDone)
				{
					oneByte = (byte)(halfByte << 4);	
				}
				else
				{
					oneByte |= halfByte;
					data[j++] = oneByte;
				}

				bFirstDone = !bFirstDone;
			}

			try
			{
				m_cameraController.SendData(data, len);
			}
			catch
			{
				m_mainForm.ErrorMessage("CameraControllerForm", "m_sendDataButton_Click", "Error calling SendData", true);
			}
		}

	}
}
