using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using InterestCalculatorBackend.Application.DTOs;
using InterestCalculatorBackend.WebAPI;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Xunit;
using WireMock.Server;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Settings;

namespace InterestCalculatorBackend.ApiIntegrationTest.WebAPI
{
    public class InterestCalculatorController : IClassFixture<WebApiApplicationFactory<Startup>>
    {
        private readonly WebApiApplicationFactory<Startup> _factory;
        
        private readonly WireMockServer _server;

        public InterestCalculatorController()
        {
            _factory = new WebApiApplicationFactory<Startup>();
            _server = WireMockServer.Start(3000);
        }
       
        [Fact]
        public async Task GetInterestCalculationMustReturnSuccess()
        {
            // Settings for interest rate server mock
            _server.Given(Request.Create().WithPath("/taxaJuros").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBody("0,01"));

            var client = _factory.CreateClient();
            
            var response = await client.GetAsync("calculajuros?valorinicial=1000&meses=12");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            
            Assert.NotEmpty(result);
            
            Assert.Equal("1126,82", result);
            
            _server.Dispose();
            
        }
        
        [Fact]
        public async Task GetInterestCalculationMustFailBecauseOfInvalidValue()
        {
            // Settings for interest rate server mock
            _server.Given(Request.Create().WithPath("/taxaJuros").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBody("0,01"));
            
            var client = _factory.CreateClient();
            
            var response = await client.GetAsync("calculajuros?valorinicial=0&meses=12");
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            
            Assert.NotEmpty(result);
            
            _server.Dispose();
        }
        
        [Fact]
        public async Task GetInterestCalculationMustFailBecauseOfInvalidMonthsValue()
        {
            // Settings for interest rate server mock
            _server.Given(Request.Create().WithPath("/taxaJuros").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBody("0,01"));
            
            var client = _factory.CreateClient();
            
            var response = await client.GetAsync("calculajuros?valorinicial=1000&meses=0");
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            
            Assert.NotEmpty(result);
            
            _server.Dispose();

        }
        
        [Fact]
        public async Task GetInterestCalculationMustFailBecauseOfBothInvalidValue()
        {
            // Settings for interest rate server mock
            _server.Given(Request.Create().WithPath("/taxaJuros").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBody("0,01"));
            
            var client = _factory.CreateClient();
            
            var response = await client.GetAsync("calculajuros?valorinicial=0&meses=0");
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            
            Assert.NotEmpty(result);
            
            _server.Dispose();

        }
        
        [Fact]
        public async Task GetInterestCalculationMustFailBecauseOfACommunicationException()
        {
            var client = _factory.CreateClient();
            
            var response = await client.GetAsync("calculajuros?valorinicial=1000&meses=12");
            
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

            _server.Dispose();

        }
        
    }
}