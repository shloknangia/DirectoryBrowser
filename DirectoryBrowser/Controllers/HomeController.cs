using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DirectoryBrowser.Controllers
{
    public class HomeController : Controller
    {
        //private static log4net.ILog Log { get; set; }
        //ILog log = log4net.LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            /*log.Debug("Debug Message");
            log.Warn("Warn Message");
            log.Error("Error Message");
            log.Fatal("Fatel Message");*/
            

            return View();
        }
    }
}
