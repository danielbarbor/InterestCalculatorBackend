using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace InterestCalculatorBackend.Application.DTOs
{
    /// <summary>
    /// A DTO containing information from the remote source code repository
    /// </summary>
    public class SourceCodeInfoDto
    {
        /// <summary>
        /// The source code url as a string
        /// </summary>
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