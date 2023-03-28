using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FadeClose
{
    public partial class frmFadeClose : Form
    {
        public frmFadeClose()
        {
            InitializeComponent();
        }

        private void frmFadeClose_Load(object sender, EventArgs e)
        {
            //Fade001: Set the Label Text
            label1.Text = "The Fade Effect is given to" + 
                Environment.NewLine + " this Form by Setting the"+
                "Opacity Property";
        }

        private void frmFadeClose_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Fade003: Cancel Form close action when the opacity is 
            // more than 1%.
            if (this.Opacity > 0.01f)
            {
                e.Cancel = true;
                timer1.Interval = 50;
                timer1.Enabled = true; 
            }
            else
            {
                 timer1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Fade002: Check the Opacity property, When Opacity is 1%
            // Close the form and stop the timer.
            if (this.Opacity > 0.01)
                this.Opacity = this.Opacity - 0.01f;
            else
                this.Close();
        }
    }
}