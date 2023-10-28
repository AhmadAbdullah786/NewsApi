using Microsoft.AspNetCore.Mvc;

namespace NewsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly NewsApiService _newsApiService;


        public NewsController(NewsApiService newsApiService)
        {
            _newsApiService = newsApiService;
        }

        [HttpGet]
        [Route("GetRecentNews")]
        public async Task<IActionResult> GetRecentNews(string companyName)
        {
            try
            {
                var news = await _newsApiService.GetRecentNewsAsync(companyName);
                return Ok(news);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}