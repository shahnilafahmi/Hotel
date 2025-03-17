using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelProject.Models;


[Table("Hms_DailySummary_GroupMaaster")]
public partial class HmsDailySummaryGroupMaaster
{
    [Column("DailySummary_GroupId")]
    [Key]
    public int DailySummaryGroupId { get; set; }

    [Column("DailySummary_GroupName")]
    [StringLength(100)]
    public string DailySummaryGroupName { get; set; }

    public bool Visible { get; set; }
}
