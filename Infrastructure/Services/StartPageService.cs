using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class StartPageService : IStartPageService
    {
        private readonly HttpClient _httpClient;

        public StartPageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<DueInResponse>> GetDueInAsync(DueInRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/StartPage/dueIn", request);


            //// Serialize the DueInRequest object to a JSON string
            //var json = JsonConvert.SerializeObject(request);

            //// Create HttpContent using the serialized JSON string
            //HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send the request using the _httpClient
            //var response = await _httpClient.PostAsync("api/StartPage/dueIn", content);

            // Ensure the response indicates success
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Raw response content: " + content);

            // Read the response content as DueInResponse
            return await response.Content.ReadFromJsonAsync<List<DueInResponse>>();
        }
    }
}
