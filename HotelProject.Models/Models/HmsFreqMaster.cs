using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models;

public partial class HmsFreqMaster
{
    [Key]
    public int? Freq_Id { get; set; }

    public string? Freq_Desc { get; set; }
}
