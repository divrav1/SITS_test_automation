using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SITS_Test_Automation.Domain.Interfaces;
using SITS_Test_Automation.Domain.Models.Request;
using SITS_Test_Automation.Domain.Models.Response;

namespace SITS_Test_Automation.Infrastructure.Services
{
    public class HistoryService : IHistoryService
    {
        public readonly HttpClient _httpClient; 

        public HistoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HistoryResponse> GetHistoryAsync(HistoryRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/History/History", request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<HistoryResponse>(content);
        }
    }
}
