using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoOS.Platform;
using VideoOS.Platform.Messaging;
using VideoOS.Platform.UI;
using VideoOS.Platform.Login;
using VideoOS.Platform.ConfigurationItems;
using MyOwnMilestoneTests.Util;

namespace MyOwnMilestoneTests.Video
{
    /// <summary>
    /// Helper class for cameras.
    /// Obtains all cameras from the Milestone system and creates Milestone Connector Camera instances.
    /// @TODO: it should also be able to obtain ptz cameras presets.
    /// </summary>
    public static class CamerasHelper
    {

        // <summary>
        // Cameras holder.
        // </summary>
        private static readonly Dictionary<string, Camera> _dicCams = new Dictionary<string, Camera>(1024);


        /// <summary>
        /// True if there are cameras in the system.
        /// </summary>
        /// <returns></returns>
        public static bool HasCameras()
        {
            return CamerasHelper._dicCams.Count > 0;
        }


        /// <summary>
        /// From a FQID, get the camera instance.
        /// </summary>
        /// <param name="strFQID"></param>
        /// <returns></returns>
        public static Camera GetCamera(string strFQID)
        {
            Camera cam;

            if (CamerasHelper._dicCams.TryGetValue(strFQID, out cam))
            {
                return cam;
            }

            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ICollection<Camera> GetAllCameras()
        {
            return CamerasHelper._dicCams.Values;
        }


        /// <summary>
        /// Will obtain, from the Milestone system, all cameras and store them in a dictionary. 
        /// </summary>
        public static void ObtainAllCameras()
        {
            List<Item> listCams = Utils.ObtainAll(Kind.Camera, IsCamera);

            // Display all found cameras
            foreach (Item cam in listCams)
            {
                Camera camera = new Camera(cam.FQID, cam.Name);

                // Add the camera to the dictionary... if not present, otherwise update it...
                if (CamerasHelper._dicCams.ContainsKey(camera.ObjId))
                {
                    CamerasHelper._dicCams[camera.ObjId] = camera;
                }
                else
                {
                    CamerasHelper._dicCams.Add(camera.ObjId, camera);
                }
            }
        }


        /// <summary>
        /// Determines if an item is a camera.  
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool IsCamera(Item item)
        {
            // It must have Kind == Camera and it must not be a folder (camera folders, like "All Cameras", have Kind.Camera)
            return item.FQID.Kind == Kind.Camera && item.FQID.FolderType == FolderType.No;
        }

    }
}
