using System.Xml.Serialization;
using WeatherService.Core;
using WeatherService.Utilities;

namespace WeatherService.Input
{
    public class XmlWeatherParser : IWeatherParserStrategy
    {
        public WeatherData? ParseWeatherData(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException(ErrorMessages.InputIsNullOrEmpty);
            }

            try
            {
                var serializer = new XmlSerializer(typeof(WeatherData));
                using (var reader = new StringReader(input)) 
                {
                    return (WeatherData?)serializer.Deserialize(reader);
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"{ErrorMessages.ErrorParsingXMLData}: {ex.Message}", ex);
            }
        }
    }
}
