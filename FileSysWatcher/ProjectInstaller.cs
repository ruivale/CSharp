using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;

namespace FileSysWatcher
{
	/// <summary>
	/// Summary description for ProjectInstaller.
	/// </summary>
	[RunInstaller(true)]
	public class ProjectInstaller : System.Configuration.Install.Installer
	{
		private System.ServiceProcess.ServiceProcessInstaller FileSysWatcherServiceProcessInstaller;
		private System.ServiceProcess.ServiceInstaller FileSysWatcherServiceInstaller;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ProjectInstaller()
		{
			// This call is required by the Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.FileSysWatcherServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
			this.FileSysWatcherServiceInstaller = new System.ServiceProcess.ServiceInstaller();
			// 
			// FileSysWatcherServiceProcessInstaller
			// 
			this.FileSysWatcherServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
			this.FileSysWatcherServiceProcessInstaller.Password = null;
			this.FileSysWatcherServiceProcessInstaller.Username = null;
			// 
			// FileSysWatcherServiceInstaller
			// 
			this.FileSysWatcherServiceInstaller.ServiceName = "File and System Watcher";
			// 
			// ProjectInstaller
			// 
			this.Installers.AddRange(new System.Configuration.Install.Installer[] {
		        this.FileSysWatcherServiceProcessInstaller,
                this.FileSysWatcherServiceInstaller});

		}
		#endregion
	}
}
