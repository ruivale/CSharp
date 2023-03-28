using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Win32;

namespace MyNewService
{
    //
    // Based on http://msdn.microsoft.com/en-us/library/zt39148a.aspx
    //
    // We can also override the OnPause, OnContinue, and OnShutdown methods to define additional processing for your component. 
    //
    // TODO LIST:
    //  - add a background image but don't stretch it 
    //	- add a taskbar icon 
    //	- manage configurations
    //  
    public partial class MyNewService : ServiceBase
    {
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;
        const int SPIF_SENDCHANGE = 0x2;
        const int I_INTERVAL = 5000; //60000 * 15; // 15 minutes

        const string STR_PICTURES_DIR = "Pictures";

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        private Thread thread = null;

        private volatile bool mayContinueToChangeBackgroundImg = true;

        public enum Style : int
        {
            Tiled,
            Centered,
            Stretched
        }


        public MyNewService()
        {
            InitializeComponent();

            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource("MySource", "MyNewLog");
            }
            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("In OnStart");

            Util.WriteToLogFile("OnStart ...");

            mayContinueToChangeBackgroundImg = true;

            try
            {
                thread = new Thread(new ThreadStart(InitWinDesktopBackgroundMonitor));
                thread.Start();
            }
            catch
            {
            }

            Util.WriteToLogFile("... OnStart");
        }



