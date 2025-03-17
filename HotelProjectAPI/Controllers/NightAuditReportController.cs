using Azure;
using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Models.Models;
using HotelProject.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NightAuditReportController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext context;
        private readonly IRepository<HmsNightAuditReport> repo;
        private ApiResponse response;
        public NightAuditReportController(IUnitOfWork unitOfWork, ApplicationDbContext context,IRepository<HmsNightAuditReport> repo)
        {
            _unitOfWork = unitOfWork;
            this.context = context;
            this.repo = repo;
            response = new ApiResponse();
        }
        [HttpGet("GetByStatus/{Status}")]
        public async Task<ActionResult<ApiResponse>> GetByStatus(string Status)
        {
            try {
                //var obj = context.HmsNightAuditReports.Where(u => u.Status.ToLower() == Status.ToLower());
                var data = await repo.GetAsQueryAble();
                var obj = data.Where(u => u.Status.ToLower() == Status.ToLower());
                if (!obj.Any())
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Result not found.Record is not present in the database!" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                response.IsSuccess = true;
                response.Result = obj; // This should now have a generated SegmentId
                response.ResponseStatus = HttpStatusCode.Created;
            }
            catch (Exception ex) {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.ResponseStatus = HttpStatusCode.InternalServerError;
            }
            return Ok(response);
        }

   }
}
