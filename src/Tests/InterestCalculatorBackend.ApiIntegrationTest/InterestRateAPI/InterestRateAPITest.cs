using System;
using System.Globalization;
using System.Threading.Tasks;
using InterestCalculatorBackend.InterestRateAPI;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace InterestCalculatorBackend.ApiIntegrationTest.InterestRateAPI
{
    public class InterestRateAPITest : IClassFixture<WebApplicationFactory<Startup>>
    {
        
        private readonly WebApplicationFactory<Startup> _factory;

        public InterestRateAPITest()
        {
            _factory = new WebApplicationFactory<Startup>();
        }
        
        [Fact]
        public async Task GetInterestRateMustReturnSuccess()
        {
            var client = _factory.CreateClient();
            
            var response = await client.GetAsync("taxaJuros");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            
            Assert.NotEmpty(result);
            
            Assert.Equal("0,01", result);
            
        }
    }
}