        /// <summary>
        /// 
        /// </summary>
        private void InitWinDesktopBackgroundMonitor()
        {
            Util.WriteToLogFile("InitWinDesktopBackgroundMonitor ...");

            //eventLog1.WriteEntry("In InitWinDesktopBackgroundMonitor ...");
            List<string> listPics = obtainPicFilesInPicHomeDir();
            int nPics = listPics != null ? listPics.Count : 0;

            while (mayContinueToChangeBackgroundImg)
            {
                for (int i = 0; i < nPics; i++)
                {
                    try
                    {                        
                        SetBMP(listPics[i]);
                        System.Threading.Thread.Sleep(I_INTERVAL);
                    }
                    catch (Exception e)
                    {
                        Util.WriteToLogFile("Could not set the " + (listPics != null && listPics.Count < i? listPics[i]: "\"NULL\"") + " file.");
                    }
                }

                System.Threading.Thread.Sleep(I_INTERVAL);

                // Updating ...
                listPics = obtainPicFilesInPicHomeDir();
                nPics = listPics != null ? listPics.Count : 0;
            }

            //eventLog1.WriteEntry("... leaving InitWinDesktopBackgroundMonitor.");
            Util.WriteToLogFile("... InitWinDesktopBackgroundMonitor");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static List<string> obtainPicFilesInPicHomeDir()
        {
            Util.WriteToLogFile("obtainPicFilesInPicHomeDir ...");

            List<string> listPics = new List<string>(128);
            string strDirToSearch4Pics = "";

            try
            {
                strDirToSearch4Pics = "C:\\Users\\Default\\Pictures";
                    //"c:\\" + System.Environment.GetEnvironmentVariable("HOMEPATH", EnvironmentVariableTarget.Process);
                //strDirToSearch4Pics += "\\" + STR_PICTURES_DIR;

                DirectoryInfo di = new DirectoryInfo(strDirToSearch4Pics);

                try
                {
                    /// TODO: optimize this pattern search ...
                    foreach (FileInfo f in di.GetFiles())
                    {
                        if (f.Name.EndsWith("jpg") ||
                            f.Name.EndsWith("jpeg") ||
                            f.Name.EndsWith("gif") ||
                            f.Name.EndsWith("png") ||
                            f.Name.EndsWith("bmp"))
                        {
                            listPics.Add(f.FullName);
                        }
                    }
                }
                catch(Exception e)
                {
                    Util.WriteToLogFile("obtainPicFilesInPicHomeDir Cannot add files to list. Exception: " + e.Message);
                }
            }
            catch (Exception e)
            {
                Util.WriteToLogFile("obtainPicFilesInPicHomeDir Exception: "+e.Message);
            }

            Util.WriteToLogFile("... obtainPicFilesInPicHomeDir. ListPics? "+(listPics != null? ""+listPics.Count: " NULL "));

            return listPics;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        private void SetBMP(string strFileName)
        {

            //int deskHeight = Screen.PrimaryScreen.Bounds.Height;
            //int deskWidth = Screen.PrimaryScreen.Bounds.Width;

            //Bitmap theImage = new Bitmap(strFileName);
            //int iImgWidth = theImage.Size.Width;
            //int iImgHeight = theImage.Size.Height;
            //string fileName = Path.Combine(Path.GetTempPath(), "new.bmp");
            ////fileName = Path.Combine(mySetting.m_settingsPath, "new.bmp");
            //Bitmap img2Desktop = new Bitmap(fileName);

            //using (Graphics g = Graphics.FromImage(img2Desktop))
            //{
            //    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //    //draw the image into the target bitmap
            //    g.DrawImage(theImage, 0, 0, 1920, 1080);
            //}

            ////img2Desktop.Save(fileName);
            ////img2Desktop.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);

            //int iImgWidth2 = img2Desktop.Size.Width;
            //int iImgHeight2 = img2Desktop.Size.Height;

            //img2Desktop.Dispose();


            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            key.SetValue(@"WallpaperStyle", 1.ToString());
            key.SetValue(@"TileWallpaper", 0.ToString());


            //int nResult = WinAPI.SystemParametersInfo(SPI_SETDESKWALLPAPER, 1, fileName, SPIF_SENDCHANGE);
            int nResult = WinAPI.SystemParametersInfo(SPI_SETDESKWALLPAPER, 1, strFileName, SPIF_SENDCHANGE);

            //Console.WriteLine("Your screen resolution is " + deskWidth + "x" + deskHeight +
            //                  ". Img(" + strFileName + ")Res is " + iImgWidth + "x" + iImgHeight +
            //                  ". NewImgRes is " + iImgWidth2 + "x" + iImgHeight2
            //                  );


            //eventLog1.WriteEntry("SetBMP("+strFileName+")");
            Util.WriteToLogFile("SetBMP(" + strFileName + ")");

        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In onStop.");

            mayContinueToChangeBackgroundImg = false;
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public class WinAPI
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        public const int SPI_SETDESKWALLPAPER = 20;
        public const int SPIF_SENDCHANGE = 0x2;

    }  

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
            logFileName = "c:\\temp\\WinDBS.log"; // GetSetting("LOGFILENAME");
            errorLogFileName = "c:\\temp\\WinDBSerror.log"; // GetSetting("ERRORLOGFILENAME");

            //IsDirectoryPresent(StripDirectoryName(logFileName), true);
            //IsDirectoryPresent(StripDirectoryName(errorLogFileName), true);
        }


        /// <summary>
        /// Writes the message to the FileSystem Watcher Log File
        /// </summary>
        public static void WriteToLogFile(string message)
        {
            //if (IsDirectoryPresent(StripDirectoryName(logFileName), true))
            //{
            FileStream fs = null;
            StreamWriter sw = null;
            //string formattedDate;
            string fileName;
            //int indexOfPeriod;

            try
            {
                //formattedDate = "(" + DateTime.Now.ToString("dd - MM - yyyy") + ")";
                //indexOfPeriod = logFileName.LastIndexOf(".");
                fileName = logFileName; //.Insert(indexOfPeriod,formattedDate);

                fs = new FileStream(fileName, FileMode.Append, FileAccess.Write);
                sw = new StreamWriter(fs);
                sw.WriteLine(message);
            }
            catch (Exception ex)
            {
                //WriteToErrorLogFile(ex);
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
                //                    PrintReport.Print();
            }
            //}
        }

    }

}
