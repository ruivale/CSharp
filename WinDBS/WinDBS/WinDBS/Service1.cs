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

namespace WinDBS
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
    //  - reorder the IMGs file path list in different ways ...
	//
    public partial class WinDBS : ServiceBase
    {
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;
        const int SPIF_SENDCHANGE = 0x2;
        const int I_INTERVAL = 60000 * 15; // 15 minutes

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
        public enum FilesSorting : int
        {
            Name = 0,
            Size = 1,
            CreationTime = 2
        }

        /// <summary>
        /// 
        /// </summary>
        public WinDBS()
        {
            //Util.WriteToLogFile("WinDBS ...");

            InitializeComponent();

            //if (!System.Diagnostics.EventLog.SourceExists("WinDBS"))
            //{
            //    System.Diagnostics.EventLog.CreateEventSource("WinDBS", "WinDBSLog");
            //}
            //eventLog1.Source = "WinDBS";
            //eventLog1.Log = "WinDBSLog";

            //Util.WriteToLogFile("... WinDBS");
        }

        /// <summary>
        /// 
        /// </summary>
        static void Main()
        {

            //Util.WriteToLogFile("Main ...");

            WinDBS winDBS = new WinDBS();
            winDBS.InitWinDesktopBackgroundMonitor();

            //winDBS.eventLog1.WriteEntry("Main ...");
            //Util.WriteToLogFile("... Main");


  
            //Console.WriteLine("---------------------------------------------------------------------");
            //List<string> listPics;
            //int nFilesSortings = Enum.GetNames(typeof(FilesSorting)).Length;
            //int j = 30;
            //for (int i = 0; i < j; i++)
            //{
            //    listPics = WinDBS.obtainPicFilesInPicHomeDir((int)(DateTime.Now.Ticks % nFilesSortings));

            //    foreach (string strFile in listPics)
            //    {
            //        //Console.WriteLine("\t" + strFile);
            //    }
            //    //Console.WriteLine("");
            //    try{System.Threading.Thread.Sleep(124);}catch { }
            //}
            //Console.WriteLine("-----------------------------------------------------------");
           




        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            //Util.WriteToLogFile("OnStart ...");

            //eventLog1.WriteEntry("In OnStart");

            mayContinueToChangeBackgroundImg = true;

            //try
            //{
            //    thread = new Thread(new ThreadStart(InitWinDesktopBackgroundMonitor));
            //    thread.Start();
            //    //this.InitWinDesktopBackgroundMonitor();
            //}
            //catch 
            //{
            //}

            //Util.WriteToLogFile("... OnStart");
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitWinDesktopBackgroundMonitor()
        {
            //eventLog1.WriteEntry("In InitWinDesktopBackgroundMonitor ...");
            List<string> listPics = 
                WinDBS.obtainPicFilesInPicHomeDir(
                    (int)(DateTime.Now.Ticks % Enum.GetNames(typeof(FilesSorting)).Length));
            int nPics = listPics != null? listPics.Count: 0;

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
                        //eventLog1.WriteEntry("Could not set the " + 
                        //    (listPics != null && listPics.Count < i? listPics[i]: "\"NULL\"") + 
                        //    " file.", EventLogEntryType.Warning);
                    }
                }

                System.Threading.Thread.Sleep(I_INTERVAL);

                // Updating ...
                listPics = WinDBS.obtainPicFilesInPicHomeDir();
                nPics = listPics != null ? listPics.Count : 0;
            }

            //eventLog1.WriteEntry("... leaving InitWinDesktopBackgroundMonitor.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static List<string> obtainPicFilesInPicHomeDir()
        {
            return obtainPicFilesInPicHomeDir(FilesSorting.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static List<string> obtainPicFilesInPicHomeDir(int iSort)
        {
            FilesSorting filesSorting = 
                iSort == (int)FilesSorting.Name ? 
                    FilesSorting.Name:
                    iSort == (int)FilesSorting.Size ? 
                        FilesSorting.Size:
                        FilesSorting.CreationTime;


            return obtainPicFilesInPicHomeDir(filesSorting);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static List<string> obtainPicFilesInPicHomeDir(FilesSorting filesSorting)
        {

            Console.WriteLine("obtainPicFilesInPicHomeDir " + filesSorting);

            List<FileInfo> listFiles = new List<FileInfo>(128);
            List<string> listImgFilePaths = new List<string>(128);
            string strDirToSearch4Pics = "";

            try
            {
                strDirToSearch4Pics = "c:\\"+System.Environment.GetEnvironmentVariable("HOMEPATH", EnvironmentVariableTarget.Process);
                strDirToSearch4Pics += "\\" + STR_PICTURES_DIR;

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
                            listFiles.Add(f);
                        }
                    }

                    switch (filesSorting)
                    {
                        case FilesSorting.Name:
                            // reorder the list ..
                            listFiles.Sort(
                                delegate(FileInfo f1, FileInfo f2)
                                {
                                    return f1.Name.CompareTo(f2.Name);
                                }
                            );
                            break;

                        case FilesSorting.Size:
                            // reorder the list ..
                            listFiles.Sort(
                                delegate(FileInfo f1, FileInfo f2)
                                {
                                    return f1.Length.CompareTo(f2.Length);
                                }
                            );
                            break;

                        default:
                            // reorder the list ..
                            listFiles.Sort(
                                delegate(FileInfo f1, FileInfo f2)
                                {
                                    return f1.CreationTimeUtc.CompareTo(f2.CreationTimeUtc);
                                }
                            );
                            break;
                    }  

                    foreach(FileInfo file in listFiles){
                        listImgFilePaths.Add(file.FullName);
                    }
                }
                catch
                {
                }
            }
            catch (Exception)
            {
            }

            return listImgFilePaths;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="style"></param>
        private static void Set(Uri uri, Style style)
        {
            System.IO.Stream stream = new System.Net.WebClient().OpenRead(uri.ToString());

            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            string strTempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");
            img.Save(strTempPath, System.Drawing.Imaging.ImageFormat.Bmp);

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

            if (style == Style.Stretched)
            {
                key.SetValue(@"WallpaperStyle", 2.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == Style.Centered)
            {
                key.SetValue(@"WallpaperStyle", 1.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == Style.Tiled)
            {
                key.SetValue(@"WallpaperStyle", 1.ToString());
                key.SetValue(@"TileWallpaper", 1.ToString());
            }

            SystemParametersInfo(
                SPI_SETDESKWALLPAPER,
                0,
                strTempPath,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);

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

        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnStop()
        {
            //eventLog1.WriteEntry("In onStop.");

            mayContinueToChangeBackgroundImg = false;

            if (this.thread != null)
            {
                try
                {
                    this.thread.Abort();
                }
                catch 
                {
                    
                    //throw;
                }
            }
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

}
