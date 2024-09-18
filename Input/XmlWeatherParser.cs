using System.Xml.Linq;

namespace weather_monitoring_and_reporting_service;
public class XmlWeatherParser : IWeatherParserStrategy
{
    public WeatherData? ParseWeatherData(string input)
    {
        var xmlElement = XDocument.Parse(input);
        var weatherData = new WeatherData
        {
            Location = xmlElement.Root.Element("Location").Value,
            Temperature = decimal.Parse(xmlElement.Root.Element("Temperature").Value),
            Humidity = decimal.Parse(xmlElement.Root.Element("Humidity").Value)
        };
        return weatherData;
    }
}
