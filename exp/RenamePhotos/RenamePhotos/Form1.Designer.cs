namespace RenamePhotos
{
    partial class Form1
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
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.textBoxDir = new System.Windows.Forms.TextBox();
            this.listBoxActualFiles = new System.Windows.Forms.ListBox();
            this.listBoxNewFiles = new System.Windows.Forms.ListBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.textBoxReplacing = new System.Windows.Forms.TextBox();
            this.labelCharToReplace = new System.Windows.Forms.Label();
            this.labelReplaceBy = new System.Windows.Forms.Label();
            this.textBoxReplaceBy = new System.Windows.Forms.TextBox();
            this.labelFile = new System.Windows.Forms.Label();
            this.labelFileBeingProcessed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(380, 12);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 20);
            this.buttonBrowse.TabIndex = 0;
            this.buttonBrowse.Text = "Select";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // textBoxDir
            // 
            this.textBoxDir.Location = new System.Drawing.Point(26, 12);
            this.textBoxDir.Name = "textBoxDir";
            this.textBoxDir.Size = new System.Drawing.Size(348, 20);
            this.textBoxDir.TabIndex = 1;
            // 
            // listBoxActualFiles
            // 
            this.listBoxActualFiles.FormattingEnabled = true;
            this.listBoxActualFiles.Location = new System.Drawing.Point(26, 38);
            this.listBoxActualFiles.Name = "listBoxActualFiles";
            this.listBoxActualFiles.Size = new System.Drawing.Size(172, 212);
            this.listBoxActualFiles.TabIndex = 2;
            // 
            // listBoxNewFiles
            // 
            this.listBoxNewFiles.FormattingEnabled = true;
            this.listBoxNewFiles.Location = new System.Drawing.Point(283, 38);
            this.listBoxNewFiles.Name = "listBoxNewFiles";
            this.listBoxNewFiles.Size = new System.Drawing.Size(172, 212);
            this.listBoxNewFiles.TabIndex = 3;
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(380, 268);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 20);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(204, 230);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(75, 20);
            this.buttonProcess.TabIndex = 5;
            this.buttonProcess.Text = "Process";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // textBoxReplacing
            // 
            this.textBoxReplacing.Location = new System.Drawing.Point(204, 72);
            this.textBoxReplacing.Name = "textBoxReplacing";
            this.textBoxReplacing.Size = new System.Drawing.Size(73, 20);
            this.textBoxReplacing.TabIndex = 6;
            // 
            // labelCharToReplace
            // 
            this.labelCharToReplace.AutoSize = true;
            this.labelCharToReplace.Location = new System.Drawing.Point(204, 56);
            this.labelCharToReplace.Name = "labelCharToReplace";
            this.labelCharToReplace.Size = new System.Drawing.Size(58, 13);
            this.labelCharToReplace.TabIndex = 7;
            this.labelCharToReplace.Text = "Replacing:";
            // 
            // labelReplaceBy
            // 
            this.labelReplaceBy.AutoSize = true;
            this.labelReplaceBy.Location = new System.Drawing.Point(204, 98);
            this.labelReplaceBy.Name = "labelReplaceBy";
            this.labelReplaceBy.Size = new System.Drawing.Size(62, 13);
            this.labelReplaceBy.TabIndex = 9;
            this.labelReplaceBy.Text = "ReplaceBy:";
            // 
            // textBoxReplaceBy
            // 
            this.textBoxReplaceBy.Location = new System.Drawing.Point(204, 114);
            this.textBoxReplaceBy.Name = "textBoxReplaceBy";
            this.textBoxReplaceBy.Size = new System.Drawing.Size(73, 20);
            this.textBoxReplaceBy.TabIndex = 8;
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Location = new System.Drawing.Point(23, 275);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(29, 13);
            this.labelFile.TabIndex = 10;
            this.labelFile.Text = "File: ";
            // 
            // labelFileBeingProcessed
            // 
            this.labelFileBeingProcessed.AutoSize = true;
            this.labelFileBeingProcessed.Location = new System.Drawing.Point(58, 275);
            this.labelFileBeingProcessed.Name = "labelFileBeingProcessed";
            this.labelFileBeingProcessed.Size = new System.Drawing.Size(0, 13);
            this.labelFileBeingProcessed.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 300);
            this.Controls.Add(this.labelFileBeingProcessed);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.labelReplaceBy);
            this.Controls.Add(this.textBoxReplaceBy);
            this.Controls.Add(this.labelCharToReplace);
            this.Controls.Add(this.textBoxReplacing);
            this.Controls.Add(this.buttonProcess);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.listBoxNewFiles);
            this.Controls.Add(this.listBoxActualFiles);
            this.Controls.Add(this.textBoxDir);
            this.Controls.Add(this.buttonBrowse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.TextBox textBoxDir;
        private System.Windows.Forms.ListBox listBoxActualFiles;
        private System.Windows.Forms.ListBox listBoxNewFiles;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.TextBox textBoxReplacing;
        private System.Windows.Forms.Label labelCharToReplace;
        private System.Windows.Forms.Label labelReplaceBy;
        private System.Windows.Forms.TextBox textBoxReplaceBy;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Label labelFileBeingProcessed;
    }
}

