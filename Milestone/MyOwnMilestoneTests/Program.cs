using MyOwnMilestoneTests.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOwnMilestoneTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // The first statement is always required, the others are only required if your application is using features supported by those areas.
            // TODO: Initialize SDK environment and login
            VideoOS.Platform.SDK.Environment.Initialize();
            ////VideoOS.Platform.SDK.UI.Environment.Initialize();
            ////VideoOS.Platform.SDK.Export.Environment.Initialize();
            ////VideoOS.Platform.SDK.Media.Environment.Initialize();
            ////VideoOS.Platform.SDK.Log.Environment.Initialize();


            while (true)
            {
                string loginType = "D";
                Console.Write("\n\nInsert D for LoginUsingSampleFromDocumentaX, S for LoginUsingSampleAsBase or exit to terminate. Press \"Enter\" for D...");
                string strLoginMode = Console.ReadLine();

                if (string.IsNullOrEmpty(strLoginMode) || strLoginMode.Equals("D"))
                {
                    loginType = "D";
                }
                else if (strLoginMode.Equals("S"))
                {
                    loginType = "S";
                }
                else if (strLoginMode.Equals("exit"))
                {
                    Console.WriteLine("Terminating...");
                    Environment.Exit(0);
                }

                LoginHelper loginHelper = new LoginHelper();


                string[] parameters = new string[] { @"http://172.18.56.52", "lab1", "efacecLAB_1"};
                bool isConnected = false;

                if (loginType.Equals("D"))
                {
                    isConnected = loginHelper.LoginUsingSampleFromDocumentaX(parameters);
                }
                else if (loginType.Equals("S"))
                {
                    isConnected = loginHelper.LoginUsingSampleAsBase(parameters);
                }

                Console.WriteLine("Tried to connect using \"LoginUsingSampleFromDocumentaX()\". Result= " + isConnected); 
            }

        }
    }
}
