using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess
{    
    [DataContract]
    class Entry
    {
        // Id
        [DataMember(Name = "EntryId")]
        public string Id { get; set; }
        
        // StudentId
        [DataMember(Name = "Id1")]
        public string EmplId { get; set; }

        // NetId
        [DataMember(Name = "Id2")]
        public string NetId { get; set; }

        // Title
        [DataMember(Name = "NameTitle")]
        public string Title { get; set; }

        // First Name
        [DataMember(Name = "NameFirst")]
        public string FirstName { get; set; }

        // Middle Name?
        [DataMember(Name = "NameOther")]
        public string MiddleName { get; set; }

        // Last Name
        [DataMember(Name = "NameLast")]
        public string LastName { get; set; }

        // Preferred First Name
        [DataMember(Name = "NamePreferred")]
        public string PreferredFirstName { get; set; }

        // Web Screen Name        
        [DataMember(Name = "NameWeb")]
        public string WebScreenName { get; set; }

        // Initials
        [DataMember(Name = "NameInitials")]
        public string Initials { get; set; }

        // Gender
        [DataMember(Name = "GenderEnum")]
        public string Gender { get; set; }

        // Birth Gender
        [DataMember(Name = "Birth_GenderEnum")]
        public string BirthGender { get; set; }

        // Birthdate
        [DataMember(Name = "DOB")]
        public DateTime? Birthdate { get; set; }

        // Age (calculated)
        public int Age 
        { 
            get 
            {
                int age = 0;

                if (Birthdate.HasValue)
                {
                    DateTime now = DateTime.Today;
                    age = now.Year - (Birthdate.Value).Year;
                    if (now < (Birthdate.Value).AddYears(age)) age--;
                }

                return age;
            } 
        }

        // Door Access Code
        [DataMember(Name = "Id3")]
        public string DoorAccessCode { get; set; }

        // PIN
        [DataMember(Name = "PinNumber")]
        public string Pin { get; set; }

        // CatCard Number
        [DataMember(Name = "Id4")]
        public string CatCardNumber { get; set; }

        // Unsure
        [DataMember(Name = "Id5")]
        public string Id5 { get; set; }
    }
}
