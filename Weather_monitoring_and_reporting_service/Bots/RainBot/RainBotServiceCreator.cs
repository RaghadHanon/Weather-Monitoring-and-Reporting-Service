using System.Text.Json.Serialization;
using System.Text.Json;
using weather_monitoring_and_reporting_service.Bots.Factories;
using weather_monitoring_and_reporting_service.Bots.Interfaces;

namespace weather_monitoring_and_reporting_service.Bots.RainBot;

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
