using System.Text.Json;
using System.Text.Json.Serialization;

namespace weather_monitoring_and_reporting_service;
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
