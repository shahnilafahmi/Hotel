using HotelProject.Models.Models;
using HotelProject.Models;
using HotelProject.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using HotelProject.Models.DTOs;

namespace HotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailySummaryGroupMasterController : ControllerBase
    {


        private readonly IUnitOfWork _unitOfWork;
        public DailySummaryGroupMasterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        

        // GET: api/HmsGuestMaster
        [HttpGet("GetAllDailySummaryGroup")]
        public async Task<IActionResult> GetAllDailySummaryGroup()
        {
            var response = new ApiResponse();

            try
            {
                var guests = await _unitOfWork.DailySummaryGroupMasterRepository.GetAllAsync();
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

        // GET: api/HmsGuestMaster/5
        [HttpGet("GetDailySummaryGroupById/{id}")]
        public async Task<IActionResult> GetDailySummaryGroupById(int id)
        {
            var response = new ApiResponse();

            try
            {
                var guest = await _unitOfWork.DailySummaryGroupMasterRepository.GetByIdAsync(id);
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

       
        [HttpPost("CreateDailySummaryGroup")]
      

        public async Task<IActionResult> CreateDailySummaryGroup([FromBody] DailySummaryGroupMasterCreateDto dto)
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
                var obj = new HmsDailySummaryGroupMaaster
                {
                    DailySummaryGroupName=dto.DailySummaryGroupName,
                    Visible=dto.Visible
                   
                };

                // Save guest to database
                await _unitOfWork.DailySummaryGroupMasterRepository.AddAsync(obj);
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
        [HttpPut("UpdateDailySummaryGroup/{id}")]
        public async Task<IActionResult> UpdateDailySummaryGroup(int id, [FromBody] HmsDailySummaryGroupMaaster data)
        {
            var response = new ApiResponse();

            if (id != data.DailySummaryGroupId || !ModelState.IsValid)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Invalid data." };
                response.ResponseStatus = HttpStatusCode.BadRequest;
                return BadRequest(response);
            }

            try
            {
                var obj = await _unitOfWork.DailySummaryGroupMasterRepository.GetByIdAsync(id);
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "not found." };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }
                if (data.DailySummaryGroupName != null) {
                    obj.DailySummaryGroupName = data.DailySummaryGroupName;
                }

                if (data.Visible != null)
                {
                    obj.Visible = data.Visible;
                }

                _unitOfWork.DailySummaryGroupMasterRepository.Update(obj);
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

        // DELETE: api/HmsGuestMaster/5
        [HttpDelete("DeleteDailySummaryGroup/{id}")]
        public async Task<IActionResult> DeleteDailySummaryGroup(int id)
        {
            var response = new ApiResponse();

            try
            {
                var guest = await _unitOfWork.DailySummaryGroupMasterRepository.GetByIdAsync(id);
                if (guest == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Guest not found." };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }
              
                _unitOfWork.DailySummaryGroupMasterRepository.Delete(guest);
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
