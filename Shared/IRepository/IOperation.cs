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
        IList<CampDTO> SearchCamp(DateTime? checkIn, DateTime? checkOut);
        BookingDTO LatestBooking();
        bool DeleteBooking(string bookingNo);
    }
}
