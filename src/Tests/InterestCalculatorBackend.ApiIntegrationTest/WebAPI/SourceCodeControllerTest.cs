using System.Threading.Tasks;
using InterestCalculatorBackend.WebAPI;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using System.Text.Json;
using InterestCalculatorBackend.Application.DTOs;

namespace InterestCalculatorBackend.ApiIntegrationTest.WebAPI
{
    public class SourceCodeControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public SourceCodeControllerTest()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [Fact]
        public async Task GetSourceCodeUrlMustReturnSuccess()
        {
            var client = _factory.CreateClient();
            
            var response = await client.GetAsync("showmethecode");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            
            Assert.NotEmpty(result);
            
            Assert.Equal("https://github.com/danielbarbor/InterestCalculatorBackend", result);
            
        }
    }
}