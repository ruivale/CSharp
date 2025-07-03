using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SecureStudentAPI
{
    /// <summary>
    /// Provides configuration for the application's Web API routes.    
    /// </summary>
    /// <remarks>This class contains methods to configure the routing behavior of the Web API.  It is
    /// typically called during application startup to set up the necessary routes.</remarks>
    ///
    /// https://www.c-sharpcorner.com/article/basic-auth-in-asp-net-mvc-web-api-using-c-sharp-net/
    /// 
    public static class WebApiConfig
    {

        /// <summary>
        /// Configures the HTTP routes for the application. 
        /// </summary>
        /// <remarks>This method enables attribute routing and defines a default route for the API. The
        /// default route template is "api/{controller}/{id}", where the <c>id</c> parameter is optional.</remarks>
        /// <param name="config">The <see cref="HttpConfiguration"/> instance to configure.</param>
        public static void Register(HttpConfiguration config)
        {
            // Enable attribute routing
            config.MapHttpAttributeRoutes();

            // Define default route
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
