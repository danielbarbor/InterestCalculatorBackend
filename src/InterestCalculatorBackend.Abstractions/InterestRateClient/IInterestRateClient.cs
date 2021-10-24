using System.Threading.Tasks;

namespace InterestCalculatorBackend.Abstractions.InterestRateClient
{
    public interface IInterestRateClient
    {
        Task<double> ConsultInterestRateAsync(string host);
    }
}