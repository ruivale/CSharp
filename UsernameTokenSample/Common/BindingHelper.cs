//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel.Channels;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Security.Tokens;
using System.Text;

namespace Microsoft.ServiceModel.Samples.CustomToken
{
    public static class BindingHelper
    {
        public static Binding userNameBinding()
        {
            // NOTE: we use a non-secure transport here, which means the message will be visible to others.
            HttpTransportBindingElement httpTransport = new HttpTransportBindingElement();

            // the transport security binding element will be configured to require a username token
            TransportSecurityBindingElement transportSecurity = new TransportSecurityBindingElement();
            transportSecurity.EndpointSupportingTokenParameters.SignedEncrypted.Add(new UsernameTokenParameters());

            // here you can require secure transport, in which case you'd probably replace HTTP with HTTPS as well
            transportSecurity.AllowInsecureTransport = true;
            transportSecurity.IncludeTimestamp = false;

            TextMessageEncodingBindingElement me = new TextMessageEncodingBindingElement(MessageVersion.Soap11, Encoding.UTF8);

            return new CustomBinding(transportSecurity, me, httpTransport);
        }
    }
}
