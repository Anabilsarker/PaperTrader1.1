using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ApiProtocol.Base;

namespace Domain.ApiProtocol.Response.ApiResponse
{
    public class LoginResponseResult
    {
        public string token;
        public string userID;
        public ExchangeSegment exchangeSegments;
    }
    public class LoginResponse
    {
        public string type;
        public string code;
        public string description;
        public LoginResponseResult result;
    }
}
