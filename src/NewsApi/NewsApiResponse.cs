using NewsApi.Models;
using Newtonsoft.Json;

public class NewsApiResponse
{
    [JsonProperty("articles")]
    public List<NewsArticle> Articles { get; set; }
}