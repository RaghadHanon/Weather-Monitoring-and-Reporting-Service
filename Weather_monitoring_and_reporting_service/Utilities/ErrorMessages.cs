using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeatherService.Utilities;
public class ErrorMessages
{
    public const string FileNotFound = "File Not Found";
    public const string FileEmpty = "File is Empty";
    public const string ProcessingFileError = "Error while Processing File";
    public const string ProcessingWeatherDataError = "Error processing weather data";
    public const string UnsupportedWeatherDataFormat = "Unsupported weather data format";
    public const string InvalidInput = "Invalid input.";
    public const string NoFactoryFoundForBot = "No factory found for bot: ";
    public const string InputIsNullOrEmpty = "Input is null or empty.";
    public const string ErrorParsingJSONData = "Error parsing JSON data";
    public const string ErrorParsingXMLData = "Error parsing XML data";
    public const string DeserializedWeatherXMLDataIsNull = "Deserialized WeatherData is null. The input might not match the expected XML structure.";
    public const string DeserializedWeatherJSONDataIsNull = "Deserialized WeatherData is null. The input might not match the expected JSON structure.";





}