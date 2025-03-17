using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelProject.Models;

[Table("Hms_TransactionCodes")]
public partial class HmsTransactionCode
{
    [Key]
    public int Id { get; set; }

    [Column("Trans_code")]
    [StringLength(10)]
    public string? TransCode { get; set; } 

    [Column("Trans_Description")]
    [StringLength(100)]
    public string? TransDescription { get; set; }

    [Column("Trans_group")]
    public int? TransGroup { get; set; }

    [Column("Main_Group")]
    [StringLength(50)]
    public string? MainGroup { get; set; } 

    [Column("CRDR")]
    [StringLength(10)]
    public string? Crdr { get; set; }

    public bool? Taxable { get; set; }

    [Column("Acc_Code")]
    [StringLength(50)]
    public string? AccCode { get; set; }

    [Column("Inv_Code")]
    [StringLength(100)]
    public string? InvCode { get; set; }

    [StringLength(10)]
    public string? PrefixCode { get; set; }

    
    [StringLength(50)]
    public string? Refcodefield { get; set; }

    [StringLength(50)]
    public string? Reportfilename { get; set; }

    public bool? Printvoucher { get; set; }

  
    public bool? ManualTransaction { get; set; }

   
    public bool? PosttoAccounts { get; set; }

    [Column("taxsvc")]
    public double? Taxsvc { get; set; }

    [Column("tax")]
    public double? Tax { get; set; }

    [Column("svc")]
    public double? Svc { get; set; }

    [Column("guestledger")]
    public int? Guestledger { get; set; }
    [ForeignKey("Guestledger")]
    public HmsGuestLedgerTemp GuestLedgerTemp { get; set; }

    [Column("dailysummary")]
    public int? Dailysummary { get; set; }
    [ForeignKey("Dailysummary")]
    public HmsDailySummary DailySummary { get; set; }
                
    public bool? InHouse { get; set; }

    [Column("Dept_id")]
    public int? DeptId { get; set; }
    

    [Column("Sort_order")]
    public int? SortOrder { get; set; }

    [Column("show_in_inv")]
    public bool? ShowInInv { get; set; }

    public bool? FilterBillSummHead { get; set; }

    [Column("Formula_Vat")]
    [StringLength(100)]
    public string? FormulaVat { get; set; }

    [Column("Formula_SVC")]
    [StringLength(100)]
    public string? FormulaSvc { get; set; }

    [Column("Formula_CGST")]
    [StringLength(100)]
    public string? FormulaCgst { get; set; }

    [Column("Formula_SGST")]
    [StringLength(100)]
    public string? FormulaSgst { get; set; }
}
