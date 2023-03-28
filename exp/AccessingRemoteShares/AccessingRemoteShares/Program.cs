using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Security.AccessControl;


namespace AccessingRemoteShares
{
    class Program
    {
        static void Main(string[] args)
        {

            // From: http://stackoverflow.com/questions/3700871/connect-to-network-drive-with-user-name-and-password
            //NetworkCredential theNetworkCredential = new NetworkCredential(@"domain\username", "password");
            //CredentialCache theNetCache = new CredentialCache();
            //theNetCache.Add(new Uri(@"\\computer"), "Basic", theNetworkCredential);
            //string[] theFolders = Directory.GetDirectories(@"\\computer\share");

            try
            {
                //string strUser = @"MDB-DMS\Administrator";
                //string strPass = "r00tAdm!n";
                string strUser = "zedas"; // "MDB-DMS\\zedas"; 
                string strPass = "Aa12345678";
                string strIP = "172.18.56.145"; //"MDB-DMS";
                string strRemotePC = @"\\" + strIP;
                string strFileDirectory = strRemotePC + @"\c\Users\Zedas\workshop";


                NetworkCredential theNetworkCredential = new NetworkCredential(strUser, strPass);
                CredentialCache theNetCache = new CredentialCache();
                theNetCache.Add(new Uri(strRemotePC), "Basic", theNetworkCredential);
                string[] strFiles = Directory.GetFiles(strFileDirectory);


                Console.WriteLine("\nFiles: ");
                foreach (string s in strFiles)
                {
                    Console.WriteLine(s);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("\n"+ex.Message+"\n");
            }
            Console.WriteLine("\nPress ENTER to exit: ");
            string strRead = Console.ReadLine();

        }
    }



    //public class NetworkConnection : IDisposable
    //{
    //    string _networkName;

    //    public NetworkConnection(string networkName, NetworkCredential credentials)
    //    {
    //        _networkName = networkName;

    //        var netResource = new NetResource()
    //        {
    //            Scope = ResourceScope.GlobalNetwork,
    //            ResourceType = ResourceType.Disk,
    //            DisplayType = ResourceDisplaytype.Share,
    //            RemoteName = networkName
    //        };

    //        var userName = string.IsNullOrEmpty(credentials.Domain)
    //            ? credentials.UserName
    //            : string.Format(@"{0}\{1}", credentials.Domain, credentials.UserName);

    //        var result = WNetAddConnection2(
    //            netResource,
    //            credentials.Password,
    //            userName,
    //            0);

    //        if (result != 0)
    //        {
    //            throw new Win32Exception(result, "Error connecting to remote share");
    //        }
    //    }

    //    ~NetworkConnection()
    //    {
    //        Dispose(false);
    //    }

    //    public void Dispose()
    //    {
    //        Dispose(true);
    //        GC.SuppressFinalize(this);
    //    }

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        WNetCancelConnection2(_networkName, 0, true);
    //    }

    //    [DllImport("mpr.dll")]
    //    private static extern int WNetAddConnection2(NetResource netResource,
    //        string password, string username, int flags);

    //    [DllImport("mpr.dll")]
    //    private static extern int WNetCancelConnection2(string name, int flags,
    //        bool force);
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //public class NetResource
    //{
    //    public ResourceScope Scope;
    //    public ResourceType ResourceType;
    //    public ResourceDisplaytype DisplayType;
    //    public int Usage;
    //    public string LocalName;
    //    public string RemoteName;
    //    public string Comment;
    //    public string Provider;
    //}

    //public enum ResourceScope : int
    //{
    //    Connected = 1,
    //    GlobalNetwork,
    //    Remembered,
    //    Recent,
    //    Context
    //};

    //public enum ResourceType : int
    //{
    //    Any = 0,
    //    Disk = 1,
    //    Print = 2,
    //    Reserved = 8,
    //}

    //public enum ResourceDisplaytype : int
    //{
    //    Generic = 0x0,
    //    Domain = 0x01,
    //    Server = 0x02,
    //    Share = 0x03,
    //    File = 0x04,
    //    Group = 0x05,
    //    Network = 0x06,
    //    Root = 0x07,
    //    Shareadmin = 0x08,
    //    Directory = 0x09,
    //    Tree = 0x0a,
    //    Ndscontainer = 0x0b
    //}
}
