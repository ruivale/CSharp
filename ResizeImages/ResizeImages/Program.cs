using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ResizeImages
{
	public enum MetaProperty
	{
		Title = 40091,
		Comment = 40092,
		Author = 40093,
		Keywords = 40094,
		Subject = 40095,
		Copyright = 33432,
		Software = 11,
		DateTime = 36867
	}

    public class Program
    {

        static void Main(string[] args)
        {
            string strImgDir;
            string strDestImgDir = null;
            int iWidth = -1;
            int iHeight = -1;
            ImageFormat imgFormat = ImageFormat.Gif;

            if (args.Length < 2)
            {
                Console.Write("Enter the directory where the images are:");
                strImgDir = Console.ReadLine();
                Console.Write("Enter the directory where the images will be saved[ENTER for same as source dir]:");
                strDestImgDir = Console.ReadLine();

                Console.Write("New width:");
                iWidth = int.Parse(Console.ReadLine().ToString());
                Console.Write("New height [-1 for scale the height according to the given width]:");
                iHeight = int.Parse(Console.ReadLine().ToString());

                Console.Write("New image format[1:BMP 2:GIF 3:JPG 4:PNG 5:TIF]:");
                int iImgFormatInternalId = int.Parse(Console.ReadLine().ToString());
                imgFormat = GetImageFormatFromInternalId(iImgFormatInternalId);
            }
            else
            {
                strImgDir = args[0];
                iWidth = int.Parse(args[1].ToString());

                // if the height is not available, scale the image ...
                if (args.Length > 2)
                {
                    iHeight = int.Parse(args[2].ToString());

                    if (args.Length > 3)
                    {
                        strDestImgDir = args[3];

                        if (args.Length > 4)
                        {
                            int iImgFormatInternalId = int.Parse(args[2].ToString());
                            imgFormat = GetImageFormatFromInternalId(iImgFormatInternalId);
                        }
                    }
                }
            }


            strDestImgDir = string.IsNullOrEmpty(strDestImgDir) ? strImgDir : strDestImgDir;


            Console.WriteLine("Using images from dir " + strImgDir);
            Console.WriteLine("Will send images to dir " + strDestImgDir);
            Console.WriteLine("Using image format: "+imgFormat.ToString());
            Console.WriteLine("New size: " + iWidth+"," + (iHeight > 0? iHeight+"": "Height will be calculated as a ratio from the given width") + ".");

            if (!Directory.Exists(strImgDir))
            {
                Console.WriteLine("The given source directory does not exist!");
                Usage();
                Console.WriteLine(Environment.NewLine + "press ENTER to terminate");
                Console.ReadLine();
                return;
            }

            if (!Directory.Exists(strDestImgDir))
            {
                Console.WriteLine("The given destination directory does not exist!");
                Usage();
                Console.WriteLine(Environment.NewLine + "press ENTER to terminate");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Press ENTER to continue...");

            try
            {
                string[] strFiles = Directory.GetFiles(strImgDir);
                int nFiles = strFiles.Length;
                // Obtaining all the image files from the given dir ...

                // Resize all the images ...
                for (int i = 0; i < nFiles; i++)
                {
                    ResizeImage(strFiles[i], strImgDir, strDestImgDir, iWidth, iHeight, imgFormat);
                }

                Console.WriteLine(Environment.NewLine + "Finished - press ENTER to terminate");
                Console.ReadLine();
                return;
            }
            catch(Exception e)
            {
                Console.WriteLine("\n\nException: \n" + e.ToString());
                Console.WriteLine(Environment.NewLine + "Press ENTER to terminate");
                Console.ReadLine();
                return;
            }
        }

        static void ResizeImage(string strImgFilePath, string strSrcImgDir, string strDestImgDir, int iWidth, int iHeight, ImageFormat imgFormat)
        {

            Bitmap SourceBitmap = new Bitmap(strImgFilePath);

            // determining the height, if found, its used otherwise, the height
            // will be calculated from the scaling 'width' 
            if(iHeight < 0)
            {
                iHeight = (SourceBitmap.Height * iWidth) / SourceBitmap.Width;
            }

            Bitmap TargetBitmap = new Bitmap(iWidth, iHeight);

            Graphics bmpGraphics = Graphics.FromImage(TargetBitmap);
            // set Drawing Quality
            bmpGraphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            bmpGraphics.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle resizedRectangle = new Rectangle(0, 0, iWidth, iHeight);
            //Rectangle compressionRectangle = new Rectangle(0, 0, SourceBitmap.Width / ScaleValue, SourceBitmap.Height / ScaleValue);
            bmpGraphics.DrawImage(SourceBitmap, resizedRectangle);

            string strNewFileName =
                strSrcImgDir.Equals(strDestImgDir) ?
                    strImgFilePath + "_" + iWidth + "x" + iHeight + "." + imgFormat.ToString() :
                    strDestImgDir + "\\" + ObtainFileNameOnly(strImgFilePath) + "." + imgFormat.ToString().ToLower();

			// Maintaining original properties (some EXIF props)
			foreach (PropertyItem pi in SourceBitmap.PropertyItems)
			{
				TargetBitmap.SetPropertyItem(pi);
			}


            TargetBitmap.Save(strNewFileName, imgFormat);

            Console.WriteLine("File: "+ strNewFileName + ".");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <returns></returns>
        private static string ObtainFileNameOnly(string strFilePath)
        {
            return
                strFilePath.Substring(strFilePath.LastIndexOf("\\") + 1).Substring(
                    0,
                    strFilePath.Substring(strFilePath.LastIndexOf("\\") + 1).LastIndexOf("."));
        }

        static void Usage()
        {
            Console.WriteLine("usage: ResizeImages imgs_source_dir_path new_width [new_height [imgs_dest_dir_path [img_format(1:BMP 2:GIF 3:JPG 4:PNG 5:TIF)]]]");
            Console.WriteLine("\tIf the new_height value is not available, it'll be calculated using the width scale.");
            Console.WriteLine("\tIf the imgs_dest_dir_path value is not available, it'll be used the source dir as the destination one.");
            Console.WriteLine("\tIf the img_format value is not available, it'll be used GIF image format.");
        }


        /// <summary>
        /// [1:BMP 2:GIF 3:JPG 4:PNG 5:TIF]
        /// 
        /// </summary>
        /// <param name="iInternalImgFormatId"></param>
        /// <returns></returns>
        static ImageFormat GetImageFormatFromInternalId(int iInternalImgFormatId)
        {
            switch (iInternalImgFormatId)
            {
                case 1:
                    return ImageFormat.Bmp;
                case 2:
                    return ImageFormat.Gif;
                case 3:
                    return ImageFormat.Jpeg;
                case 4:
                    return ImageFormat.Png;
                case 5:
                    return ImageFormat.Tiff;
                default:
                    return ImageFormat.Gif;
            }
        }

		///// <summary>  
		///// Sets the meta value of the bitmap. Complete list of EXIF values http://www.exiv2.org/tags.html  
		///// </summary>  
		///// <param name="SourceBitmap">Bitmap to which changes will be applied to</param>  
		///// <param name="property">Property enum value containing the id of the property to be changed</param>         
		///// <param name="value">Value of the proeprty to be set</param>  
		///// <returns>Returns updated bitmap</returns>  
		//static Bitmap SetMetaValue(this Bitmap SourceBitmap, MetaProperty property, string value)
		//{
		//	PropertyItem prop = SourceBitmap.PropertyItems[0];

		//	int iLen = value.Length + 1;
		//	byte[] bTxt = new Byte[iLen];
		//	for (int i = 0; i < iLen - 1; i++)
		//		bTxt[i] = (byte)value[i];
		//	bTxt[iLen - 1] = 0x00;
		//	prop.Id = (int)property;
		//	prop.Type = 2;
		//	prop.Value = bTxt;
		//	prop.Len = iLen;
		//	return SourceBitmap;
		//}

		///// <summary>  
		///// Returns meta value from the bitmap  
		///// </summary>  
		///// <param name="SourceBitmap">Bitmap to which changes will be applied to</param>  
		///// <param name="property">Property enum value containing the id of the property to be changed</param>  
		///// <returns>Returns value of the bitmap meta property</returns>  
		//static string GetMetaValue(this Bitmap SourceBitmap, MetaProperty property)
		//{
		//	PropertyItem[] propItems = SourceBitmap.PropertyItems;
		//	var prop = propItems.FirstOrDefault(p => p.Id == (int)property);
		//	if (prop != null)
		//	{
		//		return Encoding.UTF8.GetString(prop.Value);
		//	}
		//	else
		//	{
		//		return null;
		//	}
		//}
    }
}
