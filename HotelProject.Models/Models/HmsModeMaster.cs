using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models;

public partial class HmsModeMaster
{
    [Key]
    public int Mode_ID { get; set; }

    public string? Mode_Description { get; set; }
}
