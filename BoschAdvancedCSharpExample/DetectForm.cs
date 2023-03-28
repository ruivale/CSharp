using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// Summary description for DetectForm.
	/// </summary>
	public class DetectForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.DataGrid m_detectedDevicesGrid;
		private System.Windows.Forms.Button m_btnAddDevices;
		private System.Windows.Forms.Button m_btnReadDeviceInfoCache;
		private System.Windows.Forms.Button m_btnClearTable;
		private System.Windows.Forms.Button m_btnStartDetect;

		// Data members
		private Bosch.VideoSDK.Device.DeviceFinderClass m_deviceFinder = null;
		private MainForm m_mainForm = null;
		private DataTable m_detectedDevicesTable = null;
		
		public DetectForm(MainForm mainForm)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Store a pointer to the main form that created this form
			// so we can notify it when this form closes.
			m_mainForm = mainForm;

			// Add event handlers for the device finder's events.
			m_deviceFinder = new Bosch.VideoSDK.Device.DeviceFinderClass();
			m_deviceFinder.DeviceDetected += new Bosch.VideoSDK.GCALib._IDeviceFinderEvents_DeviceDetectedEventHandler(OnDeviceDetected);
			m_deviceFinder.DeviceRemoved += new Bosch.VideoSDK.GCALib._IDeviceFinderEvents_DeviceRemovedEventHandler(OnDeviceRemoved);

			// Initialize the device information data grid.
			m_detectedDevicesTable = new DataTable();

			m_detectedDevicesTable.Columns.Add(new DataColumn("Name", typeof(string)));
			m_detectedDevicesTable.Columns.Add(new DataColumn("Address", typeof(string)));
			m_detectedDevicesTable.Columns.Add(new DataColumn("ProgID", typeof(string)));
			m_detectedDevicesTable.Columns.Add(new DataColumn("Description", typeof(string)));
			m_detectedDevicesTable.Columns.Add(new DataColumn("Type", typeof(string)));
			m_detectedDevicesTable.Columns.Add(new DataColumn("SubType", typeof(string)));
			m_detectedDevicesTable.Columns.Add(new DataColumn("Audio", typeof(string)));
			m_detectedDevicesTable.Columns.Add(new DataColumn("MacAddress", typeof(string)));
			
			m_detectedDevicesGrid.DataSource = m_detectedDevicesTable;
			
			// Start a detection operation.
			ToggleDetect();
		}

		private void OnDeviceDetected(Bosch.VideoSDK.Device.DeviceInfo deviceInfo)
		{
			// Add a new row to the device table.  It will show up in the
			// m_deviceGrid data grid on the main form.
			DataRow newRow;
						
			newRow = m_detectedDevicesTable.NewRow();
			newRow["Name"] = deviceInfo.Name;
			newRow["Address"] = deviceInfo.IPAddress;
			newRow["ProgID"] = deviceInfo.ProgID;
			newRow["Description"] = deviceInfo.Description;
			newRow["Type"] = deviceInfo.Type.ToString();
			newRow["SubType"] = deviceInfo.SubType.ToString();
			newRow["Audio"] = deviceInfo.Audio.ToString();
			newRow["MacAddress"] = deviceInfo.MacAddress;
			m_detectedDevicesTable.Rows.Add(newRow);
		}

		private void OnDeviceRemoved(Bosch.VideoSDK.Device.DeviceInfo deviceInfo)
		{
			DataRow rowToRemove = null;

			foreach (DataRow row in m_detectedDevicesTable.Rows)
			{
				if (row["Address"].ToString() == deviceInfo.IPAddress)
				{
					rowToRemove = row;
				}
			}

			if (rowToRemove != null)
				m_detectedDevicesTable.Rows.Remove(rowToRemove);
			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.m_detectedDevicesGrid = new System.Windows.Forms.DataGrid();
			this.m_btnAddDevices = new System.Windows.Forms.Button();
			this.m_btnReadDeviceInfoCache = new System.Windows.Forms.Button();
			this.m_btnClearTable = new System.Windows.Forms.Button();
			this.m_btnStartDetect = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.m_detectedDevicesGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// m_detectedDevicesGrid
			// 
			this.m_detectedDevicesGrid.AllowSorting = false;
			this.m_detectedDevicesGrid.CaptionVisible = ((bool)(configurationAppSettings.GetValue("m_detectedDevicesGrid.CaptionVisible", typeof(bool))));
			this.m_detectedDevicesGrid.DataMember = "";
			this.m_detectedDevicesGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.m_detectedDevicesGrid.Location = new System.Drawing.Point(0, 0);
			this.m_detectedDevicesGrid.Name = "m_detectedDevicesGrid";
			this.m_detectedDevicesGrid.PreferredColumnWidth = 100;
			this.m_detectedDevicesGrid.Size = new System.Drawing.Size(760, 344);
			this.m_detectedDevicesGrid.TabIndex = 0;
			// 
			// m_btnAddDevices
			// 
			this.m_btnAddDevices.Location = new System.Drawing.Point(592, 352);
			this.m_btnAddDevices.Name = "m_btnAddDevices";
			this.m_btnAddDevices.Size = new System.Drawing.Size(168, 23);
			this.m_btnAddDevices.TabIndex = 1;
			this.m_btnAddDevices.Text = "Add Selected Devices to Tree";
			this.m_btnAddDevices.Click += new System.EventHandler(this.m_btnAddDevices_Click);
			// 
			// m_btnReadDeviceInfoCache
			// 
			this.m_btnReadDeviceInfoCache.Location = new System.Drawing.Point(315, 352);
			this.m_btnReadDeviceInfoCache.Name = "m_btnReadDeviceInfoCache";
			this.m_btnReadDeviceInfoCache.Size = new System.Drawing.Size(144, 23);
			this.m_btnReadDeviceInfoCache.TabIndex = 2;
			this.m_btnReadDeviceInfoCache.Text = "Read DeviceInfos Cache";
			this.m_btnReadDeviceInfoCache.Click += new System.EventHandler(this.m_btnReadDeviceInfoCache_Click);
			// 
			// m_btnClearTable
			// 
			this.m_btnClearTable.Location = new System.Drawing.Point(212, 352);
			this.m_btnClearTable.Name = "m_btnClearTable";
			this.m_btnClearTable.TabIndex = 3;
			this.m_btnClearTable.Text = "Clear Table";
			this.m_btnClearTable.Click += new System.EventHandler(this.m_btnClearTable_Click);
			// 
			// m_btnStartDetect
			// 
			this.m_btnStartDetect.Location = new System.Drawing.Point(0, 352);
			this.m_btnStartDetect.Name = "m_btnStartDetect";
			this.m_btnStartDetect.Size = new System.Drawing.Size(184, 23);
			this.m_btnStartDetect.TabIndex = 4;
			this.m_btnStartDetect.Text = "Start Detect";
			this.m_btnStartDetect.Click += new System.EventHandler(this.m_btnStartDetect_Click);
			// 
			// DetectForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(768, 381);
			this.Controls.Add(this.m_btnStartDetect);
			this.Controls.Add(this.m_btnClearTable);
			this.Controls.Add(this.m_btnReadDeviceInfoCache);
			this.Controls.Add(this.m_btnAddDevices);
			this.Controls.Add(this.m_detectedDevicesGrid);
			this.Name = "DetectForm";
			this.Text = "Detected Devices";
			((System.ComponentModel.ISupportInitialize)(this.m_detectedDevicesGrid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		
	
		protected override void OnClosing(CancelEventArgs e)
		{
			// This form is closing.  Stop the device finder from detecting.
			try
			{
				m_deviceFinder.StopDetect();
			}
			catch
			{
				m_mainForm.LogMessage("DetectForm",	"OnClosing", "Error calling StopDetect");
			}

			m_mainForm.OnDetectFormClosed();
			base.OnClosing (e);
		}
	
		protected override void OnResize(EventArgs e)
		{
			int heightAdjust = 2 * m_btnAddDevices.Height + m_btnAddDevices.Height / 2;

			// Adjust the positioning of the devices grid and the
			// add devices button.
			m_detectedDevicesGrid.Height = this.Size.Height - heightAdjust;
			m_detectedDevicesGrid.Width = this.Size.Width - 7; //need room for the scroll bar
			
			m_btnAddDevices.Top = this.Size.Height - heightAdjust;
			m_btnReadDeviceInfoCache.Top = this.Size.Height - heightAdjust;
			m_btnClearTable.Top = this.Size.Height - heightAdjust;
			m_btnStartDetect.Top = this.Size.Height - heightAdjust;

			base.OnResize (e);
		}

		private void m_btnAddDevices_Click(object sender, System.EventArgs e)
		{
			int row;

			m_mainForm.LogUserMessage("DetectForm", "m_btnAddDevices_Click", m_btnAddDevices.Text);

			for (row = 0; row < m_detectedDevicesTable.Rows.Count; row++)
			{
				if (m_detectedDevicesGrid.IsSelected(row))
				{
					DataRow tableRow = m_detectedDevicesTable.Rows[row];
					m_mainForm.AddDevice(
						tableRow["Name"].ToString(),
						"",
						tableRow["Address"].ToString(),
						tableRow["Description"].ToString(),
						"",
						"",
						tableRow["ProgID"].ToString());
				}
			}
		}

		private void m_btnReadDeviceInfoCache_Click(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("DetectForm", "m_btnReadDeviceInfoCache_Click", m_btnReadDeviceInfoCache.Text);

			// Clear the table and refresh it from the DeviceFinder's cache.
			m_detectedDevicesTable.Rows.Clear();

			foreach (Bosch.VideoSDK.Device.DeviceInfo di in m_deviceFinder.DeviceInfos)
				OnDeviceDetected(di);
			
		}

		private void m_btnClearTable_Click(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("DetectForm",	"m_btnClearTable_Click", m_btnClearTable.Text);
			m_detectedDevicesTable.Rows.Clear();
		}

		private void ToggleDetect()
		{
			// Depending on the current state, either start or stop detection
			// and update the button text accordingly.
			if (m_deviceFinder.IsDetecting)
			{
				m_deviceFinder.StopDetect();
				m_btnStartDetect.Text = "StartDetect";
			}
			else
			{
				m_detectedDevicesTable.Rows.Clear();

				m_mainForm.LogMessage("DetectForm",	"m_btnStartDetect_Click", "Calling StartDetect");

				m_deviceFinder.StartDetect(0);
				m_btnStartDetect.Text = "StopDetect";
			}
		}

		private void m_btnStartDetect_Click(object sender, System.EventArgs e)
		{
			m_mainForm.LogUserMessage("DetectForm", "m_btnStartDetect_Click", m_btnStartDetect.Text);
			ToggleDetect();
		}

	}
}
