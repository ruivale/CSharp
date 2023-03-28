using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WinForms
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.NotifyIcon ntfyIc;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.ComponentModel.IContainer components;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
            System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.ntfyIc = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 0;
            this.menuItem3.Text = "&Hello";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);

            // 
            // ntfyIc
            // 
            this.ntfyIc.ContextMenu = this.contextMenu1;
            this.ntfyIc.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfyIc.Icon")));
            this.ntfyIc.Text = "AutoHiber";
            this.ntfyIc.Visible = true;
            this.ntfyIc.Disposed += new System.EventHandler(this.ntfyIc_Disposed);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem3,
																						 this.menuItem4});
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Text = "E&xit";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Name = "Form1";
            this.Opacity = System.Double.Parse(configurationAppSettings.Get("Form1.Opacity"));
            this.ShowInTaskbar = bool.Parse(configurationAppSettings.Get("Form1.ShowInTaskbar"));
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());


        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
        }

        private void ntfyIc_Disposed(object sender, System.EventArgs e)
        {

        }

        private void menuItem3_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Hello World. This a tray icon application. Bye!");
        }


        private void menuItem4_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

    }
}
