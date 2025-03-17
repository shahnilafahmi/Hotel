using HotelProject.Models.Models;
using HotelProject.Models;
using HotelProject.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using HotelProject.Models.DTOs;
using Microsoft.Extensions.Logging;
using HotelProject.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailySummaryController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext context;

        public DailySummaryController(IUnitOfWork unitOfWork,ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            this.context = context;
        }


        [HttpGet("GetByDate")]
        public async Task<IActionResult> GetByDate( DateTime? datetime )
        {
            var response = new ApiResponse
            {
                ErrorMessages = new List<string>()
            };
            
            try
            {
                if (!datetime.HasValue  )
                {
                    // Return all records if request is null or Tdate is invalid
                    var allResults=  await _unitOfWork.DailySummaryRepository.GetAllAsync();
                   

                    response.IsSuccess = true;
                    response.ResponseStatus = HttpStatusCode.OK;
                    response.Result = allResults;

                    return Ok(response);
                }

                // Fetch records by date
                var summaries = _unitOfWork.DailySummaryRepository.GetByDate(datetime);
                

                if (!summaries.Any())
                {
                    response.IsSuccess = false;
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    response.ErrorMessages.Add("No summaries found for the specified date.");
                    return NotFound(response);
                }

                response.IsSuccess = true;
                response.ResponseStatus = HttpStatusCode.OK;
                response.Result = summaries;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ResponseStatus = HttpStatusCode.InternalServerError;
                response.ErrorMessages.Add("An error occurred while processing the request.");
                response.ErrorMessages.Add(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }




        [HttpPost("CreateDailySummary")]

        public async Task<IActionResult> CreateDailySummary([FromBody] DailySummaryCreateDto dto)
        {
            var response = new ApiResponse();
            if (!ModelState.IsValid || dto == null)
            {
                response.IsSuccess = false;
                response.ErrorMessages = ModelState.Values
                    .SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
                response.ResponseStatus = HttpStatusCode.BadRequest;
                return StatusCode((int)response.ResponseStatus, response);
            }

            try
            {
                var obj = new HmsDailySummary
                {
                    Tdate = DateTime.Today,
                    Occ = dto.Occ,
                    Vac = dto.Vac,
                    OutOfOrder = dto.OutOfOrder,
                    Dirty = dto.Dirty,
                    HouseUse = dto.HouseUse,
                    TotalRooms = dto.TotalRooms,
                    RoomRev = dto.RoomRev,
                    AvgRoomRate = dto.AvgRoomRate,
                    AvgGuestRate = dto.AvgGuestRate,
                    OccPer = dto.OccPer,
                    DoubleOcc = dto.DoubleOcc,
                    NoOfCheckin = dto.NoOfCheckin,
                    NoOfCheckOut = dto.NoOfCheckOut,
                    CheckinPax = dto.CheckinPax,
                    NoofRoomsRented = dto.NoofRoomsRented,
                    Laundry = dto.Laundry,
                    Telephone = dto.Telephone,
                    Internet = dto.Internet,
                    Misc = dto.Misc,
                    Misc1 = dto.Misc1,
                    Misc2 = dto.Misc2,
                    Coffeshop = dto.Coffeshop,
                    Coffeeshop2 = dto.Coffeeshop2,
                    Transport = dto.Transport,
                    MiniBar = dto.MiniBar,
                    NoofRes = dto.NoofRes,
                    NoShowRooms = dto.NoShowRooms,
                    ResCheckin = dto.ResCheckin,
                    Walkin = dto.Walkin,
                    VoidTransactions = dto.VoidTransactions,
                    Vat = dto.Vat,
                    ServCharge = dto.ServCharge,
                    Cst = dto.Cst,
                    Gst = dto.Gst,
                    Tax = dto.Tax,
                    Cash = dto.Cash,
                    Cheque = dto.Cheque,
                    CreditCard = dto.CreditCard,
                    CityLedger = dto.CityLedger,
                    Discount = dto.Discount,
                    Tax1 = dto.Tax1,
                    Tax2 = dto.Tax2,
                    Tdh = dto.Tdh,
                    NetCash = dto.NetCash,
                    RfCreditCard = dto.RfCreditCard,
                    ArrTotalRoom = dto.ArrTotalRoom,
                    ArrAvailRoom = dto.ArrAvailRoom,
                    OpBal = dto.OpBal,
                    ClBal = dto.ClBal,
                    Complimentary = dto.Complimentary,
                    BlockedRooms = dto.BlockedRooms,
                    OccAvail = dto.OccAvail,
                    Expense = dto.Expense,
                    SaleableRooms = dto.SaleableRooms,
                    DestChg = dto.DestChg,
                    Field1 = dto.Field1,
                    Field2 = dto.Field2,
                    Field3 = dto.Field3
                };


                // Log the created segment master object


                await _unitOfWork.DailySummaryRepository.AddAsync(obj);
                //context.HmsSegmentMasters.Add(segmentMaster);
                _unitOfWork.SaveChangesAsync(); // Await the save operation

                response.IsSuccess = true;
                response.Result = obj; // This should now have a generated SegmentId
                response.ResponseStatus = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.ResponseStatus = HttpStatusCode.InternalServerError;
            }

            return StatusCode((int)response.ResponseStatus, response);
        }



       
       

       
        [HttpDelete("DeleteDailySummary/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteDailySummary(int id)
        {
            var response = new ApiResponse();
            try
            {
                //var roomMaster = await _context.HmsRoomMasters.FindAsync(id);
                var data = await _unitOfWork.DailySummaryRepository.GetByIdAsync(id);
                if (data == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "not found" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                //_context.HmsRoomMasters.Remove(roomMaster);
                _unitOfWork.DailySummaryRepository.Delete(data);
                //await _context.SaveChangesAsync();
                _unitOfWork.SaveChangesAsync();
                response.IsSuccess = true;

                response.ResponseStatus = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.ResponseStatus = HttpStatusCode.InternalServerError;
            }
            return Ok(response);
        }
    }
}