using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.EDS.PersonService
{
    class GetPersonRequest : BaseRequest
    {
        // Request
        private GetPersonRequest(GetPersonRequestBuilder builder) : base(builder) { }

        // Request Builder
        internal sealed class GetPersonRequestBuilder : BaseRequestBuilder
        {
            // Implementation-specific properties            
            private IDictionary<string, string> QueryParameters { get; set; }

            public GetPersonRequestBuilder(string serviceScheme, string serviceHost, string servicePath)
                : base(serviceScheme, serviceHost, servicePath)
            {
                Initalize();
            }

            private void Initalize()
            {
                QueryParameters = new Dictionary<string, string>();
            }

            public GetPersonRequestBuilder SearchByStudentId(string value)
            {
                QueryParameters.Clear();
                IOHelper.AddOrUpDate(QueryParameters, "emplId", value);
                return this;
            }

            public GetPersonRequestBuilder SearchByNetId(string value)
            {
                QueryParameters.Clear();
                IOHelper.AddOrUpDate(QueryParameters, "uid", value);
                return this;
            }

            public GetPersonRequestBuilder SearchByEmplId(string value)
            {
                QueryParameters.Clear();
                IOHelper.AddOrUpDate(QueryParameters, "emplId", value);
                return this;
            }

            public GetPersonRequestBuilder SearchByUaId(string value)
            {
                QueryParameters.Clear();
                IOHelper.AddOrUpDate(QueryParameters, "uaid", value);
                return this;
            }

            public BaseRequest Build()
            {
                // Format the parameters into URL-friendly query parameters                
                foreach (var parameter in QueryParameters)
                {
                    // Append the select elements to the path
                    if (ServicePath.EndsWith("/"))
                        ServicePath += string.Format("{0}", parameter.Value);
                    else
                        ServicePath += string.Format("/{0}", parameter.Value);
                }

                // Construct the URI
                UriBuilder uriBuilder = new UriBuilder()
                {
                    Scheme = ServiceScheme,
                    Host = ServiceHost,
                    Path = ServicePath
                };

                // Set the URI property
                RequestUrl = uriBuilder.Uri;

                // Return the constructed Service Uri
                return new GetPersonRequest(this);
            }
        }
    }
}
