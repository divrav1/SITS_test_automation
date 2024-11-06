using NUnit.Framework;
using Microsoft.Playwright;
using System.Threading.Tasks;
using static BrowserHelper;
using static ConfigReader;
using SITS_Test_Automation.Tests.UITest.Services;
using SITS_Test_Automation.Tests.UITest.Interfaces;
using NUnit.Framework.Interfaces;

namespace SITS_Test_Automation.Tests.UITest.Tests
{
    [TestFixture]
    public class LoginTests
    {
        private TestLifecycleHelper _lifecycleHelper;
        private IPage _page;
        private ILoginPage _loginPage;
        private IDashboardPage _dashboardPage;
        private IAuthenticationService _authenticationService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _lifecycleHelper = new TestLifecycleHelper();
        }


        [SetUp]
        public async Task Setup()
        {
            // Initialize page and services
            _page = await _lifecycleHelper.InitializeTestAsync();
            _loginPage = new LoginPage(_page);
            _dashboardPage = new DashboardPage(_page);
            _authenticationService = new AuthenticationService(_loginPage, new ConfigReader());
        }

        [TearDown]
        public async Task TearDown() => await _lifecycleHelper.CleanupTestAsync(TestContext.CurrentContext);

        [OneTimeTearDown]
        public async Task OneTimeTearDown() => await _lifecycleHelper.FinalCleanupAsync();


        [Test, Category("RunInCI")]
        public async Task TestSSOLogin()
        {
            // Perform login via authentication service
            await _authenticationService.LoginWithSSOAsync();

            // Wait for 3 seconds after the page is fully loaded
            await Task.Delay(3000);

            // Verify the page title after login
            var title = await _page.TitleAsync();
            Assert.That(title, Is.EqualTo("SITS"));
        }
    }
}