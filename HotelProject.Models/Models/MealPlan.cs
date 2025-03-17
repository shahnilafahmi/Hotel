using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.Models
{
    public class MealPlan
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="MealPlanName is Required")]
        [MaxLength(60)]
        public string MealPlanName { get; set; }
    }
}
