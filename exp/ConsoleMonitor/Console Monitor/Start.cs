using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace Console_Monitor
{
    public partial class Start : Form
    {
        string strPath = "C:\\temp\\Snap\\";

        int c = 0;

        public Start()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo di = Directory.CreateDirectory(strPath);
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;

                File.WriteAllText(strPath+"interval.txt", textBox1.Text);

                timer1.Interval = (Convert.ToInt32(textBox1.Text) * 1000);
                this.Hide();
                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !");
                File.Delete(strPath+"interval.txt");
                Directory.Delete(strPath);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Graphics gr = Graphics.FromImage(bmp);
                gr.CopyFromScreen(0, 0, 0, 0, bmp.Size);

                string str = string.Format(strPath+"Snap[{0}].jpeg", c);

                bmp.Save(str, ImageFormat.Jpeg);

                c++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !");
            }
        }

        private void Start_Load(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();

                if (File.Exists(strPath+"interval.txt"))
                {
                    Opacity = 0;
                    int x = Convert.ToInt32(File.ReadAllText(strPath+"interval.txt"));
                    timer1.Interval = x * 1000;
                    timer1.Start();
                }
                else
                {
                    timer1.Stop();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            steps st = new steps();
            st.ShowDialog();
        }
    }
}
