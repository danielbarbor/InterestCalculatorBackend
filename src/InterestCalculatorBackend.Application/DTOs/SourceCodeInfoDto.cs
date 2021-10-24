namespace InterestCalculatorBackend.Application.DTOs
{
    public class SourceCodeInfoDto
    {
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