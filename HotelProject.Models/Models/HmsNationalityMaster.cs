using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models;

public partial class HmsNationalityMaster
{
    [Key]
    public int? Nat_id { get; set; }

    public string? Nat_Code { get; set; }

    public string? Nationality { get; set; }
}
