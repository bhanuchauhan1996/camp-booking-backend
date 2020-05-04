using DataAccess.Entities;
using Shared.DTO;
using Shared.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class OperationRepo : IOperation
    {
        private CampDBEntities dBEntities;

        public OperationRepo()
        {
            dBEntities = new CampDBEntities();
        }
        public bool DeleteBooking(string bookingNo)
        {
            var entity = dBEntities.BookingDetails.FirstOrDefault(o => o.BookingNo == bookingNo);
            if (entity == null)
            {
                return false;
            }
            else
            {
                dBEntities.BookingDetails.Remove(entity);
                dBEntities.SaveChanges();
                return true;
            }
        }

        public BookingDTO LatestBooking()
        {
            int id = dBEntities.BookingDetails.Max(x => x.OrderId);
            BookingDTO bookingDTO = AutoMapper.Mapper.Map<BookingDTO>(dBEntities.BookingDetails.FirstOrDefault(myid => myid.OrderId == id));
            return bookingDTO;
        }

        public IList<CampDTO> SearchCamp(DateTime? checkIn, DateTime? checkOut)
        {
            
            var camps = dBEntities.spSearch(checkIn, checkOut);
            return camps.Select(x => new CampDTO
            {
                CampId = x.CampId,
               Name = x.Name,
               Capacity=x.Capacity,
                Price = x.Price,
                Location=x.Location,
                Description=x.Description,
                Rating=x.Rating,
                ImageURL=x.ImageURL
                
            }).ToList();
        }
    }
}
