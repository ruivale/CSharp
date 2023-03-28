using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GeneralClasses.Files
{
    public class FileTests
    {
        static void _Main(string[] args)
        {
            try
            {
                bool isFilePresent;
                FileInfo fileInfo;

                string strLogFilePath =
                "D:\\Projects\\Bosch\\Projects\\Utils\\DMTs\\LUAS - DMT\\_releases\\CCTV - DMT\\AlarmLogs\\10.7.0.101.txt";
                //"\"D:\\Projects\\Bosch\\Projects\\Utils\\DMTs\\LUAS - DMT\\_releases\\CCTV - DMT\\AlarmLogs\\10.7.0.101.txt\"";
                //@"""D:\Projects\Bosch\Projects\Utils\DMTs\LUAS - DMT\_releases\CCTV - DMT\AlarmLogs\10.7.0.101.txt""";
                //"D:\\10.7.0.101.txt";



                isFilePresent = File.Exists(strLogFilePath);
                Console.WriteLine("File exist (File)? " + isFilePresent);
                fileInfo = new FileInfo(strLogFilePath);
                isFilePresent = fileInfo.Exists;
                Console.WriteLine("File exist (FileInfo)? " + isFilePresent);

                strLogFilePath = AddQuotesIfRequired(strLogFilePath);

                isFilePresent = File.Exists(strLogFilePath);
                Console.WriteLine("File exist (File)? " + isFilePresent);
                fileInfo = new FileInfo(strLogFilePath);
                isFilePresent = fileInfo.Exists;
                Console.WriteLine("File exist (FileInfo)? " + isFilePresent);

                if (isFilePresent)
                {
                    Console.WriteLine("File exist.");

                    long lLogFileLength = fileInfo.Length;

                    if (lLogFileLength > 1 /** 1024 * 1024*/)
                    {
                        fileInfo.Delete();
                        Console.WriteLine("File was deleted...");
                    }
                }
                else
                {
                    Console.WriteLine("File DOES NOT EXIST!");
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception: "+exc.Message + " " + exc.ToString());
            }

            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }

        private static string AddQuotesIfRequired(string path)
        {
            return !string.IsNullOrEmpty(path) ?
                path.Contains(" ") ? "\"" + path + "\"" : path
                : string.Empty;
        }

    }
}
