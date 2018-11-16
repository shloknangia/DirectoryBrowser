using DataBaseLayer;
using Helper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;


namespace DirectoryBrowser.Controllers
{
    internal class AuthAttribute : AuthorizationFilterAttribute
    {
        


        public string Roles { get; set; }
        public string Users {
            get;
            set;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {

            IDataBase tdb = DBFactory.Init();


            if (actionContext.Request.Headers.Authorization == null)
            {
                UnauthMsg(actionContext, "Auth Header Is Null");
            }
            else if (string.IsNullOrWhiteSpace(actionContext.Request.Headers.Authorization.ToString()))
            {
                UnauthMsg(actionContext,"Empty Or WhiteSpaces");
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers
                                            .Authorization.Parameter;
                string decodedAuthenticationToken = Encoding.UTF8.GetString(
                    Convert.FromBase64String(authenticationToken));
                string[] usernamePasswordArray = decodedAuthenticationToken.Split(':');
                string username = usernamePasswordArray[0];
                string password = usernamePasswordArray[1];
                //string roleOfUser = usernamePasswordArray[2];
                /*if(Roles != roleOfUser)
                {
                    UnauthMsg(actionContext,"Not Authorized to Preform this Action");
                }*/
                
                if (tdb.IsValidUser(username, password))
                {
                    if (Roles == null || tdb.IsAuthorisedUser(username, Roles))
                    {
                        Thread.CurrentPrincipal = new GenericPrincipal(
                            new GenericIdentity(username), null);
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request
                                .CreateResponse(HttpStatusCode.Forbidden,"Not Authorised To Access This Data");

                        Global.LHelper.LogError("Not Authorised To Access This Data");
                    }
                }
                else
                {
                    UnauthMsg(actionContext,"Wrong Username Or Password");
                }
            }
        }


        public bool IsAuthorized(HttpActionContext actionContext)
        {
            if(Users.Equals("admin"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private static void UnauthMsg(HttpActionContext actionContext, string msg)
        {
            actionContext.Response = actionContext.Request
                                .CreateResponse(HttpStatusCode.Unauthorized, msg);

            Global.LHelper.LogError(msg);
        }


        /*private static bool Validate(string username, string password)
        {
            return (username.Equals("adminuser") && password.Equals("adminpass") || username.Equals("baseuser") && password.Equals("baseuserpass"));
        }*/
    }
}