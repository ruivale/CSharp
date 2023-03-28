using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class VcaConfigDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox ModeCombo;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Label label1;
		private bool isActivated = false;

		private Bosch.VideoSDK.Live.VcaConfig vcaConfig;
		private MainForm main;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button downloadButton;
		private System.Windows.Forms.Button uploadButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label viprocIdLabel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label configLabel;
		private System.Windows.Forms.Button buttonGet1;
		private System.Windows.Forms.Button buttonGet2;
		private System.Windows.Forms.Button buttonGet3;
		private System.Windows.Forms.Button buttonSet2;
		private System.Windows.Forms.Button buttonSet1;
		private System.Windows.Forms.Button buttonSet3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public VcaConfigDialog(MainForm parent, Bosch.VideoSDK.Live.VcaConfig vc, string header)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.Text = header;
			main = parent;
			vcaConfig = vc;
			vcaConfig.StateChanged +=new Bosch.VideoSDK.GCALib._IVcaConfigEvents_StateChangedEventHandler(vcaConfig_StateChanged);
			try {
				vcaConfig.Initialize();
			} catch (Exception e) {statusLabel.Text = e.ToString();}
		}
		public void setStatus(string value) {
			if (!isActivated && value == "vcsInitialized") {
				vcaConfig.AttachPlugin(vcaConfig.ViprocId, 0, 2, "en");
				isActivated = true;
			}
			statusLabel.Text = value;
			try {
				configLabel.Text = "null";
				if (vcaConfig.Configuration != null) 
					configLabel.Text = Convert.ToString(vcaConfig.Configuration.ID, 16);
			} catch (Exception e) {
				configLabel.Text = e.ToString();//"<none>";
			}
			try {
				viprocIdLabel.Text = Convert.ToString(vcaConfig.ViprocId, 16);
			} catch (Exception) {
				viprocIdLabel.Text = "<failed>";
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			main.detachVcaConfigDialog(this);
			vcaConfig.AttachPlugin(0, 0, 0, null);		// disable
			vcaConfig.StateChanged -= new Bosch.VideoSDK.GCALib._IVcaConfigEvents_StateChangedEventHandler(vcaConfig_StateChanged);
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
			this.ModeCombo = new System.Windows.Forms.ComboBox();
			this.statusLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.downloadButton = new System.Windows.Forms.Button();
			this.uploadButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.viprocIdLabel = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.configLabel = new System.Windows.Forms.Label();
			this.buttonGet1 = new System.Windows.Forms.Button();
			this.buttonGet2 = new System.Windows.Forms.Button();
			this.buttonGet3 = new System.Windows.Forms.Button();
			this.buttonSet3 = new System.Windows.Forms.Button();
			this.buttonSet2 = new System.Windows.Forms.Button();
			this.buttonSet1 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// ModeCombo
			// 
			this.ModeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ModeCombo.Items.AddRange(new object[] {
														   "Off",
														   "VCD",
														   "Cfg",
														   "Edit",
														   "All"});
			this.ModeCombo.Location = new System.Drawing.Point(112, 16);
			this.ModeCombo.Name = "ModeCombo";
			this.ModeCombo.Size = new System.Drawing.Size(120, 24);
			this.ModeCombo.TabIndex = 4;
			this.ModeCombo.Text = "Mode";
			this.ModeCombo.SelectionChangeCommitted += new System.EventHandler(this.ModeCombo_SelectionChangeCommitted);
			// 
			// statusLabel
			// 
			this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.statusLabel.BackColor = System.Drawing.SystemColors.ControlLight;
			this.statusLabel.Location = new System.Drawing.Point(112, 252);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(160, 24);
			this.statusLabel.TabIndex = 16;
			this.statusLabel.Text = "label4";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(24, 252);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 24);
			this.label1.TabIndex = 17;
			this.label1.Text = "Status:";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(24, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 24);
			this.label2.TabIndex = 18;
			this.label2.Text = "Mode:";
			// 
			// downloadButton
			// 
			this.downloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.downloadButton.Location = new System.Drawing.Point(112, 48);
			this.downloadButton.Name = "downloadButton";
			this.downloadButton.Size = new System.Drawing.Size(120, 24);
			this.downloadButton.TabIndex = 19;
			this.downloadButton.Text = "Download";
			this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
			// 
			// uploadButton
			// 
			this.uploadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.uploadButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.uploadButton.Location = new System.Drawing.Point(112, 80);
			this.uploadButton.Name = "uploadButton";
			this.uploadButton.Size = new System.Drawing.Size(120, 24);
			this.uploadButton.TabIndex = 20;
			this.uploadButton.Text = "Upload";
			this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(24, 220);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 24);
			this.label3.TabIndex = 22;
			this.label3.Text = "ViprocId:";
			// 
			// viprocIdLabel
			// 
			this.viprocIdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.viprocIdLabel.BackColor = System.Drawing.SystemColors.ControlLight;
			this.viprocIdLabel.Location = new System.Drawing.Point(112, 220);
			this.viprocIdLabel.Name = "viprocIdLabel";
			this.viprocIdLabel.Size = new System.Drawing.Size(72, 24);
			this.viprocIdLabel.TabIndex = 21;
			this.viprocIdLabel.Text = "-";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.Location = new System.Drawing.Point(24, 188);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 24);
			this.label4.TabIndex = 24;
			this.label4.Text = "Config ID:";
			// 
			// configLabel
			// 
			this.configLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.configLabel.BackColor = System.Drawing.SystemColors.ControlLight;
			this.configLabel.Location = new System.Drawing.Point(112, 188);
			this.configLabel.Name = "configLabel";
			this.configLabel.Size = new System.Drawing.Size(72, 24);
			this.configLabel.TabIndex = 23;
			this.configLabel.Text = "-";
			// 
			// buttonGet1
			// 
			this.buttonGet1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonGet1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonGet1.Location = new System.Drawing.Point(112, 112);
			this.buttonGet1.Name = "buttonGet1";
			this.buttonGet1.Size = new System.Drawing.Size(24, 24);
			this.buttonGet1.TabIndex = 25;
			this.buttonGet1.Text = "1";
			this.buttonGet1.Click += new System.EventHandler(this.buttonGet_Click);
			// 
			// buttonGet2
			// 
			this.buttonGet2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonGet2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonGet2.Location = new System.Drawing.Point(144, 112);
			this.buttonGet2.Name = "buttonGet2";
			this.buttonGet2.Size = new System.Drawing.Size(24, 24);
			this.buttonGet2.TabIndex = 26;
			this.buttonGet2.Text = "2";
			this.buttonGet2.Click += new System.EventHandler(this.buttonGet_Click);
			// 
			// buttonGet3
			// 
			this.buttonGet3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonGet3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonGet3.Location = new System.Drawing.Point(176, 112);
			this.buttonGet3.Name = "buttonGet3";
			this.buttonGet3.Size = new System.Drawing.Size(24, 24);
			this.buttonGet3.TabIndex = 27;
			this.buttonGet3.Text = "3";
			this.buttonGet3.Click += new System.EventHandler(this.buttonGet_Click);
			// 
			// buttonSet3
			// 
			this.buttonSet3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSet3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonSet3.Location = new System.Drawing.Point(176, 144);
			this.buttonSet3.Name = "buttonSet3";
			this.buttonSet3.Size = new System.Drawing.Size(24, 24);
			this.buttonSet3.TabIndex = 30;
			this.buttonSet3.Text = "3";
			this.buttonSet3.Click += new System.EventHandler(this.buttonSet_Click);
			// 
			// buttonSet2
			// 
			this.buttonSet2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSet2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonSet2.Location = new System.Drawing.Point(144, 144);
			this.buttonSet2.Name = "buttonSet2";
			this.buttonSet2.Size = new System.Drawing.Size(24, 24);
			this.buttonSet2.TabIndex = 29;
			this.buttonSet2.Text = "2";
			this.buttonSet2.Click += new System.EventHandler(this.buttonSet_Click);
			// 
			// buttonSet1
			// 
			this.buttonSet1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSet1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonSet1.Location = new System.Drawing.Point(112, 144);
			this.buttonSet1.Name = "buttonSet1";
			this.buttonSet1.Size = new System.Drawing.Size(24, 24);
			this.buttonSet1.TabIndex = 28;
			this.buttonSet1.Text = "1";
			this.buttonSet1.Click += new System.EventHandler(this.buttonSet_Click);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Location = new System.Drawing.Point(24, 112);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 24);
			this.label5.TabIndex = 31;
			this.label5.Text = "Get Preset";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.Location = new System.Drawing.Point(24, 144);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 24);
			this.label6.TabIndex = 32;
			this.label6.Text = "Set Preset";
			// 
			// VcaConfigDialog
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(292, 296);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.buttonSet3);
			this.Controls.Add(this.buttonSet2);
			this.Controls.Add(this.buttonSet1);
			this.Controls.Add(this.buttonGet3);
			this.Controls.Add(this.buttonGet2);
			this.Controls.Add(this.buttonGet1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.configLabel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.viprocIdLabel);
			this.Controls.Add(this.uploadButton);
			this.Controls.Add(this.downloadButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.ModeCombo);
			this.Name = "VcaConfigDialog";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		private void ModeCombo_SelectionChangeCommitted(object sender, System.EventArgs e) {
			try {
				switch(ModeCombo.SelectedIndex) {
					case 0:
						vcaConfig.DisplayMode = 0;
						break;
					case 1:
						vcaConfig.DisplayMode = (Bosch.VideoSDK.Live.VcaDisplayModes)0x00ff;
						break;
					case 2:
						vcaConfig.DisplayMode = (Bosch.VideoSDK.Live.VcaDisplayModes)0x0700;
						break;
					case 3:
						vcaConfig.DisplayMode = (Bosch.VideoSDK.Live.VcaDisplayModes)0xff00;
						break;
					case 4:
						vcaConfig.DisplayMode = (Bosch.VideoSDK.Live.VcaDisplayModes)0xffff;
						break;
				}
			} catch (Exception) {
				ModeCombo.SelectedIndex = 0;// = "Failed !";
			}
		}

		private void uploadButton_Click(object sender, System.EventArgs e) {
			vcaConfig.UploadConfiguration();
		}

		private void downloadButton_Click(object sender, System.EventArgs e) {
			vcaConfig.DownloadConfiguration();
		}

		static private Bosch.VideoSDK.VcaConfigData[] presetBuffers = new Bosch.VideoSDK.VcaConfigData[3];
		private void buttonSet_Click(object sender, System.EventArgs e) {
			int index = Convert.ToInt32((sender as Control).Text) - 1;
			if (index >= 0 && index < 3) presetBuffers[index] = vcaConfig.Configuration.Clone();
		}
		private void buttonGet_Click(object sender, System.EventArgs e) {
			int index = Convert.ToInt32((sender as Control).Text) - 1;
			if (index >= 0 && index < 3 && presetBuffers[index] != null) 
				vcaConfig.Configuration = presetBuffers[index];
		}

		private void vcaConfig_StateChanged(Bosch.VideoSDK.Live.VcaConfig EventSource, Bosch.VideoSDK.Live.VcaConfigStates State) {
			setStatus(State.ToString());
		}
	}
}
