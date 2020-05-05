using Service.Repository;
using Shared.DTO;
using Shared.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CampBooking.Controllers
{
    public class LoginController : ApiController
    {
        private IAuthentication authentication;
        public LoginController(IAuthentication authentication)
        {
            this.authentication = authentication;
        }
        public LoginController()
        {
            authentication = new AuthenticationRepo();
        }

        /// <summary>
        /// Get user details to verify user exist or not
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public HttpResponseMessage GetUser(string username , string password)
        {
            UserDTO userDTO = authentication.Login(username, password);
            if (userDTO != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, userDTO);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No user found" );
            }
        }
    }
}
