using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace GeneralClasses.Async
{
    class AsyncTests
    {
        private static string strURI = "http://www.google.com";

        AsyncTests()
        {

        }

        private void MethodSync()
        {
            WebClient webClient = new WebClient();
            string strPage = webClient.DownloadString(strURI);
            Console.WriteLine(strPage);
        }

        //private async void MethodAsync()
        //{
        //    WebClient webClient = new WebClient();
        //    string strPage = "null";
        //    //await webClient.DownloadStringAsync(new Uri(strURI), strPage);
        //    Console.WriteLine(strPage);
        //}



        static void Main_()
        {
        }
    }
}
