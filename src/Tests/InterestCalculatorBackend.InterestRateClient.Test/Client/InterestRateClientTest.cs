using System;
using System.Net.Http;
using System.Threading.Tasks;
using InterestCalculatorBackend.Abstractions.InterestRateClient;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace InterestCalculatorBackend.InterestRateClient.Test.Client
{
    public class InterestRateClientTest
    {
        private readonly WireMockServer _server;
        
        public InterestRateClientTest()
        {
            _server = WireMockServer.Start();
        }
        
        [Fact]
        public async Task ConsultInterestRateAsyncTestMustReturnSuccess()
        {
            _server.Given(Request.Create().WithPath("/taxaJuros").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBody("0.01"));
            
            IInterestRateClient client = new InterestRateClient.Client.InterestRateClient();
            
            var response = await client.ConsultInterestRateAsync(_server.Urls[0]);
            
            Assert.Equal(0.01, response);
        }
    }
}