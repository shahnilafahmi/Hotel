using HotelProject.Models.DTOs;
using HotelProject.Models.Models;
using HotelProject.Repository.IRepository.IMaster;
using HotelProject.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using HotelProject.Models;
using HotelProject.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempInHouseGstController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext context;

        public TempInHouseGstController(IUnitOfWork unitOfWork,ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            this.context = context;
        }

        [HttpGet("GetByTransDate")]
        public async Task<ActionResult<ApiResponse>> GetByTransDate(DateTime Date)
        {
            var response = new ApiResponse();
            try
            {
                //var roomMaster = await _context.HmsRoomMasters.FindAsync(id);
                
                //var obj = await context.TempInhouseGST.Where(u => u.CheckIn.Date == Date.Date).ToListAsync();
                var obj = _unitOfWork.TempInHouseGstRepository.GetByDate(Date);
                if (!obj.Any())
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "No Results To Show.Not Found Anything!" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }
                response.IsSuccess = true;
                response.Result = obj;
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


        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] TempInHouseGstCreateDto dto)
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
                var obj = new TempInhouseGST
                {
                    RoomNo = dto.RoomNo,
                    GStName = dto.GStName,
                    Pax = dto.Pax,
                    CheckIn = dto.CheckIn,
                    DepDate = dto.DepDate,
                    Nationality = dto.Nationality,
                    City_Name = dto.City_Name,
                    RoomRate = dto.RoomRate,
                    Status = dto.Status,
                    RoomMate = dto.RoomMate,
                    VacantRoom = dto.VacantRoom,
                    Nation_Rmmt = dto.Nation_Rmmt,
                    Plan_Des = dto.Plan_Des,
                    OrgRoom = dto.OrgRoom,
                    RoomNoCHAR = dto.RoomNoCHAR,
                    SORTNO = dto.SORTNO,
                    Checkin_Time = dto.Checkin_Time,
                    GuestNo = dto.GuestNo,
                    CardNo = dto.CardNo
                };

                await _unitOfWork.TempInHouseGstRepository.AddAsync(obj);
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

            return StatusCode((int)response.ResponseStatus, response);
        }

        [HttpDelete("DeleteTempGuestView/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteTempGuestView(int id)
        {
            var response = new ApiResponse();
            try
            {
                var data = await _unitOfWork.TempInHouseGstRepository.GetByIdAsync(id);
                if (data == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Not found" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                _unitOfWork.TempInHouseGstRepository.Delete(data);
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
