using System.Text.Json.Serialization;
using System.Text.Json;
using WeatherService.Bots.Factories;
using WeatherService.Bots.Interfaces;

namespace WeatherService.Bots.RainBot;

public class RainBotServiceCreator : BotServiceFactory
{
    public override IWeatherBotService CreateBotService(string config)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        var weatherBot = JsonSerializer.Deserialize<RainBot>(config, options);
        return new RainBotService(weatherBot);
    }
}
