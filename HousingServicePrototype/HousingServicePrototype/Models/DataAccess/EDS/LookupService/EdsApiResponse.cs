using HousingServicePrototype.Models.DataAccess.EDS.LookupService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.LookupService.EDS
{
    /// <summary>
    /// Represents the response returned by the EDS Lookup Service API.
    /// </summary>
    class EdsApiResponse
    {
        /// <summary>
        /// Represents the response returned by the EDS Lookup Service API.
        /// </summary>
        public EdsApiResponse() {}

        /// <summary>
        /// Indicates if the request received a successful response.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Contains the response content in the form of a EDS Lookup Service Person DTO.
        /// </summary>
        public Person Person { get; set; }

        /// <summary>
        /// Error message received if the response was not successful.
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
