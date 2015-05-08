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
        public async Task<ApiResponse> GetEntry(string studentId)
        {
            var responseApi = await SendRequest(string.Format("Select/Entry/?ID1={0}", studentId));
            var responseEntry = responseApi;
            return responseEntry;
        }

        private async Task<ApiResponse> SendRequest(string urlCommand)
        {
            var apiResponse = new ApiResponse();
            var handler = new HttpClientHandler
            {
                Credentials = new NetworkCredential
                {
                    UserName = "ResLife-SRAPI",
                    Domain = "catnet.arizona.edu",
                    Password = "uIO61jCM2QPVcYnUpngf"
                }
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri("https://myuahome.life.arizona.edu/StarRezREST/services/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                var response = await client.GetAsync(urlCommand);

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
