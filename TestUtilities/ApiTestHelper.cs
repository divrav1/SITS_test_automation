using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using SITS_Test_Automation.Domain.Interfaces;
using SITS_Test_Automation.Domain.Models.Response;
using SITS_Test_Automation.Infrastructure.Services;

namespace SITS_Test_Automation.TestUtilities
{
    public class ApiTestHelper
    {
        private readonly IStartPageService _startPageService;
        private readonly IEditPageService _editPageService;
        private readonly IHistoryService _historyService;
        private readonly ITranslationUnit _translationUnit;

        
        public ApiTestHelper(
        IStartPageService startPageService,
            IEditPageService editPageService,
            IHistoryService historyService,
            ITranslationUnit translationUnit)
        {
            _startPageService = startPageService;
            _editPageService = editPageService;
            _historyService = historyService;
            _translationUnit = translationUnit;
        }

        public async Task<string> FetchDueInTextIdAsync()
        {
            var dueInRequest = RequestFactory.CreateDueInRequest();
            var dueInResponses = await _startPageService.GetDueInAsync(dueInRequest);
            var get_text_item = dueInResponses.FirstOrDefault(item => item.no_of_texts == 1);
            //Assert.That(dueInResponse.no_of_texts, Is.EqualTo(1), "Expected one text to be overdue.");
            return get_text_item.textIds.First();
        }

        public async Task<List<(string partName, string text, string status)>> NavigateToEditPageAsync(string textId, string text, string status)
        {
            var navigateRequest = RequestFactory.CreateNavigateToEditRequest(textId);
            var editResponse = await _editPageService.NavigateToEditAsync(navigateRequest);
            Assert.IsNotNull(editResponse, "Expected navigate to edit response to be non-null.");
            Assert.IsNotEmpty(editResponse, "Expected navigate to edit response to contain data.");
            Assert.That(editResponse.Count, Is.EqualTo(1));

            // Filter for the specified textId in the response
            var specificTextIdResponse = editResponse.FirstOrDefault(r => r.textid == textId);
            Assert.IsNotNull(specificTextIdResponse, $"Expected a response for textId '{textId}'.");

            // Define a list of target part names to check
            var targetPartNames = new List<string> { "Body text", "Abbreviation", "Price unit", "Part unit" };

            // Loop through the target part names and validate each if it exists
            // Initialize a collection to store part details for validation
            var partDetails = new List<(string partName, string text, string status)>();

            // Loop through the target part names and collect each part's text and status if it exists
            foreach (var partName in targetPartNames)
            {
                var part = specificTextIdResponse.textpart?.FirstOrDefault(tp => tp.partName == partName);

                if (part != null)
                {
                    // Add the part's name, text, and status to the collection for validation
                    partDetails.Add((partName: part.partName, text: part.text, status: part.status));
                }
            }

            return partDetails;
        }


        public async Task SendTranslationUnitRequestAsync(string textId, string source_body_text, string target_body_text, string source_abbreviation_text, string target_abbreviation_text, string status)
        {
            EnsureServiceInitialized(_translationUnit, nameof(_translationUnit));

            var translationUnitRequest = RequestFactory.CreateTranslationUnitRequest(textId, source_body_text, target_body_text, source_abbreviation_text, target_abbreviation_text);
            var translationUnitResponses = await _translationUnit.SendTranslationUnitRequestAsync(translationUnitRequest);
            // Act: Verify that the first two items have ErrorCode "OK" and the remaining have "EmptySegment"
            bool firstTwoOk = translationUnitResponses.Take(2).All(r => r.TranslationUnitResponseList.All(item => item.ErrorCode == "OK"));
            bool restEmptySegment = translationUnitResponses.Skip(2).All(r => r.TranslationUnitResponseList.All(item => item.ErrorCode == "EmptySegment"));

            // Assert: Verify that the conditions are met
            Assert.True(firstTwoOk, "Expected the first two TranslationUnitResponseList items to have ErrorCode as 'OK'.");
            Assert.True(restEmptySegment, "Expected the remaining TranslationUnitResponseList items to have ErrorCode as 'EmptySegment'.");
        }

        public async Task ReleaseTextAsync(string textId)
        {
            EnsureServiceInitialized(_editPageService, nameof(_editPageService));

            var releaseRequest = RequestFactory.CreateReleaseTextRequest(textId);
            var releaseResponse = await _editPageService.ReleaseTextAsync(releaseRequest);
            Assert.IsTrue(releaseResponse.UpdateResult.IsAcknowledged, "Expected release response to be acknowledged.");
        }

        public async Task VerifyHistoryForReleasedStatusAsync(string textId, string status)
        {
            EnsureServiceInitialized(_historyService, nameof(_historyService));

            var historyRequest = RequestFactory.CreateHistoryRequest(textId);
            var historyResponse = await _historyService.GetHistoryAsync(historyRequest);
            Assert.That(historyResponse.CurrentVersion.Status, Is.EqualTo(status), "Expected history status to be 'released'.");
            Assert.That(historyResponse.CurrentVersion.UpdatedOn.Date, Is.EqualTo(DateTime.UtcNow.Date), "Expected history update date to be today.");
        }

        

        // Helper method to ensure a service is initialized
        private static void EnsureServiceInitialized(object service, string serviceName)
        {
            if (service == null)
            {
                throw new InvalidOperationException($"{serviceName} is not initialized. This method requires it.");
            }
        }
        

    }
}
