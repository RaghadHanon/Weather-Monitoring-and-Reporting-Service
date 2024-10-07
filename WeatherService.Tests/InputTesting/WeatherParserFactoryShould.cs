using weather_reporting_service.Input;
using WeatherService.Input;
using FluentAssertions;

namespace WeatherService.Tests.InputTesting;
public class WeatherParserFactoryShould
{
    private IWeatherParserStrategy _strategy;
    private WeatherParserFactory sut;
    public WeatherParserFactoryShould()
    {
        sut = new WeatherParserFactory();
    }

    [Theory]
    [InlineData("""{"Location": "City Name", "Temperature": 32, "Humidity": 40}""")]
    public void WeatherParserFactory_WhenJSONInput_ShouldReturnJSONWeatherParser(string input)
    {
        _strategy = sut.GetParserStrategy(input);

        _strategy.Should().BeOfType<JsonWeatherParser>();
    }

    [Theory]
    [InlineData("""<WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>""")]
    public void WeatherParserFactory_WhenXMLInput_ShouldReturnXMLWeatherParser(string input)
    {
        _strategy = sut.GetParserStrategy(input);

        _strategy.Should().BeOfType<XmlWeatherParser>();
    }

    [Theory]
    [InlineData(" ")]
    [InlineData(">")]
    [InlineData("}")]
    [InlineData("l")]
    public void WeatherParserFactory_WhenInvalidInput_ShouldThrowInvalidDataException(string input)
    {
        sut.Invoking(x => x.GetParserStrategy(input))
            .Should().Throw<InvalidDataException>();
    }
}