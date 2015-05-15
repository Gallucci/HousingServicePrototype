using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.StarRez
{
    abstract class BaseRequest
    {
        public virtual string ServiceScheme { get; set; }
        public virtual string ServiceHost { get; set; }
        public virtual string ServicePath { get; set; }
        public virtual Uri ServiceUrl { get; set; }
        public virtual Uri RequestUrl { get; set; }
    }
}
