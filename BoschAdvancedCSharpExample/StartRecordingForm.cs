using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// Summary description for StartRecordingForm.
	/// </summary>
	public class StartRecordingForm : System.Windows.Forms.Form
	{
		public Bosch.VideoSDK.MediaDatabase.MediaFileFormatEnum m_format = Bosch.VideoSDK.MediaDatabase.MediaFileFormatEnum.mffVideoSDK;
		public bool m_bCancel = false;
		public System.Windows.Forms.TextBox m_fileSizeTextBox;
		public System.Windows.Forms.TextBox m_fileCommentTextBox;
		public System.Windows.Forms.TextBox m_filenameTextBox;
		
		private System.Windows.Forms.RadioButton m_vsdkFormatRadio;
		private System.Windows.Forms.RadioButton m_mpegAxFormat;
		private System.Windows.Forms.Button m_startButton;
		private System.Windows.Forms.Button m_cancelButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public StartRecordingForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_vsdkFormatRadio.Checked = true;
			m_mpegAxFormat.Checked = false;
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
			this.m_vsdkFormatRadio = new System.Windows.Forms.RadioButton();
			this.m_mpegAxFormat = new System.Windows.Forms.RadioButton();
			this.m_startButton = new System.Windows.Forms.Button();
			this.m_cancelButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_fileSizeTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.m_fileCommentTextBox = new System.Windows.Forms.TextBox();
			this.m_filenameTextBox = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_vsdkFormatRadio
			// 
			this.m_vsdkFormatRadio.Location = new System.Drawing.Point(16, 16);
			this.m_vsdkFormatRadio.Name = "m_vsdkFormatRadio";
			this.m_vsdkFormatRadio.Size = new System.Drawing.Size(120, 24);
			this.m_vsdkFormatRadio.TabIndex = 0;
			this.m_vsdkFormatRadio.Text = "Video SDK Format";
			this.m_vsdkFormatRadio.CheckedChanged += new System.EventHandler(this.m_vsdkFormatRadio_CheckedChanged);
			// 
			// m_mpegAxFormat
			// 
			this.m_mpegAxFormat.Location = new System.Drawing.Point(144, 16);
			this.m_mpegAxFormat.Name = "m_mpegAxFormat";
			this.m_mpegAxFormat.Size = new System.Drawing.Size(136, 24);
			this.m_mpegAxFormat.TabIndex = 1;
			this.m_mpegAxFormat.Text = "MPEG ActiveX Format";
			this.m_mpegAxFormat.CheckedChanged += new System.EventHandler(this.m_mpegAxFormat_CheckedChanged);
			// 
			// m_startButton
			// 
			this.m_startButton.Location = new System.Drawing.Point(8, 136);
			this.m_startButton.Name = "m_startButton";
			this.m_startButton.Size = new System.Drawing.Size(224, 23);
			this.m_startButton.TabIndex = 2;
			this.m_startButton.Text = "Start";
			this.m_startButton.Click += new System.EventHandler(this.m_startButton_Click);
			// 
			// m_cancelButton
			// 
			this.m_cancelButton.Location = new System.Drawing.Point(240, 136);
			this.m_cancelButton.Name = "m_cancelButton";
			this.m_cancelButton.Size = new System.Drawing.Size(224, 23);
			this.m_cancelButton.TabIndex = 3;
			this.m_cancelButton.Text = "Cancel";
			this.m_cancelButton.Click += new System.EventHandler(this.m_cancelButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_mpegAxFormat);
			this.groupBox1.Controls.Add(this.m_vsdkFormatRadio);
			this.groupBox1.Location = new System.Drawing.Point(16, 80);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(288, 48);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "File Format";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(312, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 16);
			this.label1.TabIndex = 6;
			this.label1.Text = "Max File Size (KB):";
			// 
			// m_fileSizeTextBox
			// 
			this.m_fileSizeTextBox.Location = new System.Drawing.Point(336, 96);
			this.m_fileSizeTextBox.Name = "m_fileSizeTextBox";
			this.m_fileSizeTextBox.Size = new System.Drawing.Size(104, 20);
			this.m_fileSizeTextBox.TabIndex = 7;
			this.m_fileSizeTextBox.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 8;
			this.label2.Text = "Filename:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 9;
			this.label3.Text = "File Comment:";
			// 
			// m_fileCommentTextBox
			// 
			this.m_fileCommentTextBox.Location = new System.Drawing.Point(104, 48);
			this.m_fileCommentTextBox.Name = "m_fileCommentTextBox";
			this.m_fileCommentTextBox.Size = new System.Drawing.Size(352, 20);
			this.m_fileCommentTextBox.TabIndex = 10;
			this.m_fileCommentTextBox.Text = "";
			// 
			// m_filenameTextBox
			// 
			this.m_filenameTextBox.Location = new System.Drawing.Point(104, 16);
			this.m_filenameTextBox.Name = "m_filenameTextBox";
			this.m_filenameTextBox.Size = new System.Drawing.Size(352, 20);
			this.m_filenameTextBox.TabIndex = 11;
			this.m_filenameTextBox.Text = "";
			// 
			// StartRecordingForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 174);
			this.Controls.Add(this.m_filenameTextBox);
			this.Controls.Add(this.m_fileCommentTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_fileSizeTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.m_cancelButton);
			this.Controls.Add(this.m_startButton);
			this.Name = "StartRecordingForm";
			this.Text = "Start Recording";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void m_startButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_cancelButton_Click(object sender, System.EventArgs e)
		{
			m_bCancel = true;
			this.Close();
		}

		private void m_vsdkFormatRadio_CheckedChanged(object sender, System.EventArgs e)
		{
			if (m_vsdkFormatRadio.Checked)
			{
				m_format = Bosch.VideoSDK.MediaDatabase.MediaFileFormatEnum.mffVideoSDK;
				m_fileCommentTextBox.Enabled = true;
			}
		}

		private void m_mpegAxFormat_CheckedChanged(object sender, System.EventArgs e)
		{
			if (m_mpegAxFormat.Checked)
			{
				m_format = Bosch.VideoSDK.MediaDatabase.MediaFileFormatEnum.mffMPEGActiveX;
				m_fileCommentTextBox.Enabled = false;
			}


		}
	}
}
