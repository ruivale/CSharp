using System;
using System.IO; 
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ABCImages{

	public class ScaleImages
	{

         static void Main(string[] args)    
		 {
             if (args.Length == 0 || args.Length != 3)
            {
                Console.WriteLine("No/wrong arguments submitted");
                Console.WriteLine("usage: scale imgs_dir_path new_width new_height" + Environment.NewLine);
                Console.ReadLine();
                return;
            }

            int iWidth = int.Parse(args[1].ToString());
            int iHeight = int.Parse(args[2].ToString());

            Console.WriteLine("Using images from dir " +args[0]+". New size: "+iWidth+"x"+iHeight+"."+ Environment.NewLine);

            if (!Directory.Exists(args[0]))
            {
                Console.WriteLine("The given directory does not exist!");
                Console.WriteLine("usage: scale imgs_dir_path new_width new_height" + Environment.NewLine);
                return;
            }

            try
            {
                string[] strFiles = Directory.GetFiles(args[0]);
                int nFiles = strFiles.Length;
                // Obtaining all the image files from the given dir ...

                // Resize all the images ...
                for (int i = 0; i < nFiles; i++)
                {
                    Console.WriteLine("Resizing file: " + strFiles[i]+" ...");                    
                    //ResizeImage(strFiles[i], iWidth, iHeight);
                }

                return;
            }
            catch
            {
                Console.WriteLine(Environment.NewLine + "Exception - press any key to terminate" + Environment.NewLine);
                Console.ReadLine();
                return;
            }
        }		 

         static void ResizeImage(string strImgPath, int iWidth, int iHeight)
         {
             Bitmap SourceBitmap = new Bitmap(strImgPath);
             Bitmap TargetBitmap = new Bitmap(iWidth, iHeight);

             Graphics bmpGraphics = Graphics.FromImage(TargetBitmap);
             // set Drawing Quality
             bmpGraphics.InterpolationMode = InterpolationMode.High;
             bmpGraphics.SmoothingMode = SmoothingMode.AntiAlias;

             Rectangle resizedRectangle = new Rectangle(0, 0, iWidth, iHeight);
             //Rectangle compressionRectangle = new Rectangle(0, 0, SourceBitmap.Width / ScaleValue, SourceBitmap.Height / ScaleValue);
             bmpGraphics.DrawImage(SourceBitmap, resizedRectangle);
             TargetBitmap.Save(strImgPath+"_"+iWidth+"x"+iHeight+".jpg", ImageFormat.Jpeg);
         }
	}
}
	
	

