using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models;

public partial class HmsFloorMaster
{
    [Key]
    public int Floorid { get; set; }
    
    public string? Floor_name { get; set; } 
}
