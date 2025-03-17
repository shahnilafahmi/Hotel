using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models;

public partial class HmsRoomBoyMaster
{
    [Key]
    public int? RoomBoy_id { get; set; }

    public string? RoomBoy_Name { get; set; }
}
