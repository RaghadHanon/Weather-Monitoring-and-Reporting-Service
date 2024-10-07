using FluentAssertions;
using WeatherService.Bots.Factories;
using WeatherService.Bots.Interfaces;
using WeatherService.Bots.RainBot;
using WeatherService.Bots.SnowBot;
using WeatherService.Bots.SunBot;
using WeatherService.Utilities;

namespace WeatherService.Tests.BotServiceFactoryTesting;
public class BotServiceFactoryShould
{
    private IWeatherBotService _weatherBotService;

    [Theory]
    [InlineData("RainBot", """{ "enabled": true,"humidityThreshold": 70,"message": "It looks like it's about to pour down!"}""")]
    public void GetBotService_WhenInputIsRainBotConfiguration_ShouldReturnRainBotService(string botName, string config)
    {
        _weatherBotService = BotServiceFactory.GetBotService(botName, config);
        var rainBot = (RainBot)_weatherBotService.Bot;

        _weatherBotService.Should().BeOfType<RainBotService>();
        rainBot.Enabled.Should().Be(true);
        rainBot.HumidityThreshold.Should().Be(70);
        rainBot.Message.Should().Be("It looks like it's about to pour down!");
    }

    [Theory]
    [InlineData("SnowBot", """{"enabled": false,"temperatureThreshold": 0,"message": "Brrr, it's getting chilly!" }""")]
    public void GetBotService_WhenInputIsSnowBotConfiguration_ShouldReturnSnowBotService(string botName, string config)
    {
        _weatherBotService = BotServiceFactory.GetBotService(botName, config);
        var snowBot = (SnowBot)_weatherBotService.Bot;

        _weatherBotService.Should().BeOfType<SnowBotService>();
        snowBot.Enabled.Should().Be(false);
        snowBot.TemperatureThreshold.Should().Be(0);
        snowBot.Message.Should().Be("Brrr, it's getting chilly!");
    }

    [Theory]
    [InlineData("SunBot", """{"enabled": true, "temperatureThreshold": 30,"message": "Wow, it's a scorcher out there!"}""")]
    public void GetBotService_WhenInputIsSunBotConfiguration_ShouldReturnSunBotService(string botName, string config)
    {
        _weatherBotService = BotServiceFactory.GetBotService(botName, config);
        var sunBot = (SunBot)_weatherBotService.Bot;

        _weatherBotService.Should().BeOfType<SunBotService>();
        sunBot.Enabled.Should().Be(true);
        sunBot.TemperatureThreshold.Should().Be(30);
        sunBot.Message.Should().Be("Wow, it's a scorcher out there!");
    }

    [Theory]
    [InlineData("InvalidBotName", "")]
    public void GetBotService_WhenInvalidBotName_ShouldThrowArgumentException(string botName, string config)
    {
        var act = () => BotServiceFactory.GetBotService(botName, config);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"{ErrorMessages.NoFactoryFoundForBot}{botName}");
    }
}
