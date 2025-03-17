using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelProject.Models;

[Table("Hms_NoshowRooms")]
public partial class HmsNoshowRoom
{
    [Key]
    [StringLength(10)]
    public int Id { get; set; }

    [Column("Res_No")]
    [StringLength(10)]
    public string ResNo { get; set; }

    [Column("Res_rooms")]
    public int? ResRooms { get; set; }

    [Column("Res_Room_Type")]
    public int? ResRoomType { get; set; }

    [Column("RoomNo_Id")]
    public int? RoomNoId { get; set; }

    [Column("No_ShowRooms")]
    public int? NoShowRooms { get; set; }
}
