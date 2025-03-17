using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.DTOs
{
    public class DailySummaryGroupMasterCreateDto
    {
        public string DailySummaryGroupName { get; set; }

        public bool Visible { get; set; }
    }
}
