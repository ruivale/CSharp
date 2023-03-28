using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Discovery;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Net;
using InvokingWebServices.org.onvif.device;
using InvokingWebServices.org.onvif.media;
using InvokingWebServices.org.onvif.ptz20;
using System.Threading;



namespace InvokingWebServices
{
    class RealyTryToCommunicateWithACamera
    {

        //private static string strIP = "172.18.56.130", strLogin = "Admin", strPass = "1234";
        private static string strIP = "172.18.56.218", strLogin = "root", strPass = "root";
        //private static string strIP = "172.18.56.164", strLogin = "root", strPass = "root";


        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            for (int i = 0; i < 1; i++)
            {
                processCameraInteraction();
            }

            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void _Main(string[] args)
        {
            var endPoint = new UdpDiscoveryEndpoint(DiscoveryVersion.WSDiscoveryApril2005);

            var discoveryClient = new DiscoveryClient(endPoint);

            discoveryClient.FindProgressChanged += discoveryClient_FindProgressChanged;

            discoveryClient.FindCompleted += discoveryClient_FindCompleted;

            FindCriteria findCriteria = new FindCriteria();
            findCriteria.Duration = new TimeSpan(0, 0, 2);//TimeSpan.MaxValue;
            findCriteria.MaxResults = int.MaxValue;
            discoveryClient.FindAsync(findCriteria);

            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void throughDotNetOnlyClasses(string[] args)
        {

            //System.DateTime UTCTime = System.DateTime.UtcNow;

            //Console.WriteLine("\n");
            //Console.WriteLine(string.Format("Client Local Time: {0}\n", System.DateTime.Now.ToString("HH:mm:ss")));
            //Console.WriteLine(string.Format("Client UTC Time: {0}\n", UTCTime.ToString("HH:mm:ss")));
            //Console.WriteLine("\n");

            //HttpTransportBindingElement httpTransport = new HttpTransportBindingElement();

            //TransportSecurityBindingElement transportSecurity = new TransportSecurityBindingElement();
            //transportSecurity.EndpointSupportingTokenParameters.SignedEncrypted.Add(new UsernameTokenParameters());
            //transportSecurity.AllowInsecureTransport = true;
            //transportSecurity.IncludeTimestamp = false;

            //TextMessageEncodingBindingElement textMessageEncoding = new TextMessageEncodingBindingElement(MessageVersion.Soap12, Encoding.UTF8);

            //CustomBinding binding = new CustomBinding(transportSecurity, textMessageEncoding, httpTransport);

            //EndpointAddress serviceAddress = new EndpointAddress("http://" + strIP + "/onvif/device_service");
            //ChannelFactory<Device> channelFactory = new ChannelFactory<Device>(binding, serviceAddress);

            //UsernameClientCredentials credentials = new UsernameClientCredentials(new UsernameInfo(strLogin, strPass));

            //channelFactory.Endpoint.Behaviors.Remove(typeof(ClientCredentials));
            //channelFactory.Endpoint.Behaviors.Add(credentials);

            //Device channel = channelFactory.CreateChannel();

            //var unitTime = channel.GetSystemDateAndTime(new GetSystemDateAndTimeRequest());
            //Console.WriteLine(string.Format("Camera Local Time: {0}:{1}:{2}\n", unitTime.SystemDateAndTime.LocalDateTime.Time.Hour, unitTime.SystemDateAndTime.LocalDateTime.Time.Minute, unitTime.SystemDateAndTime.LocalDateTime.Time.Second));
            //Console.WriteLine(string.Format("Camera UTC Time: {0}:{1}:{2}\n", unitTime.SystemDateAndTime.UTCDateTime.Time.Hour, unitTime.SystemDateAndTime.UTCDateTime.Time.Minute, unitTime.SystemDateAndTime.UTCDateTime.Time.Second));

            //var info = channel.GetDeviceInformation(new GetDeviceInformationRequest());
            //Console.WriteLine(string.Format("Model: {0}", info.Model));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void discoveryClient_FindCompleted(object sender, FindCompletedEventArgs e)
        {
            Console.WriteLine("\n\nDiscovery complete - " + ((System.ServiceModel.Discovery.DiscoveryClient)sender).Endpoint.Name + ", " + e.Result.ToString()+"\n");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void discoveryClient_FindProgressChanged(object sender, FindProgressChangedEventArgs e)
        {
            foreach (var u in e.EndpointDiscoveryMetadata.ListenUris)
            {
                string uri = u.OriginalString;

                //Console.WriteLine(uri);

                if (uri.Contains("http://"+strIP+"/onvif/device_service"))
                {
                    Console.WriteLine("\t"+uri);

                    processCameraInteraction();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void processCameraInteraction()
        {
            try
            {
                ServicePointManager.Expect100Continue = false;

                HttpTransportBindingElement httpTransportBinding = new HttpTransportBindingElement 
                { 
                    AuthenticationScheme = AuthenticationSchemes.Digest 
                };
                TextMessageEncodingBindingElement textMessageEncodingBinding = new TextMessageEncodingBindingElement 
                { 
                    MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None) 
                };
                CustomBinding customBinding = new CustomBinding(textMessageEncodingBinding, httpTransportBinding);


                PasswordDigestBehavior passwordDigestBehavior = new PasswordDigestBehavior(strLogin, strPass);

                //
                // Device service
                //
                EndpointAddress endPointAddressDevice = new EndpointAddress("http://" + strIP + "/onvif/device_service");
                DeviceClient deviceClient = new DeviceClient(customBinding, endPointAddressDevice);
                
                // must add the password behavior before ANY call to the device service otherwise it wont authenticate
                deviceClient.Endpoint.Behaviors.Add(passwordDigestBehavior);


                Date date = deviceClient.GetSystemDateAndTime().UTCDateTime.Date;
                Time time = deviceClient.GetSystemDateAndTime().UTCDateTime.Time;
                Console.WriteLine("\tSystemDateAndTime: " + date.Year + "/" + date.Month + "/" + date.Day + " " +
                                                            time.Hour + ":" + time.Minute + ":" + time.Second + "");
                Console.WriteLine("\tHostName = " + deviceClient.GetHostname().Name);
                Console.WriteLine("\tWSDL = " + deviceClient.GetWsdlUrl());


                CapabilityCategory[] cc = new CapabilityCategory[] { CapabilityCategory.All };
                org.onvif.device.Capabilities capabilities = deviceClient.GetCapabilities(cc);
                string strMediaXAddr = capabilities.Media.XAddr;
                string strPtzXAddr = capabilities.PTZ.XAddr;
                Console.WriteLine("\tMedia.XAddr = " + strMediaXAddr);
                Console.WriteLine("\tPTZ.XAddr = " + strPtzXAddr);


                //deviceClient.Open();


                string a1, b1, c1, d1, strDevInfo = deviceClient.GetDeviceInformation(out a1, out b1, out c1, out d1);
                Console.Write("\t" + strDevInfo + ", " + a1 + ", " + b1 + ", " + c1 + ", " + d1 + ".");




                //
                // Media service
                //
                EndpointAddress endPointAddressMedia = new EndpointAddress(strMediaXAddr);
                MediaClient mediaClient = new MediaClient(customBinding, endPointAddressMedia);
                mediaClient.Endpoint.Behaviors.Add(passwordDigestBehavior);
                string strProfileToken = null;

                System.DateTime b = System.DateTime.Now;
                Profile[] profiles = mediaClient.GetProfiles();
                System.DateTime a = System.DateTime.Now;
                int millis = (a.Second * 1000 + a.Millisecond) - (b.Second * 1000 + b.Millisecond);
                Console.WriteLine("\n\n\tProfile (" +b.Second+":"+b.Millisecond+" -> "+a.Second+":"+a.Millisecond+ " so, it took "+millis+" millis):");

                foreach (Profile profile in profiles)
                {
                    
                    Console.WriteLine("\t\tName = " + profile.Name + ", token = " + strProfileToken);
                    
                    if(profile.PTZConfiguration != null)
                    {
                        Console.WriteLine("\t\t\tAnd this profile has ptz configuration...");
                        strProfileToken = profile.token;
                        break;
                    }
                }




                //
                // PTZ service
                //
                EndpointAddress endPointAddressPtz = new EndpointAddress(strPtzXAddr);
                PTZClient ptzClient = new PTZClient(customBinding, endPointAddressPtz);
                ptzClient.Endpoint.Behaviors.Add(passwordDigestBehavior);




                //Console.WriteLine("\tPTZConfigurationOptions from " + strProfileToken + " profile:");
                //InvokingWebServices.org.onvif.ptz20.PTZConfigurationOptions ptzConfigurationOptions =
                //    ptzClient.GetConfigurationOptions(strProfileToken);
                //Console.WriteLine("\t\tPTZConfigurationOption.Spaces.ContinuousPanTiltVelocitySpace[0].XRange.Max " +
                //    ptzConfigurationOptions.Spaces.ContinuousPanTiltVelocitySpace[0].XRange.Max);
                //Console.WriteLine("\t\tPTZConfigurationOptions.PTZSpaces.ContinuousPanTiltVelocitySpace[0].YRange.Max " +
                //    ptzConfigurationOptions.Spaces.ContinuousPanTiltVelocitySpace[0].YRange.Max);
                //Console.WriteLine("\t\tPTZConfigurationOption.Spaces.ContinuousPanTiltVelocitySpace[0].URI " +
                //    ptzConfigurationOptions.Spaces.ContinuousPanTiltVelocitySpace[0].URI);
                //Console.WriteLine("\t\tPTZConfigurationOption.Spaces.ContinuousZoomVelocitySpace[0].XRange.Max " +
                //    ptzConfigurationOptions.Spaces.ContinuousZoomVelocitySpace[0].XRange.Max);
                //Console.WriteLine("\t\tPTZConfigurationOption.Spaces.ContinuousZoomVelocitySpace[0].URI " +
                //    ptzConfigurationOptions.Spaces.ContinuousZoomVelocitySpace[0].URI);
   





                //Console.WriteLine("\tPTZConfigurations:");
                //InvokingWebServices.org.onvif.ptz20.PTZConfiguration[] ptzConfigurations = ptzClient.GetConfigurations();
                //foreach (InvokingWebServices.org.onvif.ptz20.PTZConfiguration ptzConfiguration in ptzConfigurations)
                //{
                //    InvokingWebServices.org.onvif.ptz20.PTZConfigurationOptions ptzConfigurationOptions =
                //        ptzClient.GetConfigurationOptions(ptzConfiguration.token);
                //    Console.WriteLine("\t\tptzConfiguration(" + ptzConfiguration.Name + "):");
                //    //ptzConfigurationOptions                    
                //}






                b = System.DateTime.Now;
                PTZPreset[] presets = ptzClient.GetPresets(strProfileToken);
                a = System.DateTime.Now;
                millis = (a.Second * 1000 + a.Millisecond) - (b.Second * 1000 + b.Millisecond);
                Console.WriteLine("\n\n\tPresets  (" + b.Second + ":" + b.Millisecond + " -> " + a.Second + ":" + a.Millisecond + " so, it took "+millis+" millis):");

                foreach (PTZPreset preset in presets)
                {
                    b = System.DateTime.Now;
                    ptzClient.GotoPreset(strProfileToken, preset.token, null /* null means full speed ... I think! */);
                    a = System.DateTime.Now;
                    millis = (a.Second * 1000 + a.Millisecond) - (b.Second * 1000 + b.Millisecond);
                    Console.WriteLine("\t\tPreset activated (" + b.Second + ":" + b.Millisecond + " -> " + a.Second + ":" + a.Millisecond +
                        " so, it took " + millis + " millis). Name = " + preset.Name + ", token = " + preset.token);
                    Thread.Sleep(2500);
                }

                Console.WriteLine("\n--------------------------------------------------------------------------------------------");


                ptzClient.Close();
                mediaClient.Close();
                deviceClient.Close();

            }
            catch (Exception exc)
            {
                Console.Write(exc.ToString());
            }
        }
    }
}
