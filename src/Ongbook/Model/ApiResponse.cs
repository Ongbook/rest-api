using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ongbook.Model
{
    public class ApiResponse
    {
        public int Status { get; set; }
        public ApiError Errors { get; set; }
        public dynamic Response { get; set; }
    }

    public class ApiError: List<string> { }
}
