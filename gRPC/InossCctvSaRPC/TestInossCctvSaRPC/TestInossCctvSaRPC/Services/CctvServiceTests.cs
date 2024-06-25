using Grpc.Core;
using Test.Com.Efacec.ES.Efarail.Cctv.Grpc.Operation;

namespace Test.Com.Efacec.ES.Efarail.Cctv.Grpc.Operation.Services
{
    public class CctvServiceTests : Operation.OperationBase
    {
        private readonly long nVersion = 0;
        private readonly long nSubversion = 0;
        private readonly long nRevision = 1;
        private readonly long nBuild = 2;

        private readonly ILogger<CctvServiceTests> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public CctvServiceTests(ILogger<CctvServiceTests> logger)
        {
            _logger = logger;
        }


        public override Task<VersionsReply> GetSimpleVersion(EmptyRequest request, ServerCallContext context)
        {
            Console.WriteLine("CctvServiceTests.GetSimpleVersion() GET GET GET ...");

            return Task.FromResult(new VersionsReply
            {
                Desc = "Returning a \"bunch\" of simple versions.",
                Versions =
                {
                    new VersionBaseMsg
                    {
                        Version = nVersion,
                        Subversion = nSubversion,
                        Revision = nRevision,
                        Build = nBuild,
                        Desc = "Hello. I'm the simple CctvOperation service I version " + nVersion + "." + nSubversion + "." + nRevision + "." + nBuild + " (simple)."
                    },
                    new VersionBaseMsg
                    {
                        Version = 1,
                        Subversion = 2,
                        Revision = 3,
                        Build = 444,
                        Desc = "Hello. I'm the simple CctvOperation service II version " + 1 + "." + 2 + "." + 3 + "." + 444 + " (simple)."
                    }
                }
            });
        }

        //public override Task<VersionsReply> GetVersions(VersionRequestMsg request, ServerCallContext context)
        //{
        //    Console.WriteLine("CctvServiceTests.GetVersions() GET GET GET ...");


        //    string strAllRequestsDesc = "Request(" + request.Id + ") Requests[";

        //    foreach (var item in request.Versions)
        //    {
        //        strAllRequestsDesc += "[" + item.Id + ", " + item.Desc + "]";
        //    }

        //    strAllRequestsDesc += "]";


        //    return Task.FromResult(new VersionsReply
        //    {
        //        Desc = "Returning a \"bunch\" of versions requested from (" + strAllRequestsDesc + ") .",
        //        Versions =
        //        {
        //            new VersionBaseMsg
        //            {
        //                Version = nVersion,
        //                Subversion = nSubversion,
        //                Revision = nRevision,
        //                Build = nBuild,
        //                Desc = "Hello. I'm CctvOperation service I version " + nVersion + "." + nSubversion + "." + nRevision + "." + nBuild + "."
        //            },
        //            new VersionBaseMsg
        //            {
        //                Version = 11,
        //                Subversion = 22,
        //                Revision = 33,
        //                Build = 444444,
        //                Desc = "Hello. I'm CctvOperation service II version " + 11 + "." + 22 + "." + 33 + "." + 444444 + "."
        //            }
        //        }
        //    });
        //}

        public override Task<VersionsReply> GetVersionsWithNoBound(VersionRequestMsg request, ServerCallContext context)
        {
            Console.WriteLine("CctvServiceTests.GetVersionsWithNoBound() GET GET GET ...");


            string strAllRequestsDesc = "Request(" + request.Id + ") Requests[";

            foreach (var item in request.Versions)
            {
                strAllRequestsDesc += "[" + item.Id + ", " + item.Desc + "]";
            }

            strAllRequestsDesc += "]";


            return Task.FromResult(new VersionsReply
            {
                Desc = "Returning a \"bunch\" of versions requested from (" + strAllRequestsDesc + ") .",
                Versions =
                {
                    new VersionBaseMsg
                    {
                        Version = nVersion,
                        Subversion = nSubversion,
                        Revision = nRevision,
                        Build = nBuild,
                        Desc = "Hello. I'm CctvOperation service I version " + nVersion + "." + nSubversion + "." + nRevision + "." + nBuild + "."
                    },
                    new VersionBaseMsg
                    {
                        Version = 11,
                        Subversion = 22,
                        Revision = 33,
                        Build = 444444,
                        Desc = "Hello. I'm CctvOperation service II version " + 11 + "." + 22 + "." + 33 + "." + 444444 + "."
                    }
                }
            });
        }

        public override Task<VersionsReply> GetVersionsThroughPost(VersionRequestMsg request, ServerCallContext context)
        {
            Console.WriteLine("CctvServiceTests.GetVersionsThroughPost() POST POST POST...");


            string strAllRequestsDesc = "Request(" + request.Id + ") Requests[";

            foreach (var item in request.Versions)
            {
                strAllRequestsDesc += "[" + item.Id + ", " + item.Desc + "]";
            }

            strAllRequestsDesc += "]";


            return Task.FromResult(new VersionsReply
            {
                Desc = "Returning a \"bunch\" of versions requested from  (" + strAllRequestsDesc + ") .",
                Versions =
                {
                    new VersionBaseMsg
                    {
                        Version = nVersion,
                        Subversion = nSubversion,
                        Revision = nRevision,
                        Build = nBuild,
                        Desc = "Hello. I'm CctvOperation service version " + nVersion + "." + nSubversion + "." + nRevision + "." + nBuild + " obtained from a HTTP-POST."
                    },
                    new VersionBaseMsg
                    {
                        Version = 11,
                        Subversion = 22,
                        Revision = 33,
                        Build = 444444,
                        Desc = "Hello. I'm CctvOperation service II version " + 11 + "." + 22 + "." + 33 + "." + 444444 + " obtained from a HTTP-POST."
                    }
                }
            });
        }

    }
}
