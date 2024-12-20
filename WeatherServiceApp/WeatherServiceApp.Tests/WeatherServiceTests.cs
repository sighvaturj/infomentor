using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;
using WeatherForecastAPI;

namespace WeatherServiceApp.Tests
{
    public class WeatherServiceTests
    {
        [Fact]
        public async Task GetWeatherDataAsync_ValidIds_ReturnsXmlDocument()
        {
            // Arrange
            var service = new WeatherService();
            string validIds = "5;6";

            // Act
            XDocument result = await service.GetWeatherDataAsync(validIds);

            // Assert
            Assert.NotEmpty(result.Descendants("text"));
        }

        [Fact]
        public async Task GetWeatherDataAsync_InvalidIds_ReturnsNotNull()
        {
            // Arrange
            var service = new WeatherService();
            string invalidIds = "invalid";

            // Act
            XDocument result = await service.GetWeatherDataAsync(invalidIds);

            // Assert
            Assert.NotNull(result);
        }
    }
}
