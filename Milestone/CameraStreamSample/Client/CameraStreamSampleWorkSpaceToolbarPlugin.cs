using System;
using System.Collections.Generic;
using VideoOS.Platform;
using VideoOS.Platform.Client;

namespace CameraStreamSample.Client
{
    class CameraStreamSampleWorkSpaceToolbarPluginInstance : WorkSpaceToolbarPluginInstance
    {
        private Item _window;

        public CameraStreamSampleWorkSpaceToolbarPluginInstance()
        {
        }

        public override void Init(Item window)
        {
            _window = window;

            Title = "CameraStreamSample";
        }

        public override void Activate()
        {
            // Here you should put whatever action that should be executed when the toolbar button is pressed
        }

        public override void Close()
        {
        }

    }

    class CameraStreamSampleWorkSpaceToolbarPlugin : WorkSpaceToolbarPlugin
    {
        public CameraStreamSampleWorkSpaceToolbarPlugin()
        {
        }

        public override Guid Id
        {
            get { return CameraStreamSampleDefinition.CameraStreamSampleWorkSpaceToolbarPluginId; }
        }

        public override string Name
        {
            get { return "CameraStreamSample"; }
        }

        public override void Init()
        {
            // TODO: remove below check when CameraStreamSampleDefinition.CameraStreamSampleWorkSpaceToolbarPluginId has been replaced with proper GUID
            if (Id == new Guid("22222222-2222-2222-2222-222222222222"))
            {
                System.Windows.MessageBox.Show("Default GUID has not been replaced for CameraStreamSampleWorkSpaceToolbarPluginId!");
            }

            WorkSpaceToolbarPlaceDefinition.WorkSpaceIds = new List<Guid>() { ClientControl.LiveBuildInWorkSpaceId, ClientControl.PlaybackBuildInWorkSpaceId, CameraStreamSampleDefinition.CameraStreamSampleWorkSpacePluginId };
            WorkSpaceToolbarPlaceDefinition.WorkSpaceStates = new List<WorkSpaceState>() { WorkSpaceState.Normal };
        }

        public override void Close()
        {
        }

        public override WorkSpaceToolbarPluginInstance GenerateWorkSpaceToolbarPluginInstance()
        {
            return new CameraStreamSampleWorkSpaceToolbarPluginInstance();
        }
    }
}
