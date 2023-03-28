using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;

using System.Net;
using System.Web;
using CookComputing.XmlRpc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XmlRpcClient
{
    public interface IServerInterface : IXmlRpcProxy
    {
        [XmlRpcMethod("xmlrpc.getServerTime")]
        string GetServerTime();

        [XmlRpcMethod("xmlrpc.getCountryList")]
        string getCountry(string name);

        [XmlRpcMethod("xmlrpc.getCountryDetails")]
        string getCountryDetails(string name);        
    }
    
    public partial class XmlRpcClient : Form
    {
        private IServerInterface rpcProxy;

        public XmlRpcClient()
        {
            InitializeComponent();
            rpcProxy = XmlRpcProxyGen.Create<IServerInterface>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                rpcProxy.Url = rpcAddress.Text;
                MessageBox.Show(rpcProxy.GetServerTime());                
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

        }

        private void HandleException(Exception ex)
        {
            string msgBoxTitle = "Error";

            try
            {
                throw ex;
            }
            catch (XmlRpcFaultException fex)
            {
                MessageBox.Show("Fault Response: " + fex.FaultCode + " " + fex.FaultString, msgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (WebException webEx)
            {
                MessageBox.Show("WebException: " + webEx.Message, msgBoxTitle,MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                if (webEx.Response != null)
                    webEx.Response.Close();
            }
            catch (XmlRpcServerException xmlRpcEx)
            {
                MessageBox.Show("XmlRpcServerException: " + xmlRpcEx.Message, msgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception defEx)
            {
                MessageBox.Show("Exception: " + defEx.Message, msgBoxTitle,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
              
        private void AddTableRow(string nume , string flagurl , string iso)
        {
            ListViewItem lvi;
            ListViewItem.ListViewSubItem lvsi;

            lvi = new ListViewItem();
            lvi.Text = iso;

            lvsi = new ListViewItem.ListViewSubItem();
            lvsi.Text = nume;
            lvi.SubItems.Add(lvsi);

            lvsi = new ListViewItem.ListViewSubItem();
            lvsi.Text = flagurl;
            lvi.SubItems.Add(lvsi);

            this.listViewCountry.Items.Add(lvi);
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            listViewCountry.Items.Clear();

            try
            {
                rpcProxy.Url = rpcAddress.Text;
                JArray deserialize = (JArray)JsonConvert.DeserializeObject(rpcProxy.getCountry(textBoxCountry.Text));

                foreach (JToken t in deserialize)
                {
                    AddTableRow(t.Value<string>("name"), t.Value<string>("flag_http"), t.Value<string>("iso"));
                }

            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

        }

        private void OnSelectionChanged(object sender, EventArgs e)
        {
            if (sender == listViewCountry)
            {
                int index = -1;

                if (listViewCountry.SelectedIndices.Count > 0)
                {
                    if ((index = listViewCountry.SelectedIndices[0]) != -1)
                    {
                        try
                        {
                            string searchtext = listViewCountry.Items[index].Text;
                                                        
                            rpcProxy.Url = rpcAddress.Text;
                            JArray deserialize = (JArray)JsonConvert.DeserializeObject(rpcProxy.getCountryDetails(searchtext));

                            foreach (JToken t in deserialize)
                            {
                                textBoxISO.Text = t.Value<string>("iso");
                                textBoxISO3.Text = t.Value<string>("iso3");
                                textBoxNume.Text = t.Value<string>("name");
                                textBoxNumCode.Text = t.Value<string>("numcode");
                                pictureFlag.ImageLocation = t.Value<string>("flag_http");
                            }

                        }
                        catch (Exception ex)
                        {
                            HandleException(ex);
                        }
                    }
                }

            }
        }



    }
}
