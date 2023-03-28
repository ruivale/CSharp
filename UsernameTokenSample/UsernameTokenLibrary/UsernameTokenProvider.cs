//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.IdentityModel.Tokens;
using System.IdentityModel.Selectors;

namespace Microsoft.ServiceModel.Samples.CustomToken
{
    /// <summary>
    /// UsernameTokenProvider for use with the Username Token
    /// </summary>
    class UsernameTokenProvider : SecurityTokenProvider
    {
        UsernameInfo _usernameInfo;
        
        public UsernameTokenProvider(UsernameInfo usernameInfo) : base()
        {
            if (usernameInfo == null)
            {
                throw new ArgumentNullException("usernameInfo");
            }
            this._usernameInfo = usernameInfo;
        }

        protected override SecurityToken GetTokenCore(TimeSpan timeout)
        {
            SecurityToken result = new UsernameToken(this._usernameInfo);
            return result;
        }
    }
}