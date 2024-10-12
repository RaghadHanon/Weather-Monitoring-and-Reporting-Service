using FluentAssertions;
using WeatherService.Input;
using WeatherService.Utilities;

namespace WeatherService.Tests;
public class XmlWeatherParserTests
{
    private readonly XmlWeatherParser _sut;
    public XmlWeatherParserTests()
    {
        _sut = new XmlWeatherParser();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void ParseWeatherData_ShouldThrowArgumentNullException_WhenInputIsNullOrEmpty(string input)
    {
        _sut.Invoking(x => x.ParseWeatherData(input))
            .Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ParseWeatherData_ShouldReturnWeatherData_WhenInputIsValidXML()
    {
        var result = _sut.ParseWeatherData("<WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>");

        result.Should().NotBeNull();
        result.Location.Should().Be("City Name");
        result.Temperature.Should().Be(32);
        result.Humidity.Should().Be(40);
    }

    [Theory]
    [InlineData("Invalid XML")]
    [InlineData("<WeatherData><Location>City Name</Location><Temperature>InvalidType</Temperature><Humidity>40</Humidity></WeatherData>")]
    public void ParseWeatherData_ShouldThrowInvalidOperationException_WhenXMLIsMalformed(string input)
    {
        _sut.Invoking(x => x.ParseWeatherData(input))
            .Should().Throw<InvalidOperationException>()
            .WithMessage($"{ErrorMessages.ErrorParsingXMLData}: *");
    }
}
