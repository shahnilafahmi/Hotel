using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelProject.Models;

[Table("Hms_Doc_Master")]
public partial class HmsDocMaster
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("Doc_Name")]
    [StringLength(10)]
    public string? DocName { get; set; } 
}
