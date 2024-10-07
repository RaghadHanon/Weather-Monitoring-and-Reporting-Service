using weather_monitoring_and_reporting_service.Bots.Configurations;
using weather_monitoring_and_reporting_service.Core;
using weather_monitoring_and_reporting_service.Utilities;
using weather_reporting_service.Input;

namespace weather_monitoring_and_reporting_service;
public class Program
{
    private BotsConfigurations _botsConfigurations;
    private WeatherDataProvider _weatherDataProvider;
    public static void Main(string[] args)
    {
        var program = new Program();
        var LogIn = true;
        while (LogIn)
        {
            Console.Write("""

                              1. Log in.
                              2. Log out.

                              Please, Select an option(1 - 2):
                              
                              """);

            int.TryParse(Console.ReadLine(), out int option);
            switch (option)
            {
                case 1:
                    program.Run();
                    break;
                case 2:
                    LogIn = false;
                    break;
                default:
                    Console.WriteLine(ErrorMessages.InvalidInput);
                    break;
            }
        }
    }

    public void Run()
    {
        _botsConfigurations = new BotsConfigurations();
        _weatherDataProvider = new WeatherDataProvider();
        ConfigureBots();
        var weatherInput = GetWeatherDataFromUser();
        if (string.IsNullOrEmpty(weatherInput))
        {
            Console.WriteLine(ErrorMessages.InvalidInput);
            return;
        }

        try
        {
            SetWeatherParserStrategy(weatherInput);
            _weatherDataProvider.ProcessWeatherData(weatherInput);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ErrorMessages.ProcessingWeatherDataError}: {ex.Message}");
        }
    }

    private void ConfigureBots()
    {
        var botServices = _botsConfigurations.LoadBotConfiguration();
        if (botServices != null && botServices.Any())
        {
            _weatherDataProvider.WeatherDataNotifier.RegisterObservers(botServices);
        }
    }

    private string GetWeatherDataFromUser()
    {
        Console.WriteLine("\n\nEnter weather data (JSON or XML):");
        return Console.ReadLine()?.Trim();
    }

    private void SetWeatherParserStrategy(string weatherInput)
    {
        var parserStrategy = WeatherParserFactory.GetParserStrategy(weatherInput);
        _weatherDataProvider.SetParser(parserStrategy);
    }
}
