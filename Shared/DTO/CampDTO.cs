using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class CampDTO
    {
        public int CampId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Price { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public string ImageURL { get; set; }

        public static implicit operator CampDTO(Camp camp)
        {
            return new CampDTO
            {
                CampId = camp.CampId,
                Name = camp.Name,
                Capacity = camp.Capacity,
                Price = camp.Price,
                Location = camp.Location,
                Description = camp.Description,
                Rating = camp.Rating,
                ImageURL=camp.ImageURL
            };
        }

        public static implicit operator Camp(CampDTO vm)
        {
            return new Camp
            {
                CampId = vm.CampId,
                Name = vm.Name,
                Capacity = vm.Capacity,
                Price = vm.Price,
                Location = vm.Location,
                Description = vm.Description,
                Rating=vm.Rating,
                ImageURL=vm.ImageURL
            };
        }
    }

}
