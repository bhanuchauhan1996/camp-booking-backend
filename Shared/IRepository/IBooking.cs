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
        IList<BookingDTO> GetAllBookings();
        BookingDTO GetBooking(int id);
        void AddBooking(BookingDTO bookingDTO);
        bool DeleteBooking(int id);
        bool UpdateBooking(int id, BookingDTO bookingDTO);
        BookingDTO GetBookingFromBookingNo(string bookingNo);
    }
}
