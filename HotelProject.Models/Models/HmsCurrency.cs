using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.Models
{
    public class HmsCurrency
    {
        [Key]
        
        public int CurrencyId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CurrencyName { get; set; }

        [Required]
        [MaxLength(10)]
        public string CurrencyCode { get; set; }

        [Required]
        public int DecimalPlaces { get; set; }

        [Required]
        
        public decimal CurrencyRate { get; set; }

        [MaxLength(50)]
        public string ModifyUser { get; set; }

        public DateTime? ModifyDate { get; set; }
    }
}
