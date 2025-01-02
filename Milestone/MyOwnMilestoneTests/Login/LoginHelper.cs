using Autofac.Features.Metadata;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;
using VideoOS.Platform.Client;
using VideoOS.Platform.ConfigurationItems;
using VideoOS.Platform.Data;
using VideoOS.Platform.Proxy.Alarm;
using VideoOS.Platform.SDK.Platform;
using VideoOS.Platform.SDK.UI.LoginDialog;
using VideoOS.Platform;
using System.Threading;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using System.IO;
using System.Security;
using VideoOS.Platform.Login;




namespace MyOwnMilestoneTests.Login
{

    /// <summary>
    /// 
    /// .NET Library Initialization
    ///    NuGet package for standalone application development, MilestoneSystems.VideoOS.Platform.SDK,
    ///    is available from https://www.nuget.org/profiles/milestonesys. Applications developed using those 
    ///    libraries should be compiled as Any CPU or x64 and can be run in 64-bit architecture.
    ///
    ///    A standalone application using the .NET Library must initialize the components of the library that 
    ///    will be used by the application.
    ///
    ///    The.NET Library currently has six areas to initialize:
    ///
    ///    VideoOS.Platform.SDK – contains the base implementation and configuration access
    ///    VideoOS.Platform.SDK.UI – contains ImageViewerControl and related classes
    ///        VideoOS.Platform.SDK.Export – contains the implementation for the JPEGVideoSource, AVIExporter and DBExporter
    ///        VideoOS.Platform.SDK.Media - contains the implementation for media toolkit
    ///    VideoOS.Platform.SDK.Log - contains the implementation for storing log lines on the server
    ///    VideoOS.Platform.SDK.RemoteRetrievalTask - contains interface for managing 'edge' retrieval tasks
    ///    Each of the DLLs has different dependencies to other DLLs.When you use MilestoneSystems.VideoOS.Platform.SDK 
    ///    NuGet package, all needed DLLs are being copied to the output folder when building the project. 
    ///    These DLLs should be copied with the final solution to the end-user machines via the install process.
    ///
    ///    Note: The VideoOS.Platform.SDK.UI.dll, VideoOS.Platform.SDK.Export.dll and VideoOS.Platform.Media.dll are 
    ///          using C++ dlls.To run in 64-bit environments, they will require your application EXE file being compiled 
    ///          for target x64.
    ///
    ///    Initialization can be done in the Program.cs file like this:
    ///         VideoOS.Platform.SDK.Environment.Initialize();
    ///         VideoOS.Platform.SDK.UI.Environment.Initialize();
    ///         VideoOS.Platform.SDK.Export.Environment.Initialize();
    ///         VideoOS.Platform.SDK.Media.Environment.Initialize();
    ///         VideoOS.Platform.SDK.Log.Environment.Initialize();
    ///         
    ///    The first statement is always required, the others are only required if your application is using features supported by those areas.
    ///
    /// 
    ///    Login Process
    ///        After the environment initialization is complete, the application must log in. The following code shows how 
    ///        to log in using different types of credentials.For instance, the CameraStreamResolution sample shows how to 
    ///        log in with different credential types.
    ///
    ///        Uri uri = new Uri("http://myserver");
    ///        bool secureOnly = true; // If true, only authentication over https is accepted. If false, authentication over both http and https is accepted.
    ///
    ///        // This will reuse the Windows credentials you are logged in with
    ///        NetworkCredential nc = System.Net.CredentialCache.DefaultNetworkCredentials;
    ///
    ///        // This will use specific Windows credentials
    ///        // NetworkCredential nc = new NetworkCredential("username", "password");
    ///
    ///        // You need this to apply "basic" credentials.
    ///        // Below, do AddServer(uri, cc) instead of AddServer(uri, nc)
    ///        // CredentialCache cc = VideoOS.Platform.Login.Util.BuildCredentialCache(uri, "username", "password", "Basic");
    ///
    ///        // Alternatively, the BuildCredentialCache can also build credential for Windows login
    ///        // CredentialCache cc = VideoOS.Platform.Login.Util.BuildCredentialCache(uri, "domain-or-machine-name\username", "password", "Negotiate");
    ///
    ///        VideoOS.Platform.SDK.Environment.AddServer(secureOnly, uri, nc);
    ///
    ///        try
    ///        {
    ///            VideoOS.Platform.SDK.Environment.Login(uri);
    ///        }
    ///        catch (ServerNotFoundMIPException snfe)
    ///        {
    ///            // Report "Server not found: "
    ///        }
    ///        catch (InvalidCredentialsMIPException ice)
    ///        {
    ///            // Report  "Invalid credentials"
    ///        }
    ///        catch (Exception)
    ///        {
    ///            // Report  "Other error connecting to: " + uri.DnsSafeHost;
    ///        }
    ///        
    ///        // No exception thrown means success.
    ///        // Loading the configuration Items may take time. If you wish, you may force a load now.
    ///        // If you don't load the Items explicitly, they will be loaded automatically when needed.
    ///        if (IfeelLikeLoadingNow)
    ///        {
    ///            VideoOS.Platform.SDK.Environment.LoadConfiguration(uri)
    ///        }
    ///    
    /// 
    /// 
    ///    Using the DialogLoginForm
    ///        Another way to initialize the .NET Library is to use the DialogLoginForm to log in and initialize 
    ///        the server connection. This form will show a login dialog, and connect to the server with the 
    ///        credential provided. Only upon successful completion, or cancellation, will the dialog return. 
    ///        Please observe that the DialogLoginForm limits you to log in to one server at a time.
    ///
    ///        private static readonly Guid IntegrationId = new Guid("cb77dfe2-339e-4e6e-9c48-2f1ea09f057f");
    ///        private const string IntegrationName = "My Integration Name";
    ///        private const string Version = "1.0";
    ///        private const string ManufacturerName = "Sample Manufacturer";
    ///        
    ///        [STAThread]
    ///        static void Main()
    ///        {
    ///            Application.EnableVisualStyles();
    ///            Application.SetCompatibleTextRenderingDefault(false);
    ///        
    ///            VideoOS.Platform.SDK.Environment.Initialize();
    ///            // Initialize all the other areas needed in the application.
    ///            DialogLoginForm loginForm = new DialogLoginForm(SetLoginResult, IntegrationId, IntegrationName, Version, ManufacturerName);
    ///            Application.Run(loginForm);
    ///            if (Connected)
    ///            {
    ///                Application.Run(new MainForm());
    ///            }
    ///        }
    ///        
    ///        private static bool Connected = false;
    ///        private static void SetLoginResult(bool connected)
    ///        {
    ///            Connected = connected;
    ///        }
    /// 
    /// </summary>
    internal class LoginHelper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private static SecureString ConvertToSecureString(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            var securePassword = new SecureString();

            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }

