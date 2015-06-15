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
    class EdiApi
    {        
        public async Task<EdsApiResponse> GetResponse(BaseRequest request)
        {
            var responseApi = await SendRequest(request);
            var responseEntry = responseApi;
            return responseEntry;
        }
        
        private async Task<EdsApiResponse> SendRequest(BaseRequest request)
        {
            var apiResponse = new EdsApiResponse();
            var handler = new HttpClientHandler
            {
                Credentials = new NetworkCredential
                {
                    UserName = ConfigHelper.GetStringValue("EdsPersonApiUserName"),
                    Password = ConfigHelper.GetStringValue("EdsPersonApiPassword")
                }
            };

            using (var client = new HttpClient(handler))
            {                
                client.BaseAddress = request.ServiceUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));

                // HTTP GET
                var response = await client.GetAsync(request.RequestUrl);                

                if (response.IsSuccessStatusCode)
                {
                    var formatters = new List<MediaTypeFormatter>
                    {
                        new XmlMediaTypeFormatter() {UseXmlSerializer = true}
                    };
                    apiResponse.Success = true;                    
                    apiResponse.Person = await response.Content.ReadAsAsync<DsmlEntry>(formatters);
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
