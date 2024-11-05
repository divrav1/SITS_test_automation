using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SITS_Test_Automation.Domain.Interfaces;
using SITS_Test_Automation.Domain.Models.Response;

namespace SITS_Test_Automation.Infrastructure.Services
{
    public class FilterService : IFilterService
    {
        private readonly HttpClient _httpClient;

        public FilterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CategoryResponse>> GetCategoryAsync()
        {
            var response = await _httpClient.GetAsync("/api/Filter/GetCategory");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            //var categoryResponse = JsonConvert.DeserializeObject<CategoryResponse>(content);
            var categories = JsonConvert.DeserializeObject<List<CategoryResponse>>(content);

            return categories;
        }
    }

    
}
