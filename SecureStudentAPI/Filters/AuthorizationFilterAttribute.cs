using System;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SecureStudentAPI.Filters
{
    /// <summary>
    /// 
    /// Explanation:
    ///     - the filter checks the Authorization header;
    ///     - it decodes the Base64-encoded string;
    ///     - validates the username and password using a helper method;
    ///     - returns 401 Unauthorized if the credentials are invalid.
    ///     
    /// </summary>
    ///
    /// https://www.c-sharpcorner.com/article/basic-auth-in-asp-net-mvc-web-api-using-c-sharp-net/
    /// 
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var authHeader = actionContext.Request.Headers.Authorization;

            if (authHeader != null && authHeader.Scheme == "Basic")
            {
                var credentials = Encoding.UTF8
                    .GetString(Convert.FromBase64String(authHeader.Parameter))
                    .Split(':');

                var username = credentials[0];
                var password = credentials[1];

                if (IsAuthorizedUser(username, password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(
                        new GenericIdentity(username), null);

                    return;
                }
            }

            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"StudentAPI\"");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool IsAuthorizedUser(string username, string password)
        {
            // For demo: simple hardcoded username/password
            return username == "admin" && password == "pass123";
        }
    }
}