using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;


namespace HotelProject.Models
    {
        public class TempGuestView
        {
            [Key]
            public int Id { get; set; }  // Primary key with identity

            public string? RoomNo { get; set; }
            public string? Name { get; set; }
            public string? GStNo { get; set; }
            public int? Pax { get; set; }
            public DateTime? CheckIn { get; set; }
            public int? RoomTypId { get; set; }
        [ForeignKey("RoomTypId")]
        public HmsRoomTypeMaster RoomTypeMaster { get; set; }
        public DateTime? DepDate { get; set; }
            public string? Nationality { get; set; }
            public string? City_Name { get; set; }
            public int? RoomRate { get; set; }
            public string? Status { get; set; }
            public string? Nation_Rmmt { get; set; }
            public string? Segment { get; set; }
            public string? Typename { get; set; }
            public string? docname { get; set; }
            public string? categ_descri { get; set; }
            public string? family { get; set; }
            public string? child { get; set; }
            public string? billinginst { get; set; }
            public string? guestid { get; set; }
            public DateTime? checkout { get; set; }
            public string? resno { get; set; }
            public string? salesname { get; set; }
            public string? groupname { get; set; }
            public string? contactno { get; set; }
            public string? docno { get; set; }
            public string? guestbal { get; set; }
            public string? RoomMate { get; set; }
            public int? VacantRoom { get; set; }
            public int? OrgRoom { get; set; }
            public string? Plan_Des { get; set; }
            public string? Pay_Des { get; set; }
            public string? agentname { get; set; }
        }
    }

