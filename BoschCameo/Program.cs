using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Bosch.VideoSDK;
using Bosch.VideoSDK.GCALib;

namespace TCameoMainWindow
{
	public static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{

            bool isHwAccelerationEnabled = false;

            // Initializes the variables to pass to the MessageBox.Show method.
            string message = "Do you want to use HW acceleration?";
            string caption = "Bosch Video Sample: HW acceleration";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                isHwAccelerationEnabled = true;
            }


            Bosch.VideoSDK.Core core = new Bosch.VideoSDK.Core();
            // Set VideoSDK in unsecure mode for certain legacy devices, refer to Concepts->Fundamentals->Security Properties in VideoSDK document for more information.
            Bosch.VideoSDK.GCALib.ISecurityProperties sec = (Bosch.VideoSDK.GCALib.ISecurityProperties)core;
            sec.SecurityProperties = (int)(Bosch.VideoSDK.GCALib.SecurityPropertiesEnum.speAllowUnencryptedConnections |
                                           Bosch.VideoSDK.GCALib.SecurityPropertiesEnum.speAllowUnencryptedMediaExports |
                                           Bosch.VideoSDK.GCALib.SecurityPropertiesEnum.speAllowNoForwardSecrecy);


			IHardwareDecodingProperties ihdp = (IHardwareDecodingProperties)core;
			ihdp.HardwareDecodingEnabled = isHwAccelerationEnabled;

			core.Startup();


            Console.WriteLine("\n\n\n");

            //IHardwareDecodingProperties ihdp = (IHardwareDecodingProperties)core;
            Console.WriteLine("IHardwareDecodingProperties.getHardwareDecodingEnabled(): " + ihdp.HardwareDecodingEnabled);

            //ihdp.HardwareDecodingEnabled = false;

			//Console.WriteLine("After IHardwareDecodingProperties.setHardwareDecodingEnabled(false): " + ihdp.HardwareDecodingEnabled);

            Console.WriteLine("\n\n\n");


            Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainWindow());
			core.Shutdown(false);
		}
	}
}
