using System.Text.Json;
using WeatherService.Bots.Factories;
using WeatherService.Bots.Interfaces;
using WeatherService.Utilities;

namespace WeatherService.Bots.Configurations;
public class BotsConfigurations
{
    private List<IWeatherBotService> _botsServices { get; set; } = new List<IWeatherBotService>();
    public List<IWeatherBotService> LoadBotConfiguration()
    {
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var filePath = Path.Combine(baseDirectory, @"..\..\..\botsConfig.json");
        var fullPath = Path.GetFullPath(filePath);

        if (!File.Exists(fullPath))
        {
            Console.WriteLine(ErrorMessages.FileNotFound);
            return null;
        }

        try
        {
            var configJson = File.ReadAllText(fullPath);
            var jsonObject = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(configJson);
            foreach (var botEntry in jsonObject)
            {
                var botName = botEntry.Key;
                var botConfig = botEntry.Value.GetRawText();
                var botService = BotServiceFactory.GetBotService(botName, botConfig);
                _botsServices.Add(botService);
            }
            return _botsServices;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ErrorMessages.ProcessingFileError} {ex.Message}");
            return null;
        }
    }
}
