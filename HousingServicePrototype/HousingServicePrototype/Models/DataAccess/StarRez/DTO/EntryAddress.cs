using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.StarRez.DTO
{
    [DataContract]
    class EntryAddress
    {
        [DataMember(Name="EntryAddressID")]
        public string Id { get; set; }

        [DataMember(Name = "EntryID")]
        public int EntryId { get; set; }

        [DataMember(Name = "AddressTypeID")]
        public int AddressTypeId { get; set; }

        [DataMember(Name = "Salutation")]
        public string Salutation { get; set; }

        [DataMember(Name = "ContactName")]
        public string ContactName { get; set; }

        [DataMember(Name = "Street")]
        public string Street1 { get; set; }

        [DataMember(Name = "Street2")]
        public string Street2 { get; set; }

        [DataMember(Name = "City")]
        public string City { get; set; }

        [DataMember(Name = "CountryID")]
        public int CountryId { get; set; }

        [DataMember(Name = "StateProvince")]
        public string StateProvince { get; set; }

        [DataMember(Name = "ZipPostcode")]
        public string ZipPostCode { get; set; }

        [DataMember(Name = "Phone")]
        public string PrimaryPhone { get; set; }

        [DataMember(Name = "PhoneMobileCell")]
        public string MobilePhone { get; set; }

        [DataMember(Name = "PhoneOther")]
        public string HomePhone { get; set; }

        [DataMember(Name = "PhoneOther2")]
        public string OtherPhone { get; set; }

        [DataMember(Name = "Email")]
        public string ContactEmail { get; set; }

        [DataMember(Name = "Relationship")]
        public string ContactRelationship { get; set; }

        [DataMember(Name = "ActiveDateStart")]
        public DateTime? ActiveStartDate { get; set; }

        [DataMember(Name = "ActiveDateEnd")]
        public DateTime? ActiveEndDate { get; set; }

        [DataMember(Name = "Reference")]
        public string Reference { get; set; }

        [DataMember(Name = "Comments")]
        public string Comments { get; set; }
    }
}
