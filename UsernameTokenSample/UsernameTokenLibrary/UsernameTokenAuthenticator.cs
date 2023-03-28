//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.IdentityModel.Tokens;
using System.IdentityModel.Selectors;

namespace Microsoft.ServiceModel.Samples.CustomToken
{
    /// <summary>
    /// UsernameTokenAuthenticator for use with the Username Token
    /// This validates the username token against a directory of username-password pairs
    /// </summary>
    class UsernameTokenAuthenticator : SecurityTokenAuthenticator
    {
        UsernamePasswordProvider _passwordProvider;

        public UsernameTokenAuthenticator(UsernamePasswordProvider passwordProvider)
        {
            _passwordProvider = passwordProvider;
        }
        protected override bool CanValidateTokenCore(SecurityToken token)
        {
            return (token is UsernameToken);
        }

        protected override ReadOnlyCollection<IAuthorizationPolicy> ValidateTokenCore(SecurityToken token)
        {
            UsernameToken usernameToken = token as UsernameToken;

            // Note that we cannot authenticate the token w/o a password, so it must be retrieved from somewhere
            if (usernameToken.ValidateToken(_passwordProvider.RetrievePassword("User1")) != true)
                throw new SecurityTokenValidationException("Token validation failed");

            // add claims about user here
            DefaultClaimSet UserClaimSet = new DefaultClaimSet(new Claim(ClaimTypes.Name, usernameToken.UsernameInfo.Username, Rights.PossessProperty));
            
            List<IAuthorizationPolicy> policies = new List<IAuthorizationPolicy>(1);
            policies.Add(new UserNameTokenAuthorizationPolicy(UserClaimSet));
            return policies.AsReadOnly();
        }
    }
}