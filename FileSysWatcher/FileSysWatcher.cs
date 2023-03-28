using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;

namespace FileSysWatcher
{
    public class FileSysWatcher : System.ServiceProcess.ServiceBase
    {
        private System.IO.FileSystemWatcher FSWatcher;
        private string userName;
        private string homedir;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private System.IO.FileStream[] stream;
        private string[] files = { "", "", "", "", ""};
        /*= {
            //"BackInfo.exe",
            //"BackInfo.ini",
            "oemsi.bmp"//,
            //"Local Settings\\Temp\\backinfo.bmp",
            //"Start Menu\\Programs\\Startup\\backinfo.lnk"
        };*/


        public FileSysWatcher()
        {

            homedir = Util.GetSetting("HOMEDIR");

            // This call is required by the Windows.Forms Component Designer.
            //InitializeComponent();

            // TODO: Add any initialization after the InitComponent call

            string[] _files = {
                //"BackInfo.exe",
                //"BackInfo.ini",
                homedir + "oemsi.bmp",
                "C:\\windows\\system32\\oemsi.bmp",
                homedir + "temp/logo/oemsi.jpg",
                homedir + "temp/logo/oemsi.bmp",
                homedir + "temp/logo/oemsi2w.jpg",                
                //"Local Settings\\Temp\\backinfo.bmp",
                //"Start Menu\\Programs\\Startup\\backinfo.lnk"
            };

            Array.Copy(_files, files, _files.Length);
        }

        // The main entry point for the process

