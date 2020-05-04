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
    public class ServiceController : ApiController
    {
        private IOperation Ioperation;
        public ServiceController(IOperation Ioperation)
        {
            this.Ioperation = Ioperation;
        }
        public ServiceController()
        {
            Ioperation = new OperationRepo();
        }
        public HttpResponseMessage GetLatestBooking()
        {
            BookingDTO bookingDTO = Ioperation.LatestBooking();
            if (bookingDTO != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, bookingDTO);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No booking found ");
            }
        }

        public HttpResponseMessage DeleteBooking(string id)
        {
            try
            {
                
               if (Ioperation.DeleteBooking(id) == false)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No booking found with id " + id.ToString());
                }
                else
                {
                    Ioperation.DeleteBooking(id);
                    return Request.CreateResponse(HttpStatusCode.OK, "1 row affected");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        
    }
}
