using Newtonsoft.Json;

namespace NewsApi.Models
{
    public class NewsArticle
    {
        public string Title { get; set; }
        public string Author { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("publishedAt")]
        public DateTime PublishedDate { get; set; }
        [JsonProperty("url")]
        public string ArticleLink { get; set; }
        public string  Language { get; set; }
    }
}
