using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// Summary description for DigitalZoomForm.
	/// </summary>
	public class DigitalZoomForm : System.Windows.Forms.Form
	{
		private MainForm m_mainForm = null;

		private System.Windows.Forms.TextBox m_txtXPct;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox m_txtYPct;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox m_txtWPct;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox m_txtHPct;
		private System.Windows.Forms.Button m_btnDigitalZoom;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DigitalZoomForm(MainForm mainForm)
		{
			InitializeComponent();

			m_mainForm = mainForm;
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
			this.m_txtXPct = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtYPct = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.m_txtWPct = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.m_txtHPct = new System.Windows.Forms.TextBox();
			this.m_btnDigitalZoom = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_txtXPct
			// 
			this.m_txtXPct.Location = new System.Drawing.Point(56, 24);
			this.m_txtXPct.Name = "m_txtXPct";
			this.m_txtXPct.Size = new System.Drawing.Size(112, 20);
			this.m_txtXPct.TabIndex = 0;
			this.m_txtXPct.Text = "250";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "X %";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Y %";
			// 
			// m_txtYPct
			// 
			this.m_txtYPct.Location = new System.Drawing.Point(56, 56);
			this.m_txtYPct.Name = "m_txtYPct";
			this.m_txtYPct.Size = new System.Drawing.Size(112, 20);
			this.m_txtYPct.TabIndex = 2;
			this.m_txtYPct.Text = "250";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "W %";
			// 
			// m_txtWPct
			// 
			this.m_txtWPct.Location = new System.Drawing.Point(56, 88);
			this.m_txtWPct.Name = "m_txtWPct";
			this.m_txtWPct.Size = new System.Drawing.Size(112, 20);
			this.m_txtWPct.TabIndex = 4;
			this.m_txtWPct.Text = "500";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 120);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(32, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "H %";
			// 
			// m_txtHPct
			// 
			this.m_txtHPct.Location = new System.Drawing.Point(56, 120);
			this.m_txtHPct.Name = "m_txtHPct";
			this.m_txtHPct.Size = new System.Drawing.Size(112, 20);
			this.m_txtHPct.TabIndex = 6;
			this.m_txtHPct.Text = "500";
			// 
			// m_btnDigitalZoom
			// 
			this.m_btnDigitalZoom.Location = new System.Drawing.Point(8, 152);
			this.m_btnDigitalZoom.Name = "m_btnDigitalZoom";
			this.m_btnDigitalZoom.Size = new System.Drawing.Size(160, 23);
			this.m_btnDigitalZoom.TabIndex = 8;
			this.m_btnDigitalZoom.Text = "DigitalZoom";
			this.m_btnDigitalZoom.Click += new System.EventHandler(this.m_btnDigitalZoom_Click);
			// 
			// DigitalZoomForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(176, 181);
			this.Controls.Add(this.m_btnDigitalZoom);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.m_txtHPct);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_txtWPct);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_txtYPct);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_txtXPct);
			this.Name = "DigitalZoomForm";
			this.Text = "Digital Zoom";
			this.ResumeLayout(false);

		}
		#endregion

		private void m_btnDigitalZoom_Click(object sender, System.EventArgs e)
		{
			short x, y, w, h;

			m_mainForm.LogUserMessage("DigitalZoomForm", "m_btnDigitalZoom_Click", m_btnDigitalZoom.Text);

			x = short.Parse(m_txtXPct.Text);
			y = short.Parse(m_txtYPct.Text);
			w = short.Parse(m_txtWPct.Text);
			h = short.Parse(m_txtHPct.Text);

			try
			{
				m_mainForm.m_activeCameo.DigitalZoom(x, y, w, h);
			}
			catch
			{
				m_mainForm.ErrorMessage("DigitalZoomForm", "m_btnDigitalZoom_Click", "Error calling DigitalZoom.", true);
			}
		}

	}
}
