﻿using Shared.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Service.Repository
{
   public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        private IAuthentication authentication;
        public BasicAuthenticationAttribute()
        {
            authentication = new AuthenticationRepo();
        }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
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

                //if (authentication.Login(username, password))
                //{
                //    Thread.CurrentPrincipal = new GenericPrincipal(
                //        new GenericIdentity(username), null);
                //}
                //else
                //{
                //    actionContext.Response = actionContext.Request
                //        .CreateResponse(HttpStatusCode.Unauthorized);
                //}
            }
        }
    }
}