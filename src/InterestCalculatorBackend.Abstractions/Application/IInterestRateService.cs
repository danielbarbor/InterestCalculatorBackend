using System.Threading.Tasks;

namespace InterestCalculatorBackend.Abstractions.Application
{
    public interface IInterestRateService
    {
        Task<double> GetInterestRateNowAsync(string hostToConsult);
    }
}