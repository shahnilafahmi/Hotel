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
    public class RoomRepairHistoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public RoomRepairHistoryController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetByRoomId/{RoomId}")]
        public async Task<ActionResult<ApiResponse>> GetByRoomId(int? RoomId)
        {
            var response = new ApiResponse();
            try
            {
                //var roomMaster = await _context.HmsRoomMasters.FindAsync(id);
                if (RoomId==null) {
                   //var rows= _context.HmsRoomRepairHistories.Include(u => u.RoomMaster).ToListAsync();
                    var rows =await  _unitOfWork.RoomRepairHistoryRepository.GetAllWithIncludesAsync(u => u.RoomMaster).ToListAsync();
                    response.IsSuccess = true;
                    response.ResponseStatus = HttpStatusCode.OK;
                    response.Result=rows;
                    return Ok(response);
                }
                var obj = _context.HmsRoomRepairHistories.Include(u=>u.RoomMaster).Where(u=>u.RoomId==RoomId);
              
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Room not found" };
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

        [HttpGet("GetByTransDate")]
        public ActionResult<ApiResponse> GetByTransDate(DateTime TransDate)
        {
            var response = new ApiResponse();
            try
            {
                
                var obj = _unitOfWork.RoomRepairHistoryRepository.GetByDate(TransDate);
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

        // POST: api/RoomMaster
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateRoomMaster(RoomRepairHistoryCreateDto dto)
        {
            var response = new ApiResponse();
            try
            {
                var obj = new HmsRoomRepairHistory
                {
                  RoomId=dto.RoomId,
                  Reason=dto.Reason,
                  RoomNo=dto.RoomNo,
                  TransDate=dto.TransDate
            };

                //_context.HmsRoomMasters.Add(roomMaster);
               await  _unitOfWork.RoomRepairHistoryRepository.AddAsync(obj);
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

     
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> Delete(int id)
        {
            var response = new ApiResponse();
            try
            {
                //var roomMaster = await _context.HmsRoomMasters.FindAsync(id);
                var room = await _unitOfWork.RoomRepairHistoryRepository.GetByIdAsync(id);
                if (room == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Room not found" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                //_context.HmsRoomMasters.Remove(roomMaster);
                _unitOfWork.RoomRepairHistoryRepository.Delete(room);
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
