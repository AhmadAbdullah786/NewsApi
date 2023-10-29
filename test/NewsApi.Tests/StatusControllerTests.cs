using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NewsApi.Controllers;
using Xunit;

namespace NewsApi.Tests
{
    public class StatusControllerTests
    {
        [Fact]
        public void StatusEnspointShouldReturnHTTP200()
        {
            var controller = new NewsController();
            var result = controller.Get();
            var okResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}