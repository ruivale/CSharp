using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace MyGUIAppsTests
{
    namespace ShowPrime
    {

        class Brushing : System.Windows.Forms.Form
        {
            private void OnClick(object sender, System.EventArgs e)
            {

                using (Graphics g = CreateGraphics())
                {

                    Brush brush = new HatchBrush(HatchStyle.DiagonalBrick, Color.White, Color.Black);

                    g.DrawString("hello", new Font("Times", 50), brush, new Point(5, 5));

                }

            }

            private System.Windows.Forms.Button button;

            private System.ComponentModel.Container components = null;

            public Brushing()
            {

                InitializeComponent();

            }

            protected override void Dispose(bool disposing)
            {

                if (disposing)
                {

                    if (components != null)
                    {

                        components.Dispose();

                    }

                }

                base.Dispose(disposing);

            }

            private void InitializeComponent()
            {

                this.button = new System.Windows.Forms.Button();

                this.SuspendLayout();

                this.button.Location = new System.Drawing.Point(208, 16);

                this.button.Name = "Click";

                this.button.TabIndex = 0;

                this.button.Text = "Click";

                this.button.Click += new System.EventHandler(this.OnClick);

                this.AutoScaleDimensions = new System.Drawing.Size(5, 13);

                this.ClientSize = new System.Drawing.Size(292, 266);

                this.Controls.AddRange(new System.Windows.Forms.Control[] { this.button });

                this.Name = "Form1";

                this.Text = "Form1";

                this.ResumeLayout(false);

            }

            [System.STAThread]

            static void Main_()
            {

                System.Windows.Forms.Application.Run(new Brushing());

            }

        }
    }
}
