using WeatherService.Bots.Interfaces;

namespace WeatherService.Core;
public interface IWeatherDataNotifier
{ 
    public void RegisterObserver(IWeatherBotService observer);
    public void RegisterObservers(List<IWeatherBotService> observerList);
    public void RemoveObserver(IWeatherBotService observer);
    public void NotifyObservers(WeatherData weatherData);
}