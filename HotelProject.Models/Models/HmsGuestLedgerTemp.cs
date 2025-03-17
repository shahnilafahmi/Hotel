using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelProject.Models;

[Table("Hms_GuestLedger_temp")]
public partial class HmsGuestLedgerTemp
{
    [StringLength(10)]
    [Key]
    public int GroupId { get; set; } 

    [StringLength(10)]
    public string? Guestno { get; set; } 

    [StringLength(10)]
    public string? Amount { get; set; }

    [StringLength(10)]
    public string? VoucherNo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }
}
