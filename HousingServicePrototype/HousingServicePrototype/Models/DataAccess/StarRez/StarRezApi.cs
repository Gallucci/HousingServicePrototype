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
    class StarRezApi
    {
        public async Task<StarRezApiResponse> GetResponse(BaseRequest request)
        {
            var responseApi = await SendRequest(request);
            var responseEntry = responseApi;
            return responseEntry;
        }

        private async Task<StarRezApiResponse> SendRequest(BaseRequest request)
        {
            var apiResponse = new StarRezApiResponse();
            var handler = new HttpClientHandler
            {
                Credentials = new NetworkCredential
                {
                    UserName = ConfigHelper.GetStringValue("StarRezApiUserName"),
                    Domain = ConfigHelper.GetStringValue("StarRezApiDomain"),
                    Password = ConfigHelper.GetStringValue("StarRezApiPassword")
                }
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = request.ServiceUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                var response = await client.GetAsync(request.RequestUrl);

                if(response.IsSuccessStatusCode)
                {
                    var formatters = new List<MediaTypeFormatter>
                    {
                        new JsonMediaTypeFormatter()
                    };
                    apiResponse.Success = true;
                    apiResponse.Entries = await response.Content.ReadAsAsync<List<Entry>>(formatters);
                    return apiResponse;
                }

                apiResponse.Success = false;
                apiResponse.ErrorMessage = string.Format("Error occurred, the status code is {0}", response.StatusCode);
                apiResponse.Entries = new List<Entry>();

                return apiResponse;
            }
        }
    }
}
