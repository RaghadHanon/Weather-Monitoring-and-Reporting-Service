using WeatherService.Bots.Interfaces;

namespace WeatherService.Bots.RainBot;
public class RainBot : IWeatherBot
{
    public RainBot() { }

    public RainBot(bool enabled, decimal humidityThreshold, string message)
    {
        Enabled = enabled;
        HumidityThreshold = humidityThreshold;
        Message = message;
    }
    public bool Enabled { get; set; }
    public decimal HumidityThreshold { get; set; }
    public string Message { get; set; }
    public override string? ToString()
    {
        return $$"""
                {
                    Enabled: {{Enabled}},
                    Humidity Threshold: {{HumidityThreshold}}%,
                    Message: "{{Message}}"
                }
                """;
    }
}