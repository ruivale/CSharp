namespace XmlRpcClient
{
    partial class XmlRpcClient
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
            this.rpcAddress = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewCountry = new System.Windows.Forms.ListView();
            this.columnIso = new System.Windows.Forms.ColumnHeader();
            this.columnName = new System.Windows.Forms.ColumnHeader();
            this.columnFlag = new System.Windows.Forms.ColumnHeader();
            this.textBoxCountry = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxNumCode = new System.Windows.Forms.TextBox();
            this.textBoxISO3 = new System.Windows.Forms.TextBox();
            this.textBoxNume = new System.Windows.Forms.TextBox();
            this.textBoxISO = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureFlag = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFlag)).BeginInit();
            this.SuspendLayout();
            // 
            // rpcAddress
            // 
            this.rpcAddress.Location = new System.Drawing.Point(86, 14);
            this.rpcAddress.Name = "rpcAddress";
            this.rpcAddress.Size = new System.Drawing.Size(355, 20);
            this.rpcAddress.TabIndex = 0;
            this.rpcAddress.Text = "http://localhost/MyXmlRpcServer/web/xml-rpc.php";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(454, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Get Server time";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server url:";
            // 
            // listViewCountry
            // 
            this.listViewCountry.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnIso,
            this.columnName,
            this.columnFlag});
            this.listViewCountry.FullRowSelect = true;
            this.listViewCountry.GridLines = true;
            this.listViewCountry.Location = new System.Drawing.Point(15, 94);
            this.listViewCountry.MultiSelect = false;
            this.listViewCountry.Name = "listViewCountry";
            this.listViewCountry.Size = new System.Drawing.Size(562, 285);
            this.listViewCountry.TabIndex = 3;
            this.listViewCountry.UseCompatibleStateImageBehavior = false;
            this.listViewCountry.View = System.Windows.Forms.View.Details;
            this.listViewCountry.SelectedIndexChanged += new System.EventHandler(this.OnSelectionChanged);
            // 
            // columnIso
            // 
            this.columnIso.Text = "ISO";
            this.columnIso.Width = 49;
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 178;
            // 
            // columnFlag
            // 
            this.columnFlag.Text = "Flag url";
            this.columnFlag.Width = 300;
            // 
            // textBoxCountry
            // 
            this.textBoxCountry.Location = new System.Drawing.Point(86, 49);
            this.textBoxCountry.Name = "textBoxCountry";
            this.textBoxCountry.Size = new System.Drawing.Size(491, 20);
            this.textBoxCountry.TabIndex = 4;
            this.textBoxCountry.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Country";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureFlag);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxNumCode);
            this.groupBox1.Controls.Add(this.textBoxISO3);
            this.groupBox1.Controls.Add(this.textBoxNume);
            this.groupBox1.Controls.Add(this.textBoxISO);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(15, 385);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 150);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalii";
            // 
            // textBoxNumCode
            // 
            this.textBoxNumCode.Location = new System.Drawing.Point(108, 94);
            this.textBoxNumCode.Name = "textBoxNumCode";
            this.textBoxNumCode.ReadOnly = true;
            this.textBoxNumCode.Size = new System.Drawing.Size(187, 20);
            this.textBoxNumCode.TabIndex = 7;
            // 
            // textBoxISO3
            // 
            this.textBoxISO3.Location = new System.Drawing.Point(108, 68);
            this.textBoxISO3.Name = "textBoxISO3";
            this.textBoxISO3.ReadOnly = true;
            this.textBoxISO3.Size = new System.Drawing.Size(187, 20);
            this.textBoxISO3.TabIndex = 6;
            // 
            // textBoxNume
            // 
            this.textBoxNume.Location = new System.Drawing.Point(108, 42);
            this.textBoxNume.Name = "textBoxNume";
            this.textBoxNume.ReadOnly = true;
            this.textBoxNume.Size = new System.Drawing.Size(187, 20);
            this.textBoxNume.TabIndex = 5;
            // 
            // textBoxISO
            // 
            this.textBoxISO.Location = new System.Drawing.Point(108, 16);
            this.textBoxISO.Name = "textBoxISO";
            this.textBoxISO.ReadOnly = true;
            this.textBoxISO.Size = new System.Drawing.Size(187, 20);
            this.textBoxISO.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Numeric code:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "ISO3:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nume:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "ISO:";
            // 
            // pictureFlag
            // 
            this.pictureFlag.Location = new System.Drawing.Point(108, 124);
            this.pictureFlag.Name = "pictureFlag";
            this.pictureFlag.Size = new System.Drawing.Size(51, 16);
            this.pictureFlag.TabIndex = 7;
            this.pictureFlag.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Flag:";
            // 
            // XmlRpcClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 547);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCountry);
            this.Controls.Add(this.listViewCountry);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rpcAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "XmlRpcClient";
            this.Text = "XMLRPC Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFlag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rpcAddress;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewCountry;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnFlag;
        private System.Windows.Forms.TextBox textBoxCountry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnIso;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxNumCode;
        private System.Windows.Forms.TextBox textBoxISO3;
        private System.Windows.Forms.TextBox textBoxNume;
        private System.Windows.Forms.TextBox textBoxISO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureFlag;
        private System.Windows.Forms.Label label7;
    }
}

