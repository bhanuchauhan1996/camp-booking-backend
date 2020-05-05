using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.IRepository
{
   public interface IBooking
    {
        /// <summary>
        /// It returns all the booking.
        /// </summary>
        /// <returns></returns>
        IList<BookingDTO> GetAllBookings();

        /// <summary>
        /// Find Booking by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BookingDTO GetBooking(int id);

        /// <summary>
        /// Add booking into records.
        /// </summary>
        /// <param name="bookingDTO"></param>
        void AddBooking(BookingDTO bookingDTO);

        /// <summary>
        /// Delete Booking
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteBooking(int id);

        /// <summary>
        /// Update Booking details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bookingDTO"></param>
        /// <returns></returns>
        bool UpdateBooking(int id, BookingDTO bookingDTO);

        /// <summary>
        /// Fetch booking by using booking number.
        /// </summary>
        /// <param name="bookingNo"></param>
        /// <returns></returns>
        BookingDTO GetBookingFromBookingNo(string bookingNo);
    }
}
