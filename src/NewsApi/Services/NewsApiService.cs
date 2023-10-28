using Microsoft.Extensions.Configuration;
using NewsApi.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text.Json;
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

    public async Task<List<NewsArticle>> GetRecentNewsAsync(string companyName)
    {
        string apiKey = _configuration["AppSettings:NewsApiKey"];
        string encodedCompanyName = Uri.EscapeDataString(companyName);
        string apiUrl = $"https://newsapi.org/v2/everything?q={encodedCompanyName}&apiKey={apiKey}";
        HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<NewsApiResponse>(content);


            // Filter and return the 5 most recent articles
            var recentArticles = result.Articles
                .Where(article => article.Title.Contains(companyName, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(article => article.PublishedAt)
                .Take(5)
                .Select(article => new NewsArticle
                {
                    Id = article.Id,
                    Title = article.Title,
                    Author = article.Author,
                    Content = article.Content,
                    ArticleLink = article.ArticleLink,
                    PublishedAt = article.PublishedAt,
                    // Include other properties if needed
                })
                .ToList();

            return recentArticles;
        }

        throw new Exception("Unable to fetch news.");
    }
}
