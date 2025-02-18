using System;
using VideoOS.Platform.Client;
using VideoOS.Platform.UI.Controls;

namespace CameraStreamSample.Client
{
    public class CameraStreamSampleWorkSpaceViewItemPlugin : ViewItemPlugin
	{
		public CameraStreamSampleWorkSpaceViewItemPlugin()
        {
        }

		public override Guid Id
		{
			get { return CameraStreamSampleDefinition.CameraStreamSampleWorkSpaceViewItemPluginId; }
		}

        public override VideoOSIconSourceBase IconSource { get => CameraStreamSampleDefinition.PluginIcon; protected set => base.IconSource = value; }

		public override string Name
		{
			get { return "WorkSpace Plugin View Item"; }
		}

        public override bool HideSetupItem
        {
            get
            {
                return false;
            }
        }

		public override ViewItemManager GenerateViewItemManager()
		{
            return new CameraStreamSampleWorkSpaceViewItemManager();
		}

		public override void Init()
		{
		}

		public override void Close()
		{
		}


	}
}
