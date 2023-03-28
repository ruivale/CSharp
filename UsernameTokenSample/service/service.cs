
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Collections.Generic;
using System.IdentityModel.Claims; 
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples.CustomToken
{
    // Service class which implements the service contract.
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class EchoService : IEchoService
    {
        public string Echo()
        {
            return String.Format("Hello, you're authenticated!");
        }

    }

}
