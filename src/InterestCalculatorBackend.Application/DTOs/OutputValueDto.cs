using System.Globalization;
using System.Text.Json.Serialization;

namespace InterestCalculatorBackend.Application.DTOs
{
    public class OutputValueDto
    {
        /// <summary>
        /// The calculation result value as a double
        /// </summary>
        [JsonPropertyName("result")]
        public double ResultValue { get; set; }
        
        /// <summary>
        /// The calculation result value as a string 
        /// </summary>
        [JsonPropertyName("result_string_representation")]
        public string ResultRepresentation { get; set; }

        public OutputValueDto(double resultValue, string resultRepresentation)
        {
            ResultValue = resultValue;
            ResultRepresentation = resultRepresentation;
        }
    }
}