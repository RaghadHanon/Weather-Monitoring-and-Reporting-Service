using weather_monitoring_and_reporting_service.Input;

namespace weather_monitoring_and_reporting_service.Core;
public class WeatherDataProvider
{
    private IWeatherParserStrategy _weatherParserStrategy;
    public WeatherDataProvider() { }
    public WeatherDataProvider(IWeatherParserStrategy weatherParserStrategy)
    {
        _weatherParserStrategy = weatherParserStrategy;
    }
    public WeatherData WeatherData { get; private set; }
    public IWeatherDataNotifier WeatherDataNotifier { get; } = new WeatherDataNotifier();
    public void SetParser(IWeatherParserStrategy weatherParserStrategy)
    {
        _weatherParserStrategy = weatherParserStrategy;
    }

    public void ProcessWeatherData(string input)
    {
        WeatherData = _weatherParserStrategy.ParseWeatherData(input);
        WeatherDataNotifier.NotifyObservers(WeatherData);
    }
}
