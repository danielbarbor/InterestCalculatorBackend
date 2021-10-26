using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace InterestCalculatorBackend.Application.DTOs
{
    public class SourceCodeInfoDto
    {
        [JsonPropertyName("source_code_url")]
        public string SourceCodeUrl { get; set; }

        public SourceCodeInfoDto()
        {
                
        }

        public SourceCodeInfoDto(string sourceCodeUrl)
        {
            SourceCodeUrl = sourceCodeUrl;
        }
    }
}