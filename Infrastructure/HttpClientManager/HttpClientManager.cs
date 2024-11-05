using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SITS_Test_Automation.Infrastructure.HttpClientManager
{
    //Manage the HTTP client setup and add the JWT token
    public class HttpClientManager
    {
        private readonly HttpClient _httpClient;

        public HttpClientManager(String baseURL, String Token = null)
        {

            _httpClient = new HttpClient { BaseAddress = new Uri(baseURL) };
            if (!String.IsNullOrEmpty(Token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            }

        }

        public HttpClient GetHttpClient() => _httpClient;
    }
}
