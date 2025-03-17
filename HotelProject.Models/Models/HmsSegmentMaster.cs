using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models;

public partial class HmsSegmentMaster
{
    [Key]
    public int SegmentId { get; set; } 

    public string? Segment_Name { get; set; } 

    public string? DTCM_code { get; set; }
}
