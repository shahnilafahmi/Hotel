using HotelProject.Models.Models;
using HotelProject.Models;
using HotelProject.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using HotelProject.Models.DTOs;
using Microsoft.Extensions.Logging;
using HotelProject.Data;
using Microsoft.EntityFrameworkCore;
using HotelProject.Repository;
using Microsoft.IdentityModel.Tokens;

namespace HotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext context;

        public CurrencyController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            this.context = context;
        }


        [HttpGet("GetAllCurrencies")]
       
        public async Task<IActionResult> GetAllCurrencies()
        {
            var response = new ApiResponse();
            try
            {
                var items = await _unitOfWork.HmsCurrency.GetAllAsync();
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


        [HttpGet("GetCurrencyById/{id}")]
      
        public async Task<IActionResult> GetById(int id)
        {
            var response = new ApiResponse();
            try
            {
                var item = await _unitOfWork.HmsCurrency
                   .GetByIdAsync(id);
                if (item == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Item not found." };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                }
                else
                {
                    response.IsSuccess = true;
                    response.Result = item;
                    response.ResponseStatus = HttpStatusCode.OK;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.ResponseStatus = HttpStatusCode.InternalServerError;
            }
            return StatusCode((int)response.ResponseStatus, response);
        }

        // POST: api/hmsTransgroupMaster
        [HttpPost("CreateCurrency")]
       
        public async Task<IActionResult> Create([FromBody] CurrencyInsertDto dto)
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
                var Currency = new HmsCurrency

                {
                    CurrencyName = dto.CurrencyName,


                    CurrencyCode = dto.CurrencyCode,



                    DecimalPlaces = dto.DecimalPlaces,


                    CurrencyRate = dto.CurrencyRate,

                    ModifyUser = dto.ModifyUser,
                    ModifyDate = dto.ModifyDate
                };

                // Log the created segment master object


                await _unitOfWork.HmsCurrency.AddAsync(Currency);
                //context.HmsSegmentMasters.Add(segmentMaster);
                _unitOfWork.SaveChangesAsync(); // Await the save operation

                response.IsSuccess = true;
                response.Result = Currency; // This should now have a generated SegmentId
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




        [HttpPut("CurrencyUpdate/{id}")]
      
        public async Task<IActionResult> Update(int id, [FromBody] HmsCurrencyUpdateDto data)
        {
            var response = new ApiResponse();
            if (id != data.CurrencyId)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "ID mismatch." };
                response.ResponseStatus = HttpStatusCode.BadRequest;
                return StatusCode((int)response.ResponseStatus, response);
            }

            try
            {
                var row=await _unitOfWork.HmsCurrency.GetByIdAsync(id);
                if (row==null) {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "ID Not Found in Database." };
                    response.ResponseStatus = HttpStatusCode.BadRequest;
                    return StatusCode((int)response.ResponseStatus, response);
                }
                if (!string.IsNullOrEmpty(data.CurrencyName)) {
                row.CurrencyName=data.CurrencyName;
                }
             
                    if (!string.IsNullOrEmpty(data.CurrencyCode))
                {
                    row.CurrencyCode = data.CurrencyCode;
                }


                    if (data.DecimalPlaces.HasValue)
                {
                    row.DecimalPlaces = data.DecimalPlaces??0;
                }
              
                    if (data.CurrencyRate.HasValue)
                {
                    row.CurrencyRate = data.CurrencyRate??0;
                }
              
                    if (!string.IsNullOrEmpty(data.ModifyUser))
                {
                    row.ModifyUser = data.ModifyUser;
                }
              
                    if (data.ModifyDate != null)
                {
                    row.ModifyDate = data.ModifyDate;
                }
                _unitOfWork.HmsCurrency.Update(row);
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

        // DELETE: api/hmsTransgroupMaster/{id}
        [HttpDelete("DeleteCurrency/{id}")]
       
        public async Task<ActionResult<ApiResponse>> DeleteCurrency(int id)
        {
            var response = new ApiResponse();
            try
            {
                
                var data = await _unitOfWork.HmsCurrency.GetByIdAsync(id);
                if (data == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Currency not found" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

              
                _unitOfWork.HmsCurrency.Delete(data);
               
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