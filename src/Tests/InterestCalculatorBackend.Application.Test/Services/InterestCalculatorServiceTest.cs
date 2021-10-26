using System.Threading.Tasks;
using InterestCalculatorBackend.Abstractions.Application;
using InterestCalculatorBackend.Application.DTOs;
using InterestCalculatorBackend.Application.Services;
using Moq;
using Xunit;

namespace InterestCalculatorBackend.Application.Test.Services
{
    public class InterestCalculatorServiceTest
    {
        private readonly Mock<IInterestRateService> _rateServiceMock;
        
        public InterestCalculatorServiceTest()
        {
            _rateServiceMock = new Mock<IInterestRateService>();
        }

        [Fact]
        public async Task CalculateCompoundInterestAsyncTest()
        {
            _rateServiceMock.Setup(m => m.GetInterestRateNowAsync(It.IsAny<string>())).ReturnsAsync((string hostToConsult) => 0.01);

            IInterestCalculatorService<InputValueDto, OutputValueDto> calculatorService =
                new InterestCalculatorService(_rateServiceMock.Object);

            var inputDto = new InputValueDto(100, 5);

            var outputDto = await calculatorService.CalculateCompoundInterestAsync("http://localhost:8080", inputDto);
            
            Assert.Equal(105.10, outputDto.ResultValue);
            Assert.Equal("105,10", outputDto.ResultRepresentation);
        }
    }
}