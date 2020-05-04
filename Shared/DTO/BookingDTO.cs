using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
   public class BookingDTO
    {
        public int OrderId { get; set; }
        public int CampId { get; set; }
        public int TotalDays { get; set; }
        public string ContactNo { get; set; }
        public System.DateTime CheckIn { get; set; }
        public System.DateTime CheckOut { get; set; }
        public string BillAddress { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZIP { get; set; }
        public int Amount { get; set; }
        public string BookingNo { get; set; }
        

        public static implicit operator BookingDTO(BookingDetail bookingDetail)
        {
            return new BookingDTO
            {
                OrderId = bookingDetail.OrderId,
                CampId = bookingDetail.CampId,
                TotalDays = bookingDetail.TotalDays,
                ContactNo = bookingDetail.ContactNo,
                BillAddress = bookingDetail.BillAddress,
                CheckIn = bookingDetail.CheckIn,
                CheckOut=bookingDetail.CheckOut,
                Amount=bookingDetail.Amount,
                BookingNo=bookingDetail.BookingNo,
                State=bookingDetail.State,
                Country=bookingDetail.Country,
                ZIP=bookingDetail.ZIP
            };
        }

        public static implicit operator BookingDetail(BookingDTO bookingDetail)
        {
            return new BookingDetail
            {
                OrderId = bookingDetail.OrderId,
                CampId = bookingDetail.CampId,
                TotalDays = bookingDetail.TotalDays,
                ContactNo = bookingDetail.ContactNo,
                BillAddress = bookingDetail.BillAddress,
                CheckIn = bookingDetail.CheckIn,
                CheckOut = bookingDetail.CheckOut,
                Amount = bookingDetail.Amount,
               // BookingNo = bookingDetail.BookingNo,
                State = bookingDetail.State,
                Country = bookingDetail.Country,
                ZIP = bookingDetail.ZIP
            };
        }
    }
}
