using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITS_Test_Automation.Tests.UITest.Interfaces
{
    public interface ILoginPage
    {
        Task NavigateToUrl(string url);
        Task EnterUserEmail(string email);
        Task EnterUsername(string username);
        Task EnterPassword(string password);
    }
}
