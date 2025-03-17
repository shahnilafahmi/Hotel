using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.Models
{
    public class AgentMaster
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This AgentName is required")]
        public string AgentName { get; set; }
    }
}
