using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.DTOs
{
    public class RoomTypeMasterCreateDto
    {

        public int? Beds { get; set; }

        public string Description { get; set; } = null!;

        public int Add_user { get; set; }

        public bool? Active { get; set; }

        public string? Room_Type_Name { get; set; }
    }
}
