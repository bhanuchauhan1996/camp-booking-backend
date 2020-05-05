using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.IRepository
{
    public interface IAuthentication
    {
        /// <summary>
        /// This method checks the username and password during authentication
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserDTO Login(string username, string password);
    }
}
