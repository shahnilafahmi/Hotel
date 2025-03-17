using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelProject.Models
{

    public partial class HmsCityledgerMaster
    {
        [Key]
        public int City_id { get; set; } // Matches City_id in the table

        public string? Cty_Acct_No { get; set; } // Matches Cty_Acct_No in the table

        public string City_Name { get; set; } = null!; // Matches City_Name in the table

        public string? City_Contact { get; set; } // Matches City_Contact in the table

        public DateTime? City_Join_Date { get; set; } // Matches City_Join_Date in the table

        public string? City_Address { get; set; } // Matches City_Address in the table

        public string? City_Office_Tel { get; set; } // Matches City_Office_Tel in the table

        public string? City_Mobile_Tel { get; set; } // Matches City_Mobile_Tel in the table

        public string? City_Email { get; set; } // Matches City_Email in the table

        public string? City_Remarks { get; set; } // Matches City_Remarks in the table

        public double? City_Balance_amt { get; set; } // Matches City_Balance_amt in the table

        public double? Credit_Limit { get; set; } // Matches Credit Limit in the table

        public string? Acc_No { get; set; } // Matches Acc_No in the table

        public int? Segment_id { get; set; } // Matches Segment_id in the table
        [ForeignKey("Segment_id")]
        public HmsSegmentMaster SegmentMaster { get; set; }
        public bool? Active { get; set; }
    }
}