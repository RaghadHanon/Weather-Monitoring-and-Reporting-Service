using System.Text.Json;
using System.Text.Json.Serialization;
using WeatherService.Bots.Factories;
using WeatherService.Bots.Interfaces;

namespace WeatherService.Bots.SnowBot;
public class SnowBotServiceCreator : BotServiceFactory
{
    public override IWeatherBotService CreateBotService(string config)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        var weatherBot = JsonSerializer.Deserialize<SnowBot>(config, options);
        return new SnowBotService(weatherBot);
    }
}
