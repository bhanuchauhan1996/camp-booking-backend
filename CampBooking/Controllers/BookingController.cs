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
    /// <summary>
    /// This controller contains all the booking related api
    /// </summary>
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

        /// <summary>
        /// Fetch all bookings
        /// </summary>
        /// <returns></returns>
        public IList<BookingDTO> GetAllBooking()
        {
            return Ibooking.GetAllBookings();
        }

        /// <summary>
        /// Get booking by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get booking by booking number
        /// </summary>
        /// <param name="bookingNo"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Add booking into records
        /// </summary>
        /// <param name="bookingDTO"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete Booking by using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update Camp details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bookingDTO"></param>
        /// <returns></returns>
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
