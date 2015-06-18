using HousingServicePrototype.Models.DataAccess.EDS.PersonService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.EDS.PersonService
{
    /// <summary>
    /// Class representing the EDS Person Service API, responsible for sending API requests and handling responses.
    /// </summary>
    class EdiApi
    {
        /// <summary>
        /// Asynchronously gets the response from the request sent to the EDS Person Service API.
        /// </summary>
        /// <param name="request">Representation of the request to send to the EDS Person Service API.</param>
        /// <returns>An EDS Person Service API response.</returns>
        public async Task<EdsApiResponse> GetResponse(BaseRequest request)
        {
            var responseApi = await SendRequest(request);
            var responseEntry = responseApi;
            return responseEntry;
        }

        /// <summary>
        /// Sends a request to the EDS Person Service API.
        /// </summary>
        /// <param name="request">Representation of the request to send to the EDS Person Service API.</param>
        /// <returns>An EDS Person Service API response.</returns>
        private async Task<EdsApiResponse> SendRequest(BaseRequest request)
        {
            // Set up a new API response
            var apiResponse = new EdsApiResponse();

            // Set up a new HTTP client handler and attach credentials for Simple Authentication
            var handler = new HttpClientHandler
            {
                Credentials = new NetworkCredential
                {
                    UserName = ConfigHelper.GetStringValue("EdsPersonApiUserName"),
                    Password = ConfigHelper.GetStringValue("EdsPersonApiPassword")
                }
            };

            // Set up a new HTTP client and begin work
            using (var client = new HttpClient(handler))
            {
                // Set up base address and headers for the expected response from the EDS Lookup Service API.
                client.BaseAddress = request.ServiceUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));

                // Wait for a response from the service (HTTP GET)
                var response = await client.GetAsync(request.RequestUrl);

                // If the response reports a success then do work
                if (response.IsSuccessStatusCode)
                {
                    // Prepare an XML formatter for the response content
                    var formatters = new List<MediaTypeFormatter>
                    {
                        // Have the formatter use the XmlSerializer instead of the DataContractSerializer, which cannot handle node attributes
                        new XmlMediaTypeFormatter() {UseXmlSerializer = true}
                    };

                    // Mark the response as a success
                    apiResponse.Success = true;

                    // The returned DSML is mapped into the DsmlEntry DTO, but it's not particularly user-friendly
                    var content = await response.Content.ReadAsAsync<DsmlEntry>(formatters);

                    // Create a EDS Person Service Person DTO and pass it the DsmlEntry DTO for mapping
                    apiResponse.Person = new Person(content);

                    // Return the response
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
