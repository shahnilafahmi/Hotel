using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models;

public partial class HmsVisitPupose
{
    [Key]
    public int VisitPurposeId { get; set; }

    public string VisitPuposeDesc { get; set; } = null!;
}
