using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.Models
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessages { get; set; }
        public HttpStatusCode ResponseStatus { get; set; }
        public object Result { get; set; }
    }
}
