using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Net.NetworkInformation;

namespace GeneralClasses.Ping
{
    class PingTests
    {

        PingTests(string strFullurl)
        {
            string strAddress = string.Empty;

            try
            {
                System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();

                // FullUrl like:
                //      [protocol][strUser[:strPass]@]strAddress[:nPort]
                string[] stAddressOnly = strFullurl.Split('@');
                // ... so we can have something like: strAddress[:nPort]
                stAddressOnly = stAddressOnly[stAddressOnly.Length - 1].Split(':');

                strAddress = stAddressOnly[0];

                PingReply resp = ping.Send(strAddress, 2500);

                //var strURL = this.strAddress;


                if (resp.Status == IPStatus.Success)
                {
                    Console.WriteLine("Ping [" + strAddress + " [" + strFullurl + "]] succeeded...");
                } else
                {
                    Console.WriteLine("Ping [" + strAddress + " [" + strFullurl + "]] FAILED...");
                }
            }
            catch (Exception exc)
            {

                Console.WriteLine("Cannot ping ["+strAddress+" ["+ strFullurl + "]]...");

                throw;
            }
        }

        static void Main(string[] args)
        {
            new PingTests("172.18.56.199");
            new PingTests("user@172.18.56.199");
            new PingTests("user:@172.18.56.199");
            new PingTests("user:pass@172.18.56.199");
            new PingTests("user@172.18.56.199:1757");
            new PingTests("user:@172.18.56.199:1757");
            new PingTests("user:pass@172.18.56.199:1757");

            Console.ReadKey();
        }
    }
}
