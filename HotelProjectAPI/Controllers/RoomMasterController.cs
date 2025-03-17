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
    public class RoomMasterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public RoomMasterController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }



        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAllRoomMasters( string? status,string? shareStatus,string?cleanStatus,string?orgStatus,int? roomTypeId)
        {
            var response = new ApiResponse();
            try
            {
             
                //var query = _context.HmsRoomMasters.Include(u => u.Roomtype).Include(u=>u.FloorMaster).AsQueryable();
                var query = _unitOfWork.HmsRoomMasterRepository.GetAllWithIncludesAsync(u => u.Roomtype, u => u.FloorMaster);
                if (!query.Any()) {

                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Not found AnyResults"};
                    response.ResponseStatus = HttpStatusCode.NotFound;
                }

                if (!string.IsNullOrEmpty(status))
                {
                    query = query.Where(u => u.Status.ToLower() == status.ToLower());
                }

                if (!string.IsNullOrEmpty(shareStatus))
                {
                    query = query.Where(u => u.Share_status.ToLower() == shareStatus.ToLower());
                }

                if (!string.IsNullOrEmpty(cleanStatus))
                {
                    query = query.Where(u => u.Clean_Status.ToLower() == cleanStatus.ToLower());
                }

                if (!string.IsNullOrEmpty(orgStatus))
                {
                    query = query.Where(u => u.Org_Status.ToLower() == orgStatus.ToLower());
                }

           
                if (roomTypeId.HasValue)
                {
                    query = query.Where(u => u.Roomtype_Id == roomTypeId.Value);
                }

              
                var filteredRoomMasters = await query.ToListAsync();

               
                response.IsSuccess = true;
                response.Result = filteredRoomMasters;
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











     

        [HttpGet("GetRoomMaster/{id}")]
        public async Task<ActionResult<ApiResponse>> GetRoomMaster(int id)
        {
            var response = new ApiResponse();
            try
            {
               
                var roomMaster = await _context.HmsRoomMasters.Include(u => u.Roomtype).Include(u => u.FloorMaster).FirstOrDefaultAsync(u=>u.Id==id) ;
                if (roomMaster == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Room not found" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }
                response.IsSuccess = true;
                response.Result = roomMaster;
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

      
        [HttpPost("CreateRoomMaster")]
        public async Task<ActionResult<ApiResponse>> CreateRoomMaster(CreateRoomMasterDto roomMasterDto)
        {
            var response = new ApiResponse();
            try
            {
                var roomMaster = new HmsRoomMaster
                {
                  
                    Roomno = roomMasterDto.Roomno,
                    RoomnoInt = roomMasterDto.RoomnoInt,
                    Roomtype_Id = roomMasterDto.RoomtypeId,
                    Org_roomno = roomMasterDto.OrgRoomno,
                    Share_status = roomMasterDto.ShareStatus,
                    Clean_Status = roomMasterDto.CleanStatus,
                    Org_Status = roomMasterDto.OrgStatus,
                    Floor_id = roomMasterDto.FloorId,
                    Add_user = roomMasterDto.AddUser,
                    Added_time = DateTime.Now ,
                    Room_Desc = roomMasterDto.RoomDesc,
                    OutofOrder_Remarks = roomMasterDto.OutofOrderRemarks,
                    Active = roomMasterDto.Active,
                    Status = roomMasterDto.Status
                };

                //_context.HmsRoomMasters.Add(roomMaster);
               await  _unitOfWork.HmsRoomMasterRepository.AddAsync(roomMaster);
              _unitOfWork.SaveChangesAsync();

                response.IsSuccess = true;
                response.Result = roomMaster;
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

        // PUT: api/RoomMaster/5
        [HttpPut("UpdateRoomMaster/{id}")]
        public async Task<ActionResult<ApiResponse>> UpdateRoomMaster(int id, UpdateRoomMasterDto roomMasterDto)
        {
            var response = new ApiResponse();
            try
            {
                //var roomMaster = await _context.HmsRoomMasters.FindAsync(id);
                var roomMaster = await _unitOfWork.HmsRoomMasterRepository.GetByIdAsync(id);
                if (roomMaster == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Room not found" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                if (roomMasterDto.Roomno != null)
                {
                    roomMaster.Roomno = roomMasterDto.Roomno;
                }

                if (roomMasterDto.RoomnoInt != null)
                {
                    roomMaster.RoomnoInt = roomMasterDto.RoomnoInt;
                }

                if (roomMasterDto.RoomtypeId != 0)  
                {
                    roomMaster.Roomtype_Id = roomMasterDto.RoomtypeId;
                }

                if (roomMasterDto.OrgRoomno != null)
                {
                    roomMaster.Org_roomno = roomMasterDto.OrgRoomno;
                }

                if (roomMasterDto.ShareStatus != null)
                {
                    roomMaster.Share_status = roomMasterDto.ShareStatus;
                }

                if (roomMasterDto.CleanStatus != null)
                {
                    roomMaster.Clean_Status = roomMasterDto.CleanStatus;
                }

                if (roomMasterDto.OrgStatus != null)
                {
                    roomMaster.Org_Status = roomMasterDto.OrgStatus;
                }

                if (roomMasterDto.FloorId != null)
                {
                    roomMaster.Floor_id = roomMasterDto.FloorId;
                }

                if (roomMasterDto.AddUser != null)
                {
                    roomMaster.Add_user = roomMasterDto.AddUser;
                }

                if (roomMasterDto.AddedTime != null)
                {
                    roomMaster.Added_time = roomMasterDto.AddedTime;
                }

                if (roomMasterDto.RoomDesc != null)
                {
                    roomMaster.Room_Desc = roomMasterDto.RoomDesc;
                }

                if (roomMasterDto.OutofOrderRemarks != null)
                {
                    roomMaster.OutofOrder_Remarks = roomMasterDto.OutofOrderRemarks;
                }

                if (roomMasterDto.Active != null)
                {
                    roomMaster.Active = roomMasterDto.Active;
                }

                if (roomMasterDto.Status != null)
                {
                    roomMaster.Status = roomMasterDto.Status;
                }



                //_context.HmsRoomMasters.Update(roomMaster);
                _unitOfWork.HmsRoomMasterRepository.Update(roomMaster);
                _unitOfWork.SaveChangesAsync();

                response.IsSuccess = true;
                response.Result = roomMaster;
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

        // DELETE: api/RoomMaster/5
        [HttpDelete("DeleteRoomMaster/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteRoomMaster(int id)
        {
            var response = new ApiResponse();
            try
            {
                //var roomMaster = await _context.HmsRoomMasters.FindAsync(id);
                var roomMaster = await _unitOfWork.HmsRoomMasterRepository.GetByIdAsync(id);
                if (roomMaster == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Room not found" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                //_context.HmsRoomMasters.Remove(roomMaster);
                _unitOfWork.HmsRoomMasterRepository.Delete(roomMaster);
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
