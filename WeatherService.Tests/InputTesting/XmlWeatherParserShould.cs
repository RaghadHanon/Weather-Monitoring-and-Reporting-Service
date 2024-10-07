using FluentAssertions;
using WeatherService.Input;
using WeatherService.Utilities;

namespace WeatherService.Tests;
public class XmlWeatherParserShould
{
    private readonly XmlWeatherParser _sut;
    public XmlWeatherParserShould()
    {
        _sut = new XmlWeatherParser();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void ParseWeatherData_WhenInputIsNullOrEmpty_ShouldThrowArgumentNullException(string input)
    {
        _sut.Invoking(x => x.ParseWeatherData(input))
            .Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData("<WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>")]
    public void ParseWeatherData_WhenInputIsValidXml_ShouldReturnWeatherData(string input)
    {
        var result = _sut.ParseWeatherData(input);

        result.Should().NotBeNull();
        result.Location.Should().Be("City Name");
        result.Temperature.Should().Be(32);
        result.Humidity.Should().Be(40);
    }

    [Theory]
    [InlineData("Invalid XML")]
    [InlineData("<WeatherData><Location>City Name</Location><Temperature>InvalidType</Temperature><Humidity>40</Humidity></WeatherData>")]
    public void ParseWeatherData_WhenXmlIsMalformed_ShouldThrowInvalidOperationException(string input)
    {
        _sut.Invoking(x => x.ParseWeatherData(input))
            .Should().Throw<InvalidOperationException>()
            .WithMessage($"{ErrorMessages.ErrorParsingXMLData}: *");
    }
}
