using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.DTOs
{
    public class CreateRoomMasterDto
    {

      

        public string? Roomno { get; set; }

            public int? RoomnoInt { get; set; }

            public int RoomtypeId { get; set; }

            public string? OrgRoomno { get; set; }

            public string? ShareStatus { get; set; }

            public string? CleanStatus { get; set; }

            public string? OrgStatus { get; set; }

            public int? FloorId { get; set; }

            public int? AddUser { get; set; }

            //public DateTime? AddedTime { get; set; }

            public string? RoomDesc { get; set; }

            public string? OutofOrderRemarks { get; set; }

            public bool? Active { get; set; }

            public string? Status { get; set; }
        
    }
}
