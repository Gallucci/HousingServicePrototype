using HousingServicePrototype.Models.DataAccess.StarRez;
using HousingServicePrototype.Models.DataAccess.StarRez.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace HousingServicePrototype.Models.DataAccess
{
    /// <summary>
    /// Class representing the StarRez API, responsible for sending API requests and handling responses.
    /// </summary>
    class StarRezApi
    {
        /// <summary>
        /// Asynchronously gets the response from the request sent to the StarRez API.
        /// </summary>
        /// <param name="request">Representation of the request to send to the StarRez API.</param>
        /// <returns>A StarRez API response.</returns>
        public async Task<StarRezApiResponse> GetResponse(BaseRequest request)
        {
            var responseApi = await SendRequest(request);
            var responseEntry = responseApi;
            return responseEntry;
        }

        /// <summary>
        /// Sends a request to the StarRez API.
        /// </summary>
        /// <param name="request">Representation of the request to send to the StarRez API.</param>
        /// <returns>A StarRez API response.</returns>
        private async Task<StarRezApiResponse> SendRequest(BaseRequest request)
        {
            // Set up a new API response
            var apiResponse = new StarRezApiResponse();

            // Set up a new HTTP client handler and attach credentials for Simple Authentication with Domain
            var handler = new HttpClientHandler
            {
                Credentials = new NetworkCredential
                {
                    UserName = ConfigHelper.GetStringValue("StarRezApiUserName"),
                    Domain = ConfigHelper.GetStringValue("StarRezApiDomain"),
                    Password = ConfigHelper.GetStringValue("StarRezApiPassword")
                }
            };

            // Set up a new HTTP client and begin work
            using (var client = new HttpClient(handler))
            {
                // Set up base address and headers for the expected response from the StarRez API.
                client.BaseAddress = request.ServiceUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Wait for a response from the service (HTTP GET)
                var response = await client.GetAsync(request.RequestUrl);

                // If the response reports a success then do work
                if(response.IsSuccessStatusCode)
                {
                    // Prepare a JSON formatter for the response content
                    var formatters = new List<MediaTypeFormatter>
                    {
                        new JsonMediaTypeFormatter()
                    };

                    // Set up the response with the returned content, format it, and return it
                    apiResponse.Success = true;
                    apiResponse.Entries = await response.Content.ReadAsAsync<List<Entry>>(formatters);
                    return apiResponse;
                }

                // Otherwise, there was a problem so capture the error message
                apiResponse.Success = false;
                apiResponse.ErrorMessage = string.Format("Error occurred, the status code is {0}", response.StatusCode);
                apiResponse.Entries = new List<Entry>();
                return apiResponse;
            }
        }
    }
}
