using System;
using System.Threading.Tasks;
using InterestCalculatorBackend.Abstractions.InterestRateClient;
using InterestCalculatorBackend.InterestRateClient.CommunicationInterfaces;
using Refit;

namespace InterestCalculatorBackend.InterestRateClient.Client
{
    public class InterestRateClient : IInterestRateClient
    {
        public InterestRateClient()
        {
            
        }
        public async Task<double> ConsultInterestRateAsync(string host)
        {
            var client = RestService.For<IInterestRateCommunication>(host);

            var rate = await client.GetInterestRateAsync();

            return rate;
        }
    }
}