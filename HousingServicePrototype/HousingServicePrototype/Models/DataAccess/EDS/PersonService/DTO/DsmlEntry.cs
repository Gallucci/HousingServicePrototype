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
        [XmlElement(ElementName = "entry")]
        public Entry Entry { get; set; }

    }

    public class Entry
    {
        [XmlAttribute(AttributeName = "dn")]
        public string DomainName { get; set; }

        [XmlElement(ElementName = "attr")]
        public Attribute[] Attributes { get; set; }

        [XmlElement(ElementName = "objectclass")]
        public ObjectClass ObjectClass { get; set; }
    }

    public class ObjectClass
    {
        [XmlElement(ElementName = "oc-value")]
        public string[] Values { get; set; }
    }

    public class Attribute
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "value")]        
        public string[] Values { get; set; }
    }
}

