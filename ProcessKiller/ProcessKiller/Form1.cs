using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ProcessKiller
{

    public partial class frmProcessKiller : Form
    {

        /// <summary>
        /// constructor
        /// </summary>
        public frmProcessKiller()
        {
            InitializeComponent();

            // get an initial list of processes
            UpdateProcessList();
        }


        /// <summary>
        /// Loop through the list of running processes
        /// and add each process name to the process
        /// listbox
        /// </summary>
        private void UpdateProcessList()
        {
            // clear the existing list of any items
            lstProcesses.Items.Clear();

            // loop through the running processes and add
            //each to the list
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            {
                lstProcesses.Items.Add(p.ProcessName + " - " + p.Id);
            }

            // display the number of running processes in
            // a status message at the bottom of the page
            tslProcessCount.Text = "Processes running: " + lstProcesses.Items.Count.ToString();
        }



        /// <summary>
        /// Manually update the contents of the process
        /// listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateProcessList_Click(object sender, EventArgs e)
        {
            UpdateProcessList();
        }



        /// <summary>
        /// Kill the process selected in the process name
        /// and ID listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKill_Click(object sender, EventArgs e)
        {
            // loop through the running processes looking for a match
            // by comparing process name to the name selected in the listbox
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            {
                string[] arr = lstProcesses.SelectedItem.ToString().Split('-');
                string sProcess = arr[0].Trim();
                int iId = Convert.ToInt32(arr[1].Trim());

                if (p.ProcessName == sProcess && p.Id == iId)
                {
                    p.Kill();
                }
            }

            // update the list to show the killed process
            // has been removed
            UpdateProcessList();
        }
    }
}
