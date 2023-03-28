//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Security;

namespace Microsoft.ServiceModel.Samples.CustomToken
{
    // this class provides the stored password for a given username
    public class UsernamePasswordProvider
    {
        public string RetrievePassword(string username)
        {
            if (username == "User1")
            {
                return "P@ssw0rd";
            }
            return null;
        }
    }
}
