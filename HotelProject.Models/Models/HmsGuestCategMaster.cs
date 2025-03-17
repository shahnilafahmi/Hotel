using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models;

public partial class HmsGuestCategMaster
{
    [Key]
    public int Guest_Categ_Id { get; set; }

    public string? Categ_Description { get; set; } 
}
