using System.Xml.Serialization;

namespace weather_monitoring_and_reporting_service;
public class XmlWeatherParser : IWeatherParserStrategy
{
    public WeatherData? ParseWeatherData(string input)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(WeatherData));

        using (TextReader reader = new StringReader(input))
        {
            return (WeatherData)serializer.Deserialize(reader);
        }
    }
}
