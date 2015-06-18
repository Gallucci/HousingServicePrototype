using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HousingServicePrototype.Models.DataAccess.StarRez
{
    /// <summary>
    /// Represents a request to be sent to the StarRez API.
    /// </summary>
    class GetEntryRequest : BaseRequest
    {
        /// <summary>
        /// Represents a request to be sent to the Lookup Service API
        /// </summary>
        /// <param name="builder">A request builder to build the GetEntry request for the StarRez API.</param>
        private GetEntryRequest(GetEntryRequestBuilder builder) : base(builder) { }

        /// <summary>
        /// Class that builds GetEntry requests for the StarRez API
        /// </summary>
        internal sealed class GetEntryRequestBuilder : BaseRequestBuilder
        {
            // Implementation-specific properties

            /// <summary>
            /// Contains any related tables that should be included with the response in addition to the Entry table.
            /// </summary>
            private IList<string> RelatedTables { get; set; }

            /// <summary>
            /// Contains any parameters that should be included with the request.
            /// </summary>
            private IDictionary<string, string> QueryParameters { get; set; }

            /// <summary>
            /// Constructs a builder for building a request for the StarRez API
            /// </summary>
            /// <param name="serviceScheme">The scheme of the service URL.</param>
            /// <param name="serviceHost">The host of the service URL.</param>
            /// <param name="servicePath">The path of the service URL.</param>
            public GetEntryRequestBuilder(string serviceScheme, string serviceHost, string servicePath)
                : base(serviceScheme, serviceHost, servicePath)
            {
                Initalize();
            }

            /// <summary>
            /// Initializes any variables shared among object constructors.
            /// </summary>
            private void Initalize()
            {
                RelatedTables = new List<string>();
                QueryParameters = new Dictionary<string, string>();
            }

            /// <summary>
            /// Adds search criteria to the request.
            /// </summary>
            /// <param name="key">Name of the field or property to which the search will be keyed.</param>
            /// <param name="value">The value of the field or property to which the search will match based on the key.</param>
            /// <returns></returns>
            public GetEntryRequestBuilder AddSearchCriteria(string key, string value)
            {
                IOHelper.AddOrUpDate(QueryParameters, key, value);
                return this;
            }

            /// <summary>
            /// Indicates in the request how many records the API response should return when there are multiple entries returned.
            /// </summary>
            /// <param name="value">The maximum number records to return.</param>
            /// <returns>A GetEntry request builder with the updated property.</returns>
            public GetEntryRequestBuilder SetTopNumberOfRecords(int value)
            {                
                IOHelper.AddOrUpDate(QueryParameters, "_top", value.ToString());
                return this;
            }

            /// <summary>
            /// Indicates in the request if the API response should include information from the Address table.
            /// </summary>
            /// <returns>A GetEntry request builder with the updated property.</returns>
            public GetEntryRequestBuilder IncludeAddressTable()
            {
                RelatedTables.Add("EntryAddress");
                return this;
            }

            /// <summary>
            /// Indicates in the request if the API response should include information from the Details table.
            /// </summary>
            /// <returns>A GetEntry request builder with the updated property.</returns>
            public GetEntryRequestBuilder IncludeDetailsTable()
            {
                RelatedTables.Add("EntryDetail");
                return this;
            }

            /// <summary>
            /// Indicates in the request if the API response should include information from the Booking table.
            /// </summary>
            /// <returns>A GetEntry request builder with the updated property.</returns>
            public GetEntryRequestBuilder IncludeBookingTable()
            {
                RelatedTables.Add("Booking");
                return this;
            }

            /// <summary>
            /// Indicates in the request if the API response should include information from the Application table.
            /// </summary>
            /// <returns>A GetEntry request builder with the updated property.</returns>
            public GetEntryRequestBuilder IncludeApplicationTable()
            {
                RelatedTables.Add("EntryApplication");
                return this;
            }

            /// <summary>
            /// Builds the StarRez request URI.
            /// </summary>
            /// <returns>A request URI that contains information for making a request of the StarRez API.</returns>
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
