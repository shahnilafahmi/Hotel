using HotelProject.Models.Models;
using HotelProject.Models;
using HotelProject.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using HotelProject.Models.DTOs;
using Microsoft.Extensions.Logging;
using HotelProject.Data;
using HotelProject.Services;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestGroupMaster : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext context;
        private readonly GuestTransRoomMasterService guestTransRoomMasterService;

        public GuestGroupMaster(IUnitOfWork unitOfWork,ApplicationDbContext context,GuestTransRoomMasterService guestTransRoomMasterService)
        {
            _unitOfWork = unitOfWork;
            this.context = context;
            this.guestTransRoomMasterService = guestTransRoomMasterService;
        }

        // GET: api/hmsTransgroupMaster
        [HttpGet("GetAll")]

        public async Task<IActionResult> GetAll()
        {
            var response = new ApiResponse();
            try
            {
                var items = await _unitOfWork.HmsGuestGroupRepository.GetAllAsync();
               
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
        //public async Task<IActionResult> GetAll()
        //{
        //    var response = new ApiResponse();
        //    try
        //    {
        //        var items = await guestTransRoomMasterService.GetGuestRoomServiceDataAsync();
        //        response.IsSuccess = true;
        //        response.Result = items;
        //        response.ResponseStatus = HttpStatusCode.OK;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.IsSuccess = false;
        //        response.ErrorMessages = new List<string> { ex.Message };
        //        response.ResponseStatus = HttpStatusCode.InternalServerError;
        //    }
        //    return StatusCode((int)response.ResponseStatus, response);
        //}


        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = new ApiResponse();
            try
            {
                 var item = await _unitOfWork.HmsGuestGroupRepository.GetByIdAsync(id);
                
                
                    response.IsSuccess = true;
                    response.Result = item;
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

      
        [HttpPost("Create")]

        public async Task<IActionResult> Create([FromBody] GuestGroupMasterCreateDto dto)
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
                var obj = new HmsGuestGroupMaster
                {
                   Group_Name=dto.GroupName,
                };

               


                await _unitOfWork.HmsGuestGroupRepository.AddAsync(obj);
               
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



        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HmsGuestGroupMaster data)
        {
            var response = new ApiResponse();
            if (id != data.Group_id)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "ID mismatch." };
                response.ResponseStatus = HttpStatusCode.BadRequest;
                return StatusCode((int)response.ResponseStatus, response);
            }

            try
            {

                _unitOfWork.HmsGuestGroupRepository.Update(data);
                _unitOfWork.SaveChangesAsync();
                response.IsSuccess = true;
                response.Result = data;
                response.ResponseStatus = HttpStatusCode.NoContent;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.ResponseStatus = HttpStatusCode.InternalServerError;
            }

            return StatusCode((int)response.ResponseStatus, response);
        }

        
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<ApiResponse>> Delete(int id)
        {
            var response = new ApiResponse();
            try
            {
               
                var data = await _unitOfWork.HmsGuestGroupRepository.GetByIdAsync(id);
                if (data == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Room not found" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

               
                _unitOfWork.HmsGuestGroupRepository.Delete(data);
               
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