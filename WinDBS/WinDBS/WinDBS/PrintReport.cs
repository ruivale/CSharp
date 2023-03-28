using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace WinDBS
{
    /// <summary>
    /// Summary description for PrintReport.
    /// </summary>
    public class PrintReport
    {
        public PrintReport()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //public static void Print()
        //{
        //    try
        //    {
        //        string logFilePath = Util.GetSetting("LOGFILENAME");
        //        string dirPath = Util.StripDirectoryName(logFilePath);
        //        string xmlName = "";
        //        string htmlName;
        //        //string formattedDate;

        //        //formattedDate = "(" + DateTime.Now.ToString("dd - MM - yyyy") + ")";
        //        htmlName = @"\LogReport.html"; // + formattedDate + ".html";
        //        xmlName = CreateXML(logFilePath);
        //        XslCompiledTransform xslt = new XslCompiledTransform();
        //        xslt.Load(@"logStyles.xsl");
        //        xslt.Transform(xmlName, dirPath + htmlName);
        //    }
        //    catch (Exception ex)
        //    {
        //        Util.WriteToErrorLogFile(ex);
        //    }
        //    finally
        //    {
        //    }
        //}

        //private static string CreateXML(string logFile)
        //{
        //    XmlDocument xDoc = null;
        //    FileStream fs = null;
        //    StreamReader sr = null;
        //    string xmlName = "";
        //    string xml = "";
        //    string contents = "";

        //    try
        //    {
        //        xDoc = new XmlDocument();
        //        fs = new FileStream(logFile, FileMode.Open, FileAccess.Read);
        //        sr = new StreamReader(fs);
        //        xmlName = @"log.xml";
        //        xml = "<?xml version=\"1.0\"?><logs>";
        //        contents = "";
        //        string[] headers = { "Name", "FullPath", "ChangeType", "UserName", "Date", "Time" };

        //        contents = sr.ReadLine();
        //        while (contents != null)
        //        {
        //            Char[] separator = { ',' };
        //            string[] val = contents.Split(separator);

        //            xml = xml + "<log>";
        //            for (int i = 0; i < val.Length; i++)
        //            {
        //                xml = xml + "<" + headers[i] + ">" + val[i] + "</" + headers[i] + ">";
        //            }
        //            xml = xml + "</log>";
        //            contents = sr.ReadLine();
        //        }

        //        xml = xml + "</logs>";

        //        xDoc.LoadXml(xml);
        //        xDoc.Save(xmlName);
        //        return xmlName;
        //    }
        //    catch (Exception ex)
        //    {
        //        Util.WriteToErrorLogFile(ex);
        //        return xmlName;
        //    }
        //    finally
        //    {
        //    }
        //}
    }
}
