using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoOS.Platform.Client;
using VideoOS.Platform;
using VideoOS.Platform.UI.Controls;
using System.Reflection;

namespace SmartClientPlugin
{
    /// <summary>
    /// The PluginDefinition is the ‘entry’ point to any plugin.  
    /// This is the starting point for any plugin development and the class MUST be available for a plugin to be loaded.  
    /// Several PluginDefinitions are allowed to be available within one DLL.
    /// The class is an abstract class where all implemented methods and properties need to be declared with override.
    /// The class is constructed when the environment is loading the DLL.
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
        /// 
        /// </summary>
        public override VideoOSIconSourceBase IconSource { get => CameraStreamSampleDefinition.PluginIcon; protected set => base.IconSource = value; }

        /// <summary>
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
