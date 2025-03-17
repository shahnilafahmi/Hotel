using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.Models
{
    public class Purpose
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Purpos { get; set; }
    }
}
