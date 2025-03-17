using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.DTOs
{
    public class HmsGlGroupMasterCreateDto
    {
        public string? GL_Group_Name { get; set; }

        public string? GL_Short_Name { get; set; }

        public string? Sort_Order { get; set; }
    }
}
