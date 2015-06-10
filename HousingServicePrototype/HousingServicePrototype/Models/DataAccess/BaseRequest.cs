using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess
{
    abstract class BaseRequest
    {
        protected BaseRequest(BaseRequestBuilder builder)
        {
            ServiceUrl = builder.ServiceUrl;
            RequestUrl = builder.RequestUrl;
        }

        public virtual Uri ServiceUrl { get; set; }
        public virtual Uri RequestUrl { get; set; }
    }
}
