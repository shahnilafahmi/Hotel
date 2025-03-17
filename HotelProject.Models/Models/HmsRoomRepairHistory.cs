using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelProject.Models;


[Table("Hms_RoomRepair_History")]
public partial class HmsRoomRepairHistory
{
    [StringLength(10)]
    [Key]
    public int Id { get; set; }

    [StringLength(10)]
    public int? RoomId { get; set; }
    [ForeignKey("RoomId")]
    public HmsRoomMaster RoomMaster { get; set; }
    [StringLength(10)]
    public string? RoomNo { get; set; }

    [StringLength(10)]
    public string? Reason { get; set; }

    [Column("Trans_date")]
    [StringLength(10)]
    public DateTime TransDate { get; set; }
}
