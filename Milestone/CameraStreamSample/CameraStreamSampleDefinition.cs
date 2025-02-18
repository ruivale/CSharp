using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using CameraStreamSample.Admin;
using CameraStreamSample.Background;
using CameraStreamSample.Client;
using VideoOS.Platform;
using VideoOS.Platform.Admin;
using VideoOS.Platform.Background;
using VideoOS.Platform.Client;
using VideoOS.Platform.UI.Controls;

namespace CameraStreamSample
{
	/// <summary>
	/// The PluginDefinition is the ‘entry’ point to any plugin.  
	/// This is the starting point for any plugin development and the class MUST be available for a plugin to be loaded.  
	/// Several PluginDefinitions are allowed to be available within one DLL.
	/// Here the references to all other plugin known objects and classes are defined.
	/// The class is an abstract class where all implemented methods and properties need to be declared with override.
	/// The class is constructed when the environment is loading the DLL.
	/// </summary>
	public class CameraStreamSampleDefinition : PluginDefinition
	{
		private static readonly Image _treeNodeImage;
        private static readonly VideoOSIconSourceBase _pluginIcon;
        private static readonly Image _topTreeNodeImage;

		internal static readonly Uri DummyImagePackUri;

		internal static Guid CameraStreamSamplePluginId =			new Guid("cb9fe9dc-c40a-46de-9de8-fb3d65754ae0");
		internal static Guid CameraStreamSampleKind =				new Guid("bbc4e8f5-283b-44bd-9fce-ec96db5ec23f");
		internal static Guid CameraStreamSampleSidePanel =		new Guid("cfc3284f-ba88-4ed2-bc95-f69dd5d90123");
		internal static Guid CameraStreamSampleViewItemPlugin =	new Guid("102d8798-d9f8-494b-8c27-8f195ae6d8e8");
		internal static Guid CameraStreamSampleSettingsPanel =	new Guid("d2b7aeb5-de08-4156-8c76-9011b49a46e1");
		internal static Guid CameraStreamSampleBackgroundPlugin = new Guid("d32dc77d-ada2-4c48-924a-2997118b4312");
		internal static Guid CameraStreamSampleWorkSpacePluginId = new Guid("18ad7e3f-db65-49e4-9178-ba25b041d2d6");
		internal static Guid CameraStreamSampleWorkSpaceViewItemPluginId = new Guid("0b15fd4f-7431-4b83-9969-6de024a3e769");
        internal static Guid CameraStreamSampleTabPluginId = new Guid("b68ad7c6-fed5-4b13-90c2-0593a9358fbe");
        internal static Guid CameraStreamSampleViewLayoutId = new Guid("fe790bc6-4d51-43cf-9ee4-df29e69ffe5d");
        // IMPORTANT! Due to shortcoming in Visual Studio template the below cannot be automatically replaced with proper unique GUIDs, so you will have to do it yourself
        internal static Guid CameraStreamSampleWorkSpaceToolbarPluginId = new Guid("22222222-2222-2222-2222-222222222222");
        internal static Guid CameraStreamSampleViewItemToolbarPluginId = new Guid("33333333-3333-3333-3333-333333333333");
        internal static Guid CameraStreamSampleToolsOptionDialogPluginId = new Guid("44444444-4444-4444-4444-444444444444");
        internal static Guid CameraStreamSampleClientActionId = new Guid("55555555-5555-5555-5555-555555555550");
        internal static Guid CameraStreamSampleClientActionGroupId = new Guid("55555555-5555-5555-5555-555555555551");

        #region Private fields

        private UserControl _treeNodeInofUserControl;

		//
		// Note that all the plugin are constructed during application start, and the constructors
		// should only contain code that references their own dll, e.g. resource load.

		private List<BackgroundPlugin> _backgroundPlugins = new List<BackgroundPlugin>();
		private Collection<SettingsPanelPlugin> _settingsPanelPlugins = new Collection<SettingsPanelPlugin>();
		private List<ViewItemPlugin> _viewItemPlugins = new List<ViewItemPlugin>();
		private List<ItemNode> _itemNodes = new List<ItemNode>();
		private List<SidePanelPlugin> _sidePanelPlugins = new List<SidePanelPlugin>();
		private List<String> _messageIdStrings = new List<string>();
		private List<SecurityAction> _securityActions = new List<SecurityAction>();
		private List<WorkSpacePlugin> _workSpacePlugins = new List<WorkSpacePlugin>();
        private List<TabPlugin> _tabPlugins = new List<TabPlugin>();
        private List<ViewItemToolbarPlugin> _viewItemToolbarPlugins = new List<ViewItemToolbarPlugin>();
        private List<WorkSpaceToolbarPlugin> _workSpaceToolbarPlugins = new List<WorkSpaceToolbarPlugin>();
        private List<ViewLayout> _viewLayouts = new List<ViewLayout> { new CameraStreamSampleViewLayout() };
        private List<ToolsOptionsDialogPlugin> _toolsOptionsDialogPlugins = new List<ToolsOptionsDialogPlugin>();
        private List<ClientActionGroup> _clientActionGroups = new List<ClientActionGroup>();

