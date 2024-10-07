using FluentAssertions;
using WeatherService.Input;
using WeatherService.Utilities;

namespace WeatherService.Tests;
public class JsonWeatherParserTests
{
    private readonly JsonWeatherParser _sut;
    public JsonWeatherParserTests()
    {
        _sut = new JsonWeatherParser();
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
    [InlineData("""{"Location": "City Name", "Temperature": 32, "Humidity": 40}""")]
    public void ParseWeatherData_WhenInputIsValidJson_ShouldReturnWeatherData(string input)
    {
        var result = _sut.ParseWeatherData(input);

        result.Should().NotBeNull();
        result.Location.Should().Be("City Name");
        result.Temperature.Should().Be(32);
        result.Humidity.Should().Be(40);
    }

    [Theory]
    [InlineData("Invalid JSON")]
    [InlineData("""{ "Location": "City Name", "Temperature": "InvalidType", "Humidity": 40 }""")]
    public void ParseWeatherData_WhenJsonIsMalformed_ShouldThrowInvalidOperationException(string input)
    {
        _sut.Invoking(x => x.ParseWeatherData(input))
            .Should().Throw<InvalidOperationException>()
            .WithMessage($"{ErrorMessages.ErrorParsingJSONData}: *");
    }
}
