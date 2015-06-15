using HousingServicePrototype.Models.DataAccess.EDS.LookupService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.LookupService.EDS
{
    class EdsApiResponse
    {
        public EdsApiResponse()
        {
            //People = new List<Person>();
        }

        public bool Success { get; set; }
        public Person Person{ get; set; }
        public string ErrorMessage { get; set; }
    }
}
