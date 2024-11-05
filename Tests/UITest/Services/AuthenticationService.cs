using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SITS_Test_Automation.Tests.UITest.Interfaces;

namespace SITS_Test_Automation.Tests.UITest.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILoginPage _loginPage;
        private readonly IConfigReader _configReader;

        public AuthenticationService(ILoginPage loginPage, IConfigReader configReader)
        {
            _loginPage = loginPage;
            _configReader = configReader;
        }
        public async Task LoginWithSSOAsync()
        {
            await _loginPage.NavigateToUrl(_configReader.GetApplicationUrl());
            await _loginPage.EnterUserEmail(_configReader.GetUserEmail());
            await _loginPage.EnterUsername(_configReader.GetUsername());
            await _loginPage.EnterPassword(_configReader.GetPassword());
        }
    }
}
