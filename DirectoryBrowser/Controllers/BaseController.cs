using DataBaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace DirectoryBrowser.Controllers
{
    //[Auth]
    public class BaseController : ApiController
    {
        internal IDataBase obj = DBFactory.Init();
        
        //string username = Thread.CurrentPrincipal.Identity.Name;

        

        //log.Debug("Debug Message");
        //log.Warn("Warn Message");
        //log.Error("Error Message");
        //log.Fatal("Fatel Message");
        //log.Info(username);

    }
}