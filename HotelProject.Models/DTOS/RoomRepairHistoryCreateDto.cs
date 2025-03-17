using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.DTOs
{
    public class RoomRepairHistoryCreateDto
    {
        public int? RoomId { get; set; }
     
        public string? RoomNo { get; set; }
      
        public string? Reason { get; set; }

     
        public DateTime TransDate { get; set; }
    }
}
