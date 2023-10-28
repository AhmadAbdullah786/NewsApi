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
        [Route("GetRecentNewsByCompanyNameAndLanguage")]
        public async Task<IActionResult> GetRecentNewsByCompanyNameAndLanguage(string companyName, string language)
        {
            try
            {
                var news = await _newsApiService.GetRecentNewsByCompanyNameAndLanguageAsync(companyName,language);
                return Ok(news);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}