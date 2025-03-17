using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models;

public partial class HmsPlanMaster
{
    [Key]
    public int Planid { get; set; }
   
    public string? PlanName { get; set; }
    public double? PaxValue { get; set; }
    public double? ChildValue { get; set; }

    public string Plan_code { get; set; } 
}
