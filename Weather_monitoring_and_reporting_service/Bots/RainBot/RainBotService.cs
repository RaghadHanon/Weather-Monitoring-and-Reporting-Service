using WeatherService.Bots.Interfaces;
using WeatherService.Core;

namespace WeatherService.Bots.RainBot;
public class RainBotService : IWeatherBotService
{
    public RainBotService(RainBot bot)
    {
        Bot = bot;
    }
    public IWeatherBot Bot { get; set; }
    public bool ShouldActivate(WeatherData weatherData)
    {
        var rainBot = Bot as RainBot;
        return rainBot.Enabled && weatherData.Humidity > rainBot.HumidityThreshold;
    }

    public void GenerateBotResponse(WeatherData weatherData)
    {
        if (ShouldActivate(weatherData))
        {
            var rainBot = Bot as RainBot;
            Console.WriteLine($"""
                           -------------------------------------------------------------------
                           |                                                                 |
                           |   RainBot activated!                                            |
                           |   RainBot: "{rainBot.Message}"                
                           |                                                                 |
                           -------------------------------------------------------------------
                           
                           """);
        }
    }
}
