using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Text.RegularExpressions;
using i18n;
using Microsoft.ApplicationInsights.Extensibility;
using NLog;

namespace Zesty.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            //Remove MVC version
            MvcHandler.DisableMvcResponseHeader = true;

        }

        protected void Application_End(object sender, EventArgs e)
        {
            HangfireBootstrapper.Instance.Stop();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
         

        }

        //Servir le fichier html d'erreur.
        protected void Application_Error(object sender, EventArgs e)
        {
            HttpContext.Current.Response.ContentType = "text/html; charset=UTF-8";
        }
    }
}
