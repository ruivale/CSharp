using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;
using ImagerLib;
using System.Net;

public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string filename = Path.GetFileName(fuImage.PostedFile.FileName);
        //string str = DateTime.Now.ToString("hhmmssffffff") + filename;
        string str = filename;
        fuImage.SaveAs(Server.MapPath("ImgDir/" + str));
        string imgPath = "D:\\RND_Project\\ImageResize\\";
        imgBefore.ImageUrl = "\\ImgDir\\" + str;

        System.Drawing.Image imgBef ;
        imgBef =  System.Drawing.Image.FromFile(imgPath+imgBefore.ImageUrl);


        System.Drawing.Image _imgR;
        _imgR = Imager.Resize(imgBef, 1500, 1500, false);


        System.Drawing.Image _img2;
        _img2 = Imager.PutOnCanvas(_imgR, 1500, 1500, System.Drawing.Color.White);


        byte[] imgByteFile = null;
        imgByteFile = Imager.imageToByteArray(_img2);

        imgAfter.ImageUrl = Imager.GetImage(imgByteFile);


        String exportFileName = DateTime.Now.ToString("ddMMyyyyhhmmssffff");
        string Pic_Path = HttpContext.Current.Server.MapPath("MyPicture_"+exportFileName+".png");
        using (FileStream fs = new FileStream(Pic_Path, FileMode.Create))
        {
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                //byte[] data = Convert.FromBase64String(Imager.GetImage(imgByteFile));
                bw.Write(imgByteFile);
                bw.Close();
            }
        }

    }


  

    
}