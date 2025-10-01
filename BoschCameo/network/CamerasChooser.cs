using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCameoMainWindow;

namespace CSharpRuntimeCameo.network
{
    public partial class CamerasChooser : Form
    {

        public ArrayList arlGrp;

        private readonly MainWindow mainWindow;



        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainWindow"></param>
        public CamerasChooser(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;

            InitializeComponent();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CamerasChooser_Load(object sender, EventArgs e)
        {
            try
            {
                treeViewNetwork.Nodes.Clear();
                StationsConfig stat = new StationsConfig();

                arlGrp = stat.GetStationGroupsArray();

                GetNodes(null, arlGrp, false /* show zones */, true /* only cams */);

                treeViewNetwork.TopNode = treeViewNetwork.Nodes[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error reading network data.");

                Log.WriteLog(
                        Application.StartupPath + @"\" + Log.LOGFILENAME,
                        "Cannot read network from Stations.xml.\n" + ex.ToString());
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CamerasChooser_Shown(object sender, EventArgs e)
        {
            this.textBoxCamName.Focus();
        }


        private void CamerasChooser_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.ProcessCameraSelected();
        }


        /// <summary>
        /// 
        /// </summary>
        private void ProcessCameraSelected()
        {
            this.Close();
            this.Dispose();

            this.mainWindow.ProcessCameraSelection((MyObject)treeViewNetwork.SelectedNode.Tag);
        }


        /// <summary>
        /// 
        /// </summary>
        private void CheckForSelectionProcess()
        {
            if (treeViewNetwork.SelectedNode == null)
            {
                return;
            }

            MyObject obj = (MyObject)treeViewNetwork.SelectedNode.Tag;

            if (obj.Class == eClass.Camera)
            {
                this.ProcessCameraSelected();
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void treeViewNetwork_MouseClick(object sender, MouseEventArgs e)
        {
            if (treeViewNetwork.SelectedNode == null)
            {
                buttonOk.Enabled = false;

                return;
            }


            TreeNode clickedNode = treeViewNetwork.GetNodeAt(e.X, e.Y);

            if (clickedNode != null)
            {
                MyObject obj = (MyObject)clickedNode.Tag;

                if (obj.Class == eClass.Camera)
                {
                    buttonOk.Enabled = true;
                }
                else
                {
                    buttonOk.Enabled = false;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewNetwork_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.CheckForSelectionProcess();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void treeViewNetwork_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.CheckForSelectionProcess();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.treeViewNetwork.Focus();
            }

            string strCamName = this.textBoxCamName.Text.Trim();

            if (strCamName.Length == 0)
            {
                return;
            }

            MyObject myObj = MyObject.GetCameraFromNamePrefix(strCamName);

            if (myObj != null)
            {
                this.treeViewNetwork.SelectedNode = myObj.TreeNode;
                this.treeViewNetwork.SelectedNode.EnsureVisible();

                treeViewNetwork.Invalidate();
                treeViewNetwork.Update();

            }
        }


        /// <summary>
        /// Search tree nodes from all objects
        /// </summary>
        /// <param name="tngroup"></param>
        /// <param name="arrObj"></param>
        /// <param name="bShowZones"></param>
        private void GetNodes(TreeNode tngroup, ArrayList arrObj, bool bShowZones, bool showOnlyCams)
        {
            try
            {
                for (int j = 0; j < arrObj.Count; j++)
                {
                    Application.DoEvents();

                    MyObject myObj = (MyObject)arrObj[j];

                    if (!myObj.Visible)
                    {
                        continue;
                    }

                    if (myObj.Type == eType.StationZone || myObj.Type == eType.SoundZone)
                    {
                        if (!bShowZones)
                        {
                            GetNodes(tngroup, myObj.arrObjects, myObj.ZonesCount > 1, showOnlyCams);
                            continue;
                        }
                    }

                    TreeNode treeNode = new TreeNode();
                    treeNode.Text = myObj.Name;
                    treeNode.Tag = myObj;
                    int iImg;


                    switch (myObj.Class)
                    {
                        case eClass.VideoRecorder:
                            if (showOnlyCams && myObj.Class != eClass.Camera)
                            {
                                continue;
                            }

                            iImg = 16;

                            if (myObj.Type == eType.NVR_Bosch)
                            {
                                iImg = 22;

                                if (myObj.ModelProtocol == "VRM")
                                {
                                    iImg = 25;
                                }
                            }
                            else if (myObj.Type == eType.VideoRecorder)
                            {
                                iImg = 28;
                            }

                            if (!myObj.Enabled)
                            {
                                iImg++;
                            }

                            break;


                        case eClass.VideoStorage:
                            if (showOnlyCams && myObj.Class != eClass.Camera)
                            {
                                continue;
                            }

                            iImg = 19;

                            if (myObj.Type == eType.DVA_Bosch)
                            {
                                iImg = 31;
                            }

                            if (!myObj.Enabled)
                            {
                                iImg++;
                            }

                            break;


                        case eClass.Camera:
                            iImg = 8; // camera_ok.jpg

                            if (myObj.Type == eType.PTZ || myObj.Type == eType.CamONVIF)
                            {
                                iImg = 12; // dome_ok.jpg
                            }


                            if (!myObj.Enabled)
                            {
                                iImg++; // camera_disable.jpg or dome_disable.jpg
                            }


                            treeNode.Text = "";

                            if (myObj.VideoIn != 0)
                            {
                                treeNode.Text = myObj.VideoIn + "_";
                            }

                            treeNode.Text += myObj.Name;

                            break;


                        case eClass.Monitor:
                            if (showOnlyCams && myObj.Class != eClass.Camera)
                            {
                                continue;
                            }

                            iImg = 4;

                            if (!myObj.Enabled)
                            {
                                iImg++;
                            }

                            treeNode.Text = "";

                            if (myObj.VideoIn != 0)
                            {
                                treeNode.Text = myObj.VideoOut + "_";
                            }

                            treeNode.Text += myObj.Name;

                            break;


                        default:
                            iImg = 0;

                            if (!myObj.Enabled)
                            {
                                iImg++;
                            }

                            break;
                    }

                    treeNode.ToolTipText = treeNode.Text;
                    treeNode.ImageIndex = iImg;
                    treeNode.SelectedImageIndex = iImg;

                    if (tngroup == null)
                    {
                        treeViewNetwork.Nodes.Add(treeNode);
                    }
                    else
                    {
                        tngroup.Nodes.Add(treeNode);

                        if ((myObj.Class != eClass.StationZone) &&
                            (myObj.Class != eClass.Camera) &&
                            (myObj.Class != eClass.Monitor) &&
                            (myObj.Class != eClass.VideoRecorder) &&
                            (myObj.Class != eClass.VideoStorage))
                        {
                            treeNode.Parent.Expand();
                        }
                    }

                    myObj.TreeNode = treeNode;

                    Application.DoEvents();

                    if (myObj.Enabled)
                    {
                        GetNodes(treeNode, myObj.arrObjects, myObj.ZonesCount > 1, showOnlyCams);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(
                    Application.StartupPath + @"\" + Log.LOGFILENAME,
                    "Cannot obtain nodes from Stations.xml.\n" + ex.ToString());

                throw ex;
            }
        }

    }
}
