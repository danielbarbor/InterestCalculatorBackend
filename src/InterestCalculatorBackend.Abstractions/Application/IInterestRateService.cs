using System.Threading.Tasks;

namespace InterestCalculatorBackend.Abstractions.Application
{
    public interface IInterestRateService
    {
        public Task<double> GetInterestRateNowAsync();
    }
}