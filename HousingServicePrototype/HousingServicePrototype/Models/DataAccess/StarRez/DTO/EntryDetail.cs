using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.StarRez.DTO
{
    [DataContract]
    class EntryDetail
    {
        [DataMember(Name="EntryDetailID")]
        public int Id { get; set; }

        [DataMember(Name="EntryID")]
        public int EntryId { get; set; }

        [DataMember(Name="PhotoPath")]
        public string PhotoPath { get; set; }

        [DataMember(Name="PhotoImage")]
        public string PhotoImage { get; set; }

        [DataMember(Name="StaffID")]
        public int StaffId { get; set; }

        [DataMember(Name="ClassificationID")]
        public int ClassificationId { get; set; }

        [DataMember(Name="AttendeeStatusEnum")]
        public string AttendeeStatus { get; set; }

        [DataMember(Name="EventRegistrationFeeID")]
        public int EventRegistrationFeeId { get; set; }

        [DataMember(Name="CountryOfBirth_CountryID")]
        public int BirthCountryId { get; set; }

        [DataMember(Name="CountryOfResidence_CountryID")]
        public int ResidenceCountryId { get; set; }

        [DataMember(Name="RegionOfBirthID")]
        public int BirthRegionId { get; set; }

        [DataMember(Name="NationalityID")]
        public int NationalityId { get; set; }

        [DataMember(Name="Citizenship_CountryID")]
        public int CitizenshipCountryId { get; set; }

        [DataMember(Name="International")]
        public bool IsInternational { get; set; }

        [DataMember(Name="InternationalDetails")]
        public string InternationalDetails { get; set; }

        [DataMember(Name="Visa")]
        public bool IsVisa { get; set; }

        [DataMember(Name="VisaDetails")]
        public string VisaDetails { get; set; }

        [DataMember(Name="Religion")]
        public string Religion { get; set; }

        [DataMember(Name="Ethnicity")]
        public string Ethnicity { get; set; }

        [DataMember(Name="Medical")]
        public string Medical { get; set; }

        [DataMember(Name="Disability")]
        public string Disability { get; set; }

        [DataMember(Name="Dietary")]
        public string Dietary { get; set; }

        [DataMember(Name="SpecialNeeds")]
        public string SpecialNeeds { get; set; }

        [DataMember(Name="Married")]
        public bool IsMarried { get; set; }

        [DataMember(Name="Deceased")]
        public bool IsDeceased { get; set; }

        [DataMember(Name="LivingWithDependents")]
        public bool IsLivingWithDependents { get; set; }

        [DataMember(Name="DateEntry")]
        public DateTime? EntryDate { get; set; }

        [DataMember(Name="DateExit")]
        public DateTime? ExitDate { get; set; }

        [DataMember(Name="ResidentYear")]
        public string ResidentYear { get; set; }

        [DataMember(Name="ResidentStatus")]
        public string ResidentStatus { get; set; }

        [DataMember(Name="Occupation")]
        public string Occupation { get; set; }

        [DataMember(Name="HearAboutUs")]
        public string HearAboutUs { get; set; }

        [DataMember(Name="VehicleRegistration")]
        public string VehicleRegistration { get; set; }

        [DataMember(Name="VehicleDetails")]
        public string VehicleDetails { get; set; }

        [DataMember(Name="VehiclePermit")]
        public string VehiclePermit { get; set; }

        [DataMember(Name="PreviousMembership")]
        public string PreviousMembership { get; set; }

        [DataMember(Name="PreviousMembershipYears")]
        public string PreviousMembershipYears { get; set; }

        [DataMember(Name="PreviousMemberName")]
        public string PreviousMemberName { get; set; }

        [DataMember(Name="PreviousMemberYears")]
        public string PreviousMemberYears { get; set; }

        [DataMember(Name="PreviousMemberRelationship")]
        public string PreviousMemberRelationship { get; set; }

        [DataMember(Name="AccountHold")]
        public bool IsAccountHold { get; set; }

        [DataMember(Name="AccountCode")]
        public string AccountCode { get; set; }

        [DataMember(Name="AccountComments")]
        public string AccountComments { get; set; }

        [DataMember(Name="AccountDueDate")]
        public DateTime? AccountDueDate { get; set; }

        [DataMember(Name="Account_PaymentTypeID")]
        public int AccountPaymentTypeId { get; set; }

        [DataMember(Name="AccountBankName")]
        public string AccountBankName { get; set; }

        [DataMember(Name="AccountBankNumber")]
        public string AccountBankNumber { get; set; }

        [DataMember(Name="AccountDetail1")]
        public string AccountDetail1 { get; set; }

        [DataMember(Name="AccountDetail2")]
        public string AccountDetail2 { get; set; }

        [DataMember(Name="AccountDetail3")]
        public string AccountDetail3 { get; set; }

        [DataMember(Name="AccountDetail4")]
        public string AccountDetail4 { get; set; }

        [DataMember(Name="FinancialSupportID")]
        public string FinancialSupportId { get; set; }

        [DataMember(Name="FinancialComments")]
        public string FinancialComments { get; set; }

        [DataMember(Name="EnrollmentClass")]
        public string EnrollmentClass { get; set; }

        [DataMember(Name="EnrollmentTerm")]
        public string EnrollmentTerm { get; set; }

        [DataMember(Name="EnrollmentLevel")]
        public string EnrollmentLevel { get; set; }

        [DataMember(Name="EnrollmentStatus")]
        public string EnrollmentStatus { get; set; }

        [DataMember(Name="EnrollmentYear")]
        public string EnrollmentYear { get; set; }

        [DataMember(Name="ProfileInterests")]
        public string ProfileInterests { get; set; }

        [DataMember(Name="Career")]
        public string Career { get; set; }

        [DataMember(Name="CareerComments")]
        public string CareerComments { get; set; }

        [DataMember(Name="EmploymentDetails")]
        public string CareerDetails { get; set; }

        [DataMember(Name="IncidentHold")]
        public bool IsIncidentHold { get; set; }

        [DataMember(Name="IncidentHoldComments")]
        public string IncidentHoldComments { get; set; }

        [DataMember(Name="Comments")]
        public string Comments { get; set; }

        [DataMember(Name="DeceasedDate")]
        public DateTime? DeceasedDate { get; set; }

        [DataMember(Name="VisitorHold")]
        public bool IsVisitorHold { get; set; }

        [DataMember(Name="UsesScreenReader")]
        public bool IsUsesScreenReader { get; set; }
    }
}
