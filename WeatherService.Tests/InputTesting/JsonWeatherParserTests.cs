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
    public void ParseWeatherData_ShouldThrowArgumentNullException_WhenInputIsNullOrEmpty(string input)
    {
        _sut.Invoking(x => x.ParseWeatherData(input))
            .Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ParseWeatherData_ShouldReturnWeatherData_WhenInputIsValidJSON()
    {
        var result = _sut.ParseWeatherData("""{"Location": "City Name", "Temperature": 32, "Humidity": 40}""");

        result.Should().NotBeNull();
        result.Location.Should().Be("City Name");
        result.Temperature.Should().Be(32);
        result.Humidity.Should().Be(40);
    }

    [Theory]
    [InlineData("Invalid JSON")]
    [InlineData("""{ "Location": "City Name", "Temperature": "InvalidType", "Humidity": 40 }""")]
    public void ParseWeatherData_ShouldThrowInvalidOperationException_WhenJSONIsMalformed(string input)
    {
        _sut.Invoking(x => x.ParseWeatherData(input))
            .Should().Throw<InvalidOperationException>()
            .WithMessage($"{ErrorMessages.ErrorParsingJSONData}: *");
    }
}
