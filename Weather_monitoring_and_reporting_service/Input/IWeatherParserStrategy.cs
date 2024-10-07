using weather_monitoring_and_reporting_service.Core;

namespace weather_monitoring_and_reporting_service.Input;
public interface IWeatherParserStrategy
{
    public WeatherData ParseWeatherData(string input);
}
