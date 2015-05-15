using HousingServicePrototype.Models.DataAccess.StarRez;
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
        public Entry()
        {
            Details = new List<EntryDetail>();
            Addresses = new List<EntryAddress>();
            Bookings = new List<EntryBooking>();
            Applications = new List<EntryApplication>();
        }

        // Id
        [DataMember(Name = "EntryId")]
        public int Id { get; set; }
        
        [DataMember(Name = "CategoryID")]
        public int CategoryId { get; set; }
        
        [DataMember(Name = "EventID")]
        public int EventId { get; set; }
        
        [DataMember(Name = "GroupID")]
        public int GroupId { get; set; }
        
        [DataMember(Name = "ContactID")]
        public int ContactId { get; set; }
        
        [DataMember(Name = "EntryStatusEnum")]
        public string EntryStatus { get; set; }
        
        [DataMember(Name = "AddressTypeID")]
        public int AddressTypeId { get; set; }
        
        [DataMember(Name = "BookingID")]
        public int BookingId { get; set; }
        
        [DataMember(Name = "EntryApplicationID")]
        public int EntryApplicationId { get; set; }

        // PIN
        [DataMember(Name = "PinNumber")]
        public string Pin { get; set; }

        [DataMember(Name = "Password")]
        public string Password { get; set; }

        [DataMember(Name = "PortalEmail")]
        public string PortalEmail { get; set; }

        // Last Name
        [DataMember(Name = "NameLast")]
        public string LastName { get; set; }

        // First Name
        [DataMember(Name = "NameFirst")]
        public string FirstName { get; set; }                

        // Title
        [DataMember(Name = "NameTitle")]
        public string Title { get; set; }

        // Preferred First Name
        [DataMember(Name = "NamePreferred")]
        public string PreferredFirstName { get; set; }

        // Web Screen Name        
        [DataMember(Name = "NameWeb")]
        public string WebScreenName { get; set; }

        // Middle Name?
        [DataMember(Name = "NameOther")]
        public string MiddleName { get; set; }

        // Initials
        [DataMember(Name = "NameInitials")]
        public string Initials { get; set; }
        
        [DataMember(Name = "NameSharer")]
        public string NameSharer { get; set; }

        // Gender
        [DataMember(Name = "GenderEnum")]
        public string Gender { get; set; }

        // Birth Gender
        [DataMember(Name = "Birth_GenderEnum")]
        public string BirthGender { get; set; }
        
        [DataMember(Name = "DirectoryFlagPrivacy")]
        public bool HasDirectoryFlagPrivacy { get; set; }

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
        
        [DataMember(Name = "Position")]
        public string Position { get; set; }

        // StudentId
        [DataMember(Name = "Id1")]
        public string EmplId { get; set; }

        // NetId
        [DataMember(Name = "Id2")]
        public string NetId { get; set; }                                
        
        // Door Access Code
        [DataMember(Name = "Id3")]
        public string DoorAccessCode { get; set; }        

        // CatCard Number
        [DataMember(Name = "Id4")]
        public string CatCardNumber { get; set; }

        // Unsure
        [DataMember(Name = "Id5")]
        public string Id5 { get; set; }

        [DataMember(Name = "PhoneProcessToAccount")]
        public bool IsPhoneProcessToAccount { get; set; }
        
        [DataMember(Name = "PhoneChargeTypeID")]
        public int PhoneChargeTypeId { get; set; }
        
        [DataMember(Name = "PhoneDisableValue")]
        public int PhoneDisableValue { get; set; }
        
        [DataMember(Name = "PhoneRestrictValue")]
        public int PhoneRestrictValue { get; set; }
        
        [DataMember(Name = "PhoneControlEnum")]
        public string PhoneControl { get; set; }
        
        [DataMember(Name = "TaxExemptionEnum")]
        public string TaxExemption { get; set; }
        
        [DataMember(Name = "LastCheckInOutDate")]
        public DateTime? LastCheckInOutDate { get; set; }
        
        [DataMember(Name = "Previous_EntryStatusEnum")]
        public string PreviousEntryStatus { get; set; }
        
        [DataMember(Name = "Testing")]
        public bool IsTesting { get; set; }
        
        [DataMember(Name = "User_SecurityUserID")]
        public int UserSecurityUserId { get; set; }
        
        [DataMember(Name = "SecurityUserID")]
        public int SecurityUserId { get; set; }
        
        [DataMember(Name = "CreatedBy_SecurityUserID")]
        public int CreatedBySecurityUserId { get; set; }
        
        [DataMember(Name = "DateModified")]
        public DateTime? DateModified { get; set; }
        
        [DataMember(Name = "DateCreated")]
        public DateTime? DateCreated { get; set; }        

        // Entry Addresses
        [DataMember(Name = "EntryAddress")]
        public IList<EntryAddress> Addresses { get; set; }

        // Entry Details
        [DataMember(Name = "EntryDetail")]
        public IList<EntryDetail> Details { get; set; }

        // Entry Bookings
        [DataMember(Name = "Booking")]
        public IList<EntryBooking> Bookings { get; set; }

        // Entry Applications
        [DataMember(Name = "EntryApplication")]
        public IList<EntryApplication> Applications { get; set; }
    }
}
