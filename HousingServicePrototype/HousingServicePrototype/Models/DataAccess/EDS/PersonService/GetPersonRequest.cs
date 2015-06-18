using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.EDS.PersonService
{
    /// <summary>
    /// Represents a request to be sent to the Person Service API.
    /// </summary>
    class GetPersonRequest : BaseRequest
    {
        /// <summary>
        /// Represents a request to be sent to the Person Service API.
        /// </summary>
        /// <param name="builder">A request builder to build the GetPerson request for the Person Service API.</param>
        private GetPersonRequest(GetPersonRequestBuilder builder) : base(builder) { }

        /// <summary>
        /// Class that builds GetPerson requests for the Person Service API
        /// </summary>
        internal sealed class GetPersonRequestBuilder : BaseRequestBuilder
        {
            // Implementation-specific properties

            /// <summary>
            /// Contains any parameters that should be included with the request.
            /// </summary>
            private IDictionary<string, string> QueryParameters { get; set; }

            /// <summary>
            /// Constructs a builder for building a request for the EDS Lookup Service API
            /// </summary>
            /// <param name="serviceScheme">The scheme of the service URL.</param>
            /// <param name="serviceHost">The host of the service URL.</param>
            /// <param name="servicePath">The path of the service URL.</param>
            public GetPersonRequestBuilder(string serviceScheme, string serviceHost, string servicePath)
                : base(serviceScheme, serviceHost, servicePath)
            {
                Initalize();
            }

            /// <summary>
            /// Initializes any variables shared among object constructors.
            /// </summary>
            private void Initalize()
            {
                QueryParameters = new Dictionary<string, string>();
            }

            /// <summary>
            /// Adds search criteria to the request.
            /// </summary>
            /// <param name="key">Name of the field or property to which the search will be keyed.</param>
            /// <param name="value">The value of the field or property to which the search will match based on the key.</param>
            /// <returns>A GetPerson request builder with the updated property.</returns>
            public GetPersonRequestBuilder SearchByStudentId(string value)
            {
                QueryParameters.Clear();
                IOHelper.AddOrUpDate(QueryParameters, "emplId", value);
                return this;
            }

            /// <summary>
            /// Indicates the request to the EDS Person Service will search by NetID
            /// </summary>
            /// <param name="value">The NetId to use in the search.</param>
            /// <returns>A GetPerson request builder with the updated property.</returns>
            public GetPersonRequestBuilder SearchByNetId(string value)
            {
                QueryParameters.Clear();
                IOHelper.AddOrUpDate(QueryParameters, "uid", value);
                return this;
            }

            /// <summary>
            /// Indicates the request to the EDS Person Service will search by EmplID
            /// </summary>
            /// <param name="value">The EmplID to use in the search.</param>
            /// <returns>A GetPerson request builder with the updated property.</returns>
            public GetPersonRequestBuilder SearchByEmplId(string value)
            {
                QueryParameters.Clear();
                IOHelper.AddOrUpDate(QueryParameters, "emplId", value);
                return this;
            }

            /// <summary>
            /// Indicates the request to the EDS Person Service will search by UAID
            /// </summary>
            /// <param name="value">The UAID to use in the search.</param>
            /// <returns>A GetPerson request builder with the updated property.</returns>
            public GetPersonRequestBuilder SearchByUaId(string value)
            {
                QueryParameters.Clear();
                IOHelper.AddOrUpDate(QueryParameters, "uaid", value);
                return this;
            }

            /// <summary>
            /// Builds the EDS Person Service request URI.
            /// </summary>
            /// <returns>A request URI that contains information for making a request of the EDS Person Service API.</returns>
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
