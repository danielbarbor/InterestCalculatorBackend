using System.Globalization;
using System.Text.Json.Serialization;

namespace InterestCalculatorBackend.Application.DTOs
{
    public class OutputValueDto
    {
        [JsonPropertyName("result")]
        public double ResultValue { get; set; }
        
        [JsonPropertyName("result_string_representation")]
        public string ResultRepresentation { get; set; }

        public OutputValueDto(double resultValue, string resultRepresentation)
        {
            ResultValue = resultValue;
            ResultRepresentation = resultRepresentation;
        }
    }
}