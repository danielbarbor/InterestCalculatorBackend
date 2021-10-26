using System;
using System.Globalization;
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
            
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ",";
            provider.NumberGroupSeparator = ".";

            return Convert.ToDouble(rate, provider);
        }
    }
}