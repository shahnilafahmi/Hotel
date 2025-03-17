using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.DTOs
{
    public class GuestCheckInDTO
    {
      
            // Guest Details
            public string GuestNo { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public int? NationalityId { get; set; }
            public string Residence { get; set; }
            public int? GuestType { get; set; }
            public string ContactNo { get; set; }
            public DateTime? DateOfBirth { get; set; } // Nullable for optional DOB
            public string Email { get; set; }
            public string Sex { get; set; } // M/F
            public int? Adults { get; set; }
            public int Children { get; set; }
            public string Remarks { get; set; }

            
            public string? RefNo { get; set; }
            public string? CardNo { get; set; }
            public int? RoomTypeId { get; set; }
            public string RoomNo { get; set; }
           public double? PostingRate { get; set; }
            public double? FDayRate { get; set; }

            // Billing and Payment
            public string PaymentMode { get; set; }
            public int? RatePlan { get; set; }
            public int? BillInstructionId { get; set; }
            public double CreditLimit { get; set; }
            public int? PlanId { get; set; }
            public bool DontPrintRate { get; set; }

            // Additional Details
            public int? DocTypeId { get; set; }
            public string DocNo { get; set; }
            public string? Company { get; set; }
            public string? CareOf { get; set; }
            public int?PurposeId { get; set; }
            public int? ModeId { get; set; } // e.g., "By Air"
            public int? AgentId { get; set; }
            public int? SegmentId { get; set; }
            public int? FrequencyId { get; set; }
            public int? GuestGroupId { get; set; }
        public int? Pax { get; set; }

      
        public DateTime CheckInDate { get; set; }
            public DateTime CheckOutDate { get; set; }
            public int NumberOfDays { get; set; }
            public DateTime CheckInTime { get; set; }
            public DateTime CheckOutTime { get; set; }
            public string ResNo { get; set; } 
       
       
    }
}
