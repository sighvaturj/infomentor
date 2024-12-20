using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherForecastAPI;

namespace WeatherForecastAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // Base route is /Weather
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _weatherService;

        public WeatherController()
        {
            _weatherService = new WeatherService();
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetWeather([FromQuery] string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return BadRequest("Weather station IDs are required.");
            }

            var weatherData = await _weatherService.GetWeatherDataAsync(ids);

            if (weatherData == null)
            {
                return NotFound("Unable to fetch weather data.");
            }

            var idArray = ids.Split(";"); // Split IDs
            var parsedData = _weatherService.ParseWeatherData(weatherData, idArray); // Pass idArray here

            return Ok(parsedData);
        }


        [HttpGet]
        [Route("ByStation")]
        public async Task<IActionResult> GetWeatherByStation([FromQuery] string stationId)
        {
            if (string.IsNullOrEmpty(stationId))
            {
                return BadRequest("Station ID is required.");
            }

            var forecastData = await _weatherService.GetForecastDataAsync(stationId);

            if (forecastData == null)
            {
                return NotFound("Unable to fetch weather data for the station.");
            }

            // Navigate to the station and forecast elements
            var stationElement = forecastData.Root?
                .Elements("station")
                .FirstOrDefault(station => station.Attribute("id")?.Value == stationId);

            if (stationElement == null)
            {
                return NotFound("No data available for the specified station.");
            }

            // Extract the first 10 forecasts
            var limitedForecast = stationElement
                .Elements("forecast")
                .Take(10)
                .Select(f => new
                {
                    Time = f.Element("ftime")?.Value,
                    WindSpeed = f.Element("F")?.Value,
                    WindDirection = f.Element("D")?.Value,
                    Temperature = f.Element("T")?.Value,
                    Weather = f.Element("W")?.Value
                })
                .ToList();

            if (!limitedForecast.Any())
            {
                return NotFound("No forecast data available.");
            }

            return Ok(limitedForecast);
        }
    }
}
