//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.ServiceModel.Samples.CustomToken
{
    public class Constants
    {
        public const string UsernameTokenType = "uri:usernameTokenSample";

        internal const string UsernameTokenPrefix = "wsse";
        internal const string UsernameTokenNamespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
        internal const string UsernameTokenName = "UsernameToken";
        
        internal const string IdAttributeName = "Id";
        internal const string WsUtilityPrefix = "wsu";
        internal const string WsUtilityNamespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd";
        internal const string UsernameElementName = "Username";
        internal const string PasswordElementName = "Password";
        internal const string NonceElementName = "Nonce";
        internal const string CreatedElementName = "Created";
        public static string TypeAttributeName = "Type";
        public static string PasswordDigestType = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordDigest";
    }
}
