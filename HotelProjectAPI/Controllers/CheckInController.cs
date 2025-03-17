using Azure;
using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Models.DTOs;
using HotelProject.Models.Models;
using HotelProject.Repository.IRepository;
using HotelProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckInController : ControllerBase
    {
        private readonly GuestTransRoomMasterService guestTransRoomMasterService;
        private readonly IUnitOfWork unitOfWork;
        private readonly ApplicationDbContext context;

        public CheckInController(ApplicationDbContext context, GuestTransRoomMasterService guestTransRoomMasterService, IUnitOfWork unitOfWork)
        {

            this.context = context;
            this.guestTransRoomMasterService = guestTransRoomMasterService;
            this.unitOfWork = unitOfWork;
        }
        [HttpGet("GetCheckInInffo")]
        public async Task<IActionResult> GetCheckInInfo()
        {
            var response = new ApiResponse();
            try
            {
                var items = await guestTransRoomMasterService.GetGuestRoomServiceDataAsync();

                response.IsSuccess = true;
                response.Result = items;
                response.ResponseStatus = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.ResponseStatus = HttpStatusCode.InternalServerError;
            }
            return StatusCode((int)response.ResponseStatus, response);
        }

        [HttpPost]
        public async Task<IActionResult> GuestCheckIn(GuestCheckInDTO dto)
        {
            var response = new ApiResponse();
            try
            {
               
                if (dto == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string>() { "DTO is null.Make sure to Provide data to DTO" };
                    response.ResponseStatus = HttpStatusCode.BadRequest;
                }
                var FullName = $"{dto.FirstName} {dto.MiddleName} {dto.LastName}";
                var FdPost = false;
                if (dto.FDayRate.HasValue)
                {
                    FdPost = true;
                }
                var guestData = new HmsGuestMaster()
                {


                    GuestNo = dto.GuestNo,
                    Fname = dto.FirstName,
                    Mname = dto.MiddleName,
                    Lname = dto.LastName,
                    FullName = FullName,

                    Address1 = dto.Residence,
                    Guest_Type = dto.GuestType,
                    Contact_No = dto.ContactNo,
                    DOB = dto.DateOfBirth,
                    Email = dto.Email,
                    Sex = dto.Sex,
                    Pax = dto.Pax,
                    Res_ref_no = dto.RefNo,
                    Child = dto.Children,
                    Remarks = dto.Remarks,
                    Nationality_id = dto.NationalityId,
                    Reg_card_No = dto.CardNo,
                    Roomtype_id = dto.RoomTypeId,
                    Roomno = dto.RoomNo,
                    AgentId = dto.AgentId,
                    FD_rate = dto.FDayRate,
                    FD_Post = FdPost,
                    PayMode = dto.PaymentMode,
                    Company = dto.Company,
                    CareOf = dto.CareOf,
                    PostingRate = dto.PostingRate,
                    Rate_Plan = dto.RatePlan,
                    Billing_Instruct_id = dto.BillInstructionId,
                    Credit_Limit = dto.CreditLimit,
                    Plan_id = dto.PlanId,
                    Dont_Print_Rate = dto.DontPrintRate,
                    Doctype_id = dto.DocTypeId,
                    Doc_No = dto.DocNo,
                    Purpose_id = dto.PurposeId,
                    Mode_id = dto.ModeId,
                    Segment_id = dto.SegmentId,
                    Freq_id = dto.FrequencyId,
                    GroupGuestid = dto.GuestGroupId,
                    Checkin_Date = dto.CheckInDate.Date,
                    CheckOut_Date = dto.CheckOutDate.Date,
                    NoOfDays = dto.NumberOfDays,
                    CheckIn_time = dto.CheckInTime.TimeOfDay,
                    CheckOut_Time = dto.CheckOutTime.TimeOfDay,
                    Res_no = dto.ResNo
                };
                await unitOfWork.HmsGuestMasterRepository.AddAsync(guestData);
                unitOfWork.SaveChangesAsync();
                response.IsSuccess = true;
                response.Result = guestData;
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
