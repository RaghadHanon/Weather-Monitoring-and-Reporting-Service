using WeatherService.Core;

namespace WeatherService.Input;
public interface IWeatherParserStrategy
{
    public WeatherData ParseWeatherData(string input);
}
