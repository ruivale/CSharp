using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// Summary description for LiveVideoProperties.
	/// </summary>
	public class LiveVideoProperties : System.Windows.Forms.Form
	{
		public DeviceTreeNode m_treeNode = null;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button m_btnOK;
		private System.Windows.Forms.CheckBox m_checkMulticast;
		private System.Windows.Forms.TextBox m_txtEncoder;
		private System.Windows.Forms.ComboBox m_txtCoding;
		private System.Windows.Forms.ComboBox m_cboRemoteAudio;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox m_cboProtocol;
		private System.Windows.Forms.Label label4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public LiveVideoProperties(DeviceTreeNode treeNode)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_treeNode					= treeNode;
			m_checkMulticast.Checked	= m_treeNode.m_multicast;
			int nEncoder				= m_treeNode.m_encoder;
			m_cboProtocol.SelectedIndex	= (int) m_treeNode.m_Protocol;
			m_txtEncoder.Text			= nEncoder.ToString();

			switch(m_treeNode.m_coding)
			{
				case Bosch.VideoSDK.CodingEnum.ceMPEG2:
					m_txtCoding.Text = "MPEG2";
					break;
				case Bosch.VideoSDK.CodingEnum.ceMPEG4:
					m_txtCoding.Text = "MPEG4";
					break;
				case Bosch.VideoSDK.CodingEnum.ceWavelet:
					m_txtCoding.Text = "Wavelet";
					break;

			}

			switch(m_treeNode.m_remoteAudio)
			{
				case Bosch.VideoSDK.Live.AudioChannelFlags.acfNone:
					m_cboRemoteAudio.Text = "No Audio";
					break;
				case Bosch.VideoSDK.Live.AudioChannelFlags.acfIncludeAudio:
					m_cboRemoteAudio.Text = "Include Audio";
					break;
				case Bosch.VideoSDK.Live.AudioChannelFlags.acfBackChannelAudio:
					m_cboRemoteAudio.Text = "Back Channel Audio";
					break;
			}
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
			this.m_txtEncoder = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_checkMulticast = new System.Windows.Forms.CheckBox();
			this.m_txtCoding = new System.Windows.Forms.ComboBox();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_cboRemoteAudio = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.m_cboProtocol = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// m_txtEncoder
			// 
			this.m_txtEncoder.Location = new System.Drawing.Point(104, 96);
			this.m_txtEncoder.Name = "m_txtEncoder";
			this.m_txtEncoder.Size = new System.Drawing.Size(72, 20);
			this.m_txtEncoder.TabIndex = 2;
			this.m_txtEncoder.Text = "0";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 1;
			this.label1.Tag = "";
			this.label1.Text = "Coding";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Encoder";
			// 
			// m_checkMulticast
			// 
			this.m_checkMulticast.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.m_checkMulticast.Checked = true;
			this.m_checkMulticast.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_checkMulticast.Location = new System.Drawing.Point(14, 128);
			this.m_checkMulticast.Name = "m_checkMulticast";
			this.m_checkMulticast.TabIndex = 3;
			this.m_checkMulticast.Text = "Multicast";
			// 
			// m_txtCoding
			// 
			this.m_txtCoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_txtCoding.Items.AddRange(new object[] {
															 "MPEG2",
															 "MPEG4",
															 "Wavelet"});
			this.m_txtCoding.Location = new System.Drawing.Point(104, 64);
			this.m_txtCoding.Name = "m_txtCoding";
			this.m_txtCoding.Size = new System.Drawing.Size(121, 21);
			this.m_txtCoding.TabIndex = 1;
			// 
			// m_btnOK
			// 
			this.m_btnOK.Location = new System.Drawing.Point(79, 204);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.TabIndex = 4;
			this.m_btnOK.Text = "Ok";
			this.m_btnOK.Click += new System.EventHandler(this.m_btnOk_Click);
			// 
			// m_cboRemoteAudio
			// 
			this.m_cboRemoteAudio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboRemoteAudio.Items.AddRange(new object[] {
																  "No Audio",
																  "Include Audio",
																  "Back Channel Audio"});
			this.m_cboRemoteAudio.Location = new System.Drawing.Point(104, 160);
			this.m_cboRemoteAudio.Name = "m_cboRemoteAudio";
			this.m_cboRemoteAudio.Size = new System.Drawing.Size(121, 21);
			this.m_cboRemoteAudio.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 160);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Remote Audio";
			// 
			// m_cboProtocol
			// 
			this.m_cboProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboProtocol.Items.AddRange(new object[] {
															   "UDP",
															   "TCP"});
			this.m_cboProtocol.Location = new System.Drawing.Point(104, 32);
			this.m_cboProtocol.Name = "m_cboProtocol";
			this.m_cboProtocol.Size = new System.Drawing.Size(121, 21);
			this.m_cboProtocol.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 7;
			this.label4.Tag = "";
			this.label4.Text = "Protocol";
			// 
			// LiveVideoProperties
			// 
			this.AcceptButton = this.m_btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(240, 237);
			this.Controls.Add(this.m_cboProtocol);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_cboRemoteAudio);
			this.Controls.Add(this.m_btnOK);
			this.Controls.Add(this.m_txtCoding);
			this.Controls.Add(this.m_checkMulticast);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_txtEncoder);
			this.Name = "LiveVideoProperties";
			this.Text = "Live Video Properties";
			this.ResumeLayout(false);

		}
		#endregion

		private void m_btnOk_Click(object sender, System.EventArgs e)
		{
			m_treeNode.m_encoder	= Int32.Parse(m_txtEncoder.Text);
			m_treeNode.m_multicast	= m_checkMulticast.Checked;

			if ("MPEG2" == m_txtCoding.Text)
				m_treeNode.m_coding = Bosch.VideoSDK.CodingEnum.ceMPEG2;
			else if ("MPEG4" == m_txtCoding.Text)
				m_treeNode.m_coding = Bosch.VideoSDK.CodingEnum.ceMPEG4;
			else if ("Wavelet" == m_txtCoding.Text)
				m_treeNode.m_coding = Bosch.VideoSDK.CodingEnum.ceWavelet;

			if ("No Audio" == m_cboRemoteAudio.Text)
				m_treeNode.m_remoteAudio = Bosch.VideoSDK.Live.AudioChannelFlags.acfNone;
			else if ("Include Audio" == m_cboRemoteAudio.Text)
				m_treeNode.m_remoteAudio = Bosch.VideoSDK.Live.AudioChannelFlags.acfIncludeAudio;
			else if ("Back Channel Audio" == m_cboRemoteAudio.Text)
				m_treeNode.m_remoteAudio = Bosch.VideoSDK.Live.AudioChannelFlags.acfBackChannelAudio;

			m_treeNode.m_Protocol = (Bosch.VideoSDK.StreamingProtocolEnum) m_cboProtocol.SelectedIndex;

			m_treeNode.m_liveVideoPropertiesChanged = true;
			this.Close();
		}
	}
}
