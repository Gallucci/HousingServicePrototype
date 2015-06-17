using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.EDS.PersonService.DTO
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    class DataMappingAttribute : System.Attribute
    {
        public string PropertyName { get; set; }
        public string AttributeName { get; set; }

        public DataMappingAttribute(string attributeName)
        {
            AttributeName = attributeName;
        }
    }
}
