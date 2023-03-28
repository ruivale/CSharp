namespace PanasonicAxTest
{
    partial class RecordRepForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordRepForm));
            this.recCtl = new AxHD300SDKCONTROLLERLib.AxHD300SDKController();
            this.btPhoto = new System.Windows.Forms.Button();
            this.btFastRewind = new System.Windows.Forms.Button();
            this.btPlayBackward = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.btPlayForward = new System.Windows.Forms.Button();
            this.btNextFrame = new System.Windows.Forms.Button();
            this.btPrevFrame = new System.Windows.Forms.Button();
            this.btFastForward = new System.Windows.Forms.Button();
            this.saveImageDlg = new System.Windows.Forms.SaveFileDialog();
            this.lblTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCamNo = new System.Windows.Forms.Label();
            this.repTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.recCtl)).BeginInit();
            this.SuspendLayout();
            // 
            // recCtl
            // 
            this.recCtl.Enabled = true;
            this.recCtl.Location = new System.Drawing.Point(12, 40);
            this.recCtl.Name = "recCtl";
            this.recCtl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("recCtl.OcxState")));
            this.recCtl.Size = new System.Drawing.Size(437, 301);
            this.recCtl.TabIndex = 0;
            this.recCtl.Error += new AxHD300SDKCONTROLLERLib._DHD300SDKControllerEvents_ErrorEventHandler(this.recCtl_Error);
            // 
            // btPhoto
            // 
            this.btPhoto.Location = new System.Drawing.Point(12, 347);
            this.btPhoto.Name = "btPhoto";
            this.btPhoto.Size = new System.Drawing.Size(54, 23);
            this.btPhoto.TabIndex = 1;
            this.btPhoto.Text = "Photo";
            this.btPhoto.UseVisualStyleBackColor = true;
            this.btPhoto.Click += new System.EventHandler(this.btPhoto_Click);
            // 
            // btFastRewind
            // 
            this.btFastRewind.Location = new System.Drawing.Point(72, 347);
            this.btFastRewind.Name = "btFastRewind";
            this.btFastRewind.Size = new System.Drawing.Size(49, 23);
            this.btFastRewind.TabIndex = 2;
            this.btFastRewind.Text = "<<";
            this.btFastRewind.UseVisualStyleBackColor = true;
            this.btFastRewind.Click += new System.EventHandler(this.btFastRewind_Click);
            // 
            // btPlayBackward
            // 
            this.btPlayBackward.Location = new System.Drawing.Point(182, 347);
            this.btPlayBackward.Name = "btPlayBackward";
            this.btPlayBackward.Size = new System.Drawing.Size(49, 23);
            this.btPlayBackward.TabIndex = 3;
            this.btPlayBackward.Text = "<";
            this.btPlayBackward.UseVisualStyleBackColor = true;
            this.btPlayBackward.Click += new System.EventHandler(this.btPlayBackward_Click);
            // 
            // btPause
            // 
            this.btPause.Location = new System.Drawing.Point(237, 347);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(49, 23);
            this.btPause.TabIndex = 4;
            this.btPause.Text = "II";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btPlayForward
            // 
            this.btPlayForward.Location = new System.Drawing.Point(292, 347);
            this.btPlayForward.Name = "btPlayForward";
            this.btPlayForward.Size = new System.Drawing.Size(49, 23);
            this.btPlayForward.TabIndex = 5;
            this.btPlayForward.Text = ">";
            this.btPlayForward.UseVisualStyleBackColor = true;
            this.btPlayForward.Click += new System.EventHandler(this.btPlayForward_Click);
            // 
            // btNextFrame
            // 
            this.btNextFrame.Location = new System.Drawing.Point(347, 347);
            this.btNextFrame.Name = "btNextFrame";
            this.btNextFrame.Size = new System.Drawing.Size(49, 23);
            this.btNextFrame.TabIndex = 6;
            this.btNextFrame.Text = "|>";
            this.btNextFrame.UseVisualStyleBackColor = true;
            this.btNextFrame.Click += new System.EventHandler(this.btNextFrame_Click);
            // 
            // btPrevFrame
            // 
            this.btPrevFrame.Location = new System.Drawing.Point(127, 347);
            this.btPrevFrame.Name = "btPrevFrame";
            this.btPrevFrame.Size = new System.Drawing.Size(49, 23);
            this.btPrevFrame.TabIndex = 7;
            this.btPrevFrame.Text = "<|";
            this.btPrevFrame.UseVisualStyleBackColor = true;
            this.btPrevFrame.Click += new System.EventHandler(this.btPrevFrame_Click);
            // 
            // btFastForward
            // 
            this.btFastForward.Location = new System.Drawing.Point(400, 347);
            this.btFastForward.Name = "btFastForward";
            this.btFastForward.Size = new System.Drawing.Size(49, 23);
            this.btFastForward.TabIndex = 8;
            this.btFastForward.Text = ">>";
            this.btFastForward.UseVisualStyleBackColor = true;
            this.btFastForward.Click += new System.EventHandler(this.btFastForward_Click);
            // 
            // saveImageDlg
            // 
            this.saveImageDlg.DefaultExt = "jpeg";
            this.saveImageDlg.Filter = "JPEG files|*.jpeg";
            this.saveImageDlg.RestoreDirectory = true;
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(304, 9);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(120, 23);
            this.lblTime.TabIndex = 16;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Camera:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Time:";
            // 
            // lblCamNo
            // 
            this.lblCamNo.Location = new System.Drawing.Point(76, 9);
            this.lblCamNo.Name = "lblCamNo";
            this.lblCamNo.Size = new System.Drawing.Size(100, 23);
            this.lblCamNo.TabIndex = 14;
            this.lblCamNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // repTimer
            // 
            this.repTimer.Interval = 30;
            this.repTimer.Tick += new System.EventHandler(this.repTimer_Tick);
            // 
            // RecordRepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 374);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCamNo);
            this.Controls.Add(this.btFastForward);
            this.Controls.Add(this.btPrevFrame);
            this.Controls.Add(this.btNextFrame);
            this.Controls.Add(this.btPlayForward);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.btPlayBackward);
            this.Controls.Add(this.btFastRewind);
            this.Controls.Add(this.btPhoto);
            this.Controls.Add(this.recCtl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecordRepForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "RecordRepForm";
            this.Shown += new System.EventHandler(this.RecordRepForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecordRepForm_FormClosing);
            this.Load += new System.EventHandler(this.RecordRepForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.recCtl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxHD300SDKCONTROLLERLib.AxHD300SDKController recCtl;
        private System.Windows.Forms.Button btPhoto;
        private System.Windows.Forms.Button btFastRewind;
        private System.Windows.Forms.Button btPlayBackward;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btPlayForward;
        private System.Windows.Forms.Button btNextFrame;
        private System.Windows.Forms.Button btPrevFrame;
        private System.Windows.Forms.Button btFastForward;
        private System.Windows.Forms.SaveFileDialog saveImageDlg;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCamNo;
        private System.Windows.Forms.Timer repTimer;
    }
}