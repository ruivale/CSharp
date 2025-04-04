using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Xml;
using VideoOS.Platform;
using VideoOS.Platform.Client;
using VideoOS.Platform.ConfigurationItems;
using VideoOS.Platform.Messaging;
using VideoOS.Platform.UI.Controls;


namespace SmartClientPlugin
{
    internal class CameraViewControl : ViewItemPlugin
    {
        /// <summary>
        /// 
        /// </summary>
        public override VideoOSIconSourceBase IconSource { get => SmartClientViewPlugin.PluginIcon; protected set => base.IconSource = value; }


        public CameraViewControl()
        {

            //Collection<object> selMons =
            //    EnvironmentManager.Instance.SendMessage(
            //        new VideoOS.Platform.Messaging.Message(MessageId.SmartClient.GetSelectedViewItemRequest));

            //Collection<object> selCams =
            //    EnvironmentManager.Instance.SendMessage(
            //        new VideoOS.Platform.Messaging.Message(MessageId.SmartClient.GetSelectedCameraRequest));


            //// To start recording on a specific camera, the following instruction can be used:
            //EnvironmentManager.Instance.SendMessage(new Message(MessageId.Control.StartRecordingCommand), cameraFQID);


        }

    }
}