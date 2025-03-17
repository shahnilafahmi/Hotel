using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelProject.Models;


[Table("Hms_Mode_Description")]
public partial class HmsModeDescription
{
    [Column("Mode_Id")]
    [Key]
    public int ModeId { get; set; }

    [Column("Mode_Description")]
    [StringLength(50)]
    public string? ModeDescription { get; set; } 
}
