using HousingServicePrototype.Models.DataAccess.StarRez.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.StarRez
{
    /// <summary>
    /// Represents the response returned by the StarRez API.
    /// </summary>
    class StarRezApiResponse
    {
        /// <summary>
        /// Represents the response returned by the StarRez API.
        /// </summary>
        public StarRezApiResponse()
        {
            Entries = new List<Entry>();
        }

        /// <summary>
        /// Indicates if the request received a successful response.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Contains the response content in the form of a StarRez Entry DTO.
        /// </summary>
        public IEnumerable<Entry> Entries { get; set; }

        /// <summary>
        /// Error message received if the response was not successful.
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
