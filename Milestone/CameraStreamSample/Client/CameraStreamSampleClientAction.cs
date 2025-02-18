using System;
using System.Windows;
using System.Windows.Media.Imaging;
using VideoOS.Platform.Client;
using VideoOS.Platform.UI.Controls;

namespace CameraStreamSample.Client
{
    public class CameraStreamSampleClientAction : ClientAction
    {
        public override Guid Id
        {
            get => CameraStreamSampleDefinition.CameraStreamSampleClientActionId;
        }

        public override string Name
        {
            get => "CameraStreamSample Client Action"; //Note that the action name should be localized (unless it contains a name of an Item or similar).
        }

        public override VideoOSIconSourceBase Icon
        {
            get => CameraStreamSampleDefinition.PluginIcon;
        }

        public override void Init()
        {
            // TODO: remove below check when CameraStreamSampleDefinition.CameraStreamSampleClientActionId has been replaced with proper GUID
            if (Id == new Guid("55555555-5555-5555-5555-555555555550"))
            {
                System.Windows.MessageBox.Show("Default GUID has not been replaced for CameraStreamSampleClientActionId!");
            }
        }

        public override void Close()
        {
        }

        public override void Activated()
        {
            MessageBox.Show("CameraStreamSample Client Action activated.");
        }
    }
}