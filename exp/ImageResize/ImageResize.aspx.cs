using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImagerLib;

public partial class ImageResize : System.Web.UI.Page
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
        string imgPath = "D:\\RND_Project\\ImageResize\\ImgDir\\";
        
        Imager.PerformImageResizeAndPutOnCanvas(imgPath,filename, Convert.ToInt16(txtWidth.Text), Convert.ToInt16(txtHeight.Text), txtOutputFileName.Text.ToString()+".jpg");

    }
}