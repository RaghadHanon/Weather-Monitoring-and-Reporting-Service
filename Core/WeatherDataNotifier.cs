namespace weather_monitoring_and_reporting_service;
public class WeatherDataNotifier : IWeatherDataNotifier
{
    private readonly List<IWeatherBotService> _observers = new List<IWeatherBotService>();
    public void RegisterObserver(IWeatherBotService observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
    }

    public void RegisterObservers(List<IWeatherBotService> observerList)
    {
        foreach (var observer in observerList)
        {
            RegisterObserver(observer);
        }
    }

    public void RemoveObserver(IWeatherBotService observer)
    {
        if (_observers.Contains(observer))
        {
            _observers.Remove(observer);
        }
    }

    public void NotifyObservers(WeatherData weatherData)
    {
        foreach (var observer in _observers)
        {
            observer.BotResponse(weatherData);
        }
    }
}