        static void Main()
        {
            System.ServiceProcess.ServiceBase[] ServicesToRun;

            // More than one user Service may run within the same process. To add
            // another service to this process, change the following line to
            // create a second service object. For example,
            //
            //   ServicesToRun = new System.ServiceProcess.ServiceBase[] {new Service1(), new MySecondUserService()};
            //
            ServicesToRun = new System.ServiceProcess.ServiceBase[] { new FileSysWatcher() };

            System.ServiceProcess.ServiceBase.Run(ServicesToRun);
        }


        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FSWatcher = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.FSWatcher)).BeginInit();
            // 
            // FSWatcher
            // 
            this.FSWatcher.EnableRaisingEvents = true;
            this.FSWatcher.IncludeSubdirectories = true;
            this.FSWatcher.NotifyFilter = ((System.IO.NotifyFilters)((((((((System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.DirectoryName)
                | System.IO.NotifyFilters.Attributes)
                | System.IO.NotifyFilters.Size)
                | System.IO.NotifyFilters.LastWrite)
                | System.IO.NotifyFilters.LastAccess)
                | System.IO.NotifyFilters.CreationTime)
                | System.IO.NotifyFilters.Security)));
            this.FSWatcher.Path = "C:\\";
            this.FSWatcher.Deleted += new System.IO.FileSystemEventHandler(this.FSWatcher_Deleted);
            this.FSWatcher.Renamed += new System.IO.RenamedEventHandler(this.FSWatcher_Renamed);
            this.FSWatcher.Changed += new System.IO.FileSystemEventHandler(this.FSWatcher_Changed);
            this.FSWatcher.Created += new System.IO.FileSystemEventHandler(this.FSWatcher_Created);
            // 
            // FileSysWatcher
            // 
            this.CanHandlePowerEvent = true;
            this.CanPauseAndContinue = true;
            this.CanShutdown = true;
            this.ServiceName = "File and System Watcher";
            ((System.ComponentModel.ISupportInitialize)(this.FSWatcher)).EndInit();

        }
        #endregion

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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





        /// <summary>
        /// Set things in motion so your service can do its work.
        /// </summary>
        protected override void OnStart(string[] args)
        {
            try
            {
                this.stream = new System.IO.FileStream[files.Length];

                for (int i = 0; i < files.Length; i++)
                {
                    try
                    {
                        this.stream[i] = new System.IO.FileStream(
                            homedir + files[i],
                            System.IO.FileMode.Open,
                            System.IO.FileAccess.Read,
                            System.IO.FileShare.None); //locks file                                            
                        Util.WriteToLogFile("Opened file " + files[i] + ".");
                    }
                    catch (Exception ex)
                    {
                        Util.WriteToErrorLogFile(ex);
                        Util.WriteToLogFile("ERROR: Cannot open file " + files[i] + ".");
                    }
                }
            }
            catch (Exception ex)
            {
                Util.WriteToErrorLogFile(ex);
            }
            finally
            {
            }
        }


        /// <summary>
        /// Stop this service.
        /// </summary>
        protected override void OnStop()
        {
            try
            {
                if (this.stream != null && this.stream.Length > 0)
                {
                    for (int i = 0; i < this.stream.Length; i++)
                    {
                        this.stream[i].Close();
                        //Util.WriteToLogFile("Closed file " + files[i] + ".");
                    }
                }
            }
            catch (Exception ex)
            {
                Util.WriteToErrorLogFile(ex);
            }
            finally
            {
            }
        }


        /***
        /// <summary>
        /// Set things in motion so your service can do its work.
        /// </summary>
        protected override void OnStart_original(string[] args)
        {
            try
            {
                string path = Util.GetSetting("PATHTOWATCH");

                if (Util.IsDirectoryPresent(path, false))
                {
                    FSWatcher.Path = path;
                }
                else
                {
                    Exception customEx = new Exception(@"Path To Watch Does Not Exists, Setting Default Path To Watch To C:\");
                    Util.WriteToErrorLogFile(customEx);
                    FSWatcher.Path = @"C\";
                }

                userName = System.Environment.UserName;
            }
            catch (Exception ex)
            {
                Util.WriteToErrorLogFile(ex);
                FSWatcher.Path = @"C\";
            }
            finally
            {
            }
        }

		/// <summary>
		/// Stop this service.
		/// </summary>
		protected override void OnStop_original()
		{
			// TODO: Add code here to perform any tear-down necessary to stop your service.
		}
        /**/




        /// <summary>
        /// Event occurs when the contents of a File or Directory is changed
        /// </summary>
        private void FSWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            if (e.FullPath.ToUpper() != Util.logFileName.ToUpper() && e.FullPath.ToUpper() != Util.errorLogFileName.ToUpper())
            {
                if (Util.GetFileNameFromPath(e.Name).ToUpper() == "FILESYSWATCHER.EXE.CONFIG")
                {
                    string newPath = Util.GetSetting("PATHTOWATCH");

                    if (newPath.ToUpper() != FSWatcher.Path.ToUpper())
                    {
                        if (Util.IsDirectoryPresent(newPath, false))
                        {
                            FSWatcher.Path = newPath;
                        }
                        else
                        {
                            Exception customEx = new Exception(@"Path To Watch Does Not Exists, Setting Default Path To Watch To C:\");
                            Util.WriteToErrorLogFile(customEx);
                            FSWatcher.Path = @"C\";
                        }
                    }
                }
                string message = @"";
                try
                {
                    message = Util.GetFileNameFromPath(e.Name);
                    message = message + "," + e.FullPath;
                    message = message + "," + "Changed";
                    message = message + "," + userName;
                    message = message + "," + System.DateTime.Now.Date.ToShortDateString();
                    message = message + "," + System.DateTime.Now.TimeOfDay.ToString();
                    Util.WriteToLogFile(message);
                }
                catch (Exception ex)
                {
                    Util.WriteToErrorLogFile(ex);
                }
                finally
                {
                }
            }
        }


        /// <summary>
        /// Event occurs when the a File or Directory is created
        /// </summary>
        private void FSWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            string message = @"";
            try
            {
                message = Util.GetFileNameFromPath(e.Name);
                message = message + "," + e.FullPath;
                message = message + "," + "Created";
                message = message + "," + userName;
                message = message + "," + System.DateTime.Now.Date.ToShortDateString();
                message = message + "," + System.DateTime.Now.TimeOfDay.ToString();
                Util.WriteToLogFile(message);
            }
            catch (Exception ex)
            {
                Util.WriteToErrorLogFile(ex);
            }
            finally
            {
            }
        }


        /// <summary>
        /// Event occurs when the a File or Directory is deleted
        /// </summary>
        private void FSWatcher_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            string message = @"";
            try
            {
                message = Util.GetFileNameFromPath(e.Name);
                message = message + "," + e.FullPath;
                message = message + "," + "Deleted";
                message = message + "," + userName;
                message = message + "," + System.DateTime.Now.Date.ToShortDateString();
                message = message + "," + System.DateTime.Now.TimeOfDay.ToString();
                Util.WriteToLogFile(message);
            }
            catch (Exception ex)
            {
                Util.WriteToErrorLogFile(ex);
            }
            finally
            {
            }
        }


        /// <summary>
        /// Event occurs when the a File or Directory is renamed
        /// </summary>
        private void FSWatcher_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            string message = @"";
            try
            {
                message = Util.GetFileNameFromPath(e.Name);
                message = message + "," + e.FullPath;
                message = message + "," + "Renamed To " + Util.GetFileNameFromPath(e.OldName);
                message = message + "," + userName;
                message = message + "," + System.DateTime.Now.Date.ToShortDateString();
                message = message + "," + System.DateTime.Now.TimeOfDay.ToString();
                Util.WriteToLogFile(message);
            }
            catch (Exception ex)
            {
                Util.WriteToErrorLogFile(ex);
            }
            finally
            {
            }
        }
    }
}
