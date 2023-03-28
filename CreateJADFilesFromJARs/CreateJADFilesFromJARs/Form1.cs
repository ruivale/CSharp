using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using ICSharpCode.SharpZipLib.Zip;

namespace CreateJADFilesFromJARs
{
    public partial class CreateJADFilesFromJARs : Form
    {
        private const string S_MANIFEST_VERSION         = "Manifest-Version";
        private const string S_MIDLET                   = "MIDlet";
        private const string S_MIDLET_JAR_URL           = "MIDlet-Jar-URL";
        private const string S_JAR_FILE_EXT             = ".jar";
        private const string S_JAD_FILE_EXT             = ".jad";
        private const string S_META_INF_DIR             = @"META-INF\*";
        private const string S_MANIFEST_RELATIVE_PATH   = @"\META-INF\MANIFEST.MF";
        private const string S_EXTRACT_DIR_APPEND       = ".dir";

        DirectoryInfo directoryInfo;

        public CreateJADFilesFromJARs()
        {
            InitializeComponent();
            this.listBoxJARs.SelectionMode = SelectionMode.MultiExtended;
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
                this.textBoxSelectedPath.Text = folderBrowserDialog.SelectedPath;

                this.listBoxJARs.Items.Clear();
                string path = folderBrowserDialog.SelectedPath;
                directoryInfo = new DirectoryInfo(path);
                this.Text = directoryInfo.FullName.ToString();

                foreach (string f in Directory.GetFiles(path, "*"+S_JAR_FILE_EXT))
                {
                    string filename = f.Substring(f.LastIndexOf(@"\") + 1);
                    this.listBoxJARs.Items.Add(filename.ToString());
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.buttonStart.Enabled = false;
            this.buttonBrowse.Enabled = false;
            processJADCreation(this.listBoxJARs.SelectedItems);

            /** 4 later optimization */
            //            //ThreadStart ts = new ThreadStart(processJADCreation);
            //            Thread myThread = new Thread(processJADCreation);
            //            myThread.Start(this.listBoxJARs.SelectedItems);

            this.buttonStart.Enabled = true;
            this.buttonBrowse.Enabled = true;
        }

        private void processJADCreation(object collection)
        {
            foreach (string file in ((ListBox.SelectedObjectCollection)collection))
            {
                try
                {
                    this.labelFile.Text = file.ToString();

                    string StrFileName = directoryInfo.FullName.ToString() + @"\" + file;
                    string StrDestDir = StrFileName + S_EXTRACT_DIR_APPEND;
                    FastZip fz = new FastZip();
                    fz.ExtractZip(StrFileName, StrDestDir, S_META_INF_DIR);

                    FileInfo fileMF = new FileInfo(StrDestDir + S_MANIFEST_RELATIVE_PATH);

                    FileStream fsReading = new FileStream(fileMF.ToString(), FileMode.OpenOrCreate, FileAccess.Read);
                    StreamReader streamReader = new StreamReader(fsReading);
                    FileStream fsWriting = new FileStream(
                        StrFileName.Substring(0, StrFileName.Length-4) + S_JAD_FILE_EXT, 
                        FileMode.OpenOrCreate, 
                        FileAccess.Write);
                    StreamWriter streamWriter = new StreamWriter(fsWriting);

                    string line;

                    while ((line = (string)streamReader.ReadLine()) != null )
                    {
                        //MessageBox.Show(file + " file. Line: "+line);

                        streamWriter.WriteLine(line);
                    }

                    // Adding the related JAR line to JAD file ...
                    streamWriter.WriteLine(S_MIDLET_JAR_URL + ": " + file);


                    streamReader.Close();
                    fsReading.Close();
                    streamWriter.Close();
                    fsWriting.Close();

                    Directory.Delete(StrDestDir, true);
                }

                catch (Exception ex)
                {
                    // something went wrong
                    MessageBox.Show(ex.Message, "Error while processing the "+file+" file. Continuing ...");
                }
            }

            this.labelFile.Text = "";
        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxSelectAll.Checked)
            {
                int nJARs = this.listBoxJARs.Items.Count;

                for (int i = 0; i < nJARs; i++)
                {
                    this.listBoxJARs.SetSelected(i, true);
                }
            }
            else
            {
                this.listBoxJARs.ClearSelected();
            }
        }
    }
}
