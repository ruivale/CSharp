using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PanasonicAxTest
{
    public partial class SearchForm : Form
    {
       
        public SearchForm()
        {
            InitializeComponent();
        }

       

        private void SearchForm_Load(object sender, EventArgs e)
        {
            int i = 0;
            for (i = 0; i < 24; i++)
            {
                cbBeginHour.Items.Add(i);
                cbEndHour.Items.Add(i);
                cbBeginMin.Items.Add(i);
                cbEndMin.Items.Add(i);
                cbBeginSec.Items.Add(i);
                cbEndSec.Items.Add(i);
            }

            for (i = 24; i < 61; i++)
            {
                cbBeginMin.Items.Add(i);
                cbEndMin.Items.Add(i);
                cbBeginSec.Items.Add(i);
                cbEndSec.Items.Add(i);
            }
            cbBeginHour.SelectedIndex = 0;
            cbBeginMin.SelectedIndex = 0;
            cbBeginSec.SelectedIndex = 0;
            cbEndHour.SelectedIndex = 0;
            cbEndMin.SelectedIndex = 0;
            cbEndSec.SelectedIndex = 0;

            for(i = 0; i < recEventsListBox.Items.Count ; i++)
                recEventsListBox.SetItemChecked(i,true);

            comboBoxCameras.Items.Add("ALL CAMERAS");
            for (i = 1; i <= 16; i++)
            {
                comboBoxCameras.Items.Add("CAM " + i.ToString());
            }
            comboBoxCameras.SelectedIndex = 0;
            beginDateTimePicker.Value = new DateTime(2006, 1, 1);
            endDateTimePicker.Value = new DateTime(2006, 1, 1);
        }

        private void recEventsAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i;
            for (i = 0; i < recEventsListBox.Items.Count; i++)
                recEventsListBox.SetItemChecked(i, true);
        }

        private void recEventsNone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i;
            for (i = 0; i < recEventsListBox.Items.Count; i++)
                recEventsListBox.SetItemChecked(i, false);
        }

       

        private void btOK_Click(object sender, EventArgs e)
        {
            int targetDisk ; 
            DateTime startTime;
            DateTime endTime;
            string channelFlags = "";
            int emergency,  // emergency recording
                manual,     // manual recording
                schedule,   // schedule recording
                vmd,        // vmd
                trm,        // terminal alarm
                com,        // command alarm
                loss,       // video loss
                text ;      // with/without text

            targetDisk = 0; // Normal disk area
            _targetDisk = targetDisk;

            startTime = beginDateTimePicker.Value;
            startTime = startTime.AddHours(Convert.ToDouble((int)cbBeginHour.SelectedItem)).
                            AddMinutes(Convert.ToDouble((int)cbBeginMin.SelectedItem)).
                            AddSeconds(Convert.ToDouble((int)cbBeginSec.SelectedItem));
            _startTime = startTime;

            endTime = endDateTimePicker.Value;
            endTime = endTime.AddHours(Convert.ToDouble((int)cbEndHour.SelectedItem)).
                    AddMinutes(Convert.ToDouble((int)cbEndMin.SelectedItem)).
                    AddSeconds(Convert.ToDouble((int)cbEndSec.SelectedItem));
            _endTime = endTime;

            manual  = recEventsListBox.GetItemChecked(0) ? 1 : 0;
            _manual = manual;

            vmd     = recEventsListBox.GetItemChecked(1) ? 1 : 0;
            _vmd = vmd;

            schedule = recEventsListBox.GetItemChecked(2) ? 1 : 0;
            _schedule = schedule;

            trm = recEventsListBox.GetItemChecked(3) ? 1 : 0;
            _trm = trm;

            emergency = recEventsListBox.GetItemChecked(4) ? 1 : 0;
            _emergency = emergency;

            com = recEventsListBox.GetItemChecked(5) ? 1 : 0;
            _com = com;

            loss = recEventsListBox.GetItemChecked(6) ? 1 : 0;
            _videoLoss = loss;

            text = 2; // ignore
            _text = text;

            int i;
            if (comboBoxCameras.SelectedIndex == 0)
                channelFlags = "0000000000000000"; // all 16 cameras
            else
                for (i = 1; i <= 16; i++)
                    channelFlags += comboBoxCameras.SelectedIndex == i ? "1" : "0";
            _channelFlags = channelFlags;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void endDateTimeNow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            endDateTimePicker.Value = currentTime.Date;
            cbEndHour.SelectedItem = currentTime.Hour;
            cbEndMin.SelectedItem = currentTime.Minute;
            cbEndSec.SelectedItem = currentTime.Second;

        }

        public int _targetDisk;
        public int TargetDisk
        {
            get
            {
                return _targetDisk;
            }
        }

        public int _manual;
        public int Manual
        {
            get
            {
                return _manual;
            }
        }

        public int _vmd;
        public int Vmd
        {
            get
            {
                return _vmd;
            }
        }

        public int _schedule;
        public int Schedule
        {
            get
            {
                return _schedule;
            }
        }

        public int _trm;
        public int Trm
        {
            get
            {
                return _trm;
            }
        }

        public int _emergency;
        public int Emergency
        {
            get
            {
                return _emergency;
            }
        }

        public int _com;
        public int Com
        {
            get
            {
                return _com;
            }
        }

        public int _videoLoss;
        public int VideoLoss
        {
            get
            {
                return _videoLoss;
            }
        }

        public int _text;
        public int TextFlag
        {
            get
            {
                return _text;
            }
        }

        public string _channelFlags;
        public string ChannelFlags
        {
            get
            {
                return _channelFlags;
            }
        }

        public DateTime _startTime;
        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }
        }

        public DateTime _endTime;
        public DateTime EndTime
        {
            get
            {
                return _endTime;
            }
        }
    }
}