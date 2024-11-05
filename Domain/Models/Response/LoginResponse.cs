using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITS_Test_Automation.Domain.Models.Response
{
    //Define models for the responses of the GetJWTToken 
    public class LoginResponse
    {
        public string? Token { get; set; }
    }
}
