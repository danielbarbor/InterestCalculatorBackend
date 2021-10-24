using InterestCalculatorBackend.Abstractions.Application;
using InterestCalculatorBackend.Application.DTOs;

namespace InterestCalculatorBackend.Application.Services
{
    public class SourceCodeService : ISourceCodeService<SourceCodeInfoDto>
    {
        public SourceCodeInfoDto ShowMeTheCode()
        {
            return new SourceCodeInfoDto("https://github.com/danielbarbor/InterestCalculatorBackend");
        }
    }
}