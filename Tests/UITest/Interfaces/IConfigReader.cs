using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITS_Test_Automation.Tests.UITest.Interfaces
{
    public interface IConfigReader
    {
        string GetApplicationUrl();
        string GetUserEmail();
        string GetUsername();
        string GetPassword();
        string GetBaseURL();
    }
}
