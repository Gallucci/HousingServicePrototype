using HousingServicePrototype.Models.DataAccess.EDS.PersonService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.EDS.PersonService
{
    class EdsApiResponse
    {
        public EdsApiResponse() {}

        public bool Success { get; set; }
        public Person Person { get; set; }
        public string ErrorMessage { get; set; }
    }
}
