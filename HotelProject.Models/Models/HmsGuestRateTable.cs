using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models;

public partial class HmsGuestRateTable
{
    [Key]
    public string? RateId { get; set; }

    public string? Res_no { get; set; }

    public string Room_Type_id { get; set; } = null!;

    public string Rate { get; set; } = null!;

    public string? Remarks { get; set; }

    public string? Posting_Date { get; set; }

    public string? GuestNo { get; set; }
}
