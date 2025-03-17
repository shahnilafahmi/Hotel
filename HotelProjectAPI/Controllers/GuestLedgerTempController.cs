using HotelProject.Data;
using HotelProject.Models.DTOs;
using HotelProject.Models.Models;
using HotelProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.EntityFrameworkCore;
using HotelProject.Repository.IRepository;

namespace HotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestLedgerTempController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public GuestLedgerTempController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/RoomMaster
        //[HttpGet]
        //public async Task<ActionResult<ApiResponse>> GetAll()
        //{
        //    var response = new ApiResponse();
        //    try
        //    {
        //        var roomMasters = await _unitOfWork.RoomRepairHistoryRepository.GetAllAsync() ;
        //        response.IsSuccess = true;
        //        response.Result = roomMasters;
        //        response.ResponseStatus = HttpStatusCode.OK;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.IsSuccess = false;
        //        response.ErrorMessages = new List<string> { ex.Message };
        //        response.ResponseStatus = HttpStatusCode.InternalServerError;
        //    }
        //    return Ok(response);
        //}

        //// GET: api/RoomMaster/5
        //[HttpGet("{RoomId}")]
        //public async Task<ActionResult<ApiResponse>> GetByRoomId(string RoomId)
        //{
        //    var response = new ApiResponse();
        //    try
        //    {
        //        //var roomMaster = await _context.HmsRoomMasters.FindAsync(id);
        //        if (RoomId==null || RoomId=="") {
        //           var rows= _unitOfWork.RoomRepairHistoryRepository.GetAllAsync();
        //            response.IsSuccess = true;
        //            response.ResponseStatus = HttpStatusCode.OK;
        //            response.Result=rows;
        //            return Ok(response);
        //        }
        //        var obj = _context.HmsRoomRepairHistories.Where(u=>u.RoomId.ToLower().Contains(RoomId.ToLower()));
              
        //        if (obj == null)
        //        {
        //            response.IsSuccess = false;
        //            response.ErrorMessages = new List<string> { "Room not found" };
        //            response.ResponseStatus = HttpStatusCode.NotFound;
        //            return NotFound(response);
        //        }
        //        response.IsSuccess = true;
        //        response.Result = obj;
        //        response.ResponseStatus = HttpStatusCode.OK;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.IsSuccess = false;
        //        response.ErrorMessages = new List<string> { ex.Message };
        //        response.ResponseStatus = HttpStatusCode.InternalServerError;
        //    }
        //    return Ok(response);
        //}

        //[HttpGet]
        //public async Task<ActionResult<ApiResponse>> GetByTransDate(DateTime TransDate)
        //{
        //    var response = new ApiResponse();
        //    try
        //    {
        //        //var roomMaster = await _context.HmsRoomMasters.FindAsync(id);
        //        if (TransDate == null )
        //        {
                   
        //            response.IsSuccess = false;
        //            response.ResponseStatus = HttpStatusCode.BadRequest;
        //            response.ErrorMessages = new List<string> { "PLEASE ENTER DATE IN THE INPUT" };
        //            return BadRequest(response);
        //        }
        //        var obj = _context.HmsRoomRepairHistories.Where(u=>u.TransDate.Date ==TransDate.Date);

        //        if (obj == null)
        //        {
        //            response.IsSuccess = false;
        //            response.ErrorMessages = new List<string> { "No Results To Show.Not Found Anything!" };
        //            response.ResponseStatus = HttpStatusCode.NotFound;
        //            return NotFound(response);
        //        }
        //        response.IsSuccess = true;
        //        response.Result = obj;
        //        response.ResponseStatus = HttpStatusCode.OK;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.IsSuccess = false;
        //        response.ErrorMessages = new List<string> { ex.Message };
        //        response.ResponseStatus = HttpStatusCode.InternalServerError;
        //    }
        //    return Ok(response);
        //}

      
        [HttpPost("CreateGuestLedger")]
        public async Task<ActionResult<ApiResponse>> CreateGuestLedger(GuestLedgerTempCreateDto dto)
        {
            var response = new ApiResponse();
            try
            {
                var obj = new HmsGuestLedgerTemp
                {
                 VoucherNo=dto.VoucherNo,
                 Amount=dto.Amount,
                 Date=dto.Date,
                 Guestno=dto.Guestno
 };

                //_context.HmsRoomMasters.Add(roomMaster);
               await  _unitOfWork.GuestLedgerTempRepository.AddAsync(obj);
              _unitOfWork.SaveChangesAsync();

                response.IsSuccess = true;
                response.Result = obj;
                response.ResponseStatus = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.ResponseStatus = HttpStatusCode.InternalServerError;
            }
            return Ok(response);
        }

     
        [HttpDelete("Delete/{GuestNo}")]
        public async Task<ActionResult<ApiResponse>> Delete(string GuestNo)
        {
            var response = new ApiResponse();
            try
            {
              
                var obj = _context.HmsGuestLedgerTemps.Where(u=>u.Guestno.ToLower()==GuestNo.ToLower());

                if (!obj.Any())
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Not Results to Delete.No results Found!" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

              
                _unitOfWork.GuestLedgerTempRepository.RemoveRange(obj);
                
               
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

        [HttpDelete("DeleteByDate/{ProvidedDate}")]
        public async Task<ActionResult<ApiResponse>> Delete(DateTime ProvidedDate)
        {
            var response = new ApiResponse();
            try
            {
               
                var obj = _unitOfWork.GuestLedgerTempRepository.GetByDate(ProvidedDate);
                

                if (!obj.Any())
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Not Results to Delete.No results Found!" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

               
               
                _unitOfWork.GuestLedgerTempRepository.RemoveRange(obj);
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
