using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.DTOs
{
    public class NoShowRoomCreateDto
    {
        public string? ResNo { get; set; }

        
        public int? ResRooms { get; set; }

        
        public int? ResRoomType { get; set; }

       
        public int? RoomNoId { get; set; }

       
        public int? NoShowRooms { get; set; }
    }
}
