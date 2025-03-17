using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelProject.Models;

public partial class HmsRoomMaster
{


    [Key]
    public int Id { get; set; }

    public string? Roomno { get; set; }  

    public int? RoomnoInt { get; set; }  

    public int Roomtype_Id { get; set; } 
    [ForeignKey("Roomtype_Id")]
    public HmsRoomTypeMaster Roomtype { get; set; }

    public string? Org_roomno { get; set; }  

    public string? Share_status { get; set; } 

    public string? Clean_Status { get; set; }  

    public string? Org_Status { get; set; }  

    public int? Floor_id { get; set; }  
    [ForeignKey("Floor_id")]
    public HmsFloorMaster FloorMaster { get; set; }
    public int? Add_user { get; set; }  

    public DateTime? Added_time { get; set; }  

    public string? Room_Desc { get; set; }  

    public string? OutofOrder_Remarks { get; set; }  

    public bool? Active { get; set; }  

    public string? Status { get; set; } 

}
