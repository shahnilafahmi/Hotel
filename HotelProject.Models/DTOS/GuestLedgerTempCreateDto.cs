using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.DTOs
{
    public class GuestLedgerTempCreateDto
    {
        public string? Guestno { get; set; }

  
        public string? Amount { get; set; }

     
        public string? VoucherNo { get; set; }

      
        public DateTime Date { get; set; }
    }
}
