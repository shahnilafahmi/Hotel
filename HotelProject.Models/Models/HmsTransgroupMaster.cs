using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models;

public partial class HmsTransgroupMaster
{
    [Key]
    public int? Id { get; set; }

    public string? Trans_group_Name { get; set; }
}
