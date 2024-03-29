﻿using SistemaEncuestas.App_Start;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SistemaEncuestas
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            HttpContext.Current.Application.Add("Version", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());

            GlobalConfiguration.Configuration
                               .Formatters
                               .JsonFormatter
                               .SerializerSettings
                               .ReferenceLoopHandling =
                               Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration
                               .Formatters
                               .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }
    }
}
