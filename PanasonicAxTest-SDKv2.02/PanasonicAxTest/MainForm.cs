using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace PanasonicAxTest
{
    public partial class MainForm : Form
    {
        private int uid = -1;
        private string server = "";
        private string port = "";
        private string screen = "";

        
        public MainForm()
        {
            InitializeComponent();
        }

        
        /*
         * Login
         */
        private void button2_Click(object sender, EventArgs e)
        {
            btLogin.Enabled = false;
            server = txtServerHost.Text;
            int myPort = 0;
            try
            {
                int.TryParse(txtServerPort.Text, out myPort);
            }
            catch { myPort = 80; }
            port = myPort.ToString();
            recCtl.HttpPort = myPort;
            recCtl.HttpURL = server;

            recCtl.OpenHttp();

            lblUid.Text = recCtl.UID;
            uid = int.Parse(recCtl.UID);
            mainTab.Enabled = true;
            btLogout.Enabled = true;

        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            recCtl.BackColor = Color.Black;
            
        }
   
  /// <summary>
  /// Inicia a reprodução de uma camara
  /// </summary>
  /// <param name="nCamera">Nº da camara. Entre 1 e 16</param>
        private void startCamera(int nCamera)
        {
            displayTimer.Enabled = false;
            
            recCtl.CameraChannel = nCamera;

            recCtl.SelectLive();

            recCtl.Playback();

            
            displayTimer.Enabled = true;

        }

        /// <summary>
        /// Para a reprodução de video em tempo real
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btStopLive_Click(object sender, EventArgs e)
        {
            if (displayTimer.Enabled)
            {
                recCtl.Stop();
                displayTimer.Enabled = false;
            }
        }

        private void camPos1_Click(object sender, EventArgs e)
        {
            startCamera(1);
        }

        private void camPos2_Click(object sender, EventArgs e)
        {
            startCamera(2);
        }

        private void camPos3_Click(object sender, EventArgs e)
        {
            startCamera(3);
        }

        private void camPos4_Click(object sender, EventArgs e)
        {
            startCamera(4);
        }

        private void camPos5_Click(object sender, EventArgs e)
        {
            startCamera(5);
        }

        private void camPos6_Click(object sender, EventArgs e)
        {
            startCamera(6);
        }

        private void camPos7_Click(object sender, EventArgs e)
        {
            startCamera(7);
        }

        private void camPos8_Click(object sender, EventArgs e)
        {
            startCamera(8);
        }

        private void camPos9_Click(object sender, EventArgs e)
        {
            startCamera(9);
        }

        private void camPos10_Click(object sender, EventArgs e)
        {
            startCamera(10);
        }

        private void camPos11_Click(object sender, EventArgs e)
        {
            startCamera(11);
        }

        private void camPos12_Click(object sender, EventArgs e)
        {
            startCamera(12);
        }

        private void camPos13_Click(object sender, EventArgs e)
        {
            startCamera(13);
        }

        private void camPos14_Click(object sender, EventArgs e)
        {
            startCamera(14);
        }

        private void camPos15_Click(object sender, EventArgs e)
        {
            startCamera(15);
        }

        private void camPos16_Click(object sender, EventArgs e)
        {
            startCamera(16);
        }


        private void displayTimer_Tick(object sender, EventArgs e)
        {
            string camName = recCtl.CameraName;

            lblCamNo.Text = camName != "" ? camName : screen;
            lblTime.Text = recCtl.FrameDate.ToString();
        }

        private void mainTab_Deselected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0: //Live Video
                    //recCtl.Stop();
                    
                    screen = "";
                    break;

            }
        }

        
        private void mainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btGetRecordings_Click(object sender, EventArgs e)
        {
            //recCtl.GetSearchResult(0);
            
            btGetRecordings.Enabled = false;
            btSearch.Enabled = false;
            getRecordsProgress.Value = 0;
            
            
            bWorkerGetRecords.RunWorkerAsync("ClearFirst");

        }
        
        private void btSearch_Click(object sender, EventArgs e)
        {
            SearchForm mySearchForm = new SearchForm();

            if (mySearchForm.ShowDialog() == DialogResult.OK)
            {

                /***/
                recCtl.SearchEVENT( mySearchForm.TargetDisk, 
                                    mySearchForm.StartTime, 
                                    mySearchForm.EndTime,
                                    mySearchForm.ChannelFlags, 
                                    mySearchForm.Emergency, 
                                    mySearchForm.Manual,
                                    mySearchForm.Schedule, 
                                    mySearchForm.Vmd, 
                                    mySearchForm.Trm, 
                                    mySearchForm.Com, 
                                    mySearchForm.VideoLoss,
                                    mySearchForm.TextFlag);
                /**/

                
                /***
                string strUID = uid.ToString();
                string strTempParam = getTempParam();

                // http://172.18.56.69:80/cgi-bin/disksel.cgi?UID=19344&DISKSEL=0&TEMP=1194272040312) -> 200.
                string strURL = "http://" + server + ":" + port + "/cgi-bin/disksel.cgi?UID=" + strUID + "&DISKSEL=0" + strTempParam;
                MessageBox.Show(strURL);
                execHttpRequest(strURL);

                // http://172.18.56.69:80/cgi-bin/search.cgi?UID=19344&KIND=EVENT&STARTTIME=060101000001&ENDTIME=071105141400&CAM=1000000000000000&EMERGENCY=ON&MANUAL=ON&SCHEDULE=ON&VMD=ON&TRM=ON&COM=ON&LOSS=ON&TEXT=ON&TEMP=1194272040515) -> 200.
                strURL = "http://" + server + ":" + port + "/cgi-bin/search.cgi?UID=" + strUID + "&KIND=EVENT&STARTTIME=070101000001&ENDTIME=071105141400&CAM=1110000000000000&EMERGENCY=ON&MANUAL=ON&SCHEDULE=ON&VMD=ON&TRM=ON&COM=ON&LOSS=ON&TEXT=OFF" + strTempParam;
                MessageBox.Show(strURL);
                execHttpRequest(strURL);
                
                // http://172.18.56.69:80/cgi-bin/search.cgi?UID=19344&OPERATE=1&HTML=sdk_searchstat.html&TEMP=1194272040703) -> 200.
                strURL = "http://" + server + ":" + port + "/cgi-bin/search.cgi?UID=" + strUID + "&OPERATE=1&HTML=sdk_searchstat.html" + strTempParam;
                MessageBox.Show(strURL);
                execHttpRequest(strURL);
                /**/


                btGetRecordings.Enabled = false;
                btSearch.Enabled = false;
                getRecordsProgress.Value = 0;

                bWorkerGetRecords.RunWorkerAsync();
            }
            

            
        }

        /// <summary>
        /// Converte o formato data YYMMDDHHMMSS em YYYY/MM/DD HH:MM:SS
        /// </summary>
        /// <param name="strTimef">Data a converter</param>
        /// <returns>Data convertida</returns>
        private string RetTimefToDateTime(string strTimef)
        {
            string strRet;
            if (strTimef.Length < 12)
                return "";
            strRet = "20" + strTimef.Substring(0, 2) + "/";
            strRet += strTimef.Substring(2, 2) + "/";
            strRet += strTimef.Substring(4, 2) + " ";
            strRet += strTimef.Substring(6, 2) + ":";
            strRet += strTimef.Substring(8, 2) + ":";
            strRet += strTimef.Substring(10, 2);

            return strRet;
        }

        /// <summary>
        /// Recolhe as gravações do gravador baseadas na última procura efectuada
        /// Esta função o controlo ActiveX
        /// </summary>
        /// <returns>Retorna um DataTable com as gravações</returns>
        private RecordingsDataSet.RecordingsDataTable getRecordingsInfo()
        {
            RecordingsDataSet.RecordingsDataTable newDT = new RecordingsDataSet.RecordingsDataTable();
            List<string> framesTime = new List<string>();
            List<int> framesNumber = new List<int>();
            List<int> camerasNumber = new List<int>();
            List<string> alarms = new List<string>();
            List<int> recordsNumber = new List<int>();
            List<string> descriptions = new List<string>();
            recCtl.GetSearchResult(3); // Beginning 
            int numOfHit = recCtl.NumOfHit;
            int currentRecordings = 0;
            bool hasMoreRecordings = true;

            if (numOfHit == 0)
            {
                bWorkerGetRecords.ReportProgress(100);
                return newDT;
            }
            // 071011113616,07,2,LOSS,0,952,0
            while (hasMoreRecordings)
            {
                string recordings = recCtl.ResultList;
                TextReader recordsStream = new StringReader(recordings);

                while (true)
                {
                    string lineRecord = "";
                    try
                    {
                        lineRecord = recordsStream.ReadLine();
                    }
                    catch { lineRecord = ""; }
                    if (lineRecord == null || lineRecord == "")
                        break;
                    string[] recordFields = lineRecord.Split(',');

                    int recordNumber = -1;
                    try
                    {
                        if(recordFields[5] != "") 
                        int.TryParse(recordFields[5], out recordNumber);
                    }
                    catch { recordNumber = -1; }

                    if (recordNumber == 0)
                        recordNumber=0;

                    if (recordNumber >= 0 /*&& !recordsNumber.Contains(recordNumber)*/)
                    {
                        recordsNumber.Add(recordNumber);
                        currentRecordings++;
                    }
                    else
                        continue;

                    
                    framesTime.Add(RetTimefToDateTime(recordFields[0]));

                    int frameNumber;
                    try
                    {
                        int.TryParse(recordFields[1], out frameNumber);
                    }
                    catch { frameNumber = 0; }
                    framesNumber.Add(frameNumber);

                    int cameraNumber;
                    try
                    {
                        int.TryParse(recordFields[2], out cameraNumber);
                    }
                    catch { cameraNumber = -1; }
                    camerasNumber.Add(cameraNumber);

                    alarms.Add(recordFields[3]);

                    int hasText;
                    try
                    {
                        int.TryParse(recordFields[4], out hasText);
                    }
                    catch { hasText = -1; }

                    descriptions.Add(hasText == 0 ? "" : recordFields[4]);

                    
                }

                double racio = (double)currentRecordings / (double)numOfHit;
                int progress = (int)(racio * 100);
                bWorkerGetRecords.ReportProgress(progress > 100 ? 100 : progress);
                hasMoreRecordings = currentRecordings < numOfHit;

                if(hasMoreRecordings) recCtl.GetSearchResult(1); // Next Page
                System.Threading.Thread.Sleep(1000);
            }

            int i;
            for (i = 0; i < currentRecordings; i++)
            {
                 
                        newDT.AddRecordingsRow(recordsNumber[i], framesTime[i], framesNumber[i],
                            camerasNumber[i], alarms[i], descriptions[i]);
                
            }            
            
            return newDT;
        }

        /// <summary>
        /// Executado pela thread criada pelo BackgroundWorker.
        /// Usa a função getRecordingsInfoNoAx() para recolher as gravações
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bWorkerGetRecords_DoWork(object sender, DoWorkEventArgs e)
        {
            RecordingsDataSet.RecordingsDataTable records = null;
            object arg = e.Argument;
            if (arg is string)
            {
                string str = (string)arg;
                if(str == "ClearFirst")
                    execHttpRequest(makeSearchOpUrl(SearchOperation.ClearSearch));
            }

            records = getRecordingsInfoNoAx();
            //records = getRecordingsInfo();
            e.Result = records;
        }

        /// <summary>
        /// Altera o valor da progressBar durante a recolha das gravações
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bWorkerGetRecords_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            getRecordsProgress.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Executado quando termina a recolha das gravações
        /// Atribui a DataTable à DataGrid para apresentar os dados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bWorkerGetRecords_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            RecordingsDataSet.RecordingsDataTable records = (RecordingsDataSet.RecordingsDataTable)e.Result;


            try
            {
                recordsDataGrid.DataSource = records;
                recordsDataGrid.Sort(recordsDataGrid.Columns[0], ListSortDirection.Descending);
            }
            catch { }
            btGetRecordings.Enabled = true;
            
            btSearch.Enabled = true;
        }

        private void recCtl_Error(object sender, AxHD300SDKCONTROLLERLib._DHD300SDKControllerEvents_ErrorEvent e)
        {
            int error = e.number;
            string desc = e.description;
        }

        /// <summary>
        /// Recolhe as gravações sem usar o controlo ActiveX, apenas executando as CGI's
        /// </summary>
        /// <returns>DataTable com as gravações</returns>
        private RecordingsDataSet.RecordingsDataTable getRecordingsInfoNoAx()
        {

            RecordingsDataSet.RecordingsDataTable newDT = new RecordingsDataSet.RecordingsDataTable();
            List<string> framesTime = new List<string>();
            List<int> framesNumber = new List<int>();
            List<int> camerasNumber = new List<int>();
            List<string> isAlarmed = new List<string>();
            List<int> recordsNumber = new List<int>();
            List<string> descriptions = new List<string>();
            int recordingsTotalNumber = -1;
            int currentRecordings = 0;
            bool recTotalNumberKnown = false;
            bool hasMoreRecordings = true;




           
            while (hasMoreRecordings)
            {

                //MessageBox.Show(makeSearchOpUrl(SearchOperation.GetCurrentPage));                

                StreamReader content = execHttpRequestToStream(makeSearchOpUrl(SearchOperation.GetCurrentPage));
                while (!content.EndOfStream)
                {
                    string line = content.ReadLine();

                    if (line.Contains("var mstrFrameTime"))
                    {
                        //MessageBox.Show("var mstrFrameTime: " + line + ".");

                        string lineToken = line.Split('(')[1];
                        string arrayToken = lineToken.Split(')')[0];
                        foreach (string timeStr in arrayToken.Split(','))
                        {
                            string time = timeStr.Trim().Substring(1, timeStr.Length - 2);

                            //MessageBox.Show("Time: " + time + ". RetTimefToDateTime(time): " + RetTimefToDateTime(time) + ".");

                            framesTime.Add(RetTimefToDateTime(time));

                        }
                    }

                    if (line.Contains("var mstrFrameNo"))
                    {
                        
                        //MessageBox.Show("var mstrFrameNo: "+line+".");

                        string lineToken = line.Split('(')[1];
                        string arrayToken = lineToken.Split(')')[0];
                        foreach (string frameNoStr in arrayToken.Split(','))
                        {
                            int frameNo;
                            try
                            {
                                int.TryParse(frameNoStr.Trim().Substring(1, frameNoStr.Length - 2), out frameNo);
                            }
                            catch
                            {
                                frameNo = 0;
                            }
                            framesNumber.Add(frameNo);

                        }
                    }

                    if (line.Contains("var mstrCameraNo"))
                    {

                        //MessageBox.Show("var mstrCameraNo: " + line + ".");

                        string lineToken = line.Split('(')[1];
                        string arrayToken = lineToken.Split(')')[0];
                        foreach (string camNoStr in arrayToken.Split(','))
                        {
                            int camNo;
                            try
                            {
                                int.TryParse(camNoStr.Trim().Substring(1, camNoStr.Length - 2), out camNo);
                            }
                            catch
                            {
                                camNo = 0;
                            }
                            camerasNumber.Add(camNo);

                        }
                    }

                    if (line.Contains("var mstrTrigger"))
                    {

                        //MessageBox.Show("var mstrTrigger: " + line + ".");

                        string lineToken = line.Split('(')[1];
                        string arrayToken = lineToken.Split(')')[0];
                        foreach (string alarmedStr in arrayToken.Split(','))
                        {
                            string alarmed = alarmedStr.Trim().Substring(1, alarmedStr.Length - 2);
                            isAlarmed.Add(alarmed);

                        }
                    }

                    if (line.Contains("var mstrRecordNo"))
                    {

                        //MessageBox.Show("var mstrRecordNo: " + line + ".");

                        string lineToken = line.Split('(')[1];
                        string arrayToken = lineToken.Split(')')[0];
                        foreach (string recordNoStr in arrayToken.Split(','))
                        {
                            int recordNo;
                            try
                            {
                                string recNo = recordNoStr.Trim().Substring(1, recordNoStr.Length - 2);
                                if (recNo != "")
                                {
                                    int.TryParse(recNo, out recordNo);
                                    recordsNumber.Add(recordNo);
                                    currentRecordings++;
                                }
                            }
                            catch
                            {

                            }

                        }
                    }

                    if (line.Contains("var mstrText"))
                    {

                        //MessageBox.Show("var mstrText: " + line + ".");

                        string lineToken = line.Split('(')[1];
                        string arrayToken = lineToken.Split(')')[0];
                        foreach (string descStr in arrayToken.Split(','))
                        {
                            string desc = descStr.Trim().Substring(1, descStr.Length - 2);
                            descriptions.Add(desc);
                        }
                    }

 
                    /**/
                    if (!recTotalNumberKnown && line.Contains("function Constructor()"))
                    {

                        //MessageBox.Show("function Constructor(): " + line + ".");

                        while (!content.EndOfStream)
                        {
                            string functionLine = content.ReadLine();

                            if (functionLine.Contains("SetRecordNum"))
                            {

                                MessageBox.Show("SetRecordNum: " + functionLine + ".");

                                string totalNumber = functionLine.Split('"')[1];
                                recordingsTotalNumber = int.Parse(totalNumber);
                                recTotalNumberKnown = true;

                                break;
                            }
                        }
                    }
                    /**/

                }

                //MessageBox.Show("recordingsTotalNumber: " + recordingsTotalNumber + ".");

                if (recordingsTotalNumber == 0)
                {
                    bWorkerGetRecords.ReportProgress(100);
                    return newDT;
                }
                hasMoreRecordings = currentRecordings < recordingsTotalNumber;
                double racio = (double)currentRecordings / (double)recordingsTotalNumber;
                int progress = (int)(racio * 100);
                bWorkerGetRecords.ReportProgress(progress > 100 ? 100 : progress);
                //getRecordsProgress.Value = progress > 100 ? 100 : progress;
                content.Close();
                if (hasMoreRecordings)
                {

                    execHttpRequest(makeSearchOpUrl(SearchOperation.NextPage));

                    //waitTime(1000);
                   // timeOutFactor += 1;
                }
            }

            int i = 0;
            for (i = 0; i < currentRecordings; i++)
                newDT.AddRecordingsRow(recordsNumber[i], framesTime[i], framesNumber[i], camerasNumber[i],
                    isAlarmed[i], descriptions[i]);


            return newDT;
        }

        /// <summary>
        /// Cria e executa um request Web ignorando o seu resultado
        /// </summary>
        /// <param name="url"></param>
        private void execHttpRequest(string url)
        {
            HttpWebRequest reqt = (HttpWebRequest)WebRequest.Create(url);
           
            HttpWebResponse res = (HttpWebResponse)reqt.GetResponse();
            res.Close();
        }

        /// <summary>
        /// Cria e executa um request Web
        /// </summary>
        /// <param name="url"></param>
        /// <returns>StreamReader a apontar para a resposta</returns>
        private StreamReader execHttpRequestToStream(string url)
        {
            HttpWebRequest reqt = (HttpWebRequest)WebRequest.Create(url);
            
            HttpWebResponse res = null;


            res = (HttpWebResponse)reqt.GetResponse();

            Stream contentStream = res.GetResponseStream();
            StreamReader content = new StreamReader(contentStream);

            return content;
        }

        /// <summary>
        /// Cria o parametro Temp a passar para a CGI.
        /// O valor tempo que retorna são os milissegundos desde 1970
        /// </summary>
        /// <returns>Parametro da query string: &TEMP=mmmmmmm</returns>
        private string getTempParam()
        {
            DateTime currDate = DateTime.Now.ToUniversalTime();
            long nanoTime = currDate.ToFileTimeUtc();
            long nano1970 = new DateTime(1970, 1, 1).ToFileTimeUtc();
            long tempValue = nanoTime - nano1970;
            tempValue = (long)Math.Round(tempValue * 0.0001);
            return "&TEMP=" + tempValue.ToString();

        }

        /// <summary>
        /// Converte o formato Data YYYY/MM/DD HH:MM:SS em YYMMDDHHMMSS
        /// </summary>
        /// <param name="strAxDate"></param>
        /// <returns></returns>
        private string strDateToStr(string strAxDate)
        {
            string strDate = "";
            // 30-10-1899 0:00:00
            string yy = strAxDate.Substring(6, 4);
            string mm = strAxDate.Substring(3, 2);
            string dd = strAxDate.Substring(0, 2);
            string hh = strAxDate.Substring(11, 2);
            string min = strAxDate.Substring(13, 2);
            string sec = strAxDate.Substring(16, 2);

            strDate = yy + mm + dd + hh + min + sec;

            return strDate;
        }

        /// <summary>
        /// Cria o parametro TIMEF das CGI's. Este parametro é construido a partir do tempo e da frame
        /// que está a ser reproduzido. Se nada estiver a ser reproduzido, usa-se o tempo actual e a frame
        /// como o número 1.
        /// </summary>
        /// <returns>Parametro da query string &TIMEF=xxxxxxxxx</returns>
        private string retTimeF()
        {
            string strInDate = recCtl.FrameDate.ToString(); 
            string ret = "";
            if (strInDate != "")
            {
                ret = strDateToStr(strInDate);
                ret += recCtl.FrameNO;
                ret = "&TIMEF=" + ret;
            }
            else
            {
                DateTime currDate = DateTime.Now.ToUniversalTime();
                strInDate = currDate.Year + "/" + currDate.Month.ToString().PadLeft(2, '0') + "/" +
                    currDate.Day.ToString().PadLeft(2, '0') + " " + currDate.Hour.ToString().PadLeft(2, '0') + ":" +
                    currDate.Minute.ToString().PadLeft(2, '0') + ":" + currDate.Second.ToString().PadLeft(2, '0');
                ret = strDateToStr(strInDate);
                ret += "1";
                ret = "&TIMEF=" + ret;

                MessageBox.Show("recCtl.FrameDate.ToString() IS \"\"");

            }

            return ret;
        }

        /// <summary>
        /// Enumeração que representa as operações de procura a recolha de gravações
        /// </summary>
        enum SearchOperation
        {
            FirstPage,
            NextPage,
            PrevPage,
            GetCurrentPage,
            ClearSearch
        }

        /// <summary>
        /// Função que cria as URL's de acordo a operação requerida.
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        private string makeSearchOpUrl(SearchOperation op)
        {
            string strUrl = "";

            switch (op)
            {
                case SearchOperation.FirstPage:
                case SearchOperation.GetCurrentPage:
                case SearchOperation.NextPage:
                case SearchOperation.PrevPage:
                    strUrl = "http://" + server + ":" + port + "/cgi-bin/list.cgi?UID=" + uid.ToString();
                    break;

                case SearchOperation.ClearSearch:

                    MessageBox.Show(recCtl.FrameDate.ToString() + " frmnbr: " + recCtl.FrameNO);

                    strUrl = "http://" + server + ":" + port + "/cgi-bin/search.cgi?UID=" + uid.ToString() +
                        "&KIND=CLEAR&PAGE=CURRENT" + retTimeF();

                    MessageBox.Show(strUrl);


                    break;
            }



            switch (op)
            {
                case SearchOperation.FirstPage:
                    strUrl += "&PAGE=TOP&HTML=01_07_030.html";
                    break;

                case SearchOperation.GetCurrentPage:
                    strUrl += "&HTML=01_07_010.html";
                    break;

                case SearchOperation.NextPage:
                    strUrl += "&PAGE=PREV&OPERATE=1&HTML=01_07_030.html";
                    break;

                case SearchOperation.PrevPage:
                    strUrl += "&PAGE=NEXT&OPERATE=1&HTML=01_07_030.html";
                    break;

                case SearchOperation.ClearSearch:
                    strUrl += "&HTML=01_07_030.html";
                    
                    MessageBox.Show(strUrl);

                    break;

            }

            strUrl += getTempParam();

          
            return strUrl;
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            recCtl.CloseHttp();
            mainTab.Enabled = false;
            btLogout.Enabled = false;
            btLogin.Enabled = true;
        }

        

        private void recordsDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row < 0) return;
            RecordingsDataSet.RecordingsRow selectedRow = (RecordingsDataSet.RecordingsRow)((DataRowView) recordsDataGrid.Rows[row].DataBoundItem).Row ;
            int camId = selectedRow.CameraNo ;
            DateTime startTime = Convert.ToDateTime(selectedRow.FrameTime);
            
         
            /***/
            RecordRepForm myRepForm = new RecordRepForm(recCtl.HttpURL, recCtl.HttpPort, recCtl.UID, camId, startTime);
            myRepForm.Owner = this;
            myRepForm.Show();
            /***/
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            recCtl.CloseHttp();
        }

        /*
         * 
         * 
         *  Monitor / Commands
         * 
         * 
         * 
         */

        private bool connected = false;
        private int monitorUID = -1;

        private bool recorderUp = false;

        /// <summary>
        /// Start / Stop monitor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btMonitorToggle_Click(object sender, EventArgs e)
        {
            btMonitorToggle.Enabled = false;
            if (!connected)
            {
                server = txtServerHost.Text;
                port = txtServerPort.Text;
               
                    executeHttpOperation(Operation.Login,
                        "http://" + server + ":" + port + "/cgi-bin/start.cgi?UID=-1" + getTempParam());
              
                    
            }
            else
            {
                btMonitorToggle.Enabled = false;
                statusTimer.Enabled = false;
                executeHttpOperation(Operation.Logout,
                    "http://" + server + ":" + port + "/cgi-bin/logout.cgi?UID=" + monitorUID.ToString() + getTempParam());
                

            }
        }

        
        private StreamReader execHttpRequestToStreamMonitor(BackgroundWorker myWorker, string url)
        {
            HttpWebRequest reqt = (HttpWebRequest)WebRequest.Create(url);
            /*reqt.KeepAlive = true;
            reqt.Headers["UserAgent"] = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.30)";
            reqt.Timeout = 100000;
            */
            reqt.Timeout = 10000;
            HttpWebResponse res = null;
            StreamReader content = null;

            try
            {

                res = (HttpWebResponse)reqt.GetResponse();
                
                    if (recorderUp == false)
                    {
                        //alarmsListBox.Items.Add(DateTime.Now.ToString() + " :: Recorder is up");
                        myWorker.ReportProgress(0, DateTime.Now.ToString() + " :: Recorder is up");
                        recorderUp = true;
                    }
                
                Stream contentStream = res.GetResponseStream();
                content = new StreamReader(contentStream);
            }
            catch
            {
                
                    if (recorderUp || firstGetStatus)
                    {
                        recorderUp = false;
                        //alarmsListBox.Items.Add(DateTime.Now.ToString() + " :: Recorder is down");
                        myWorker.ReportProgress(0, DateTime.Now.ToString() + " :: Recorder is down");
                    }
                
            }
            finally
            {
                
                    if (recorderUp && res != null && res.StatusCode != HttpStatusCode.OK)
                        content = null;
                
            }



            return content;
        }

        private bool execHttpRequestMonitor(BackgroundWorker myWorker, string url)
        {
            bool ok = false;
            HttpWebRequest reqt = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse res = null;
            reqt.Timeout = 10000;

            try
            {
                res = (HttpWebResponse)reqt.GetResponse();

            }
            catch {
               
                    if (recorderUp || firstGetStatus)
                    {
                        recorderUp = false;
                        //alarmsListBox.Items.Add(DateTime.Now.ToString() + " :: Recorder is down");
                        myWorker.ReportProgress(0, DateTime.Now.ToString() + " :: Recorder is down");
                    }
                
            }
            if (res != null && res.StatusCode == HttpStatusCode.OK)
            {
                
                    if (recorderUp == false)
                    {
                        //alarmsListBox.Items.Add(DateTime.Now.ToString() + " :: Recorder is up");
                        myWorker.ReportProgress(0, DateTime.Now.ToString() + " :: Recorder is up");
                        recorderUp = true;
                    }
                
                ok = true;
                res.Close();
            }
            
            return ok;
        }

        private int lastAlarmInd;
        private int lastAlarmMsg;
        private int lastAlarmSrc;

        private int sysPSDADR = 0;

        private bool firstGetStatus = true;

        private void statusTimer_Tick(object sender, EventArgs e)
        {
            executeHttpOperation (Operation.Status ,"http://" + server + ":" + port + "/cgi-bin/status.cgi?UID=" + monitorUID.ToString() + "&HTML=sdk_status.html" + getTempParam());
            

        }

        /// <summary>
        /// Cria a string de alarme consoante o código do alarme
        /// </summary>
        /// <returns></returns>
        private string makeAlarmMsgStr()
        {
            string almStr = "";

                switch (lastAlarmMsg)
                {
                    case 0:
                        almStr = "Terminal Alarm: " + lastAlarmSrc.ToString() + "CH";
                        break;

                    /***   Este alarme é detectado pelo pooling do estado das camaras
                    case 1:
                        almStr = "Video Loss Alarm: CAM " + lastAlarmSrc.ToString();
                        break;
                   /***/

                        // Alarme de detecção de movimento
                    /****************************************************************/
                    case 2:
                        almStr = "VMD Alarm: CAM " + lastAlarmSrc.ToString();
                        break;
                    /****************************************************************/

                    case 3:
                        almStr = "Command Alarm: " + lastAlarmSrc.ToString() + "CH";
                        break;

                    case 4:
                        almStr = "Emergency REC has been ocurred";
                        break;

                    case 10:
                        almStr = "Thermal error has been detected.";
                        break;

                    case 11:
                        almStr = "Altered Alarm: " + lastAlarmSrc.ToString() + "CH";
                        break;

                    case 12:
                        almStr = "HDD write error has been detected.";
                        break;

                    case 13:
                        almStr = "HDD SMART warning has been detected.";
                        break;

                    case 14:
                        almStr = "HDD capacity warning has been detected.";
                        break;
            
                    case 15:
                        almStr = "HDD hour meter warning has been detected.";
                        break;

                    case 16:
                        almStr = "Power loss has been detected.";
                        break;

                    case 17:
                        almStr = "HDD has been removed.";
                        break;

                    case 18:
                        almStr = "Video Loss has been occurred.";
                        break;

                    case 19:
                        almStr = "Error has been occurred.";break;

                        // Falta de espaço em disco
                    /****************************************************************/
                    case 20:
                        almStr = "HDD-NML(" + lastAlarmSrc.ToString() + "%) capacity warning has been detected.";
                        break;

                    case 21:
                        almStr = "HDD-EVT(" + lastAlarmSrc.ToString() + "%) capacity warning has been detected.";
                        break;

                    case 22:
                        almStr = "HDD-COPY(" + lastAlarmSrc.ToString() + "%) capacity warning has been detected.";
                        break;
                    
                    case 23:
                        almStr = "COPY1(" + lastAlarmSrc.ToString() + "%) capacity warning has been detected.";
                        break;

                    case 24:
                        almStr = "COPY2(" + lastAlarmSrc.ToString() + "%) capacity warning has been detected.";
                        break;
                    /****************************************************************/
                    case 25:
                        almStr = "FAN Error has been detected.";
                        break;

                    case 26:
                        almStr = "MEDIUM ERROR has been detected.";
                        break;


                        //Discos cheios
                    /****************************************************************/
                    case 27:
                        almStr = "HDD-NML(FULL) capacity warning has been detected.";
                        break;

                    case 28:
                        almStr = "HDD-EVT(FULL) capacity warning has been detected.";
                        break;

                    case 29:almStr = "HDD-COPY(FULL) capacity warning has been detected.";
                        break;

                    case 30:
                        almStr = "COPY1(FULL) capacity warning has been detected.";
                        break;

                    case 31:
                        almStr = "COPY2(FULL) capacity warning has been detected.";
                        break;
                    /****************************************************************/
                    case 32:
                        almStr = "Mirror recovery failure has been occurred.";
                        break;

                    case 33:
                        almStr = "Raid5 recovery failure has been occurred.";
                        break;

                    case 34:
                        almStr = "HDD has been removed.";
                        break;

                    case 35:
                        almStr = "HDD has been removed.";
                        break;

                    case 36:
                        almStr = "HDD 1down has been detected.";
                        break;

               
            }
            if (almStr == "")
                return "";
            else
                return DateTime.Now.ToString() + "::" + almStr;
        }

        private void lblAllCamerasRec_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i;
            for (i = 0; i < camerasListBox.Items.Count; i++)
                camerasListBox.SetItemChecked(i, true);
        }

        private void lblNoCamerasRec_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i;
            for (i = 0; i < camerasListBox.Items.Count; i++)
                camerasListBox.SetItemChecked(i, false);

        }

        private void btStartRec_Click(object sender, EventArgs e)
        {
            //GET /cgi-bin/psdctl.cgi?UID=224&FORMAT=1&TOADR=001&CMD=ZAI&
            //PARAM=%0F%0F%0F%87%0F%0F%0F:01&TEMP=1192538720
            /*
             * %0F%0F%0F<%87%0F%0F%0F> define nº da camara
             *              87 = 1000 0111 -- 1000 camara nº 1 , segunda parte do octeto (0111) é a diferença entre 1111 e 1000,
             *                                0100 camara nº 2                          ou seja, 15 - 8 = 7 (0111)
             *                                0010 camara nº 3
             *                                0001 camara nº 4
             * %0F%0F%0F<%cam[1-4]%cam[5-8]%cam[9-12]%cam[13-16]>
             */
            string strUrl = "";
            /***/
            if (camerasListBox .SelectedIndex != -1)
            {

                strUrl = "http://" + server + ":" + port + "/cgi-bin/psdctl.cgi?UID=" + monitorUID.ToString() +
                 "&FORMAT=2&TOADR="+sysPSDADR.ToString().PadLeft(3,'0')+"&CMD=ZAI&PARAM=%0F%0F%0F"  +
                 getCamaraCode()+ ":01" + getTempParam();

                executeHttpOperation(Operation.StartRecording, strUrl);

            }
              /***/
        }

        /// <summary>
        /// Cria a máscara das camaras a ser passado a cgi.
        /// </summary>
        /// <returns></returns>
        private string getCamaraCode()
        {
            int i = 0;
            int offset = 0;
            int mask = 0;
            mask = 0;
            for (i = 0, offset = 3; i < 16; i += 4, offset--)
            {
                int auxMask = 0;
                auxMask |= (camerasListBox.GetItemChecked(i) ? 1 : 0) << 7;
                auxMask |= (camerasListBox.GetItemChecked(i+1) ? 1 : 0) << 6;
                auxMask |= (camerasListBox.GetItemChecked(i+2) ? 1 : 0) << 5;
                auxMask |= (camerasListBox.GetItemChecked(i+3) ? 1 : 0) << 4;
                auxMask |= (~auxMask >> 4) & 0xF;
                mask |= auxMask << (offset*8);

            }
            string maskStr = "";
            maskStr = String.Format("%{0:X}{1:X}%{2:X}{3:X}%{4:X}{5:X}%{6:X}{7:X}",
                (mask & 0xF0000000) >> 28, (mask & 0xF000000) >> 24, (mask & 0xF00000) >> 20,
                (mask & 0xF0000) >> 16, (mask & 0xF000) >> 12, (mask & 0xF00) >> 8, (mask & 0xF0) >> 4,
                (mask & 0xF));
            return maskStr;
        }

        private void btStopRecAll_Click(object sender, EventArgs e)
        {
            string strUrl = "http://" + server + ":" + port + "/cgi-bin/rec.cgi?UID=" + monitorUID.ToString() +
                        "&REC=OFF" + getTempParam();

            executeHttpOperation(Operation.StopRecording, strUrl);
        }

        private void btAlarmReset_Click(object sender, EventArgs e)
        {
            string strUrl = "http://" + server + ":" + port + "/cgi-bin/alarm.cgi?UID="
                + monitorUID.ToString() + "&CMD=RESET";
            executeHttpOperation(Operation.AlarmReset, strUrl);
        }

       
        private void alarmTimer_Tick(object sender, EventArgs e)
        {
            if (btAlarmReset.ForeColor == Color.FromKnownColor(KnownColor.ControlText))
                btAlarmReset.ForeColor = Color.Red;
            else
                btAlarmReset.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
        }

        private void httpRequestWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            object myArgs = e.Argument;
            StreamReader content = null;
            if(myArgs is string[]){
                string[] args = (string[]) myArgs;
               switch(args.Length)
                {
                   case 0:
                       e.Cancel = true;
                       break;

                   case 1:
                       content = execHttpRequestToStreamMonitor((BackgroundWorker)sender, args[0]);
                       e.Result = content;
                       break;

                   case 2:
                       bool ok = execHttpRequestMonitor((BackgroundWorker)sender, args[0]);
                       e.Cancel = !ok;
                       break;

                }
               
            }
        }

        private void httpRequestWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            alarmsListBox.Items.Add(e.UserState.ToString());
        }

        enum Operation
        {
            Login,
            Logout,
            Status,
            AlarmReset,
            AlarmInformation,
            StartRecording,
            StopRecording,
            ActiveCamerasInformation,
            ChangeMonitorCamera,
            RecorderKeyboardInformation,
            HDDNormalInfo,
            HDDCopyInfo,
            HDDEventInfo,
            DiskCopy1Info,
            DiskCopy2Info
        }

        private void executeHttpOperation(Operation op, string url)
        {

            switch (op)
            {
                case Operation.Login:
                    BackgroundWorker loginWorker = new BackgroundWorker();
                    loginWorker.WorkerReportsProgress = true;
                    loginWorker.DoWork += new DoWorkEventHandler(httpRequestWorker_DoWork);
                    loginWorker.ProgressChanged += new ProgressChangedEventHandler(httpRequestWorker_ProgressChanged);
                    loginWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loginWorker_RunWorkerCompleted);
                    loginWorker.RunWorkerAsync(new string[] { url });
                    break;


                case Operation.Status:
                    BackgroundWorker myhttpRequestWorker = new BackgroundWorker();
                    myhttpRequestWorker.WorkerReportsProgress = true;
                    myhttpRequestWorker.DoWork += new DoWorkEventHandler(httpRequestWorker_DoWork);
                    myhttpRequestWorker.ProgressChanged += new ProgressChangedEventHandler(httpRequestWorker_ProgressChanged);
                    myhttpRequestWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(statusOperationHandling);
                    myhttpRequestWorker.RunWorkerAsync(new string[] { url });
                    break;

                case Operation.AlarmInformation:
                    BackgroundWorker alarmWorker = new BackgroundWorker();
                    alarmWorker.WorkerReportsProgress = true;
                    alarmWorker.DoWork +=new DoWorkEventHandler(httpRequestWorker_DoWork);
                    alarmWorker.ProgressChanged += new ProgressChangedEventHandler(httpRequestWorker_ProgressChanged );
                    alarmWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(alarmInformationOperationHandling);
                    alarmWorker.RunWorkerAsync(new string[] { url });
                    break;

                case Operation.Logout:
                    BackgroundWorker logoutWorker = new BackgroundWorker();
                    logoutWorker.WorkerReportsProgress = true;
                    logoutWorker.DoWork += new DoWorkEventHandler(httpRequestWorker_DoWork);
                    logoutWorker.ProgressChanged += new ProgressChangedEventHandler(httpRequestWorker_ProgressChanged);
                    logoutWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(logoutOperationHandling);
                    logoutWorker.RunWorkerAsync(new string[] { url });
                    break;
                case Operation.AlarmReset:
                case Operation.StartRecording:
                case Operation.StopRecording:
                    BackgroundWorker noHandleWorker = new BackgroundWorker();
                    noHandleWorker.WorkerReportsProgress = true;
                    noHandleWorker.DoWork += new DoWorkEventHandler(httpRequestWorker_DoWork);
                    noHandleWorker.ProgressChanged += new ProgressChangedEventHandler(httpRequestWorker_ProgressChanged);
                    noHandleWorker.RunWorkerAsync(new string[] { url, "NoResponse" });
                    break;

                
                case Operation.ActiveCamerasInformation:
                    BackgroundWorker activeCamerasWorker = new BackgroundWorker();
                    activeCamerasWorker.WorkerReportsProgress = true;
                    activeCamerasWorker.DoWork += new DoWorkEventHandler(httpRequestWorker_DoWork);
                    activeCamerasWorker.ProgressChanged += new ProgressChangedEventHandler(httpRequestWorker_ProgressChanged);
                    activeCamerasWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(activeCamerasInformationHandling);
                    activeCamerasWorker.RunWorkerAsync(new string[] { url });
                    break;

                case Operation.ChangeMonitorCamera:
                    BackgroundWorker changeMonitorWorker = new BackgroundWorker();
                    changeMonitorWorker.WorkerReportsProgress = true;
                    changeMonitorWorker.DoWork += new DoWorkEventHandler(httpRequestWorker_DoWork);
                    changeMonitorWorker.ProgressChanged += new ProgressChangedEventHandler(httpRequestWorker_ProgressChanged);
                    changeMonitorWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(changeMonitorHandling);
                    changeMonitorWorker.RunWorkerAsync(new string[] { url, "NoResponse" });
                    break;

                case Operation.RecorderKeyboardInformation:
                    BackgroundWorker recorderKeyboardWorker = new BackgroundWorker();
                    recorderKeyboardWorker.WorkerReportsProgress = true;
                    recorderKeyboardWorker.DoWork += new DoWorkEventHandler(httpRequestWorker_DoWork);
                    recorderKeyboardWorker.ProgressChanged += new ProgressChangedEventHandler(httpRequestWorker_ProgressChanged);
                    recorderKeyboardWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(receorderKeyboardInfoHandling);
                    recorderKeyboardWorker.RunWorkerAsync(new string[] { url });
                    break;

                case Operation.DiskCopy1Info:
                case Operation.DiskCopy2Info:
                case Operation.HDDCopyInfo:
                case Operation.HDDEventInfo:
                case Operation.HDDNormalInfo:
                    BackgroundWorker diskInfo = new BackgroundWorker();
                    diskInfo.WorkerReportsProgress = true;
                    diskInfo.DoWork += new DoWorkEventHandler(httpRequestWorker_DoWork);
                    diskInfo.ProgressChanged += new ProgressChangedEventHandler(httpRequestWorker_ProgressChanged);
                    diskInfo.RunWorkerCompleted += new RunWorkerCompletedEventHandler(diskInfoHandling);
                    diskInfo.RunWorkerAsync(new string[] { url });
                    break;
            }
            
        }

        void diskInfoHandling(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void receorderKeyboardInfoHandling(object sender, RunWorkerCompletedEventArgs e)
        {
            StreamReader content = (StreamReader)e.Result;
            if (content == null) return;
            if (e.Cancelled) return;
            string statusLine = "";
            int currentCamera = 0;
            while (!content.EndOfStream)
            {
                statusLine = content.ReadLine();
                if (statusLine.Contains("PARAM"))
                {
                    try
                    {
                        statusLine = statusLine.Split(':')[4];
                        statusLine = statusLine.Split(';')[0];
                        currentCamera = int.Parse(statusLine);
                    }
                    catch
                    {
                        alarmsListBox.Items.Add(DateTime.Now.ToString() + ":: Wrong Recorder Keyboard parameter received");
                        currentCamera = 0;
                    }
                    break;
                }
            }
            btCam1.BackColor = currentCamera == 1 ? Color.YellowGreen : Color.Transparent;
            btCam2.BackColor = currentCamera == 2 ? Color.YellowGreen : Color.Transparent;
            btCam3.BackColor = currentCamera == 3 ? Color.YellowGreen : Color.Transparent;
            btCam4.BackColor = currentCamera == 4 ? Color.YellowGreen : Color.Transparent;
            btCam5.BackColor = currentCamera == 5 ? Color.YellowGreen : Color.Transparent;
            btCam6.BackColor = currentCamera == 6 ? Color.YellowGreen : Color.Transparent;
            btCam7.BackColor = currentCamera == 7 ? Color.YellowGreen : Color.Transparent;
            btCam8.BackColor = currentCamera == 8 ? Color.YellowGreen : Color.Transparent;
            btCam9.BackColor = currentCamera == 9 ? Color.YellowGreen : Color.Transparent;
            btCam10.BackColor = currentCamera == 10 ? Color.YellowGreen : Color.Transparent;
            btCam11.BackColor = currentCamera == 11 ? Color.YellowGreen : Color.Transparent;
            btCam12.BackColor = currentCamera == 12 ? Color.YellowGreen : Color.Transparent;
            btCam13.BackColor = currentCamera == 13 ? Color.YellowGreen : Color.Transparent;
            btCam14.BackColor = currentCamera == 14 ? Color.YellowGreen : Color.Transparent;
            btCam15.BackColor = currentCamera == 15 ? Color.YellowGreen : Color.Transparent;
            btCam16.BackColor = currentCamera == 16 ? Color.YellowGreen : Color.Transparent;
        }

        void changeMonitorHandling(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        void logoutOperationHandling(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) return;

            btMonitorToggle.Text = "Start Monitor";
            btMonitorToggle.Enabled = true;
            groupBoxRec.Enabled = false;
            btAlarmReset.Enabled = false;
            connected = false;
            
                firstGetStatus = true;
                recorderUp = false;
            
        }


        /// <summary>
        /// Processamento da resposta do login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void loginWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StreamReader content = (StreamReader)e.Result;
            if (content == null)
            {

                return;
            }


            while (!content.EndOfStream)
            {
                string line = content.ReadLine();
                if (line.Contains("UID="))
                {
                    int offset = line.IndexOf("UID=");
                    string uidAndNextString = line.Substring(offset + 4);
                    string[] tokens = uidAndNextString.Split('&');
                    int cUid = int.Parse(tokens[0]);
                    this.monitorUID = cUid;

                    btMonitorToggle.Text = "Stop Monitor";
                    btMonitorToggle.Enabled = true;
                    connected = true;
                    statusTimer.Enabled = true;
                    break;
                }
            }
        }

        private string lastCamerasState = "";
        private string lastActiveState = "";

        /// <summary>
        /// Processamento do estado das camaras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void activeCamerasInformationHandling(object sender, RunWorkerCompletedEventArgs e)
        {
            StreamReader content = (StreamReader)e.Result;
            if (content == null) return;
            if (e.Cancelled) return;
            string camerasLine = "";
            string myActiveCameras;
            while (!content.EndOfStream)
            {
                camerasLine = content.ReadLine();
                if (camerasLine.Contains("PARAM"))
                {
                    try
                    {

                        camerasLine = camerasLine.Split(':')[3];
                        camerasLine = camerasLine.Split("</pre>".ToCharArray())[0];
                        break;
                    }
                    catch
                    {
                        alarmsListBox.Items.Add(DateTime.Now.ToString() + ":: " + "Wrong Active Cameras Info received");
                        camerasLine = lastCamerasState;
                    }
                }
            }
            if (camerasLine == "" || camerasLine.Length != 16)
            {
                alarmsListBox.Items.Add(DateTime.Now.ToString() + ":: " + "Wrong Active Cameras Info received: empty");
                camerasLine = lastCamerasState;
            }
            myActiveCameras = makeActiveCamerasState();
            if (lastActiveState == "")
                lastActiveState = myActiveCameras;
             
            if (lastCamerasState == "")
                lastCamerasState = "0000000000000000";

            int i;


            //if (camerasLine != myActiveCameras)
            //{
                for (i = 0; i < 16; i++)
                {
                    if (camerasLine[i] != lastCamerasState[i] )                                                                 
                    {
                        if (camerasLine[i] == '0' && myActiveCameras[i] == '1') // Video Loss
                                alarmsListBox.Items.Add(DateTime.Now.ToString() + "::" + " Video Loss: CAM " + (i + 1).ToString());

                        if(camerasLine[i] == '1' && myActiveCameras[i] == '0') // Unexpected Video
                            alarmsListBox.Items.Add(DateTime.Now.ToString() + "::" + " Unexpected Video : CAM " + (i + 1).ToString());

                        if(camerasLine[i] == '1' && myActiveCameras[i] == '1') // Video OK
                            alarmsListBox.Items.Add(DateTime.Now.ToString() + "::" + " Video OK: CAM " + (i + 1).ToString());

                        if(camerasLine[i] == '0' && myActiveCameras[i] == '0') // Unexpected video plugged out
                            alarmsListBox.Items.Add(DateTime.Now.ToString() + "::" + " Unexpected Video OK: CAM " + (i + 1).ToString());

                    }
                    else
                    {
                        if (myActiveCameras[i] != lastActiveState[i])
                        {
                            if (camerasLine[i] == '0')
                            {
                                if (myActiveCameras[i] == '1')
                                { // Configuration Changed: new active camera, but no signal found
                                    alarmsListBox.Items.Add(DateTime.Now.ToString() + "::" + " Video Loss: CAM " + (i + 1).ToString());
                                }
                               

                            }
                            if (camerasLine[i] == '1')
                            {
                                if (myActiveCameras[i] == '0')
                                {  // Camera removed, but still plugged
                                    alarmsListBox.Items.Add(DateTime.Now.ToString() + "::" + " Video Still OK: CAM " + (i + 1).ToString());
                                }
                                else
                                { // New active camera and signal found
                                    alarmsListBox.Items.Add(DateTime.Now.ToString() + "::" + " Video OK: CAM " + (i + 1).ToString());
                                }

                            }
                        }
                    }
                }
            //}

            lastCamerasState = camerasLine;
            lastActiveState = myActiveCameras;

            /***** KEYBOARD INFORMATION *****/
            executeHttpOperation(Operation.RecorderKeyboardInformation, "http://" + server + ":" + port + "/cgi-bin/psdctl.cgi?UID=" + monitorUID.ToString() +
                "&FORMAT=2&TOADR=" + sysPSDADR.ToString().PadLeft(3, '0') + "&CMD=QSR&PARAM=" + getTempParam());

            ((BackgroundWorker)sender).Dispose();
        }

        private string makeActiveCamerasState()
        {
            string cameraState = "";
            int i;
            for (i = 0; i < 16; i++)
                cameraState += activeCamerasListBox.GetItemChecked(i) ? "1" : "0";

            return cameraState;
            
        }

        /// <summary>
        /// Processamento do estado do alarme geral
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void alarmInformationOperationHandling(object sender, RunWorkerCompletedEventArgs e)
        {
            StreamReader alarmInfo = (StreamReader)e.Result;
            if (e.Cancelled) return;
            if (alarmInfo != null)
            {
                string alarmLine = "";
                while (!alarmInfo.EndOfStream)
                {
                    alarmLine = alarmInfo.ReadLine();
                    if (alarmLine.Contains("PARAM"))
                    {
                        alarmLine = alarmLine.Split(':')[1];
                        alarmLine = alarmLine.Split("</pre>".ToCharArray())[0];
                        break;
                    }
                }
                alarmInfo.Close();

                int alarmValue = -1;
                try
                {
                    int.TryParse(alarmLine, out alarmValue);
                    switch (alarmValue)
                    {
                        case 0: // No Alarm
                            alarmTimer.Enabled = false;
                            btAlarmReset.Enabled = false;
                            break;

                        case 1: // Alarm End : no blinking
                            alarmTimer.Enabled = false;
                            btAlarmReset.ForeColor = Color.Red;
                            btAlarmReset.Enabled = true;
                            break;

                        case 2:
                            btAlarmReset.Enabled = true;
                            alarmTimer.Enabled = true;
                            break;
                    }
                }
                catch
                {
                    alarmsListBox.Items.Add(DateTime.Now.ToString() + "::" + "Error on getting alarm status");
                }
                
            }
            /***** CAMERAS INFORMATION *****/
            executeHttpOperation(Operation.ActiveCamerasInformation, "http://" + server + ":" + port + "/cgi-bin/psdctl.cgi?UID=" + monitorUID.ToString() +
                "&FORMAT=2&TOADR=" + sysPSDADR.ToString().PadLeft(3, '0') + "&CMD=QSY&PARAM=00001:00016" + getTempParam());


            ((BackgroundWorker)sender).Dispose();
        }

        /// <summary>
        /// Processamento da resposta de Status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void statusOperationHandling(object sender, RunWorkerCompletedEventArgs e)
        {
            StreamReader content = (StreamReader)e.Result;
            statusListBox.Items.Clear();
            if (e.Cancelled) return;
            if (content == null)
            {
                return;
            }
            string alarmMsgStr = "";
            bool buildAlarmMsg = false;

            string fileName = "";
            if (!content.EndOfStream)
                fileName = content.ReadLine();
            if (fileName != "FILENAME=sdk_status.html")
            {

                btMonitorToggle.Enabled = false;
                statusTimer.Enabled = false;
                btMonitorToggle.Text = "Start Monitor";
                btMonitorToggle.Enabled = true;
                groupBoxRec.Enabled = false;
                btAlarmReset.Enabled = false;
                
                connected = false;
                
                    firstGetStatus = true;
                    recorderUp = false;
               
                alarmsListBox.Items.Add(DateTime.Now.ToString() + " :: Recorder is down");
                btMonitorToggle.PerformClick();
                return;
            }

            while (!content.EndOfStream)
            {
                string line = content.ReadLine();

                statusListBox.Items.Add(line);

                if (line.StartsWith("SYSPSDADDR:"))
                {
                    int value = int.Parse(line.Substring(11));
                    sysPSDADR = value;
                    if (firstGetStatus)
                        groupBoxRec.Enabled = true;
                }

                if (line.StartsWith("RECIND:"))
                {
                    int value = int.Parse(line.Substring(7));
                    if (value != 0)
                    {
                        lblREC.ForeColor = Color.Red;
                        boxLblREC.BackColor = Color.Red;
                    }
                    else
                    {
                        lblREC.ForeColor = System.Drawing.Color.FromKnownColor(KnownColor.ControlText);
                        boxLblREC.BackColor = Color.Black;
                    }
                }

                if (line.StartsWith("ALARMIND:"))
                {
                    int value = int.Parse(line.Substring(9));

                    //btAlarmReset.Enabled = value != 0;
                    
                        if (firstGetStatus)
                            lastAlarmInd = value;
                        else
                        {
                            if (value != 0 && lastAlarmInd != value)
                            {
                                buildAlarmMsg = true;
                            }
                        }
                    
                    lastAlarmInd = value;
                }

                if (line.StartsWith("ALARMMSG:"))
                {
                    int value = int.Parse(line.Substring(9));
                    
                        if (firstGetStatus)
                            lastAlarmMsg = value;
                        else
                        {
                            if (value == 1 && lastAlarmMsg != value)
                                buildAlarmMsg = true;

                        }
                   
                    lastAlarmMsg = value;
                }

                if (line.StartsWith("ALARMSRC:"))
                {
                    int value = int.Parse(line.Substring(9));
                    
                        if (firstGetStatus)
                            lastAlarmSrc = value;
                        else
                        {
                            if (lastAlarmSrc != value)
                                buildAlarmMsg = true;

                        }
                   
                    lastAlarmSrc = value;
                }
            }
            
                firstGetStatus = false;
           
            if (buildAlarmMsg)
            {
                alarmMsgStr = makeAlarmMsgStr();
                if(alarmMsgStr != "")
                alarmsListBox.Items.Add(alarmMsgStr);

            }


            /***** ALARM INFORMATION *****/
            /***
            StreamReader alarmInfo = execHttpRequestToStreamMonitor("http://" + server + ":" + port + "/cgi-bin/psdctl.cgi?UID=" + monitorUID.ToString() +
                 "&FORMAT=2&TOADR=" + sysPSDADR.ToString().PadLeft(3, '0') + "&CMD=QLD&PARAM=0" + getTempParam());
            
             /***/
            /***** ALARM INFORMATION *****/
            executeHttpOperation(Operation.AlarmInformation, "http://" + server + ":" + port + "/cgi-bin/psdctl.cgi?UID=" + monitorUID.ToString() +
                 "&FORMAT=2&TOADR=" + sysPSDADR.ToString().PadLeft(3, '0') + "&CMD=QLD&PARAM=0" + getTempParam());


          
          
            ((BackgroundWorker)sender).Dispose();
        }



        void changeMonitorCamera(int nCam)
        {
            executeHttpOperation(Operation.ChangeMonitorCamera,"http://" + server + ":" + port + "/cgi-bin/psdctl.cgi?UID="+monitorUID.ToString() + 
                "&FORMAT=1&TOADR=" + sysPSDADR.ToString().PadLeft(3,'0') + "&CMD=OCS&PARAM="+nCam.ToString().PadLeft(5,'0') + getTempParam());
        }

        private void btCam1_Click(object sender, EventArgs e)
        {
            changeMonitorCamera(1);
        }

        private void btCam3_Click(object sender, EventArgs e)
        {
            changeMonitorCamera(3);
        }

        private void btCam2_Click(object sender, EventArgs e)
        {
            changeMonitorCamera(2);
        }

        private void btCam4_Click(object sender, EventArgs e)
        {
            changeMonitorCamera(4);
        }

        private void btCam5_Click(object sender, EventArgs e)
        {
            changeMonitorCamera(5);
        }

        private void btCam6_Click(object sender, EventArgs e)
        {
            changeMonitorCamera(6);
        }

        private void btCam7_Click(object sender, EventArgs e)
        {
            changeMonitorCamera(7);
        }

        private void btCam8_Click(object sender, EventArgs e)
        {
            changeMonitorCamera(8);
        }

        private void btCam9_Click(object sender, EventArgs e)
        {
            changeMonitorCamera(9);
        }

        private void btCam10_Click(object sender, EventArgs e)
        {
            changeMonitorCamera(10);
        }

        private void btCam11_Click(object sender, EventArgs e)
        {
            changeMonitorCamera(11);
        }

        private void btCam12_Click(object sender, EventArgs e)
        {
            changeMonitorCamera(12);
        }

        private void btCam13_Click(object sender, EventArgs e)
        {
            changeMonitorCamera(13);
        }

        private void btCam14_Click(object sender, EventArgs e)
        {
            changeMonitorCamera(14);
        }

        private void btCam15_Click(object sender, EventArgs e)
        {
            changeMonitorCamera(15);
        }

        private void btCam16_Click(object sender, EventArgs e)
        {
            changeMonitorCamera(16);
        }

        private void buttonExtract_Click_1(object sender, EventArgs e)
        {
            int row = rowSelectedIndex;
            if (row < 0) return;
            RecordingsDataSet.RecordingsRow selectedRow = (RecordingsDataSet.RecordingsRow)((DataRowView)recordsDataGrid.Rows[row].DataBoundItem).Row;
            int camId = selectedRow.CameraNo;
            DateTime startTime = Convert.ToDateTime(selectedRow.FrameTime);
            DateTime endTime = Convert.ToDateTime("2007/11/08 18:30:00");

            this.bExtract.Enabled = false;
            this.bExtract.Text = "Processing ...";
                        
            recCtl.StartVideoDownload(startTime, endTime, camId);

            this.bExtract.Text = "Extract...";
            this.bExtract.Enabled = true;

        }

        private void recordsDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rowSelectedIndex = e.RowIndex;
        }
        int rowSelectedIndex = -1;
    }
}