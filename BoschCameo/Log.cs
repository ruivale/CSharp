using System;
using System.Text;
using System.IO;
namespace CSharpRuntimeCameo
{
    public class Log
    {
        public const long L_MAX_LOG_FILE_SIZE_IN_BYTES = 5000000000 * 2; // +/- 1 GB
        public const string LOGFILENAME = "Log.dat";
        public const string LOGFILENAMEHTTP = "LogMessages.dat";
        string stFl;
        public static string stLastError = "";

        static Log()
        {

            try
            {
                FileInfo file = new FileInfo(Log.LOGFILENAME);

                if (file.Length > L_MAX_LOG_FILE_SIZE_IN_BYTES)
                {
                    file.Delete();
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine("Log " + exc.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stFile"></param>
        public Log(string stFile)
        {
            stFl = stFile;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stLog"></param>
        /// <returns></returns>
        public bool WriteLog(string stLog)
        {
            try
            {
                if (stLastError == "")
                {
                    stLastError = stLog;
                }
                else if (stLastError.Equals(stLog))
                {
                    return true;
                }
                else
                {
                    stLastError = stLog;
                }

                TextWriter tw = new StreamWriter(stFl);

                // write a line of text to the file
                tw.WriteLine(DateTime.Now + " - " + stLog);

                // close the stream
                tw.Close();

                StreamWriter SW = File.AppendText(stFl);
                SW.WriteLine(DateTime.Now + " - " + stLog);
                SW.Close();
                SW.Dispose();
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stFile"></param>
        /// <param name="stLog"></param>
        /// <returns></returns>
        public static bool WriteLog(string stFile, string stLog)
        {
            try
            {
                if (stLastError == "")
                {
                    stLastError = stLog;
                }
                else if (stLastError.Equals(stLog))
                {
                    return true;
                }
                else
                {
                    stLastError = stLog;
                }

                CheckFileSize();

                
                if (stLog != null && stLog.Length > 0 && stLog[0] == '\n')
                {
                    StreamWriter SW = File.AppendText(stFile);
                    SW.WriteLine(stLog);
                    SW.Close();
                    SW.Dispose();
                    return true;
                }
                else if (stLog != null && stLog.Length > 0)
                {
                    StreamWriter SW = File.AppendText(stFile);
                    SW.WriteLine(DateTime.Now + " - " + stLog);
                    SW.Close();
                    SW.Dispose();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stFile"></param>
        /// <param name="stLog"></param>
        /// <returns></returns>
        public static bool WriteLogWithMiliseconds(string stFile, string stLog)
        {
            try
            {
                CheckFileSize();

                StreamWriter SW = File.AppendText(stFile);
                SW.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " - " + stLog);
                SW.Close();
                SW.Dispose();

                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private static void CheckFileSize()
        {
            FileInfo file = new FileInfo(Log.LOGFILENAME);

            if (file.Length > L_MAX_LOG_FILE_SIZE_IN_BYTES)
            {
                file.Delete();
            }
        }
    }
}
