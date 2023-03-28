using System;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
//using System.Windows.Forms;

namespace AutoHibernate
{
	/// <summary>
	/// Summary description for Util.
	/// </summary>
	public class Util
	{
        public const string S_LOGFILENAME = "LOGFILENAME";
        public const string S_ERRORLOGFILENAME = "ERRORLOGFILENAME";
        public const string S_DAYSOFWEEK = "DAYSOFWEEK";
        public const string S_FIRSTDAYOFWEEK = "FIRSTDAYOFWEEK";
        public const string S_HIBERNATEDAYS = "HIBERNATEDAYS";
        public const string S_HIBERNATETIME = "HIBERNATETIME";

        public const char C_HIBERNATETIME_SEPARATOR = ':';

        public const int I_HOURS = 0;
        public const int I_MINUTES = 1;
        public const int I_SECONDS = 2;


        public static string logFileName;
		public static string errorLogFileName;
		public static string s_daysOfWeek;
		public static string s_firstDayOfWeek;
		public static string s_hibernateDays;
        public static HibernateHour hibernateHour;
        public static List<string> listDaysOfWeek;
        public static List<string> listHibernateDays;  

		/// <summary>
		/// Static Constructor
		/// </summary>
		static Util()
		{
            logFileName = GetSetting(S_LOGFILENAME);
            errorLogFileName = GetSetting(S_ERRORLOGFILENAME);

            // normally: "Sun,Mon,Tue,Wed,Thr,Fri,Sat" 
            s_daysOfWeek = GetSetting(S_DAYSOFWEEK); 
            // normally: "Mon" 
            s_firstDayOfWeek = GetSetting(S_FIRSTDAYOFWEEK); 
            // normally: "Mon,Tue,Wed,Thr,Fri"
            s_hibernateDays = GetSetting(S_HIBERNATEDAYS);
            // time to Hibernate
            string s_time2Hibernate = GetSetting(S_HIBERNATETIME);
            hibernateHour = ObtainDateTimeWhenToHibernate(s_time2Hibernate);

            // Creating the list of values ...
            listDaysOfWeek = ObtainTheWeekDaysFromConfig(s_daysOfWeek);
            listHibernateDays = ObtainTheHibernateDaysFromConfig(s_hibernateDays);

		}

        /// <summary>
        /// Parse a string like: 8:30:00 and builds a new DateTime using 
        /// </summary>
        /// <param name="s_time2Hibernate"></param>
        /// <returns></returns>
        private static HibernateHour ObtainDateTimeWhenToHibernate(string s_time2Hibernate)
        {
            int i_h = 0;
            int i_m = 0;
            int i_s = 0;

            try
            {
                int i = 0;

                foreach (string s_time_param in s_time2Hibernate.Split(C_HIBERNATETIME_SEPARATOR))
                {
                    switch (i)
                    {
                        case I_HOURS:
                            i_h = int.Parse(s_time_param);
                            break;

                        case I_MINUTES:
                            i_m = int.Parse(s_time_param);
                            break;

                        case I_SECONDS:
                            i_s = int.Parse(s_time_param);
                            break;
                    }

                    i++;
                }
            }
            catch (Exception ex)
            {

            }

            //MessageBox.Show("TimeToHibernate -> "+i_h+":" + i_m+ ":"+i_s);

            return new HibernateHour(i_h, i_m, i_s);
        }

