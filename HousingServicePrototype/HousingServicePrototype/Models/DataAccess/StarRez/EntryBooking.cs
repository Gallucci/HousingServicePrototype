using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.StarRez
{
    [DataContract]
    class EntryBooking
    {
        [DataMember(Name="BookingID")]
        public int Id { get; set; }

        [DataMember(Name="RoomSpaceID")]
        public int RoomSpaceId { get; set; }

        [DataMember(Name="EntryID")]
        public int EntryId { get; set; }

        [DataMember(Name="EntryStatusEnum")]
        public string EntryStatus { get; set; }
        
        [DataMember(Name="RoomTypeID")]
        public int RoomTypeId { get; set; }

        [DataMember(Name="RoomLocationID")]
        public int RoomLocationId { get; set; }

        [DataMember(Name="Start_BookingReasonID")]
        public int StartBookingReasonId { get; set; }
        
        [DataMember(Name="End_BookingReasonID")]
        public int EndBookingReasonId { get; set; }

        [DataMember(Name="BookingTypeID")]
        public int BookingTypeId { get; set; }
        
        [DataMember(Name="RoomRateID")]
        public int RoomRateId { get; set; }
        
        [DataMember(Name="BookingLinkType")]
        public string BookingLinkType { get; set; }
        
        [DataMember(Name="TermSessionID")]
        public int TermSessionId { get; set; }

        [DataMember(Name="HousekeepingID")]
        public int HousingkeepingId { get; set; }

        [DataMember(Name="RoomLocationFixed")]
        public bool IsRoomLocationFixed { get; set; }

        [DataMember(Name="RoomRateAmount")]
        public decimal RoomRateAmount { get; set; }

        [DataMember(Name="CheckInDate")]
        public DateTime? CheckInDate { get; set; }

        [DataMember(Name="CheckOutDate")]
        public DateTime? CheckOutDate { get; set; }

        [DataMember(Name="ETA")]
        public DateTime? EstimatedTimeOfArrival { get; set; }

        [DataMember(Name="ETD")]
        public DateTime? EstimatedTimeOfDeparture { get; set; }

        [DataMember(Name="CheckInDateActual")]
        public DateTime? CheckInDateActual { get; set; }

        [DataMember(Name="CheckOutDateActual")]
        public DateTime? CheckOutDateActual { get; set; }

        [DataMember(Name="DateChargedTo")]
        public DateTime? DateChargedTo { get; set; }

        [DataMember(Name="ContractDateStart")]
        public DateTime? ContractStartDate { get; set; }

        [DataMember(Name="ContractDateEnd")]
        public DateTime? ContractEndDate { get; set; }

        [DataMember(Name="ResvChargeToEntry")]
        public bool IsReservationChargeToEntry { get; set; }

        [DataMember(Name="NumberOfGuests")]
        public int NumberOfGuests { get; set; }

        [DataMember(Name="NumberOfGuestsFree")]
        public int NumberOfGuestsFree { get; set; }

        [DataMember(Name="NumberOfChildren")]
        public int NumberOfChildren { get; set; }

        [DataMember(Name="NumberOfChildrenFree")]
        public int NumberOfChildrenFree { get; set; }

        [DataMember(Name="SpecialRequirement")]
        public string SpecialRequirement { get; set; }

        [DataMember(Name="RoomService1Frequency")]
        public string RoomService1Frequency { get; set; }

        [DataMember(Name="RoomService2Frequency")]
        public string RoomService2Frequency { get; set; }

        [DataMember(Name="RoomService3Frequency")]
        public string RoomService3Frequency { get; set; }

        [DataMember(Name="Comments")]
        public string Comments { get; set; }

        [DataMember(Name="DateBilled")]
        public DateTime? DateBilled { get; set; }

        [DataMember(Name="CustomBit1")]
        public bool CustomBit1 { get; set; }

        [DataMember(Name="CustomBit2")]
        public bool CustomBit2 { get; set; }

        [DataMember(Name="CustomBit3")]
        public bool CustomBit3 { get; set; }

        [DataMember(Name="CustomBit4")]
        public bool CustomBit4 { get; set; }

        [DataMember(Name="CustomString1")]
        public string CustomString1 { get; set; }

        [DataMember(Name="CustomString2")]
        public string CustomString2 { get; set; }

        [DataMember(Name="CustomString3")]
        public string CustomString3 { get; set; }

        [DataMember(Name="CustomString4")]
        public string CustomString4 { get; set; }

        [DataMember(Name="CustomString5")]
        public string CustomString5 { get; set; }

        [DataMember(Name="CustomString6")]
        public string CustomString6 { get; set; }

        [DataMember(Name="CustomString7")]
        public string CustomString7 { get; set; }

        [DataMember(Name="CustomString8")]
        public string CustomString8 { get; set; }

        [DataMember(Name="CustomString9")]
        public string CustomString9 { get; set; }

        [DataMember(Name="CustomString10")]
        public string CustomString10 { get; set; }

        [DataMember(Name="CustomDate1")]
        public DateTime? CustomDate1 { get; set; }

        [DataMember(Name="CustomDate2")]
        public DateTime? CustomDate2 { get; set; }

        [DataMember(Name="CustomDate3")]
        public DateTime? CustomDate3 { get; set; }

        [DataMember(Name="CustomDate4")]
        public DateTime? CustomDate4 { get; set; }

        [DataMember(Name="SecurityUserID")]
        public int SecurityUserId { get; set; }

        [DataMember(Name="DateModifiedBilling")]
        public DateTime? DateModifiedBilling { get; set; }

        [DataMember(Name="DateModified")]
        public DateTime? DateModified { get; set; }

        [DataMember(Name="DateCreated")]
        public DateTime? DateCreated { get; set; }
    }
}
