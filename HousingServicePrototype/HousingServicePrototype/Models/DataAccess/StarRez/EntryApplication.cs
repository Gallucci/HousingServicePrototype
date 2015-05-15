using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.StarRez
{
    [DataContract]
    class EntryApplication
    {
        [DataMember(Name="EntryApplicationID")]
        public int Id { get; set; }

        [DataMember(Name="EntryID")]
        public int EntryId { get; set; }

        [DataMember(Name="ApplicationStatusID")]
        public int ApplicationStatusId { get; set; }

        [DataMember(Name="ClassificationID")]
        public int ClassificationId { get; set; }

        [DataMember(Name="TermID")]
        public int TermId { get; set; }

        [DataMember(Name="Returning")]
        public bool IsReturning { get; set; }

        [DataMember(Name="ExpectedArrivalDate")]
        public DateTime? ExpectedArrivalDate{ get; set; }

        [DataMember(Name="ExpectedArrivalDateLatest")]
        public DateTime? ExpectedArrivalDateLatest { get; set; }

        [DataMember(Name="ExpectedDepartureDate")]
        public DateTime? ExpectedDepartureDate { get; set; }

        [DataMember(Name="ApplicationDate")]
        public DateTime? ApplicationDate { get; set; }

        [DataMember(Name="Rating")]
        public string Rating { get; set; }

        [DataMember(Name="CancelDate")]
        public DateTime CancelDate { get; set; }

        [DataMember(Name="EnquiryDate")]
        public DateTime? EnquiryDate { get; set; }

        [DataMember(Name="ReceivedDate")]
        public DateTime? ReceivedDate { get; set; }

        [DataMember(Name="CompleteDate")]
        public DateTime? CompletionDate { get; set; }

        [DataMember(Name="ReceivedFee")]
        public bool HasReceivedFee { get; set; }

        [DataMember(Name="ReceivedFee_WebPaymentID")]
        public int ReceivedFeeWebPaymentId { get; set; }

        [DataMember(Name="ReceivedFee_PaymentID")]
        public int ReceivedFeePaymentId { get; set; }

        [DataMember(Name="ReceivedFeeDate")]
        public DateTime? ReceivedFeeDate { get; set; }

        [DataMember(Name="ReceivedFeeAmount")]
        public decimal ReceivedFeeAmount { get; set; }

        [DataMember(Name="ReceivedDeposit")]
        public bool HasReceivedDeposit { get; set; }

        [DataMember(Name="ReceivedDepositWaived")]
        public bool IsReceivedDepositWaived { get; set; }

        [DataMember(Name="ReceivedDeposit_WebPaymentID")]
        public int ReceivedDepositWebPaymentId { get; set; }

        [DataMember(Name="ReceivedDeposit_PaymentID")]
        public int ReceivedDepositReceivedDepositPaymentId { get; set; }

        [DataMember(Name="ReceivedDepositDate")]
        public DateTime? ReceivedDepositDate { get; set; }

        [DataMember(Name="ReceivedDepositAmount")]
        public decimal ReceivedDepositAmount { get; set; }

        [DataMember(Name="ReceivedPhotoDate")]
        public DateTime? ReceivedPhotoDate { get; set; }

        [DataMember(Name="OfferedDate")]
        public DateTime? OfferedDate { get; set; }

        [DataMember(Name="OfferSentDate")]
        public DateTime? OfferSentDate { get; set; }

        [DataMember(Name="OfferReplyEnum")]
        public string OfferReply { get; set; }

        [DataMember(Name="OfferReplyDate")]
        public DateTime? OfferReplyDate { get; set; }

        [DataMember(Name="OfferReplyReason")]
        public string OfferReplyReason { get; set; }

        [DataMember(Name="ContractSignedDate")]
        public DateTime? ContractSignedDate { get; set; }

        [DataMember(Name="PreferenceComments")]
        public string PreferenceComments { get; set; }

        [DataMember(Name="RoomPreferenceComments")]
        public string RoomPreferenceComments { get; set; }

        [DataMember(Name="Comments")]
        public string Comments { get; set; }

        [DataMember(Name="CommentsInternal")]
        public string CommentsInternal { get; set; }

        [DataMember(Name="Web")]
        public bool IsWeb { get; set; }

        [DataMember(Name="RoomSelectionTimeslot")]
        public string RoomSelectionTimeslot { get; set; }

        [DataMember(Name="RoomSelectionNumber")]
        public int RoomSelectionNumber { get; set; }

        [DataMember(Name="RoomMateGroupID")]
        public int RoomMateGroupId { get; set; }

        [DataMember(Name="RoomMateGroupSortOrder")]
        public int RoommateGroupSortOrder { get; set; }

        [DataMember(Name="RoomMateShowInSearch")]
        public bool IsRoomMateShowInSearch { get; set; }

        [DataMember(Name="RoomMateDescription")]
        public string RoomMateDescription { get; set; }

        [DataMember(Name="AllocateOptionEnum")]
        public string AllocateOption { get; set; }

        [DataMember(Name="PortalTrackingOnly")]
        public bool IsPortalTrackingOnly { get; set; }

        [DataMember(Name="TableID")]
        public int TableId { get; set; }

        [DataMember(Name="TableName")]
        public string TableName { get; set; }

        [DataMember(Name="CustomBit1")]
        public bool CustomBit1 { get; set; }

        [DataMember(Name="CustomBit2")]
        public bool CustomBit2 { get; set; }

        [DataMember(Name="CustomBit3")]
        public bool CustomBit3 { get; set; }

        [DataMember(Name="CustomBit4")]
        public bool CustomBit4 { get; set; }

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

        [DataMember(Name="DateModified")]
        public DateTime? DateModified { get; set; }

        [DataMember(Name="DateCreated")]
        public DateTime? DateCreated { get; set; }

    }
}
