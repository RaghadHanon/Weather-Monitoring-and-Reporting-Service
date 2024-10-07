using weather_monitoring_and_reporting_service.Bots.Interfaces;

namespace weather_monitoring_and_reporting_service.Core;
public interface IWeatherDataNotifier
{ 
    public void RegisterObserver(IWeatherBotService observer);
    public void RegisterObservers(List<IWeatherBotService> observerList);
    public void RemoveObserver(IWeatherBotService observer);
    public void NotifyObservers(WeatherData weatherData);
}