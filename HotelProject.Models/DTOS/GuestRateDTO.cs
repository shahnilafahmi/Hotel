namespace HotelProject.Models.DTOs
{
    public class CreateGuestRateDto
    {


        public string? Res_no { get; set; }
        public string Room_Type_id { get; set; } = null!;
        public string Rate { get; set; } = null!;

        public string? Remarks { get; set; }
        public string? Posting_Date { get; set; }
        public string? GuestNo { get; set; }
    }


    public class UpdateGuestRateDto
    {
        // Optional if RateId is needed for updating
        public string? RateId { get; set; }

        public string? Res_no { get; set; }
        public string? Room_Type_id { get; set; }
        public string? Rate { get; set; }
        public string? Remarks { get; set; }
        public string? Posting_Date { get; set; }
        public string? GuestNo { get; set; }
    }


}
