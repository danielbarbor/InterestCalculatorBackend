using System.Threading.Tasks;
using InterestCalculatorBackend.Abstractions.Application;
using InterestCalculatorBackend.Abstractions.InterestRateClient;

namespace InterestCalculatorBackend.Application.Services
{
    public class InterestRateService : IInterestRateService
    {
        private readonly IInterestRateClient _rateClient;
        
        public InterestRateService(IInterestRateClient rateClient)
        {
            _rateClient = rateClient;
        }
        
        public async Task<double> GetInterestRateNowAsync()
        {
            var rate = await _rateClient.ConsultInterestRateAsync();

            return rate;
        }
    }
}