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
    public class NationalityMasterController : ControllerBase
    {


        private readonly IUnitOfWork _unitOfWork;
        public NationalityMasterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        

        // GET: api/HmsGuestMaster
        [HttpGet("GetAllNationality")]
        public async Task<IActionResult> GetAllNationality()
        {
            var response = new ApiResponse();

            try
            {
                var obj = await _unitOfWork.HmsNationalityMasterRepository.GetAllAsync();
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

        // GET: api/HmsGuestMaster/5
        [HttpGet("GetNationalityById/{id}")]
        public async Task<IActionResult> GetNationalityById(int id)
        {
            var response = new ApiResponse();

            try
            {
                var obj = await _unitOfWork.HmsNationalityMasterRepository.GetByIdAsync(id);
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

        [HttpPost("CreateNationality")]
       
        public async Task<IActionResult> CreateNationality([FromBody] NationalityMasterCreateDto dto)
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
                var obj = new HmsNationalityMaster
                {
                    Nat_Code=dto.Nat_Code,
                    Nationality=dto.Nationality,
                };

                // Save guest to database
                await _unitOfWork.HmsNationalityMasterRepository.AddAsync(obj);
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
        [HttpPut("UpdateNationality/{id}")]
        public async Task<IActionResult> UpdateNationality(int id, [FromBody] HmsNationalityMaster data)
        {
            var response = new ApiResponse();

            if (id != data.Nat_id || !ModelState.IsValid)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Invalid data." };
                response.ResponseStatus = HttpStatusCode.BadRequest;
                return BadRequest(response);
            }

            try
            {
                var obj = await _unitOfWork.HmsNationalityMasterRepository.GetByIdAsync(id);
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "not found." };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }
                if (data.Nat_Code != null) {
                    obj.Nat_Code = data.Nat_Code;
                }

                if (data.Nationality != null)
                {
                    obj.Nationality = data.Nationality;
                }

                _unitOfWork.HmsNationalityMasterRepository.Update(obj);
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
        [HttpDelete("DeleteNationality/{id}")]
        public async Task<IActionResult> DeleteNationality(int id)
        {
            var response = new ApiResponse();

            try
            {
                var obj = await _unitOfWork.HmsNationalityMasterRepository.GetByIdAsync(id);
              
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Not found." };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }
              
                _unitOfWork.HmsNationalityMasterRepository.Delete(obj);
                _unitOfWork.SaveChangesAsync();

                response.IsSuccess = true;
                response.Result = "NatioNality deleted successfully.";
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
