using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WeatherForecastAPI
{
    public class WeatherService
    {
        private const string ApiUrl = "https://xmlweather.vedur.is";

        public async Task<XDocument> GetWeatherDataAsync(string ids)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{ApiUrl}/?op_w=xml&type=txt&lang=is&view=xml&ids={ids}";
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string xmlString = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("API Response: \n" + xmlString);

                    return XDocument.Parse(xmlString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
                return null;
            }
        }

        public async Task<XDocument> GetForecastDataAsync(string stationId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{ApiUrl}/?op_w=xml&type=forec&lang=is&view=xml&ids={stationId}";
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string xmlString = await response.Content.ReadAsStringAsync();
                    return XDocument.Parse(xmlString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching forecast data: {ex.Message}");
                return null;
            }
        }

        public List<object> ParseWeatherData(XDocument xmlDocument, string[] ids)
        {
            var results = new List<object>();

            if (xmlDocument == null)
            {
                return results;
            }

            try
            {
                var idIndex = 0;

                foreach (var textElement in xmlDocument.Descendants("text"))
                {
                    var weatherData = new
                    {
                        Id = idIndex < ids.Length ? ids[idIndex] : null, // Assign ID based on index
                        Title = textElement.Element("title")?.Value,
                        Creation = textElement.Element("creation")?.Value,
                        ValidFrom = textElement.Element("valid_from")?.Value,
                        ValidTo = textElement.Element("valid_to")?.Value,
                        Content = textElement.Element("content")?.Value
                    };

                    results.Add(weatherData);
                    idIndex++; // Increment index to map to the next ID
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing XML: {ex.Message}");
            }

            return results;
        }
    }
}
