using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models;

public partial class HmsGlGroupMaster
{
    [Key]
    public int GL_Group_Id { get; set; }

    public string? GL_Group_Name { get; set; }

    public string? GL_Short_Name { get; set; }

    public string? Sort_Order { get; set; } 
}
