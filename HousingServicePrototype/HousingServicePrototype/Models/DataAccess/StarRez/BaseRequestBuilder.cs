using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.StarRez
{
    abstract class BaseRequestBuilder
    {
        public string ServiceScheme { get; set; }
        public string ServiceHost { get; set; }
        public string ServicePath { get; set; }
        public Uri ServiceUrl { get; set; }
        public Uri RequestUrl { get; set; }

        protected BaseRequestBuilder()
        {
            ServiceScheme = ConfigHelper.GetStringValue("StarRezApiScheme");
            ServiceHost = ConfigHelper.GetStringValue("StarRezApiHost");
            ServicePath = ConfigHelper.GetStringValue("StarRezApiPath");
            ServiceUrl = new UriBuilder() { Scheme = ServiceScheme, Host = ServiceHost, Path = ServicePath }.Uri;
        }

        protected BaseRequestBuilder(string serviceScheme, string serviceHost, string servicePath)
        {
            ServiceScheme = serviceScheme;
            ServiceHost = serviceHost;
            ServicePath = servicePath;
            ServiceUrl = new UriBuilder() { Scheme = ServiceScheme, Host = ServiceHost, Path = ServicePath }.Uri;
        }        
    }
}