        #endregion

        #region Initialization

        /// <summary>
        /// Load resources 
        /// </summary>
        static CameraStreamSampleDefinition()
        {
            _topTreeNodeImage = Properties.Resources.Server;
            DummyImagePackUri = new Uri(string.Format($"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Resources/DummyItem.png"));
            _pluginIcon = new VideoOSIconUriSource() { Uri = DummyImagePackUri };
            _treeNodeImage = ResourceToImage(DummyImagePackUri);
        }

        /// <summary>
        /// WPF requires resources to be stored with Build Action=Resource, which unfortunately cannot easily be read for WinForms controls, so we use this small
        /// utility method
        /// </summary>
        /// <param name="imageUri">Pack URI pointing to the image <seealso cref="https://learn.microsoft.com/en-us/dotnet/desktop/wpf/app-development/pack-uris-in-wpf"/></param>
        /// <returns></returns>
        private static Image ResourceToImage(Uri imageUri)
        {
            var bitmapImage = new BitmapImage(imageUri);
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                stream.Flush();
                return new Bitmap(stream);
            }
        }

        /// <summary>
        /// Get the icon for the plugin in WPF format
        /// </summary>
        internal static VideoOSIconSourceBase PluginIcon => _pluginIcon;

        /// <summary>
        /// Get the icon for the plugin in WinForms format
        /// </summary>
        internal static Image TreeNodeImage => _treeNodeImage;

        #endregion

        /// <summary>
        /// This method is called when the environment is up and running.
        /// Registration of Messages via RegisterReceiver can be done at this point.
        /// </summary>
        public override void Init()
		{			
			// Populate all relevant lists with your plugins etc.
			_itemNodes.Add(new ItemNode(CameraStreamSampleKind, Guid.Empty,
					             		"CameraStreamSample", _treeNodeImage,
					             		"CameraStreamSamples", _treeNodeImage,
					             		Category.Text, true,
					             		ItemsAllowed.Many,
					             		new CameraStreamSampleItemManager(CameraStreamSampleKind),
					             		null					             		             
					             		) );
			if (EnvironmentManager.Instance.EnvironmentType == EnvironmentType.SmartClient)
			{
				
                _workSpacePlugins.Add(new CameraStreamSampleWorkSpacePlugin());
				
                _sidePanelPlugins.Add(new CameraStreamSampleSidePanelPlugin());


				_viewItemPlugins.Add(new CameraStreamSampleViewItemPlugin());
				_viewItemPlugins.Add(new CameraStreamSampleWorkSpaceViewItemPlugin());
                
                _viewItemToolbarPlugins.Add(new CameraStreamSampleViewItemToolbarPlugin());
                
                _workSpaceToolbarPlugins.Add(new CameraStreamSampleWorkSpaceToolbarPlugin());
                
                _settingsPanelPlugins.Add(new CameraStreamSampleSettingsPanelPlugin());

                // TODO: remove below check when CameraStreamSampleDefinition.CameraStreamSampleClientActionGroupId has been replaced with proper GUID
                if (Id == new Guid("55555555-5555-5555-5555-555555555551"))
                {
                    System.Windows.MessageBox.Show("Default GUID has not been replaced for CameraStreamSampleClientActionGroupId!");
                }
                
                ClientActionGroup clientActionGroup = new ClientActionGroup(CameraStreamSampleClientActionGroupId, "CameraStreamSample Client Action Group", CameraStreamSampleDefinition.PluginIcon); //Note that the group name should be localized.
                clientActionGroup.Actions.Add(new CameraStreamSampleClientAction());
                _clientActionGroups.Add(clientActionGroup);
            }
            if (EnvironmentManager.Instance.EnvironmentType == EnvironmentType.Administration)
            {
                _tabPlugins.Add(new CameraStreamSampleTabPlugin());
                _toolsOptionsDialogPlugins.Add(new CameraStreamSampleToolsOptionDialogPlugin());
            }

			_backgroundPlugins.Add(new CameraStreamSampleBackgroundPlugin());
		}

		/// <summary>
		/// The main application is about to be in an undetermined state, either logging off or exiting.
		/// You can release resources at this point, it should match what you acquired during Init, so additional call to Init() will work.
		/// </summary>
		public override void Close()
		{
			_itemNodes.Clear();
			_sidePanelPlugins.Clear();
			_viewItemPlugins.Clear();
            _settingsPanelPlugins.Clear();
			_backgroundPlugins.Clear();
		    _workSpacePlugins.Clear();
            _tabPlugins.Clear();
            _viewItemToolbarPlugins.Clear();
            _workSpaceToolbarPlugins.Clear();
            _toolsOptionsDialogPlugins.Clear();
            _clientActionGroups.Clear();
        }

        /// <summary>
        /// Return any new messages that this plugin can use in SendMessage or PostMessage,
        /// or has a Receiver set up to listen for.
        /// The suggested format is: "YourCompany.Area.MessageId"
        /// </summary>
        public override List<string> PluginDefinedMessageIds
		{
			get
			{
				return _messageIdStrings;
			}
		}

