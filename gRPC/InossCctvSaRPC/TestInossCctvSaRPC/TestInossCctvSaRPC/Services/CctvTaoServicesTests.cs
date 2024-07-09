using System;
using System.IO;
using System.Runtime.Remoting;
//using System.Runtime.Remoting.Channels;

// from IIOPChannel.dll
using Ch.Elca.Iiop;
using Ch.Elca.Iiop.Services;
using omg.org.CosNaming;



namespace Test.Com.Efacec.ES.Efarail.Cctv.Tao.InossCctvSa
{

    /// <summary>
    /// This class will try to use IIOP.NET (w/ ACE+TAO) and comunicate w/ a known StvSa TAO service running in a NameServer in Linux.
    /// By adding the IIOPChannel.dll, build in IIOP.NET project, we access all its classes and also to ACE+TAO classes.
    /// </summary>
    public class CctvTaoServicesTests
    {

        //// A named host (or IP-address host) must be used to connect to the NameService. If "localhost" is used, an omg.org.CORBA.COMM_FAILURE is raised.
        //private static readonly string STR_HOST = "172.19.181.215";      // named host
        //private static readonly int I_PORT = 2809;                     // OMG default port for iiop


        //private static readonly string STR_OPER_TAO_SERVICE = "StvOperation_";
        //private static readonly string STR_OPER_TAO_SERVICE_KIND = "STV";
        //private static readonly int I_STV_TAO_SERVER_ID = 100201;
        //// Like: StvOperation_100201
        //private static readonly string STR_OPER_TAO_SERVICE_ID = STR_OPER_TAO_SERVICE + I_STV_TAO_SERVER_ID;


        /// <summary>
        /// 
        /// </summary>
        CctvTaoServicesTests()
        {

        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public static void run()
        //{
        //    try
        //    {
        //        // Register the channel...
        //        IiopClientChannel channel = new IiopClientChannel();    // assign port automatically
        //        ChannelServices.RegisterChannel(channel);

        //        // Access the COS naming service (NameService)...
        //        CorbaInit init = CorbaInit.GetInit();
        //        NamingContext nameService = init.GetNameService(STR_HOST, I_PORT);

        //        // Like: {StvOperation_100201, STV}
        //        NameComponent[] moduleNameComps = new NameComponent[] { new NameComponent(STR_OPER_TAO_SERVICE_ID, STR_OPER_TAO_SERVICE_KIND) };
        //        NamingContext nameCtxOperStv = (NamingContext)nameService.resolve(moduleNameComps);

        //        // Access the IDL-defined interface (which maps to a .NET interface class)
        //        stv.tao.COperationStv cOperationStv = (stv.tao.COperationStv)nameCtxOperStv;

        //        int nStvSaUpTime = cOperationStv.getSaUptime();

        //        Console.WriteLine("StvSaOperation uptime: " + nStvSaUpTime);

        //    }
        //    #region Exception
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Exception: " + e);
        //    }
        //    #endregion        
        //}
       
    }
}
