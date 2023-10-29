using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Moq;
using NewsApi.Controllers;
using NewsApi.Models;
using Xunit;

namespace NewsApi.Tests
{
    public class NewsControllerTests
    {
        [Fact]
        public async Task GetRecentNewsShouldReturnOK()
        {

            var newsServiceMock = new Mock<NewsApiService>();
            var controller = new NewsController(newsServiceMock.Object);

            var result = await controller.GetRecentNewsByCompanyNameAndInMultipleLanguage("Microsoft", "en");


            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}