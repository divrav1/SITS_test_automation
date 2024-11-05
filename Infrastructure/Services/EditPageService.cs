using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SITS_Test_Automation.Domain.Interfaces;
using SITS_Test_Automation.Domain.Models.Request;
using SITS_Test_Automation.Domain.Models.Response;

namespace SITS_Test_Automation.Infrastructure.Services
{
    public class EditPageService : IEditPageService
    {
        public readonly HttpClient _httpClient;

        public EditPageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<NavigateToEditResponse>> NavigateToEditAsync(NavigateToEditRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/EditPage/NavigateToEdit", request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<NavigateToEditResponse>>(content);
        }

        public async Task<ReleaseTextResponse> ReleaseTextAsync(ReleaseTextRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("", request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ReleaseTextResponse>(content);
        }
    }
}
