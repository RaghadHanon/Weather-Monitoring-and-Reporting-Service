using FluentAssertions;
using WeatherService.Bots.Factories;
using WeatherService.Bots.Interfaces;
using WeatherService.Bots.RainBot;
using WeatherService.Bots.SnowBot;
using WeatherService.Bots.SunBot;
using WeatherService.Utilities;

namespace WeatherService.Tests.BotServiceFactoryTesting;
public class BotServiceFactoryTests
{
    private IWeatherBotService _weatherBotService;

    [Fact]
    public void GetBotService_ShouldReturnRainBotService_WhenInputIsRainBotConfiguration()
    {
        _weatherBotService = BotServiceFactory.GetBotService("RainBot", """{ "enabled": true,"humidityThreshold": 70,"message": "It looks like it's about to pour down!"}""");
        var rainBot = (RainBot)_weatherBotService.Bot;

        _weatherBotService.Should().BeOfType<RainBotService>();
        rainBot.Enabled.Should().Be(true);
        rainBot.HumidityThreshold.Should().Be(70);
        rainBot.Message.Should().Be("It looks like it's about to pour down!");
    }

    [Fact]
    public void GetBotService_ShouldReturnSnowBotService_WhenInputIsSnowBotConfiguration()
    {
        _weatherBotService = BotServiceFactory.GetBotService("SnowBot", """{"enabled": false,"temperatureThreshold": 0,"message": "Brrr, it's getting chilly!" }""");
        var snowBot = (SnowBot)_weatherBotService.Bot;

        _weatherBotService.Should().BeOfType<SnowBotService>();
        snowBot.Enabled.Should().Be(false);
        snowBot.TemperatureThreshold.Should().Be(0);
        snowBot.Message.Should().Be("Brrr, it's getting chilly!");
    }

    [Fact]
    public void GetBotService_ShouldReturnSunBotService_WhenInputIsSunBotConfiguration()
    {
        _weatherBotService = BotServiceFactory.GetBotService("SunBot", """{"enabled": true, "temperatureThreshold": 30,"message": "Wow, it's a scorcher out there!"}""");
        var sunBot = (SunBot)_weatherBotService.Bot;

        _weatherBotService.Should().BeOfType<SunBotService>();
        sunBot.Enabled.Should().Be(true);
        sunBot.TemperatureThreshold.Should().Be(30);
        sunBot.Message.Should().Be("Wow, it's a scorcher out there!");
    }

    [Fact]
    public void GetBotService_ShouldThrowArgumentException_WhenBotNameIsInvalid()
    {
        var act = () => BotServiceFactory.GetBotService("InvalidBotName", "");

        act.Should().Throw<ArgumentException>()
            .WithMessage($"{ErrorMessages.NoFactoryFoundForBot}{"InvalidBotName"}");
    }
}
