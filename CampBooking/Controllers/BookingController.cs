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
    public class BookingController : ApiController
    {
        private IBooking Ibooking;
        public BookingController(IBooking booking)
        {
            Ibooking = booking;
        }
        public BookingController()
        {
            Ibooking = new BookingRepo();
        }

        public IList<BookingDTO> GetAllBooking()
        {
            return Ibooking.GetAllBookings();
        }

        public HttpResponseMessage GetBooking(int id)
        {
            BookingDTO bookingDTO = Ibooking.GetBooking(id);
            if (bookingDTO != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, bookingDTO);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No booking found with id " + id.ToString());
            }
        }

        public HttpResponseMessage GetBookingFromBookingNo(string bookingNo)
        {
            BookingDTO bookingDTO = Ibooking.GetBookingFromBookingNo(bookingNo);
            if (bookingDTO != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, bookingDTO);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No booking found with this " + bookingNo);
            }
        }


        public HttpResponseMessage AddBooking([FromBody]BookingDTO bookingDTO)
        {
            try
            {
                Ibooking.AddBooking(bookingDTO);
                var message = Request.CreateResponse(HttpStatusCode.Created, bookingDTO);
                message.Headers.Location = new Uri(Request.RequestUri + bookingDTO.OrderId.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public HttpResponseMessage DeleteBooking(int id)
        {
            try
            {
                if (id <= 0)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not a valid booking id");
                else if (Ibooking.DeleteBooking(id) == false)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No booking found with id " + id.ToString());
                }
                else
                {
                    Ibooking.DeleteBooking(id);
                    return Request.CreateResponse(HttpStatusCode.OK, "1 row affected");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        [System.Web.Http.HttpPut]
        public HttpResponseMessage UpdateCamp(int id, [FromBody]BookingDTO bookingDTO)
        {
            try
            {
                if (id <= 0)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not a valid booking id");
                else if (Ibooking.UpdateBooking(id, bookingDTO) == false)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No booking found with id " + id.ToString());
                }
                else
                {
                    Ibooking.UpdateBooking(id, bookingDTO);
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
