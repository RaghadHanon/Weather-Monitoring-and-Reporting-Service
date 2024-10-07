using weather_monitoring_and_reporting_service.Bots.Interfaces;

namespace weather_monitoring_and_reporting_service.Bots.RainBot;
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