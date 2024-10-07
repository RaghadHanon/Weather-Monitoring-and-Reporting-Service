using System.Text.Json;
using System.Text.Json.Serialization;
using weather_monitoring_and_reporting_service.Bots.Factories;
using weather_monitoring_and_reporting_service.Bots.Interfaces;

namespace weather_monitoring_and_reporting_service.Bots.SnowBot;
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
