using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RenamePhotos
{
    public partial class Form1 : Form
    {
        private const string S_JPG_FILE_EXT = ".jpg";

        DirectoryInfo directoryInfo;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            // open a file chooser ...
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = false;
            folderBrowserDialog.ShowDialog();

            if (folderBrowserDialog.SelectedPath != null &&
                folderBrowserDialog.SelectedPath.Length > 0)
            {
                // Actualize the text comp with the selected path ...
                this.textBoxDir.Text = folderBrowserDialog.SelectedPath;

                this.listBoxActualFiles.Items.Clear();
                string path = folderBrowserDialog.SelectedPath;
                directoryInfo = new DirectoryInfo(path);
                this.Text = directoryInfo.FullName.ToString();

                foreach (string f in Directory.GetFiles(path, "*" + S_JPG_FILE_EXT))
                {
                    string filename = f.Substring(f.LastIndexOf(@"\") + 1);
                    this.listBoxActualFiles.Items.Add(filename.ToString());
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            //Environment.Exit(0);
            //Application.Exit();
            this.Dispose();
            //this.Close();
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            this.buttonBrowse.Enabled = false;
            this.buttonProcess.Enabled = false;

            processRename(this.listBoxActualFiles.SelectedItems);

            /** 4 later optimization */
            //            //ThreadStart ts = new ThreadStart(processJADCreation);
            //            Thread myThread = new Thread(processJADCreation);
            //            myThread.Start(this.listBoxJARs.SelectedItems);

            this.buttonBrowse.Enabled = true;
            this.buttonProcess.Enabled = true;

        }

        private void processRename(object collection)
        {
            //foreach (string file in ((ListBox.SelectedObjectCollection)collection))
            //{
            //    try
            //    {
            //        this.labelFileBeingProcessed.Text = file.ToString();

            //        string StrFileName = directoryInfo.FullName.ToString() + @"\" + file;
            //        string StrDestDir = StrFileName + S_EXTRACT_DIR_APPEND;
            //        FastZip fz = new FastZip();
            //        fz.ExtractZip(StrFileName, StrDestDir, S_META_INF_DIR);

            //        FileInfo fileMF = new FileInfo(StrDestDir + S_MANIFEST_RELATIVE_PATH);

            //    }

            //    catch (Exception ex)
            //    {
            //        // something went wrong
            //        MessageBox.Show(ex.Message, "Error while processing the " + file + " file. Continuing ...");
            //    }
            //}

            //this.labelFileBeingProcessed.Text = "";
        }

    }
}
