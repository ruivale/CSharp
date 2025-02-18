using System;
using VideoOS.Platform.Client;

namespace CameraStreamSample.Client
{
    /// <summary>
    /// Interaction logic for CameraStreamSampleWorkSpaceViewItemWpfUserControl.xaml
    /// </summary>
    public partial class CameraStreamSampleWorkSpaceViewItemWpfUserControl : ViewItemWpfUserControl
    {
        public CameraStreamSampleWorkSpaceViewItemWpfUserControl()
        {
            InitializeComponent();
        }

        public override void Init()
        {
        }

        public override void Close()
        {
        }

        /// <summary>
        /// Do not show the sliding toolbar!
        /// </summary>
        public override bool ShowToolbar
        {
            get { return false; }
        }

        private void ViewItemWpfUserControl_ClickEvent(object sender, EventArgs e)
        {
            FireClickEvent();
        }

        private void ViewItemWpfUserControl_DoubleClickEvent(object sender, EventArgs e)
        {
            FireDoubleClickEvent();
        }
    }
}
