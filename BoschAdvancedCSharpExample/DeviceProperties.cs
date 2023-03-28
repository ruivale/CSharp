using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// Summary description for DeviceProperties.
	/// </summary>
	public class DevicePropertiesForm : System.Windows.Forms.Form
	{
		public DeviceTreeNode m_treeNode = null;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button m_btnOk;
		private System.Windows.Forms.TextBox m_txtAddress;
		private System.Windows.Forms.TextBox m_txtUsername;
		private System.Windows.Forms.TextBox m_txtPassword;
		private System.Windows.Forms.TextBox m_txtProgID;
		private System.Windows.Forms.TextBox m_txtName;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox m_txtProtocol;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DevicePropertiesForm(DeviceTreeNode treeNode)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_treeNode = treeNode;
			m_txtName.Text = m_treeNode.m_deviceName;
			m_txtProtocol.Text = m_treeNode.m_deviceProtocol;
			m_txtAddress.Text = m_treeNode.m_deviceAddress;
			m_txtUsername.Text = m_treeNode.m_username;
			m_txtPassword.Text = m_treeNode.m_password;
			m_txtProgID.Text = m_treeNode.m_progID;
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.m_btnOk = new System.Windows.Forms.Button();
			this.m_txtAddress = new System.Windows.Forms.TextBox();
			this.m_txtUsername = new System.Windows.Forms.TextBox();
			this.m_txtPassword = new System.Windows.Forms.TextBox();
			this.m_txtProgID = new System.Windows.Forms.TextBox();
			this.m_txtName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.m_txtProtocol = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Address";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Username";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 120);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Password";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 144);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "ProgID";
			// 
			// m_btnOk
			// 
			this.m_btnOk.Location = new System.Drawing.Point(96, 176);
			this.m_btnOk.Name = "m_btnOk";
			this.m_btnOk.Size = new System.Drawing.Size(80, 23);
			this.m_btnOk.TabIndex = 6;
			this.m_btnOk.Text = "Ok";
			this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
			// 
			// m_txtAddress
			// 
			this.m_txtAddress.Location = new System.Drawing.Point(72, 72);
			this.m_txtAddress.Name = "m_txtAddress";
			this.m_txtAddress.Size = new System.Drawing.Size(192, 20);
			this.m_txtAddress.TabIndex = 2;
			this.m_txtAddress.Text = "";
			// 
			// m_txtUsername
			// 
			this.m_txtUsername.Location = new System.Drawing.Point(72, 96);
			this.m_txtUsername.Name = "m_txtUsername";
			this.m_txtUsername.Size = new System.Drawing.Size(192, 20);
			this.m_txtUsername.TabIndex = 3;
			this.m_txtUsername.Text = "";
			// 
			// m_txtPassword
			// 
			this.m_txtPassword.Location = new System.Drawing.Point(72, 120);
			this.m_txtPassword.Name = "m_txtPassword";
			this.m_txtPassword.PasswordChar = '*';
			this.m_txtPassword.Size = new System.Drawing.Size(192, 20);
			this.m_txtPassword.TabIndex = 4;
			this.m_txtPassword.Text = "";
			// 
			// m_txtProgID
			// 
			this.m_txtProgID.Location = new System.Drawing.Point(72, 144);
			this.m_txtProgID.Name = "m_txtProgID";
			this.m_txtProgID.Size = new System.Drawing.Size(192, 20);
			this.m_txtProgID.TabIndex = 5;
			this.m_txtProgID.Text = "";
			// 
			// m_txtName
			// 
			this.m_txtName.Location = new System.Drawing.Point(72, 24);
			this.m_txtName.Name = "m_txtName";
			this.m_txtName.Size = new System.Drawing.Size(192, 20);
			this.m_txtName.TabIndex = 1;
			this.m_txtName.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "Name";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 48);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 16);
			this.label6.TabIndex = 11;
			this.label6.Text = "Protocol";
			// 
			// m_txtProtocol
			// 
			this.m_txtProtocol.Location = new System.Drawing.Point(72, 48);
			this.m_txtProtocol.Name = "m_txtProtocol";
			this.m_txtProtocol.Size = new System.Drawing.Size(192, 20);
			this.m_txtProtocol.TabIndex = 2;
			this.m_txtProtocol.Text = "";
			// 
			// DevicePropertiesForm
			// 
			this.AcceptButton = this.m_btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(272, 205);
			this.Controls.Add(this.m_txtProtocol);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.m_txtName);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.m_txtProgID);
			this.Controls.Add(this.m_txtPassword);
			this.Controls.Add(this.m_txtUsername);
			this.Controls.Add(this.m_txtAddress);
			this.Controls.Add(this.m_btnOk);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "DevicePropertiesForm";
			this.Text = "Device Properties";
			this.ResumeLayout(false);

		}
		#endregion

		private void m_btnOk_Click(object sender, System.EventArgs e)
		{
			m_treeNode.m_deviceName = m_txtName.Text;
			m_treeNode.m_deviceProtocol = m_txtProtocol.Text;
			m_treeNode.m_deviceAddress = m_txtAddress.Text;
			m_treeNode.m_username = m_txtUsername.Text;
			m_treeNode.m_password = m_txtPassword.Text;
			m_treeNode.m_progID = m_txtProgID.Text;

			this.Close();
		}
	}
}
