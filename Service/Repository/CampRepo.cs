using DataAccess.Entities;
using Shared.DTO;
using Shared.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class CampRepo : ICamp
    {
        private CampDBEntities dBEntities;
        public CampRepo()
        {
            dBEntities = new CampDBEntities();
        }

        public void AddCamp(CampDTO camp)
        {
            dBEntities.Camps.Add(camp);
            dBEntities.SaveChanges();
        }

        public bool DeleteCamp(int id)
        {
            var entity = dBEntities.Camps.FirstOrDefault(c => c.CampId == id);
            if(entity==null)
            {
                return false;
            }
            else
            {
                dBEntities.Camps.Remove(entity);
                dBEntities.SaveChanges();
                return true;
            }
            
        }

        public IList<CampDTO> GetAllCamps()
        {
            IList<CampDTO> campViewModels = null;
            campViewModels = AutoMapper.Mapper.Map<IList<CampDTO>>(dBEntities.Camps.ToList());
            return campViewModels;
        }

        public CampDTO GetCamp(int id)
        {
            CampDTO campViewModel = AutoMapper.Mapper.Map<CampDTO>(dBEntities.Camps.FirstOrDefault(myid => myid.CampId == id));
            return campViewModel;
            
        }

        public bool UpdateCamp(int id, CampDTO camp)
        {
            var entity = dBEntities.Camps.FirstOrDefault(c => c.CampId == id);
            if (entity == null)
            {
                return false;
            }
            else
            {
                entity.Capacity = camp.Capacity;
                entity.Description = camp.Description;
                entity.Location = camp.Location;
                entity.Name = camp.Name;
                entity.Price = camp.Price;
                entity.Rating = camp.Rating;
                entity.ImageURL = camp.ImageURL;
                dBEntities.SaveChanges();
                return true;
            }

        }
    }
}
