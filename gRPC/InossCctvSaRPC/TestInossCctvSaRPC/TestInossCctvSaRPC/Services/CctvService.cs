using Grpc.Core;
using Com.Efacec.ES.TRP.Efarail.Cctv.Grpc.Operation.v1;
using Com.Efacec.ES.TRP.Efarail.Cctv.Grpc.Configuration.v1;
using Com.Efacec.ES.TRP.Efarail.Cctv.Grpc.Enums.v1;
using Com.Efacec.ES.TRP.Efarail.Cctv.Grpc.Messages.v1;



namespace Com.Efacec.ES.TRP.Efarail.Cctv.Grpc.Operation.Services
{
    public class CctvService : v1.Operation.OperationBase
    {
        private readonly ILogger<CctvService> _logger;

        public CctvService(ILogger<CctvService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Obtain the Operation service version
        ///     GetVersion(MsgVersions) returns(MsgReply);
        ///     
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<ListCctvVersionsResponse> GetVersions(VersionsRequest request, ServerCallContext context)
        {

            CctvVersion msgVersionReplyGRPC = new CctvVersion
            {
                Version = 0,
                SubVersion = 0,
                Revision = 1,
                Build = 2,
                Desc = "Hello. I'm CctvOperation service version 0.0.1-alphaI."
            };

            CctvVersion msgVersionReplySa = new CctvVersion
            {
                Version = 2,
                SubVersion = 0,
                Revision = 1,
                Build = 2560,
                Desc = "Hello. I'm CctvSa service version 2.0.1.2560."
            };


            Response response = new Response
            {
                ResponseValue = ResponseValue.ROk,
                Desc = ResponseValue.ROk.ToString()
            };

            ListCctvVersionsResponse msgVersions = new ListCctvVersionsResponse()
            {
                Response = response,
                CctvVersions = { msgVersionReplyGRPC, msgVersionReplySa }
            };

            return Task.FromResult(msgVersions);
        }

        ///// <summary>
        ///// Setting a connection between a source equipment, normally a camera, and a target one, normally a monitor.
        /////     SetSourceinTarget(MsgSetSourceInTarget) returns (MsgReply);
        /////     
        ///// </summary>
        ///// <param name="request"></param>
        ///// <param name="context"></param>
        ///// <returns></returns>
        //public override Task<MsgReply> SetSourceinTarget(MsgSetSourceInTarget request, ServerCallContext context)
        //{
        //    return Task.FromResult(new MsgReply
        //    {
        //        Value = 0,//Com.Efacec.ES.Efarail.Cctv.Grpc.Operation.ReplyValue.Ok.,
        //        StrDesc = "Hello. I'm CctvOperation service version 0.0.1-alphaI."
        //    });
        //}
    }
}
