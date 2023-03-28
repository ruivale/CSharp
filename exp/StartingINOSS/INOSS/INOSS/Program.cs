using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace INOSS
{
    class Program
    {
        static void Main(string[] args)
        {
            string strCP = "D:\\Projects\\GISTV\\Projects\\StvIG-MdP\\IG\\GISTV\\build\\classes;D:\\Projects\\Bosch\\Projects\\BoschJniWrapper\\build\\classes;D:\\Projects\\GISIP_V2\\IG\\SipIG-MdPFase2\\IG\\GISIP_V2\\build\\classes;D:\\Projects\\ERCOM\\trunk\\build\\classes;.;lib\\antlr.jar;lib\\appframe.jar;lib\\CCTV-MdP.jar;lib\\comfyj-2.7.jar;lib\\comfyj-generator-2.7.jar;lib\\comfyj-svrmanager-2.7.jar;lib\\commons-cli.jar;lib\\dom4j.jar;lib\\graphlayout.jar;lib\\IMAPI.jar;lib\\INOSSv2SystemConfigModule-MdP.jar;lib\\izmcomjni.jar;lib\\izmcomtlb.jar;lib\\jaxen.jar;lib\\JniWBoschCameo.jar;lib\\JniWBoschGCA.jar;lib\\JniWBoschGCADivar2.jar;lib\\jniwrap-3.8.jar;lib\\jniwrap-generator-3.8.jar;lib\\jspComm.jar;lib\\jviews.jar;lib\\jviewssvg.jar;lib\\JZBoschEFAGateway.jar;lib\\JZBoschEFALiveVideo.jar;lib\\ojdbc14.jar;lib\\orai18n.jar;lib\\Orb.jar;lib\\OrbServices.jar;lib\\prototypes.jar;lib\\sdm.jar;lib\\sdmgui.jar;lib\\Serialio.jar;lib\\slf4j-api-1.5.8.jar;lib\\slf4j-simple-1.5.8.jar;lib\\swingfx_all.jar;lib\\velocity-dep-1.3.1.jar;lib\\winpack-3.8.jar;lib\\xmlrpc-1.1.1.jar";

            Calljava("D:\\Projects\\TLC-LUAS_MdP\\TLC-LUAS\\tests\\TLC-MdP\\runINOSSv2_56.228_FromProjects.bat");
        }

        private static void Calljava(string arg)
        {
            if (arg != null )
            {
                Process.Start(arg);
            }
            else
            {
                //...
            }
        }

    }
}
