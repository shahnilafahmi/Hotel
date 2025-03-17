using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelProject.Models;

[Table("Hms_Rate_Type_master")]
public partial class HmsRateTypeMaster
{
    [Key]
    public int Id { get; set; }
    [Column("Rate_Type_name")]
    [StringLength(20)]
    public string? RateTypeName { get; set; }

   
}
