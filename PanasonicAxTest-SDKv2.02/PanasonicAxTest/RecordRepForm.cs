using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PanasonicAxTest
{
    public partial class RecordRepForm : Form
    {
        private int channelId = -1;
        private string server;
        private int port;
        private string uid;
        private DateTime startTime;

        private FormStatus statusForm;

        enum FormStatus
        {
            Playing,
            Paused
        }

        private void ActualizaForm(FormStatus status)
        {
            statusForm = status;
            switch (statusForm)
            {
                case FormStatus.Playing:
                    btPhoto.Enabled = true;
                    btFastRewind.Enabled = true;
                    btPrevFrame.Enabled = false;
                    btPlayBackward.Enabled = true;
                    btPause.Enabled = true;
                    btPlayForward.Enabled = true;
                    btNextFrame.Enabled = false;
                    btFastForward.Enabled = true;
                    break;

                case FormStatus.Paused:
                    btPhoto.Enabled = true;
                    btFastRewind.Enabled = false;
                    btPrevFrame.Enabled = true;
                    btPlayBackward.Enabled = true;
                    btPause.Enabled = false;
                    btPlayForward.Enabled = true;
                    btNextFrame.Enabled = true;
                    btFastForward.Enabled = false;
                    break;
            }
        }

        public RecordRepForm()
        {
            InitializeComponent();
        }

        public RecordRepForm(string server, int port, string cUID, int chId, DateTime sTime)
        {
            InitializeComponent();
            this.server = server;
            this.port = port;
            channelId = chId;
            uid = cUID;
            startTime = sTime;
        }

        private void RecordRepForm_Load(object sender, EventArgs e)
        {
           
            
        }

        private void RecordRepForm_Shown(object sender, EventArgs e)
        {
            recCtl.HttpURL = server;
            recCtl.HttpPort = port;
            recCtl.RefreshInterval = 500;
            recCtl.OpenHttp();
            recCtl.SelectNet();
            recCtl.CameraChannel = channelId;

            recCtl.PlaybackByTime(startTime);
            repTimer.Enabled = true;
            ActualizaForm(FormStatus.Playing);
        }

        private void RecordRepForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            repTimer.Enabled = false;
            recCtl.Stop();
            recCtl.CloseHttp();
        }

        private void recCtl_Error(object sender, AxHD300SDKCONTROLLERLib._DHD300SDKControllerEvents_ErrorEvent e)
        {
            int erro = e.number;
            string desc = e.description;
        }

        private void btFastRewind_Click(object sender, EventArgs e)
        {
            recCtl.Rewind();         
        }

        private void btPrevFrame_Click(object sender, EventArgs e)
        {
            recCtl.PreviousImage();
        }

        private void btPlayBackward_Click(object sender, EventArgs e)
        {
            recCtl.Backward();
            ActualizaForm(FormStatus.Playing);
        }

        private void btPause_Click(object sender, EventArgs e)
        {
            recCtl.Pause();
            ActualizaForm(FormStatus.Paused);
        }

        private void btPlayForward_Click(object sender, EventArgs e)
        {
            recCtl.Playback();
            ActualizaForm(FormStatus.Playing);
        }

        private void btNextFrame_Click(object sender, EventArgs e)
        {
            recCtl.NextImage();
        }

        private void btFastForward_Click(object sender, EventArgs e)
        {
            recCtl.FastForward();
        }

        private void btPhoto_Click(object sender, EventArgs e)
        {
            if (saveImageDlg.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveImageDlg.FileName;
                recCtl.SaveImage(filePath);
            }
        }

        private void repTimer_Tick(object sender, EventArgs e)
        {
            string camName = recCtl.CameraName;

            lblCamNo.Text = camName != "" ? camName : recCtl.CameraChannel.ToString() ;
            lblCamNo.Text += " Speed:"+recCtl.NetPlaySpeed.ToString();
            lblTime.Text = recCtl.FrameDate.ToString();

        }
    }
}