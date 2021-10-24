using System.Threading.Tasks;
using Refit;

namespace InterestCalculatorBackend.InterestRateClient.CommunicationInterfaces
{
    public interface IInterestRateCommunication
    {
        [Get("/taxaJuros")]
        Task<double> GetInterestRateAsync();
    }
}