using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.Models
{
    public class Source
    {
        public int Id { get; set; }
        [Required]
        public string SourceName { get; set; }
    }
}
