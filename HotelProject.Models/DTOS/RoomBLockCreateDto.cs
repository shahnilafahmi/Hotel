using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.DTOs
{
    public class RoomBLockCreateDto
    {
        public int? ResDetId { get; set; }

        public int? RoomId { get; set; }


        public DateTime Date { get; set; }

    }
}
