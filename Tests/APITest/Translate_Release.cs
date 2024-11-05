using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SITS_Test_Automation.Domain.Interfaces;
using SITS_Test_Automation.Infrastructure.HttpClientManager;
using SITS_Test_Automation.Infrastructure.Services;
using SITS_Test_Automation.Tests.UITest.Interfaces;
using SITS_Test_Automation.TestUtilities;

namespace SITS_Test_Automation.Tests.APITest
{
    [TestFixture]
    public class Translate_Release
    {
        private ILoginService _loginService;
        private IFilterService _filterService;
        private IStartPageService _startPageService;
        private IEditPageService _editPageService;
        private IHistoryService _historyService;
        private ITranslationUnit _translationUnit;
        private ApiTestHelper _apiTestHelper;
        private readonly IConfigReader _configReader = new ConfigReader();


        [SetUp]
        public async Task SetUp()
        {
            var httpClientManager = new HttpClientManager(_configReader.GetBaseURL());
            _loginService = new LoginService(httpClientManager.GetHttpClient());

            //Get JWT token
            var token = await _loginService.GetJwtTokenAsync("rIIQ7YxL83HgmhQKmuSLpw==", "Cn9lfsUnW1PRBF1oMsJXjg==");
            Console.WriteLine("this is token " + token.ToString());

            // Initialize HttpClient with token and base URL
            var httpClient = new HttpClientManager(_configReader.GetBaseURL(), token);
            var client = httpClient.GetHttpClient();


            //var httpClientWithToken = new HttpClientManager(_configReader.GetBaseURL(), token).GetHttpClient();
            //HttpClientManager httpClient = new HttpClientManager(_configReader.GetBaseURL(), token);
            _filterService = new FilterService(client);
            _startPageService = new StartPageService(client);
            _editPageService = new EditPageService(client);
            _historyService = new HistoryService(client);
            _translationUnit = new TranslationUnitService(client);

            _apiTestHelper = new ApiTestHelper(_startPageService, _editPageService, _historyService, _translationUnit);


        }

        [Test]
        public async Task Should_Release_single_text_from_Dashboard()
        {
            var source_body_text = "Total weight";
            var target_body_text = "test_body";
            var source_abbreviation = "Total weight";
            var target_abbreviation = "test_abbreviation";
            var source_part_name = string.Empty;
            var target_part_name = string.Empty;
            var source_price_unit = string.Empty;
            var target_price_unit = string.Empty;
            var inProgress = "in progress";
            var translated = "translated";
            var released = "released";

            // call category
            var categories = await _filterService.GetCategoryAsync();
            Assert.IsNotNull(categories);

            var textId = await _apiTestHelper.FetchDueInTextIdAsync();

            //Verify text and status
            var partDetails = await _apiTestHelper.NavigateToEditPageAsync(textId, source_body_text, inProgress);


            foreach (var (partName, text, status) in partDetails)
            {
                // Use partName, text, and status as needed
                Console.WriteLine($"Part Name: {partName}, Text: {text}, Status: {status}");
                
                //Send Translation request
                await _apiTestHelper.SendTranslationUnitRequestAsync(textId, source_body_text, target_body_text, source_abbreviation, target_abbreviation, translated);

                //Release Text
                await _apiTestHelper.ReleaseTextAsync(textId);

                //Verify in History
                await _apiTestHelper.VerifyHistoryForReleasedStatusAsync(textId, released);
            }


        }
    }
}
