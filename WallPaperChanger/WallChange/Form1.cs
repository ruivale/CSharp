using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO; 
using System.Diagnostics;


namespace WallChange
{	
		
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		public const int SPI_SETDESKWALLPAPER = 20;
		public const int SPIF_SENDCHANGE = 0x2;
		public int picIndex ;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.CheckedListBox mycheckedListBox;
		private System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.Timer timer1;
		string fileName;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ComboBox cmbInterval;
		private int GlobalTimer;
		private System.Windows.Forms.Button btnChange;
		private System.Windows.Forms.Button btnOpen;
		public int GlobalInterval;
		private System.Windows.Forms.Button btnAbout;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private int[] myArray;
		private System.Windows.Forms.MenuItem menuItem3;
		private Settings mySetting;
		

		public Form1()
		{
			InitializeComponent();
			mySetting = new Settings(Directory.GetCurrentDirectory(), this);

			GlobalTimer = 0;
			GlobalInterval = 60 / 5;
			
			picIndex = 0;
			myArray = new int[]{   60 ,
								   5 * 60, 
								   15 * 60 ,
								   1 * 60 * 60 ,
								   2 * 60 * 60 , 
								   1 * 24 * 60 * 60 ,
								   2 * 24 * 60 * 60 , 
									-12
							   };
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			
			base.Dispose( disposing );
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
			this.btnChange = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.btnOpen = new System.Windows.Forms.Button();
			this.mycheckedListBox = new System.Windows.Forms.CheckedListBox();
			this.btnDel = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.cmbInterval = new System.Windows.Forms.ComboBox();
			this.btnAbout = new System.Windows.Forms.Button();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// btnChange
			// 
			this.btnChange.Location = new System.Drawing.Point(64, 8);
			this.btnChange.Name = "btnChange";
			this.btnChange.Size = new System.Drawing.Size(64, 24);
			this.btnChange.TabIndex = 0;
			this.btnChange.Text = "Change";
			this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Multiselect = true;
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(8, 8);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(48, 24);
			this.btnOpen.TabIndex = 2;
			this.btnOpen.Text = "&Open";
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// mycheckedListBox
			// 
			this.mycheckedListBox.AllowDrop = true;
			this.mycheckedListBox.ColumnWidth = 300;
			this.mycheckedListBox.HorizontalScrollbar = true;
			this.mycheckedListBox.Location = new System.Drawing.Point(8, 48);
			this.mycheckedListBox.Name = "mycheckedListBox";
			this.mycheckedListBox.Size = new System.Drawing.Size(416, 154);
			this.mycheckedListBox.Sorted = true;
			this.mycheckedListBox.TabIndex = 3;
			this.mycheckedListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.mycheckedListBox_DragDrop);
			this.mycheckedListBox.SelectedIndexChanged += new System.EventHandler(this.mycheckedListBox_SelectedIndexChanged);
			this.mycheckedListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.mycheckedListBox_DragEnter);
			// 
			// btnDel
			// 
			this.btnDel.Location = new System.Drawing.Point(136, 8);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(64, 24);
			this.btnDel.TabIndex = 4;
			this.btnDel.Text = "Delete";
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 5000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(296, 8);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(80, 24);
			this.checkBox1.TabIndex = 6;
			this.checkBox1.Text = "Random";
			// 
			// cmbInterval
			// 
			this.cmbInterval.Items.AddRange(new object[] {
															 "1min",
															 "5min",
															 "15min",
															 "1hr",
															 "2hr",
															 "1Day",
															 "2Day",
															 "eternity"});
			this.cmbInterval.Location = new System.Drawing.Point(208, 8);
			this.cmbInterval.Name = "cmbInterval";
			this.cmbInterval.Size = new System.Drawing.Size(72, 21);
			this.cmbInterval.TabIndex = 7;
			this.cmbInterval.Text = "Interval";
			this.cmbInterval.SelectedIndexChanged += new System.EventHandler(this.cmbInterval_SelectedIndexChanged);
			// 
			// btnAbout
			// 
			this.btnAbout.Location = new System.Drawing.Point(368, 8);
			this.btnAbout.Name = "btnAbout";
			this.btnAbout.Size = new System.Drawing.Size(64, 24);
			this.btnAbout.TabIndex = 8;
			this.btnAbout.Text = "About";
			this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenu = this.contextMenu1;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "WallPaper";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1,
																						 this.menuItem2,
																						 this.menuItem3});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "E&xit";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "&Restore";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "&Change";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(440, 213);
			this.Controls.Add(this.btnAbout);
			this.Controls.Add(this.cmbInterval);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.btnDel);
			this.Controls.Add(this.mycheckedListBox);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.btnChange);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "WallPaper";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

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
		/// <summary>
		/// Change the wallpaper immediately. the method search for any image file in
		/// the directory and enter them into an checked list box
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnChange_Click(object sender, System.EventArgs e)
		{
			SetBMP();
		}
		/// <summary>
		/// update the ini file with the picture index
		/// </summary>
		private void UpdateFile()
		{
			mySetting.SaveSettings();

		}
		/// <summary>
		/// add an image file into the checked listbox
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOpen_Click(object sender, System.EventArgs e)
		{
			//change the initial directory if required.
			openFileDialog1.InitialDirectory = @"c:\";
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				foreach (string fileName in openFileDialog1.FileNames )
				{
					mycheckedListBox.Items.Add (fileName,CheckState.Checked);
				}	
				UpdateFile();
			}

		}
		/// <summary>
		/// form load
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, System.EventArgs e)
		{
			this.Hide();
			mySetting.LoadSettings();
				
			mycheckedListBox.Items.Clear();
			checkDir(mySetting.m_settingsPath);
			
			if (mycheckedListBox.Items.Count > picIndex)
			{
				mycheckedListBox.SelectedIndex = picIndex;
			}
			if (mycheckedListBox.Items.Count > 0)
			{
				fileName = mycheckedListBox.Items[picIndex].ToString();
			}
			SetBMP();
			
			
		}
		/// <summary>
		/// add a selected file type to the listbox
		/// if a new type is suppose to be added - please enter it here
		/// </summary>
		/// <param name="fileType">the file type to be added</param>
		/// <param name="mycheckedListBox"></param>
		/// <returns></returns>
		private void AddAllSupportedTypes(string dir)
		{
			AddToCheckedListBox("*.jpg", dir);
			AddToCheckedListBox("*.jpeg", dir);
			AddToCheckedListBox("*.bmp", dir);
			AddToCheckedListBox("*.gif", dir);


		}
		/// <summary>
		/// check the directory , collect all the file name of a certain type
		/// and send them to AddToListBox
		/// </summary>
		/// <param name="fileType">image type file</param>
		/// <param name="dir">the selected directory</param>
		private void AddToCheckedListBox (string fileType, string dir)
		{
			string[] dirs = Directory.GetFiles(dir , fileType);
			
			AddToListBox(dirs);
			
		}
		/// <summary>
		/// add the string[] to the list box
		/// </summary>
		/// <param name="files">the array of strings to be added</param>
		private void AddToListBox (string[] files)
		{
			foreach (string file in files) 
			{
				mycheckedListBox.Items.Add (file ,CheckState.Checked);
				Trace.WriteLine("adding : " + file);
			}
		}
		private void AddToListBox (string file)
		{
			{
				mycheckedListBox.Items.Add (file ,CheckState.Checked);
				Trace.WriteLine("adding : " + file);
			}
		}
		/// <summary>
		/// get all the directorys in the specific directory and send them
		/// to check all files and sub directories
		/// </summary>
		/// <param name="strDir">the directory to be searched in</param>
		private void checkDir(string strDir)
		{	
			string [] strTempDir  = Directory.GetDirectories(strDir);
			foreach (string newstr in strTempDir)
			{
				checkDir (newstr);
				
			}
			AddAllSupportedTypes(strDir);
		}

		public bool m_bcheckChangePossible = true;
		private void mycheckedListBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (m_bcheckChangePossible)
				fileName = mycheckedListBox.SelectedItem.ToString();
		}
		
		/// <summary>
		/// Delete picture from the listbox
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDel_Click(object sender, System.EventArgs e)
		{
			if (mycheckedListBox.Items.Count < 1)
				return;
			if (mycheckedListBox.SelectedIndex < 0)
			{
				return;
			}
			m_bcheckChangePossible = false;
			int Index = mycheckedListBox.SelectedIndex;
			mycheckedListBox.Items.RemoveAt(Index);
			fileName = mycheckedListBox.SelectedIndex.ToString();
			m_bcheckChangePossible = true;
		}

		/// <summary>
		/// machine clock
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if (GlobalInterval < 0) return;
			if (GlobalTimer++ > GlobalInterval)
			{
				SetBMP();
				GlobalTimer = 0;
			}
		}
		/// <summary>
		/// Set the new BMP in the background
		/// </summary>
		private void SetBMP()
		{
			try
			{
				int nResult ;
				if (mycheckedListBox.Items.Count < 1)
					return;
				picIndex = mycheckedListBox.SelectedIndex ;
				if (picIndex  < 0 )
				{
				
					picIndex = 0;
					mycheckedListBox.SelectedIndex = 0;
				}
			
				if (Path.GetExtension(fileName).ToLower() != ".bmp")
				{
					Bitmap theImage = new Bitmap(fileName);
					fileName = Path.Combine(mySetting.m_settingsPath ,  "new.bmp");
					theImage.Save (fileName, System.Drawing.Imaging.ImageFormat.Bmp);
					theImage .Dispose();
				}
			
				nResult =  WinAPI.SystemParametersInfo(SPI_SETDESKWALLPAPER,1,fileName,SPIF_SENDCHANGE);
				picIndex  = (picIndex + 1 ) % mycheckedListBox.CheckedItems.Count;
				if (checkBox1.Checked == true)
				{
					Random rnd = new Random();
					picIndex = (rnd.Next(mycheckedListBox.CheckedItems.Count) %
						mycheckedListBox.CheckedItems.Count);
				}
				mycheckedListBox.SelectedIndex = picIndex;

				UpdateFile();
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.ToString());
			}
		}

		private void cmbInterval_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			GlobalInterval = myArray[cmbInterval.SelectedIndex]  / 5;
			GlobalTimer = 0;
			UpdateFile();
		}

		private void btnAbout_Click(object sender, System.EventArgs e)
		{
			frmAbout myfrmAbout = new frmAbout();
			myfrmAbout.Show();
		}

		

		private void mycheckedListBox_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			Trace.WriteLine("ListBox Drag enter");
			
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			
			foreach (string dirfile in files)
			{
				if (CheckIfDirectory(dirfile ))
	                 checkDir(dirfile);
                else 
					 AddToListBox(dirfile);
			}
			
			Trace.WriteLine("After Sending to listbox");
			
		}
		private bool CheckIfDirectory(string dir)
		{
			bool bAns = false;
			if (File.GetAttributes(dir) == FileAttributes.Directory)
				bAns = true;
			return bAns;
		}
	
		private void mycheckedListBox_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop, false)==true)
				e.Effect = DragDropEffects.All;
			Trace.WriteLine("ListBoxDragDrop   ");
		}

		private void notifyIcon1_DoubleClick(object sender, System.EventArgs e)
		{
			this.Show();
			this.WindowState = FormWindowState.Normal;
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			this.Show();
			this.WindowState = FormWindowState.Normal;
		}

		private void Form1_Resize(object sender, System.EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
				this.Hide();
			
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			btnChange_Click(sender, e);
		
		}

		
		

	}

	public class WinAPI
	{
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static  extern int SystemParametersInfo (int uAction , int uParam , string lpvParam , int fuWinIni) ;
		public const int SPI_SETDESKWALLPAPER = 20;
		public const int SPIF_SENDCHANGE = 0x2;

	}  


}
