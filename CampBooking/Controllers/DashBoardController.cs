using Service.Repository;
using Shared.DTO;
using Shared.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CampBooking.Controllers
{
    /// <summary>
    /// This api represent dashboard of application
    /// </summary>
    public class DashBoardController : ApiController
    {
        private IOperation Ioperation;
        public DashBoardController(IOperation Ioperation)
        {
            this.Ioperation = Ioperation;
        }
        public DashBoardController()
        {
            Ioperation = new OperationRepo();
        }

        /// <summary>
        /// Gell all camp by using dates
        /// </summary>
        /// <param name="checkIN"></param>
        /// <param name="checkOut"></param>
        /// <returns></returns>
        public IList<CampDTO> GetAllSearchBooking(DateTime? checkIN=null, DateTime? checkOut=null)
        {
            if (checkIN==null)
            {
                checkIN = DateTime.Today;

            }
            if (checkOut==null)
            {
                checkOut = DateTime.Today.AddDays(1);
            }
            return Ioperation.SearchCamp(checkIN, checkOut);
        }
    }
}
