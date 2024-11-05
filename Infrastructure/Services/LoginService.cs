using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SITS_Test_Automation.Domain.Interfaces;
using SITS_Test_Automation.Domain.Models.Response;

namespace SITS_Test_Automation.Infrastructure.Services
{
    //Implement the services for ILoginService
    public class LoginService : ILoginService
    {
        private readonly HttpClient _httpClient;

        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetJwtTokenAsync(string username, string password)
        {

            // Create the HTTP request
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/Login/GetJWTToken");

            // Add the username and password as headers
            request.Headers.Add("username", username);
            request.Headers.Add("password", password);

            // Send the request
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(content);

            return loginResponse?.Token;
        }
    }
}
