using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HousingServicePrototype.Models.DataAccess.EDS.PersonService.DTO
{
    [XmlRoot("dsml", Namespace="http://www.dsml.org/DSML")]
    public class DsmlEntry
    {
        [XmlElement(ElementName = "directory-entries")]
        public DirectoryEntry DirectoryEntry { get; set; }
    }

    public class DirectoryEntry
    {
        [XmlArray(ElementName = "entry")]
        [XmlArrayItem("attr", typeof(Attribute))]
        public Attribute[] EntryAttributes { get; set; }

    }

    public class Attribute
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "value")]        
        public string[] Value { get; set; }
    }
}

