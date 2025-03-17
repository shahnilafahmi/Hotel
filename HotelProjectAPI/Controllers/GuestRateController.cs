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
    public class GuestRateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public GuestRateController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetAllRates")]
        public async Task<ActionResult<ApiResponse>> GetAllRates()
        {
            var response = new ApiResponse();
            try
            {
                var rates = await _unitOfWork.GuestRatesRepository.GetAllAsync();
                response.IsSuccess = true;
                response.Result = rates;
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

        [HttpGet("GetRateByResNO/{resNo}")]
        public async Task<ActionResult<ApiResponse>> GetRateByResNO(string resNo)
        {
            var response = new ApiResponse();
            try
            {
                // Query using case-insensitive comparison and trimming any potential spaces
                var data = await _unitOfWork.GuestRatesRepository.GetAsQueryAble();
                var rate = data.FirstOrDefault(c => c.Res_no.Trim().ToLower() == resNo.Trim().ToLower());
                //var rate = _context.HmsGuestRateTables.FirstOrDefault(c => c.Res_no.Trim().ToLower() == resNo.Trim().ToLower());

                if (rate == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Rate not found" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                response.IsSuccess = true;
                response.Result = rate;
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

        [HttpPost]
        [Route("CreateRate")]
        public async Task<ActionResult<ApiResponse>> CreateRate(CreateGuestRateDto rateDto)
        {
            var response = new ApiResponse();
            try
            {
                // Get all rates asynchronously using GetAllAsync
                var allRates = await _unitOfWork.GuestRatesRepository.GetAllAsync();

                // Order the rates by RateId, select the highest RateId
                var maxRateId = allRates
                    .OrderByDescending(r => r.RateId)
                    .Select(r => r.RateId)
                    .FirstOrDefault();

                // Parse the maxRateId as an integer, if available, otherwise start from 1
                int newRateId = 1;
                if (!string.IsNullOrEmpty(maxRateId) && int.TryParse(maxRateId, out int currentMaxId))
                {
                    newRateId = currentMaxId + 1;
                }

                var rate = new HmsGuestRateTable
                {
                    RateId = newRateId.ToString(), // Assign the new RateId
                    Res_no = rateDto.Res_no,
                    Room_Type_id = rateDto.Room_Type_id,
                    Rate = rateDto.Rate,
                    Remarks = rateDto.Remarks,
                    Posting_Date = rateDto.Posting_Date,
                    GuestNo = rateDto.GuestNo
                };

                await _unitOfWork.GuestRatesRepository.AddAsync(rate);
                 _unitOfWork.SaveChangesAsync();

                response.IsSuccess = true;
                response.Result = rate;
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
        [HttpPut("UpdateRate/{resno}")]
        public async Task<ActionResult<ApiResponse>> UpdateRate(string resno, UpdateGuestRateDto rateDto)
        {
            var response = new ApiResponse();
            try
            {
                // Query the database to find the record by res_no (without formatting)
                //var rate = _context.HmsGuestRateTables.FirstOrDefault(c => c.Res_no.Trim().ToLower() == resno.Trim().ToLower());
                var data = await _unitOfWork.GuestRatesRepository.GetAsQueryAble();
                var rate = data.FirstOrDefault(c => c.Res_no.Trim().ToLower() == resno.Trim().ToLower());
                if (rate == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Rate not found" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                // Update fields only if provided in the rateDto
                if (!string.IsNullOrEmpty(rateDto.Res_no))
                {
                    rate.Res_no = rateDto.Res_no;
                }
                if (!string.IsNullOrEmpty(rateDto.Room_Type_id))
                {
                    rate.Room_Type_id = rateDto.Room_Type_id;
                }
                if (!string.IsNullOrEmpty(rateDto.Rate))
                {
                    rate.Rate = rateDto.Rate;
                }
                if (!string.IsNullOrEmpty(rateDto.Remarks))
                {
                    rate.Remarks = rateDto.Remarks;
                }
               if (!string.IsNullOrEmpty(rateDto.GuestNo))
                {
                    rate.GuestNo = rateDto.GuestNo;
                }

                // Update the record in the repository
                _unitOfWork.GuestRatesRepository.Update(rate);
                 _unitOfWork.SaveChangesAsync();  // Ensure asynchronous saving

                response.IsSuccess = true;
                response.Result = rate;
                response.ResponseStatus = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                var errorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    errorMessage += " Inner exception: " + ex.InnerException.Message;
                }
                response.ErrorMessages = new List<string> { errorMessage };
                response.ResponseStatus = HttpStatusCode.InternalServerError;
            }

            return Ok(response);
        }

        [HttpDelete("DeleteRate/{resno}")]
        public async Task<ActionResult<ApiResponse>> DeleteRate(string resno)
        {
            var response = new ApiResponse();
            try
            {
                // Ensure 'resno' is trimmed and compared in a case-insensitive way
                var rate = _context.HmsGuestRateTables.FirstOrDefault(c => c.Res_no.Trim().ToLower() == resno.Trim().ToLower());

                if (rate == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Rate not found" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                // Delete the rate from the repository
                _unitOfWork.GuestRatesRepository.Delete(rate);

                // Asynchronously save the changes
                 _unitOfWork.SaveChangesAsync();

                response.IsSuccess = true;
                response.ResponseStatus = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                var errorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    errorMessage += " Inner exception: " + ex.InnerException.Message;
                }
                response.ErrorMessages = new List<string> { errorMessage };
                response.ResponseStatus = HttpStatusCode.InternalServerError;
            }

            return Ok(response);
        }

    }
}
