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
    public class RoomMateController : ControllerBase
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext context;

        public RoomMateController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            this.context = context;
        }


        // GET: api/HmsGuestMaster
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = new ApiResponse();

            try
            {
                //var guests = await context.HmsRoomMates.Include(u => u.DocMaster).Include(u => u.NationalityMaster).ToListAsync();
                var guests = await _unitOfWork.RoomMateRepository.GetAllWithIncludesAsync(u => u.DocMaster, u => u.NationalityMaster).ToListAsync();
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

        [HttpGet("GetByGuestNo/{Guestno}")]
        public async Task<IActionResult> GetByGuestNo(string? Guestno)
        {
            var response = new ApiResponse();

            try
            {

               
                if (Guestno==null) {
                   var rows= await context.HmsRoomMates.Include(u => u.DocMaster).Include(u => u.NationalityMaster).ToListAsync();
                    response.IsSuccess = true;
                    response.Result = rows;
                    response.ResponseStatus = HttpStatusCode.OK;
                }
                var obj = await _unitOfWork.RoomMateRepository.GetAllWithIncludesAsync(u => u.DocMaster, u => u.NationalityMaster)
                    .Where(u => u.GuestNo.ToLower().Contains(Guestno.ToLower())).ToListAsync();
               
      //          var obj = context.HmsRoomMates.Include(u => u.DocMaster).Include(u => u.NationalityMaster)
      //.AsNoTracking()
      //.Where(u => u.GuestNo.ToLower().Contains(Guestno.ToLower()));



                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Not found." };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

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

        [HttpPost("Create")]

        public async Task<IActionResult> Create([FromBody] RoomMateCreateDto dto)
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
                var obj = new HmsRoomMate
                {
                    GuestNo = dto.GuestNo,
                    CheckoutDate = dto.CheckoutDate,
                    Dob = dto.Dob,
                    RmName = dto.RmName,
                    Status = dto.Status,
                    DocId = dto.DocId,
                    DocNo = dto.DocNo,
                };

                // Save guest to database
                await _unitOfWork.RoomMateRepository.AddAsync(obj);
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
        public async Task<IActionResult> Update(int id, [FromBody] HmsRoomMate data)
        {
            var response = new ApiResponse();

            if (id != data.Id || !ModelState.IsValid)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Invalid data." };
                response.ResponseStatus = HttpStatusCode.BadRequest;
                return BadRequest(response);
            }

            try
            {
                var obj = await _unitOfWork.RoomMateRepository.GetByIdAsync(id);
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "not found." };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }
                if (data.Status != null)
                {
                    obj.Status = data.Status;
                }

                if (data.CheckoutDate != null)
                {
                    obj.CheckoutDate = data.CheckoutDate;
                }
                if (data.GuestNo != null)
                {
                    obj.GuestNo = data.GuestNo;
                }
                if (data.Dob != null)
                {
                    obj.Dob = data.Dob;
                }
                if (data.DocId != null)
                {
                    obj.DocId = data.DocId;
                }

                if (data.NatId != null)
                {
                    obj.NatId = data.NatId;
                }
                if (data.RmName != null)
                {
                    obj.RmName = data.RmName;
                }

                _unitOfWork.RoomMateRepository.Update(obj);
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
        [HttpDelete("Delete/{Guestno}")]
        public async Task<IActionResult> Delete(string? Guestno)
        {
            var response = new ApiResponse();

            try
            {
                if (Guestno == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Please Provide GuestNo in Input." };
                    response.ResponseStatus = HttpStatusCode.BadRequest;
                    return NotFound(response);
                }
                var obj = context.HmsRoomMates
     .AsNoTracking()
     .Where(u => u.GuestNo.ToLower() ==Guestno.ToLower());
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Not found." };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                context.HmsRoomMates.RemoveRange(obj);
                _unitOfWork.SaveChangesAsync();

                response.IsSuccess = true;
                response.Result = "RoomMate deleted successfully.";
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
