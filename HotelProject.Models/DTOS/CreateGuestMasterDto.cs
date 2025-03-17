using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.DTOs
{
    public class CreateGuestMasterDto
    {
        public string GuestNo { get; set; }

        public string Fname { get; set; }

        public string Mname { get; set; }

        public string Lname { get; set; }

        public string FullName { get; set; }
        public int? Guest_Trans_Id { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public int? Nationality_id { get; set; }

        public int? Doctype_id { get; set; }

        public string Doc_No { get; set; }

        public DateTime? DOB { get; set; }

        public DateTime? PP_issue_DAte { get; set; }

        public DateTime? PP_Exp_Date { get; set; }

        public string PP_issue_place { get; set; }

        public string TA_code { get; set; }

        public int? Cityledger_Id { get; set; }
       
        public string TA_VoucherNo { get; set; }

        public string Email { get; set; }

        public string Remarks { get; set; }

        public int? RoomId { get; set; }

        public int? Roomtype_id { get; set; }

        public bool? Tax { get; set; }

        public bool? TD_Applicable { get; set; }

        public double? Room_Charge { get; set; }

        public double? Service_Charge { get; set; }

        public int? Pax { get; set; }

        public int? Child { get; set; }

        public string Sex { get; set; }

        public string Reg_card_No { get; set; }

        public DateTime? Checkin_Date { get; set; }

        public DateTime? CheckOut_Date { get; set; }

        public TimeSpan? CheckIn_time { get; set; }

        public TimeSpan? CheckOut_Time { get; set; }

        public DateTime? Dep_Date { get; set; }

        public TimeSpan? Dep_Time { get; set; }

        public string Status { get; set; }

        public int? Checkin_User { get; set; }

        public int? Checkout_User { get; set; }

        public int? Rent_Type { get; set; }

        public double? Guest_Balance { get; set; }

        public double? Guest_Amount { get; set; }

        public string Invoice_No { get; set; }

        public string Roomno { get; set; }

        public string Org_Roomno { get; set; }

        public string Share_staus { get; set; }

        public string Cityledger_Voucherno { get; set; }

        public int? Org_roomno_id { get; set; }

        public string Res_ref_no { get; set; }

        public int? GroupGuestid { get; set; }

        public string Res_no { get; set; }

        public int? Category_id { get; set; }

        public string Room_Transfer_Reason { get; set; }

        public int? Guest_Type { get; set; }

        public int? Rate_Plan { get; set; }

        public bool? Dont_Print_Rate { get; set; }

        public string ThanksMsg { get; set; }

        public int? Thanks_Method { get; set; }

        public int? Freq_id { get; set; }

        public int? Mode_id { get; set; }

        public int? Segment_id { get; set; }

        public int? Purpose_id { get; set; }

        public int? Plan_id { get; set; }

        public string PayMode { get; set; }

        public int? NoOfDays { get; set; }

        public bool? HoldBill { get; set; }

        public bool? RecheckIn { get; set; }

        public int? EntryDepId { get; set; }

        public string VehNo { get; set; }

        public string Contact_No { get; set; }

        public string Tel_No { get; set; }

        public double? Credit_Limit { get; set; }

        public int? Salesman_id { get; set; }

        public int? Billing_Instruct_id { get; set; }

        public double? FD_rate { get; set; }

        public bool? FD_Post { get; set; }

        public string Gst_status { get; set; }

        public string Pending_Remarks { get; set; }

        public string Settlement_Trans_code { get; set; }

        public double? Settlement_Amount { get; set; }

        public int? Posting_roomno { get; set; }

        public string Posting_GuestNo { get; set; }

        public int? Nat_Res { get; set; }

        public string ContNAme { get; set; }

        public double? Vat_amt { get; set; }

        public double? Vatable_amt { get; set; }

        public bool? TD_post_share { get; set; }
    }
}
