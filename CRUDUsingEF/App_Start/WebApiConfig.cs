using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace CRUDUsingEF
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Formatters.Clear(); // removed all message format
            //config.Formatters.Add(new JsonMediaTypeFormatter());

            config.Formatters.JsonFormatter
                .SerializerSettings.ReferenceLoopHandling =
                ReferenceLoopHandling.Ignore;


            //var settings = new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //};

            //JsonMediaTypeFormatter jsonFormatter =
            //    new JsonMediaTypeFormatter();
            //jsonFormatter.SerializerSettings = settings;

            //config.Formatters.Add(jsonFormatter);
        }
    }
}
