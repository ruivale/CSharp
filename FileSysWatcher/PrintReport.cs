using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace FileSysWatcher
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

		public static void Print()
		{
			try
			{
				string logFilePath = Util.GetSetting("LOGFILENAME");
				string dirPath = Util.StripDirectoryName(logFilePath);
				string xmlName = "";
				string htmlName;
				//string formattedDate;

				//formattedDate = "(" + DateTime.Now.ToString("dd - MM - yyyy") + ")";
				htmlName = @"\LogReport.html"; // + formattedDate + ".html";
				xmlName = CreateXML(logFilePath);
				XslTransform xslt = new XslTransform();
				xslt.Load(@"logStyles.xsl");
				xslt.Transform(xmlName, dirPath + htmlName,null);
			}
			catch(Exception ex)
			{
				Util.WriteToErrorLogFile(ex);
			}
			finally
			{
			}
		}

		private static string CreateXML(string logFile)
		{
			XmlDocument xDoc = null;
			FileStream fs = null;
			StreamReader sr = null;
			string xmlName = "";
			string xml = "";
			string contents = "";
	
			try
			{
				xDoc = new XmlDocument();
				fs = new FileStream(logFile,FileMode.Open,FileAccess.Read);
				sr = new StreamReader(fs);
				xmlName = @"log.xml";
				xml = "<?xml version=\"1.0\"?><logs>";
				contents = "";
				string[] headers = {"Name","FullPath","ChangeType","UserName","Date","Time"};

				contents = sr.ReadLine();
				while (contents != null)
				{
					Char[] separator = {','};
					string[] val = contents.Split(separator);
								
					xml = xml + "<log>";
					for (int i = 0;i < val.Length;i++)
					{
						xml = xml + "<" + headers[i] + ">" + val[i] + "</" + headers[i] + ">";
					}
					xml = xml + "</log>";
					contents = sr.ReadLine();
				}

				xml = xml + "</logs>";

				xDoc.LoadXml(xml);
				xDoc.Save(xmlName);
				return xmlName;
			}
			catch(Exception ex)
			{
				Util.WriteToErrorLogFile(ex);
				return xmlName;
			}
			finally
			{
			}
		}
	}
}
