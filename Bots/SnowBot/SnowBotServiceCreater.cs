using System.Text.Json;
using System.Text.Json.Serialization;

namespace weather_monitoring_and_reporting_service;
public class SnowBotServiceCreater : BotServiceFactory
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
