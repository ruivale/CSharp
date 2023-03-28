using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace PC_Controller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoOperation(listView1.SelectedItems[0].Text);
        }


        private void DoOperation(string oparation)
        {
            string filename = string.Empty;
            string arguments = string.Empty;

            switch (oparation)
            {
                case "Shut Down":
                    filename = "shutdown.exe";
                    arguments = "-s";
                    break;

                case "Restart":

                    filename = "shutdown.exe";
                    arguments = "-r";
                    break;

                case "Logoff":

                    filename = "shutdown.exe";
                    arguments = "-l";
                    break;

                case "Lock":

                    filename = "Rundll32.exe";
                    arguments = "User32.dll, LockWorkStation";
                    break;
                case "Hibernation":

                    filename = @"%windir%\system32\rundll32.exe";
                    arguments = "PowrProf.dll, SetSuspendState";
                    break;
                case "Sleep":

                    filename = "Rundll32.exe";
                    arguments = "powrprof.dll, SetSuspendState 0,1,0";
                    break;
            }

            ProcessStartInfo startinfo = new ProcessStartInfo(filename, arguments);
            Process.Start(startinfo);
            this.Close();
        }
    }
}
