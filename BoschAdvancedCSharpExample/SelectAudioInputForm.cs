using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// Summary description for SelectAudioInputForm.
	/// </summary>
	public class SelectAudioInputForm : System.Windows.Forms.Form
	{
		private Bosch.VideoSDK.AudioLib.AudioSource m_audioSource = null;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button m_btnOk;
		private System.Windows.Forms.ComboBox m_sourceDropDown;
		private System.Windows.Forms.ComboBox m_inputDropDown;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SelectAudioInputForm(Bosch.VideoSDK.AudioLib.AudioSource source)
		{
			InitializeComponent();

			m_audioSource = source;
			m_sourceDropDown.Items.Clear();

			int nDevices = m_audioSource.DeviceCount;

			if (nDevices > 0)
			{
				for (short i = 0; i < m_audioSource.DeviceCount; i++)
				{
					m_sourceDropDown.Items.Add(m_audioSource.get_DeviceName(i));
				}
				m_sourceDropDown.Enabled = true;
				m_inputDropDown.Enabled = true;
				m_sourceDropDown.SelectedIndex = 0;
			}
			else
			{
				m_sourceDropDown.Enabled = false;
				m_inputDropDown.Enabled = false;
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
			this.m_sourceDropDown = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_inputDropDown = new System.Windows.Forms.ComboBox();
			this.m_btnOk = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_sourceDropDown
			// 
			this.m_sourceDropDown.Location = new System.Drawing.Point(88, 24);
			this.m_sourceDropDown.Name = "m_sourceDropDown";
			this.m_sourceDropDown.Size = new System.Drawing.Size(192, 21);
			this.m_sourceDropDown.TabIndex = 0;
			this.m_sourceDropDown.SelectedIndexChanged += new System.EventHandler(this.m_sourceDropDown_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Audio Source:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Input:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_inputDropDown
			// 
			this.m_inputDropDown.Location = new System.Drawing.Point(88, 56);
			this.m_inputDropDown.Name = "m_inputDropDown";
			this.m_inputDropDown.Size = new System.Drawing.Size(192, 21);
			this.m_inputDropDown.TabIndex = 2;
			this.m_inputDropDown.SelectedIndexChanged += new System.EventHandler(this.m_inputDropDown_SelectedIndexChanged);
			// 
			// m_btnOk
			// 
			this.m_btnOk.Location = new System.Drawing.Point(104, 88);
			this.m_btnOk.Name = "m_btnOk";
			this.m_btnOk.TabIndex = 4;
			this.m_btnOk.Text = "Ok";
			this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
			// 
			// SelectAudioInputForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 117);
			this.Controls.Add(this.m_btnOk);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_inputDropDown);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_sourceDropDown);
			this.Name = "SelectAudioInputForm";
			this.Text = "Select Audio Input";
			this.ResumeLayout(false);

		}
		#endregion

		private void m_btnOk_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_sourceDropDown_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_audioSource.SelectDevice(m_sourceDropDown.SelectedIndex);

			m_inputDropDown.Items.Clear();

			for (int i = 0; i < m_audioSource.InputCount; i++)
			{
				m_inputDropDown.Items.Add(m_audioSource.get_InputName(i));
			}

			m_inputDropDown.SelectedIndex = 0;
		}

		private void m_inputDropDown_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			for (int i = 0; i < m_audioSource.InputCount; i++)
			{
				m_audioSource.EnableInput(i , (m_inputDropDown.SelectedIndex == i));
			}
		}
	}
}
