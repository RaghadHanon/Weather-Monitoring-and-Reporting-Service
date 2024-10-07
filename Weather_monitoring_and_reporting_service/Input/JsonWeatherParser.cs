using System.Text.Json;
using System.Text.Json.Serialization;
using WeatherService.Core;
using WeatherService.Utilities;

namespace WeatherService.Input;
public class JsonWeatherParser : IWeatherParserStrategy
{
    public WeatherData? ParseWeatherData(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentNullException(ErrorMessages.InputIsNullOrEmpty);
        }

        try
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            return JsonSerializer.Deserialize<WeatherData>(input, options);
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException($"{ErrorMessages.ErrorParsingJSONData}: {ex.Message}", ex);
        }
    }
}