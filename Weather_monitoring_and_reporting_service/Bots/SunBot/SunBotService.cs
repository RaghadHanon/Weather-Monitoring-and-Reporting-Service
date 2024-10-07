using WeatherService.Bots.Interfaces;
using WeatherService.Core;

namespace WeatherService.Bots.SunBot;
public class SunBotService : IWeatherBotService
{
    public SunBotService(SunBot bot)
    {
        Bot = bot;
    }
    public IWeatherBot Bot { get; set; }
    public bool ShouldActivate(WeatherData weatherData)
    {
        var sunBot = Bot as SunBot;
        return sunBot.Enabled && weatherData.Temperature > sunBot.TemperatureThreshold;
    }

    public void GenerateBotResponse(WeatherData weatherData)
    {
        if (ShouldActivate(weatherData))
        {
            var sunBot = Bot as SunBot;
            Console.WriteLine($"""
                           -------------------------------------------------------------------
                           |                                                                 |
                           |   SunBot activated!                                             |
                           |   SunBot: "{sunBot.Message}"                                    
                           |                                                                 |
                           -------------------------------------------------------------------

                           """);
        }
    }
}
