using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ServiceModel.Samples.CustomToken;
using System.IdentityModel.Selectors;
using System.IO;
using System.Xml;
using System.IdentityModel.Tokens;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.ServiceModel.Samples.CustomToken.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TokenTest()
        {
            // create our token
            UsernameSecurityTokenSerializer s = new UsernameSecurityTokenSerializer(null);
            Stream stream = new MemoryStream();
            XmlWriter writer = XmlDictionaryWriter.Create(stream);
            UsernameToken token = new UsernameToken(new UsernameInfo("User1", "P@ssw0rd"));
            s.WriteToken(writer, token);
            stream.Position = 0;

            XmlDocument doc = new XmlDocument();
            doc.Load(stream);

            string hashBase64 = token.GetPasswordDigestAsBase64();
            // check if WSE3 can load our token
            Microsoft.Web.Services3.Security.Tokens.UsernameToken token2 = new Microsoft.Web.Services3.Security.Tokens.UsernameToken(doc.DocumentElement);

            // check if WSE3 generates the same hash for the same input (nonce, datetime and password):
            byte[] alterHash = Microsoft.Web.Services3.Security.Tokens.UsernameToken.ComputePasswordDigest(
                Convert.FromBase64String(token.GetNonceAsBase64()),
                XmlConvert.ToDateTime(token.GetCreatedAsString(), "yyyy-MM-ddTHH:mm:ssZ"),
                "P@ssw0rd");

            string alterHashBase64 = Convert.ToBase64String(alterHash);
            Assert.AreEqual(hashBase64, alterHashBase64, false);
        }
    }
}
