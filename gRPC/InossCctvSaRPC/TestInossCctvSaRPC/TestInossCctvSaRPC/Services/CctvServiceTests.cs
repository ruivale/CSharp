using Grpc.Core;
using Test.Com.Efacec.ES.Efarail.Cctv.Grpc.Operation;

namespace Test.Com.Efacec.ES.Efarail.Cctv.Grpc.Operation.Services
{
    public class CctvServiceTests : Operation.OperationBase
    {
        private readonly uint nVersion = 0;
        private readonly uint nSubversion = 0;
        private readonly uint nRevision = 1;
        private readonly ulong nBuild = 2;

        private readonly ILogger<CctvServiceTests> _logger;

        public CctvServiceTests(ILogger<CctvServiceTests> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Obtain the Operation service version
        ///     GetVersion(EmptyMessage) returns(MsgReply);
        ///     
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<VersionReply> GetVersion(MsgEmpty request, ServerCallContext context)
        {
            Console.WriteLine("CctvServiceTests.GetVersion()...");


            return Task.FromResult(new VersionReply
            {
                Version = nVersion,
                Subversion = nSubversion,
                Revision = nRevision,
                Build = nBuild,
                Desc = "Hello. I'm CctvOperation service version " + nVersion + "." + nSubversion + "." + nRevision + "." + nBuild
            });
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
        //        Value = (int)Com.Efacec.ES.Efarail.Cctv.Grpc.Operation.ReplyValue.Ok,
        //        StrDesc = Com.Efacec.ES.Efarail.Cctv.Grpc.Operation.ReplyValue.Ok.ToString()
        //    });
        //}

        ///// <summary>
        ///// Obtains the given targets connection information, if any.
        /////     rpc GetSourcesInTargets(MsgGetSourcesInTargets) returns(MsgGetSourcesInTargetsReply);
        /////     
        ///// </summary>
        ///// <param name="request"></param>
        ///// <param name="context"></param>
        ///// <returns></returns>
        //public override Task<MsgGetSourcesInTargetsReply> GetSourcesInTargets(MsgGetSourcesInTargets request, ServerCallContext context)
        //{
        //    return Task.FromResult(new MsgGetSourcesInTargetsReply
        //    {
        //        MsgReply = new MsgReply
        //        {
        //            Value = (int)Com.Efacec.ES.Efarail.Cctv.Grpc.Operation.ReplyValue.Ok,
        //            StrDesc = Com.Efacec.ES.Efarail.Cctv.Grpc.Operation.ReplyValue.Ok.ToString()
        //        },
        //        SourceInTarget = new MsgGetSourcesInTargetsReply
        //        {
                    
        //        }
        //    });
        //}

        
    }
}
