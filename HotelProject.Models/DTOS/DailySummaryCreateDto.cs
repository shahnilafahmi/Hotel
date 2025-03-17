using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.DTOs
{
    public class DailySummaryCreateDto
    {
        //[Column(TypeName = "datetime")]
        //public DateOnly Tdate { get; set; }

        public int Occ { get; set; }

        public int Vac { get; set; }

        public int OutOfOrder { get; set; }

        public int Dirty { get; set; }

        public int HouseUse { get; set; }

        [Column("Total_Rooms")]
        public int TotalRooms { get; set; }

        [Column("Room_Rev")]
        public double? RoomRev { get; set; }

        [Column("Avg_room_rate")]
        public double? AvgRoomRate { get; set; }

        [Column("Avg_Guest_rate")]
        public double? AvgGuestRate { get; set; }

        [Column("Occ_Per")]
        public double? OccPer { get; set; }

        public int? DoubleOcc { get; set; }

        public int? NoOfCheckin { get; set; }

        public int? NoOfCheckOut { get; set; }

        [Column("Checkin_Pax")]
        public int? CheckinPax { get; set; }

        [Column("NOOfRooms_Rented")]
        public int? NoofRoomsRented { get; set; }

        public double? Laundry { get; set; }

        public double? Telephone { get; set; }

        public double? Internet { get; set; }

        public double? Misc { get; set; }

        public double? Misc1 { get; set; }

        public double? Misc2 { get; set; }

        public double? Coffeshop { get; set; }

        public double? Coffeeshop2 { get; set; }

        public double? Transport { get; set; }

        public double? MiniBar { get; set; }

        public int? NoofRes { get; set; }

        public int? NoShowRooms { get; set; }

        [Column("Res_Checkin")]
        public int? ResCheckin { get; set; }

        public int? Walkin { get; set; }

        [Column("Void_Transactions")]
        public int? VoidTransactions { get; set; }

        public double? Vat { get; set; }

        [Column("Serv_Charge")]
        public double? ServCharge { get; set; }

        [Column("CST")]
        public double? Cst { get; set; }

        [Column("GST")]
        public double? Gst { get; set; }

        public double? Tax { get; set; }

        public double? Cash { get; set; }

        public double? Cheque { get; set; }

        public double? CreditCard { get; set; }

        public double? CityLedger { get; set; }

        public double? Discount { get; set; }

        public double? Tax1 { get; set; }

        public double Tax2 { get; set; }

        [Column("TDh")]
        public double Tdh { get; set; }

        public double NetCash { get; set; }

        [Column("RF_creditCArd")]
        public double RfCreditCard { get; set; }

        [Column("ARR_TotalRoom")]
        public double ArrTotalRoom { get; set; }

        [Column("ARR_Avail_Room")]
        public double ArrAvailRoom { get; set; }

        [Column("OP_Bal")]
        public double OpBal { get; set; }

        [Column("CL_Bal")]
        public double ClBal { get; set; }

        public int Complimentary { get; set; }

        [Column("Blocked_rooms")]
        public int BlockedRooms { get; set; }

        [Column("Occ_Avail")]
        public double OccAvail { get; set; }

        public double Expense { get; set; }

        [Column("Saleable_Rooms")]
        public int SaleableRooms { get; set; }

        [Column("Dest_Chg")]
        public double DestChg { get; set; }

        public double Field1 { get; set; }

        public double Field2 { get; set; }

        public double Field3 { get; set; }
    }
}
