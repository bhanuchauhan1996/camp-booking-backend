using DataAccess;
using Shared.DTO;
using System.Collections.Generic;

namespace Shared.IRepository
{
    public interface ICamp
    {
        IList<CampDTO> GetAllCamps();
        CampDTO GetCamp(int id);
        void AddCamp(CampDTO camp);
        bool DeleteCamp(int id);
        bool UpdateCamp(int id, CampDTO camp);
    }
}
