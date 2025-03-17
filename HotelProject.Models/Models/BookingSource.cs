using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.Models
{
    public class BookingSource
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string BookingSourceName { get; set; }
    }
}
