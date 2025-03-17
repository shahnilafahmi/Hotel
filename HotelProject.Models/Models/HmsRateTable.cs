using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelProject.Models;

public partial class HmsRateTable
{
    [Key]
    public int Id { get; set; }

    public int RoomTypeId { get; set; }
    [ForeignKey("RoomTypeId")]
  public HmsRoomTypeMaster RoomTypeMaster { get; set; }

    public int RateTypeId { get; set; }
    [ForeignKey("RateTypeId")]
    public HmsRateTypeMaster RateTypeMaster { get; set; }
    public int? Rate { get; set; }

    public int? MinRate { get; set; }
}
