using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ApiTracking
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // config.EnableCors(); // If CORS needed

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );/**/

            // Force the use of EXACT action names.
            /*config.Routes.MapHttpRoute(
                name: "DefaultActionApi",
                routeTemplate: "api/{controller}/{action}"
            );/**/

            // Used to force JSON type
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    }
}
