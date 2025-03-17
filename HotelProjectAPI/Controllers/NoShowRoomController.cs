using HotelProject.Models.Models;
using HotelProject.Models;
using HotelProject.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using HotelProject.Models.DTOs;
using Microsoft.Extensions.Logging;
using HotelProject.Data;

namespace HotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoShowRoomController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext context;

        public NoShowRoomController(IUnitOfWork unitOfWork,ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            this.context = context;
        }

      
       
        [HttpPost("Create")]

        public async Task<IActionResult> Create([FromBody] NoShowRoomCreateDto dto)
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
                
                var obj = new HmsNoshowRoom
                {
                    NoShowRooms=dto.NoShowRooms,
                    ResNo=dto.ResNo,
                    ResRooms=dto.ResRooms,
                    ResRoomType=dto.ResRoomType,
                    RoomNoId=dto.RoomNoId
                };



                await _unitOfWork.NoShowRoomRepository.AddAsync(obj);
               
                _unitOfWork.SaveChangesAsync(); 

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



       
       

        // DELETE: api/hmsTransgroupMaster/{id}
        [HttpDelete("Delete/{ResNo}")]
        public async Task<ActionResult<ApiResponse>> Delete(string ResNo)
        {
            var response = new ApiResponse();
            try
            {
                //var roomMaster = await _context.HmsRoomMasters.FindAsync(id);

                //var data = context.HmsNoshowRooms.Where(u => u.ResNo.ToLower() == ResNo.ToLower());
                var rows = await _unitOfWork.NoShowRoomRepository.GetAsQueryAble();
                var data = rows.Where(u => u.ResNo.ToLower() == ResNo.ToLower());
                if (data == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "not found" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                //_context.HmsRoomMasters.Remove(roomMaster);
                _unitOfWork.NoShowRoomRepository.RemoveRange(data);
               context.HmsNoshowRooms.RemoveRange(data);
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