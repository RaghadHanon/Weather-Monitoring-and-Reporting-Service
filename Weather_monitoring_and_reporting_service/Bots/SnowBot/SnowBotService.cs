using WeatherService.Bots.Interfaces;
using WeatherService.Core;

namespace WeatherService.Bots.SnowBot;
public class SnowBotService : IWeatherBotService
{
    public SnowBotService(SnowBot bot)
    {
        Bot = bot;
    }
    public IWeatherBot Bot { get; set; }
    public bool ShouldActivate(WeatherData weatherData)
    {
        var snowBot = Bot as SnowBot;
        return snowBot.Enabled && weatherData.Temperature < snowBot.TemperatureThreshold;
    }

    public void GenerateBotResponse(WeatherData weatherData)
    {
        if (ShouldActivate(weatherData))
        {
            var snowBot = Bot as SnowBot;
            Console.WriteLine($"""
                           -------------------------------------------------------------------
                           |                                                                 |
                           |   SnowBot activated!                                            |
                           |   SnowBot: "{snowBot.Message}"                                  
                           |                                                                 |
                           -------------------------------------------------------------------
                           
                           """);
        }
    }
}
