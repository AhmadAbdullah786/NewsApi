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

    public async Task<List<NewsArticle>> GetRecentNewsByCompanyNameAndInMultipleLanguageAsync(string companyName, string languageCodes)
    {
        string apiKey = _configuration["AppSettings:NewsApiKey"];
        string encodedCompanyName = Uri.EscapeDataString(companyName);

        List<NewsArticle> recentArticles = new List<NewsArticle>();

        var languages = languageCodes.Split(',');

        try
        {
            foreach (var language in languages)
            {
                string apiUrl = $"https://newsapi.org/v2/everything?q={encodedCompanyName}&language={language}&apiKey={apiKey}";
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<NewsApiResponse>(content);

                    

                    // Filter and return the 5 most recent articles for each language
                    var languageArticles = result.Articles
                        .Where(article => article.Title.Contains(companyName, StringComparison.OrdinalIgnoreCase))
                        .OrderByDescending(article => article.PublishedDate)
                        .Take(5)
                        .Select(article => new NewsArticle
                        {
                            Title = article.Title,
                            Author = article.Author,
                            Content = article.Content,
                            ArticleLink = article.ArticleLink,
                            PublishedDate = article.PublishedDate,
                            Language = language
                        })
                        .ToList();

                    recentArticles.AddRange(languageArticles);
                }
                else
                {
                    throw new Exception($"Unable to fetch news for language: {language}");
                }
            }
        }
        catch (Exception ex)
        {
            // Handle the exception, log it, and return an error response as needed
            throw new Exception($"An error occurred while fetching news: {ex.Message}");
        }

        return recentArticles;
    }
}
