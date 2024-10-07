using System.Text.Json.Serialization;
using System.Text.Json;
using weather_monitoring_and_reporting_service.Bots.Factories;
using weather_monitoring_and_reporting_service.Bots.Interfaces;

namespace weather_monitoring_and_reporting_service.Bots.SunBot;
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
