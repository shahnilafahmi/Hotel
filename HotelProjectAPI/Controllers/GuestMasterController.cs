using HotelProject.Models.Models;
using HotelProject.Models;
using HotelProject.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using HotelProject.Models.DTOs;
using HotelProject.Services;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestMasterController : ControllerBase
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly GuestTransRoomMasterService guestTransRoomMasterService;

        public GuestMasterController(IUnitOfWork unitOfWork,GuestTransRoomMasterService guestTransRoomMasterService)
        {
            _unitOfWork = unitOfWork;
            this.guestTransRoomMasterService = guestTransRoomMasterService;
        }
        

       
       

        [HttpGet("GetAllGuests")]
        public async Task<IActionResult> GetAllGuests(string GuestFullName, string? GuestNo, string? GuestType, string? CityName,
    string? Nationality, string? DocNo, string? ResNo, string? RoomType, string? Roomno, string? ContactNo,
    string? RefrenceNo, int? NoOfDays,string?CardNo,string?plan,DateTime?Checkindate,DateTime?Checkoutdate)
        {
            var response = new ApiResponse();

            try
            {
                var items = await guestTransRoomMasterService.GetGuestRoomServiceDataAsync();
                var query = items.AsQueryable();
               
                if (!string.IsNullOrEmpty(GuestFullName))
                {
                    query = query.Where(g => g.FullName.ToLower()==GuestFullName.ToLower());
                }

                if (!string.IsNullOrEmpty(GuestNo))
                {
                    query = query.Where(g => g.GuestNo.Contains(GuestNo));
                }

                if (!string.IsNullOrEmpty(GuestType))
                {
                    query = query.Where(g => g.Guest_Type.ToString() == GuestType);
                }

                if (!string.IsNullOrEmpty(CityName))
                {
                    query = query.Where(u=>u.CityledgerMaster.City_Name.ToLower()== CityName.ToLower());
                }


                if (!string.IsNullOrEmpty(Nationality))
                {
                    query = query.Where(g => g.NationalityMasters.Nationality.ToLower()==Nationality.ToLower());
                }

                if (!string.IsNullOrEmpty(DocNo))
                {
                    query = query.Where(g => g.Doc_No.ToLower()==DocNo.ToLower());
                }

                if (!string.IsNullOrEmpty(ResNo))
                {
                    query = query.Where(g => g.Res_no.ToLower()==ResNo.ToLower());
                }

                if (!string.IsNullOrEmpty(RoomType))
                {
                    query = query.Where(g => g.RoomTypeMaster.Room_Type_Name==RoomType.ToLower());
                }

                if (!string.IsNullOrEmpty(Roomno))
                {
                    query = query.Where(g => g.Roomno.Contains(Roomno));
                }

                if (!string.IsNullOrEmpty(ContactNo))
                {
                    query = query.Where(g => g.Contact_No.Contains(ContactNo));
                }

                if (!string.IsNullOrEmpty(RefrenceNo))
                {
                    query = query.Where(g => g.Res_ref_no.Contains(RefrenceNo));
                }

                if (NoOfDays.HasValue)
                {
                    query = query.Where(g => g.NoOfDays == NoOfDays);
                }
                if (!string.IsNullOrEmpty(CardNo))
                {
                    query = query.Where(g => g.Reg_card_No.ToLower() == CardNo.ToLower());
                }
                if (!string.IsNullOrEmpty(plan)) {
                    query = query.Where(g => g.PlanMaster.PlanName.ToLower() == plan.ToLower());
                }
                if (Checkindate.HasValue)
                {
                    query = query.Where(g => g.Checkin_Date.Value.Date == Checkindate.Value.Date);
                }
                if (Checkoutdate.HasValue)
                {
                    query = query.Where(g => g.CheckOut_Date.Value.Date == Checkoutdate.Value.Date);
                }

                // Execute the query
                var guests = await query.ToListAsync();

                // Return the response
                response.IsSuccess = true;
                response.Result = guests;
                response.ResponseStatus = HttpStatusCode.OK;
            }
            catch (System.Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.ResponseStatus = HttpStatusCode.InternalServerError;
            }

            return Ok(response);
        }


        [HttpGet("GetGuestById/{id}")]
        public async Task<IActionResult> GetGuestById(int id)
        {
            var response = new ApiResponse();

            try
            {
                var items = await  guestTransRoomMasterService.GetGuestRoomServiceDataAsync();
                var guest=items.FirstOrDefault(u=>u.Guestid==id);
                if (guest == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Guest not found." };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                response.IsSuccess = true;
                response.Result = guest;
                response.ResponseStatus = HttpStatusCode.OK;
            }
            catch (System.Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.ResponseStatus = HttpStatusCode.InternalServerError;
            }

            return Ok(response);
        }

       
        [HttpPost("CreateGuest")]
     

        public async Task<IActionResult> CreateGuest([FromBody] CreateGuestMasterDto dto)
        {
            var response = new ApiResponse();

            if (!ModelState.IsValid)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Invalid data." };
                response.ResponseStatus = HttpStatusCode.BadRequest;
                return BadRequest(response);
            }

            try
            {
                // Map CreateGuestMasterDto to HmsGuestMaster
                var guest = new HmsGuestMaster
                {
                    GuestNo = dto.GuestNo,
                    Fname = dto.Fname,
                    Mname = dto.Mname,
                    Lname = dto.Lname,
                    FullName = dto.FullName,
                    Address1 = dto.Address1,
                    Address2 = dto.Address2,
                    Nationality_id = dto.Nationality_id,
                    Doctype_id = dto.Doctype_id,
                    Doc_No = dto.Doc_No,
                    DOB = dto.DOB,
                   
                    PP_issue_DAte = dto.PP_issue_DAte,
                    PP_Exp_Date = dto.PP_Exp_Date,
                    PP_issue_place = dto.PP_issue_place,
                    TA_code = dto.TA_code,
                    Cityledger_Id = dto.Cityledger_Id,
                    TA_VoucherNo = dto.TA_VoucherNo,
                    Email = dto.Email,
                    Remarks = dto.Remarks,
                    RoomId = dto.RoomId,
                    Roomtype_id = dto.Roomtype_id,
                    Tax = dto.Tax,
                    TD_Applicable = dto.TD_Applicable,
                    Room_Charge = dto.Room_Charge,
                    Service_Charge = dto.Service_Charge,
                    Pax = dto.Pax,
                    Child = dto.Child,
                    Sex = dto.Sex,
                    Reg_card_No = dto.Reg_card_No,
                    Checkin_Date = dto.Checkin_Date,
                    CheckOut_Date = dto.CheckOut_Date,
                    CheckIn_time = dto.CheckIn_time,
                    CheckOut_Time = dto.CheckOut_Time,
                    //Dep_Date = dto.Dep_Date,
                    Dep_Time = dto.Dep_Time,
                    Status = dto.Status,
                    Checkin_User = dto.Checkin_User,
                    Checkout_User = dto.Checkout_User,
                    Rent_Type = dto.Rent_Type,
                    Guest_Balance = dto.Guest_Balance,
                    Guest_Amount = dto.Guest_Amount,
                    Invoice_No = dto.Invoice_No,
                    Roomno = dto.Roomno,
                    Org_Roomno = dto.Org_Roomno,
                    Share_staus = dto.Share_staus,
                    Cityledger_Voucherno = dto.Cityledger_Voucherno,
                    Org_roomno_id = dto.Org_roomno_id,
                    Res_ref_no = dto.Res_ref_no,
                    GroupGuestid = dto.GroupGuestid,
                    Res_no = dto.Res_no,
                    Category_id = dto.Category_id,
                    Room_Transfer_Reason = dto.Room_Transfer_Reason,
                    Guest_Type = dto.Guest_Type,
                    Rate_Plan = dto.Rate_Plan,
                    Dont_Print_Rate = dto.Dont_Print_Rate,
                    ThanksMsg = dto.ThanksMsg,
                    Thanks_Method = dto.Thanks_Method,
                    Freq_id = dto.Freq_id,
                    Mode_id = dto.Mode_id,
                    Segment_id = dto.Segment_id,
                    Purpose_id = dto.Purpose_id,
                    Plan_id = dto.Plan_id,
                    PayMode = dto.PayMode,
                    NoOfDays = dto.NoOfDays,
                    HoldBill = dto.HoldBill,
                    RecheckIn = dto.RecheckIn,
                    EntryDepId = dto.EntryDepId,
                    VehNo = dto.VehNo,
                    Contact_No = dto.Contact_No,
                    Tel_No = dto.Tel_No,
                    Credit_Limit = dto.Credit_Limit,
                    Salesman_id = dto.Salesman_id,
                    Billing_Instruct_id = dto.Billing_Instruct_id,
                    FD_rate = dto.FD_rate,
                    FD_Post = dto.FD_Post,
                    Gst_status = dto.Gst_status,
                    Pending_Remarks = dto.Pending_Remarks,
                    Settlement_Trans_code = dto.Settlement_Trans_code,
                    Settlement_Amount = dto.Settlement_Amount,
                    Posting_roomno = dto.Posting_roomno,
                    Posting_GuestNo = dto.Posting_GuestNo,
                    Nat_Res = dto.Nat_Res,
                    ContNAme = dto.ContNAme,
                    Vat_amt = dto.Vat_amt,
                    Vatable_amt = dto.Vatable_amt,
                    TD_post_share = dto.TD_post_share
                };

                // Save guest to database
                await _unitOfWork.HmsGuestMasterRepository.AddAsync(guest);
                _unitOfWork.SaveChangesAsync();

                response.IsSuccess = true;
                response.Result = guest;
                response.ResponseStatus = HttpStatusCode.Created;
            }
            catch (System.Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.ResponseStatus = HttpStatusCode.InternalServerError;
            }

            return Ok(response);
        }


        // PUT: api/HmsGuestMaster/5
        [HttpPut("UpdateGuest/{id}")]
        public async Task<IActionResult> UpdateGuest(int id, [FromBody] HmsGuestMaster guest)
        {
            var response = new ApiResponse();

            if (id != guest.Guestid || !ModelState.IsValid)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Invalid data." };
                response.ResponseStatus = HttpStatusCode.BadRequest;
                return BadRequest(response);
            }

            try
            {
                var guestFromDb = await _unitOfWork.HmsGuestMasterRepository.GetByIdAsync(id);
                if (guestFromDb == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Guest not found." };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }
                if (guest.GuestNo != null) guestFromDb.GuestNo = guest.GuestNo;
                
                if (guest.Fname != null) guestFromDb.Fname = guest.Fname;
                if (guest.Mname != null) guestFromDb.Mname = guest.Mname;
                if (guest.Lname != null) guestFromDb.Lname = guest.Lname;
                if (guest.FullName != null) guestFromDb.FullName = guest.FullName;
                if (guest.Address1 != null) guestFromDb.Address1 = guest.Address1;
                if (guest.Address2 != null) guestFromDb.Address2 = guest.Address2;
                if (guest.Nationality_id.HasValue) guestFromDb.Nationality_id = guest.Nationality_id.Value;
                if (guest.Doctype_id.HasValue) guestFromDb.Doctype_id = guest.Doctype_id.Value;
                if (guest.Doc_No != null) guestFromDb.Doc_No = guest.Doc_No;
                if (guest.DOB.HasValue) guestFromDb.DOB = guest.DOB.Value;
                if (guest.PP_issue_DAte.HasValue) guestFromDb.PP_issue_DAte = guest.PP_issue_DAte.Value;
                if (guest.PP_Exp_Date.HasValue) guestFromDb.PP_Exp_Date = guest.PP_Exp_Date.Value;
                if (guest.PP_issue_place != null) guestFromDb.PP_issue_place = guest.PP_issue_place;
                if (guest.TA_code != null) guestFromDb.TA_code = guest.TA_code;
                if (guest.Cityledger_Id.HasValue) guestFromDb.Cityledger_Id = guest.Cityledger_Id.Value;
                if (guest.TA_VoucherNo != null) guestFromDb.TA_VoucherNo = guest.TA_VoucherNo;
                if (guest.Email != null) guestFromDb.Email = guest.Email;
                if (guest.Remarks != null) guestFromDb.Remarks = guest.Remarks;
                if (guest.RoomId.HasValue) guestFromDb.RoomId = guest.RoomId.Value;
                if (guest.Roomtype_id.HasValue) guestFromDb.Roomtype_id = guest.Roomtype_id.Value;
                if (guest.Tax.HasValue) guestFromDb.Tax = guest.Tax.Value;
                if (guest.TD_Applicable.HasValue) guestFromDb.TD_Applicable = guest.TD_Applicable.Value;
                if (guest.Room_Charge.HasValue) guestFromDb.Room_Charge = guest.Room_Charge.Value;
                if (guest.Service_Charge.HasValue) guestFromDb.Service_Charge = guest.Service_Charge.Value;
                if (guest.Pax.HasValue) guestFromDb.Pax = guest.Pax.Value;
                if (guest.Child.HasValue) guestFromDb.Child = guest.Child.Value;
                if (guest.Sex != null) guestFromDb.Sex = guest.Sex;
                if (guest.Reg_card_No != null) guestFromDb.Reg_card_No = guest.Reg_card_No;
                if (guest.Checkin_Date.HasValue) guestFromDb.Checkin_Date = guest.Checkin_Date.Value;
                if (guest.CheckOut_Date.HasValue) guestFromDb.CheckOut_Date = guest.CheckOut_Date.Value;
                if (guest.CheckIn_time.HasValue) guestFromDb.CheckIn_time = guest.CheckIn_time.Value;
                if (guest.CheckOut_Time.HasValue) guestFromDb.CheckOut_Time = guest.CheckOut_Time.Value;
               // if (guest.Dep_Date.HasValue) guestFromDb.Dep_Date = guest.Dep_Date.Value;
                if (guest.Dep_Time.HasValue) guestFromDb.Dep_Time = guest.Dep_Time.Value;
                if (guest.Status != null) guestFromDb.Status = guest.Status;
                if (guest.Checkin_User.HasValue) guestFromDb.Checkin_User = guest.Checkin_User.Value;
                if (guest.Checkout_User.HasValue) guestFromDb.Checkout_User = guest.Checkout_User.Value;
                if (guest.Rent_Type.HasValue) guestFromDb.Rent_Type = guest.Rent_Type.Value;
                if (guest.Guest_Balance.HasValue) guestFromDb.Guest_Balance = guest.Guest_Balance.Value;
                if (guest.Guest_Amount.HasValue) guestFromDb.Guest_Amount = guest.Guest_Amount.Value;
                if (guest.Invoice_No != null) guestFromDb.Invoice_No = guest.Invoice_No;
                if (guest.Roomno != null) guestFromDb.Roomno = guest.Roomno;
                if (guest.Org_Roomno != null) guestFromDb.Org_Roomno = guest.Org_Roomno;
                if (guest.Share_staus != null) guestFromDb.Share_staus = guest.Share_staus;
                if (guest.Cityledger_Voucherno != null) guestFromDb.Cityledger_Voucherno = guest.Cityledger_Voucherno;
                if (guest.Org_roomno_id.HasValue) guestFromDb.Org_roomno_id = guest.Org_roomno_id.Value;
                if (guest.Res_ref_no != null) guestFromDb.Res_ref_no = guest.Res_ref_no;
                if (guest.GroupGuestid != null) guestFromDb.GroupGuestid = guest.GroupGuestid;
                if (guest.Res_no != null) guestFromDb.Res_no = guest.Res_no;
                if (guest.Category_id.HasValue) guestFromDb.Category_id = guest.Category_id.Value;
                if (guest.Room_Transfer_Reason != null) guestFromDb.Room_Transfer_Reason = guest.Room_Transfer_Reason;
                if (guest.Guest_Type.HasValue) guestFromDb.Guest_Type = guest.Guest_Type.Value;
                if (guest.Rate_Plan.HasValue) guestFromDb.Rate_Plan = guest.Rate_Plan.Value;
                if (guest.Dont_Print_Rate.HasValue) guestFromDb.Dont_Print_Rate = guest.Dont_Print_Rate.Value;
                if (guest.ThanksMsg != null) guestFromDb.ThanksMsg = guest.ThanksMsg;
                if (guest.Thanks_Method.HasValue) guestFromDb.Thanks_Method = guest.Thanks_Method.Value;
                if (guest.Freq_id.HasValue) guestFromDb.Freq_id = guest.Freq_id.Value;
                if (guest.Mode_id.HasValue) guestFromDb.Mode_id = guest.Mode_id.Value;
                if (guest.Segment_id.HasValue) guestFromDb.Segment_id = guest.Segment_id.Value;
                if (guest.Purpose_id.HasValue) guestFromDb.Purpose_id = guest.Purpose_id.Value;
                if (guest.Plan_id.HasValue) guestFromDb.Plan_id = guest.Plan_id.Value;
                if (guest.PayMode != null) guestFromDb.PayMode = guest.PayMode;
                if (guest.NoOfDays.HasValue) guestFromDb.NoOfDays = guest.NoOfDays.Value;
                if (guest.HoldBill.HasValue) guestFromDb.HoldBill = guest.HoldBill.Value;
                if (guest.RecheckIn.HasValue) guestFromDb.RecheckIn = guest.RecheckIn.Value;
                if (guest.EntryDepId.HasValue) guestFromDb.EntryDepId = guest.EntryDepId.Value;
                if (guest.VehNo != null) guestFromDb.VehNo = guest.VehNo;
                if (guest.Contact_No != null) guestFromDb.Contact_No = guest.Contact_No;
                if (guest.Tel_No != null) guestFromDb.Tel_No = guest.Tel_No;
                if (guest.Credit_Limit.HasValue) guestFromDb.Credit_Limit = guest.Credit_Limit.Value;
                if (guest.Salesman_id.HasValue) guestFromDb.Salesman_id = guest.Salesman_id.Value;
                if (guest.Billing_Instruct_id.HasValue) guestFromDb.Billing_Instruct_id = guest.Billing_Instruct_id.Value;
                if (guest.FD_rate.HasValue) guestFromDb.FD_rate = guest.FD_rate.Value;
                if (guest.FD_Post.HasValue) guestFromDb.FD_Post = guest.FD_Post.Value;
                if (guest.Gst_status != null) guestFromDb.Gst_status = guest.Gst_status;
                if (guest.Pending_Remarks != null) guestFromDb.Pending_Remarks = guest.Pending_Remarks;
                if (guest.Settlement_Trans_code != null) guestFromDb.Settlement_Trans_code = guest.Settlement_Trans_code;
                if (guest.Settlement_Amount.HasValue) guestFromDb.Settlement_Amount = guest.Settlement_Amount.Value;
                if (guest.Posting_roomno.HasValue) guestFromDb.Posting_roomno = guest.Posting_roomno.Value;

                if (guest.Posting_GuestNo !=null) guestFromDb.Posting_GuestNo = guest.Posting_GuestNo;

                if (guest.Nat_Res != null) guestFromDb.Nat_Res = guest.Nat_Res;
                if (guest.ContNAme != null) guestFromDb.ContNAme = guest.ContNAme;
                if (guest.Vat_amt != null) guestFromDb.Vat_amt = guest.Vat_amt;
                if (guest.Vatable_amt != null) guestFromDb.Vatable_amt = guest.Vatable_amt;
                if (guest.TD_post_share != null) guestFromDb.TD_post_share = guest.TD_post_share;

                _unitOfWork.HmsGuestMasterRepository.Update(guestFromDb);
                _unitOfWork.SaveChangesAsync();

                response.IsSuccess = true;
                response.Result = guest;
                response.ResponseStatus = HttpStatusCode.OK;
            }
            catch (System.Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.ResponseStatus = HttpStatusCode.InternalServerError;
            }

            return Ok(response);
        }

        [HttpDelete("DeleteGuest/{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            var response = new ApiResponse();

            try
            {
                var guest = await _unitOfWork.HmsGuestMasterRepository.GetByIdAsync(id);
                if (guest == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Guest not found." };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }
              
                _unitOfWork.HmsGuestMasterRepository.Delete(guest);
                _unitOfWork.SaveChangesAsync();

                response.IsSuccess = true;
                response.Result = "Guest deleted successfully.";
                response.ResponseStatus = HttpStatusCode.OK;
            }
            catch (System.Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.ResponseStatus = HttpStatusCode.InternalServerError;
            }

            return Ok(response);
        }


    }
}
