using DataBaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DirectoryBrowser.Controllers
{
   
    public class WellController : BaseController
    {

        [Auth]
        [HttpGet]
        [Route("api/wells/getallwells")]
        public List<string> GetAllWells()
        {
            //IDataBase obj = new TextFileDB();
            List<string> ret = obj.GetAllWells();
            return ret;
        }
        
        [Auth]
        [HttpGet]
        [Route("api/wells/getwell/{id}")]
        public HttpResponseMessage GetWellById(int id)
        {
            //TextFileDB obj = new TextFileDB();
            HttpResponseMessage msg = new HttpResponseMessage();
            if (id <= obj.LengthOfFileWell())
            {
                string org = obj.GetNthWell(id);
                msg = Request.CreateResponse(HttpStatusCode.OK, org);
            }
            else
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            }
            return msg;
        }
        
        [Auth]
        [HttpGet]
        [Route("api/wells/getwellsbyorg/{org}")]
        public HttpResponseMessage GetWellsByOrg(char org)
        {
            //TextFileDB obj = new TextFileDB();
            HttpResponseMessage msg = new HttpResponseMessage();
            List<string> list = new List<string>();
            list = obj.GetWellsByOrg(org);
            if (list.Count > 0)
            {
                msg = Request.CreateResponse(HttpStatusCode.OK, list);
            }
            else
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            }
            return msg;
        }

        [Auth]
        [HttpGet]
        [Route("api/wells/getwellsbyfield/{f}")]
        public HttpResponseMessage GetWellsByField(string f)
        {
            //TextFileDB obj = new TextFileDB();
            HttpResponseMessage msg = new HttpResponseMessage();
            List<string> list = new List<string>();
            list = obj.GetWellsByField(f);
            if (list.Count > 0)
            {
                msg = Request.CreateResponse(HttpStatusCode.OK, list);
            }
            else
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            }
            return msg;
        }

        [Auth]
        [HttpGet]
        [Route("api/wells/getwellsbyorgandfield/{org}/{f}")]
        public HttpResponseMessage GetWellsByOrgAndField(char org, string f)
        {
            //TextFileDB obj = new TextFileDB();
            HttpResponseMessage msg = new HttpResponseMessage();
            List<string> list = new List<string>();
            list = obj.GetWellsByOrgAndField(org, f);
            if (list.Count > 0)
            {
                msg = Request.CreateResponse(HttpStatusCode.OK, list);
            }
            else
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            }
            return msg;
        }

        [Auth(Roles = "ALL,WELL")]
        [HttpPost]
        [Route("api/wells/createnewwell")]
        public HttpResponseMessage CreateNewWell([FromBody] string well)
        {
            //TextFileDB obj = new TextFileDB();
            obj.AddNewWell(well);
            var ret = Request.CreateResponse(HttpStatusCode.Created);
            return ret;
        }

        [Auth(Roles = "ALL,WELL")]
        [HttpDelete]
        [Route("api/wells/deletewell/{id}")]
        public HttpResponseMessage DeleteWellById(int id)
        {

            //TextFileDB obj = new TextFileDB();
            HttpResponseMessage msg = new HttpResponseMessage();
            if (id <= obj.LengthOfFileWell())
            {
                obj.DeleteNthWell(id);
                msg = Request.CreateResponse(HttpStatusCode.OK, "Well " + id + " Deleted");
            }
            else
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            }
            return msg;
        }

        [Auth(Roles = "ALL,WELL")]
        [HttpDelete]
        [Route("api/wells/deletewellbyfield/{f}")]
        public HttpResponseMessage DeleteWellByField(string f)
        {

            //TextFileDB obj = new TextFileDB();
            HttpResponseMessage msg = new HttpResponseMessage();
            obj.DeleteWellsByField(f);
            msg = Request.CreateResponse(HttpStatusCode.OK, "Wells Of Field " + f + " Deleted");
            return msg;
        }

        [Auth(Roles = "ALL,WELL")]
        [HttpDelete]
        [Route("api/wells/deletewellbyorg/{org}")]
        public HttpResponseMessage DeleteWellByOrg(char org)
        {

            //TextFileDB obj = new TextFileDB();
            HttpResponseMessage msg = new HttpResponseMessage();
            obj.DeleteWellsByOrg(org);
            msg = Request.CreateResponse(HttpStatusCode.OK, "Wells Of Organization " + org + " Deleted");
            return msg;
        }
    }
}
