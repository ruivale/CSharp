using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoOS.Platform;

namespace MyOwnMilestoneTests.Util
{
    public static class Utils
    {


        /// <summary>
        /// Will obtain, from the Milestone system, all user defined items from the given Guid kind using the test function. 
        /// </summary>
        /// <param name="kind"></param>
        /// <returns></returns>
        public static List<Item> ObtainAll()
        {
            // Start from the root and recursively collect all cameras
            List<Item> listItems = new List<Item>();

            IList<Item> rootItems = Configuration.Instance.GetItems(ItemHierarchy.Both);


            foreach (Item rootItem in rootItems)
            {
                Utils.FindItemsRecursively(rootItem, listItems);
            }

            return listItems;
        }


        /// <summary>
        /// Will obtain, from the Milestone system, all user defined items from the given Guid kind using the test function. 
        /// </summary>
        /// <param name="kind"></param>
        /// <returns></returns>
        public static List<Item> ObtainAll(Guid guidKind, Func<Item, bool> testFunct)
        {
            // Start from the root and recursively collect all cameras
            List<Item> listItems = new List<Item>();

            IList<Item> rootItems = Configuration.Instance.GetItemsByKind(guidKind, ItemHierarchy.UserDefined);
            //IList<Item> rootItems = Configuration.Instance.GetItems(ItemHierarchy.SystemDefined);


            foreach (Item rootItem in rootItems)
            {
                Utils.FindItemsRecursively(rootItem, listItems, testFunct);
            }

            return listItems;
        }


        /// <summary>
        /// Recursively traverses the hierarchy and finds all items using the testFunct function.
        /// </summary>
        public static void FindItemsRecursively(Item item, List<Item> listItems)
        {
            // found the desired item...
            listItems.Add(item);

            // Recursively check all child items
            IList<Item> children = item.GetChildren();

            foreach (Item child in children)
            {
                FindItemsRecursively(child, listItems);
            }
        }


        /// <summary>
        /// Recursively traverses the hierarchy and finds all items using the testFunct function.
        /// </summary>
        public static void FindItemsRecursively(Item item, List<Item> listItems, Func<Item, bool> testFunct)
        {
            if (testFunct(item))
            {
                // found the desired item...
                listItems.Add(item);
            }
            else
            {
                // Recursively check all child items
                IList<Item> children = item.GetChildren();

                foreach (Item child in children)
                {
                    FindItemsRecursively(child, listItems, testFunct);
                }
            }
        }


    }

}
