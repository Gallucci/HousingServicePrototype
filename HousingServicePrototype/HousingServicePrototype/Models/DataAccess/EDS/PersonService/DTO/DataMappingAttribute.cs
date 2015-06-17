using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.EDS.PersonService.DTO
{
    /// <summary>
    /// Attribute that marks a property to be mapped to an attribute of the specified name, similar to the DataMember attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    class DataMappingAttribute : System.Attribute
    {
        /// <summary>
        /// The name of the attribute to which this property will be mapped
        /// </summary>
        public string AttributeName { get; set; }

        /// <summary>
        /// Constructor for the DataMapping attribute, which marks a property to be mapped to an attribute of the specified name, similar to the DataMember attribute.
        /// </summary>
        /// <param name="attributeName">Name of the attribute to which this property will be mapped.</param>
        public DataMappingAttribute(string attributeName)
        {
            AttributeName = attributeName;
        }
    }
}
