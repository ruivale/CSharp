using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoOS.Platform.Client;
using VideoOS.Platform;
using VideoOS.Platform.UI.Controls;
using System.Reflection;
using VideoOS.Platform.Messaging;
using System.Net;

namespace SmartClientPlugin
{
    /// <summary>
    /// The PluginDefinition is the ‘entry’ point to any plugin.  
    /// This is the starting point for any plugin development and the class MUST be available for a plugin to be loaded.  
    /// Several PluginDefinitions are allowed to be available within one DLL.
    /// The class is an abstract class where all implemented methods and properties need to be declared with override.
    /// The class is constructed when the environment is loading the DLL.
    /// 
    /// During application start, all MIP plug-ins are loaded into memory, and one PluginDefinition for each plug-in is constructed. 
    /// The PluginDefinition will not be constructed at any later time during the same application execution.
    /// 
    /// During the loading of the plug-ins, the executing application and the MIP Environment are generally not operational, 
    /// and can therefore not support any calls.
    /// 
    /// When all plug-ins are loaded, and the MIP Environment is up and running, the PluginDefinitions Init() method is called
    /// on all plug-ins. At this point, the plug-ins can register message receivers, and load local resources, but the main 
    /// application may still not have logged in to any server.
    /// 
    /// Access to the plug-in property lists (for excample BackgroundPlugins, SidePanelPlugins, OptionDialogsPlugins) differs 
    /// slightly from application to application. The following sequence should therefore be observed:
    ///     During application start, the plug-ins are accessed
    ///     When the configuration is ready for access, the plug-ins Init() method is called
    ///     When a user logs out, or a service is stopping, the Close() method is called
    ///     If a user logs in and out many times, the Init() and Close() will be called on the plug-in classes 
    ///         accordingly(the Init() on the PluginDefinition is only called once).
    ///     
    /// Construction of UserControls is usually done when needed, and not re-used later. 
    /// The relevant GenerateUserControl() methods should therefore always create a new instance of the specific UserControl.
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    public class SmartClientViewPlugin : PluginDefinition
    {

        private static readonly VideoOSIconSourceBase _pluginIcon;
        internal static readonly Uri DummyImagePackUri;

        static SmartClientViewPlugin() 
        {
            DummyImagePackUri = new Uri(string.Format($"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Resources/DummyItem.png"));
            _pluginIcon = new VideoOSIconUriSource() { Uri = DummyImagePackUri };
        }


        /// <summary>
        /// Gets the unique id identifying this ViewItem
        /// </summary>
        public override Guid Id { get { return new Guid("d7d7d7d7-d7d7-d7d7-d7d7-d7d7d7d7d7d7"); } }

        /// <summary>
        ///     The text used for a single ViewItem
        /// </summary>
        public override string Name { get { return "SmartClientPlugin.SmartClientViewPlugin"; } }

        /// <summary>
        /// In general, the Init() method is called when the class is able to start doing something useful:
        ///     On PluginDefinition that is when MIP Environment is ready for message registration
        ///     On Plugin classes it is called when MIP Environment is ready and configuration ready
        ///     On UserControls it is typically right after construction; here the Close() may be important to clean up resources
        ///     
        /// </summary>
        public override void Init()
        {
            // Initialize plugin when Smart Client starts
            EnvironmentManager.Instance.Log(false, "SmartClientPlugin.SmartClientViewPlugin", "SmartClient Plugin Initialized.");
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public override ViewItemUserControl GenerateViewItemUserControl()
        //{
        //    return new CameraViewControl();
        //}

        /// <summary>
        /// Generates a ViewItemManager for managing one ViewItem. A ViewItemManager is generated for each ViewItem defined.
        /// </summary>
        /// <returns></returns>
        public override ViewItemManager GenerateViewItemManager()
        {
            return new CameraViewControl();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Close()
        {
            // Cleanup logic if needed
        }

    }
}
