using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITS_Test_Automation.Domain.Interfaces
{   
    public interface ILoginService
    {
        Task<String> GetJwtTokenAsync(String username, String password);
    }
}
