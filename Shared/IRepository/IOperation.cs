using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.IRepository
{
   public interface IOperation
    {
        /// <summary>
        /// Search camp between two dates.
        /// </summary>
        /// <param name="checkIn"></param>
        /// <param name="checkOut"></param>
        /// <returns></returns>
        IList<CampDTO> SearchCamp(DateTime? checkIn, DateTime? checkOut);

        /// <summary>
        /// Fetch the latest booked order
        /// </summary>
        /// <returns></returns>
        BookingDTO LatestBooking();

        /// <summary>
        /// Delete Booking
        /// </summary>
        /// <param name="bookingNo"></param>
        /// <returns></returns>
        bool DeleteBooking(string bookingNo);
    }
}
