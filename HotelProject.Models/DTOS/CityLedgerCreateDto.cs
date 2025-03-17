using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.DTOs
{
    public class CityLedgerCreateDto
    {
        public string? Cty_Acct_No { get; set; } 

        public string City_Name { get; set; } = null!;

        public string? City_Contact { get; set; } 

        public DateTime? City_Join_Date { get; set; }

        public string? City_Address { get; set; } 
        public string? City_Office_Tel { get; set; }

        public string? City_Mobile_Tel { get; set; } 

        public string? City_Email { get; set; } 

        public string? City_Remarks { get; set; } 

        public double? City_Balance_amt { get; set; } 

        public double? Credit_Limit { get; set; } 

        public string? Acc_No { get; set; } 

        public int? Segment_id { get; set; } 

        public bool? Active { get; set; }
    }
}
