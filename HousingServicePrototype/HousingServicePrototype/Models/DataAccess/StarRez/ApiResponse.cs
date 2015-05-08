using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess
{
    class ApiResponse
    {
        public bool Success { get; set; }
        public IEnumerable<Entry> Entries { get; set; }
        public string ErrorMessage { get; set; }
    }
}
