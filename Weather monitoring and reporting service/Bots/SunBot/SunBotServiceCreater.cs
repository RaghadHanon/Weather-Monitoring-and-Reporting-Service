using System.Text.Json.Serialization;
using System.Text.Json;

namespace weather_monitoring_and_reporting_service;
public class SunBotServiceCreater : BotServiceFactory
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
