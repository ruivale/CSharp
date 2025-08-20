using System;
using System.Collections.Generic;
using VideoOS.Platform;
using MyOwnMilestoneTests.Util;
using VideoOS.Platform.Messaging;

namespace MyOwnMilestoneTests.Video
{
    /// <summary>
    /// Helper class for monitors.
    /// Obtains all monitors from the Milestone system and creates Milestone Connector Monitor instances.
    /// </summary>
    public static class MonitorsHelper
    {
        // <summary>
        // Monitors holder.
        // </summary>
        private static readonly Dictionary<string, Monitor> _dicMonitors = new Dictionary<string, Monitor>(1024);

        /// <summary>
        /// True if there are monitors in the system.
        /// </summary>
        /// <returns></returns>
        public static bool HasMonitors()
        {
            return MonitorsHelper._dicMonitors.Count > 0;
        }

        /// <summary>
        /// From a FQID, get the monitor instance.
        /// </summary>
        /// <param name="strFQID"></param>
        /// <returns></returns>
        public static Monitor GetMonitor(string strFQID)
        {
            Monitor monitor;

            if (MonitorsHelper._dicMonitors.TryGetValue(strFQID, out monitor))
            {
                return monitor;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ICollection<Monitor> GetAllMonitors()
        {
            return MonitorsHelper._dicMonitors.Values;
        }

        /// <summary>
        /// Will obtain, from the Milestone system, all monitors and store them in a dictionary. 
        /// </summary>
        public static void ObtainAllMonitors()
        {
            List<Item> listMonitors = Utils.ObtainAll(Kind.VideoWallMonitor, IsMonitor);

            // Display all found monitors
            foreach (Item monitor in listMonitors)
            {
                Monitor mon = new Monitor(monitor.FQID, monitor.Name);

                // Add the monitor to the dictionary... if not present, otherwise update it...
                if (MonitorsHelper._dicMonitors.ContainsKey(mon.ObjId))
                {
                    MonitorsHelper._dicMonitors[mon.ObjId] = mon;
                }
                else
                {
                    MonitorsHelper._dicMonitors.Add(mon.ObjId, mon);
                }
            }
        }

        /// <summary>
        /// Determines if an item is a monitor.  
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool IsMonitor(Item item)
        {
            // It must have Kind == VideoWallMonitor and it must not be a folder (monitor folders, like "All Monitors", have Kind.Monitor)
            return item.FQID.Kind == Kind.VideoWallMonitor && item.FQID.FolderType == FolderType.No;
        }


        /// <summary>
        /// 
        /// </summary>
        public static void GetCurrentMonitorLayout()
        {

            //Console.WriteLine("Getting current monitor layout...");




            //string strFqidVWMon1 = "90aaa255-3e05-47b8-a4b2-ffa498966f03";
            //FQID fqidVWMon1 = MonitorsHelper.GetMonitor(strFqidVWMon1).FQID;

            //// Get list of monitors
            //object response = EnvironmentManager.Instance.SendMessage(new Message(MessageId.SmartClient), fqidVWMon1);
            ////object response = EnvironmentManager.Instance.SendMessage(new Message(MessageId.SmartClient.GetMonitors), null);

            //Console.WriteLine("Response: " + response); 

            ////if (response is List<Guid> monitorIds)
            ////{
            ////    foreach (Guid monitorId in monitorIds)
            ////    {
            ////        // Retrieve the current view layout for each monitor
            ////        object viewResponse = EnvironmentManager.Instance.SendMessage(
            ////            new Message(MessageId.SmartClient.GetCurrentView, monitorId), null);

            ////        if (viewResponse is string layoutXml)
            ////        {
            ////            Console.WriteLine($"Monitor {monitorId} Layout: {layoutXml}");
            ////        }
            ////    }
            ////}
        }
    }
}

