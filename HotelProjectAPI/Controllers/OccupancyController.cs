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
    public class OccupancyController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext context;

        public OccupancyController(IUnitOfWork unitOfWork,ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            this.context = context;
        }

        // GET: api/hmsTransgroupMaster
        //[HttpGet]
        

      
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(DateOnly )
        //{
        //    var response = new ApiResponse();
        //    try
        //    {
        //        var item = await _unitOfWork.HmsFloorMasterRepository.GetByIdAsync(id);
        //        if (item == null)
        //        {
        //            response.IsSuccess = false;
        //            response.ErrorMessages = new List<string> { "Item not found." };
        //            response.ResponseStatus = HttpStatusCode.NotFound;
        //        }
        //        else
        //        {
        //            response.IsSuccess = true;
        //            response.Result = item;
        //            response.ResponseStatus = HttpStatusCode.OK;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.IsSuccess = false;
        //        response.ErrorMessages = new List<string> { ex.Message };
        //        response.ResponseStatus = HttpStatusCode.InternalServerError;
        //    }
        //    return StatusCode((int)response.ResponseStatus, response);
        //}

        // POST: api/hmsTransgroupMaster
        [HttpPost("Create")]

        public async Task<IActionResult> Create([FromBody] OcuupanyCreateDto dto)
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
                
                var obj = new HmsOccupancy
                {
                    ResNo = dto.ResNo,
                    GuestNo = dto.GuestNo,
                    NoofRooms = dto.NoofRooms,
                    Source = dto.Source,
                    StayDate = dto.StayDate,
                    RoomType = dto.RoomType,
                    Status = dto.Status,
                    CityledgerCode = dto.CityledgerCode,
                    BalRooms = dto.BalRooms,
                    CheckinDate = dto.CheckinDate,
                    CheckoutDate = dto.CheckoutDate,
                    Rate = dto.Rate,
                    RoomNo = dto.RoomNo,
                    RoomId = dto.RoomId
                };



                await _unitOfWork.OccupanyRepository.AddAsync(obj);
               
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
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<ApiResponse>> Delete(int id)
        {
            var response = new ApiResponse();
            try
            {
                //var roomMaster = await _context.HmsRoomMasters.FindAsync(id);
                var data = await _unitOfWork.OccupanyRepository.GetByIdAsync(id);
                if (data == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "not found" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                //_context.HmsRoomMasters.Remove(roomMaster);
                _unitOfWork.OccupanyRepository.Delete(data);
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