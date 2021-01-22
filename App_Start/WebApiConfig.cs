using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CrudAngular
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var cors = new System.Web.Http.Cors.EnableCorsAttribute("*", "*", "GET, POST, PUT, DELETE, OPTIONS");
            config.EnableCors(cors);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
