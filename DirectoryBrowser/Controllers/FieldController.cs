using DataBaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DirectoryBrowser.Controllers
{
    
    public class FieldController : BaseController
    {
        [Auth]
        [HttpGet]
        [Route("api/fields/getallfields")]
        public List<string> GetAllFields()
        {
            //TextFileDB obj = new TextFileDB();
            List<string> ret = obj.GetAllFields();
            return ret;
        }

        [Auth]
        [HttpGet]
        [Route("api/fields/getfield/{id}")]
        public HttpResponseMessage GetFieldById(int id)
        {
            // obj = new TextFileDB();
            HttpResponseMessage msg = new HttpResponseMessage();
            if (id <= obj.LengthOfFileField())
            {
                string org = obj.GetNthField(id);
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
        [Route("api/fields/getfieldsbyorg/{org}")]
        public HttpResponseMessage GetFieldsByOrg(char org)
        {
            //TextFileDB obj = new TextFileDB();
            HttpResponseMessage msg = new HttpResponseMessage();
            List<string> list = new List<string>();
            list = obj.GetFieldsByOrg(org);
            if(list.Count > 0)
            {
                msg = Request.CreateResponse(HttpStatusCode.OK, list);
            }
            else
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            }
            return msg;
        }

        [Auth(Roles = "ALL,FIELD")]
        [HttpPost]
        [Route("api/fields/createnewfield")]
        public HttpResponseMessage CreateNewOrganization([FromBody] string field)
        {
            //TextFileDB obj = new TextFileDB();
            obj.AddNewField(field);
            var ret = Request.CreateResponse(HttpStatusCode.Created);
            return ret;
        }

        [Auth(Roles = "ALL,FIELD")]
        [HttpDelete]
        [Route("api/fields/deletefield/{id}")]
        public HttpResponseMessage DeleteOrgById(int id)
        {
            string fieldName = "";
            //TextFileDB obj = new TextFileDB();
            HttpResponseMessage msg = new HttpResponseMessage();
            if (id <= obj.LengthOfFileField())
            {
                fieldName = obj.DeleteNthField(id);
                obj.DeleteWellsByField(fieldName);
                msg = Request.CreateResponse(HttpStatusCode.OK, "Field " + id + " Deleted");
            }
            else
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            }
            return msg;
        }


        [Auth(Roles = "ALL,FIELD")]
        [HttpDelete]
        [Route("api/fields/deletefieldbyorg/{org}")]
        public HttpResponseMessage DeleteFieldById(char org)
        {

            //TextFileDB obj = new TextFileDB();
            HttpResponseMessage msg = new HttpResponseMessage();
            obj.DeleteFieldsByOrg(org);
            obj.DeleteWellsByOrg(org);
            msg = Request.CreateResponse(HttpStatusCode.OK, "Fields of Organization " + org + " Deleted");
            return msg;
        }
    }
}
