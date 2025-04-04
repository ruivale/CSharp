using Grpc.Core;

using static Google.Rpc.Context.AttributeContext.Types;



namespace Com.Efacec.ES.TRP.Efarail.Cctv.Grpc.Operation.Services
{

    public class CctvOperationServerImpl: Test.Com.Efacec.ES.Efarail.Cctv.Grpc.Operation.Operation.OperationBase
    {

        public CctvOperationServerImpl()
        {
        }



        /// Obtain the Operation service version
        /// Like: 
        ///      
        /// rpc GetVersionsThroughPost(VersionRequestMsg) returns(VersionsReply) {
        ///    option(google.api.http) = {
        ///       post: "/v1/versionsPost"
        ///       body: "versions"
        ///    };
        /// };
        public override Task<Test.Com.Efacec.ES.Efarail.Cctv.Grpc.Operation.VersionsReply> 
            GetVersionsThroughPost(Test.Com.Efacec.ES.Efarail.Cctv.Grpc.Operation.VersionRequestMsg request, ServerCallContext context)
        {
            Test.Com.Efacec.ES.Efarail.Cctv.Grpc.Operation.VersionBaseMsg vbm1 = 
                new Test.Com.Efacec.ES.Efarail.Cctv.Grpc.Operation.VersionBaseMsg
                {
                    Version = 1,
                    Subversion = 1,
                    Revision = 1,
                    Build = 1,
                    Desc = "Hello. I'm CctvOperationServer 1 service version 1.1.1_b1."
                };

            Test.Com.Efacec.ES.Efarail.Cctv.Grpc.Operation.VersionBaseMsg vbm2 =
                new Test.Com.Efacec.ES.Efarail.Cctv.Grpc.Operation.VersionBaseMsg
                {
                    Version = 2,
                    Subversion = 2,
                    Revision = 2,
                    Build = 2,
                    Desc = "Hello. I'm CctvOperationServer 2 service version 2.2.2_b2."
                };


            Test.Com.Efacec.ES.Efarail.Cctv.Grpc.Operation.VersionsReply msgVersions = new Test.Com.Efacec.ES.Efarail.Cctv.Grpc.Operation.VersionsReply()
            {
                Desc = "Hello. I'm CctvOperationServerImpl service version 0.0.1-alphaI.",
                Versions = { vbm1, vbm2},
            };

            return Task.FromResult(msgVersions);
        }

    }




        //public class CctvService : Operation.OperationBase
        //{
        //    private readonly ILogger<CctvService> _logger;

        //    public CctvService(ILogger<CctvService> logger)
        //    {
        //        _logger = logger;
        //    }

        //    /// <summary>
        //    /// Obtain the Operation service version
        //    ///     GetVersion(MsgVersions) returns(MsgReply);
        //    ///     
        //    /// </summary>
        //    /// <param name="request"></param>
        //    /// <param name="context"></param>
        //    /// <returns></returns>
        //    public override Task<ListCctvVersionsResponse> GetVersions(VersionsRequest request, ServerCallContext context)
        //    {

        //        CctvVersion msgVersionReplyGRPC = new CctvVersion
        //        {
        //            Version = 0,
        //            SubVersion = 0,
        //            Revision = 1,
        //            Build = 2,
        //            Desc = "Hello. I'm CctvOperation service version 0.0.1-alphaI."
        //        };

        //        CctvVersion msgVersionReplySa = new CctvVersion
        //        {
        //            Version = 2,
        //            SubVersion = 0,
        //            Revision = 1,
        //            Build = 2560,
        //            Desc = "Hello. I'm CctvSa service version 2.0.1.2560."
        //        };


        //        Response response = new Response
        //        {
        //            ResponseValue = ResponseValue.ROk,
        //            Desc = ResponseValue.ROk.ToString()
        //        };

        //        ListCctvVersionsResponse msgVersions = new ListCctvVersionsResponse()
        //        {
        //            Response = response,
        //            CctvVersions = { msgVersionReplyGRPC, msgVersionReplySa }
        //        };

        //        return Task.FromResult(msgVersions);
        //    }

        //    ///// <summary>
        //    ///// Setting a connection between a source equipment, normally a camera, and a target one, normally a monitor.
        //    /////     SetSourceinTarget(MsgSetSourceInTarget) returns (MsgReply);
        //    /////     
        //    ///// </summary>
        //    ///// <param name="request"></param>
        //    ///// <param name="context"></param>
        //    ///// <returns></returns>
        //    //public override Task<MsgReply> SetSourceinTarget(MsgSetSourceInTarget request, ServerCallContext context)
        //    //{
        //    //    return Task.FromResult(new MsgReply
        //    //    {
        //    //        Value = 0,//Com.Efacec.ES.Efarail.Cctv.Grpc.Operation.ReplyValue.Ok.,
        //    //        StrDesc = "Hello. I'm CctvOperation service version 0.0.1-alphaI."
        //    //    });
        //    //}
        //}
    }
