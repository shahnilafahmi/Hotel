using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models;

public partial class HmsRoomTypeMaster
{
    [Key]
    public int RoomType_Id { get; set; }

    public int? Beds { get; set; }

    public string? Description { get; set; } 

    public int? Add_user { get; set; }

    public bool? Active { get; set; }

    public string? Room_Type_Name { get; set; }
}
