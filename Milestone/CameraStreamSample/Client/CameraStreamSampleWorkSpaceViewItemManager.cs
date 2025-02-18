using VideoOS.Platform.Client;

namespace CameraStreamSample.Client
{
    public class CameraStreamSampleWorkSpaceViewItemManager : ViewItemManager
	{
		public CameraStreamSampleWorkSpaceViewItemManager() : base("CameraStreamSampleWorkSpaceViewItemManager")
        {
        }

		public override ViewItemWpfUserControl GenerateViewItemWpfUserControl()
		{
            return new CameraStreamSampleWorkSpaceViewItemWpfUserControl();
		}
	}
}
