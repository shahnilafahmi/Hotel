using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HotelProject.Models.Models
    {
        public class TempInhouseGST
        {
        [Key]
             public int Id { get; set; }
              public int? RoomNo { get; set; }
            public string? GStName { get; set; }
            public int? Pax { get; set; }
            public DateTime CheckIn { get; set; }
            public DateTime? DepDate { get; set; }
            public string? Nationality { get; set; }
            public string? City_Name { get; set; }
            public int? RoomRate { get; set; }
            public string? Status { get; set; }
            public string? RoomMate { get; set; }
            public int? VacantRoom { get; set; }
            public string? Nation_Rmmt { get; set; }
            public string? Plan_Des { get; set; }
            public int? OrgRoom { get; set; }
            public string? RoomNoCHAR { get; set; }
            public long? SORTNO { get; set; }
            public DateTime? Checkin_Time { get; set; }
            public string? GuestNo { get; set; }
            public string? CardNo { get; set; }
        }
    }

