namespace weather_monitoring_and_reporting_service;
public interface IWeatherDataNotifier
{ 
    public void RegisterObserver(IWeatherBotService observer);
    public void RegisterObservers(List<IWeatherBotService> observerList);
    public void RemoveObserver(IWeatherBotService observer);
    public void NotifyObservers(WeatherData weatherData);
}