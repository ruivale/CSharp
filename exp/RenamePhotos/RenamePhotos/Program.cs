using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace RenamePhotos
{
    static class Program
    {
        private static Thread newThread;
        private static Form1 form;
        private static string[] args;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            Program.args = args;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            // hooks to catch the APP/Process exit
            Application.ApplicationExit += new EventHandler(ApplicationExitHandler);
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);


            newThread = new Thread(listen);
            newThread.Start();

            form = new Form1();
            Application.Run(form);
        }

        private static void listen()
        {

            string sargs = "";
            foreach(string arg in Program.args)
            {
                byte[] bytes = new byte[arg.Length * sizeof(char)];
                System.Buffer.BlockCopy(arg.ToCharArray(), 0, bytes, 0, bytes.Length);
                System.Text.Decoder decoder = System.Text.Encoding.UTF8.GetDecoder();
                char[] chars = new char[bytes.Length];
                int charLen = decoder.GetChars(bytes, 0, bytes.Length, chars, 0);

                ////char[] chars = arg.ToCharArray();
                ////List<byte> list = new List<byte>(128);
                ////foreach(char c in chars)
                ////{
                ////    list.Add(c.);
                ////}

                //string s = "";
                //foreach (char c in chars)
                //{
                //    s += ((ushort)c).ToString();
                //}

                sargs += "arg:" + arg
                    //+ " decoded:" + s
                    //+ " decoded:" + System.Text.Encoding.UTF8.GetString(bytes)
                    //" decoded:"+new String(chars) 
                    + " \n";
            }
            Console.WriteLine("RenamePhotos: Args="+sargs);


            MessageBox.Show("Args:\n " + sargs);


            bool mayRun = true;

            while (mayRun)
            {
                // Get string from user/stdio if the process caller grabs this process stdinput
                string line = Console.ReadLine(); 

                if (line == "END") // Check string
                {
                    Console.WriteLine("RenamePhotos: Received END from the SDTIN...");
                    Thread.Sleep(1000);

                    //MessageBox.Show(null,
                    //                "_sWrongUserPassword",
                    //                "_sErrorTitle",
                    //                MessageBoxButtons.OK,
                    //                MessageBoxImage.Error,
                    //                MessageBoxResult.OK,
                    //                System.Windows.MessageBoxOptions.RtlReading);

                    //Environment.Exit(190);
                    Application.Exit();
                    //form.Dispose();
                    //form.Close();

                    mayRun = false;
                }

                if(form != null && form.IsDisposed)
                {
                    Console.WriteLine("RenamePhotos: The MAIN form is disposing, so we need to terminate...");
                    mayRun = false;
                }

                Thread.Sleep(100);
            }
        }


        private static void ApplicationExitHandler(Object sender, EventArgs e)
        {
            Console.WriteLine("RenamePhotos: App exit");
        }
        private static void CurrentDomain_ProcessExit(Object sender, EventArgs e)
        {
            Console.WriteLine("RenamePhotos: Process exit");
        }
    }
}
