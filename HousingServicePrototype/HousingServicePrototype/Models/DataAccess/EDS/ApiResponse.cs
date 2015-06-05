using HousingServicePrototype.Models.DataAccess.EDS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.EDS
{
    class ApiResponse
    {
        public ApiResponse()
        {
            People = new List<Person>();
        }

        public bool Success { get; set; }
        public IEnumerable<Person> People { get; set; }
        public string ErrorMessage { get; set; }
    }
}
