using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms; 


namespace MyGUIAppsTests
{
    namespace ShowPrime
    {
        public class ShowPrime : Form 
        {

            public System.Windows.Forms.ProgressBar progressBar;

            private System.Windows.Forms.Label label1;

            private System.Windows.Forms.TextBox textBoxInput;

            private System.Windows.Forms.TextBox textBoxResult;

            private System.Windows.Forms.Button buttonStart;

            private System.Windows.Forms.Button buttonCancel;

            private System.ComponentModel.BackgroundWorker backgroundWorker;


            // the class declaration the public part that exposes the

            public ShowPrime()
            {
                // its implementation

                InitializeComponent();

                InitializeBackgoundWorker();

            }

            private void InitializeBackgoundWorker()
            {

                backgroundWorker.DoWork += DoWork;

                backgroundWorker.RunWorkerCompleted += Complete;

                backgroundWorker.ProgressChanged += ProgressChanged;

                backgroundWorker.WorkerReportsProgress = true;

                backgroundWorker.WorkerSupportsCancellation = true;

            }

            private void DoWork(object sender, DoWorkEventArgs e)
            {

                BackgroundWorker worker = sender as BackgroundWorker;

                e.Result = IsPrime((int)e.Argument, worker, e);

            }

            private void ProgressChanged(object sender, ProgressChangedEventArgs e)
            {

                progressBar.Value = e.ProgressPercentage;

            }

            private void Complete(object sender, RunWorkerCompletedEventArgs e)
            {

                textBoxInput.Enabled = true;

                buttonStart.Enabled = true;

                buttonCancel.Enabled = false;

                if (e.Error != null)

                    MessageBox.Show(e.Error.Message);

                else if (e.Cancelled)

                    textBoxResult.Text = "Processing cancelled!";

                else

                    textBoxResult.Text = e.Result.ToString();

            }

            private void buttonStart_Click(object sender, EventArgs e)
            {

                int number = 0;

                if (int.TryParse(textBoxInput.Text, out number))
                {

                    textBoxResult.Text = String.Empty;

                    textBoxInput.Enabled = false;

                    buttonStart.Enabled = false;

                    buttonCancel.Enabled = true;

                    progressBar.Value = 0;

                    backgroundWorker.RunWorkerAsync(number);

                }
                else textBoxResult.Text = "input invalid!";

            }

            private void buttonCancel_Click(object sender, EventArgs e)
            {

                backgroundWorker.CancelAsync();

                buttonCancel.Enabled = false;

            }

            private string IsPrime(int number, BackgroundWorker worker, DoWorkEventArgs e)
            {

                int root = ((int)System.Math.Sqrt(number)) + 1;

                int highestPercentageReached = 0;

                for (int i = 2; i < root; i++)
                {

                    if (worker.CancellationPending)
                    {

                        e.Cancel = true;

                        return String.Empty;

                    }
                    else
                    {

                        if (number % i == 0)

                            return "can be divided by " + i.ToString();

                        int percentComplete = (int)((float)i / (float)root * 100);

                        if (percentComplete > highestPercentageReached)
                        {

                            highestPercentageReached = percentComplete;

                            worker.ReportProgress(percentComplete);

                        }

                    }

                }

                return "is prime";

            }


            [STAThread]

            static void Main_()
            {
                // program entry point after importing class libraries as

                Application.Run(new ShowPrime()); // separated by namespaces

            }

            private System.ComponentModel.IContainer components = null;


            protected override void Dispose(bool disposing)
            {

                if (disposing && (components != null))
                {

                    components.Dispose();

                }

                base.Dispose(disposing);
            }


            #region Windows Form Designer generated code


            private void InitializeComponent()
            {

                this.progressBar = new System.Windows.Forms.ProgressBar();

                this.label1 = new System.Windows.Forms.Label();

                this.textBoxInput = new System.Windows.Forms.TextBox();

                this.textBoxResult = new System.Windows.Forms.TextBox();

                this.buttonStart = new System.Windows.Forms.Button();

                this.buttonCancel = new System.Windows.Forms.Button();

                this.backgroundWorker = new System.ComponentModel.BackgroundWorker();

                this.SuspendLayout();


                // Location, Name, Size,TabIndex, Name and Text properties as set in Visual Studio

                this.progressBar.Location = new System.Drawing.Point(12, 33);

                this.progressBar.Name = "progressBar";

                this.progressBar.Size = new System.Drawing.Size(392, 23);

                this.progressBar.TabIndex = 0;

                this.label1.AutoSize = true; // the property for Label1 sets autosize=true

                this.label1.Location = new System.Drawing.Point(11, 9);

                this.label1.Name = "label1";

                this.label1.Size = new System.Drawing.Size(28, 13);

                this.label1.TabIndex = 1;

                this.label1.Text = "Num:"; // the text property is set to Num

                this.textBoxInput.Location = new System.Drawing.Point(48, 5);

                this.textBoxInput.Name = "textBoxInput";

                this.textBoxInput.Size = new System.Drawing.Size(181, 20);

                this.textBoxInput.TabIndex = 2;

                this.textBoxResult.Location = new System.Drawing.Point(235, 5);

                this.textBoxResult.Name = "textBoxResult";

                this.textBoxResult.ReadOnly = true;

                this.textBoxResult.Size = new System.Drawing.Size(169, 20);

                this.textBoxResult.TabIndex = 3;

                this.buttonStart.Location = new System.Drawing.Point(412, 4);

                this.buttonStart.Name = "buttonStart";

                this.buttonStart.Size = new System.Drawing.Size(75, 23);

                this.buttonStart.TabIndex = 4;

                this.buttonStart.Text = "Start";

                this.buttonStart.Click += new

                System.EventHandler(this.buttonStart_Click);

                this.buttonCancel.Location = new System.Drawing.Point(412, 33);

                this.buttonCancel.Name = "buttonCancel";

                this.buttonCancel.Size = new System.Drawing.Size(75, 23);

                this.buttonCancel.TabIndex = 5;

                this.buttonCancel.Text = "Cancel";

                this.buttonCancel.Click += new

                System.EventHandler(this.buttonCancel_Click);

                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);

                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

                this.ClientSize = new System.Drawing.Size(499, 70);

                this.Controls.Add(this.buttonCancel);

                this.Controls.Add(this.buttonStart);

                this.Controls.Add(this.textBoxResult);

                this.Controls.Add(this.textBoxInput);

                this.Controls.Add(this.label1);

                this.Controls.Add(this.progressBar);

                this.Name = "ShowPrime";

                this.Text = "ShowPrime";

                this.ResumeLayout(false);

                this.PerformLayout();

            }

            #endregion


        }


    }

}

