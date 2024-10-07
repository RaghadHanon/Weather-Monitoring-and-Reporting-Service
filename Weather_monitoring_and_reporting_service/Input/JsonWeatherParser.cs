using System.Text.Json;
using System.Text.Json.Serialization;
using weather_monitoring_and_reporting_service.Core;

namespace weather_monitoring_and_reporting_service.Input;
public class JsonWeatherParser : IWeatherParserStrategy
{
    public WeatherData? ParseWeatherData(string input)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        return JsonSerializer.Deserialize<WeatherData>(input, options);
    }
}
