using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models;

public partial class HmsGuestGroupMaster
{
    [Key]
    public int? Group_id { get; set; }

    public string? Group_Name { get; set; }
}
