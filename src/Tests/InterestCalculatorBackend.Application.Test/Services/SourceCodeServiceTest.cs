using InterestCalculatorBackend.Application.Services;
using Xunit;

namespace InterestCalculatorBackend.Application.Test.Services
{
    public class SourceCodeServiceTest
    {
        [Fact]
        public void ShowMeTheCodeTest()
        {
            var sourceCodeService = new SourceCodeService();

            var sourceCodeDto = sourceCodeService.ShowMeTheCode();
            
            Assert.Equal("https://github.com/danielbarbor/InterestCalculatorBackend", sourceCodeDto.SourceCodeUrl);
        }
    }
}