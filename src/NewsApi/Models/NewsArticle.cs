using Newtonsoft.Json;

namespace NewsApi.Models
{
    public class NewsArticle
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; }
        [JsonProperty("url")]
        public string ArticleLink { get; set; }
        public string  Language { get; set; }

        [JsonProperty("publishedAt")]
        public object PublishedAt { get; internal set; }
    }
}
