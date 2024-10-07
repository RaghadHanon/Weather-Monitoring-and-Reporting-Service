using WeatherService.Core;

namespace WeatherService.Bots.Interfaces;
public interface IWeatherBotService
{
    IWeatherBot Bot { get; set; }
    bool ShouldActivate(WeatherData weatherData);
    void GenerateBotResponse(WeatherData weatherData);
}