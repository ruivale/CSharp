using System.Windows.Forms;

namespace TCameoMainWindow
{
	partial class MainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.bttConnect = new System.Windows.Forms.Button();
            this.panelCameo = new System.Windows.Forms.Panel();
            this.comboBoxProgID = new System.Windows.Forms.ComboBox();
            this.checkBoxHWAcceleration = new System.Windows.Forms.CheckBox();
            this.buttonCam = new System.Windows.Forms.Button();
            this.comboBoxStreamProtocol = new System.Windows.Forms.ComboBox();
            this.comboBoxVideoInput = new System.Windows.Forms.ComboBox();
            this.labelVdoInput = new System.Windows.Forms.Label();
            this.labelStreamEncoder = new System.Windows.Forms.Label();
            this.comboBoxStreamEncoder = new System.Windows.Forms.ComboBox();
            this.labelStreamProtocol = new System.Windows.Forms.Label();
            this.ttCBHWA = new System.Windows.Forms.ToolTip(this.components);
            this.ttBttCam = new System.Windows.Forms.ToolTip(this.components);
            this.ttCBSP = new System.Windows.Forms.ToolTip(this.components);
            this.ttCBVI = new System.Windows.Forms.ToolTip(this.components);
            this.ttCBSE = new System.Windows.Forms.ToolTip(this.components);
            this.labelCamActive = new System.Windows.Forms.Label();
            this.labelProgId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUrl.Location = new System.Drawing.Point(14, 41);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(363, 20);
            this.textBoxUrl.TabIndex = 0;
            this.textBoxUrl.TextChanged += new System.EventHandler(this.TextBoxUrl_TextChanged);
            this.textBoxUrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxUrl_KeyDown);
            // 
            // bttConnect
            // 
            this.bttConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttConnect.Location = new System.Drawing.Point(642, 104);
            this.bttConnect.Name = "bttConnect";
            this.bttConnect.Size = new System.Drawing.Size(75, 23);
            this.bttConnect.TabIndex = 1;
            this.bttConnect.Text = "C&onnect";
            this.bttConnect.UseVisualStyleBackColor = true;
            this.bttConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // panelCameo
            // 
            this.panelCameo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCameo.Location = new System.Drawing.Point(12, 133);
            this.panelCameo.Name = "panelCameo";
            this.panelCameo.Size = new System.Drawing.Size(704, 570);
            this.panelCameo.TabIndex = 2;
            // 
            // comboBoxProgID
            // 
            this.comboBoxProgID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxProgID.FormattingEnabled = true;
            this.comboBoxProgID.Items.AddRange(new object[] {
            "GCA.VIP.DeviceProxy",
            "GCA.ONVIF.DeviceProxy",
            "GCA.RTSP.DeviceProxy",
            "GCA.File.DeviceProxy",
            "GCA.Divar600.DeviceProxy",
            "GCA.Divar700.DeviceProxy",
            "GCA.DVR5000.DeviceProxy",
            "GCA.DiBos.DeviceProxy"});
            this.comboBoxProgID.Location = new System.Drawing.Point(443, 69);
            this.comboBoxProgID.Name = "comboBoxProgID";
            this.comboBoxProgID.Size = new System.Drawing.Size(160, 21);
            this.comboBoxProgID.TabIndex = 3;
            // 
            // checkBoxHWAcceleration
            // 
            this.checkBoxHWAcceleration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHWAcceleration.Location = new System.Drawing.Point(12, 709);
            this.checkBoxHWAcceleration.Name = "checkBoxHWAcceleration";
            this.checkBoxHWAcceleration.Size = new System.Drawing.Size(704, 20);
            this.checkBoxHWAcceleration.TabIndex = 0;
            this.checkBoxHWAcceleration.Text = "HW Acceleration (read-only after initialization [to change the selection, a resta" +
    "rt is needed])";
            this.ttCBHWA.SetToolTip(this.checkBoxHWAcceleration, "Can only be set prior to initialization");
            // 
            // buttonCam
            // 
            this.buttonCam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCam.Location = new System.Drawing.Point(12, 12);
            this.buttonCam.Name = "buttonCam";
            this.buttonCam.Size = new System.Drawing.Size(186, 23);
            this.buttonCam.TabIndex = 4;
            this.buttonCam.Text = "Select &camera";
            this.ttBttCam.SetToolTip(this.buttonCam, "Select a camera");
            this.buttonCam.UseVisualStyleBackColor = true;
            this.buttonCam.Click += new System.EventHandler(this.ButtonCam_Click);
            // 
            // comboBoxStreamProtocol
            // 
            this.comboBoxStreamProtocol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxStreamProtocol.FormattingEnabled = true;
            this.comboBoxStreamProtocol.Items.AddRange(new object[] {
            "UDP",
            "TCP",
            "Direct",
            "TCP Transcoded"});
            this.comboBoxStreamProtocol.Location = new System.Drawing.Point(296, 69);
            this.comboBoxStreamProtocol.Name = "comboBoxStreamProtocol";
            this.comboBoxStreamProtocol.Size = new System.Drawing.Size(81, 21);
            this.comboBoxStreamProtocol.TabIndex = 5;
            this.ttCBSP.SetToolTip(this.comboBoxStreamProtocol, "Stream protocol");
            // 
            // comboBoxVideoInput
            // 
            this.comboBoxVideoInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxVideoInput.FormattingEnabled = true;
            this.comboBoxVideoInput.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBoxVideoInput.Location = new System.Drawing.Point(52, 69);
            this.comboBoxVideoInput.Name = "comboBoxVideoInput";
            this.comboBoxVideoInput.Size = new System.Drawing.Size(52, 21);
            this.comboBoxVideoInput.TabIndex = 6;
            this.ttCBVI.SetToolTip(this.comboBoxVideoInput, "Device video input");
            // 
            // labelVdoInput
            // 
            this.labelVdoInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVdoInput.AutoSize = true;
            this.labelVdoInput.Location = new System.Drawing.Point(12, 72);
            this.labelVdoInput.Name = "labelVdoInput";
            this.labelVdoInput.Size = new System.Drawing.Size(34, 13);
            this.labelVdoInput.TabIndex = 7;
            this.labelVdoInput.Text = "Input:";
            // 
            // labelStreamEncoder
            // 
            this.labelStreamEncoder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStreamEncoder.AutoSize = true;
            this.labelStreamEncoder.Location = new System.Drawing.Point(117, 72);
            this.labelStreamEncoder.Name = "labelStreamEncoder";
            this.labelStreamEncoder.Size = new System.Drawing.Size(50, 13);
            this.labelStreamEncoder.TabIndex = 9;
            this.labelStreamEncoder.Text = "Encoder:";
            // 
            // comboBoxStreamEncoder
            // 
            this.comboBoxStreamEncoder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxStreamEncoder.FormattingEnabled = true;
            this.comboBoxStreamEncoder.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.comboBoxStreamEncoder.Location = new System.Drawing.Point(173, 69);
            this.comboBoxStreamEncoder.Name = "comboBoxStreamEncoder";
            this.comboBoxStreamEncoder.Size = new System.Drawing.Size(50, 21);
            this.comboBoxStreamEncoder.TabIndex = 8;
            this.ttCBSE.SetToolTip(this.comboBoxStreamEncoder, "Stream encoder");
            // 
            // labelStreamProtocol
            // 
            this.labelStreamProtocol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStreamProtocol.AutoSize = true;
            this.labelStreamProtocol.Location = new System.Drawing.Point(241, 72);
            this.labelStreamProtocol.Name = "labelStreamProtocol";
            this.labelStreamProtocol.Size = new System.Drawing.Size(49, 13);
            this.labelStreamProtocol.TabIndex = 10;
            this.labelStreamProtocol.Text = "Protocol:";
            // 
            // labelCamActive
            // 
            this.labelCamActive.AutoSize = true;
            this.labelCamActive.Location = new System.Drawing.Point(12, 109);
            this.labelCamActive.Name = "labelCamActive";
            this.labelCamActive.Size = new System.Drawing.Size(58, 13);
            this.labelCamActive.TabIndex = 11;
            this.labelCamActive.Text = "Camera: ...";
            // 
            // labelProgId
            // 
            this.labelProgId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProgId.AutoSize = true;
            this.labelProgId.Location = new System.Drawing.Point(396, 72);
            this.labelProgId.Name = "labelProgId";
            this.labelProgId.Size = new System.Drawing.Size(41, 13);
            this.labelProgId.TabIndex = 12;
            this.labelProgId.Text = "ProgId:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 733);
            this.Controls.Add(this.labelProgId);
            this.Controls.Add(this.labelCamActive);
            this.Controls.Add(this.labelStreamProtocol);
            this.Controls.Add(this.labelStreamEncoder);
            this.Controls.Add(this.comboBoxStreamEncoder);
            this.Controls.Add(this.labelVdoInput);
            this.Controls.Add(this.comboBoxVideoInput);
            this.Controls.Add(this.comboBoxStreamProtocol);
            this.Controls.Add(this.buttonCam);
            this.Controls.Add(this.comboBoxProgID);
            this.Controls.Add(this.panelCameo);
            this.Controls.Add(this.bttConnect);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.checkBoxHWAcceleration);
            this.Name = "MainWindow";
            this.Text = "Runtime Cameo Sample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxUrl;
		private System.Windows.Forms.Button bttConnect;
		private System.Windows.Forms.Panel panelCameo;
        private System.Windows.Forms.ComboBox comboBoxProgID;
        private System.Windows.Forms.CheckBox checkBoxHWAcceleration;
        private System.Windows.Forms.Button buttonCam;
        private System.Windows.Forms.ComboBox comboBoxStreamProtocol;
        private System.Windows.Forms.ComboBox comboBoxVideoInput;
        private System.Windows.Forms.Label labelVdoInput;
        private System.Windows.Forms.Label labelStreamEncoder;
        private System.Windows.Forms.ComboBox comboBoxStreamEncoder;
        private System.Windows.Forms.Label labelStreamProtocol;
        private ToolTip ttCBHWA;
        private ToolTip ttBttCam;
        private ToolTip ttCBSP;
        private ToolTip ttCBVI;
        private ToolTip ttCBSE;
        private Label labelCamActive;
        private Label labelProgId;
    }
}

