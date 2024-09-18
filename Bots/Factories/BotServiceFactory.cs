namespace weather_monitoring_and_reporting_service;
public abstract class BotServiceFactory
{
    public abstract IWeatherBotService CreateBotService(string config);

    public static IWeatherBotService GetBotService(string botName, string config)
    {
        var botServiceCraeterClassName = $"weather_monitoring_and_reporting_service.{botName}ServiceCreater";
        var botServiceCreaterType = Type.GetType(botServiceCraeterClassName);
        if (botServiceCreaterType == null)
            throw new ArgumentException($"{ErrorMessages.NoFactoryFoundForBot}: {botName}");

        var botServiceCreaterObject = (BotServiceFactory)Activator.CreateInstance(botServiceCreaterType);
        var botService = botServiceCreaterObject.CreateBotService(config);
        return botService;
    }
}
