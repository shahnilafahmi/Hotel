using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models;

public partial class HmsGuestTran
{
    [Key]
    public int Id { get; set; }

    public string? GuestNo { get; set; }

    public string? Manual_Refno { get; set; }

    public string? Res_no { get; set; }

    public DateTime Trans_date { get; set; }

    public double? Trans_Amt { get; set; }

    public string? Trans_Code { get; set; }

    public string? Remarks { get; set; }

    public string? Void_Reason { get; set; }

    public string? Trans_Confirm { get; set; }

    public string? Pay_Mode { get; set; }

    public string? Currency_code { get; set; }

    public double Curr_rate { get; set; }

    public double? For_Curr_Amt { get; set; }

    public string? Card_Code { get; set; }

    public string? Card_Name { get; set; }

    public DateTime? Card_exp_date { get; set; }

    public string? ChequeNo { get; set; }

    public DateTime? Cheque_date { get; set; }

    public string? Tel_No { get; set; }

    public DateTime? Call_time { get; set; }

    public DateTime? Call_duration { get; set; }

    public int Add_User { get; set; }

    public DateTime Add_time { get; set; }

    public int? Void_user { get; set; }

    public DateTime? Void_Time { get; set; }

    public string? Voucher_No { get; set; }

    public string? Acc_Code { get; set; }

    public string? Split_No { get; set; }

    public bool? Posted { get; set; }

    public bool? Night_Audit { get; set; }

    public int? Ref_trans_id { get; set; }

    public string? Ref_trans_code { get; set; }

    public string? Ref_No { get; set; }

    public string? Roomno { get; set; }

    public int? RoomId { get; set; }

    public int? ShiftID { get; set; }

    public string? Trans_Mode { get; set; }

    public int? FolioNo { get; set; }
}
