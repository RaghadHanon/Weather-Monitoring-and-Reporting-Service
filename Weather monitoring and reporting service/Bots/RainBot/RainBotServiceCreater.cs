using System.Text.Json.Serialization;
using System.Text.Json;

namespace weather_monitoring_and_reporting_service;
public class RainBotServiceCreater : BotServiceFactory
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
