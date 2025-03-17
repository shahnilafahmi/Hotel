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

namespace HotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionCodeController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext context;
        private ApiResponse response;
        public TransactionCodeController(IUnitOfWork unitOfWork,ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            this.context = context;
            response = new ApiResponse();
        }


        [HttpGet("GetByTransCode")]
        public async Task<IActionResult> GetByTransCode(string TransCode)
        {
           var result= _unitOfWork.TransactionCodeRepository.getByTransCode(TransCode);
            if (!result.Any()) {
                response.IsSuccess = false;
                response.ResponseStatus = HttpStatusCode.NotFound;
                response.ErrorMessages = new List<string>() { "No matching results found of this Transaction Code!" };

                return NotFound(response);
            }
            response.IsSuccess = true;
           response.ResponseStatus = HttpStatusCode.OK;
           response.Result = result;

           return Ok(response);
        }

        //[HttpPut("UpdateByTransCode/{TransCode}")]
        //public async Task<IActionResult> UpdateByTransCode(string TransCode, HmsTransactionCode hmsTransactionCode)

        //{
        //    if (TransCode.ToLower() != hmsTransactionCode.TransCode.ToLower())
        //    {
        //        response.IsSuccess = false;
        //        response.ResponseStatus = HttpStatusCode.BadRequest;
        //        response.ErrorMessages = new List<string>() { "Invalid data provided." };

        //        return BadRequest(response);
        //    }

        //    //var row = _unitOfWork.TransactionCodeRepository.getByTransCode(TransCode);


        //    if (row == null)
        //    {
        //        response.IsSuccess = false;
        //        response.ResponseStatus = HttpStatusCode.NotFound;
        //        response.ErrorMessages = new List<string>() { "No matching results found of this Transaction Code!" };

        //        return NotFound(response);

        //    }
        //    if (hmsTransactionCode.Id != 0) // Assuming Id is always non-null since it's an int
        //    {
        //        row.Id = hmsTransactionCode.Id;
        //    }

        //    if (!string.IsNullOrEmpty(hmsTransactionCode.TransCode))
        //    {
        //        row.TransCode = hmsTransactionCode.TransCode;
        //    }

        //    if (!string.IsNullOrEmpty(hmsTransactionCode.TransDescription))
        //    {
        //        row.TransDescription = hmsTransactionCode.TransDescription;
        //    }

        //    if (hmsTransactionCode.TransGroup.HasValue)
        //    {
        //        row.TransGroup = hmsTransactionCode.TransGroup.Value;
        //    }

        //    if (!string.IsNullOrEmpty(hmsTransactionCode.MainGroup))
        //    {
        //        row.MainGroup = hmsTransactionCode.MainGroup;
        //    }

        //    if (!string.IsNullOrEmpty(hmsTransactionCode.Crdr))
        //    {
        //        row.Crdr = hmsTransactionCode.Crdr;
        //    }

        //    if (hmsTransactionCode.Taxable.HasValue)
        //    {
        //        row.Taxable = hmsTransactionCode.Taxable.Value;
        //    }

        //    if (!string.IsNullOrEmpty(hmsTransactionCode.AccCode))
        //    {
        //        row.AccCode = hmsTransactionCode.AccCode;
        //    }

        //    if (!string.IsNullOrEmpty(hmsTransactionCode.InvCode))
        //    {
        //        row.InvCode = hmsTransactionCode.InvCode;
        //    }

        //    if (!string.IsNullOrEmpty(hmsTransactionCode.PrefixCode))
        //    {
        //        row.PrefixCode = hmsTransactionCode.PrefixCode;
        //    }

        //    if (!string.IsNullOrEmpty(hmsTransactionCode.Refcodefield))
        //    {
        //        row.Refcodefield = hmsTransactionCode.Refcodefield;
        //    }

        //    if (!string.IsNullOrEmpty(hmsTransactionCode.Reportfilename))
        //    {
        //        row.Reportfilename = hmsTransactionCode.Reportfilename;
        //    }

        //    if (hmsTransactionCode.Printvoucher.HasValue)
        //    {
        //        row.Printvoucher = hmsTransactionCode.Printvoucher.Value;
        //    }

        //    if (hmsTransactionCode.ManualTransaction.HasValue)
        //    {
        //        row.ManualTransaction = hmsTransactionCode.ManualTransaction.Value;
        //    }

        //    if (hmsTransactionCode.PosttoAccounts.HasValue)
        //    {
        //        row.PosttoAccounts = hmsTransactionCode.PosttoAccounts.Value;
        //    }

        //    if (hmsTransactionCode.Taxsvc.HasValue)
        //    {
        //        row.Taxsvc = hmsTransactionCode.Taxsvc.Value;
        //    }

        //    if (hmsTransactionCode.Tax.HasValue)
        //    {
        //        row.Tax = hmsTransactionCode.Tax.Value;
        //    }

        //    if (hmsTransactionCode.Svc.HasValue)
        //    {
        //        row.Svc = hmsTransactionCode.Svc.Value;
        //    }

        //    if (hmsTransactionCode.Guestledger.HasValue)
        //    {
        //        row.Guestledger = hmsTransactionCode.Guestledger.Value;
        //    }

        //    if (hmsTransactionCode.Dailysummary.HasValue)
        //    {
        //        row.Dailysummary = hmsTransactionCode.Dailysummary.Value;
        //    }

        //    if (hmsTransactionCode.InHouse.HasValue)
        //    {
        //        row.InHouse = hmsTransactionCode.InHouse.Value;
        //    }

        //    if (hmsTransactionCode.DeptId.HasValue)
        //    {
        //        row.DeptId = hmsTransactionCode.DeptId.Value;
        //    }

        //    if (hmsTransactionCode.SortOrder.HasValue)
        //    {
        //        row.SortOrder = hmsTransactionCode.SortOrder.Value;
        //    }

        //    if (hmsTransactionCode.ShowInInv.HasValue)
        //    {
        //        row.ShowInInv = hmsTransactionCode.ShowInInv.Value;
        //    }

        //    if (hmsTransactionCode.FilterBillSummHead.HasValue)
        //    {
        //        row.FilterBillSummHead = hmsTransactionCode.FilterBillSummHead.Value;
        //    }

        //    if (!string.IsNullOrEmpty(hmsTransactionCode.FormulaVat))
        //    {
        //        row.FormulaVat = hmsTransactionCode.FormulaVat;
        //    }

        //    if (!string.IsNullOrEmpty(hmsTransactionCode.FormulaSvc))
        //    {
        //        row.FormulaSvc = hmsTransactionCode.FormulaSvc;
        //    }

        //    if (!string.IsNullOrEmpty(hmsTransactionCode.FormulaCgst))
        //    {
        //        row.FormulaCgst = hmsTransactionCode.FormulaCgst;
        //    }

        //    if (!string.IsNullOrEmpty(hmsTransactionCode.FormulaSgst))
        //    {
        //        row.FormulaSgst = hmsTransactionCode.FormulaSgst;
        //    }


        //    _unitOfWork.TransactionCodeRepository.Update(row);
        //    _unitOfWork.SaveChangesAsync();

        //    response.IsSuccess = true;
        //    response.ResponseStatus = HttpStatusCode.OK;
        //    response.Result = row;

        //    return Ok(response);
        //}
        [HttpPut("UpdateByTransCode/{TransCode}")]
        public async Task<IActionResult> UpdateByTransCode(string TransCode, HmsTransactionCode hmsTransactionCode)
        {
            if (TransCode.ToLower() != hmsTransactionCode.TransCode.ToLower())
            {
                response.IsSuccess = false;
                response.ResponseStatus = HttpStatusCode.BadRequest;
                response.ErrorMessages = new List<string> { "Invalid data provided." };
                return BadRequest(response);
            }

            // Fetch the existing record by transaction code
            var data =  _unitOfWork.TransactionCodeRepository.getByTransCode(TransCode).ToList(); // Ensure `GetByTransCodeAsync` exists in your repository.
            var row = data.FirstOrDefault();
          
            if (row == null)
            {
                response.IsSuccess = false;
                response.ResponseStatus = HttpStatusCode.NotFound;
                response.ErrorMessages = new List<string> { "No matching results found for this Transaction Code!" };
                return NotFound(response);
            }
           
            // Update fields only if they have valid data
            row.Id = hmsTransactionCode.Id != 0 ? hmsTransactionCode.Id : row.Id;
            row.TransCode = !string.IsNullOrEmpty(hmsTransactionCode.TransCode) ? hmsTransactionCode.TransCode : row.TransCode;
            row.TransDescription = !string.IsNullOrEmpty(hmsTransactionCode.TransDescription) ? hmsTransactionCode.TransDescription : row.TransDescription;
            row.TransGroup = hmsTransactionCode.TransGroup ?? row.TransGroup;
            row.MainGroup = !string.IsNullOrEmpty(hmsTransactionCode.MainGroup) ? hmsTransactionCode.MainGroup : row.MainGroup;
            row.Crdr = !string.IsNullOrEmpty(hmsTransactionCode.Crdr) ? hmsTransactionCode.Crdr : row.Crdr;
            row.Taxable = hmsTransactionCode.Taxable ?? row.Taxable;
            row.AccCode = !string.IsNullOrEmpty(hmsTransactionCode.AccCode) ? hmsTransactionCode.AccCode : row.AccCode;
            row.InvCode = !string.IsNullOrEmpty(hmsTransactionCode.InvCode) ? hmsTransactionCode.InvCode : row.InvCode;
            row.PrefixCode = !string.IsNullOrEmpty(hmsTransactionCode.PrefixCode) ? hmsTransactionCode.PrefixCode : row.PrefixCode;
            row.Refcodefield = !string.IsNullOrEmpty(hmsTransactionCode.Refcodefield) ? hmsTransactionCode.Refcodefield : row.Refcodefield;
            row.Reportfilename = !string.IsNullOrEmpty(hmsTransactionCode.Reportfilename) ? hmsTransactionCode.Reportfilename : row.Reportfilename;
            row.Printvoucher = hmsTransactionCode.Printvoucher ?? row.Printvoucher;
            row.ManualTransaction = hmsTransactionCode.ManualTransaction ?? row.ManualTransaction;
            row.PosttoAccounts = hmsTransactionCode.PosttoAccounts ?? row.PosttoAccounts;
            row.Taxsvc = hmsTransactionCode.Taxsvc ?? row.Taxsvc;
            row.Tax = hmsTransactionCode.Tax ?? row.Tax;
            row.Svc = hmsTransactionCode.Svc ?? row.Svc;
            row.Guestledger = hmsTransactionCode.Guestledger ?? row.Guestledger;
            row.Dailysummary = hmsTransactionCode.Dailysummary ?? row.Dailysummary;
            row.InHouse = hmsTransactionCode.InHouse ?? row.InHouse;
            row.DeptId = hmsTransactionCode.DeptId ?? row.DeptId;
            row.SortOrder = hmsTransactionCode.SortOrder ?? row.SortOrder;
            row.ShowInInv = hmsTransactionCode.ShowInInv ?? row.ShowInInv;
            row.FilterBillSummHead = hmsTransactionCode.FilterBillSummHead ?? row.FilterBillSummHead;
            row.FormulaVat = !string.IsNullOrEmpty(hmsTransactionCode.FormulaVat) ? hmsTransactionCode.FormulaVat : row.FormulaVat;
            row.FormulaSvc = !string.IsNullOrEmpty(hmsTransactionCode.FormulaSvc) ? hmsTransactionCode.FormulaSvc : row.FormulaSvc;
            row.FormulaCgst = !string.IsNullOrEmpty(hmsTransactionCode.FormulaCgst) ? hmsTransactionCode.FormulaCgst : row.FormulaCgst;
            row.FormulaSgst = !string.IsNullOrEmpty(hmsTransactionCode.FormulaSgst) ? hmsTransactionCode.FormulaSgst : row.FormulaSgst;

            // Update and save the changes
            _unitOfWork.TransactionCodeRepository.Update(row);
             _unitOfWork.SaveChangesAsync();

            response.IsSuccess = true;
            response.ResponseStatus = HttpStatusCode.OK;
            response.Result = row;

            return Ok(response);
        }


    }
}