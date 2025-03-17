using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelProject.Models;


[Table("Hms_Mandatory_Fields")]
public partial class HmsMandatoryField
{
    [Column("id")]
    public int Id { get; set; }

    [StringLength(10)]
    public string? FieldName { get; set; }

    [StringLength(10)]
    public string? ControlName { get; set; }

    [Column("Control_type")]
    [StringLength(10)]
    public string? ControlType { get; set; }

    [StringLength(10)]
    public string? FornNme { get; set; }

    public bool? Value { get; set; }
}