            securePassword.MakeReadOnly();
            return securePassword;
        }


        /// <summary>
        /// This method will ask for the necessary parameters.
        /// </summary>
        private static ConnInfo GetLoginParams(string[] args)
        {

            bool mayUseGivenParams = false;

            Console.WriteLine("GetLoginParams. May use the given parameters? Press \"Enter\" for yes (y)...");
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("\t" + args[i]);
            }
            string strMayUseParams = Console.ReadLine();
            mayUseGivenParams = string.IsNullOrEmpty(strMayUseParams) || strMayUseParams.Equals("y");

            if (mayUseGivenParams &&
                args.Length > 2 &&
                !string.IsNullOrEmpty(args[0]) &&
                !string.IsNullOrEmpty(args[1]) &&
                !string.IsNullOrEmpty(args[2]))
            {
                Console.Write("Authentication: Windows Default, Windows or Basic (D/W/B)? Press \"Enter\" for \"Basic\"...");
                string str = Console.ReadLine();

                ConnInfo connInfo = new ConnInfo
                {
                    URL = args[0],
                    AuthorizationMode =
                        str != null && str.Length > 0 && (str.StartsWith("W", true, null) || str.StartsWith("D", true, null)) ?
                            str.StartsWith("W", true, null) ?
                                AuthorizationMode.Windows :
                                AuthorizationMode.DefaultWindows :
                            AuthorizationMode.Basic,
                    UserName = args[1],
                    Password = ConvertToSecureString(args[2])
                };

                Console.WriteLine("GetLoginParams: " + connInfo.ToString());

                return connInfo;
            }
            else
            {
                ConnInfo connInfo = new ConnInfo
                {
                    // change to false to connect to servers older than 2021 R1 or servers not running HTTPS on the Identity/Management Server communication
                    SecureOnly = false
                };

                Console.Write("XProtect server (url): ");
                connInfo.URL = Console.ReadLine();

                if (!connInfo.URL.StartsWith("http://", true, null) && !connInfo.URL.StartsWith("https://", true, null))
                {
                    connInfo.URL = "http://" + connInfo.URL;
                }


                Console.Write("Authentication: Windows Default, Windows or Basic (D/W/B)? Press \"Enter\" for \"Basic\"...");
                string str = Console.ReadLine();
                connInfo.AuthorizationMode =
                    str != null && str.Length > 0 && (str.StartsWith("W", true, null) || str.StartsWith("D", true, null)) ?
                        str.StartsWith("W", true, null) ?
                            AuthorizationMode.Windows :
                            AuthorizationMode.DefaultWindows :
                        AuthorizationMode.Basic;


                if (connInfo.AuthorizationMode != AuthorizationMode.DefaultWindows)
                {
                    Console.Write("Username: ");
                    connInfo.UserName = Console.ReadLine();

                    connInfo.Password = GetPasswordFromConsole();

                    Console.WriteLine();
                }

                Console.WriteLine("\tUsing " + connInfo.ToString());

                return connInfo;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static SecureString GetPasswordFromConsole()
        {
                
            SecureString securePassword = new SecureString();

            ConsoleKeyInfo key;
            Console.Write("Password: ");

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Enter)
                {
                    // Append the character to the password.
                    securePassword.AppendChar(key.KeyChar);
                    Console.Write("*");
                }
                // Exit if Enter key is pressed.
            } while (key.Key != ConsoleKey.Enter);

            securePassword.MakeReadOnly();

            return securePassword;
        }



        /// <summary>
        /// Login routine 
        /// </summary>
        /// <param name="connInfo"></param>
        /// <returns></returns> True if successfully logged in
        private static bool LoginUsingCredentials(ConnInfo connInfo)
        {

            Guid IntegrationId = new Guid("AA2730FE-50BF-4166-8352-920D590B4C07");
            const string IntegrationName = "Just logging in...";
            const string Version = "1.0";
            const string ManufacturerName = "EFACEC";

            
            Uri uri = new UriBuilder(connInfo.URL).Uri;
            CredentialCache cc = new CredentialCache();


            //  This will reuse the Windows credentials you are logged in with
            //    CredentialCache cc = VideoOS.Platform.Login.Util.BuildCredentialCache(uri, "", "", "Negotiate");
            //  This will use specific Windows credentials
            //    CredentialCache cc = VideoOS.Platform.Login.Util.BuildCredentialCache(uri, "mydomain\\test", "M1le!st0n3123", "Negotiate");
            //  You need this to apply Basic user credentials. 
            //    CredentialCache cc = VideoOS.Platform.Login.Util.BuildCredentialCache(uri, "test", "test", "Basic");

            switch (connInfo.AuthorizationMode)
            {
                case AuthorizationMode.DefaultWindows:
                    cc = Util.BuildCredentialCache(uri, "", "", "Negotiate");
                    break;
                case AuthorizationMode.Windows:
                    cc = Util.BuildCredentialCache(uri, connInfo.UserName, connInfo.Password, "Negotiate");
                    break;
                case AuthorizationMode.Basic:
                    cc = Util.BuildCredentialCache(uri, connInfo.UserName, connInfo.Password, "Basic");
                    break;
            }

            VideoOS.Platform.SDK.Environment.AddServer(connInfo.SecureOnly, uri, cc);


            try
            {
                VideoOS.Platform.SDK.Environment.Login(uri, IntegrationId, IntegrationName, Version, ManufacturerName);
            }
            catch (ServerNotFoundMIPException snfe)
            {
                Console.WriteLine("Server not found: " + snfe.Message);
                VideoOS.Platform.SDK.Environment.RemoveServer(uri);
                return false;
            }
            catch (InvalidCredentialsMIPException ice)
            {
                Console.WriteLine("Invalid credentials for: " + ice.Message);
                VideoOS.Platform.SDK.Environment.RemoveServer(uri);
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Internal error connecting to: " + uri.DnsSafeHost);
                VideoOS.Platform.SDK.Environment.RemoveServer(uri);
                return false;
            }


            LoginSettings loginSettings = LoginSettingsCache.GetLoginSettings(uri.DnsSafeHost);
            
            if (loginSettings == null)
            {
                Console.WriteLine($"Login not succeeded for user: {connInfo.UserName} on server: {uri.DnsSafeHost}.");
                VideoOS.Platform.SDK.Environment.RemoveServer(uri);
                return false;
            }

            Console.WriteLine($"Login succeeded for user: {connInfo.UserName} on server: {loginSettings.Uri}.");


            try
            {
                VideoOS.Platform.SDK.Environment.Logout(uri);

                Console.WriteLine("Logged out: " + uri.ToString());
            }
            catch (Exception)
            {
                Console.WriteLine("Internal error when logging out: " + uri.ToString());
                VideoOS.Platform.SDK.Environment.RemoveServer(uri);
                return false;
            }


            return true;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="_url"></param>
        /// <param name="_user"></param>
        /// <param name="_pwd"></param>
        /// <param name="_auth"></param>
        /// <returns></returns>
        public bool LoginUsingSampleAsBase(string[] args)
        {
            Console.WriteLine("LoginUsingSampleAsBase");

            
            // Notifies a waiting thread that an event has occurred. 
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);


            ConnInfo connInfo = GetLoginParams(args);

            bool logged = LoginUsingCredentials(connInfo);

            return logged;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool LoginUsingSampleFromDocumentaX(string[] args)
        {

            Console.WriteLine("LoginUsingSampleFromDocumentaX");

            // Here just to remember but this is already called in Program.Main(..)
            //VideoOS.Platform.SDK.Environment.Initialize();

            // Notifies a waiting thread that an event has occurred.
            AutoResetEvent _resetEvent = new AutoResetEvent(false);

            ConnInfo connInfo = GetLoginParams(args);


            Uri uri = new UriBuilder(connInfo.URL).Uri;



            if (connInfo.AuthorizationMode == AuthorizationMode.Basic)
            {
                // You need this to apply "basic" credentials.
                CredentialCache cc = Util.BuildCredentialCache(uri, connInfo.UserName, connInfo.Password, "Basic");
                VideoOS.Platform.SDK.Environment.AddServer(connInfo.SecureOnly, uri, cc);
            }
            else if(connInfo.AuthorizationMode == AuthorizationMode.DefaultWindows)
            {
                // This will reuse the Windows credentials you are logged in with
                NetworkCredential nc = System.Net.CredentialCache.DefaultNetworkCredentials;
                VideoOS.Platform.SDK.Environment.AddServer(connInfo.SecureOnly, uri, nc);

                // CredentialCache cc = Util.BuildCredentialCache(uri, "", "", "Negotiate");
                //VideoOS.Platform.SDK.Environment.AddServer(connInfo.SecureOnly, uri, cc);
            }
            else if (connInfo.AuthorizationMode == AuthorizationMode.Windows)
            {
                // Alternatively, the BuildCredentialCache can also build credential for Windows login ("domain-or-machine-name\username", "password")
                CredentialCache cc = Util.BuildCredentialCache(uri, connInfo.UserName, connInfo.Password, "Negotiate");
                VideoOS.Platform.SDK.Environment.AddServer(connInfo.SecureOnly, uri, cc);

                // This will use specific Windows credentials
                // NetworkCredential nc = new NetworkCredential("username", "password");
                //VideoOS.Platform.SDK.Environment.AddServer(connInfo.SecureOnly, uri, nc);
            }


            try
            {
                VideoOS.Platform.SDK.Environment.Login(uri);
            }
            catch (ServerNotFoundMIPException snfe)
            {
                Console.WriteLine("Server not found: " + snfe.Message);
                VideoOS.Platform.SDK.Environment.RemoveServer(uri);
                return false;
            }
            catch (InvalidCredentialsMIPException ice)
            {
                Console.WriteLine("Invalid credentials for: " + ice.Message);
                VideoOS.Platform.SDK.Environment.RemoveServer(uri);
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Internal error connecting to: " + uri.DnsSafeHost);
                VideoOS.Platform.SDK.Environment.RemoveServer(uri);
                return false;
            }


            { // the following block was added from the LoginUsingCredentials(..) method. It was not present in the documentaX!
                LoginSettings loginSettings = LoginSettingsCache.GetLoginSettings(uri.DnsSafeHost);

                if (loginSettings == null)
                {
                    Console.WriteLine($"Login not succeeded for user: {connInfo.UserName} on server: {uri.DnsSafeHost}.");
                    VideoOS.Platform.SDK.Environment.RemoveServer(uri);
                    return false;
                }

                Console.WriteLine($"Login succeeded for user: {connInfo.UserName} on server: {loginSettings.Uri}.");
            }


            // No exception thrown means success.
            // Loading the configuration Items may take time. If you wish, you may force a load now.
            // If you don't load the Items explicitly, they will be loaded automatically when needed.
            bool IfeelLikeLoadingNow = true;

            if (IfeelLikeLoadingNow)
            {
                VideoOS.Platform.SDK.Environment.LoadConfiguration(uri);
            }

            try
            {
                VideoOS.Platform.SDK.Environment.Logout(uri);

                Console.WriteLine("Logged out: " + uri.ToString());
            }
            catch (Exception)
            {
                Console.WriteLine("Internal error when logging out: " + uri.ToString());
                VideoOS.Platform.SDK.Environment.RemoveServer(uri);
                return false;
            }


            return true;
        }
    }
}
