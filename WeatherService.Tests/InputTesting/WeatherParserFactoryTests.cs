using weather_reporting_service.Input;
using WeatherService.Input;
using FluentAssertions;

namespace WeatherService.Tests.InputTesting;
public class WeatherParserFactoryTests
{
    private IWeatherParserStrategy _strategy;
    private WeatherParserFactory sut;
    public WeatherParserFactoryTests()
    {
        sut = new WeatherParserFactory();
    }

    [Fact]
    public void WeatherParserFactory_ShouldReturnJSONWeatherParser_WhenInputIsJSON()
    {
        _strategy = sut.GetParser("""{"Location": "City Name", "Temperature": 32, "Humidity": 40}""");

        _strategy.Should().BeOfType<JsonWeatherParser>();
    }

    [Fact]
    public void WeatherParserFactory_ShouldReturnXMLWeatherParser_WhenInputIsXML()
    {
        _strategy = sut.GetParser("""<WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>""");

        _strategy.Should().BeOfType<XmlWeatherParser>();
    }

    [Theory]
    [InlineData(" ")]
    [InlineData(">")]
    [InlineData("}")]
    [InlineData("l")]
    public void WeatherParserFactory_ShouldThrowInvalidDataException_WhenInputIsInvalid(string input)
    {
        sut.Invoking(x => x.GetParser(input))
            .Should().Throw<InvalidDataException>();
    }
}