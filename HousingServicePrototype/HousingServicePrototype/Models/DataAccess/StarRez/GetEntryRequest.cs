using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HousingServicePrototype.Models.DataAccess.StarRez
{
    class GetEntryRequest : BaseRequest
    {
        // Implementation-specific properties
        public IList<string> RelatedTables { get; set; }
        
        private GetEntryRequest(RequestBuilder builder) : base()
        {            
            ServiceScheme = builder.ServiceScheme;
            ServiceHost = builder.ServiceHost;
            ServicePath = builder.ServicePath;            
            ServiceUrl = builder.ServiceUrl;
            RequestUrl = builder.RequestUrl;

            RelatedTables = builder.RelatedTables;
        }

        internal sealed class RequestBuilder : BaseRequestBuilder
        {
            // Implementation-specific properties
            public IList<string> RelatedTables { get; set; }
            public IDictionary<string, string> QueryParameters { get; set; }
            
            public RequestBuilder() : base()
            {                
                Initalize();
            }

            public RequestBuilder(string serviceScheme, string serviceHost, string servicePath) : base(serviceScheme, serviceHost, servicePath)
            {
                Initalize();
            }

            private void Initalize()
            {
                RelatedTables = new List<string>();
                QueryParameters = new Dictionary<string, string>();
            }

            public RequestBuilder AddSearchCriteria(string key, string value)
            {
                IOHelper.AddOrUpDate(QueryParameters, key, value);
                return this;
            }

            public RequestBuilder SetTopNumberOfRecords(int value)
            {                
                IOHelper.AddOrUpDate(QueryParameters, "_top", value.ToString());
                return this;
            }
            
            public RequestBuilder IncludeAddressTable()
            {
                RelatedTables.Add("EntryAddress");
                return this;
            }

            public RequestBuilder IncludeDetailsTable()
            {
                RelatedTables.Add("EntryDetail");
                return this;
            }

            public RequestBuilder IncludeBookingTable()
            {
                RelatedTables.Add("Booking");
                return this;
            }

            public RequestBuilder IncludeApplicationTable()
            {
                RelatedTables.Add("EntryApplication");
                return this;
            }

            public BaseRequest Build()
            {

                // Append the select elements to the path
                ServicePath += "Select/Entry/";

                // Include any related tables
                if (RelatedTables.Any())
                    QueryParameters.Add("_relatedtables", string.Join(",", RelatedTables.ToArray()));

                // Format the parameters into URL-friendly query parameters
                var queryParameters = HttpUtility.ParseQueryString(string.Empty);
                foreach (var parameter in QueryParameters)
                {
                    queryParameters.Add(parameter.Key, parameter.Value);
                }

                // Construct the URI
                UriBuilder uriBuilder = new UriBuilder()
                {
                    Scheme = ServiceScheme,
                    Host = ServiceHost,
                    Path = ServicePath,
                    Query = queryParameters.ToString()
                };

                // Set the URI property
                RequestUrl = uriBuilder.Uri;

                // Return the constructed Service Uri
                return new GetEntryRequest(this);
            }
        }
    }
}
