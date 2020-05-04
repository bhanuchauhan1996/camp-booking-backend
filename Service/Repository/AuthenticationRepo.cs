using DataAccess.Entities;
using Shared.DTO;
using Shared.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class AuthenticationRepo : IAuthentication
    {
        private CampDBEntities dBEntities;
        public AuthenticationRepo()
        {
            dBEntities = new CampDBEntities();
        }
        public UserDTO  Login(string username, string password)
        {

            UserDTO userDTO = AutoMapper.Mapper.Map<UserDTO>(dBEntities.Users.FirstOrDefault(user =>
                       user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
                                          && user.Password == password));
                return userDTO;

           
        }
    }
}
