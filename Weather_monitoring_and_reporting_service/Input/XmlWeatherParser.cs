using System.Xml.Serialization;
using weather_monitoring_and_reporting_service.Core;

namespace weather_monitoring_and_reporting_service.Input;
public class XmlWeatherParser : IWeatherParserStrategy
{
    public WeatherData? ParseWeatherData(string input)
    {
        var serializer = new XmlSerializer(typeof(WeatherData));

        using (TextReader reader = new StringReader(input))
        {
            return (WeatherData)serializer.Deserialize(reader);
        }
    }
}
