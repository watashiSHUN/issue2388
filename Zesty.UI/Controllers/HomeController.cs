using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using NLog;
using hbehr.recaptcha;
using Newtonsoft.Json;
using Vereyon.Web;

namespace Zesty.UI.Controllers
{
    public class HomeController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ActionResult Index()
        {
            return View();
        }


    }
}