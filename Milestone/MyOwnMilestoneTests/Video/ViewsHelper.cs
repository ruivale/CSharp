using System;
using System.Collections.Generic;
using VideoOS.Platform;
using MyOwnMilestoneTests.Util;

namespace MyOwnMilestoneTests.Video
{
    /// <summary>
    /// Helper class for views.
    /// Obtains all views from the Milestone system and creates Milestone Connector View instances.
    /// </summary>
    public static class ViewsHelper
    {
        // <summary>
        // Views holder.
        // </summary>
        private static readonly Dictionary<string, View> _dicViews = new Dictionary<string, View>(1024);

        /// <summary>
        /// True if there are views in the system.
        /// </summary>
        /// <returns></returns>
        public static bool HasViews()
        {
            return ViewsHelper._dicViews.Count > 0;
        }

        /// <summary>
        /// From a FQID, get the view instance.
        /// </summary>
        /// <param name="strFQID"></param>
        /// <returns></returns>
        public static View GetView(string strFQID)
        {
            View view;

            if (ViewsHelper._dicViews.TryGetValue(strFQID, out view))
            {
                return view;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ICollection<View> GetAllViews()
        {
            return ViewsHelper._dicViews.Values;
        }

        /// <summary>
        /// Will obtain, from the Milestone system, all views and store them in a dictionary. 
        /// </summary>
        public static void ObtainAllViews()
        {
            List<Item> listViews = Utils.ObtainAll(Kind.View, IsView);

            // Display all found views
            foreach (Item view in listViews)
            {
                View vw = new View(view.FQID, view.Name);

                // Add the view to the dictionary... if not present, otherwise update it...
                if (ViewsHelper._dicViews.ContainsKey(vw.ObjId))
                {
                    ViewsHelper._dicViews[vw.ObjId] = vw;
                }
                else
                {
                    ViewsHelper._dicViews.Add(vw.ObjId, vw);
                }
            }
        }

        /// <summary>
        /// Determines if an item is a view.  
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool IsView(Item item)
        {
            // It must have Kind == View and it must not be a folder (view folders, like "All Views", have Kind.View)
            return item.FQID.Kind == Kind.View;//&& item.FQID.FolderType == FolderType.No;
        }
    }
}
