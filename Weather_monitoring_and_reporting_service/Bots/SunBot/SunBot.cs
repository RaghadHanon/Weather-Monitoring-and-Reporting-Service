using WeatherService.Bots.Interfaces;

namespace WeatherService.Bots.SunBot;
public class SunBot : IWeatherBot
{
    public SunBot() { }
    public SunBot(bool enabled, decimal temperatureThreshold, string message)
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