using HousingServicePrototype.Models.DataAccess.EDS.PersonService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.EDS.PersonService
{
    /// <summary>
    /// Represents the response returned by the EDS Person Service API.
    /// </summary>
    class EdsApiResponse
    {
        /// <summary>
        /// Represents the response returned by the EDS Person Service API.
        /// </summary>
        public EdsApiResponse() {}

        /// <summary>
        /// Indicates if the request received a successful response.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Contains the response content in the form of a EDS Person Service Person DTO.
        /// </summary>
        public Person Person { get; set; }

        /// <summary>
        /// Error message received if the response was not successful.
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
