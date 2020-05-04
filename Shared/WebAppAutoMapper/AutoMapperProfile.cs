using AutoMapper;
using DataAccess.Entities;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.WebAppAutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Camp, CampDTO>();
            CreateMap<CampDTO, Camp>();
            CreateMap<BookingDetail, BookingDTO>();
            CreateMap<BookingDTO, BookingDetail>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();


        }
    }
}
