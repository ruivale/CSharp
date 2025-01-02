using System;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Security;
using System.Security.Claims;
using System.Security.Principal;
//using VideoOS.Platform.Common.OAuth;
using VideoOS.Platform.Login;
using VideoOS.Platform.OAuth;
using VideoOS.Platform.SDK.UI.Properties;




namespace MyOwnMilestoneTests.Login
{
    public class ConnInfo
    {
        private CredentialCache _credentials;

        private volatile bool _isCancelled;

        internal string URL { get; set; }

        internal Uri ServerAddress { get; set; }

        internal AuthType AuthType { get; set; }

        internal string DomainName { get; set; }

        internal string UserName { get; set; }

        internal SecureString Password { get; set; }

        internal bool SecureOnly { get; set; }

        internal AuthorizationMode AuthorizationMode { get; set; }

        //internal IdpExternalProviderInfo SelectedExternalProvider { get; set; }

        internal IMipTokenCache MipTokenCache { get; set; }

        internal bool IsCancelled
        {
            get
            {
                return _isCancelled;
            }
            set
            {
                _isCancelled = value;
            }
        }


        public ConnInfo() { }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="uiConnInfo"></param>
        internal ConnInfo(Uri serverAddress, AuthType authType, string userName, SecureString password, bool secureOnly/*, IdpExternalProviderInfo selectedExternalProvider*/)
        {
            ServerAddress = serverAddress;
            SetAuthentication(authType, userName, password);
            SecureOnly = secureOnly;
            //SelectedExternalProvider = selectedExternalProvider;
        }


        /// <summary>
        /// 
        /// </summary>
        private void SetWindowsAuthentication()
        {
            UserName = WindowsIdentity.GetCurrent().Name;
            Password = null;
            if (_credentials == null)
            {
                _credentials = new CredentialCache();
            }

            if (_credentials.GetCredential(ServerAddress, "Negotiate") != null)
            {
                _credentials.Remove(ServerAddress, "Negotiate");
            }

            _credentials.Add(ServerAddress, "Negotiate", CredentialCache.DefaultNetworkCredentials);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="authenticationType"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <exception cref="UIConnInfoException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void SetAuthentication(AuthType authenticationType, string userName, SecureString password)
        {
            UserName = userName;
            Password = password;
            switch (authenticationType)
            {
                case AuthType.WindowsDefault:
                    SetWindowsAuthentication();
                    break;
                case AuthType.Windows:
                    {
                        string[] array = userName.Split('\\');
                        if (array.Length == 1)
                        {
                            UserName = array[0];
                            DomainName = string.Empty;
                        }
                        else
                        {
                            if (array.Length != 2)
                            {
                                throw new Exception("LoginInvalidUsername");
                            }

                            DomainName = array[0];
                            UserName = array[1];
                        }

                        _credentials = new CredentialCache();
                        _credentials.Add(ServerAddress, "Negotiate", new NetworkCredential(UserName, Password, DomainName));
                        break;
                    }
                case AuthType.Simple:
                    _credentials = new CredentialCache();
                    _credentials.Add(ServerAddress, "Basic", new NetworkCredential(UserName, Password));
                    break;
                case AuthType.ExternalProvider:
                    _credentials = null;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("authenticationType");
            }

            AuthType = authenticationType;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return 
                "ConnInfo(DomainName=" + DomainName + "\n\tURL=" + URL +
                "\n\tUserName=" + UserName + "\n\tPassword=" + Password.ToString() +
                "\n\tSecureOnly=" + SecureOnly + "\n\tAuthorizationMode=" + AuthorizationMode;

        }
    }
}
