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
        public string SourceCodeUrl { get; set; }

        public SourceCodeInfoDto(string sourceCodeUrl)
        {
            SourceCodeUrl = sourceCodeUrl;
        }
    }
}