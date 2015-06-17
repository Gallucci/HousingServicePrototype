using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HousingServicePrototype.Models.DataAccess.EDS.PersonService.DTO
{
    /// <summary>
    /// A DSML Data Transfer Object that holds the DSML returned from a Person Service API request.  This is the root object, and holds references to all other related objects within it.
    /// </summary>
    [XmlRoot("dsml", Namespace="http://www.dsml.org/DSML")]
    public class DsmlEntry
    {
        /// <summary>
        /// The Directory Entry node
        /// </summary>
        [XmlElement(ElementName = "directory-entries")]
        public DirectoryEntry DirectoryEntry { get; set; }
    }

    /// <summary>
    /// Represents a Directory Entry node within the DSML tree
    /// </summary>
    public class DirectoryEntry
    {
        /// <summary>
        /// The Entry node.
        /// </summary>
        [XmlElement(ElementName = "entry")]
        public Entry Entry { get; set; }

    }

    /// <summary>
    /// Represents a Entry node within the DSML tree
    /// </summary>
    public class Entry
    {
        /// <summary>
        /// The domain name as defined in an Entry's DN attribute by the DSML.
        /// </summary>
        [XmlAttribute(AttributeName = "dn")]
        public string DomainName { get; set; }

        /// <summary>
        /// List of attribute nodes.
        /// </summary>
        [XmlElement(ElementName = "attr")]
        public Attribute[] Attributes { get; set; }

        /// <summary>
        /// The object class node.
        /// </summary>
        [XmlElement(ElementName = "objectclass")]
        public ObjectClass ObjectClass { get; set; }
    }

    /// <summary>
    /// Represents an Object Class node within the DSML tree.
    /// </summary>
    public class ObjectClass
    {
        /// <summary>
        /// List of possible values assigned to the object class.
        /// </summary>
        [XmlElement(ElementName = "oc-value")]
        public string[] Values { get; set; }
    }

    /// <summary>
    /// Represents an Attribute node within the DSML tree.
    /// </summary>
    public class Attribute
    {
        /// <summary>
        /// Name of the attribute as specified by the DSML.
        /// </summary>
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// List of possible values assigned to the attribute; always a list even with singular values.
        /// </summary>
        [XmlElement(ElementName = "value")]        
        public string[] Values { get; set; }
    }
}

