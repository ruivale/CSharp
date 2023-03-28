/*
Sticky NotePad , By Saurabh Nandu
http://learncsharp.cjb.net 
03/03/2001

*/

namespace stickynote
{
	//Import the necessary Asemblies
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.WinForms;
    using System.Data;
	using System.IO ;
	
    /// <summary>
    ///    The class to demonstrate a Sticky Pad 
    /// </summary>
    public class sticky : System.WinForms.Form
    {
        /// <summary>
        ///    Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components;
		private System.WinForms.MenuItem menuItem4;
		private System.WinForms.MenuItem menuItem3;
		private System.WinForms.MenuItem menuItem2;
		private System.WinForms.MenuItem menuItem1;
		private System.WinForms.ContextMenu contextMenu1;
		//TrayIcon is used to place the Application in the System Tray
		private System.WinForms.TrayIcon StickyNote;
		private System.WinForms.RichTextBox tbox;
		
		/// <summary>
		///		The Constructor
		///		We Call 2 methods here 
		///		InitilizeComponent - to Initilize the winform
		///		read - to read the data from the text file 
		/// </summary>
        public sticky()
        {
            InitializeComponent();
			read();
        }

        /// <summary>
        ///    Clean up any resources being used.
        /// </summary>
        public override void Dispose()
        {
			//Before Disposing Save the Text
			save();
			this.StickyNote.Dispose();
            base.Dispose();
            components.Dispose();
        }

        /// <summary>
        ///    Required method for Designer support - do not modify
        ///    the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager (typeof(sticky));
			this.components = new System.ComponentModel.Container ();
			this.tbox = new System.WinForms.RichTextBox ();
			this.contextMenu1 = new System.WinForms.ContextMenu ();
			this.menuItem4 = new System.WinForms.MenuItem ();
			this.menuItem2 = new System.WinForms.MenuItem ();
			this.menuItem1 = new System.WinForms.MenuItem ();
			this.StickyNote = new System.WinForms.TrayIcon ();
			this.menuItem3 = new System.WinForms.MenuItem ();
			//@this.TrayHeight = 90;
			//@this.TrayLargeIcon = false;
			//@this.TrayAutoArrange = true;
			tbox.AutoWordSelection = true;
			tbox.Size = new System.Drawing.Size (194, 156);
			tbox.ContextMenu = this.contextMenu1;
			tbox.TabIndex = 1;
			tbox.ScrollBars = System.WinForms.RichTextBoxScrollBars.Vertical;
			tbox.Dock = System.WinForms.DockStyle.Fill;
			tbox.CausesValidation = false;
			tbox.TabStop = false;
			tbox.BackColor = System.Drawing.Color.Orange;
			//@contextMenu1.SetLocation (new System.Drawing.Point (100, 7));
			contextMenu1.MenuItems.All = new System.WinForms.MenuItem[4] {this.menuItem1, this.menuItem2, this.menuItem3, this.menuItem4};
			menuItem4.Text = "Exit";
			menuItem4.Index = 3;
			menuItem4.Click += new System.EventHandler (this.Exit);
			menuItem2.Text = "Hide";
			menuItem2.Index = 1;
			menuItem2.Click += new System.EventHandler (this.minimise);
			menuItem1.Text = "Show";
			menuItem1.Index = 0;
			menuItem1.Click += new System.EventHandler (this.maximise);
			//@StickyNote.SetLocation (new System.Drawing.Point (7, 7));
			StickyNote.Text = "StickyNote";
			StickyNote.Visible = true;
			StickyNote.Icon = (System.Drawing.Icon) resources.GetObject ("StickyNote.Icon");
			StickyNote.ContextMenu = this.contextMenu1;
			menuItem3.Text = "Help";
			menuItem3.Index = 2;
			menuItem3.Click += new System.EventHandler (this.helpme);
			this.Text = "Sticky Note, By Saurabh Nandu";
			this.MaximizeBox = false;
			this.AutoScaleBaseSize = new System.Drawing.Size (5, 13);
			this.BorderStyle = System.WinForms.FormBorderStyle.FixedSingle;
			this.ContextMenu = this.contextMenu1;
			this.WindowState = System.WinForms.FormWindowState.Minimized;
			this.ShowInTaskbar = false;
			this.Icon = (System.Drawing.Icon) resources.GetObject ("$this.Icon");
			this.CausesValidation = false;
			this.TopMost = true;
			this.ControlBox = false;
			this.BackColor = System.Drawing.Color.Orange;
			this.ClientSize = new System.Drawing.Size (194, 156);
			this.Controls.Add (this.tbox);
		}

		
		/// <summary>
		///		This function is called when "Hide"
		///		is selected from the context menu
		/// </summary>
		protected void minimise (object sender, System.EventArgs e)
		{
			if(this.Visible)
			{
				//Hide the Application
				this.Hide();
			}
			
		}
		
		/// <summary>
		///		This method is called when "Show" 
		///		is selected from the context Menu
		/// </summary>
		protected void maximise (object sender, System.EventArgs e)
		{
			//Maximise the Window
			//Why??? since we are initially setting the WinForms
			//State to "Minimised" in the constructor
			this.WindowState = System.WinForms.FormWindowState.Normal;
			if(!this.Visible)
			{
				//If the Window is hidded 
				//Show it
				this.Show();
			}
			
		}
		/// <summary>
		///		Method called when "Help" button clicked 
		/// </summary>
		protected void helpme (object sender, System.EventArgs e)
		{
			MessageBox.Show("Sticky Note Made by Saurabh Nandu, saurabhn@webveda.com") ;
		}

		/// <summary>
		///		Called when "Exit" is slelcted from the context menu.
		/// </summary>
		protected void Exit (object sender, System.EventArgs e)
		{
			//Call the Dispose Method
			this.Close();
		}

		/// <summary>
		///		This method is called from the destructor (Dispose)
		///		It saves the Data to the Text File
		/// </summary>
		protected void save()
		{
			//Open a File Stream
			FileStream fout = new FileStream("sticky.txt", FileMode.Open, 
				FileAccess.Write, FileShare.ReadWrite) ;
			//Get a StreamWriter , since its easy to write string with it.
			StreamWriter sw = new StreamWriter(fout) ;
			//Write the contents for the RichTextBox
			sw.Write(tbox.Text);
			//Close the Streams
			sw.Close();
			fout.Close();
		}

		/// <summary>
		///		This method is called from the constructor
		///		It read the text from the Text file 
		///		and displays it in the RichTextBox
		/// </summary>
		protected void read()
		{
			//Open the streams to the file
			FileStream fin = new FileStream("sticky.txt", FileMode.Open, 
				FileAccess.Read, FileShare.ReadWrite) ;
			StreamReader tr = new StreamReader(fin) ;
			//Read the data, I use "ReadToEnd" cause with it you 
			//can read the whole file in one shot !
			tbox.Text = tr.ReadToEnd();
			//Close the streams
			tr.Close();
			fin.Close();
		}
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main(string[] args) 
        {
            Application.Run(new sticky());
        }
    }
}
