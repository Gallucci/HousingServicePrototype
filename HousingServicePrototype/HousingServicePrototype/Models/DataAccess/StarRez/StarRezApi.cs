using HousingServicePrototype.Models.DataAccess.StarRez;
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
        public async Task<ApiResponse> GetEntry(string name, string value)
        {
            var StarRezApiScheme = ConfigHelper.GetStringValue("StarRezApiScheme");
            var StarRezApiHost = ConfigHelper.GetStringValue("StarRezApiHost");
            var StarRezApiPath = ConfigHelper.GetStringValue("StarRezApiPath");

            var starRezGetRequest = new GetEntryRequest.RequestBuilder(StarRezApiScheme, StarRezApiHost, StarRezApiPath)
                .AddSearchCriteria(name, value)
                .IncludeEntryAddressTable()
                .IncludeEntryDetailsTable()
                .Build();

            var responseApi = await SendRequest(starRezGetRequest);
            var responseEntry = responseApi;
            return responseEntry;
        }

        private async Task<ApiResponse> SendRequest(GetEntryRequest request)
        {
            var apiResponse = new ApiResponse();
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
                var response = await client.GetAsync(request.CommandUrl);

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
