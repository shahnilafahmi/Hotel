using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelProject.Models.Models.Reservation;


namespace HotelProject.Models;

[Table("Hms_RoomBlock_Rooms")]
public partial class HmsRoomBlockRoom
{
    [Key]
    public int Id { get; set; }

    [Column("Res_Det_Id")]
    public int? ResDetId { get; set; }
    [ForeignKey("ResDetId")]
    public HmsReservationDetail ReservationDetailTable { get; set; }

    public int? RoomId { get; set; }
    [ForeignKey("RoomId")]
    public HmsRoomMaster RoomMaster { get; set; }
  

    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }
}
