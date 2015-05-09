using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HousingServicePrototype.Models.DataAccess.StarRez
{
    class GetEntryRequest
    {
        public string ServiceScheme { get; set; }
        public string ServiceHost { get; set; }
        public string ServicePath { get; set; }        
        public IList<string> RelatedTables { get; set; }
        public Uri ServiceUrl { get; set; }
        public Uri CommandUrl { get; set; }

        private GetEntryRequest(RequestBuilder builder)
        {
            ServiceScheme = builder.ServiceScheme;
            ServiceHost = builder.ServiceHost;
            ServicePath = builder.ServicePath;            
            RelatedTables = builder.RelatedTables;
            ServiceUrl = builder.ServiceUrl;
            CommandUrl = builder.CommandUrl;
        }

        internal sealed class RequestBuilder
        {
            public string ServiceScheme { get; set; }
            public string ServiceHost { get; set; }
            public string ServicePath { get; set; }            
            public IList<string> RelatedTables { get; set; }
            public IDictionary<string, string> QueryParameters { get; set; }
            public Uri ServiceUrl { get; set; }
            public Uri CommandUrl { get; set; }

            public RequestBuilder(string serviceScheme, string serviceHost, string servicePath)
            {
                ServiceScheme = serviceScheme;
                ServiceHost = serviceHost;
                ServicePath = servicePath;

                RelatedTables = new List<string>();
                QueryParameters = new Dictionary<string, string>();

                ServiceUrl = new UriBuilder() { Scheme = serviceScheme, Host = serviceHost, Path = servicePath }.Uri;
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
            
            public RequestBuilder IncludeEntryAddressTable()
            {
                RelatedTables.Add("EntryAddress");
                return this;
            }

            public RequestBuilder IncludeEntryDetailsTable()
            {
                RelatedTables.Add("EntryDetail");
                return this;
            }

            public GetEntryRequest Build()
            {

                // Append the select elements to the path
                ServicePath += "Select/Entry/";

                // Include any related tables
                if (RelatedTables.Count > 0)
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
                CommandUrl = uriBuilder.Uri;

                // Return the constructed Service Uri
                return new GetEntryRequest(this);
            }
        }
    }
}
