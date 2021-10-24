using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using InterestCalculatorBackend.Application.DTOs;
using InterestCalculatorBackend.WebAPI;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace InterestCalculatorBackend.ApiIntegrationTest.WebAPI
{
    public class InterestCalculatorController : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public InterestCalculatorController()
        {
            _factory = new WebApplicationFactory<Startup>();
        }
        
        [Fact]
        public async Task GetInterestCalculationMustReturnSuccess()
        {
            var client = _factory.CreateClient();
            
            var response = await client.GetAsync("calculajuros?valorinicial=1000&meses=12");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            
            Assert.NotEmpty(result);
            
            var outputValueDto = JsonSerializer.Deserialize<OutputValueDto>(result);
            
            Assert.NotNull(outputValueDto);
            
            Assert.Equal(1126.82, outputValueDto.ResultValue);
            
            Assert.Equal("1126.82", outputValueDto.ResultRepresentation);
            
        }
        
        [Fact]
        public async Task GetInterestCalculationMustFailBecauseOfInvalidValue()
        {
            var client = _factory.CreateClient();
            
            var response = await client.GetAsync("calculajuros?valorinicial=0&meses=12");
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            
            Assert.NotEmpty(result);

        }
        
        [Fact]
        public async Task GetInterestCalculationMustFailBecauseOfInvalidMonthsValue()
        {
            var client = _factory.CreateClient();
            
            var response = await client.GetAsync("calculajuros?valorinicial=1000&meses=0");
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            
            Assert.NotEmpty(result);

        }
        
        [Fact]
        public async Task GetInterestCalculationMustFailBecauseOfBothInvalidValue()
        {
            var client = _factory.CreateClient();
            
            var response = await client.GetAsync("calculajuros?valorinicial=0&meses=0");
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            
            Assert.NotEmpty(result);

        }
        
    }
}