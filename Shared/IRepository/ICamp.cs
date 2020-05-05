using DataAccess;
using Shared.DTO;
using System.Collections.Generic;

namespace Shared.IRepository
{
    public interface ICamp
    {
        /// <summary>
        /// Get all camps
        /// </summary>
        /// <returns></returns>
        IList<CampDTO> GetAllCamps();

        /// <summary>
        /// Get camp by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CampDTO GetCamp(int id);

        /// <summary>
        /// Used to add camp
        /// </summary>
        /// <param name="camp"></param>
        void AddCamp(CampDTO camp);

        /// <summary>
        /// Delete Camp 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteCamp(int id);

        /// <summary>
        /// Update Camp Detail
        /// </summary>
        /// <param name="id"></param>
        /// <param name="camp"></param>
        /// <returns></returns>
        bool UpdateCamp(int id, CampDTO camp);
    }
}
