using HousingServicePrototype.Models.DataAccess.EDS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.EDS
{
    class EdsApi
    {        
        //public async Task<EdsApiResponse> GetResponse(string request)
        public async Task<EdsApiResponse> GetResponse(BaseRequest request)
        {
            var responseApi = await SendRequest(request);
            var responseEntry = responseApi;
            return responseEntry;
        }
        
        //private async Task<EdsApiResponse> SendRequest(string request)
        private async Task<EdsApiResponse> SendRequest(BaseRequest request)
        {
            var apiResponse = new EdsApiResponse();
            var handler = new HttpClientHandler
            {
                Credentials = new NetworkCredential
                {
                    UserName = ConfigHelper.GetStringValue("EdsApiUserName"),                    
                    Password = ConfigHelper.GetStringValue("EdsApiPassword")
                }
            };

            using (var client = new HttpClient(handler))
            {                
                //client.BaseAddress = new Uri("https://siaapps.uits.arizona.edu/home/web_services/edsLookup/");
                client.BaseAddress = request.ServiceUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));                

                // HTTP GET
                var response = await client.GetAsync(request.RequestUrl);
                //var response = await client.GetAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var formatters = new List<MediaTypeFormatter>
                    {
                        new JsonMediaTypeFormatter()
                    };
                    apiResponse.Success = true;
                    //apiResponse.People = await response.Content.ReadAsAsync<List<Person>>(formatters);
                    apiResponse.Person = await response.Content.ReadAsAsync<Person>(formatters);
                    return apiResponse;
                }

                apiResponse.Success = false;
                apiResponse.ErrorMessage = string.Format("Error occurred, the status code is {0}", response.StatusCode);
                apiResponse.Person = null;
                return apiResponse;
            }
        }
    }
}
