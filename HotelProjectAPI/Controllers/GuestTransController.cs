using HotelProject.Models.Models;
using HotelProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using HotelProject.Repository.IRepository;
using HotelProject.Models.DTOs;

namespace HotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestTransController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
       
        public GuestTransController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }



        [HttpPost("CreateGuestTran")]
        public async Task<IActionResult> CreateGuestTran([FromBody] GuestTranCreateDto dto)
        {
            var response = new ApiResponse();

            if (!ModelState.IsValid)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Invalid data." };
                response.ResponseStatus = HttpStatusCode.BadRequest;
                return BadRequest(response);
            }

            // Map DTO to Entity
            var guestTran = new HmsGuestTran
            {
                GuestNo = dto.GuestNo,
                Manual_Refno = dto.Manual_Refno,
                Res_no = dto.Res_no,
                Trans_date = dto.Trans_date,
                Trans_Amt = dto.Trans_Amt,
                Trans_Code = dto.Trans_Code,
                Remarks = dto.Remarks,
                Void_Reason = dto.Void_Reason,
                Trans_Confirm = dto.Trans_Confirm,
                Pay_Mode = dto.Pay_Mode,
                Currency_code = dto.Currency_code,
                Curr_rate = dto.Curr_rate,
                For_Curr_Amt = dto.For_Curr_Amt,
                Card_Code = dto.Card_Code,
                Card_Name = dto.Card_Name,
                Card_exp_date = dto.Card_exp_date,
                ChequeNo = dto.ChequeNo,
                Cheque_date = dto.Cheque_date,
                Tel_No = dto.Tel_No,
                Call_time = dto.Call_time,
                Call_duration = dto.Call_duration,
                Add_User = dto.Add_User,
                Add_time = dto.Add_time,
                Void_user = dto.Void_user,
                Void_Time = dto.Void_Time,
                Voucher_No = dto.Voucher_No,
                Acc_Code = dto.Acc_Code,
                Split_No = dto.Split_No,
                Posted = dto.Posted,
                Night_Audit = dto.Night_Audit,
                Ref_trans_id = dto.Ref_trans_id,
                Ref_trans_code = dto.Ref_trans_code,
                Ref_No = dto.Ref_No,
                Roomno = dto.Roomno,
                RoomId = dto.RoomId,
                ShiftID = dto.ShiftID,
                Trans_Mode = dto.Trans_Mode,
                FolioNo = dto.FolioNo
            };

            // Call AddAsync
            await _unitOfWork.HmsGuestTranRepository.AddAsync(guestTran);
        _unitOfWork.SaveChangesAsync();

            response.IsSuccess = true;
            response.ResponseStatus = HttpStatusCode.Created;
            response.Result = dto;

            return Ok(response);
        }


    }
}
