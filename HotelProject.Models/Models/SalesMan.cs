using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.Models
{
    public class SalesMan
    {
        [Key]
            public int Id { get; set; }
        [Required(ErrorMessage = " Name is required ")]
            public string Name { get; set; } 
            public bool? IsDeleted { get; set; } 
            public string? ContactNumber { get; set; } 
            public int? LocationId { get; set; } 
            public string? Status { get; set; }
      
    }
}
