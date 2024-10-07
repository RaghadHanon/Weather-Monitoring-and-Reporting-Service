namespace WeatherService.Core;
public class WeatherData
{
    public WeatherData() { }
    public WeatherData(string location, decimal temperature, decimal humidity)
    {
        Location = location;
        Temperature = temperature;
        Humidity = humidity;
    }
    public string Location { get; set; }
    public decimal Temperature { get; set; }
    public decimal Humidity { get; set; }
    public override string? ToString()
    {
        return $"""

               Location : {Location},
               Temperature : {Temperature},
               Humidity : {Humidity}

               """;
    }
}
