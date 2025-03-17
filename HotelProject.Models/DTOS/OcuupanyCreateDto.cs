using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.DTOs
{
    public class OcuupanyCreateDto
    {
        [Column("Res_no")]
        [StringLength(30)]
        public string? ResNo { get; set; }

        [StringLength(30)]
        public string? GuestNo { get; set; }

        public int NoofRooms { get; set; }

        [StringLength(10)]
        public string Source { get; set; } = null!;

        [Column("Stay_date", TypeName = "datetime")]
        public DateTime StayDate { get; set; }

        [Column("Room_Type")]
        public int RoomType { get; set; }

        [StringLength(10)]
        public string Status { get; set; } = null!;

        [Column("Cityledger_Code")]
        public int? CityledgerCode { get; set; }

        [Column("Bal_rooms")]
        public int BalRooms { get; set; }

        [Column("Checkin_date", TypeName = "datetime")]
        public DateTime? CheckinDate { get; set; }

        [Column("Checkout_date", TypeName = "datetime")]
        public DateTime? CheckoutDate { get; set; }

        public double? Rate { get; set; }

        [StringLength(10)]
        public string? RoomNo { get; set; }

        public int? RoomId { get; set; }
    }
}
