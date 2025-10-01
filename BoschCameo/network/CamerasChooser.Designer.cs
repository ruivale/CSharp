using System;
using System.Windows.Forms;

namespace CSharpRuntimeCameo.network
{
    partial class CamerasChooser
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
            this.treeViewNetwork = new System.Windows.Forms.TreeView();
            //this.treeViewNetwork = new CodersLab.Windows.Controls.TreeView();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelCam = new System.Windows.Forms.Label();
            this.textBoxCamName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // treeViewNetwork
            // 
            this.treeViewNetwork.AllowDrop = true;
            this.treeViewNetwork.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewNetwork.Location = new System.Drawing.Point(12, 12);
            this.treeViewNetwork.Name = "treeViewNetwork";
            //this.treeViewNetwork.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            //this.treeViewNetwork.SelectionMode = CodersLab.Windows.Controls.TreeViewSelectionMode.MultiSelect;
            this.treeViewNetwork.Size = new System.Drawing.Size(456, 671);
            this.treeViewNetwork.TabIndex = 9;
            //this.treeViewNetwork.Click += new System.EventHandler(this.treeViewNetwork_Click);
            this.treeViewNetwork.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeViewNetwork_MouseClick);
            this.treeViewNetwork.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeViewNetwork_MouseDoubleClick);
            this.treeViewNetwork.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeViewNetwork_KeyUp);
            //this.treeViewNetwork.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeViewNetwork_MouseUp);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(393, 757);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(312, 757);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 12;
            this.buttonOk.Text = "&OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelCam
            // 
            this.labelCam.AutoSize = true;
            this.labelCam.Location = new System.Drawing.Point(12, 702);
            this.labelCam.Name = "labelCam";
            this.labelCam.Size = new System.Drawing.Size(140, 13);
            this.labelCam.TabIndex = 13;
            this.labelCam.Text = "Camera (like 100_Shunt):";
            // 
            // textBoxCamName
            // 
            this.textBoxCamName.Location = new System.Drawing.Point(158, 699);
            this.textBoxCamName.Name = "textBoxCamName";
            this.textBoxCamName.Size = new System.Drawing.Size(310, 20);
            this.textBoxCamName.TabIndex = 14;
            this.textBoxCamName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // CamerasChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 792);
            this.Controls.Add(this.textBoxCamName);
            this.Controls.Add(this.labelCam);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.treeViewNetwork);
            this.Name = "CamerasChooser";
            this.Text = "CamerasChooser";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CamerasChooser_FormClosed);
            this.Load += new System.EventHandler(this.CamerasChooser_Load);                 
            this.Shown += new System.EventHandler(this.CamerasChooser_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

 
        #endregion

        //private CodersLab.Windows.Controls.TreeView treeViewNetwork;
        private System.Windows.Forms.TreeView treeViewNetwork;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private Label labelCam;
        private TextBox textBoxCamName;
    }
}