namespace PanasonicAxTest
{
    partial class SearchForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.endDateTimeNow = new System.Windows.Forms.LinkLabel();
            this.cbEndMin = new System.Windows.Forms.ComboBox();
            this.cbEndSec = new System.Windows.Forms.ComboBox();
            this.cbEndHour = new System.Windows.Forms.ComboBox();
            this.cbBeginMin = new System.Windows.Forms.ComboBox();
            this.cbBeginSec = new System.Windows.Forms.ComboBox();
            this.cbBeginHour = new System.Windows.Forms.ComboBox();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.beginDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.recEventsAll = new System.Windows.Forms.LinkLabel();
            this.recEventsNone = new System.Windows.Forms.LinkLabel();
            this.recEventsListBox = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxCameras = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.endDateTimeNow);
            this.groupBox1.Controls.Add(this.cbEndMin);
            this.groupBox1.Controls.Add(this.cbEndSec);
            this.groupBox1.Controls.Add(this.cbEndHour);
            this.groupBox1.Controls.Add(this.cbBeginMin);
            this.groupBox1.Controls.Add(this.cbBeginSec);
            this.groupBox1.Controls.Add(this.cbBeginHour);
            this.groupBox1.Controls.Add(this.endDateTimePicker);
            this.groupBox1.Controls.Add(this.beginDateTimePicker);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date and Time";
            // 
            // endDateTimeNow
            // 
            this.endDateTimeNow.AutoSize = true;
            this.endDateTimeNow.Location = new System.Drawing.Point(463, 62);
            this.endDateTimeNow.Name = "endDateTimeNow";
            this.endDateTimeNow.Size = new System.Drawing.Size(29, 13);
            this.endDateTimeNow.TabIndex = 10;
            this.endDateTimeNow.TabStop = true;
            this.endDateTimeNow.Text = "Now";
            this.endDateTimeNow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.endDateTimeNow_LinkClicked);
            // 
            // cbEndMin
            // 
            this.cbEndMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndMin.FormattingEnabled = true;
            this.cbEndMin.Location = new System.Drawing.Point(354, 58);
            this.cbEndMin.Name = "cbEndMin";
            this.cbEndMin.Size = new System.Drawing.Size(42, 21);
            this.cbEndMin.TabIndex = 9;
            // 
            // cbEndSec
            // 
            this.cbEndSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndSec.FormattingEnabled = true;
            this.cbEndSec.Location = new System.Drawing.Point(414, 58);
            this.cbEndSec.Name = "cbEndSec";
            this.cbEndSec.Size = new System.Drawing.Size(42, 21);
            this.cbEndSec.TabIndex = 8;
            // 
            // cbEndHour
            // 
            this.cbEndHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndHour.FormattingEnabled = true;
            this.cbEndHour.Location = new System.Drawing.Point(296, 58);
            this.cbEndHour.Name = "cbEndHour";
            this.cbEndHour.Size = new System.Drawing.Size(42, 21);
            this.cbEndHour.TabIndex = 7;
            // 
            // cbBeginMin
            // 
            this.cbBeginMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBeginMin.FormattingEnabled = true;
            this.cbBeginMin.Location = new System.Drawing.Point(354, 18);
            this.cbBeginMin.Name = "cbBeginMin";
            this.cbBeginMin.Size = new System.Drawing.Size(42, 21);
            this.cbBeginMin.TabIndex = 6;
            // 
            // cbBeginSec
            // 
            this.cbBeginSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBeginSec.FormattingEnabled = true;
            this.cbBeginSec.Location = new System.Drawing.Point(414, 18);
            this.cbBeginSec.Name = "cbBeginSec";
            this.cbBeginSec.Size = new System.Drawing.Size(42, 21);
            this.cbBeginSec.TabIndex = 5;
            // 
            // cbBeginHour
            // 
            this.cbBeginHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBeginHour.FormattingEnabled = true;
            this.cbBeginHour.Location = new System.Drawing.Point(296, 18);
            this.cbBeginHour.Name = "cbBeginHour";
            this.cbBeginHour.Size = new System.Drawing.Size(42, 21);
            this.cbBeginHour.TabIndex = 4;
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(45, 58);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.endDateTimePicker.TabIndex = 3;
            // 
            // beginDateTimePicker
            // 
            this.beginDateTimePicker.Location = new System.Drawing.Point(45, 19);
            this.beginDateTimePicker.Name = "beginDateTimePicker";
            this.beginDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.beginDateTimePicker.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "End";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Begin";
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(135, 287);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 1;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(317, 287);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.recEventsAll);
            this.groupBox2.Controls.Add(this.recEventsNone);
            this.groupBox2.Controls.Add(this.recEventsListBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(497, 62);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recording Events";
            // 
            // recEventsAll
            // 
            this.recEventsAll.AutoSize = true;
            this.recEventsAll.Location = new System.Drawing.Point(472, 16);
            this.recEventsAll.Name = "recEventsAll";
            this.recEventsAll.Size = new System.Drawing.Size(18, 13);
            this.recEventsAll.TabIndex = 4;
            this.recEventsAll.TabStop = true;
            this.recEventsAll.Text = "All";
            this.recEventsAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.recEventsAll_LinkClicked);
            // 
            // recEventsNone
            // 
            this.recEventsNone.AutoSize = true;
            this.recEventsNone.Location = new System.Drawing.Point(459, 36);
            this.recEventsNone.Name = "recEventsNone";
            this.recEventsNone.Size = new System.Drawing.Size(33, 13);
            this.recEventsNone.TabIndex = 5;
            this.recEventsNone.TabStop = true;
            this.recEventsNone.Text = "None";
            this.recEventsNone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.recEventsNone_LinkClicked);
            // 
            // recEventsListBox
            // 
            this.recEventsListBox.BackColor = System.Drawing.SystemColors.Control;
            this.recEventsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.recEventsListBox.FormattingEnabled = true;
            this.recEventsListBox.Items.AddRange(new object[] {
            "MANUAL",
            "VMD",
            "SCHEDULE",
            "TRM",
            "EMEERGENCY",
            "COM",
            "VIDEOLOSS"});
            this.recEventsListBox.Location = new System.Drawing.Point(8, 19);
            this.recEventsListBox.MultiColumn = true;
            this.recEventsListBox.Name = "recEventsListBox";
            this.recEventsListBox.Size = new System.Drawing.Size(484, 30);
            this.recEventsListBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxCameras);
            this.groupBox3.Location = new System.Drawing.Point(178, 186);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(171, 48);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Camera";
            // 
            // comboBoxCameras
            // 
            this.comboBoxCameras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCameras.FormattingEnabled = true;
            this.comboBoxCameras.Location = new System.Drawing.Point(44, 19);
            this.comboBoxCameras.Name = "comboBoxCameras";
            this.comboBoxCameras.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCameras.TabIndex = 0;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 322);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.DateTimePicker beginDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.ComboBox cbBeginMin;
        private System.Windows.Forms.ComboBox cbBeginSec;
        private System.Windows.Forms.ComboBox cbBeginHour;
        private System.Windows.Forms.ComboBox cbEndMin;
        private System.Windows.Forms.ComboBox cbEndSec;
        private System.Windows.Forms.ComboBox cbEndHour;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox recEventsListBox;
        private System.Windows.Forms.LinkLabel recEventsAll;
        private System.Windows.Forms.LinkLabel recEventsNone;
        private System.Windows.Forms.LinkLabel endDateTimeNow;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBoxCameras;
    }
}