namespace NewsApi.Services
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class NewsApiService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public NewsApiService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<string> GetNewsAsync(string companyName)
        {
            string apiKey = _configuration["AppSettings:NewsApiKey"];
            string apiUrl = $"https://newsapi.org/v2/everything?q={companyName}&language=en&apiKey={apiKey}";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw new Exception("Unable to fetch news.");
        }
    }
}
