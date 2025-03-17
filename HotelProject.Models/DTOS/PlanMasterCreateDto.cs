using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.DTOs
{
    public class PlanMasterCreateDto
    {
        public string? PlanName { get; set; }
        public double? PaxValue { get; set; }
        public double? ChildValue { get; set; }
        public string PlanCode { get; set; }
    }
}
