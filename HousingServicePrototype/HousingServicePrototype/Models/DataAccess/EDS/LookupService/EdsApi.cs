using HousingServicePrototype.Models.DataAccess.EDS.LookupService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.LookupService.EDS
{
    /// <summary>
    /// Class representing the EDS Lookup Service API, responsible for sending API requests and handling responses.
    /// </summary>
    class EdsApi
    {        
        /// <summary>
        /// Asynchronously gets the response from the request sent to the EDS Lookup Service API.
        /// </summary>
        /// <param name="request">Representation of the request to send to the EDS Lookup Service API.</param>
        /// <returns>An EDS Lookup Service API response.</returns>
        public async Task<EdsApiResponse> GetResponse(BaseRequest request)
        {
            var responseApi = await SendRequest(request);
            var responseEntry = responseApi;
            return responseEntry;
        }
        
        /// <summary>
        /// Sends a request to the EDS Lookup Service API.
        /// </summary>
        /// <param name="request">Representation of the request to send to the EDS Lookup Service API.</param>
        /// <returns>An EDS Lookup Service API response.</returns>
        private async Task<EdsApiResponse> SendRequest(BaseRequest request)
        {
            // Set up a new API response
            var apiResponse = new EdsApiResponse();

            // Set up a new HTTP client handler and attach credentials for Simple Authentication
            var handler = new HttpClientHandler
            {
                Credentials = new NetworkCredential
                {
                    UserName = ConfigHelper.GetStringValue("EdsLookupApiUserName"),
                    Password = ConfigHelper.GetStringValue("EdsLookupApiPassword")
                }
            };

            // Set up a new HTTP client and begin work
            using (var client = new HttpClient(handler))
            {
                // Set up base address and headers for the expected response from the EDS Lookup Service API.
                client.BaseAddress = request.ServiceUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));                

                // Wait for a response from the service
                var response = await client.GetAsync(request.RequestUrl);                

                // If the response reports a success then do work
                if (response.IsSuccessStatusCode)
                {
                    // Prepare a JSON formatter for the response content
                    var formatters = new List<MediaTypeFormatter>
                    {
                        new JsonMediaTypeFormatter()
                    };

                    // Set up the response with the returned content and return it
                    apiResponse.Success = true;                    
                    apiResponse.Person = await response.Content.ReadAsAsync<Person>(formatters);
                    return apiResponse;
                }

                // Otherwise, there was a problem so capture the error message
                apiResponse.Success = false;
                apiResponse.ErrorMessage = string.Format("Error occurred, the status code is {0}", response.StatusCode);
                apiResponse.Person = null;
                return apiResponse;
            }
        }
    }
}