        /// <summary>
        /// From a list of comma separated values, obtain the week days name.
        /// </summary>
        /// <param name="s_dOfWeek">Sun,Mon,Tue,Wed,Thr,Fri,Sat</param>
        /// <returns></returns>
        private static List<string> ObtainTheWeekDaysFromConfig(string s_dOfWeek)
        {
            List<string> aListDW = new List<string>();

            if (s_dOfWeek != null)
            {
                foreach (string sDay in s_dOfWeek.Split(','))
                {
                    //MessageBox.Show("Day: " + sDay + ".");
                    aListDW.Add(sDay);
                }

            }

            return aListDW;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s_dOfWeek"></param>
        /// <returns></returns>
        private static List<string> ObtainTheHibernateDaysFromConfig(string s_HiberDays)
        {
            List<string> aListHD = new List<string>();

            if (s_HiberDays != null)
            {
                foreach (string sDay in s_HiberDays.Split(','))
                {
                    //MessageBox.Show("Hiber day: " + sDay + ".");
                    aListHD.Add(sDay);
                }
            }
 
            return aListHD;
        }

        /// <summary>
        /// Search for a given week day name in a list of week days names. 
        /// Example:
        ///   - day name to search for:  Wednesday
        ///   - list of week days names: Mon,Tue,Wed,Thu,Fri
        /// </summary>
        /// <param name="s_day"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsDayInHibernateList(string s_day, List<string> list)
        {
            bool isInList = false;

            foreach (string s_DayInHiberList in list )
            {
                //MessageBox.Show("IsDayInHibernateList s_day:"+s_day+
                //    " s_DayInHiberList: "+s_DayInHiberList +
                //    " s_day short: "+s_day.Substring(0, s_DayInHiberList.Length));

                if(s_DayInHiberList.CompareTo(
                    s_day.Substring(0, s_DayInHiberList.Length)) == 0)
                {
                    isInList = true;
                    break;
                }
            }

            return isInList;
        }

		/// <summary>
		/// Gets The File Name From Specified Path
		/// </summary>
		public static string GetFileNameFromPath(string path)
		{
			string fileName = @"";
			int indexOfLastSlash = 0;
			try
			{
				indexOfLastSlash = path.LastIndexOf(@"\");
				fileName = path.Substring(indexOfLastSlash + 1);
				return fileName;
			}
			catch(Exception ex)
			{
				WriteToErrorLogFile(ex);
				return "";
			}
			finally
			{
			}
		}

		/// <summary>
		/// Gets The Directory Path from the FilePath
		/// </summary>
		public static string StripDirectoryName(string path)
		{
			string direcoryPath = @"";
			int indexOfLastSlash = 0;

			try
			{
				indexOfLastSlash = path.LastIndexOf(@"\");
				direcoryPath = path.Substring(0,indexOfLastSlash);
				return direcoryPath;
			}
			catch(Exception ex)
			{
				WriteToErrorLogFile(ex);
				return "";
			}
			finally
			{
			}
		}

		/// <summary>
		/// Gets Values From The Config File.
		/// </summary>
		public static bool IsDirectoryPresent(string directory,bool create)
		{
			try
			{
				if (!Directory.Exists(directory))
				{
					if (create == true)
					{
						Directory.CreateDirectory(directory);
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					return true;
				}
			}
			catch (Exception ex)
			{
				WriteToErrorLogFile(ex);
				return false;
			}
			finally
			{
			}
		}

		/// <summary>
		/// Gets Values From The Config File.
		/// </summary>
		public static string GetSetting(string val)
		{
			try
			{
				return ConfigurationSettings.AppSettings[val];
			}
			catch (Exception ex)
			{
				WriteToErrorLogFile(ex);
				return "";
			}
			finally
			{
			}
		}

		/// <summary>
		/// Writes the message to the FileSystem Watcher Log File
		/// </summary>
		public static void WriteToLogFile(string message)
		{
			if (IsDirectoryPresent(StripDirectoryName(logFileName),true))
			{
				FileStream fs = null;
				StreamWriter sw = null;
				//string formattedDate;
				string fileName;
				//int indexOfPeriod;

				try
				{
					//formattedDate = "(" + DateTime.Now.ToString("dd - MM - yyyy") + ")";
					//indexOfPeriod = logFileName.LastIndexOf(".");
					fileName = logFileName ; //.Insert(indexOfPeriod,formattedDate);

					fs = new FileStream(fileName,FileMode.Append,FileAccess.Write);
					sw = new StreamWriter(fs);
					sw.WriteLine(message);
				}
				catch (Exception ex)
				{
					WriteToErrorLogFile(ex);
				}
				finally
				{
					if (sw != null)
					{
						sw.Close();
					}

					if (fs != null)
					{
						fs.Close();
					}
					//PrintReport.Print();
				}
			}
		}

		/// <summary>
		/// Writes the Exception to the FileSystem Watcher Error Log File
		/// </summary>
		public static void WriteToErrorLogFile(Exception sourceException)
		{
			if (IsDirectoryPresent(StripDirectoryName(errorLogFileName),true))
			{
				FileStream fs = null;
				StreamWriter sw = null;
				try
				{
					fs = new FileStream(errorLogFileName,FileMode.Append,FileAccess.Write);
					sw = new StreamWriter(fs);
					sw.WriteLine("==================================================================");
					sw.WriteLine("ERROR OCCOURED IN:" + sourceException.Source);
					sw.WriteLine("ERROR DESCRPTION:" + sourceException.Message);
					sw.WriteLine("ERROR DESCRPTION:" + sourceException.StackTrace);
					sw.WriteLine("==================================================================");
					sw.WriteLine("");
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (sw != null)
					{
						sw.Close();
					}

					if (fs != null)
					{
						fs.Close();
					}
				}
			}
		}

        /// <summary>
        /// 
        /// </summary>
        public class HibernateHour
        {
            protected int i_hours = 0;
            protected int i_minutes = 0;
            protected int i_seconds = 0;

            public HibernateHour(int i_h, int i_m, int i_s)
            {
                this.i_hours = i_h;
                this.i_minutes = i_m;
                this.i_seconds = i_s;
            }

            public int GetHours()
            {
                return this.i_hours;
            }
            public int GetMinutes()
            {
                return this.i_minutes;
            }
            public int GetSeconds()
            {
                return this.i_seconds;
            }
        }
	}
}
