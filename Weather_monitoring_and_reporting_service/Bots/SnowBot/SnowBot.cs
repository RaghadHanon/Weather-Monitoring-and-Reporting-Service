using WeatherService.Bots.Interfaces;

namespace WeatherService.Bots.SnowBot;
public class SnowBot : IWeatherBot
{
    public SnowBot() { }

    public SnowBot(bool enabled, decimal temperatureThreshold, string message)
    {
        Enabled = enabled;
        TemperatureThreshold = temperatureThreshold;
        Message = message;
    }
    public bool Enabled { get; set; }
    public decimal TemperatureThreshold { get; set; }
    public string Message { get; set; }
    public override string? ToString()
    {
        return $$"""
                {
                    Enabled: {{Enabled}},
                    Temperature Threshold: {{TemperatureThreshold}}%,
                    Message: "{{Message}}"
                }
                """;
    }
}