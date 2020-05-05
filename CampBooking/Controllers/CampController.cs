using Shared.DTO;
using Newtonsoft.Json;
using Shared.IRepository;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace CampBooking.Controllers
{
    /// <summary>
    /// This controller contains all the camp related api
    /// </summary>
    public class CampController : ApiController
    {
        private ICamp Icamp;
        public CampController(ICamp camp)
        {
            Icamp = camp;
        }
        public CampController()
        {
            Icamp = new CampRepo();
        }

      /// <summary>
      /// Get all camps
      /// </summary>
      /// <returns></returns>
        public IList<CampDTO> Get()
        {
            return Icamp.GetAllCamps();
        }

      /// <summary>
      /// Get camp by id
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
        public HttpResponseMessage GetCamp(int id)
        {
            CampDTO campViewModel= Icamp.GetCamp(id);
            if(campViewModel != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, campViewModel);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No camp found with id "+id.ToString());
            }
        }

        /// <summary>
        /// Add camp 
        /// </summary>
        /// <param name="camp"></param>
        /// <returns></returns>
        public HttpResponseMessage AddCamp([FromBody]CampDTO camp)
        {
            try
            {
                Icamp.AddCamp(camp);
                var message = Request.CreateResponse(HttpStatusCode.Created, camp);
                message.Headers.Location = new Uri(Request.RequestUri + camp.CampId.ToString());
                return message;
            }
            catch(Exception ex) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            
        }
       
        /// <summary>
        /// Delete Camp
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage DeleteCamp(int id)
        {
            try
            {
                if (id <= 0)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not a valid camp id");
                else if (Icamp.DeleteCamp(id) == false)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No camp found with id " + id.ToString());
                }
                else
                {
                    Icamp.DeleteCamp(id);
                    return Request.CreateResponse(HttpStatusCode.OK, "1 row affected");
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            
        }
        
        /// <summary>
        /// Update Camp
        /// </summary>
        /// <param name="id"></param>
        /// <param name="camp"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPut]
        public HttpResponseMessage UpdateCamp(int id,[FromBody]CampDTO camp)
        {
            try
            {
                if (id <= 0)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not a valid camp id");
                else if (Icamp.UpdateCamp(id,camp) == false)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No camp found with id " + id.ToString());
                }
                else
                {
                    Icamp.UpdateCamp(id,camp);
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
