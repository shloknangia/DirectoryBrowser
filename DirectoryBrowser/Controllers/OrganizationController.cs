using DataBaseLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using Helper;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace DirectoryBrowser.Controllers
{
    
    public class OrganizationController : BaseController
    {

        LoggerHelper LHelper = new LoggerHelper();

        
        [Auth]
        [HttpGet]
        [Route("api/organization/getallorg")]
        public List<string> GetAllOrg()
        {
            logEverything();

            List<string> ret = obj.GetAllOrg();
            //ret.Add(Thread.CurrentPrincipal.Identity.Name);
            return ret;
        }

        [Auth]
        private void logEverything()
        {
            string username = Thread.CurrentPrincipal.Identity.Name;

            
            LHelper.LogWarn("Warn Message");
            LHelper.LogError("Error Message");
            
            LHelper.LogInfo(username);

        }

        [Auth]
        [HttpGet]
        [Route("api/organization/getorg/{id}")]
        public HttpResponseMessage GetOrgById(int id)
        {
            //TextFileDB obj = new TextFileDB();
            logEverything();

            HttpResponseMessage msg = new HttpResponseMessage();
            if (id <= obj.LengthOfFileOrg())
            {
                string org = obj.GetNthOrg(id);
                msg = Request.CreateResponse(HttpStatusCode.OK, org);
            }
            else
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            }
            return msg;
        }

        [Auth(Roles = "ALL,ORG")]
        [HttpPost]
        [Route("api/organization/createneworg")]
        public HttpResponseMessage CreateNewOrganization([FromBody] string org)
        {
            //TextFileDB obj = new TextFileDB();
            //IDataBase obj = Init();
            logEverything();
            obj.AddNewOrg(org);
            var ret = Request.CreateResponse(HttpStatusCode.Created);
            //ret.Headers.Location = new Uri(Request.RequestUri + c.id.ToString());
            return ret;
        }

        [Auth(Roles = "ALL,ORG")]
        [HttpDelete]
        [Route("api/organization/deleteorg/{id}")]
        public HttpResponseMessage DeleteOrgById(int id)
        {
            string orgName;
            //TextFileDB obj = new TextFileDB();
            //IDataBase obj = Init();
            logEverything();
            HttpResponseMessage msg = new HttpResponseMessage();
            if (id <= obj.LengthOfFileOrg())
            {
                orgName = obj.DeleteNthOrg(id);
                obj.DeleteFieldsByOrg(Convert.ToChar(orgName));
                obj.DeleteWellsByOrg(Convert.ToChar(orgName));
                msg = Request.CreateResponse(HttpStatusCode.OK, "Organization " + id + " Deleted");
            }
            else
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            }
            return msg;
        }
    }
}