		/// <summary>
		/// If authorization is to be used, add the SecurityActions the entire plugin 
		/// would like to be available.  E.g. Application level authorization.
		/// </summary>
		public override List<SecurityAction> SecurityActions
		{
			get
			{
				return _securityActions;
			}
			set
			{
			}
		}

		#region Identification Properties

		/// <summary>
		/// Gets the unique id identifying this plugin component
		/// </summary>
		public override Guid Id
		{
			get
			{
				return CameraStreamSamplePluginId;
			}
		}

		/// <summary>
		/// This Guid can be defined on several different IPluginDefinitions with the same value,
		/// and will result in a combination of this top level ProductNode for several plugins.
		/// Set to Guid.Empty if no sharing is enabled.
		/// </summary>
		public override Guid  SharedNodeId
		{
			get
			{
				return Guid.Empty;
			}
		}

		/// <summary>
		/// Define name of top level Tree node - e.g. A product name
		/// </summary>
		public override string Name
		{
			get { return "CameraStreamSample"; }
		}

		/// <summary>
		/// Your company name
		/// </summary>
		public override string Manufacturer
		{
			get
			{
				return "Your Company name";
			}
		}

		/// <summary>
		/// Version of this plugin.
		/// </summary>
		public override string VersionString
		{
			get
			{
				return "1.0.0.0";
			}
		}

		/// <summary>
		/// Icon to be used on top level - e.g. a product or company logo
		/// </summary>
		public override System.Drawing.Image Icon
		{
			get { return _topTreeNodeImage; }
		}

		#endregion

		#region Administration properties

		/// <summary>
		/// A list of server side configuration items in the administrator
		/// </summary>
		public override List<ItemNode> ItemNodes
		{
			get { return _itemNodes; }
		}

        /// <summary>
        /// An extension plug-in running in the Administrator to add a tab for built-in devices and hardware.
        /// </summary>
        public override ICollection<TabPlugin> TabPlugins
        {
            get { return _tabPlugins; }
        }

        /// <summary>
        /// An extension plug-in running in the Administrator to add more tabs to the Tools-Options dialog.
        /// </summary>
        public override List<ToolsOptionsDialogPlugin> ToolsOptionsDialogPlugins
        {
            get { return _toolsOptionsDialogPlugins; }
        }

        /// <summary>
        /// A user control to display when the administrator clicks on the top TreeNode
        /// </summary>
        public override UserControl GenerateUserControl()
		{
			_treeNodeInofUserControl = new HelpPage();
			return _treeNodeInofUserControl;
		}

		/// <summary>
		/// This property can be set to true, to be able to display your own help UserControl on the entire panel.
		/// When this is false - a standard top and left side is added by the system.
		/// </summary>
		public override bool UserControlFillEntirePanel
		{
			get { return false; }
		}
		#endregion

		#region Client related methods and properties

		/// <summary>
		/// A list of Client side definitions for Smart Client
		/// </summary>
		public override List<ViewItemPlugin> ViewItemPlugins
    	{
    		get { return _viewItemPlugins; }
    	}

        /// <summary>
        /// An extension plug-in running in the Smart Client to add more choices on the Settings panel.
        /// Supported from Smart Client 2017 R1. For older versions use OptionsDialogPlugins instead.
        /// </summary>
        public override Collection<SettingsPanelPlugin> SettingsPanelPlugins
        {
            get { return _settingsPanelPlugins; }
        }

        /// <summary> 
        /// An extension plugin to add to the side panel of the Smart Client.
        /// </summary>
        public override List<SidePanelPlugin> SidePanelPlugins
		{
			get {  return _sidePanelPlugins; }
		}

		/// <summary>
		/// Return the workspace plugins
		/// </summary>
		public override List<WorkSpacePlugin> WorkSpacePlugins
		{
			get { return _workSpacePlugins; }
		}

        /// <summary> 
        /// An extension plug-in to add to the view item toolbar in the Smart Client.
        /// </summary>
        public override List<ViewItemToolbarPlugin> ViewItemToolbarPlugins
        {
            get { return _viewItemToolbarPlugins; }
        }

        /// <summary> 
        /// An extension plug-in to add to the work space toolbar in the Smart Client.
        /// </summary>
        public override List<WorkSpaceToolbarPlugin> WorkSpaceToolbarPlugins
        {
            get { return _workSpaceToolbarPlugins; }
        }

        /// <summary>
        /// An extension plug-in running in the Smart Client to provide extra view layouts.
        /// </summary>
        public override List<ViewLayout> ViewLayouts
        {
            get { return _viewLayouts; }
        }

        /// <summary>
        /// An extension plug-in running in the Smart Client to provide actions that can be activated by the operator.
        /// </summary>
        public override List<ClientActionGroup> ClientActionGroups
        {
            get { return _clientActionGroups; }
        }

        #endregion


        /// <summary>
        /// Create and returns the background task.
        /// </summary>
        public override List<BackgroundPlugin> BackgroundPlugins
		{
			get { return _backgroundPlugins; }
		}

	}
}
