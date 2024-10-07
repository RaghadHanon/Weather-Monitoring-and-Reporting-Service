using weather_monitoring_and_reporting_service.Core;

namespace weather_monitoring_and_reporting_service.Bots.Interfaces;
public interface IWeatherBotService
{
    IWeatherBot Bot { get; set; }
    bool ShouldActivate(WeatherData weatherData);
    void GenerateBotResponse(WeatherData weatherData);
}