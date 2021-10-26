using System.Threading.Tasks;
using InterestCalculatorBackend.Abstractions.Application;
using InterestCalculatorBackend.Abstractions.InterestRateClient;
using InterestCalculatorBackend.Application.Services;
using Moq;
using Xunit;

namespace InterestCalculatorBackend.Application.Test.Services
{
    public class InterestRateServiceTest
    {
        private readonly Mock<IInterestRateClient> _rateClientMock;
        
        public InterestRateServiceTest()
        {
            _rateClientMock = new Mock<IInterestRateClient>();
        }

        [Fact]
        public async Task GetInterestRateTest()
        {
            _rateClientMock.Setup(m => m.ConsultInterestRateAsync(It.IsAny<string>())).ReturnsAsync((string host) => 0.01);
            
            IInterestRateService rateService = new InterestRateService(_rateClientMock.Object);

            var rate = await rateService.GetInterestRateNowAsync("http://localhost:8080");
            
            Assert.Equal(0.01, rate);
        }

    }
}