using MyOwnMilestoneTests.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoOS.Platform;

namespace MyOwnMilestoneTests.Video
{
    public class ItemsHelper
    {

        public static void ObtainAllItems()
        {

            Console.WriteLine("\n\n\nAll items:");
            foreach (Item item in Utils.ObtainAll())
            {
                Console.WriteLine(
                    $"Item[\n\tName:{item.Name} Type:typeof(item) \n\tFQID[" +
                    $"\n\t\t[ObjId:{item.FQID.ObjectId}]" +
                    $"\n\t\t[ParentId:{item.FQID.ParentId}]" +
                    $"\n\t\t[Enabled?{item.Enabled}]" +
                    $"\n\t\t[Kind:{item.FQID.Kind} [({Kind.DefaultTypeToNameTable[item.FQID.Kind]}) ({Kind.DefaultTypeToCategoryTable[item.FQID.Kind]})]]" +

                    //item.Properties

                    $"\n\t\t[FolderType:{item.FQID.FolderType}]]]");


                ObtainChildren(item, 2);

                //if (item.FQID.Kind == Kind.VideoWallMonitor)
                //{
                //    foreach (Item itemII in Configuration.Instance.GetItem(item.FQID).GetChildren())
                //    {
                //        Console.WriteLine(
                //            $"\t\tItem[\n\t\tChildren:{itemII.Name} Type:typeof(item) \n\t\t\tFQID[" +
                //            $"\n\t\t\t\t[ObjId:{itemII.FQID.ObjectId}]" +
                //            $"\n\t\t\t\t[ParentId:{itemII.FQID.ParentId}]" +
                //            $"\n\t\t\t\t[Kind:{itemII.FQID.Kind} [({Kind.DefaultTypeToNameTable[itemII.FQID.Kind]}) ({Kind.DefaultTypeToCategoryTable[itemII.FQID.Kind]})]]" +
                //            $"\n\t\t\t\t[ServerId:{itemII.FQID.ServerId}]" +
                //            $"\n\t\t\t\t[FolderType:{itemII.FQID.FolderType}]]]");

                //    }
                //}
            }
        }

        private static void ObtainChildren(Item item, int level)
        {
            // found the desired item...
            Console.WriteLine($"{new string('\t', level)}Item[Name:{item.Name} FQID[" +
                $"[ObjId:{item.FQID.ObjectId}]" +
                $"[ParentId:{item.FQID.ParentId}]" +
                $"[Enabled?{item.Enabled}]" +
                $"[Kind:{item.FQID.Kind} [({Kind.DefaultTypeToNameTable[item.FQID.Kind]}) ({Kind.DefaultTypeToCategoryTable[item.FQID.Kind]})]]" +

                //item.Properties

                $"[FolderType:{item.FQID.FolderType}]]]");


            // Recursively check all child items
            IList<Item> children = item.GetChildren();

            foreach (Item child in children)
            {
                ObtainChildren(child, level + 1);
            }
        }
    }
}
