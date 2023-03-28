//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.ServiceModel.Security.Tokens;
using System.IdentityModel.Tokens;
using System.IdentityModel.Selectors;

namespace Microsoft.ServiceModel.Samples.CustomToken
{
    /// <summary>
    /// UsernameServiceCredentials for use with the Username Token. It serves up a Custom SecurityTokenManager
    /// UsernameServiceCredentialsSecurityTokenManager - that knows about our custom token.
    /// </summary>
    /// 
    public class UsernameServiceCredentials : ServiceCredentials
    {
        UsernamePasswordProvider _validator;
        public UsernamePasswordProvider Validator { get { return _validator; } }

        public UsernameServiceCredentials(UsernamePasswordProvider validator)
        {
            if (validator == null)
                throw new ArgumentNullException("validator");
            _validator = validator;
        }

        protected override ServiceCredentials CloneCore()
        {
            return new UsernameServiceCredentials(_validator);
        }

        public override SecurityTokenManager CreateSecurityTokenManager()
        {
            return new UsernameServiceCredentialsSecurityTokenManager(this);
        }
    }
}
