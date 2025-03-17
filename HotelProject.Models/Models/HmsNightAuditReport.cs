using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelProject.Models;


[Table("Hms_NIghtAudit_Reports")]
public partial class HmsNightAuditReport
{
    [Key]
    public int Id { get; set; }
    [StringLength(10)]
    public string ReportName { get; set; } = null!;

    [Column("Proc_name")]
    [StringLength(10)]
    public string ProcName { get; set; } = null!;

    [StringLength(10)]
    public string Status { get; set; } = null!;
}
