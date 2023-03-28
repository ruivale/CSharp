using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvokingWebServices
{

    /// <summary>
    /// 
    /// </summary>
    class TryToPTZ
    {
        private static string strXmlSOAPGotoPreset =
               "<?xml version=\"1.0\" ?>" +
               "<S:Envelope xmlns:S=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:env=\"http://www.w3.org/2003/05/soap-envelope\">" +
                    "<env:Header>"+
                        "<wsse:Security xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\">" +
                            "<wsse:UsernameToken>" +
                                "<wsse:Username>" +

                                    "root" + 

                                "</wsse:Username>" +
                                "<wsse:Password Type=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordDigest\">" +

                                    "lX2L6pZWNE35HMus36hLvSl+iFo=" + 
                            
                                "</wsse:Password>" +
                                "<wsse:Nonce EncodingType=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary\">" +

                                    "DsSHNEy23PAbL+DtDMAVSA==" + 

                                "</wsse:Nonce>" +
                                "<wsu:Created xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\">"+

                                    "2014-05-14T09:42:05.864Z" + 

                                "</wsu:Created>" +
                            "</wsse:UsernameToken>" + 
                        "</wsse:Security>" +
                    "</env:Header>" +
                    "<S:Body>" +
                        "<ns10:GotoPreset xmlns=\"\" xmlns:ns10=\"http://www.onvif.org/ver20/ptz/wsdl\" " +
                                                   "xmlns:ns2=\"http://docs.oasis-open.org/wsrf/bf-2\" " +
                                                   "xmlns:ns3=\"http://www.w3.org/2005/08/addressing\" " +
                                                   "xmlns:ns4=\"http://docs.oasis-open.org/wsn/b-2\" " +
                                                   "xmlns:ns6=\"http://www.onvif.org/ver10/schema\" " +
                                                   "xmlns:ns7=\"http://docs.oasis-open.org/wsn/t-1\" " +
                                                   "xmlns:ns8=\"http://www.w3.org/2004/08/xop/include\" " +
                                                   "xmlns:xmime=\"http://www.w3.org/2005/05/xmlmime\">" +
                           "<ns10:ProfileToken>" +

                               "profile_1_jpeg" +

                           "</ns10:ProfileToken>" +
                           "<ns10:PresetToken>" +

                               "5" +

                           "</ns10:PresetToken>" +
                       "</ns10:GotoPreset>" +
                   "</S:Body>" +
               "</S:Envelope>";


        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void _Main(string[] args)
        {

        }
    }
}
