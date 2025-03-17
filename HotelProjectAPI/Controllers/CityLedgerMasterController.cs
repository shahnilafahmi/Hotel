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
using HotelProject.Repository;

namespace HotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityLedgerMasterController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext context;
       

        public CityLedgerMasterController(IUnitOfWork unitOfWork,ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            this.context = context;
            
        }
       

        // GET: api/hmsTransgroupMaster
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = new ApiResponse();
            try
            {
                var data =  _unitOfWork.HmsCityLedgerMasterRepository.GetAllWithIncludesAsync(u => u.SegmentMaster);
                var items = data.ToList();
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

      
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = new ApiResponse();
            try
            {//aa
                //var item = await context.HmsCityledgerMasters.Include
                //     (u => u.SegmentMaster).FirstOrDefaultAsync(u => u.City_id == id);
               var data=  _unitOfWork.HmsCityLedgerMasterRepository.GetAllWithIncludesAsync(u => u.SegmentMaster);

                var item = data.FirstOrDefault(u=>u.City_id==id);
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
        [HttpPost("Create")]

        public async Task<IActionResult> Create([FromBody] CityLedgerCreateDto dto)
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
                var obj = new HmsCityledgerMaster
                {
                    Cty_Acct_No = dto.Cty_Acct_No,
                    City_Name = dto.City_Name,
                    City_Contact = dto.City_Contact,
                    City_Join_Date = dto.City_Join_Date,
                    City_Address = dto.City_Address,
                    City_Office_Tel = dto.City_Office_Tel,
                    City_Mobile_Tel = dto.City_Mobile_Tel,
                    City_Email = dto.City_Email,
                    City_Remarks = dto.City_Remarks,
                    City_Balance_amt = dto.City_Balance_amt,
                    Credit_Limit = dto.Credit_Limit,
                    Acc_No = dto.Acc_No,
                    Segment_id = dto.Segment_id,
                    Active = dto.Active
                };


                // Log the created segment master object


                await _unitOfWork.HmsCityLedgerMasterRepository.AddAsync(obj);
                //context.HmsSegmentMasters.Add(segmentMaster);
                _unitOfWork.SaveChangesAsync(); // Await the save operation

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



       
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HmsCityledgerMaster data)
        {
            var response = new ApiResponse();
            if (id != data.City_id)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "ID mismatch." };
                response.ResponseStatus = HttpStatusCode.BadRequest;
                return StatusCode((int)response.ResponseStatus, response);
            }

            try
            {
                var obj = await _unitOfWork.HmsCityLedgerMasterRepository.GetByIdAsync(id);
                if (data.Cty_Acct_No != null)
                {
                    obj.Cty_Acct_No = data.Cty_Acct_No;
                }
                if (data.City_Name != null)
                {
                    obj.City_Name = data.City_Name;
                }
                if (data.City_Contact != null)
                {
                    obj.City_Contact = data.City_Contact;
                }
                if (data.City_Join_Date != null)
                {
                    obj.City_Join_Date = data.City_Join_Date;
                }
                if (data.City_Address != null)
                {
                    obj.City_Address = data.City_Address;
                }
                if (data.City_Office_Tel != null)
                {
                    obj.City_Office_Tel = data.City_Office_Tel;
                }
                if (data.City_Mobile_Tel != null)
                {
                    obj.City_Mobile_Tel = data.City_Mobile_Tel;
                }
                if (data.City_Email != null)
                {
                    obj.City_Email = data.City_Email;
                }
                if (data.City_Remarks != null)
                {
                    obj.City_Remarks = data.City_Remarks;
                }
                if (data.City_Balance_amt != null)
                {
                    obj.City_Balance_amt = data.City_Balance_amt;
                }
                if (data.Credit_Limit != null)
                {
                    obj.Credit_Limit = data.Credit_Limit;
                }
                if (data.Acc_No != null)
                {
                    obj.Acc_No = data.Acc_No;
                }
                if (data.Segment_id != null)
                {
                    obj.Segment_id = data.Segment_id;
                }
                if (data.Active != null)
                {
                    obj.Active = data.Active;
                }
                _unitOfWork.HmsCityLedgerMasterRepository.Update(obj);
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
        [HttpDelete("DeleteCityLedger/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteCityLedger(int id)
        {
            var response = new ApiResponse();
            try
            {
                //var roomMaster = await _context.HmsRoomMasters.FindAsync(id);
                var data = await _unitOfWork.HmsCityLedgerMasterRepository.GetByIdAsync(id);
                if (data == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "not found" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

              
                _unitOfWork.HmsCityLedgerMasterRepository.Delete(data);
             
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