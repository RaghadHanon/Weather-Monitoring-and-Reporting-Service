using weather_monitoring_and_reporting_service.Bots.Interfaces;
using weather_monitoring_and_reporting_service.Utilities;

namespace weather_monitoring_and_reporting_service.Bots.Factories;
public abstract class BotServiceFactory
{
    public abstract IWeatherBotService CreateBotService(string config);

    public static IWeatherBotService GetBotService(string botName, string config)
    {
        var botServiceCraetorClassName = $"weather_monitoring_and_reporting_service.Bots.{botName}.{botName}ServiceCreator";
        var botServiceCreatorType = Type.GetType(botServiceCraetorClassName);
        if (botServiceCreatorType == null)
            throw new ArgumentException($"{ErrorMessages.NoFactoryFoundForBot}{botName}");

        var botServiceCreatorObject = (BotServiceFactory)Activator.CreateInstance(botServiceCreatorType);
        var botService = botServiceCreatorObject.CreateBotService(config);
        return botService;
    }
}
