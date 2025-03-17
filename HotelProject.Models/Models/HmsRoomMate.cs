using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelProject.Models;

[Table("Hms_RoomMates")]
public partial class HmsRoomMate
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? GuestNo { get; set; }

    [Column("Rm_Name")]
    [StringLength(50)]
    public string? RmName { get; set; } 

    [Column("Doc_Id")]
    public int? DocId { get; set; }
    [ForeignKey("DocId")]
    public HmsDocMaster DocMaster { get; set; }
    [Column("Doc_no")]
    [StringLength(50)]
    public string? DocNo { get; set; }

    [Column("Nat_Id")]
    public int? NatId { get; set; }
    [ForeignKey("NatId")]
    public HmsNationalityMaster NationalityMaster { get; set; }

    [Column("DOB", TypeName = "datetime")]
    public DateTime? Dob { get; set; }

    [StringLength(10)]
    public string? Status { get; set; }

    [Column("Checkout_Date", TypeName = "datetime")]
    public DateTime? CheckoutDate { get; set; }
}
