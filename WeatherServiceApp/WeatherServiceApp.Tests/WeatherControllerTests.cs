using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace WeatherServiceApp.Tests
{
    public class WeatherControllerTests : IClassFixture<WebApplicationFactory<WeatherForecastAPI.Startup>>
    {
        private readonly HttpClient _client;

        public WeatherControllerTests(WebApplicationFactory<WeatherForecastAPI.Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetWeather_ValidIds_ReturnsOk()
        {
            // Arrange
            string ids = "5;6";
            string url = $"/weather?ids={ids}";

            // Act
            HttpResponseMessage response = await _client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            Assert.False(string.IsNullOrEmpty(content));
        }
    }
}
