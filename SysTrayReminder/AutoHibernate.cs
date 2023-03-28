using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;
//using System.Drawing;
using System.Windows.Forms;

namespace AutoHibernate
{
	public class AutoHibernate : System.ServiceProcess.ServiceBase
	{
        private static int I_TIME_TIMER_INTERVAL = 60000; // 1 min

        /// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        /// <summary>
        /// 
        /// </summary>
        private DateTime currentSystemTime = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        private System.Timers.Timer m_TimeTimer = new System.Timers.Timer(I_TIME_TIMER_INTERVAL);



		public AutoHibernate()
		{
            // Just for initialization ...
            new Util();

			// This call is required by the Windows.Forms Component Designer.
            this.InitializeComponent();

			// TODO: Add any initialization after the InitComponent call
            //this.m_TimeTimer.Stop();
		}

        /// <summary>
        /// The timer action listener fired event method call ... ;-)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_TimeTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.currentSystemTime = DateTime.Now;
            //MessageBox.Show("DateTime: " + this.currentSystemTime+" from the timer handler method.");

            string s_day_week_now = this.currentSystemTime.DayOfWeek.ToString();

            if(Util.IsDayInHibernateList(s_day_week_now, Util.listHibernateDays))
            {

                //MessageBox.Show("The " + s_day_week_now+" day is present in the hiber list.");

                // Today is in the hibernate days list. Check for the time ...
                DateTime dateTimeToHiber = new DateTime(
                    this.currentSystemTime.Year,
                    this.currentSystemTime.Month,
                    this.currentSystemTime.Day,
                    Util.hibernateHour.GetHours(),
                    Util.hibernateHour.GetMinutes(),
                    Util.hibernateHour.GetSeconds());

                if (dateTimeToHiber.CompareTo(this.currentSystemTime) < 0) // Earlier, so ..
                {
                    this.Hibernate();
                    //MessageBox.Show("Just hibernating ...");

                    //LockWorkStation();
                }
            }
        }

		// The main entry point for the process
        static void Main_()
        {
            new AutoHibernate();
            System.Threading.Thread.Sleep(60000*5);
        }

		static void Main()
		{
			System.ServiceProcess.ServiceBase[] ServicesToRun;
	
			// More than one user Service may run within the same process. To add
			// another service to this process, change the following line to
			// create a second service object. For example,
			//
			//   ServicesToRun = new System.ServiceProcess.ServiceBase[] {new Service1(), new MySecondUserService()};
			//
			ServicesToRun = new System.ServiceProcess.ServiceBase[] { new  AutoHibernate() };

			System.ServiceProcess.ServiceBase.Run(ServicesToRun);
		}

        /// <summary>
        /// Really hibernate the workstation
        /// </summary>
        private void Hibernate()
        {
            try
            {
                this.m_TimeTimer.Stop();
                Application.SetSuspendState(PowerState.Hibernate, true, true);
            }
            catch (Exception ex)
            {
                Util.WriteToErrorLogFile(ex);
            }
            finally
            {
            }
        }


		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.m_TimeTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.m_TimeTimer_Elapsed);

            this.currentSystemTime = DateTime.Now;
            //MessageBox.Show("DateTime: " + this.currentSystemTime);

        }
		#endregion


        #region Component start/stop/dispose
        /// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) 
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

        /// <summary>
        /// Set things in motion so your service can do its work.
        /// </summary>
        protected override void OnStart(string[] args)
        {
            try
            {
                //this.m_TimeTimer.Stop();                
                this.m_TimeTimer.Start();
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
                this.m_TimeTimer.Stop();
            }
            catch (Exception ex)
            {
                Util.WriteToErrorLogFile(ex);
            }
            finally
            {
            }
        }
        #endregion


        #region Native methods
        /// <summary>
        /// It locks the windows workstation
        /// </summary>
        [DllImport("user32.dll")]
        public static extern void LockWorkStation();

        /// <summary>
        /// Exit windows
        /// </summary>
        /// <param name="uFlags"></param>
        /// <param name="dwReason"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int ExitWindowsEx(int uFlags, int dwReason);
        #endregion
	}
}
