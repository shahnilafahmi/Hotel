using HotelProject.Models.DTOs;
using HotelProject.Models.Models;
using HotelProject.Repository.IRepository.IMaster;
using HotelProject.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using HotelProject.Models;

namespace HotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempGuestViewController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TempGuestViewController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] TempGuestViewCreateDto dto)
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
                var obj = new TempGuestView
                {
                    RoomNo = dto.RoomNo,
                    Name = dto.Name,
                    GStNo = dto.GStNo,
                    Pax = dto.Pax,
                    CheckIn = dto.CheckIn,
                    RoomTypId = dto.RoomTypId,
                    DepDate = dto.DepDate,
                    Nationality = dto.Nationality,
                    City_Name = dto.City_Name,
                    RoomRate = dto.RoomRate,
                    Status = dto.Status,
                    Nation_Rmmt = dto.Nation_Rmmt,
                    Segment = dto.Segment,
                    Typename = dto.Typename,
                    docname = dto.docname,
                    categ_descri = dto.categ_descri,
                    family = dto.family,
                    child = dto.child,
                    billinginst = dto.billinginst,
                    guestid = dto.guestid,
                    checkout = dto.checkout,
                    resno = dto.resno,
                    salesname = dto.salesname,
                    groupname = dto.groupname,
                    contactno = dto.contactno,
                    docno = dto.docno,
                    guestbal = dto.guestbal,
                    RoomMate = dto.RoomMate,
                    VacantRoom = dto.VacantRoom,
                    OrgRoom = dto.OrgRoom,
                    Plan_Des = dto.Plan_Des,
                    Pay_Des = dto.Pay_Des,
                    agentname = dto.agentname
                };

                await _unitOfWork.TempGuestViewRepository.AddAsync(obj);
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

        [HttpDelete("DeleteTempGuestView/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteTempGuestView(int id)
        {
            var response = new ApiResponse();
            try
            {
                var data = await _unitOfWork.TempGuestViewRepository.GetByIdAsync(id);
                if (data == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Not found" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                _unitOfWork.TempGuestViewRepository.Delete(data);
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
