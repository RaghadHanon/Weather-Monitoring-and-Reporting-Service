using weather_monitoring_and_reporting_service.Input;
using weather_monitoring_and_reporting_service.Utilities;

namespace weather_reporting_service.Input;
public class WeatherParserFactory
{
    public static IWeatherParserStrategy GetParserStrategy(string weatherInput)
    {
        if (weatherInput.StartsWith('{') || weatherInput.StartsWith('['))
            return new JsonWeatherParser();

        if (weatherInput.StartsWith('<'))
            return new XmlWeatherParser();

        throw new InvalidOperationException(ErrorMessages.UnsupportedWeatherDataFormat);
    }
}