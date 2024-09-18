namespace weather_monitoring_and_reporting_service;
public interface IWeatherParserStrategy
{
    public WeatherData ParseWeatherData(string input);
}
