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
        UserDTO Login(string username, string password);
    }
}
