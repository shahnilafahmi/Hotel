using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.DTOs
{
    public class RoomMateCreateDto
    {
        public string GuestNo { get; set; }

       
        public string RmName { get; set; }

       
        public int? DocId { get; set; }

      
        public string? DocNo { get; set; }

       
        public int? NatId { get; set; }

       
        public DateTime? Dob { get; set; }

        
        public string? Status { get; set; }

       
        public DateTime? CheckoutDate { get; set; }
    }
}
