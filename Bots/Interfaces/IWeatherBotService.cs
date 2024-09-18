namespace weather_monitoring_and_reporting_service;
public interface IWeatherBotService
{
    IWeatherBot Bot { get; set; }
    bool ShouldActivate(WeatherData weatherData);
    void BotResponse(WeatherData weatherData);
}