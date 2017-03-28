using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.MemoryStorage;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zesty.UI.Startup))]
namespace Zesty.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
                       
        }
    }

    

}
