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
        [Route("GetRecentNewsByCompanyNameAndInMultipleLanguage")]
        public async Task<IActionResult> GetRecentNewsByCompanyNameAndInMultipleLanguage(string companyName, string languageCodes)
        {
            try
            {
                var news = await _newsApiService.GetRecentNewsByCompanyNameAndInMultipleLanguageAsync(companyName, languageCodes);
                return Ok(news);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}