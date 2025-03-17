using HotelProject.Models.Models;
using HotelProject.Models;
using HotelProject.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using HotelProject.Models.DTOs;
using HotelProject.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomBlockController : ControllerBase
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext context;

        public RoomBlockController(IUnitOfWork unitOfWork,ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            this.context = context;
        }
        

        // GET: api/HmsGuestMaster
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = new ApiResponse();

            try
            {
                //var guests = await context.HmsRoomBlockRooms.Include(u => u.ReservationDetailTable).Include(u => u.RoomMaster).ToListAsync();
                var data = _unitOfWork.RoomBlockRepository.GetAllWithIncludesAsync(u => u.ReservationDetailTable, u => u.RoomMaster);
                var guests =await  data.ToListAsync();
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
        [HttpGet("GetRoomBlockByDate")]
        public async Task<ActionResult<ApiResponse>> GetRoomBlockByDate(DateTime Date)
        {
            var response = new ApiResponse();
            try
            {
                //var roomMaster = await _context.HmsRoomMasters.FindAsync(id);

                //var obj = await context.HmsRoomBlockRooms.Include(u => u.ReservationDetailTable).Include(u => u.RoomMaster).Where(u => u.Date.Date == Date.Date).ToListAsync();
                var data = _unitOfWork.RoomBlockRepository.GetAllWithIncludesAsync(u => u.ReservationDetailTable, u => u.RoomMaster);
                var obj= await data.Where(u => u.Date.Date == Date.Date).ToListAsync();
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

        // GET: api/HmsGuestMaster/5
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = new ApiResponse();

            try
            {
                var guest =await context.HmsRoomBlockRooms.Include(u => u.ReservationDetailTable).Include(u => u.RoomMaster).FirstOrDefaultAsync(u=>u.Id==id);
                if (guest == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "not found." };
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

    
        [HttpPost("Create")]
      
        public async Task<IActionResult> Create([FromBody] RoomBLockCreateDto dto)
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
                var obj = new HmsRoomBlockRoom
                {
                ResDetId=dto.ResDetId,
                RoomId=dto.RoomId,
                Date=dto.Date
                };

                // Save guest to database
                await _unitOfWork.RoomBlockRepository.AddAsync(obj);
                _unitOfWork.SaveChangesAsync();

                response.IsSuccess = true;
                response.Result = obj;
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
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HmsRoomBlockRoom data)
        {
            var response = new ApiResponse();

            if (id != data.Id|| !ModelState.IsValid)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Invalid data." };
                response.ResponseStatus = HttpStatusCode.BadRequest;
                return BadRequest(response);
            }

            try
            {
                var obj = await _unitOfWork.RoomBlockRepository.GetByIdAsync(id);
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "not found." };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }
                if (data.ResDetId != null) {
                    obj.ResDetId = data.ResDetId;
                }
                if (data.RoomId != null)
                {
                    obj.RoomId = data.RoomId;
                }
                if (data.Date != null)
                {
                    obj.Date = data.Date;
                }

                _unitOfWork.RoomBlockRepository.Update(obj);
                _unitOfWork.SaveChangesAsync();

                response.IsSuccess = true;
                response.Result = obj;
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

       
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new ApiResponse();

            try
            {
                var obj = await _unitOfWork.RoomBlockRepository.GetByIdAsync(id);
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { " not found." };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }
              
                _unitOfWork.RoomBlockRepository.Delete(obj);
                _unitOfWork.SaveChangesAsync();

                response.IsSuccess = true;
                response.Result = "ModeDescription deleted successfully.";
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
