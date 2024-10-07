using System.Text.Json.Serialization;
using System.Text.Json;
using WeatherService.Bots.Factories;
using WeatherService.Bots.Interfaces;

namespace WeatherService.Bots.SunBot;
public class SunBotServiceCreator : BotServiceFactory
{
    public override IWeatherBotService CreateBotService(string config)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        var weatherBot = JsonSerializer.Deserialize<SunBot>(config, options);
        return new SunBotService(weatherBot);
    }
}
