using HousingServicePrototype.Models.DataAccess.StarRez.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.StarRez
{
    class StarRezApiResponse
    {
        public StarRezApiResponse()
        {
            Entries = new List<Entry>();
        }

        public bool Success { get; set; }
        public IEnumerable<Entry> Entries { get; set; }
        public string ErrorMessage { get; set; }
    }
}
