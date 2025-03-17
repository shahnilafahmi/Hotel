using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.DTOs
{
    public class HmsCurrencyUpdateDto
    {
        public int CurrencyId { get; set; }

       
        public string? CurrencyName { get; set; }

     
        public string? CurrencyCode { get; set; }

      
        public int? DecimalPlaces { get; set; }

      

        public decimal? CurrencyRate { get; set; }

      
        public string? ModifyUser { get; set; }

        public DateTime? ModifyDate { get; set; }
    }
}
