using VideoOS.Platform.Admin;

namespace CameraStreamSample.Admin
{
    public partial class CameraStreamSampleToolsOptionDialogUserControl : ToolsOptionsDialogUserControl
    {
        public CameraStreamSampleToolsOptionDialogUserControl()
        {
            InitializeComponent();
        }

        public override void Init()
        {
        }

        public override void Close()
        {
        }

        public string MyPropValue
        {
            set { textBoxPropValue.Text = value ?? ""; }
            get { return textBoxPropValue.Text; }
        }
    }
}
