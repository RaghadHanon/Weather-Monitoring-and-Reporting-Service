using WeatherService.Input;
using WeatherService.Utilities;

namespace weather_reporting_service.Input;
public class WeatherParserFactory
{
    public IWeatherParserStrategy GetParser(string weatherInput)
    {
        if (weatherInput.StartsWith('{') || weatherInput.StartsWith('['))
            return new JsonWeatherParser();

        if (weatherInput.StartsWith('<'))
            return new XmlWeatherParser();

        throw new InvalidDataException(ErrorMessages.UnsupportedWeatherDataFormat);
    }
}