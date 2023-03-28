using System;
using System.Configuration;
using System.IO;

namespace FileSysWatcher
{
	/// <summary>
	/// Summary description for Util.
	/// </summary>
	public class Util
	{
		public static string logFileName;
		public static string errorLogFileName;

		/// <summary>
		/// Static Constructor
		/// </summary>
		static Util()
		{
			logFileName = GetSetting("LOGFILENAME");
			errorLogFileName = GetSetting("ERRORLOGFILENAME");

			IsDirectoryPresent(StripDirectoryName(logFileName),true);
			IsDirectoryPresent(StripDirectoryName(errorLogFileName),true);
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
					PrintReport.Print();
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
	}
}
